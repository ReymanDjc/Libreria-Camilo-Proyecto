namespace LibreriaCamilo.Consultas
{
    partial class cFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cFactura));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ConsultacomboBox = new System.Windows.Forms.ComboBox();
            this.BuscartextBox = new System.Windows.Forms.TextBox();
            this.Filtrarbutton = new System.Windows.Forms.Button();
            this.ClientesdataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(503, 105);
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            // 
            // ConsultacomboBox
            // 
            this.ConsultacomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ConsultacomboBox.FormattingEnabled = true;
            this.ConsultacomboBox.Location = new System.Drawing.Point(97, 125);
            this.ConsultacomboBox.Name = "ConsultacomboBox";
            this.ConsultacomboBox.Size = new System.Drawing.Size(94, 21);
            this.ConsultacomboBox.TabIndex = 72;
            // 
            // BuscartextBox
            // 
            this.BuscartextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BuscartextBox.Location = new System.Drawing.Point(228, 125);
            this.BuscartextBox.Name = "BuscartextBox";
            this.BuscartextBox.Size = new System.Drawing.Size(122, 20);
            this.BuscartextBox.TabIndex = 71;
            // 
            // Filtrarbutton
            // 
            this.Filtrarbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Filtrarbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Filtrarbutton.Location = new System.Drawing.Point(384, 123);
            this.Filtrarbutton.Name = "Filtrarbutton";
            this.Filtrarbutton.Size = new System.Drawing.Size(60, 23);
            this.Filtrarbutton.TabIndex = 70;
            this.Filtrarbutton.Text = "Filtrar";
            this.Filtrarbutton.UseVisualStyleBackColor = true;
            // 
            // ClientesdataGridView
            // 
            this.ClientesdataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientesdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientesdataGridView.Location = new System.Drawing.Point(12, 151);
            this.ClientesdataGridView.Name = "ClientesdataGridView";
            this.ClientesdataGridView.Size = new System.Drawing.Size(495, 220);
            this.ClientesdataGridView.TabIndex = 69;
            // 
            // cFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 376);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ConsultacomboBox);
            this.Controls.Add(this.BuscartextBox);
            this.Controls.Add(this.Filtrarbutton);
            this.Controls.Add(this.ClientesdataGridView);
            this.Name = "cFactura";
            this.Text = "cFactura";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClientesdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox ConsultacomboBox;
        private System.Windows.Forms.TextBox BuscartextBox;
        private System.Windows.Forms.Button Filtrarbutton;
        private System.Windows.Forms.DataGridView ClientesdataGridView;
    }
}