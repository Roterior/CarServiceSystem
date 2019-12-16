using CarServiceSystem.src.entity;
using CarServiceSystem.src.service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarServiceSystem.src.form
{
    public partial class CreateClient : Form
    {
        private readonly IClientService service = ClientServiceImpl.GetService();
        private readonly ICarClientService carService = CarClientServiceImpl.GetService();
        private readonly Main main;

        public CreateClient() => InitializeComponent();

        public CreateClient(Main main) : this() => this.main = main;

        private void button1_Click(object sender, EventArgs e)
        {
            Client client = service.Create(new Client
            {
                Id = Guid.NewGuid(),
                LastName = lname.Text,
                FirstName = fname.Text,
                MiddleName = mname.Text,
                Address = address.Text,
                Phone = !phone.Text.Equals("") ? phone.Text : null
            });
            if (!inn.Text.Equals("")) client.Inn = int.Parse(inn.Text);
            if (!passportNum.Text.Equals("")) client.PassportNumber = int.Parse(passportNum.Text);
            if (!passportSeries.Text.Equals("")) client.PassportSeries = int.Parse(passportSeries.Text);
            carService.Create(new CarClient
            {
                ClientId = client.Id,
                Maker = maker.Text,
                Model = model.Text,
                ReleaseYear = (releaseYear.Text != "") ? int.Parse(releaseYear.Text) : 0,
                Description = description.Text
            });
            if (!inn.Text.Equals("")) client.Inn = int.Parse(inn.Text);
            main.updateClientTable(new List<Client>(1) { client });
            Close();
        }
    }
}
