namespace MergeReminder
{
    partial class BranchingTree
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // uxTreeView
            // 
            this.uxTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxTreeView.Location = new System.Drawing.Point(0, 0);
            this.uxTreeView.Name = "uxTreeView";
            this.uxTreeView.Size = new System.Drawing.Size(150, 150);
            this.uxTreeView.TabIndex = 0;
            this.uxTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.uxTreeView_BeforeCheck);
            // 
            // BranchingTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.uxTreeView);
            this.Name = "BranchingTree";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView uxTreeView;
    }
}
