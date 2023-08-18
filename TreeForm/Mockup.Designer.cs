namespace TreeForm
{
    partial class Mockup
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
            this.treeview = new System.Windows.Forms.TreeView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeview
            // 
            this.treeview.Location = new System.Drawing.Point(88, 95);
            this.treeview.Name = "treeview";
            this.treeview.Size = new System.Drawing.Size(248, 316);
            this.treeview.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(430, 95);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(248, 316);
            this.treeView1.TabIndex = 2;
            // 
            // Mockup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.treeview);
            this.Name = "Mockup";
            this.Text = "Mockup";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeview;
        private System.Windows.Forms.TreeView treeView1;
    }
}