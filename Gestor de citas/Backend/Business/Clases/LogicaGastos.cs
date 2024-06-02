using Business.DTO;
using Business.Interfaces;
using CapaDatos;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Clases
{
    public class LogicaGastos : IGastos
    {
        private GestorGastosContext BD;
        private Notificador notificador = new Notificador();

        public LogicaGastos(GestorGastosContext BD)
        {
            this.BD = BD;
        }

        public List<Gasto> ActivacionGastos(int GastoID, int UserID)
        {
            Gasto encontrado = BD.Gastos.ToList().Find(c => c.Id == GastoID && c.IdUsuario == UserID)!;

            if (encontrado != null && encontrado.Estado == true)
            {
                    encontrado.Estado = false;
            }
            else if (encontrado != null && encontrado.Estado == false)
            {
                encontrado.Estado = true;
            }

            BD.SaveChanges();
            return BD.Gastos.ToList();
        }

        public List<Gasto> GetAllGastos()
        {
            return BD.Gastos.ToList();
        }

        public List<GastosDTO> GetGastos_ID(int IDLogeado)
        {
            List<Gasto>gastos = BD.Gastos.ToList().Where(c => c.IdUsuario == IDLogeado && c.Estado == true).ToList();
            
            List<GastosDTO> gastos_Dto = new List<GastosDTO>();


            foreach (Gasto gasto in gastos)
            {
                GastosDTO gasto_temp = new GastosDTO();

                gasto_temp.Nombre = gasto.Nombre;
                gasto_temp.Estado = gasto.Estado;
                gasto_temp.Presupuesto = gasto.Presupuesto;
                gasto_temp.IDUsuario = gasto.IdUsuario;
                gasto_temp.IDCategoria = gasto.IdCategoria;

                gastos_Dto.Add(gasto_temp);
            }

            return gastos_Dto;
        }

        public List<Gasto> GetGastos_Activos()
        {
            return BD.Gastos.Where(a => a.Estado == true).ToList();
        }


        public dynamic AgregarGastos(IUsuario usersLogic,GastosDTO gastoNuevo)
        {
            Gasto temp = new Gasto
            {
                Nombre = gastoNuevo.Nombre,
                Presupuesto = gastoNuevo.Presupuesto,
                Estado = true,
                IdCategoria = gastoNuevo.IDCategoria,
                IdUsuario = gastoNuevo.IDUsuario,
            };
                
            BD.Gastos.Add(temp);
            BD.SaveChanges();

            // Agregar el gasto asociado a una lista en su usuario:

            List<Usuario> usuarios = BD.Usuarios.ToList();

            List<Gasto> gastos = BD.Gastos.ToList();

        #region asignacionGastos 
            // Chequeo y asignacion de los gastos segun el ID del usuario:

            Usuario UsuarioRelated = usuarios.Find(t => t.Id == gastoNuevo.IDUsuario)!;
            
            UsuarioRelated.Gastos = (gastos.Where(w => w.IdUsuario == UsuarioRelated.Id).ToList());

            List<int?> AllGastos_user = UsuarioRelated.Gastos.Select(g=> g.Presupuesto).ToList();

            int? suma = AllGastos_user.Sum();

            if (suma >= UsuarioRelated.MontoLimite)
            {
                string mensaje = "hola" + UsuarioRelated.Nombre + "Superaste/alcanzaste el limite de gastos previamente establecido";
                usersLogic.Notificar(UsuarioRelated, mensaje);

                //notificador.Enviar(UsuarioRelated, mensaje);
            }
        #endregion


            var resultado = new List<GastosDTO>();
            var dataUsuario = BD.Gastos.ToList();

            foreach (var item in dataUsuario)
            {
                var ObjetoDTO = new GastosDTO();

                ObjetoDTO.Nombre = item.Nombre;
                ObjetoDTO.Presupuesto = item.Presupuesto;
                ObjetoDTO.Estado = item.Estado;
                ObjetoDTO.IDUsuario = item.IdUsuario;
                ObjetoDTO.IDCategoria = item.IdCategoria;

                resultado.Add(ObjetoDTO);
            }
            return new
            {
                succes = true,
                message = "Gasto agregado con exito",
                result = resultado
            };
        }
    }
}
