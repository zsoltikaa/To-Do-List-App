namespace to_do_list_app
{
    partial class frmMain
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
            btnRemove = new Button();
            listTasks = new ListBox();
            btnExit = new Button();
            comboBoxTime = new ComboBox();
            lblTimer = new Label();
            btnDone = new Button();
            lvlBar = new ProgressBar();
            SuspendLayout();
            // 
            // txbInput
            // 
            txbInput.Font = new Font("JetBrains Mono", 13.7999992F, FontStyle.Regular, GraphicsUnit.Point, 238);
            txbInput.Location = new Point(12, 12);
            txbInput.Name = "txbInput";
            txbInput.Size = new Size(310, 38);
            txbInput.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("JetBrains Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnAdd.Location = new Point(328, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(122, 38);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add task";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // checkbLow
            // 
            checkbLow.AutoSize = true;
            checkbLow.Font = new Font("JetBrains Mono", 10.1999989F);
            checkbLow.ForeColor = Color.FromArgb(192, 192, 0);
            checkbLow.Location = new Point(12, 67);
            checkbLow.Name = "checkbLow";
            checkbLow.Size = new Size(152, 26);
            checkbLow.TabIndex = 3;
            checkbLow.Text = "Low priority";
            checkbLow.UseVisualStyleBackColor = true;
            // 
            // checkbMedium
            // 
            checkbMedium.AutoSize = true;
            checkbMedium.Font = new Font("JetBrains Mono", 10.1999989F);
            checkbMedium.ForeColor = Color.FromArgb(207, 103, 0);
            checkbMedium.Location = new Point(12, 96);
            checkbMedium.Name = "checkbMedium";
            checkbMedium.Size = new Size(182, 26);
            checkbMedium.TabIndex = 4;
            checkbMedium.Text = "Medium priority";
            checkbMedium.UseVisualStyleBackColor = true;
            // 
            // checkbHigh
            // 
            checkbHigh.AutoSize = true;
            checkbHigh.Font = new Font("JetBrains Mono", 10.1999989F);
            checkbHigh.ForeColor = Color.Red;
            checkbHigh.Location = new Point(12, 128);
            checkbHigh.Name = "checkbHigh";
            checkbHigh.Size = new Size(162, 26);
            checkbHigh.TabIndex = 5;
            checkbHigh.Text = "High priority";
            checkbHigh.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Font = new Font("JetBrains Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnRemove.Location = new Point(328, 390);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(122, 64);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Remove task";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // listTasks
            // 
            listTasks.FormattingEnabled = true;
            listTasks.Location = new Point(12, 194);
            listTasks.Name = "listTasks";
            listTasks.Size = new Size(310, 304);
            listTasks.TabIndex = 8;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("JetBrains Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnExit.Location = new Point(328, 460);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(122, 38);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // comboBoxTime
            // 
            comboBoxTime.FormattingEnabled = true;
            comboBoxTime.Location = new Point(94, 160);
            comboBoxTime.Name = "comboBoxTime";
            comboBoxTime.Size = new Size(228, 28);
            comboBoxTime.TabIndex = 10;
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("JetBrains Mono", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, 238);
            lblTimer.Location = new Point(12, 161);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(76, 23);
            lblTimer.TabIndex = 11;
            lblTimer.Text = "Timer:";
            // 
            // btnDone
            // 
            btnDone.Font = new Font("JetBrains Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnDone.Location = new Point(328, 194);
            btnDone.Name = "btnDone";
            btnDone.Size = new Size(122, 64);
            btnDone.TabIndex = 12;
            btnDone.Text = "Task done";
            btnDone.UseVisualStyleBackColor = true;
            // 
            // lvlBar
            // 
            lvlBar.Location = new Point(12, 504);
            lvlBar.Name = "lvlBar";
            lvlBar.Size = new Size(438, 29);
            lvlBar.TabIndex = 13;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(462, 538);
            Controls.Add(lvlBar);
            Controls.Add(btnDone);
            Controls.Add(lblTimer);
            Controls.Add(comboBoxTime);
            Controls.Add(btnExit);
            Controls.Add(listTasks);
            Controls.Add(btnRemove);
            Controls.Add(checkbHigh);
            Controls.Add(checkbMedium);
            Controls.Add(checkbLow);
            Controls.Add(btnAdd);
            Controls.Add(txbInput);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "frmMain";
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
        private Button btnRemove;
        private ListBox listTasks;
        private Button btnExit;
        private ComboBox comboBoxTime;
        private Label lblTimer;
        private Button btnDone;
        private ProgressBar lvlBar;
    }
}
