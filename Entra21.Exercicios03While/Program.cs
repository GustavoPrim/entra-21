﻿using Entra21.Exercicios03While;

Console.WriteLine(@"         MENU           
01 - Exercício 01
02 - Exercício 02
03 - Exercício 03
04 - Exercício 04
05 - Exercício 05
06 - Exercício 06
07 - Exercício 07
08 - Exercício 08
09 - Exercício 09
10 - Exercício 10
11 - Exercício 11
12 - Exercício 12
13 - Exercício 13
14 - Exercicio 14
15 - Exercício 15
16 - Exercício 16
17 - Exercício 17 ");

Console.Write("Informe o exercício desejado: ");
int menuDesejado = Convert.ToInt32(Console.ReadLine());

Console.Clear();

if (menuDesejado == 1)
{
    Exercicio01 exercicio01 = new Exercicio01();
    exercicio01.Executar();
}
else if (menuDesejado == 2)
{
    Exercicio02 exercicio02 = new Exercicio02();
    exercicio02.Executar();
}
else if (menuDesejado == 3)
{
    Exercicio03 exercicio03 = new Exercicio03();
    exercicio03.Executar();
}
else if (menuDesejado == 4)
{
    Exercicio04 exercicio04 = new Exercicio04();
    exercicio04.Executar();
}
else if (menuDesejado == 5)
{
    Exercicio05 exercicio05 = new Exercicio05();
    exercicio05.Executar();
}
else if (menuDesejado == 6)
{
    Exercicio06 exercicio06 = new Exercicio06();
    exercicio06.Executar();
}
else if (menuDesejado == 7)
{
    Exercicio07 exercicio07 = new Exercicio07();
    exercicio07.Executar();
}
else if (menuDesejado == 8)
{
    Exercicio08 exercicio08 = new Exercicio08();
    exercicio08.Executar();
}
else if (menuDesejado == 9)
{
    Exercicio09 exercicio09 = new Exercicio09();
    exercicio09.Executar();
}
else if (menuDesejado == 10)
{
    Exercicio10 exercicio10 = new Exercicio10();
    exercicio10.Executar();
}
else if (menuDesejado == 11)
{
    Exercicio11 exercicio11 = new Exercicio11();
    exercicio11.Executar();
}
else if (menuDesejado == 12)
{
    Exercicio12 exercicio12 = new Exercicio12();
    exercicio12.Executar();
}
else if (menuDesejado == 13)
{
    Exercicio13 exercicio13 = new Exercicio13();
    exercicio13.Executar();
}
else if (menuDesejado == 14)
{
    Exercicio14 exercicio14 = new Exercicio14();
    exercicio14.Executar();
}
else if (menuDesejado == 15)
{
    Exercicio15 exercicio15 = new Exercicio15();
    exercicio15.Executar();
}
else if (menuDesejado == 16)
{
    Exercicio16 exercicio16 = new Exercicio16();
    exercicio16.Executar();
}
else if (menuDesejado == 17)
{
    Exercicio17 exercicio17 = new Exercicio17();
    exercicio17.Executar();
}

