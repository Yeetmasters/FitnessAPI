using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessAPI.Models
{
    public class Session
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionId { get; set; } // Primary Key

        public int SquatWeight { get; set; }
        public int BenchWeight { get; set; }

        public int UserId { get; set; }
        public int WorkoutId { get; set; }


    }
}
