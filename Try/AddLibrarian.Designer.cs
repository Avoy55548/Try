﻿
namespace LIBRARY_MANAGEMENT_SYSTEM
{
    partial class AddLibrarian
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
            this.btnCancelAL = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlInfoAB = new System.Windows.Forms.Panel();
            this.pnlInfoAB.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelAL
            // 
            this.btnCancelAL.BackColor = System.Drawing.Color.IndianRed;
            this.btnCancelAL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAL.Location = new System.Drawing.Point(387, 631);
            this.btnCancelAL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelAL.Name = "btnCancelAL";
            this.btnCancelAL.Size = new System.Drawing.Size(113, 31);
            this.btnCancelAL.TabIndex = 23;
            this.btnCancelAL.Text = "Cancel";
            this.btnCancelAL.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RosyBrown;
            this.panel2.Location = new System.Drawing.Point(0, -28);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(927, 80);
            this.panel2.TabIndex = 22;
            // 
            // pnlInfoAB
            // 
            this.pnlInfoAB.BackColor = System.Drawing.Color.RosyBrown;
            this.pnlInfoAB.Controls.Add(this.btnCancelAL);
            this.pnlInfoAB.Location = new System.Drawing.Point(428, 50);
            this.pnlInfoAB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlInfoAB.Name = "pnlInfoAB";
            this.pnlInfoAB.Size = new System.Drawing.Size(500, 662);
            this.pnlInfoAB.TabIndex = 21;
            // 
            // AddLibrarian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 684);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlInfoAB);
            this.Name = "AddLibrarian";
            this.Text = "AddLibrarian";
            this.pnlInfoAB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancelAL;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlInfoAB;
    }
}