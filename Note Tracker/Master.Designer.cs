// <copyright file="Master.Designer.cs" company="Blizzeta Software and Gaming">
// Copyright (c) 2013 All Rights Reserved
// <author>Adonis S. Deliannis (Blizzardo1)</author>
// </copyright>
      
namespace Note_Taker
{
    partial class Master
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.NewTicket = new System.Windows.Forms.MenuItem();
            this.ReopenTicket = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.Close = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.Exit = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.LOff = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.LAbandoned = new System.Windows.Forms.MenuItem();
            this.LUrgent = new System.Windows.Forms.MenuItem();
            this.LSevere = new System.Windows.Forms.MenuItem();
            this.LModerate = new System.Windows.Forms.MenuItem();
            this.LLight = new System.Windows.Forms.MenuItem();
            this.OpenOrders = new System.Windows.Forms.ListBox();
            this.CurrentNotes = new System.Windows.Forms.ListBox();
            this.InputNotes = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.DeleteNote = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.workOrder = new System.Windows.Forms.TextBox();
            this.currentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UpdateStatus = new System.Windows.Forms.Button();
            this.Service = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StatusText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lockDownMode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.priority = new System.Windows.Forms.ComboBox();
            this.UpdatePriority = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem8});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.NewTicket,
            this.ReopenTicket,
            this.menuItem4,
            this.Close,
            this.menuItem6,
            this.Exit});
            this.menuItem1.Text = "&File";
            // 
            // NewTicket
            // 
            this.NewTicket.Index = 0;
            this.NewTicket.Text = "&New Ticket";
            this.NewTicket.Click += new System.EventHandler(this.NewTicket_Click);
            // 
            // ReopenTicket
            // 
            this.ReopenTicket.Index = 1;
            this.ReopenTicket.Text = "&Reopen";
            this.ReopenTicket.Click += new System.EventHandler(this.ReopenTicket_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // Close
            // 
            this.Close.Index = 3;
            this.Close.Text = "&Close";
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 4;
            this.menuItem6.Text = "-";
            // 
            // Exit
            // 
            this.Exit.Index = 5;
            this.Exit.Text = "E&xit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.LOff,
            this.menuItem13,
            this.LAbandoned,
            this.LUrgent,
            this.LSevere,
            this.LModerate,
            this.LLight});
            this.menuItem8.Text = "&Set Lockdown";
            // 
            // LOff
            // 
            this.LOff.Index = 0;
            this.LOff.Text = "&Off";
            this.LOff.Click += new System.EventHandler(this.LOff_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 1;
            this.menuItem13.Text = "-";
            // 
            // LAbandoned
            // 
            this.LAbandoned.Index = 2;
            this.LAbandoned.Text = "Abandoned";
            this.LAbandoned.Click += new System.EventHandler(this.LAbandoned_Click);
            // 
            // LUrgent
            // 
            this.LUrgent.Index = 3;
            this.LUrgent.Text = "&Urgent";
            this.LUrgent.Click += new System.EventHandler(this.LUrgent_Click);
            // 
            // LSevere
            // 
            this.LSevere.Index = 4;
            this.LSevere.Text = "&Severe";
            this.LSevere.Click += new System.EventHandler(this.LSevere_Click);
            // 
            // LModerate
            // 
            this.LModerate.Index = 5;
            this.LModerate.Text = "&Moderate";
            this.LModerate.Click += new System.EventHandler(this.LModerate_Click);
            // 
            // LLight
            // 
            this.LLight.Index = 6;
            this.LLight.Text = "&Light";
            this.LLight.Click += new System.EventHandler(this.LLight_Click);
            // 
            // OpenOrders
            // 
            this.OpenOrders.FormattingEnabled = true;
            this.OpenOrders.Location = new System.Drawing.Point(2, 4);
            this.OpenOrders.Name = "OpenOrders";
            this.OpenOrders.Size = new System.Drawing.Size(190, 368);
            this.OpenOrders.TabIndex = 0;
            this.OpenOrders.SelectedIndexChanged += new System.EventHandler(this.OpenOrders_SelectedIndexChanged);
            // 
            // CurrentNotes
            // 
            this.CurrentNotes.FormattingEnabled = true;
            this.CurrentNotes.Location = new System.Drawing.Point(197, 69);
            this.CurrentNotes.Name = "CurrentNotes";
            this.CurrentNotes.Size = new System.Drawing.Size(451, 160);
            this.CurrentNotes.TabIndex = 1;
            // 
            // InputNotes
            // 
            this.InputNotes.Location = new System.Drawing.Point(198, 236);
            this.InputNotes.Multiline = true;
            this.InputNotes.Name = "InputNotes";
            this.InputNotes.Size = new System.Drawing.Size(447, 72);
            this.InputNotes.TabIndex = 2;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(561, 315);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(82, 23);
            this.Send.TabIndex = 3;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // DeleteNote
            // 
            this.DeleteNote.Location = new System.Drawing.Point(480, 315);
            this.DeleteNote.Name = "DeleteNote";
            this.DeleteNote.Size = new System.Drawing.Size(75, 23);
            this.DeleteNote.TabIndex = 4;
            this.DeleteNote.Text = "Delete";
            this.DeleteNote.UseVisualStyleBackColor = true;
            this.DeleteNote.Click += new System.EventHandler(this.DeleteNote_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Work Order";
            // 
            // workOrder
            // 
            this.workOrder.Location = new System.Drawing.Point(267, 1);
            this.workOrder.Name = "workOrder";
            this.workOrder.ReadOnly = true;
            this.workOrder.Size = new System.Drawing.Size(185, 20);
            this.workOrder.TabIndex = 6;
            // 
            // currentName
            // 
            this.currentName.Location = new System.Drawing.Point(267, 28);
            this.currentName.Name = "currentName";
            this.currentName.ReadOnly = true;
            this.currentName.Size = new System.Drawing.Size(185, 20);
            this.currentName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Name";
            // 
            // UpdateStatus
            // 
            this.UpdateStatus.Location = new System.Drawing.Point(458, 349);
            this.UpdateStatus.Name = "UpdateStatus";
            this.UpdateStatus.Size = new System.Drawing.Size(75, 23);
            this.UpdateStatus.TabIndex = 9;
            this.UpdateStatus.Text = "Update";
            this.UpdateStatus.UseVisualStyleBackColor = true;
            this.UpdateStatus.Click += new System.EventHandler(this.UpdateStatus_Click);
            // 
            // Service
            // 
            this.Service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Service.FormattingEnabled = true;
            this.Service.Location = new System.Drawing.Point(279, 351);
            this.Service.Name = "Service";
            this.Service.Size = new System.Drawing.Size(173, 21);
            this.Service.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Status";
            // 
            // StatusText
            // 
            this.StatusText.Location = new System.Drawing.Point(502, 1);
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            this.StatusText.Size = new System.Drawing.Size(136, 20);
            this.StatusText.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(465, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Lock";
            // 
            // lockDownMode
            // 
            this.lockDownMode.Location = new System.Drawing.Point(502, 28);
            this.lockDownMode.Name = "lockDownMode";
            this.lockDownMode.ReadOnly = true;
            this.lockDownMode.Size = new System.Drawing.Size(136, 20);
            this.lockDownMode.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 354);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Service Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Priority";
            // 
            // priority
            // 
            this.priority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priority.FormattingEnabled = true;
            this.priority.Location = new System.Drawing.Point(243, 312);
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(137, 21);
            this.priority.TabIndex = 15;
            // 
            // UpdatePriority
            // 
            this.UpdatePriority.Location = new System.Drawing.Point(386, 310);
            this.UpdatePriority.Name = "UpdatePriority";
            this.UpdatePriority.Size = new System.Drawing.Size(75, 23);
            this.UpdatePriority.TabIndex = 9;
            this.UpdatePriority.Text = "Update";
            this.UpdatePriority.UseVisualStyleBackColor = true;
            this.UpdatePriority.Click += new System.EventHandler(this.UpdatePriority_Click);
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 376);
            this.Controls.Add(this.priority);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lockDownMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StatusText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Service);
            this.Controls.Add(this.UpdatePriority);
            this.Controls.Add(this.UpdateStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentName);
            this.Controls.Add(this.workOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeleteNote);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.InputNotes);
            this.Controls.Add(this.CurrentNotes);
            this.Controls.Add(this.OpenOrders);
            this.Menu = this.mainMenu1;
            this.Name = "Master";
            this.Text = "Notes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem NewTicket;
        private System.Windows.Forms.MenuItem ReopenTicket;
        private System.Windows.Forms.MenuItem menuItem4;
        new private System.Windows.Forms.MenuItem Close;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem Exit;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem LOff;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.MenuItem LUrgent;
        private System.Windows.Forms.MenuItem LSevere;
        private System.Windows.Forms.MenuItem LModerate;
        private System.Windows.Forms.MenuItem LLight;
        private System.Windows.Forms.ListBox OpenOrders;
        private System.Windows.Forms.ListBox CurrentNotes;
        private System.Windows.Forms.TextBox InputNotes;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Button DeleteNote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox workOrder;
        private System.Windows.Forms.TextBox currentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuItem LAbandoned;
        private System.Windows.Forms.Button UpdateStatus;
        private System.Windows.Forms.ComboBox Service;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox StatusText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lockDownMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox priority;
        private System.Windows.Forms.Button UpdatePriority;
    }
}

