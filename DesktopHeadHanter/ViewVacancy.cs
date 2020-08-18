using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHeadHanter
{
    public class ViewVacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public string Info { get; set; }
        public string Adress { get; set; }
        public ViewVacancy(dynamic obj)
        {
            Id = obj.id;
            Name = obj.name;
            if (obj.salary != null)
            {
                if (obj.salary.to == null)
                    Salary = $"Зп: от {obj.salary.from} руб.";
                else
                    Salary = $"Зп:до {obj.salary.to} руб.";

            }
              
            else
            {
                Salary = "Зп: не указана";
            }
            Info = $"{Name} {Salary} {Adress}";
        }
    }
}
