using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravelBlog.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public ICollection<ExperienceLocation> ExperienceLocations { get; set; }
        public ICollection<LocationPerson> LocationPeople { get; set; }

        [NotMapped]
        public virtual ICollection<Person> People { get; set; }
    }
}
