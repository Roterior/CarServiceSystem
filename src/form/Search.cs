using CarServiceSystem.src.entity;
using CarServiceSystem.src.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarServiceSystem.src.form
{
    public partial class Search : Form
    {
        private readonly IClientService service = ClientServiceImpl.GetService();
        private readonly Main main;

        public Search() => InitializeComponent();

        public Search(Main main) : this() => this.main = main;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FilterClient filter = new FilterClient
                {
                    FirstName = fname.Text,
                    MiddleName = mname.Text,
                    LastName = lname.Text
                };
                if (inn.Text != "")
                {
                    filter.Inn = int.Parse(inn.Text);
                }
                main.updateClientTable(service.GetByFilter(filter));
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
