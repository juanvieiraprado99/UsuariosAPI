using Microsoft.AspNetCore.Mvc;
using usuarios.models;

namespace usuarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private static List<Usuario> Usuarios()
        {
            return new List<Usuario>
            {
                new Usuario{  Nome = "Lucas", Id = 1, DataNascimento = new DateTime(1999, 09, 05)  }
            };
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Usuarios());
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            var usuarios = Usuarios();
            usuarios.Add(usuario);
            return Ok(usuario);
        }
    }
}
