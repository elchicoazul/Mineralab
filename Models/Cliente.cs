using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mineralab.Models
{
    [Table("T_clientes")]    
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        
        [Required(ErrorMessage = "Por favor ingrese un nombre")]   
        [Display(Name="Nombre: ")]
        [Column("nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Por favor ingrese un ruc")]   
        [Display(Name="Ruc: ")]
        [Column("ruc")]
        public string ruc { get; set; }
  
        [Display(Name="Telefono: ")]
        [Range(9, Int32.MaxValue)]
        [Column("telefono")]
        public int telefono { get; set; }
  
        [Display(Name="Email: ")]
        [Column("email")]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Por favor ingrese una direccion")]   
        [Display(Name="Direccion: ")]
        [Column("direccion")]
        public string direccion { get; set; }

        [NotMapped]
        public string mensaje { get; set; }
    }
}