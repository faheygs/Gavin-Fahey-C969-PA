namespace Gavin_Fahey_C969_PA
{
    partial class Main
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
            this.mainMenuOptions = new System.Windows.Forms.MenuStrip();
            this.customerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addCustomerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCustomerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCustomerBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addAppointmentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.updateAppointmentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAppointmentBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByWeekBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByMonthBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuOptions
            // 
            this.mainMenuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerMenu,
            this.appointmentMenu,
            this.calendarMenu});
            this.mainMenuOptions.Location = new System.Drawing.Point(0, 0);
            this.mainMenuOptions.Name = "mainMenuOptions";
            this.mainMenuOptions.Size = new System.Drawing.Size(800, 24);
            this.mainMenuOptions.TabIndex = 0;
            this.mainMenuOptions.Text = "Test";
            // 
            // customerMenu
            // 
            this.customerMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomerBtn,
            this.updateCustomerBtn,
            this.deleteCustomerBtn});
            this.customerMenu.Name = "customerMenu";
            this.customerMenu.Size = new System.Drawing.Size(71, 20);
            this.customerMenu.Text = "Customer";
            // 
            // addCustomerBtn
            // 
            this.addCustomerBtn.Name = "addCustomerBtn";
            this.addCustomerBtn.Size = new System.Drawing.Size(180, 22);
            this.addCustomerBtn.Text = "Add Customer";
            this.addCustomerBtn.Click += new System.EventHandler(this.addCustomerBtn_Click);
            // 
            // updateCustomerBtn
            // 
            this.updateCustomerBtn.Name = "updateCustomerBtn";
            this.updateCustomerBtn.Size = new System.Drawing.Size(180, 22);
            this.updateCustomerBtn.Text = "Update Customer";
            this.updateCustomerBtn.Click += new System.EventHandler(this.updateCustomerBtn_Click);
            // 
            // deleteCustomerBtn
            // 
            this.deleteCustomerBtn.Name = "deleteCustomerBtn";
            this.deleteCustomerBtn.Size = new System.Drawing.Size(180, 22);
            this.deleteCustomerBtn.Text = "Delete Customer";
            // 
            // appointmentMenu
            // 
            this.appointmentMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAppointmentBtn,
            this.updateAppointmentBtn,
            this.deleteAppointmentBtn});
            this.appointmentMenu.Name = "appointmentMenu";
            this.appointmentMenu.Size = new System.Drawing.Size(102, 20);
            this.appointmentMenu.Text = "Apppointments";
            // 
            // addAppointmentBtn
            // 
            this.addAppointmentBtn.Name = "addAppointmentBtn";
            this.addAppointmentBtn.Size = new System.Drawing.Size(186, 22);
            this.addAppointmentBtn.Text = "Add Appointment";
            // 
            // updateAppointmentBtn
            // 
            this.updateAppointmentBtn.Name = "updateAppointmentBtn";
            this.updateAppointmentBtn.Size = new System.Drawing.Size(186, 22);
            this.updateAppointmentBtn.Text = "Update Appointment";
            // 
            // deleteAppointmentBtn
            // 
            this.deleteAppointmentBtn.Name = "deleteAppointmentBtn";
            this.deleteAppointmentBtn.Size = new System.Drawing.Size(186, 22);
            this.deleteAppointmentBtn.Text = "Delete Appointment";
            // 
            // calendarMenu
            // 
            this.calendarMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByWeekBtn,
            this.sortByMonthBtn});
            this.calendarMenu.Name = "calendarMenu";
            this.calendarMenu.Size = new System.Drawing.Size(94, 20);
            this.calendarMenu.Text = "Calendar View";
            // 
            // sortByWeekBtn
            // 
            this.sortByWeekBtn.Name = "sortByWeekBtn";
            this.sortByWeekBtn.Size = new System.Drawing.Size(150, 22);
            this.sortByWeekBtn.Text = "Sort by Week";
            // 
            // sortByMonthBtn
            // 
            this.sortByMonthBtn.Name = "sortByMonthBtn";
            this.sortByMonthBtn.Size = new System.Drawing.Size(150, 22);
            this.sortByMonthBtn.Text = "Sort by Month";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainMenuOptions);
            this.MainMenuStrip = this.mainMenuOptions;
            this.Name = "Main";
            this.Text = "Main";
            this.mainMenuOptions.ResumeLayout(false);
            this.mainMenuOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuOptions;
        private System.Windows.Forms.ToolStripMenuItem customerMenu;
        private System.Windows.Forms.ToolStripMenuItem addCustomerBtn;
        private System.Windows.Forms.ToolStripMenuItem updateCustomerBtn;
        private System.Windows.Forms.ToolStripMenuItem deleteCustomerBtn;
        private System.Windows.Forms.ToolStripMenuItem appointmentMenu;
        private System.Windows.Forms.ToolStripMenuItem addAppointmentBtn;
        private System.Windows.Forms.ToolStripMenuItem updateAppointmentBtn;
        private System.Windows.Forms.ToolStripMenuItem deleteAppointmentBtn;
        private System.Windows.Forms.ToolStripMenuItem calendarMenu;
        private System.Windows.Forms.ToolStripMenuItem sortByWeekBtn;
        private System.Windows.Forms.ToolStripMenuItem sortByMonthBtn;
    }
}