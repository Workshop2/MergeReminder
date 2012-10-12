namespace MergeReminder
{
    partial class Index
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Index));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uxLoginPane = new System.Windows.Forms.Panel();
            this.uxTest = new System.Windows.Forms.Button();
            this.uxDomain = new System.Windows.Forms.TextBox();
            this.uxPassword = new System.Windows.Forms.TextBox();
            this.uxTfsServer = new System.Windows.Forms.TextBox();
            this.uxUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uxBranchesPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.uxFilter = new System.Windows.Forms.CheckBox();
            this.uxFilterDevChanges = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.uxLoginPane.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "test2";
            this.notifyIcon1.BalloonTipTitle = "test1";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Merge Reminder";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 70);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuItem1.Text = "About";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // uxLoginPane
            // 
            this.uxLoginPane.Controls.Add(this.uxTest);
            this.uxLoginPane.Controls.Add(this.uxDomain);
            this.uxLoginPane.Controls.Add(this.uxPassword);
            this.uxLoginPane.Controls.Add(this.uxTfsServer);
            this.uxLoginPane.Controls.Add(this.uxUsername);
            this.uxLoginPane.Controls.Add(this.label2);
            this.uxLoginPane.Controls.Add(this.label4);
            this.uxLoginPane.Controls.Add(this.label3);
            this.uxLoginPane.Controls.Add(this.label1);
            this.uxLoginPane.Location = new System.Drawing.Point(0, 1);
            this.uxLoginPane.Name = "uxLoginPane";
            this.uxLoginPane.Size = new System.Drawing.Size(577, 92);
            this.uxLoginPane.TabIndex = 8;
            // 
            // uxTest
            // 
            this.uxTest.Location = new System.Drawing.Point(251, 67);
            this.uxTest.Name = "uxTest";
            this.uxTest.Size = new System.Drawing.Size(75, 23);
            this.uxTest.TabIndex = 16;
            this.uxTest.Text = "Test";
            this.uxTest.UseVisualStyleBackColor = true;
            this.uxTest.Click += new System.EventHandler(this.uxTest_Click);
            // 
            // uxDomain
            // 
            this.uxDomain.Location = new System.Drawing.Point(460, 12);
            this.uxDomain.Name = "uxDomain";
            this.uxDomain.Size = new System.Drawing.Size(100, 20);
            this.uxDomain.TabIndex = 15;
            // 
            // uxPassword
            // 
            this.uxPassword.Location = new System.Drawing.Point(301, 39);
            this.uxPassword.Name = "uxPassword";
            this.uxPassword.Size = new System.Drawing.Size(100, 20);
            this.uxPassword.TabIndex = 14;
            this.uxPassword.UseSystemPasswordChar = true;
            // 
            // uxTfsServer
            // 
            this.uxTfsServer.Location = new System.Drawing.Point(64, 12);
            this.uxTfsServer.Name = "uxTfsServer";
            this.uxTfsServer.Size = new System.Drawing.Size(162, 20);
            this.uxTfsServer.TabIndex = 9;
            // 
            // uxUsername
            // 
            this.uxUsername.Location = new System.Drawing.Point(301, 12);
            this.uxUsername.Name = "uxUsername";
            this.uxUsername.Size = new System.Drawing.Size(100, 20);
            this.uxUsername.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Username:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Domain:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tfs Server:";
            // 
            // uxBranchesPanel
            // 
            this.uxBranchesPanel.Enabled = false;
            this.uxBranchesPanel.Location = new System.Drawing.Point(6, 120);
            this.uxBranchesPanel.Name = "uxBranchesPanel";
            this.uxBranchesPanel.Size = new System.Drawing.Size(563, 206);
            this.uxBranchesPanel.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(218, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Save Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Branches:";
            // 
            // uxFilter
            // 
            this.uxFilter.AutoSize = true;
            this.uxFilter.Location = new System.Drawing.Point(7, 342);
            this.uxFilter.Name = "uxFilter";
            this.uxFilter.Size = new System.Drawing.Size(177, 17);
            this.uxFilter.TabIndex = 14;
            this.uxFilter.Text = "Exclude other people\'s changes";
            this.uxFilter.UseVisualStyleBackColor = true;
            // 
            // uxFilterDevChanges
            // 
            this.uxFilterDevChanges.AutoSize = true;
            this.uxFilterDevChanges.Location = new System.Drawing.Point(7, 367);
            this.uxFilterDevChanges.Name = "uxFilterDevChanges";
            this.uxFilterDevChanges.Size = new System.Drawing.Size(165, 17);
            this.uxFilterDevChanges.TabIndex = 14;
            this.uxFilterDevChanges.Text = "Include eSightDev\'s changes";
            this.uxFilterDevChanges.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 408);
            this.Controls.Add(this.uxFilter);
            this.Controls.Add(this.uxFilterDevChanges);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.uxBranchesPanel);
            this.Controls.Add(this.uxLoginPane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Merge Reminder";
            this.contextMenuStrip1.ResumeLayout(false);
            this.uxLoginPane.ResumeLayout(false);
            this.uxLoginPane.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel uxLoginPane;
        private System.Windows.Forms.Button uxTest;
        private System.Windows.Forms.TextBox uxDomain;
        private System.Windows.Forms.TextBox uxPassword;
        private System.Windows.Forms.TextBox uxTfsServer;
        private System.Windows.Forms.TextBox uxUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel uxBranchesPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox uxFilter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.CheckBox uxFilterDevChanges;
    }
}

