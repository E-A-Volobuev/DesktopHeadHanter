using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesktopHeadHanter
{
   public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Salary { get; set; }

        public string Company { get; set; }
        public string Adress { get; set; }
      
        public string Description { get; set; }
        public string Email { get; set; }

        public string ContactsName { get; set; }
        public string Phones { get; set; }


        public Vacancy(dynamic obj)
        {
            Id = obj.id;
            Name = obj.name;
            Adress = obj.area.name;
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

            Company = obj.employer.name;

            if(obj.contacts!=null&&obj.contacts.phones!=null&& obj.contacts.name!=null)
            {
                Email = obj.contacts.email;
                foreach (var x in obj.contacts.phones)
                {
                    Phones = $"{obj.contacts.country} {obj.contacts.city} {obj.contacts.number}";
                    ContactsName = obj.contacts.name;
                }
            }
            else
            {
                Email = null;
                Phones = null;
                ContactsName = "только отклик на hh.ru";
            }
            string html = obj.description;
            html = Regex.Replace(html, "<.*?>", string.Empty);
            Description = html;




        }
    }
}
