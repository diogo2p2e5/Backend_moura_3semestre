
using System.Security.AccessControl;
using Exercicio3;

Pessoa pessoa = new Pessoa();
 string nome = pessoa.Nome;
 int idade = pessoa.idade;

Console.WriteLine("qual o seu nome:");
pessoa.Nome = Console.ReadLine();


Console.WriteLine("qual o sua idade:");
pessoa.idade = int.Parse(Console.ReadLine());

pessoa.ExibirDados();


