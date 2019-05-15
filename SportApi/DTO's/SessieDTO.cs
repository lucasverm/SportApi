using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportApi.DTO_s
{
    public class SessieDTO
    {
        [Required]
        public int LesgeverId { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        [Required]
        public TimeSpan Duur { get; set; }

        [Required]
        public TimeSpan StartUur { get; set; }

        [Required]
        public DayOfWeek Weekdag { get; set; }

        [Required]
        public List<int> Leden { get; set; }
    }
}