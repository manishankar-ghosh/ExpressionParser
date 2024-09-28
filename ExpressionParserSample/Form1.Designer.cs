namespace ExpressionParserSample
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCriteria = new TextBox();
            btnMatch = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtCriteria
            // 
            txtCriteria.Location = new Point(154, 47);
            txtCriteria.Name = "txtCriteria";
            txtCriteria.Size = new Size(747, 23);
            txtCriteria.TabIndex = 0;
            txtCriteria.Text = "(Salary >= 5000 -a Dgn = Manager) -o (Bonus >= 1000 -a Address = Delhi Central) -o DOJ <= 01 Jan 2000";
            // 
            // btnMatch
            // 
            btnMatch.Location = new Point(154, 99);
            btnMatch.Name = "btnMatch";
            btnMatch.Size = new Size(75, 23);
            btnMatch.TabIndex = 1;
            btnMatch.Text = "Match";
            btnMatch.UseVisualStyleBackColor = true;
            btnMatch.Click += btnMatch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 55);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 2;
            label1.Text = "Criteria";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(997, 270);
            Controls.Add(label1);
            Controls.Add(btnMatch);
            Controls.Add(txtCriteria);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCriteria;
        private Button btnMatch;
        private Label label1;
    }
}
