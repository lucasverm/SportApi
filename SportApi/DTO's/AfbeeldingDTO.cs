using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportApi.DTO_s
{
    public class AfbeeldingDTO
    {
        [Required]
        public int LesMateriaalId { get; set; }

        [Required]
        public string Adres { get; set; }
    }
}