using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    class ColoresVehiculo
    {
        public int IdColor { get; set; }
        public string NombreColor { get; set; }

        //aqui va la conexion con vehiculos
    }
}
