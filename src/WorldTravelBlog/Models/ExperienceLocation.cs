using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravelBlog.Models
{
    [Table("ExperienceLocations")]
    public class ExperienceLocation
    {
        [Key]
        public int ExperienceLocationId { get; set; }
        public int ExperienceId { get; set; }
        public int LocationId { get; set; }

        public virtual Experience Experience { get; set; }
        public virtual Location Location { get; set; }
    }
}
