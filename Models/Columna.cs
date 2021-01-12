using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mineralab.Models
{
    [Table("T_Column")]
    public class Columna
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int pruebaid { get; set; }
        public string nombre { get; set; }
    }
}