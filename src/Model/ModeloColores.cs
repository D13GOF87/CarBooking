using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    class ModeloColores
    {
        public int IdColor { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string NombreColor { get; set; }
s
        //aqui va la conexion con vehiculos
    }
}
