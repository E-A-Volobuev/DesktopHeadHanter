using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopHeadHanter
{
    public partial class Form3 : Form
    {
        public int id;
        public Form3(Vacancy selected)
        {
            InitializeComponent();
            textBox2.Text = selected.Name;
            label2.Text = selected.Salary;
            label3.Text = selected.Company;
            label4.Text = selected.Adress;
            textBox1.Text=selected.Description;
            label6.Text = $"{selected.ContactsName}\n{selected.Email}\n{selected.Phones}";
            id = selected.Id;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;


        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start($"https://hh.ru/vacancy/{id}");
        }
    }
}
