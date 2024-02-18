using OpenGL;
using System;
using System.Collections.Generic;

namespace LSystem
{
    public class LSystemUnif
    {
        static GlobalParam _globalParam;

        public static GlobalParam GlobalParameter => _globalParam;

        Dictionary<ProductionNumber, List<Production>> _productions;
        static Random _rnd;
        string _sentence;

        public string Sentence => _sentence;

        public static Vertex3f RandomColor3 => new Vertex3f((float)_rnd.NextDouble(), (float)_rnd.NextDouble(), (float)_rnd.NextDouble());

        public static Vertex2f RandomVertex2f => new Vertex2f((float)_rnd.NextDouble(), (float)_rnd.NextDouble());

        public static float RandomFloat(float min = 0.0f, float max = 1.0f) => (max - min) * (float)_rnd.NextDouble() + min;

        public LSystemUnif(Random random)
        {
            _rnd = random;
            _globalParam = new GlobalParam();
        }

        public float AddParameter(string key, float value)
        {
            if (!_globalParam.ContainsKey(key))
            {
                _globalParam.Add(key, value);
            }
            else
            {
                _globalParam[key] = value;
            }
            return value;
        }        

        public void AddRule(ProductionNumber key, string alphabet, int varCount, string leftContext, int leftVarCount,
            Condition condition, MultiVariableFunc func, float probability = 1.0f)
        {
            MChar predecessor = new MChar(alphabet, varCount);
            MChar left = new MChar(leftContext, leftVarCount);

            Production production = new Production(condition, _globalParam, func, predecessor, left, MChar.Null, probability);
            AddRule(key, production);
        }

        public void AddRule(ProductionNumber key, string alphabet, int varCount, 
            Condition condition,  MultiVariableFunc func, float probability = 1.0f)
        {
            MChar predecessor = new MChar(alphabet, varCount);
            Production production = new Production(condition, _globalParam, func, predecessor, MChar.Null, MChar.Null, probability);
            AddRule(key, production);
        }

        public void AddRule(ProductionNumber key, Production production)
        {
            // p1: A(x,y) : y<3 => A(2x, x+y)
            if (_productions == null) _productions = new Dictionary<ProductionNumber, List<Production>>();

            if (_productions.ContainsKey(key))
            {
                _productions[key].Add(production);
            }
            else
            {
                List<Production> list = new List<Production>();
                list.Add(production);
                _productions.Add(key, list);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axiom"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public MString Generate(MString axiom, int n, bool isPrintDebug = false)
        {
            MString mString = axiom;

            for (int i = 0; i < n; i++)
            {
                MString oldString = mString;

                Stack<MChar> stack = new Stack<MChar>();
                Stack<int> indexStack = new Stack<int>();
                int chNum = 0;

                // nstr 초기화하여 oldstring->nstr로 복사한다.
                MString[] nstr = new MString[oldString.Length]; 
                for (int j = 0; j < nstr.Length; j++)
                    nstr[j] = oldString[j].ToMString();

                // (1) 줄의 문자마다 순회한다.
                for (int k = 0; k < oldString.Length; k++)
                {
                    MChar inChar = oldString[k];

                    // 스택을 이용하여 트리구조의 leftChar를 쌓아 경로를 만든다.
                    #region
                    if (inChar.Alphabet == "[") 
                    {
                        indexStack.Push(chNum);
                        chNum = 0;
                    }
                    else if (inChar.Alphabet == "]")
                    {
                        for (int j = 0; j < chNum; j++) stack.Pop();
                        chNum = indexStack.Pop();
                    }
                    else
                    {
                        stack.Push(inChar);
                        chNum++;
                    }
                    #endregion

                    // left Context를 위한 context-load
                    #region
                    string leftContext = stack.String();
                    
                    MChar leftChar;                    
                    if (stack.Count == 0)
                    {
                        leftChar = MChar.Null;
                    }
                    else
                    {
                        MChar temp = stack.Pop();
                        leftChar = (stack.Count == 0) ? MChar.Null : stack.Peek();
                        stack.Push(temp);
                    }
                    #endregion

                    // (2) 키에 맞는 Productions 규칙마다 순회한다.
                    foreach (KeyValuePair<ProductionNumber, List<Production>> items in _productions)
                    {
                        List<Production> satisfiedProd = new List<Production>();

                        // 조건에 맞는 Production 만 선별한다.
                        foreach (Production prod in items.Value) // 만족하는 Production을 모은다.
                        {
                            MChar mchar = prod.Predecessor;
                            if (!mchar.IsSameNumOfInParameter(inChar)) continue; // 매개변수 수가 일치하는가?

                            // left context가 없으면,                               
                            if (prod.Left == MChar.Null)
                            {
                                // Production Condition을 만족하면
                                if (prod.Condition(inChar, leftChar, MChar.Null))
                                {
                                    satisfiedProd.Add(prod);
                                }
                            }
                            // left context가 있으면, 문자만 일치하면 된다.
                            else
                            {
                                if (prod.Left.Alphabet == leftChar.Alphabet)
                                {
                                    // Production Condition을 만족하면
                                    if (prod.Condition(inChar, leftChar, MChar.Null))
                                    {
                                        satisfiedProd.Add(prod);
                                    }
                                }
                            }
                        }
                        
                        if (satisfiedProd.Count > 0)
                        {
                            // 랜덤사건을 통하여 해당되는 Production을 고른다.
                            #region
                            float sum = 0.0f; // 해당 키의 확률의 합을 구한다.
                            foreach (Production prod in satisfiedProd)
                                sum += prod.Probability;

                            float incidentProbability = sum * (float)_rnd.NextDouble(); // 사건의 확률을 만든다.
                            int indexIncident = 0;
                            sum = 0.0f;
                            for (int a = 0; a < satisfiedProd.Count; a++)
                            {
                                sum += satisfiedProd[a].Probability;
                                if (incidentProbability < sum)
                                {
                                    indexIncident = a;
                                    break;
                                }
                            }
                            #endregion

                            // 치환해야 할 Production을 실행한다. 
                            Production incidentProd = satisfiedProd[indexIncident];
                            nstr[k] = incidentProd.Func(inChar, leftChar, MChar.Null, incidentProd.GlobalParam); // 치환
                        }

                    }
                }

                // 각 문자마다 치환된 문자에 대하여 새로운 문자열을 이어붙인다.
                MString newString = MString.Null;
                for (int j = 0; j < nstr.Length; j++)
                {
                    newString += nstr[j];
                }

                mString = newString;
                if (isPrintDebug) Console.WriteLine($"{i+1} = {newString}");
                oldString = newString;
            }

            _sentence = mString.ToString();
            return mString;
        }
    }
}
