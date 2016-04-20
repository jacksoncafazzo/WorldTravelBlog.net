using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravelBlog.Models
{
    [Table("Experiences")]
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        public string Title { get; set; }
        public ICollection<ExperiencePerson> ExperiencePeople { get; set; }
        public ICollection<ExperienceLocation> ExperienceLocations { get; set; }
    }
}
