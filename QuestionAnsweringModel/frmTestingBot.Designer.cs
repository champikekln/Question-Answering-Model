namespace Testing
{
    partial class frmTestingBot
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
            button1 = new Button();
            txtQuestion = new TextBox();
            txtAnswer = new TextBox();
            resetChat = new Button();
            Training = new Button();
            panel1 = new Panel();
            Train = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            panel1.SuspendLayout();
            Train.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(773, 17);
            button1.Name = "button1";
            button1.Size = new Size(125, 24);
            button1.TabIndex = 0;
            button1.Text = "Test";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtQuestion
            // 
            txtQuestion.Location = new Point(31, 19);
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(736, 23);
            txtQuestion.TabIndex = 1;
            // 
            // txtAnswer
            // 
            txtAnswer.Location = new Point(31, 48);
            txtAnswer.Multiline = true;
            txtAnswer.Name = "txtAnswer";
            txtAnswer.ScrollBars = ScrollBars.Both;
            txtAnswer.Size = new Size(736, 352);
            txtAnswer.TabIndex = 2;
            // 
            // resetChat
            // 
            resetChat.Location = new Point(773, 57);
            resetChat.Name = "resetChat";
            resetChat.Size = new Size(125, 55);
            resetChat.TabIndex = 3;
            resetChat.Text = "Reset";
            resetChat.UseVisualStyleBackColor = true;
            resetChat.Click += resetChat_Click;
            // 
            // Training
            // 
            Training.Location = new Point(3, 3);
            Training.Name = "Training";
            Training.Size = new Size(886, 32);
            Training.TabIndex = 4;
            Training.Text = "Training";
            Training.UseVisualStyleBackColor = true;
            Training.Click += Training_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(Training);
            panel1.Location = new Point(6, 39);
            panel1.Name = "panel1";
            panel1.Size = new Size(892, 38);
            panel1.TabIndex = 5;
            // 
            // Train
            // 
            Train.Controls.Add(tabPage1);
            Train.Controls.Add(tabPage2);
            Train.Location = new Point(12, 12);
            Train.Name = "Train";
            Train.SelectedIndex = 0;
            Train.Size = new Size(912, 445);
            Train.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtQuestion);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(resetChat);
            tabPage1.Controls.Add(txtAnswer);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(904, 417);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Testing";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(904, 417);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Training";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmTestingBot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 481);
            Controls.Add(Train);
            Name = "frmTestingBot";
            Text = "Train & Test";
            Load += frmTestingBot_Load;
            panel1.ResumeLayout(false);
            Train.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private TextBox txtQuestion;
        private TextBox txtAnswer;
        private Button resetChat;
        private Button Training;
        private Panel panel1;
        private TabControl Train;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}
