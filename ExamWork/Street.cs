using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork
{
    public class Street : Entity
    {
        public string Name { get; set; }

        public virtual City City { get; set; }
    }
}
