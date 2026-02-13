using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio6
{
    public class Pessoa
    {
        public string Nome;

        // public string Sobrenome;

        public int idade;

        public Pessoa(string N, string SN, int I)
        {
            Nome = N;
            // Sobrenome = SN;
            idade = I;

        }

        public Pessoa(string N, int I)
        {
            Nome = N;
            idade = I;

        }
        


        public void apresentacao(string Sobrenome)
        {
            
            Console.WriteLine($"meu nome é{Nome} {Sobrenome} eu tenho{idade} ");
            


        }

    }
}