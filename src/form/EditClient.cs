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
    public partial class EditClient : Form
    {
        private readonly IClientService service = ClientServiceImpl.GetService();
        private readonly ICarClientService carService = CarClientServiceImpl.GetService();
        private readonly Main main;

        public EditClient()
        {
            InitializeComponent();
            foreach (Control c in Controls)
                if (c is TextBox && string.IsNullOrEmpty(c.Text))
                    c.Text = null;
        }

        public EditClient(Main main) : this() => this.main = main;

        private void button1_Click(object sender, EventArgs e)
        {
            Client current = Main.currentClient;
            if (!lname.Text.Equals("")) current.LastName = lname.Text;
            if (!fname.Text.Equals("")) current.FirstName = fname.Text;
            if (!mname.Text.Equals("")) current.MiddleName = mname.Text;
            if (!address.Text.Equals("")) current.Address = address.Text;
            if (!phone.Text.Equals("")) current.Phone = phone.Text;
            if (!inn.Text.Equals("")) current.Inn = int.Parse(inn.Text);
            if (!passportNum.Text.Equals("")) current.PassportNumber = int.Parse(passportNum.Text);
            if (!passportSeries.Text.Equals("")) current.PassportSeries = int.Parse(passportSeries.Text);
            if (!maker.Text.Equals("")) current.CarClientList[0].Maker = maker.Text;
            if (!model.Text.Equals("")) current.CarClientList[0].Model = model.Text;
            if (!description.Text.Equals("")) current.CarClientList[0].Description = description.Text;
            if (!releaseYear.Text.Equals("")) current.CarClientList[0].ReleaseYear = int.Parse(releaseYear.Text);
            Client client = service.Update(current);
            main.updateClientTable(new List<Client>(1) { client });
            Close();
        }
    }
}
