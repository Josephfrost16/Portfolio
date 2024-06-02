using Business.DTO;
using Business.Interfaces;
using CapaDatos;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Clases
{
    public class LogicaUsuarios : IUsuario
    {

        private GestorGastosContext BD;
        public static Notificador notificador = new Notificador();

        public List<IObservador> notificadores;
        public LogicaUsuarios(GestorGastosContext bd)
        {
            BD = bd;
            notificadores = new List<IObservador>();
        }

        //List<Gasto> gastos = BD.Gastos.ToList ();

        // Logica observable:

        public  void AgregarSub(IObservador observador)
        {
            notificadores.Add(observador);
        }

        public  void QuitarSub(IObservador observador)
        {
            notificadores.Remove(observador);
        }

        public  void Notificar(Usuario ingresado, string mensaje)
        {
            foreach (var observador in notificadores)
            {
                observador.Enviar(ingresado, mensaje);
            }
        }
        // Logica de negocio:
        public List<Usuario> GetUsuarios()
        {
            return BD.Usuarios.ToList();
        }

        public  int Login(UserDTO logeado)
        {
            Usuario encontrado = BD.Usuarios.ToList().Find(c => c.Correo == logeado.Correo
                                    && c.Password == logeado.Password)!;
            
            if (encontrado != null)
            {
                UserDTO usuario_ = new UserDTO();

                usuario_.Correo = encontrado.Correo;
                usuario_.Password = encontrado.Password;
                return encontrado.Id;
            }

            else
            {
                return 0;
            }

        }
        public dynamic AgregarUsuario(UserDTO usuario)
        {
            // Registro:
            Usuario temp = new Usuario
            {
                Id = 0,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Password = usuario.Password,
                MontoLimite = usuario.MontoLimite,
            };

            BD.Usuarios.Add(temp);
            BD.SaveChanges();


            #region show
            var resultado = new List<UserDTO>();
            var dataUsuario = BD.Usuarios.ToList();

            foreach(var item in dataUsuario)
            {
                var ObjetoDTO = new UserDTO();

                ObjetoDTO.Nombre = item.Nombre;
                ObjetoDTO.Correo = item.Correo;
                ObjetoDTO.Password = item.Password;
                ObjetoDTO.MontoLimite = item.MontoLimite;

                resultado.Add(ObjetoDTO);
            }

            #endregion

            return new
            {
                succes = true,
                message = "Usuario registrado con exito",
                result = resultado
            };
        }

        public Usuario ModificarUser(int IDLogeado, UserDTO nuevo)
        {
            List<Usuario> usuarios = BD.Usuarios.ToList();

            Usuario usuarioLogeado = usuarios.Find(x=> x.Id == IDLogeado)!;
            
            usuarioLogeado.Nombre = nuevo.Nombre;
            usuarioLogeado.MontoLimite = nuevo.MontoLimite;
            usuarioLogeado.Correo = nuevo.Correo;
            usuarioLogeado.Password = nuevo.Password;

            BD.SaveChanges ();
            return usuarioLogeado;
        }
    }
}
