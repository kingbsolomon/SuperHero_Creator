using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superhero_Creator.Models
{
    public class Superhero
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Hey dumbass, enter a name")]
        public string Name { get; set; }
        public string AltEgo { get; set; }
        public string PrimAbility { get; set; }
        public string SecAbility { get; set; }
        public string CatchPhrase { get; set; }
    }
}
