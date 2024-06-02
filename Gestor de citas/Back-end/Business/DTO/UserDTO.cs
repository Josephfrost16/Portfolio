using Business.Clases;
using Business.Interfaces;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class UserDTO
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Password { get; set; }
        public int? MontoLimite { get; set; }


        public UserDTO()
        {
            Nombre = "";
            Correo = "";
            Password = "";
            MontoLimite = 0;
        }
    }
}
