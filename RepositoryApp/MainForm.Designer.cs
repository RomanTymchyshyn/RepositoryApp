namespace RepositoryApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.EventPanel = new System.Windows.Forms.Panel();
            this.AddEventButton = new System.Windows.Forms.Button();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EventTypeComboBox = new System.Windows.Forms.ComboBox();
            this.EventTypeLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.IDLabel = new System.Windows.Forms.Label();
            this.SaveEventPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.AppConfigCheckBox = new System.Windows.Forms.CheckBox();
            this.HelpLabel = new System.Windows.Forms.Label();
            this.DeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.SaveAllButton = new System.Windows.Forms.Button();
            this.SaveCurrentButton = new System.Windows.Forms.Button();
            this.DBCheckBox = new System.Windows.Forms.CheckBox();
            this.XMLCheckBox = new System.Windows.Forms.CheckBox();
            this.txtCheckBox = new System.Windows.Forms.CheckBox();
            this.overwriteCheckBox = new System.Windows.Forms.CheckBox();
            this.EventPanel.SuspendLayout();
            this.SaveEventPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EventPanel
            // 
            this.EventPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EventPanel.Controls.Add(this.AddEventButton);
            this.EventPanel.Controls.Add(this.DescriptionTextBox);
            this.EventPanel.Controls.Add(this.label1);
            this.EventPanel.Controls.Add(this.EventTypeComboBox);
            this.EventPanel.Controls.Add(this.EventTypeLabel);
            this.EventPanel.Controls.Add(this.NameTextBox);
            this.EventPanel.Controls.Add(this.NameLabel);
            this.EventPanel.Controls.Add(this.IDTextBox);
            this.EventPanel.Controls.Add(this.IDLabel);
            this.EventPanel.Location = new System.Drawing.Point(10, 10);
            this.EventPanel.Name = "EventPanel";
            this.EventPanel.Size = new System.Drawing.Size(360, 340);
            this.EventPanel.TabIndex = 0;
            // 
            // AddEventButton
            // 
            this.AddEventButton.Location = new System.Drawing.Point(131, 303);
            this.AddEventButton.Name = "AddEventButton";
            this.AddEventButton.Size = new System.Drawing.Size(84, 32);
            this.AddEventButton.TabIndex = 8;
            this.AddEventButton.Text = "Add Event";
            this.AddEventButton.UseVisualStyleBackColor = true;
            this.AddEventButton.Click += new System.EventHandler(this.AddEventButton_Click);
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(109, 86);
            this.DescriptionTextBox.Multiline = true;
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(246, 215);
            this.DescriptionTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(3, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Event description";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventTypeComboBox
            // 
            this.EventTypeComboBox.FormattingEnabled = true;
            this.EventTypeComboBox.Items.AddRange(new object[] {
            "Error",
            "Warning",
            "Info"});
            this.EventTypeComboBox.Location = new System.Drawing.Point(109, 62);
            this.EventTypeComboBox.Name = "EventTypeComboBox";
            this.EventTypeComboBox.Size = new System.Drawing.Size(246, 21);
            this.EventTypeComboBox.TabIndex = 5;
            this.EventTypeComboBox.Text = "Error";
            // 
            // EventTypeLabel
            // 
            this.EventTypeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EventTypeLabel.Location = new System.Drawing.Point(3, 62);
            this.EventTypeLabel.Name = "EventTypeLabel";
            this.EventTypeLabel.Size = new System.Drawing.Size(100, 21);
            this.EventTypeLabel.TabIndex = 4;
            this.EventTypeLabel.Text = "Event type";
            this.EventTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(109, 36);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(246, 20);
            this.NameTextBox.TabIndex = 3;
            // 
            // NameLabel
            // 
            this.NameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameLabel.Location = new System.Drawing.Point(3, 36);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(100, 20);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Event name";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(109, 10);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(246, 20);
            this.IDTextBox.TabIndex = 1;
            // 
            // IDLabel
            // 
            this.IDLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IDLabel.Location = new System.Drawing.Point(3, 10);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(100, 20);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "Event ID";
            this.IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveEventPanel
            // 
            this.SaveEventPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SaveEventPanel.Controls.Add(this.overwriteCheckBox);
            this.SaveEventPanel.Controls.Add(this.exitButton);
            this.SaveEventPanel.Controls.Add(this.AppConfigCheckBox);
            this.SaveEventPanel.Controls.Add(this.HelpLabel);
            this.SaveEventPanel.Controls.Add(this.DeleteCheckBox);
            this.SaveEventPanel.Controls.Add(this.SaveAllButton);
            this.SaveEventPanel.Controls.Add(this.SaveCurrentButton);
            this.SaveEventPanel.Controls.Add(this.DBCheckBox);
            this.SaveEventPanel.Controls.Add(this.XMLCheckBox);
            this.SaveEventPanel.Controls.Add(this.txtCheckBox);
            this.SaveEventPanel.Location = new System.Drawing.Point(376, 10);
            this.SaveEventPanel.Name = "SaveEventPanel";
            this.SaveEventPanel.Size = new System.Drawing.Size(237, 340);
            this.SaveEventPanel.TabIndex = 1;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Red;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.Location = new System.Drawing.Point(68, 297);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(106, 37);
            this.exitButton.TabIndex = 8;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // AppConfigCheckBox
            // 
            this.AppConfigCheckBox.Location = new System.Drawing.Point(131, 36);
            this.AppConfigCheckBox.Name = "AppConfigCheckBox";
            this.AppConfigCheckBox.Size = new System.Drawing.Size(88, 47);
            this.AppConfigCheckBox.TabIndex = 7;
            this.AppConfigCheckBox.Text = "Use way from app.config";
            this.AppConfigCheckBox.UseVisualStyleBackColor = true;
            // 
            // HelpLabel
            // 
            this.HelpLabel.Location = new System.Drawing.Point(12, 139);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(207, 112);
            this.HelpLabel.TabIndex = 6;
            this.HelpLabel.Text = resources.GetString("HelpLabel.Text");
            this.HelpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DeleteCheckBox
            // 
            this.DeleteCheckBox.Location = new System.Drawing.Point(12, 112);
            this.DeleteCheckBox.Name = "DeleteCheckBox";
            this.DeleteCheckBox.Size = new System.Drawing.Size(172, 24);
            this.DeleteCheckBox.TabIndex = 5;
            this.DeleteCheckBox.Text = "Delete events from local repo";
            this.DeleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // SaveAllButton
            // 
            this.SaveAllButton.Location = new System.Drawing.Point(134, 254);
            this.SaveAllButton.Name = "SaveAllButton";
            this.SaveAllButton.Size = new System.Drawing.Size(85, 37);
            this.SaveAllButton.TabIndex = 4;
            this.SaveAllButton.Text = "Save all added events";
            this.SaveAllButton.UseVisualStyleBackColor = true;
            this.SaveAllButton.Click += new System.EventHandler(this.SaveAllButton_Click);
            // 
            // SaveCurrentButton
            // 
            this.SaveCurrentButton.Location = new System.Drawing.Point(12, 254);
            this.SaveCurrentButton.Name = "SaveCurrentButton";
            this.SaveCurrentButton.Size = new System.Drawing.Size(81, 37);
            this.SaveCurrentButton.TabIndex = 3;
            this.SaveCurrentButton.Text = "Save current event";
            this.SaveCurrentButton.UseVisualStyleBackColor = true;
            this.SaveCurrentButton.Click += new System.EventHandler(this.SaveCurrentButton_Click);
            // 
            // DBCheckBox
            // 
            this.DBCheckBox.AutoSize = true;
            this.DBCheckBox.Location = new System.Drawing.Point(12, 51);
            this.DBCheckBox.Name = "DBCheckBox";
            this.DBCheckBox.Size = new System.Drawing.Size(81, 17);
            this.DBCheckBox.TabIndex = 2;
            this.DBCheckBox.Text = "Save to DB";
            this.DBCheckBox.UseVisualStyleBackColor = true;
            // 
            // XMLCheckBox
            // 
            this.XMLCheckBox.AutoSize = true;
            this.XMLCheckBox.Location = new System.Drawing.Point(131, 10);
            this.XMLCheckBox.Name = "XMLCheckBox";
            this.XMLCheckBox.Size = new System.Drawing.Size(88, 17);
            this.XMLCheckBox.TabIndex = 1;
            this.XMLCheckBox.Text = "Save to XML";
            this.XMLCheckBox.UseVisualStyleBackColor = true;
            // 
            // txtCheckBox
            // 
            this.txtCheckBox.AutoSize = true;
            this.txtCheckBox.Location = new System.Drawing.Point(12, 10);
            this.txtCheckBox.Name = "txtCheckBox";
            this.txtCheckBox.Size = new System.Drawing.Size(77, 17);
            this.txtCheckBox.TabIndex = 0;
            this.txtCheckBox.Text = "Save to txt";
            this.txtCheckBox.UseVisualStyleBackColor = true;
            // 
            // overwriteCheckBox
            // 
            this.overwriteCheckBox.AutoSize = true;
            this.overwriteCheckBox.Location = new System.Drawing.Point(12, 86);
            this.overwriteCheckBox.Name = "overwriteCheckBox";
            this.overwriteCheckBox.Size = new System.Drawing.Size(175, 17);
            this.overwriteCheckBox.TabIndex = 9;
            this.overwriteCheckBox.Text = "Overwrite if event already exists";
            this.overwriteCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 362);
            this.Controls.Add(this.SaveEventPanel);
            this.Controls.Add(this.EventPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Repository Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.EventPanel.ResumeLayout(false);
            this.EventPanel.PerformLayout();
            this.SaveEventPanel.ResumeLayout(false);
            this.SaveEventPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel EventPanel;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EventTypeComboBox;
        private System.Windows.Forms.Label EventTypeLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Button AddEventButton;
        private System.Windows.Forms.Panel SaveEventPanel;
        private System.Windows.Forms.Label HelpLabel;
        private System.Windows.Forms.CheckBox DeleteCheckBox;
        private System.Windows.Forms.Button SaveAllButton;
        private System.Windows.Forms.Button SaveCurrentButton;
        private System.Windows.Forms.CheckBox DBCheckBox;
        private System.Windows.Forms.CheckBox XMLCheckBox;
        private System.Windows.Forms.CheckBox txtCheckBox;
        private System.Windows.Forms.CheckBox AppConfigCheckBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.CheckBox overwriteCheckBox;
    }
}

