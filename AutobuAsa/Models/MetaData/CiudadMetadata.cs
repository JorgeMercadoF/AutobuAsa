using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutobuAsa.Models
{
    [MetadataType(typeof(CiudadMetadata))]
    public partial class Ciudad
    {

    }


    public class CiudadMetadata
    {
        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CiudadMetadata()
        {
            this.Ruta = new HashSet<Ruta>();
            this.Ruta1 = new HashSet<Ruta>();
        }*/

        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Es requerido el nombre de la ciudad")]
        [MaxLength(200, ErrorMessage ="El nombre de la ciudad debe tener un maximo de 200 caracteres")]
        [MinLength(2, ErrorMessage ="El nombre de la ciudad debe tener un minimo de 2 caracteres ")]
        [DisplayName("Ciudad")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Es requerido el codigo de la ciudad")]
        [MaxLength(3, ErrorMessage = "El codigo de la ciudad debe tener un maximo de 3 caracteres")]
        [MinLength(3, ErrorMessage = "El codigo de la ciudad debe tener un minimo de 3 caracteres ")]
        [DisplayName("Codigo de la Ciudad")]
        public string codigo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ruta> Ruta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ruta> Ruta1 { get; set; }
    }
}