using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class GastosDTO
    {
        public string? Nombre { get; set; }
        public int? Presupuesto { get; set; }
        public bool? Estado { get; set; }
        public int? IDCategoria { get; set; }
        public int? IDUsuario { get; set; }
        public GastosDTO()
        {
            Nombre = "";
            Presupuesto = 0;
            Estado = null;
            IDCategoria = 0;
            IDUsuario = 0;
        }
    }
}
