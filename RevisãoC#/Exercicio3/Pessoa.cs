using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio3
{
    public class Pessoa
    {
        public string Nome;

        public int idade;

        public void ExibirDados()
        {
            if (idade <= 0)
            {
                Console.WriteLine("Idade inválida");

            }
            else
            {
                
            Console.WriteLine($"seu nome é {Nome} e sua idade é {idade}");

            }


        }



    }
}