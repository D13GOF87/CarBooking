
using System.ComponentModel.DataAnnotations;
namespace Model.DTOs
{
    public class AgenciasDto
    {

        public int IdAgencia { get; set; }

        public string NombreAgencia { get; set; }

        public int EstadoAgencia { get; set; }


    }
    public class CrearAgenciasDto {
       [Required]
        public string NombreAgencia { get; set; }

        public int EstadoAgencia { get; set; }
    }

    public class ActualizarAgenciasDto
    {
        
        public string NombreAgencia { get; set; }

        public int EstadoAgencia { get; set; }
    }


}
