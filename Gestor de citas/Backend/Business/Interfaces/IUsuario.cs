using Business.DTO;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUsuario
    {
        // logica observable:
        public void AgregarSub(IObservador observador);
        public void QuitarSub(IObservador observador);
        public void Notificar(Usuario ingresado, string mensaje);

        List<Usuario> GetUsuarios();
        dynamic AgregarUsuario(UserDTO usuario);
        public int Login(UserDTO logeado);
        Usuario ModificarUser(int IDLogeado,UserDTO nuevo);

    }
}
