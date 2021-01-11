using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mineralab.Models
{
    [Table("T_metodos")]
    public class Metodo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
     
        public int ID { get; set; }

        [Required(ErrorMessage = "Por favor ingrese Nombre")]
        [Display(Name="Nombres")]
        [Column("nombre")]
        public String Name { get; set; }

        

    }
}