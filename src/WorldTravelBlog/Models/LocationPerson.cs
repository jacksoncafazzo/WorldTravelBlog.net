using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravelBlog.Models
{
    [Table("LocationPeople")]
    public class LocationPerson
    {
        [Key]
        public int LocationPersonId { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Person Person { get; set; }
    }
}
