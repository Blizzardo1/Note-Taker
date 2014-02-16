// <copyright file="Ticket.cs" company="Blizzeta Software and Gaming">
// Copyright (c) 2013 All Rights Reserved
// <author>Adonis S. Deliannis (Blizzardo1)</author>
// </copyright>
      
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Note_Taker
{
    [Flags]
    public enum Defcon : sbyte
    {
        Off = 0x00,
        Urgent = 0x01,
        Severe = 0x02,
        Moderate = 0x04,
        Light = 0x08,
        Abandoned = 0x16
    }

    [Flags]
    public enum Priority: short
    {
        NotPrioritised = 0x0000,
        Low = 0x0001,
        Medium = 0x0010,
        High = 0x0100,
        Realtime = 0x1000
    }

    [Flags]
    public enum ServiceStatus : sbyte
    {
        Service_Not_Started = 0,
        Service_Started = 1,
        Service_Completed = 2,
        Pickup_Confirmed = 3,
        Closed_and_PickedUp = 4
    }

    public delegate void OrderAddedHandler(Ticket ticket);
    public delegate void OrderClosedHandler(Ticket ticket);
    public delegate void OrderServiceStatusChanngedHandler(Ticket ticket);
    public delegate void OrderPriorityChangedHandler(Ticket ticket, Ticket.Note note);
    public delegate void OrderLockdownChangedHandler(Ticket ticket);

    public class Ticket
    {
        public event OrderAddedHandler OrderAdded;
        public event OrderClosedHandler OrderClosed;
        public event OrderServiceStatusChanngedHandler OrderServiceStatusChanged;
        public event OrderPriorityChangedHandler OrderPriorityChanged;
        public event OrderLockdownChangedHandler OrderLockdownChanged;

        public struct CustomerInfo
        {
            public string FirstName;
            public string LastName;
            public string Address;
            public string Email;
            public string PrimaryPhone;
            public string AlternatePhone;
            public string Issues;
            public string ComputerResponse;
            public string NetworkResponse;
            public string SpeedResponse;
            public string ProtectionResponse;
            public string BackupReponse;
            public string DiscussReponse;
            public ComputerInformation CompInfo;
        }

        public struct ComputerInformation
        {
            public string Brand;
            public string Model;
            public string Serial;
            public string OperatingSystem;
            public string Processor;
            public string RAM;
            public string MaxRAM;
        }

        public struct Note
        {
            public DateTime Timestamp;
            public Priority priority;
            public string Message;
            public override string ToString()
            {
                return string.Format("[{0:MM/dd/yy HH:mm:ss}{1}] {2}",
                    Timestamp,
                    priority == Priority.NotPrioritised ? "" : string.Format(", {0}", priority),
                    Message);
            }
        }

        public System.Windows.Forms.ListBox Notes = new System.Windows.Forms.ListBox();

        private CustomerInfo cinfo;
        private long workorder;

        public CustomerInfo CustomerInformation { get { return cinfo; } }

        public long WorkOrderNumber { get { return workorder; } }

        public static List<Ticket> OpenTickets = new List<Ticket>();
        public Defcon Level = Defcon.Off;
        public ServiceStatus Status = ServiceStatus.Service_Not_Started;

        public Ticket(CustomerInfo customerInfo)
        {
            this.cinfo = customerInfo;
        }

        public void StoreCustomerInformation()
        {
            // TODO: Store information into the MySQL Server
            
        }

        public void ChangeLockdown(Defcon lockdown)
        {
            this.Level = lockdown;
            if (OrderLockdownChanged != null)
                OrderLockdownChanged(this);
        }

        public void PrioritiseNote(Note note, Priority priority)
        {
            note.priority = priority;
            if (OrderPriorityChanged != null)
                OrderPriorityChanged(this, note);
        }

        public bool ChangeServiceStatus(ServiceStatus status)
        {
            if (this.Status <= ServiceStatus.Service_Completed)
            {
                this.Status = status;
                if (OrderServiceStatusChanged != null) OrderServiceStatusChanged(this);
                return true;
            }
            else if (this.Status == ServiceStatus.Service_Completed && status >= ServiceStatus.Service_Completed)
            {
                this.Status = status;
                if (OrderServiceStatusChanged != null) OrderServiceStatusChanged(this);
                return true;
            }

            return false;
        }

        public bool CloseTicket()
        {
            if (Status == ServiceStatus.Closed_and_PickedUp)
            {
                if (OrderClosed != null)
                    OrderClosed(this);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates a new Ticket
        /// </summary>
        /// <param name="customerInfo">The Customer Information you provide in the New Ticket Window</param>
        /// <returns>A new ticket based on the Customer Information</returns>
        public void CreateTicket()
        {
            object locko = new object();

            lock (locko)
            {
                System.Threading.Thread.Sleep(100);
                this.workorder = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmssf"));
            }

            // TODO: Fix Delegate Mishap; Not Firing
            // TODO: Add MySql Code here!
            if (OrderAdded != null)
                OrderAdded(this);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", workorder, cinfo.LastName);
        }
    }
}
