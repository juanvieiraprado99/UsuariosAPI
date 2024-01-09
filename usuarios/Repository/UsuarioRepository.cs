using Microsoft.EntityFrameworkCore;
using usuarios.Data;
using usuarios.models;

namespace usuarios.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }
        public void AdicionaUsuario(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            _context.Update(usuario);
        }

        public async Task<Usuario> BuscaUsuario(int id)
        {
            return await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> BuscaUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public void DeletaUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
