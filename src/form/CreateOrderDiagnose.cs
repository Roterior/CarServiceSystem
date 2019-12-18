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
    public partial class CreateOrderDiagnose : Form
    {
        private readonly IClientService service = ClientServiceImpl.GetService();
        private readonly IOrderRepairService orderService = OrderRepairServiceImpl.GetService();
        private readonly Main main;

        public CreateOrderDiagnose()
        {
            InitializeComponent();
            LoadClientCar();
        }
        public CreateOrderDiagnose(Main main) : this() => this.main = main;

        private void LoadClientCar()
        {
            CarClient car = Main.currentClient.CarClientList?[0];
            maker.Text = "Марка " + car.Maker;
            model.Text = "Модель " + car.Model;
            releaseYear.Text = "Год выпуска " + car.ReleaseYear.ToString();
            status.Text = "Статус Поломана жизнью";
            description.Text = car.Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderService.Create(new OrderRepair
            {
                Status = "Ремонт",
                Timestamp = DateTimeOffset.Now,
                Price = description.Text.Length * 1000,
                ClientId = Main.currentClient.Id,
                Description = description.Text
            });
            Client client = service.GetById(Main.currentClient.Id);
            main.updateOrderTable(client);
            Close();
        }
    }
}
