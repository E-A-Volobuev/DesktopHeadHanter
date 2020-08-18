using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopHeadHanter
{
    public partial class Form2 : Form
    {
        public Form2(List<ViewVacancy> viewVacansies)
        {
            InitializeComponent();
            listBox1.DataSource = viewVacansies;
            listBox1.DisplayMember = "Info";
            listBox1.ValueMember = "Id";
            listBox1.SelectedIndexChanged+= listBox1_SelectedIndexChanged;
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewVacancy selected = (ViewVacancy)listBox1.SelectedItem;
            int id = selected.Id;
            var vacancy = GetVacancies(id);

            Form3 form3 = new Form3(vacancy);
            form3.Show();
        }
        public Vacancy GetVacancies(int id)
        {

            string site = $"https://api.hh.ru/vacancies/{id}";
            string s;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(site);
            req.UserAgent = "SimpleHostClient";
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            using (StreamReader stream = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                s = stream.ReadToEnd();

            }

            dynamic obj = JObject.Parse(s);
            Vacancy vacancy = new Vacancy(obj);
            return vacancy;

        }
    }
}
