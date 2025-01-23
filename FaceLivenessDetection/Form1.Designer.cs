namespace FaceLivenessDetection
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
            textBoxMachineCode = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            pictureImage = new PictureBox();
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            richTextBox1 = new RichTextBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureImage).BeginInit();
            SuspendLayout();
            // 
            // textBoxMachineCode
            // 
            textBoxMachineCode.Location = new Point(156, 30);
            textBoxMachineCode.Name = "textBoxMachineCode";
            textBoxMachineCode.Size = new Size(193, 23);
            textBoxMachineCode.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBoxMachineCode);
            groupBox1.Location = new Point(21, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(367, 68);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Activation";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 33);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 1;
            label1.Text = "machineCode:";
            // 
            // pictureImage
            // 
            pictureImage.BackColor = SystemColors.ActiveBorder;
            pictureImage.BorderStyle = BorderStyle.FixedSingle;
            pictureImage.Location = new Point(27, 110);
            pictureImage.Name = "pictureImage";
            pictureImage.Size = new Size(361, 285);
            pictureImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureImage.TabIndex = 2;
            pictureImage.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(166, 470);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Open";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(27, 408);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(361, 56);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 505);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(pictureImage);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxMachineCode;
        private GroupBox groupBox1;
        private Label label1;
        private PictureBox pictureImage;
        private Button button1;
        private OpenFileDialog openFileDialog1;
        private RichTextBox richTextBox1;
    }
}
