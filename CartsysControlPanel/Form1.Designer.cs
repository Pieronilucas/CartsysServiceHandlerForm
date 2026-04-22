namespace CartsysControlPanel;

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
        radioButton1 = new RadioButton();
        radioButton2 = new RadioButton();
        radioButton3 = new RadioButton();
        radioButton4 = new RadioButton();
        radioButton5 = new RadioButton();
        radioButton6 = new RadioButton();
        radioButton7 = new RadioButton();
        radioButton8 = new RadioButton();
        radioButton9 = new RadioButton();
        radioButton10 = new RadioButton();
        button1 = new Button();
        SeriaHdTb = new TextBox();
        button2 = new Button();
        textBox1 = new TextBox();
        SuspendLayout();
        // 
        // radioButton1
        // 
        radioButton1.AutoSize = true;
        radioButton1.Location = new Point(12, 16);
        radioButton1.Name = "radioButton1";
        radioButton1.Size = new Size(65, 19);
        radioButton1.TabIndex = 0;
        radioButton1.TabStop = true;
        radioButton1.Tag = "1";
        radioButton1.Text = "Executa";
        radioButton1.UseVisualStyleBackColor = true;
        radioButton1.CheckedChanged += RadioButton_CheckedChanged;
        // 
        // radioButton2
        // 
        radioButton2.AutoSize = true;
        radioButton2.Location = new Point(12, 41);
        radioButton2.Name = "radioButton2";
        radioButton2.Size = new Size(73, 19);
        radioButton2.TabIndex = 1;
        radioButton2.TabStop = true;
        radioButton2.Tag = "2";
        radioButton2.Text = "Guardian";
        radioButton2.UseVisualStyleBackColor = true;
        radioButton2.CheckedChanged += RadioButton_CheckedChanged;
        // 
        // radioButton3
        // 
        radioButton3.AutoSize = true;
        radioButton3.Location = new Point(12, 66);
        radioButton3.Name = "radioButton3";
        radioButton3.Size = new Size(91, 19);
        radioButton3.TabIndex = 2;
        radioButton3.TabStop = true;
        radioButton3.Tag = "3";
        radioButton3.Text = "Notificações";
        radioButton3.UseVisualStyleBackColor = true;
        radioButton3.CheckedChanged += RadioButton_CheckedChanged;
        // 
        // radioButton4
        // 
        radioButton4.AutoSize = true;
        radioButton4.Location = new Point(12, 91);
        radioButton4.Name = "radioButton4";
        radioButton4.Size = new Size(57, 19);
        radioButton4.TabIndex = 3;
        radioButton4.TabStop = true;
        radioButton4.Tag = "4";
        radioButton4.Text = "NFS-e";
        radioButton4.UseVisualStyleBackColor = true;
        radioButton4.CheckedChanged += RadioButton_CheckedChanged;
        // 
        // radioButton5
        // 
        radioButton5.AutoSize = true;
        radioButton5.Location = new Point(12, 116);
        radioButton5.Name = "radioButton5";
        radioButton5.Size = new Size(62, 19);
        radioButton5.TabIndex = 4;
        radioButton5.TabStop = true;
        radioButton5.Tag = "5";
        radioButton5.Text = "Tarefas";
        radioButton5.UseVisualStyleBackColor = true;
        radioButton5.CheckedChanged += RadioButton_CheckedChanged;
        // 
        // radioButton6
        // 
        radioButton6.AutoSize = true;
        radioButton6.Location = new Point(12, 141);
        radioButton6.Name = "radioButton6";
        radioButton6.Size = new Size(63, 19);
        radioButton6.TabIndex = 5;
        radioButton6.TabStop = true;
        radioButton6.Tag = "6";
        radioButton6.Text = "Zapzap";
        radioButton6.UseVisualStyleBackColor = true;
        radioButton6.CheckedChanged += RadioButton_CheckedChanged;
        // 
        // radioButton7
        // 
        radioButton7.AutoSize = true;
        radioButton7.Location = new Point(12, 166);
        radioButton7.Name = "radioButton7";
        radioButton7.Size = new Size(63, 19);
        radioButton7.TabIndex = 6;
        radioButton7.TabStop = true;
        radioButton7.Tag = "7";
        radioButton7.Text = "Update";
        radioButton7.UseVisualStyleBackColor = true;
        radioButton7.CheckedChanged += RadioButton_CheckedChanged;
        // 
        // radioButton8
        // 
        radioButton8.AutoSize = true;
        radioButton8.Location = new Point(12, 191);
        radioButton8.Name = "radioButton8";
        radioButton8.Size = new Size(80, 19);
        radioButton8.TabIndex = 7;
        radioButton8.TabStop = true;
        radioButton8.Tag = "8";
        radioButton8.Text = "Parcelinha";
        radioButton8.UseVisualStyleBackColor = true;
        radioButton8.CheckedChanged += RadioButton_CheckedChanged;
        // 
        // radioButton9
        // 
        radioButton9.AutoSize = true;
        radioButton9.Location = new Point(12, 216);
        radioButton9.Name = "radioButton9";
        radioButton9.Size = new Size(139, 19);
        radioButton9.TabIndex = 8;
        radioButton9.TabStop = true;
        radioButton9.Tag = "9";
        radioButton9.Text = "SignalR (meu nenem)";
        radioButton9.UseVisualStyleBackColor = true;
        radioButton9.CheckedChanged += RadioButton_CheckedChanged;
        // 
        // radioButton10
        // 
        radioButton10.AutoSize = true;
        radioButton10.Location = new Point(12, 241);
        radioButton10.Name = "radioButton10";
        radioButton10.Size = new Size(61, 19);
        radioButton10.TabIndex = 9;
        radioButton10.TabStop = true;
        radioButton10.Tag = "10";
        radioButton10.Text = "Alertas";
        radioButton10.UseVisualStyleBackColor = true;
        radioButton10.CheckedChanged += RadioButton_CheckedChanged;
        // 
        // button1
        // 
        button1.Location = new Point(12, 290);
        button1.Name = "button1";
        button1.Size = new Size(200, 23);
        button1.TabIndex = 10;
        button1.Text = "Instalar";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // SeriaHdTb
        // 
        SeriaHdTb.Location = new Point(1698, 12);
        SeriaHdTb.Name = "SeriaHdTb";
        SeriaHdTb.Size = new Size(89, 23);
        SeriaHdTb.TabIndex = 11;
        SeriaHdTb.TextChanged += textBox1_TextChanged;
        // 
        // button2
        // 
        button2.BackColor = Color.Turquoise;
        button2.Location = new Point(12, 523);
        button2.Name = "button2";
        button2.Size = new Size(75, 23);
        button2.TabIndex = 12;
        button2.Text = "Setar reg";
        button2.UseVisualStyleBackColor = false;
        button2.Click += button2_Click;
        // 
        // textBox1
        // 
        textBox1.BackColor = SystemColors.Control;
        textBox1.BorderStyle = BorderStyle.None;
        textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        textBox1.Location = new Point(1599, 13);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(93, 23);
        textBox1.TabIndex = 13;
        textBox1.Text = "Serial HD:";
        textBox1.TextAlign = HorizontalAlignment.Center;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1799, 840);
        Controls.Add(textBox1);
        Controls.Add(button2);
        Controls.Add(SeriaHdTb);
        Controls.Add(button1);
        Controls.Add(radioButton10);
        Controls.Add(radioButton9);
        Controls.Add(radioButton8);
        Controls.Add(radioButton7);
        Controls.Add(radioButton6);
        Controls.Add(radioButton5);
        Controls.Add(radioButton4);
        Controls.Add(radioButton3);
        Controls.Add(radioButton2);
        Controls.Add(radioButton1);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private RadioButton radioButton3;
    private RadioButton radioButton4;
    private RadioButton radioButton5;
    private RadioButton radioButton6;
    private RadioButton radioButton7;
    private RadioButton radioButton8;
    private RadioButton radioButton9;
    private RadioButton radioButton10;
    private Button button1;
    private TextBox SeriaHdTb;
    private Button button2;
    private TextBox textBox1;
}