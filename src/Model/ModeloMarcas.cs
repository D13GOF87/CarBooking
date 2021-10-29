using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    class ModeloMarcas
    {
        public int IdMarcas { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string NombreMarca { get; set; }

        //aqui va la conexion con vehiculos
    }
}
