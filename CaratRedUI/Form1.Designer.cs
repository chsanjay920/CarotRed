namespace CaratRedUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.RootPannel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // RootPannel
            // 
            this.RootPannel.BackColor = System.Drawing.Color.Transparent;
            this.RootPannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RootPannel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RootPannel.Location = new System.Drawing.Point(0, 0);
            this.RootPannel.Margin = new System.Windows.Forms.Padding(2);
            this.RootPannel.Name = "RootPannel";
            this.RootPannel.Size = new System.Drawing.Size(1584, 861);
            this.RootPannel.TabIndex = 0;
            this.RootPannel.Paint += new System.Windows.Forms.PaintEventHandler(this.RootPannel_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CaratRedUI.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.RootPannel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Scan | Ezy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel RootPannel;
    }
}

