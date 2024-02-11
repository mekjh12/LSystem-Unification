# LSystem-ContextSensitive

LSystem을 위한 통합 버전
* Basic LSystem
* Stochastic Basic LSystem
* Context-sensitive Basic LSystem


# Developmental surface models (p.123)
```c#
 ![image](https://github.com/mekjh12/LSystem-Unification/assets/122244587/ce021221-12d3-40fd-a640-02243159e087)

```
![image](https://github.com/mekjh12/LSystem-Unification/assets/122244587/a37f9334-9501-46e7-a0b5-76fd34958464)


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
