using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessAPI.Models
{
    /*
    * User model holds personal attributes and sign in information.
    */
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; } // Primary Key
        [Required, MaxLength(200)]
        public string Email { get; set; }
        [Required, MaxLength(100)]
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }

        [Timestamp]
        public DateTime TimeCreated { get; set; }
        public ICollection<Session> Sessions { get; set; }

    }
}
