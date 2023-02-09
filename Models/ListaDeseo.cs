using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class ListaDeseo
    {

        [Key]
        public int Id { get; set; }
        public string? ProductoDeseado { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public int Unidades { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public string? Correo { get; set; }

    }
}
