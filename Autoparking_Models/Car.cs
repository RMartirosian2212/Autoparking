using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoparking_Models
{
    public class Car
    {
        [Key]
        public int id { get; set; }
        [Required] 
        public string? Image { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
