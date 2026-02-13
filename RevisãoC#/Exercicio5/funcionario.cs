using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio5
{
    public class funcionario : Pessoa
    {
        public double salario = 1500.50;


        public void ExibirDados()
        {
            System.Console.WriteLine($"Nome do funcionario: {Nome} idade do funcionario: {idade} salario do funcionario: {salario}");


        }
    }
}