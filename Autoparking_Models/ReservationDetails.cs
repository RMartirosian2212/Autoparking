using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoparking_Models
{
    public class ReservationDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CarName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime startDate { get; set; }
        [Required]
        public DateTime endDate { get; set; }
    }
}
