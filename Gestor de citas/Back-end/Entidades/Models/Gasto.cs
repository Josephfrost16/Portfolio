using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class Gasto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Presupuesto { get; set; }

    public bool? Estado { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
