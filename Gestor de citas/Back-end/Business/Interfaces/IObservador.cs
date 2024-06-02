using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IObservador
    {
        void Enviar(Usuario logeado,string mensaje);
    }
}
