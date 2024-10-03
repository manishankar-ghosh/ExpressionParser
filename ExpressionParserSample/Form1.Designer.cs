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
            btnMatch2 = new Button();
            SuspendLayout();
            // 
            // txtCriteria
            // 
            txtCriteria.Location = new Point(220, 78);
            txtCriteria.Margin = new Padding(4, 5, 4, 5);
            txtCriteria.Name = "txtCriteria";
            txtCriteria.Size = new Size(1065, 31);
            txtCriteria.TabIndex = 0;
            txtCriteria.Text = "10 > 2 -a 10 > 20";
            // 
            // btnMatch
            // 
            btnMatch.Location = new Point(220, 165);
            btnMatch.Margin = new Padding(4, 5, 4, 5);
            btnMatch.Name = "btnMatch";
            btnMatch.Size = new Size(107, 38);
            btnMatch.TabIndex = 1;
            btnMatch.Text = "Match";
            btnMatch.UseVisualStyleBackColor = true;
            btnMatch.Click += btnMatch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(141, 92);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 25);
            label1.TabIndex = 2;
            label1.Text = "Criteria";
            // 
            // btnMatch2
            // 
            btnMatch2.Location = new Point(215, 234);
            btnMatch2.Name = "btnMatch2";
            btnMatch2.Size = new Size(112, 34);
            btnMatch2.TabIndex = 3;
            btnMatch2.Text = "Match 2";
            btnMatch2.UseVisualStyleBackColor = true;
            btnMatch2.Click += btnMatch2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1424, 450);
            Controls.Add(btnMatch2);
            Controls.Add(label1);
            Controls.Add(btnMatch);
            Controls.Add(txtCriteria);
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
        private Button btnMatch2;
    }
}
