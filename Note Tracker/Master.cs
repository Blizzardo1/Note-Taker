// <copyright file="Master.cs" company="Blizzeta Software and Gaming">
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
    public partial class Master : Form
    {
        private static Master _self;
        public static Master Self { get { return _self; } }

        public Master()
        {
            InitializeComponent();
            string[] names = Enum.GetNames(typeof(ServiceStatus));
            for (int i = 0; i < names.Length; i++)
                names[i] = names[i].Replace('_', ' ');
            Service.Items.AddRange(names);

            priority.Items.AddRange(Enum.GetNames(typeof(Priority)));
            _self = this;
        }

        private void NewTicket_Click(object sender, EventArgs e)
        {
            (new TicketNew()).ShowDialog();
        }

        private void ReopenTicket_Click(object sender, EventArgs e)
        {
            // TODO: Search our Recent Customer List on the server
        }

        private void Close_Click(object sender, EventArgs e)
        {
            if (OpenOrders.SelectedItem != null)
                ((Ticket)OpenOrders.SelectedItem).CloseTicket();
            else BoxDiag.Error(OpenOrders, this, true);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            // TODO: Save and close all MySql Connections before exiting

        }

        private void LOff_Click(object sender, EventArgs e)
        {
            if (OpenOrders.SelectedItem != null)
                ((Ticket)OpenOrders.SelectedItem).Level = Defcon.Off;
            else BoxDiag.Error(OpenOrders, this, true);
            
        }

        private void LUrgent_Click(object sender, EventArgs e)
        {
            if (OpenOrders.SelectedItem != null)
                ((Ticket)OpenOrders.SelectedItem).Level = Defcon.Urgent;
            else BoxDiag.Error(OpenOrders, this, true);
        }

        private void LSevere_Click(object sender, EventArgs e)
        {
            if (OpenOrders.SelectedItem != null)
                ((Ticket)OpenOrders.SelectedItem).Level = Defcon.Severe;
            else BoxDiag.Error(OpenOrders, this, true);
        }

        private void LModerate_Click(object sender, EventArgs e)
        {
            if (OpenOrders.SelectedItem != null)
                ((Ticket)OpenOrders.SelectedItem).Level = Defcon.Moderate;
            else BoxDiag.Error(OpenOrders, this, true);
        }

        private void LLight_Click(object sender, EventArgs e)
        {
            if (OpenOrders.SelectedItem != null)
                ((Ticket)OpenOrders.SelectedItem).Level = Defcon.Light;
            else BoxDiag.Error(OpenOrders, this, true);
        }

        private void LAbandoned_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this,
                "Are you sure you want to do this? Once you do this, you cannot go back!",
                "Mark Order Abandoned",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (OpenOrders.SelectedItem != null)
                    ((Ticket)OpenOrders.SelectedItem).Level = Defcon.Abandoned;
                else BoxDiag.Error(OpenOrders, this, true);
            }
        }

        private void UpdateStatus_Click(object sender, EventArgs e)
        {
            if (OpenOrders.SelectedItem != null)
                ((Ticket)OpenOrders.SelectedItem).Status = (ServiceStatus)Enum.Parse(typeof(ServiceStatus), (Service.SelectedItem as string).Replace(' ', '_'));
            else BoxDiag.Error(OpenOrders, this, true);
        }

        public void AddOrder(Ticket ticket)
        {
            OpenOrders.Items.Add(ticket);
            lockDownMode.Text = ticket.Level.ToString();
            StatusText.Text = ticket.Status.ToString().Replace('_', ' ');
            workOrder.Text = ticket.WorkOrderNumber.ToString();
            currentName.Text = string.Format("{0}, {1}", ticket.CustomerInformation.LastName, ticket.CustomerInformation.FirstName);
            CurrentNotes = ticket.Notes;
            CurrentNotes.Invalidate();
        }

        private void OpenOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(OpenOrders.SelectedItem != null)
            {
                Ticket t = ((Ticket)OpenOrders.SelectedItem);
                CurrentNotes = t.Notes;
                CurrentNotes.Invalidate();
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (OpenOrders.SelectedItem != null)
            {
                Ticket t = ((Ticket)OpenOrders.SelectedItem);
                t.Notes.Items.Add(new Ticket.Note() { priority = Priority.NotPrioritised, Message = InputNotes.Text, Timestamp = DateTime.Now });
                CurrentNotes = t.Notes;
                CurrentNotes.Invalidate();
            }
            else BoxDiag.Error(OpenOrders, this, true);
        }

        private void DeleteNote_Click(object sender, EventArgs e)
        {

        }

        private void UpdatePriority_Click(object sender, EventArgs e)
        {
            if (CurrentNotes.SelectedItem != null && OpenOrders.SelectedItem != null)
                ((Ticket)OpenOrders.SelectedItem).PrioritiseNote(((Ticket.Note)CurrentNotes.SelectedItem), (Priority)Enum.Parse(typeof(Priority), priority.SelectedText));
            else BoxDiag.Error(CurrentNotes, this, true);
        }
    }
}
