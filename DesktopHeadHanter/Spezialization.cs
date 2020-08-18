using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHeadHanter
{
    public class Spezialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Spezialization(dynamic obj)
        {
            Id = obj.id;
            Name = obj.name;
        }

    }
}
