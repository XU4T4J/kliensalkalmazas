namespace RF_Kliensalkalmazás
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
            this.checkedListBoxProducts = new System.Windows.Forms.CheckedListBox();
            this.buttonDOWN = new System.Windows.Forms.Button();
            this.buttonUP = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // checkedListBoxProducts
            // 
            this.checkedListBoxProducts.FormattingEnabled = true;
            this.checkedListBoxProducts.Location = new System.Drawing.Point(39, 32);
            this.checkedListBoxProducts.Name = "checkedListBoxProducts";
            this.checkedListBoxProducts.Size = new System.Drawing.Size(328, 349);
            this.checkedListBoxProducts.TabIndex = 0;
            this.checkedListBoxProducts.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxProducts_SelectedIndexChanged);
            // 
            // buttonDOWN
            // 
            this.buttonDOWN.Location = new System.Drawing.Point(639, 358);
            this.buttonDOWN.Name = "buttonDOWN";
            this.buttonDOWN.Size = new System.Drawing.Size(134, 23);
            this.buttonDOWN.TabIndex = 1;
            this.buttonDOWN.Text = "Leárazás";
            this.buttonDOWN.UseVisualStyleBackColor = true;
            this.buttonDOWN.Click += new System.EventHandler(this.buttonDOWN_Click);
            // 
            // buttonUP
            // 
            this.buttonUP.Location = new System.Drawing.Point(447, 358);
            this.buttonUP.Name = "buttonUP";
            this.buttonUP.Size = new System.Drawing.Size(134, 23);
            this.buttonUP.TabIndex = 2;
            this.buttonUP.Text = "Ár növelése";
            this.buttonUP.UseVisualStyleBackColor = true;
            this.buttonUP.Click += new System.EventHandler(this.buttonUP_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(639, 135);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(511, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Árváltoztatás mértéke:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(385, 53);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 290);
            this.listBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonUP);
            this.Controls.Add(this.buttonDOWN);
            this.Controls.Add(this.checkedListBoxProducts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxProducts;
        private System.Windows.Forms.Button buttonDOWN;
        private System.Windows.Forms.Button buttonUP;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
    }
}

