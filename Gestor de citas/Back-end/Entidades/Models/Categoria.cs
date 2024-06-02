using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public bool? Estado { get; set; }


    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();
}
