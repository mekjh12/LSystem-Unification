using System;
using System.Collections;
using System.Collections.Generic;

namespace LSystem
{
    public enum ProductionNumber
    {
        P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, 
        P11, P12, P13, P14, P15, P16, P17, P18, P19, P20, 
        P21, P22, P23, P24, P25, P26, P27, P28, P29, P30, 
        P31, P32, P33, P34, P35, P36, P37, P38, P39, P40, 
        P41, P42, P43, P44, P45, P46, P47, P48, P49, P50,
    }

    public delegate bool Condition(MChar mchar, MChar pchar, MChar nchar);

    public delegate MString MultiVariableFunc(MChar mchar, MChar pchar, MChar nchar, GlobalParam g);

    public class GlobalParam
    {
        Dictionary<string, float> _value;

        public GlobalParam()
        {
            _value = new Dictionary<string, float>();
        }

        public float Add(string key, float value)
        {
            _value.Add(key, value);
            return value;
        }

        public bool ContainsKey(string key)
        {
            return _value.ContainsKey(key);
        }

        public float this[string key]
        {
            get => _value[key];
            set => _value[key] = value;
        }
        
    }

    public struct Production
    {
        MultiVariableFunc _func;
        Condition _condition;
        MChar _left;
        MChar _right;
        MChar _predecessor;
        GlobalParam _g;
        float _probability;

        public MChar Predecessor => _predecessor;

        public float Probability => _probability;

        public MChar Left => _left;

        public MChar Right => _right;

        public GlobalParam GlobalParam => _g;

        public MultiVariableFunc Func => _func;

        public Condition Condition => _condition;

        public Production(Condition condition, GlobalParam g, MultiVariableFunc func, MChar predecessor, MChar left, MChar right, float probability)
        {
            _func = func;
            _g = g;
            _condition = condition;
            _left = left;
            _right = right;
            _probability = probability;
            _predecessor = predecessor;
        }
    }

    public struct MChar
    {
        string _alphabet;
        float[] _parametric;
        
        public int Length => _parametric.Length;

        public float this[int i] => _parametric[i];

        public float[] Parametric
        {
            get => _parametric;
            set => _parametric = value;
        }

        public string Alphabet => _alphabet;

        public static MChar Char(string alphabet, params float[] values) => new MChar(alphabet, values);

        public static MChar Null => new MChar("null");

        public MChar(string alphabet, int varCount)
        {
            _alphabet = alphabet;
            _parametric = new float[varCount];
            for (int i = 0; i < varCount; i++)
            {
                _parametric[i] = 0.0f;
            }
        }

        public MChar(string alphabet, params float[] param)
        {
            _alphabet = alphabet;
            _parametric = param;
        }

        /// <summary>
        /// 알파벳과 매개변수의 갯수가 동시에 일치하면 서로 같다고 판별한다.
        /// </summary>
        /// <param name="mchar"></param>
        /// <returns></returns>
        public bool IsSameNumOfInParameter(MChar mchar)
        {
            return _alphabet == mchar.Alphabet && Length == mchar.Length;
        }

        public override string ToString()
        {
            string txt = "";
            txt += $"{_alphabet}(";
            for (int i = 0; i < _parametric.Length; i++)
            {
                txt += _parametric[i] + ((i < _parametric.Length - 1) ? "," : "");
            }
            txt += ")";
            return txt;
        }

        public static MString operator +(MChar a, MChar b)
        {
            return new MString(new MChar[] { a, b });
        }

        public static bool operator !=(MChar a, MChar b)
        {
            return a.Alphabet != b.Alphabet;
        }

        public static bool operator ==(MChar a, MChar b)
        {
            return a.Alphabet == b.Alphabet;
        }

        public override bool Equals(Object o)
        {
            return this.Alphabet == ((MChar)o).Alphabet;
        }

        public MString ToMString()=> new MString(new MChar[] { this });
    }


    public class MString: IEnumerator, IEnumerable
    {
        MChar[] _chars;
        int position = -1;

        public static MString Null => new MString();

        public int Length => _chars.Length;

        public MChar this[int i] => _chars[i];

        public MString(params MChar[] mchar)
        {
            _chars = mchar;
        }

        public object Current => _chars[position];        

        public override string ToString()
        {
            string txt = "";
            foreach (MChar item in _chars)
            {
                int count = item.Parametric.Length;
                if (count == 0)
                {
                    txt += item.Alphabet;
                }
                else
                {
                    txt += $"{item.Alphabet}(";
                    for (int i = 0; i < count; i++)
                    {
                        txt += item.Parametric[i]
                            + ((i < item.Parametric.Length - 1) ? "," : "");
                    }
                    txt += ")";
                }
            }
            return txt;
        }

        public static explicit operator MString(string txt)
        {
            GlobalParam g = LSystemUnif.GlobalParameter;
            txt = txt.Replace(" ", ""); // 공백을 제거한다.

            int start = 0;
            string newstr = "";
            while(start < txt.Length - 1)
            {
                if (txt.Substring(start, 1) == "<")
                {
                    int b = txt.IndexOf(">", start);
                    if (start < b) // replace
                    {
                        string key = txt.Substring(start + 1, b - start - 1);
                        float value = g.ContainsKey(key) ? g[key] : 1.0f;
                        if (!g.ContainsKey(key))
                            Console.WriteLine($"global parameter {key} don't exits.");
                        newstr = txt.Substring(0, start) + value + txt.Substring(b + 1);
                        txt = newstr;
                        start = b + 1;
                        continue;
                    }
                }
                start++;
            }


            MString str = MString.Null;
            for (int i = 0; i < txt.Length; i++)
            {
                char chr = txt[i];
                if (i + 1 < txt.Length)
                {
                    if (txt[i + 1] == '(')
                    {
                        int j = txt.IndexOf(")", i + 1);
                        if (i < j)
                        {
                            string[] cols = txt.Substring(i + 2, j - i - 2).Split(',');
                            float[] pars = new float[cols.Length];
                            for (int k = 0; k < pars.Length; k++) pars[k] = float.Parse(cols[k].Trim());
                            str += MChar.Char(chr.ToString(), pars);
                            i = j;
                            continue;
                        }
                        else
                        {
                            new Exception("구문 오류[괄호()]입니다.");
                        }
                    }
                    else
                    {
                        str += MChar.Char(chr.ToString());
                    }
                }
                else
                {
                    str += MChar.Char(chr.ToString());
                }
            }
            return str;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _chars.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        public static MString operator +(MString a, MString b)
        {
            MString mString = new MString();
            List<MChar> list = new List<MChar>();
            list.AddRange(a._chars);
            list.AddRange(b._chars);
            mString._chars = list.ToArray();
            return mString;
        }

        public static MString operator +(MString a, MChar b)
        {
            MString mString = new MString();
            List<MChar> list = new List<MChar>();
            list.AddRange(a._chars);
            list.Add(b);
            mString._chars = list.ToArray();
            return mString;
        }

        public static MString operator +(MChar b, MString a)
        {
            MString mString = new MString();
            List<MChar> list = new List<MChar>();
            list.Add(b);
            list.AddRange(a._chars);
            mString._chars = list.ToArray();
            return mString;
        }
    }
}
