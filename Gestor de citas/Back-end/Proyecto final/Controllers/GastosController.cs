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
    public class GastosController : ControllerBase
    {

        IGastos gastos;
        IUsuario usuarioLogic;

        Notificador notificador = new Notificador();
        public GastosController(IGastos gastos, IUsuario usuarioLogic)
        {
            this.gastos = gastos;
            this.usuarioLogic = usuarioLogic;

        }

        [HttpGet("GetGastos_Activos")]
        public IEnumerable<Gasto> GetGastos_Activos()
        {
            return gastos.GetGastos_Activos();
        }

        [HttpGet("GetAllGastos")]
        public IEnumerable<Gasto> GetAllGastos()
        {
            return gastos.GetAllGastos();
        }

        [HttpGet("GetGastosByID")]
        public List<GastosDTO> GetGastos_BY_ID(int IDUsuario)
        {
            return gastos.GetGastos_ID(IDUsuario);
        }

        [HttpPost("AgregarGasto")]
        public dynamic AgregarGasto(GastosDTO gastoNuevo)
        {
            usuarioLogic.AgregarSub(notificador);
            return gastos.AgregarGastos(usuarioLogic, gastoNuevo);
        }

        [HttpPut("ActivacionGastos")]
        public IEnumerable<Gasto> ActivacionGastos(int IDGasto,int IdUser)
        {
            return gastos.ActivacionGastos(IDGasto,IdUser);
        }
    }
}
