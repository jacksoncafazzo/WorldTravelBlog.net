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
        public ICollection<LocationPerson> LocationPeople { get; set; }
        public ICollection<ExperiencePerson> ExperiencePeople { get; set; }

        [NotMapped]
        public virtual ICollection<Location> Locations { get; set; }
        [NotMapped]
        public virtual ICollection<Experience> Experiences { get; set; }
        public Person()
        {
            this.Locations = new HashSet<Location>();
            this.Experiences = new HashSet<Experience>();
        }
    }
}
