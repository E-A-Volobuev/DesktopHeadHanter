using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHeadHanter
{
    //страна
    public class Countries
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Countries(dynamic obj)
        {
            Id = obj.id;
            Name = obj.name;
        }
    }
    //область
    public class Areas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Areas(dynamic obj)
        {
            Id = obj.id;
            Name = obj.name;
        }
    }
    //город
    public class Sities
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Sities(dynamic obj)
        {
            Id = obj.id;
            Name = obj.name;
        }
    }
}
