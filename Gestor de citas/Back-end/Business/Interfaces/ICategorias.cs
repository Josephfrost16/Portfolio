using Business.DTO;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICategorias
    {
        List<Categoria> GetAllCategorias();
        List<Categoria> GetCategorias_Activas(int IdLogeado);
        List<Categoria> ActivacionCategorias(int ID);
        dynamic AgregarCategoria(CategoriasDTO categoriaNueva);

    }
}
