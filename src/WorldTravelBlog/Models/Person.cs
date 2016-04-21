using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravelBlog.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        public string Name { get; set; }
        public string ImgLink { get; set; }
        public ICollection<ExperiencePerson> ExperiencePeople { get; set; }

        [NotMapped]
        public virtual ICollection<Experience> Experiences { get; set; }

        public Person()
        {
            this.Experiences = new HashSet<Experience>();
        }
    }
}