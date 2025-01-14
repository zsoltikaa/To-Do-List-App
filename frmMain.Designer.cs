namespace to_do_list_app
{
    partial class FrmMain
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
            txbInput = new TextBox();
            btnAdd = new Button();
            checkbLow = new CheckBox();
            checkbMedium = new CheckBox();
            checkbHigh = new CheckBox();
            listTasks = new ListBox();
            comboBoxTime = new ComboBox();
            lblTimer = new Label();
            lblLevel = new Label();
            btnRemove = new Button();
            btnExit = new Button();
            btnDone = new Button();
            SuspendLayout();
            // 
            // txbInput
            // 
            txbInput.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txbInput.Location = new Point(12, 12);
            txbInput.Name = "txbInput";
            txbInput.Size = new Size(310, 34);
            txbInput.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(199, 95, 4);
            btnAdd.Font = new Font("Segoe UI", 12F);
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(328, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(122, 35);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add task";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // checkbLow
            // 
            checkbLow.AutoSize = true;
            checkbLow.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkbLow.ForeColor = Color.FromArgb(192, 192, 0);
            checkbLow.Location = new Point(12, 138);
            checkbLow.Name = "checkbLow";
            checkbLow.Size = new Size(142, 32);
            checkbLow.TabIndex = 3;
            checkbLow.Text = "Low priority";
            checkbLow.UseVisualStyleBackColor = true;
            // 
            // checkbMedium
            // 
            checkbMedium.AutoSize = true;
            checkbMedium.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkbMedium.ForeColor = Color.FromArgb(207, 103, 0);
            checkbMedium.Location = new Point(12, 100);
            checkbMedium.Name = "checkbMedium";
            checkbMedium.Size = new Size(181, 32);
            checkbMedium.TabIndex = 4;
            checkbMedium.Text = "Medium priority";
            checkbMedium.UseVisualStyleBackColor = true;
            // 
            // checkbHigh
            // 
            checkbHigh.AutoSize = true;
            checkbHigh.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            checkbHigh.ForeColor = Color.Red;
            checkbHigh.Location = new Point(12, 62);
            checkbHigh.Name = "checkbHigh";
            checkbHigh.Size = new Size(149, 32);
            checkbHigh.TabIndex = 5;
            checkbHigh.Text = "High priority";
            checkbHigh.UseVisualStyleBackColor = true;
            // 
            // listTasks
            // 
            listTasks.FormattingEnabled = true;
            listTasks.Location = new Point(12, 225);
            listTasks.Name = "listTasks";
            listTasks.Size = new Size(310, 304);
            listTasks.TabIndex = 8;
            // 
            // comboBoxTime
            // 
            comboBoxTime.FormattingEnabled = true;
            comboBoxTime.Location = new Point(82, 185);
            comboBoxTime.Name = "comboBoxTime";
            comboBoxTime.Size = new Size(240, 28);
            comboBoxTime.TabIndex = 10;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("Segoe UI Light", 12F);
            lblTimer.ForeColor = Color.White;
            lblTimer.Location = new Point(12, 181);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(64, 28);
            lblTimer.TabIndex = 11;
            lblTimer.Text = "Timer:";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            lblLevel.ForeColor = Color.FromArgb(199, 95, 4);
            lblLevel.Location = new Point(12, 532);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(46, 28);
            lblLevel.TabIndex = 13;
            lblLevel.Text = "lvlv";
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(199, 95, 4);
            btnRemove.Font = new Font("Segoe UI", 12F);
            btnRemove.ForeColor = Color.Black;
            btnRemove.Location = new Point(328, 395);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(122, 64);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Remove task";
            btnRemove.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(199, 95, 4);
            btnExit.Font = new Font("Segoe UI", 12F);
            btnExit.ForeColor = Color.Black;
            btnExit.Location = new Point(328, 465);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 64);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            // 
            // btnDone
            // 
            btnDone.BackColor = Color.FromArgb(199, 95, 4);
            btnDone.Font = new Font("Segoe UI", 12F);
            btnDone.ForeColor = Color.Black;
            btnDone.Location = new Point(328, 325);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(122, 64);
            btnDone.TabIndex = 12;
            btnDone.Text = "Task done";
            btnDone.UseVisualStyleBackColor = false;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 31, 31);
            ClientSize = new Size(462, 569);
            Controls.Add(lblLevel);
            Controls.Add(btnDone);
            Controls.Add(lblTimer);
            Controls.Add(btnExit);
            Controls.Add(comboBoxTime);
            Controls.Add(btnRemove);
            Controls.Add(listTasks);
            Controls.Add(checkbHigh);
            Controls.Add(checkbMedium);
            Controls.Add(checkbLow);
            Controls.Add(btnAdd);
            Controls.Add(txbInput);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FrmMain";
            Text = " To Do List App";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbInput;
        private Button btnAdd;
        private CheckBox checkbLow;
        private CheckBox checkbMedium;
        private CheckBox checkbHigh;
        private ListBox listTasks;
        private ComboBox comboBoxTime;
        private Label lblTimer;
        private Label lblLevel;
        private Button btnRemove;
        private Button btnExit;
        private Button btnDone;
    }
}
