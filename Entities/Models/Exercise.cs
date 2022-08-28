using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Exercise
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [MaxLength(50,ErrorMessage ="Max length for Name is 50 characters")]
        public string? Name { get; set; }

        public string? ImageUrl { get; set; }

        [ForeignKey(nameof(MuscularGroup))]
        public int MuscularGroupId { get; set; }

        public MuscularGroup? MuscularGroup { get; set; }

    }
}
