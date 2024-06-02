using Business.Clases;
using Business.DTO;
using Business.Interfaces;
using Entidades.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IUsuario usuarios;

        //IObservador observador;
        public UsuariosController(IUsuario usuarios)
        {
            this.usuarios = usuarios;   
        }
        
        [HttpGet("GetUsuarios")]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return usuarios.GetUsuarios();
        }

        [HttpPost("Login")] 
        public dynamic Login([FromBody] UserDTO usuario)
        {
            return usuarios.Login(usuario);
        }

        [HttpPost("Registro")]
        public dynamic AgregarUser([FromBody]UserDTO usuario)
        {
            return usuarios.AgregarUsuario(usuario);
        }

        [HttpPost("EditarMonto")]
        public dynamic EditarMonto(int IDLogeado, UserDTO nuevo)
        {
            return usuarios.ModificarUser(IDLogeado, nuevo);
        }
    }
}
