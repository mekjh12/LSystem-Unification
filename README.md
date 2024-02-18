# LSystem-ContextSensitive

LSystem을 위한 통합 버전
* Basic LSystem
* Stochastic Basic LSystem
* Context-sensitive Basic LSystem

![image](https://github.com/mekjh12/LSystem-Unification/assets/122244587/985ee840-12e4-4289-ac08-e0f221e0400b)

![image](https://github.com/mekjh12/LSystem-Unification/assets/122244587/2b26bda3-56ac-4dc2-babf-ad3d31110160)

# Developmental surface models (p.123)

현재부터 MString생성을 string으로 생성 후 explicit cast.
```c#
 LSystemUnif lSystem = new LSystemUnif(_rnd);
 GlobalParam globalParam = new GlobalParam();
 float delta = globalParam.Add("delta", 5);
 float d = globalParam.Add("d", 1);

 MString axiom = (MString)"[A][B]";                

 lSystem.AddRule(ProductionNumber.P1, "A", varCount: 0, g: globalParam,
     condition: (t, p, n) => true,
     func: (MChar c, MChar p, MChar n, GlobalParam g) => (MString)"[+A{.].C.}");

 lSystem.AddRule(ProductionNumber.P2, "B", varCount: 0, g: globalParam,
     condition: (t, p, n) => true,
     func: (MChar c, MChar p, MChar n, GlobalParam g) => (MString)"[-B{.].C.}");

 lSystem.AddRule(ProductionNumber.P2, "C", varCount: 0, g: globalParam,
     condition: (t, p, n) => true,
     func: (MChar c, MChar p, MChar n, GlobalParam g) => (MString)"G(0.5)C");

 Console.WriteLine("axiom=" + axiom);
 MString sentence = lSystem.Generate(axiom, 20);
 Console.WriteLine("result=" + sentence);
```
![image](https://github.com/mekjh12/LSystem-Unification/assets/122244587/a37f9334-9501-46e7-a0b5-76fd34958464)


```c#
GlobalParam globalParam = new GlobalParam();
globalParam.Add("d", 4);
globalParam.Add("m", 2);
globalParam.Add("u", 1);

lSystem.AddRule("a", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] < globalParam["m"], 
    func: (MChar c, MChar p, MChar n, GlobalParam g)
     => MChar.Char("a", c[0] + 1).ToMString());

lSystem.AddRule("a", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] == globalParam["m"],
    func: (MChar c, MChar p, MChar n, GlobalParam g)
     => MChar.Char("I") + MChar.Open + MChar.Char("L") + MChar.Close + MChar.Char("a", 1));

lSystem.AddRule("D", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] < globalParam["d"],
    func: (MChar c, MChar p, MChar n, GlobalParam g)
     => MChar.Char("D", c[0] + 1).ToMString());

lSystem.AddRule("D", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] == globalParam["d"],
    func: (MChar c, MChar p, MChar n, GlobalParam g)
     => MChar.Char("S", 1).ToMString());

lSystem.AddRule("S", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] < globalParam["u"],
    func: (MChar c, MChar p, MChar n, GlobalParam g)
     => MChar.Char("S", c[0] + 1).ToMString());

lSystem.AddRule("S", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] == globalParam["u"],
    func: (MChar c, MChar p, MChar n, GlobalParam g)
     => MChar.Empty.ToMString());

lSystem.AddRule("I", varCount: 0, leftContext:"S", 1, g: globalParam,
    condition: (t, p, n) => p[0] == globalParam["u"],
    func: (MChar c, MChar p, MChar n, GlobalParam g)
     => MChar.Char("I") + MChar.Char("S", 1));

lSystem.AddRule("a", varCount: 1, leftContext: "S", 1, g: globalParam,
    condition: (t, p, n) => true,
    func: (MChar c, MChar p, MChar n, GlobalParam g)
     => MChar.I + MChar.Open + MChar.L + MChar.Close + MChar.A);

lSystem.AddRule("A", varCount: 0, g: globalParam,
    condition: (t, p, n) => true,
    func: (MChar c, MChar p, MChar n, GlobalParam g) => MChar.K.ToMString());

MString axiom = MChar.Char("D", 1) + MChar.Char("a", 1);
Console.WriteLine("axiom=" + axiom);
MString sentence = lSystem.Generate(axiom, 8);
Console.WriteLine(sentence);
```

## A Family of simple leaves generated using a parametric L-system. p.124
```c#
LSystemUnif lSystem = new LSystemUnif(_rnd);
GlobalParam globalParam = new GlobalParam();
float delta = globalParam.Add("delta", 60);
float d = globalParam.Add("d", 1);
float LA = globalParam.Add("LA", 5);
float RA = globalParam.Add("RA", 1);
float LB = globalParam.Add("LB", 0.6f);
float RB = globalParam.Add("RB", 1.06f);
float PD = globalParam.Add("PD", 0.25f);

MString axiom = (MString)"{.A(0)}";
lSystem.AddRule(ProductionNumber.P1, "A", varCount: 1, g: globalParam,
    condition: (t, p, n) => true,
    func: (MChar t, MChar p, MChar n, GlobalParam g)
    => (MString)$"G({LA},{RA})[-B({t[0]}).][A({t[0] + 1})][+B({t[0]}).]");

lSystem.AddRule(ProductionNumber.P2, "B", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] > 0,
    func: (MChar t, MChar p, MChar n, GlobalParam g) => (MString)$"G({LB},{RB})B({t[0] - PD})");

lSystem.AddRule(ProductionNumber.P3, "G", varCount: 2, g: globalParam,
    condition: (t, p, n) => true,
    func: (MChar t, MChar p, MChar n, GlobalParam g) => (MString)$"G({t[0] * t[1]},{t[1]})");
```
![image](https://github.com/mekjh12/LSystem-Unification/assets/122244587/b5f0652b-30e4-445b-8c42-d3e8e01a61c9)

## A rose leaf. p.126
```c#
GlobalParam globalParam = new GlobalParam();
float delta = globalParam.Add("delta", 60);
float LA = globalParam.Add("LA", 5);
float RA = globalParam.Add("RA", 1.15f);
float LB = globalParam.Add("LB", 1.3f);
float RB = globalParam.Add("RB", 1.25f);
float LC = globalParam.Add("LC", 3);
float RC = globalParam.Add("RC", 1.19f);

MString axiom = (MString)"[{A(0,0).}][{A(0,1).}]";

lSystem.AddRule(ProductionNumber.P1, "A", varCount: 2, g: globalParam,
    condition: (t, p, n) => t[1] == 0,
    func: (MChar t, MChar p, MChar n, GlobalParam g) =>
    (MString)$".G({LA},{RA}).[+B({t[0]})G({LC},{RC},{t[0]}).}}][+B({t[0]}){{.]A({t[0] + 1},{t[1]})");

lSystem.AddRule(ProductionNumber.P2, "A", varCount: 2, g: globalParam,
    condition: (t, p, n) => t[1] == 1,
    func: (MChar t, MChar p, MChar n, GlobalParam g) =>
    (MString)$".G({LA},{RA}).[-B({t[0]})G({LC},{RC},{t[0]}).}}][-B({t[0]}){{.]A({t[0] + 1},{t[1]})");

lSystem.AddRule(ProductionNumber.P3, "B", varCount: 1, g: globalParam,
    condition: (t, p, n) => t[0] > 0,
    func: (MChar t, MChar p, MChar n, GlobalParam g) => (MString)$"G({LB},{RB})B({t[0] - 1})");

lSystem.AddRule(ProductionNumber.P4, "G", varCount: 2, g: globalParam,
    condition: (t, p, n) => true,
    func: (MChar t, MChar p, MChar n, GlobalParam g) => (MString)$"G({t[0] * t[1]},{t[1]})");

lSystem.AddRule(ProductionNumber.P5, "G", varCount: 3, g: globalParam,
    condition: (t, p, n) => t[2] > 1,
    func: (MChar t, MChar p, MChar n, GlobalParam g) => (MString)$"G({t[0] * t[1]},{t[1]},{t[2] - 1})");

Console.WriteLine("axiom=" + axiom);
MString sentence = lSystem.Generate(axiom, n: 25);
```
![image](https://github.com/mekjh12/LSystem-Unification/assets/122244587/4354f4b5-0603-4ac5-942a-1b736b633153)



## Structure of a lily-of-the-valley flower. p.128
```c#
LSystemUnif lSystem = new LSystemUnif(_rnd);

GlobalParam globalParam = new GlobalParam();
float delta = globalParam.Add("delta", 5);
float d = globalParam.Add("d", 1);

MString axiom = (MString)"G(18)  [X(36)A]/(-72)[X(36)B]  [X(36)A]/(-72)[X(36)B]  [X(36)A]/(-72)[X(36)B]  [X(36)A]/(-72)[X(36)B]  [X(36)A]/(-72)[X(36)B] ";

lSystem.AddRule(ProductionNumber.P1, "A", varCount: 0, g: globalParam,
    condition: (t, p, n) => true,
    func: (MChar t, MChar p, MChar n, GlobalParam g) => (MString)$"[&G(1)A{{.].");

lSystem.AddRule(ProductionNumber.P2, "B", varCount: 0, g: globalParam,
    condition: (t, p, n) => true,
    func: (MChar t, MChar p, MChar n, GlobalParam g) => (MString)$"B&.G(1).}}");

lSystem.AddRule(ProductionNumber.P3, "X", varCount: 1, g: globalParam,
    condition: (t, p, n) => true,
    func: (MChar t, MChar p, MChar n, GlobalParam g) => (MString)$"X({t[0] + 4.5f})");

Console.WriteLine("axiom=" + axiom);
MString sentence = lSystem.Generate(axiom, n: 14);
```
![image](https://github.com/mekjh12/LSystem-Unification/assets/122244587/f7f3d3c7-8be9-40c2-8af6-14284bbc5e05)

