// <copyright file="TicketNew.cs" company="Blizzeta Software and Gaming">
// Copyright (c) 2013 All Rights Reserved
// <author>Adonis S. Deliannis (Blizzardo1)</author>
// </copyright>
      
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Note_Taker
{
    public partial class TicketNew : Form
    {
        public TicketNew()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Ticket.CustomerInfo ci = new Ticket.CustomerInfo()
            {
                FirstName = firstName.Text,
                LastName = lastName.Text,
                Address = addressInfo.Text,
                PrimaryPhone = primaryPhone.Text,
                AlternatePhone = alternatePhone.Text,
                Email = emailAddress.Text,
                ComputerResponse = placeResponse.Text,
                NetworkResponse = networkResponse.Text,
                SpeedResponse = speedResponse.Text,
                ProtectionResponse = protectionResponse.Text,
                BackupReponse = backupResponse.Text,
                DiscussReponse = discussResponse.Text,
                Issues = issues.Text,
                CompInfo = new Ticket.ComputerInformation()
                {
                    Brand = brand.Text,
                    Model = model.Text,
                    Serial = serial.Text,
                    Processor = processor.Text,
                    OperatingSystem = operatingSystem.Text,
                    RAM = currentRAM.Text,
                    MaxRAM = maxRAM.Text
                }
            };

            Ticket t = new Ticket(ci);
            t.OrderAdded += t_OrderAdded;
            t.CreateTicket();
            Ticket.OpenTickets.Add(t);
            this.Close();
        }

        void t_OrderAdded(Ticket ticket)
        {
            Master.Self.AddOrder(ticket);
            BoxDiag.Success(string.Format("Success! You've created a work order for {0} {1} with {2} as new WID", ticket.CustomerInformation.FirstName, ticket.CustomerInformation.LastName, ticket.WorkOrderNumber));
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
                c.Dispose();
            this.Close();
        }
    }
}
