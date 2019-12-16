﻿using CarServiceSystem.src.entity;
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
        public static Client currentClient;
        private OrderRepair currentOrder;
        private List<Client> clients;

        public Main()
        {
            InitializeComponent();
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
                //List<string> tableColumns = new List<string>(3) { "FirstName", "LastName", "Inn" };
                //Dictionary<string, string> map = new Dictionary<string, string>(3)
                //{
                //    ["LastName"] = "Фамилия",
                //    ["FirstName"] = "Имя",
                //    ["Inn"] = "Инн"
                //};
                
                //TableBuilder.BuildTable(clients, tabControl2, map, new DataGridViewCellEventHandler(CellClickClient));
                if (clients != null && clients.Count > 0)
                {
                    currentClient = clients[0];
                    updateClientInfo();
                    updateOrderTable();
                }
                else
                {
                    currentClient = null;
                    currentOrder = null;
                    updateOrderTable();
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void updateClientInfo()
        {
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

        public void updateOrderTable()
        {
            List<OrderRepair> orderRepairs = currentClient?.OrderRepairList;
            try
            {
                dataGridView2.Rows.Clear();
                foreach (OrderRepair order in orderRepairs)
                {
                    dataGridView2.Rows.Add(order.Timestamp, order.Price);
                }
                //List<string> tableColumns = new List<string>(3) { "FirstName", "LastName", "Inn" };
                //Dictionary<string, string> map = new Dictionary<string, string>(3)
                //{
                //    ["LastName"] = "Фамилия",
                //    ["FirstName"] = "Имя",
                //    ["Inn"] = "Инн"
                //};

                //TableBuilder.BuildTable(clients, tabControl2, map, new DataGridViewCellEventHandler(CellClickClient));
                if (clients != null && clients.Count > 0)
                {
                    //currentClient = clients[0];
                    //updateClientInfo();
                    //updateClientOrders(currentClient);
                }
                else
                {
                    //currentClient = null;
                    //currentOrder = null;
                    //updateClientOrders(currentClient);
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
            currentClient = clients[e.RowIndex];
            updateClientInfo();
            updateOrderTable();
        }

        private void CellClickOrder(object sender, DataGridViewCellEventArgs e)
        {
            currentOrder = currentClient.OrderRepairList[e.RowIndex];
            updateOrderInfo();
        }
    }
}