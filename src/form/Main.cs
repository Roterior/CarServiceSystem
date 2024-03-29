﻿using CarServiceSystem.src.entity;
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
    public partial class Main : Form
    {
        private readonly IClientService service = ClientServiceImpl.GetService();
        public static Client currentClient;
        private OrderRepair currentOrder;
        private List<Client> clients;

        public Main()
        {
            InitializeComponent();
            if (currentClient is null)
            {
                button2.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Search(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new CreateClient(this).Show();
        }

        public void updateClientTable(List<Client> clients)
        {
            this.clients = clients;
            try
            {
                dataGridView1.Rows.Clear();
                foreach (Client client in clients)
                {
                    dataGridView1.Rows.Add(client.LastName, client.FirstName, client.MiddleName);
                }
                if (clients != null && clients.Count > 0)
                {
                    currentClient = clients[0];
                    updateClientInfo();
                    updateOrderTable(currentClient);
                }
                else
                {
                    currentClient = null;
                    currentOrder = null;
                    updateOrderTable(currentClient);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void updateClientInfo()
        {
            button5.Enabled = true;
            button6.Enabled = true;
            if (currentClient.CarClientList is null || currentClient.CarClientList.Count <= 0)
            {
                button2.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button4.Enabled = true;
            }
            passportNum.Text = "Номер паспорта " + currentClient.PassportNumber;
            passportSeries.Text = "Серия паспорта " + currentClient.PassportSeries;
            inn.Text = "ИНН " + currentClient.Inn;
            address.Text = "Адрес " + currentClient.Address;
            phone.Text = "Телефон " + currentClient.Phone;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CreateOrder(this).Show();
        }

        public void updateOrderTable(Client client)
        {
            currentClient = client;
            List<OrderRepair> orderRepairs = currentClient?.OrderRepairList;
            try
            {
                dataGridView2.Rows.Clear();
                foreach (OrderRepair order in orderRepairs)
                {
                    dataGridView2.Rows.Add(order.Timestamp, order.Price);
                }
                if (orderRepairs != null && orderRepairs.Count > 0)
                {
                    currentOrder = orderRepairs[0];
                    updateOrderInfo();
                }
                else
                {
                    currentOrder = null;
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void updateOrderInfo()
        {
            status.Text = "Статус " + currentOrder.Status;
            description.Text = currentOrder.Description;
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                currentClient = clients[e.RowIndex];
                updateClientInfo();
                updateOrderTable(currentClient);
            }
        }

        private void CellClickOrder(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                currentOrder = currentClient.OrderRepairList[e.RowIndex];
                updateOrderInfo();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            service.Delete(currentClient);
            clients.Remove(currentClient);
            currentClient = null;
            updateClientTable(clients);
            updateClientInfo();
            updateOrderInfo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new CreateOrderDiagnose(this).Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new EditClient(this).Show();
        }
    }
}
