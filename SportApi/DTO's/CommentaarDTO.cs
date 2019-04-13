using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportApi.DTO_s
{
    public class CommentaarDTO
    {
        [Required]
        public int LidId { get; set; }
        [Required]
        public int LesmateriaalId { get; set; }
        public String Tekst { get; set; }
    }
}
