using Exercicio9;

Console.WriteLine("Escolha o primeiro número da equação");
float a = float.Parse(Console.ReadLine());

Console.WriteLine("Escolha o segundo número da equação");
float b = float.Parse(Console.ReadLine());

Calculadora cal = new Calculadora(a, b);
cal.Multiplicar();
