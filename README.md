# Developmental surface models (p.123)
```c#
 LSystemUnif lSystem = new LSystemUnif(_rnd);
 GlobalParam globalParam = new GlobalParam();
 float delta = globalParam.Add("delta", 10);
 float d = globalParam.Add("d", 1);

 MChar G = MChar.Char("G", d);
 MChar A = MChar.A;
 MChar B = MChar.B;
 MChar C = MChar.C;
 MChar plus = MChar.Char("+", delta);
 MChar minus = MChar.Char("-", delta);
 MChar open = MChar.Char("{");
 MChar close = MChar.Char("}");
 MChar dot = MChar.Char(".");

 MString axiom = MChar.Open + A + MChar.Close + MChar.Open + B + MChar.Close;

 lSystem.AddRule("p1", "A", varCount: 0, g: globalParam,
     condition: (t, p, n) => true,
     func: (MChar c, MChar p, MChar n, GlobalParam g)
         => MChar.Open + plus + A + open + dot + MChar.Close + dot + C + dot + close
         );

 lSystem.AddRule("p2", "B", varCount: 0, g: globalParam,
     condition: (t, p, n) => true,
     func: (MChar c, MChar p, MChar n, GlobalParam g)
         => MChar.Open + minus + B + open + dot + MChar.Close + dot + C + dot + close
         );

 lSystem.AddRule("p3", "C", varCount: 0, g: globalParam,
     condition: (t, p, n) => true,
     func: (MChar c, MChar p, MChar n, GlobalParam g)
         => G + C
         );

 Console.WriteLine("axiom=" + axiom);
 MString sentence = lSystem.Generate(axiom, 18);
 Console.WriteLine("result=" + sentence);
```
![image](https://github.com/mekjh12/LSystem-Unification/assets/122244587/a37f9334-9501-46e7-a0b5-76fd34958464)

# LSystem-ContextSensitive

LSystem을 위한 통합 버전
* Basic LSystem
* Stochastic Basic LSystem
* Context-sensitive Basic LSystem

```c#
GlobalParam globalParam = new GlobalParam();
globalParam.Add("d", 4);
globalParam.Add("m", 2);
globalParam.Add("u", 1);

lSystem.AddRule("a", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] < globalParam["m"], 
    func: (MChar c, MChar p, MChar n, GlobalParam g) => MChar.Char("a", c[0] + 1).ToMString());

lSystem.AddRule("a", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] == globalParam["m"],
    func: (MChar c, MChar p, MChar n, GlobalParam g) => MChar.Char("I") + MChar.Open + MChar.Char("L") + MChar.Close + MChar.Char("a", 1));

lSystem.AddRule("D", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] < globalParam["d"],
    func: (MChar c, MChar p, MChar n, GlobalParam g) => MChar.Char("D", c[0] + 1).ToMString());

lSystem.AddRule("D", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] == globalParam["d"],
    func: (MChar c, MChar p, MChar n, GlobalParam g) => MChar.Char("S", 1).ToMString());

lSystem.AddRule("S", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] < globalParam["u"],
    func: (MChar c, MChar p, MChar n, GlobalParam g) => MChar.Char("S", c[0] + 1).ToMString());

lSystem.AddRule("S", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] == globalParam["u"],
    func: (MChar c, MChar p, MChar n, GlobalParam g) => MChar.Empty.ToMString());

lSystem.AddRule("I", varCount: 0, leftContext:"S", 1, g: globalParam,
    condition: (t, p, n) => p[0] == globalParam["u"],
    func: (MChar c, MChar p, MChar n, GlobalParam g) => MChar.Char("I") + MChar.Char("S", 1));

lSystem.AddRule("a", varCount: 1, leftContext: "S", 1, g: globalParam,
    condition: (t, p, n) => true,
    func: (MChar c, MChar p, MChar n, GlobalParam g) => MChar.I + MChar.Open + MChar.L + MChar.Close + MChar.A);

lSystem.AddRule("A", varCount: 0, g: globalParam,
    condition: (t, p, n) => true,
    func: (MChar c, MChar p, MChar n, GlobalParam g) => MChar.K.ToMString());

MString axiom = MChar.Char("D", 1) + MChar.Char("a", 1);
Console.WriteLine("axiom=" + axiom);
MString sentence = lSystem.Generate(axiom, 8);
Console.WriteLine(sentence);
```
```js
axiom=D(1)a(1)
0=D(2)a(2)
1=D(3)I[L]a(1)
2=D(4)I[L]a(2)
3=S(1)I[L]I[L]a(1)
4=IS(1)[L]I[L]a(2)
5=I[L]IS(1)[L]I[L]a(1)
6=I[L]I[L]IS(1)[L]a(2)
7=I[L]I[L]I[L]I[L]A
8=I[L]I[L]I[L]I[L]K
```
