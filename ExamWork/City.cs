using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork
{
    public class City : Entity
    {
        public string Name { get; set; }
        public int Population { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Street> Streets { get; set; }
    }
}
