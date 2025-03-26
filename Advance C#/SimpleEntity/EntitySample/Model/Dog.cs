using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySample.Model
{
    public class Dog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DogId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual Breed Breed { get; set; }
    }
}
