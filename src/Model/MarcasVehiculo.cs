using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    class MarcasVehiculo
    {
        public int IdMarcas { get; set; }
        public string NombreMarca { get; set; }

        //aqui va la conexion con vehiculos
    }
}
