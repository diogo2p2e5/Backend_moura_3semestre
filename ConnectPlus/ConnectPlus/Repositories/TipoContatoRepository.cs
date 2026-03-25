using ConnectPlus.BdContextConnect;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectPlus.Repositories
{
    public class TipoContatoRepository : ITipoContatoRepository
    {
        private readonly ConnectContext _context;

        public TipoContatoRepository(ConnectContext context)
        {
            _context = context;
        }


        public void Atualizar(Guid Id, TbTiposContato tipoContato)
        {
            var TipoContatoBuscado = _context.TbTiposContatos.Find(Id);

            if (TipoContatoBuscado != null)
            {
                TipoContatoBuscado.Titulo = tipoContato.Titulo;

                _context.SaveChanges();
            }
        }

        public TbTiposContato BuscarPorId(Guid id)
        {
            return _context.TbTiposContatos.Find(id)!;
        }

        public void Cadastrar(TbTiposContato tipoContato)
        {
            _context.TbTiposContatos.Add(tipoContato);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var TipoContatoBuscado = _context.TbTiposContatos.Find(id);

            if (TipoContatoBuscado != null)
            {
                _context.TbTiposContatos.Remove(TipoContatoBuscado);
                _context.SaveChanges();
            }
        }

       

        public List<TbTiposContato> Listar()
        {
            return _context.TbTiposContatos.OrderBy(TbTiposContato => TbTiposContato).ToList();
        }
    }
}
