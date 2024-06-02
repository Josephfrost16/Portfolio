using Business.Clases;
using Business.DTO;
using Business.Interfaces;
using Entidades.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Proyecto_final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        ICategorias categorias;
        public CategoriasController(IUsuario usuarios,ICategorias categorias,IGastos gastos)
        {
            this.categorias = categorias;
        }

        [HttpGet("GetCategorias_Activas")]
        public IEnumerable<Categoria> GetCategorias_Activas(int IDLogeado)
        {
            return categorias.GetCategorias_Activas(IDLogeado);
        }

        [HttpGet("GetAllCategorias")]
        public IEnumerable<Categoria> GetAllCategorias()
        {
            return categorias.GetAllCategorias();   
        }

        [HttpPut("ActivacionCategorias")]
        public IEnumerable<Categoria> ActivacionCategorias(int ID)
        {
            return categorias.ActivacionCategorias(ID);
        }

        [HttpPost("AgregarCategoria")]
        public dynamic AgregarCategoria(CategoriasDTO categoriaNueva)
        {
            return categorias.AgregarCategoria(categoriaNueva);
        }
    }
}
