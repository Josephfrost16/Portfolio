using Business.DTO;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IGastos
    {
        List<Gasto> GetAllGastos();
        public List<GastosDTO> GetGastos_ID(int IDUsuario);
        List<Gasto> GetGastos_Activos();
        dynamic AgregarGastos(IUsuario usersLogic,GastosDTO gastoNuevo);
        public List<Gasto> ActivacionGastos(int GastosID,int UsuarioID);
    }
}
