using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio9
{
    public class Calculadora
    {
        float A;
        float B;
        float Resultado;

        public Calculadora(float a, float b)
        {
            A = a;
            B = b;
        }

        public void Somar()
        {
            Resultado = A + B;
            Console.Clear();
            Console.WriteLine($"O resultado da soma de {A} + {B} = {Resultado}");
        }

        public void Multiplicar()
        {
            Resultado = A + B;
            Console.Clear();
            Console.WriteLine($"O resultado da multpliacação de {A} * {B} = {Resultado}");
        }
    }
}