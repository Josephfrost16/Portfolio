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
    public class LogicaCategorias : ICategorias
    {
        private  GestorGastosContext BD;
        public LogicaCategorias(GestorGastosContext BD)
        {
            this.BD = BD;
        }

        public List<Categoria> GetAllCategorias()
        {
            return BD.Categorias.ToList();
        }

        public List<Categoria> GetCategorias_Activas(int IDLogeado)
        {
            return BD.Categorias.Where(a => a.IDUsuario == IDLogeado && a.Estado == true).ToList();
        }

        public List<Categoria> ActivacionCategorias(int ID)
        {
            List<Categoria> categorias = BD.Categorias.ToList();    

            Categoria seleccionada = categorias.Find(c=> c.Id == ID)!;

            if (seleccionada != null && seleccionada.Estado == true)
            {
                seleccionada.Estado = false;
            }
            else if (seleccionada != null && seleccionada.Estado == false)
            {
                seleccionada.Estado=true;
            }
            BD.SaveChanges();
            return categorias;
        }

        public dynamic AgregarCategoria(CategoriasDTO categoriaNueva)
        {
            Categoria temp  = new Categoria
            {
                Nombre = categoriaNueva.Nombre,
                Estado = true,
            };

            BD.Categorias.Add(temp);
            BD.SaveChanges();

            var resultado = new List<CategoriasDTO>();
            var dataUsuario = BD.Categorias.ToList();

            foreach (var item in dataUsuario)
            {
                var ObjetoDTO = new CategoriasDTO();

                ObjetoDTO.ID = item.Id;
                ObjetoDTO.Nombre = item.Nombre;
                ObjetoDTO.Estado = item.Estado;

                resultado.Add(ObjetoDTO);
            }
            return resultado;
        }
    }
}
