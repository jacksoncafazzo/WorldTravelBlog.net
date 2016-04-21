using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravelBlog.Models
{
    [Table("ExperiencePeople")]
    public class ExperiencePerson
    {
        [Key]
        public int ExperiencePersonId { get; set; }

        [ForeignKey("Experience")]
        public int ExperienceId { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public virtual Experience Experience { get; set; }
        public virtual Person Person { get; set; }
    }
}