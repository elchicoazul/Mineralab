using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mineralab.Models
{
      [Table("T_Prueba")]
    public class Prueba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        public int categoriaid { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad {get; set; }

        
    }
}