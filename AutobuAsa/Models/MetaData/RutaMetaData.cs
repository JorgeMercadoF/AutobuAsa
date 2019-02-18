using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutobuAsa.Models
{
    [MetadataType(typeof(RutaMetaData))]
    public partial class Ruta
    {
    }

    public class RutaMetaData
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Es requerido seleccionar una ciudad de origen")]
        [DisplayName("Origen")]
        public int ciudadOrigen { get; set; }
        [Required(ErrorMessage = "Es requerido seleccionar una ciudad de destino")]
        [DisplayName("Destino")]
        public int ciudadDestino { get; set; }

        [Required(ErrorMessage = "Es requerido informar los kilometros de la ruta")]
        [DisplayName("Kilometros")]
        public decimal km { get; set; }
        [Required(ErrorMessage = "Es requerido informar el coste de la ruta")]
        [DisplayName("Coste (€)")]
        public decimal precio { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
        public virtual Ciudad Ciudad1 { get; set; }
    }
}