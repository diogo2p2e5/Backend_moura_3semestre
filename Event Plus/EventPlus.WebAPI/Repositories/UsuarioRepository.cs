using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;

    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Busca o usuario pelo e-mail e valida o hash da senha
    /// </summary>
    /// <param name="Email">email do usuario</param>
    /// <param name="Senha">senha do usuario</param>
    /// <returns>retorna o usuario buscado e valiadado</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        //Primeiro, busca o usuario pelo email
        var usuarioBuscado = _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.Email == Email);

        //verifica se o usuario realmente existe
        if (usuarioBuscado != null)
        {
            //comparamos o hash da senha digitada com oque esta no banco
            bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);


            if (confere)
            {
                return usuarioBuscado;
            }
        }

        return null!;
            
    }

    /// <summary>
    /// busca usuario pelo id , incluindo os dados do seu tipo usuá+rio
    /// </summary>
    /// <param name="IdUsusario">id do usuario a ser buscado e retorna o usuario buscado</param>
    /// <returns></returns>
    public Usuario BuscarPorId(Guid IdUsusario)
    {
        return _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.IdUsuario == IdUsusario)!;
    }

    /// <summary>
    /// Cadastra um novo usuario com a senha criptografada
    /// </summary>
    /// <param name="usuario">usuario a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
       usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}
