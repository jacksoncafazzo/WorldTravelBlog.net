using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldTravelBlog.Models
{
    public class ExperiencePerson
    {
        public int ExperiencePersonId { get; set; }
        public int ExperienceId { get; set; }
        public int PersonId { get; set; }

        public virtual Experience Experience { get; set; }
        public virtual Person Person { get; set; }
    }
}
