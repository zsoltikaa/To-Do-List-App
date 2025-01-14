namespace to_do_list_app
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Application = Application;
    using Timer = System.Threading.Timer;

    public partial class FrmMain : Form
    {
        private readonly List<(string taskName, DateTime dueTime)> scheduledTasks = [];

        private readonly List<string> motivationalQuotes =
        [
            "Believe in yourself and all that you are.",
            "The only way to do great work is to love what you do.",
            "You are capable of amazing things.",
            "Your only limit is your mind.",
            "Dream big, work hard, stay focused, and make it happen.",
            "Success is not the key to happiness. Happiness is the key to success.",
            "The future belongs to those who believe in the beauty of their dreams.",
            "Believe you can and you're halfway there.",
            "Don't watch the clock; do what it does. Keep going.",
            "The best way to predict the future is to create it."
        ];

        private readonly string filePath = "tasks.txt";
        private int currentLevel = 1;

        private int currentPoints = 0;

        private int pointsToNextLevel = 20;

        public FrmMain()
        {

            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            listTasks.DrawMode = DrawMode.OwnerDrawFixed;
            listTasks.DrawItem += ListTasks_DrawItem;
            btnAdd.Click += new EventHandler(BtnAddTaskClick);
            btnRemove.Click += new EventHandler(BtnRemoveTaskClick);
            btnExit.Click += BtnExitClick;
            btnDone.Click += new EventHandler(BtnDoneClick);
            checkbLow.CheckedChanged += new EventHandler(CheckBoxCheckedChanged);
            checkbMedium.CheckedChanged += new EventHandler(CheckBoxCheckedChanged);
            checkbHigh.CheckedChanged += new EventHandler(CheckBoxCheckedChanged);

            for (int hours = 0; hours < 24; hours++)
            {
                for (int minutes = 0; minutes < 60; minutes += 5)
                {
                    comboBoxTime.Items.Add($"{hours:D2}:{minutes:D2}");
                }
            }

            comboBoxTime.SelectedIndex = 0;

            LoadTasks();

        }

        private void BtnAddTaskClick(object sender, EventArgs e)
        {

            string taskName = txbInput.Text;

            if (string.IsNullOrWhiteSpace(taskName))
            {
                MessageBox.Show("Please provide a task!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string priority = "";
            if (checkbLow.Checked)
            {
                priority = "Low Priority";
            }
            else if (checkbMedium.Checked)
            {
                priority = "Medium Priority";
            }
            else if (checkbHigh.Checked)
            {
                priority = "High Priority";
            }

            if (string.IsNullOrEmpty(priority))
            {
                MessageBox.Show("Please select a priority!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedTime = comboBoxTime.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedTime))
            {
                MessageBox.Show("Please select a time for the task!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string taskEntry = $"{taskName} | {priority} | {selectedTime}";
            listTasks.Items.Add(taskEntry);
            SortTasksByPriority();
            SaveTasks();
            txbInput.Clear();
            checkbLow.Checked = false;
            checkbMedium.Checked = false;
            checkbHigh.Checked = false;

            MessageBox.Show("Task added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnRemoveTaskClick(object sender, EventArgs e)
        {

            if (listTasks.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to remove!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            listTasks.Items.Remove(listTasks.SelectedItem);
            SaveTasks();

            MessageBox.Show("Task removed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnDoneClick(object sender, EventArgs e)
        {

            if (listTasks.SelectedItem == null)
            {
                MessageBox.Show("Please select a task to mark as completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedTask = listTasks.SelectedItem.ToString();

            listTasks.Items.Remove(listTasks.SelectedItem);

            var taskToRemove = scheduledTasks.FirstOrDefault(t => $"{t.taskName} | {t.dueTime:HH:mm}" == selectedTask);
            if (taskToRemove.taskName != null)
            {
                scheduledTasks.Remove(taskToRemove);
            }

            SaveTasks();

            MessageBox.Show("Task marked as completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            string[] taskParts = selectedTask.Split('|');
            string priority = taskParts[1].Trim();
            int points = 0;

            if (priority == "Low Priority") points = 2;
            else if (priority == "Medium Priority") points = 3;
            else if (priority == "High Priority") points = 5;

            UpdatePoints(points);
            UpdateLevelDisplay();

        }

        private void UpdatePoints(int pointsToAdd)
        {

            currentPoints += pointsToAdd;

            if (currentLevel < 5 && currentPoints >= pointsToNextLevel)
            {
                currentLevel++;
                pointsToNextLevel *= 2;
                currentPoints = 0;

                DisplayMotivationalQuote();

                MessageBox.Show($"Congratulations! You've reached Level {currentLevel}!", "Level Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void DisplayMotivationalQuote()
        {

            Random random = new();
            int index = random.Next(motivationalQuotes.Count);
            string quote = motivationalQuotes[index];

            MessageBox.Show(quote, "Motivational Quote", MessageBoxButtons.OK);

        }

        private void ListTasks_DrawItem(object sender, DrawItemEventArgs e)
        {

            if (e.Index < 0) return;

            string itemText = listTasks.Items[e.Index].ToString();
            Color backgroundColor = Color.White;

            if (itemText.Contains("Low Priority")) backgroundColor = Color.Yellow;
            else if (itemText.Contains("Medium Priority")) backgroundColor = Color.Orange;
            else if (itemText.Contains("High Priority")) backgroundColor = Color.Red;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backgroundColor = ControlPaint.Dark(backgroundColor);
            }

            using (Brush backgroundBrush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            Color textColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected ? Color.White : e.ForeColor;

            using (Brush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(itemText, e.Font, textBrush, e.Bounds);
            }

            e.DrawFocusRectangle();

        }

        private void SortTasksByPriority()
        {

            var sortedTasks = listTasks.Items.Cast<string>()
                .OrderByDescending(item =>
                {
                    if (item.Contains("High Priority")) return 3;
                    if (item.Contains("Medium Priority")) return 2;
                    if (item.Contains("Low Priority")) return 1;
                    return 0;
                })
                .ToList();

            listTasks.Items.Clear();

            foreach (var task in sortedTasks)
            {
                listTasks.Items.Add(task);
            }

        }

        private void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length >= 4)
                {
                    if (lines[1].StartsWith("Level: ") && int.TryParse(lines[1].AsSpan(7), out int level))
                        currentLevel = level;

                    if (lines[2].StartsWith("Points: ") && int.TryParse(lines[2].AsSpan(9), out int points))
                        currentPoints = points;

                    if (lines[3].StartsWith("Points needed for next level: "))
                    {
                        if (lines[3].Length > 35)
                        {
                            string pointsString = lines[3].Substring(35).Trim();
                            if (int.TryParse(pointsString, out int nextLevelPoints))
                            {
                                pointsToNextLevel = nextLevelPoints;
                            }
                        }
                    }

                    if (pointsToNextLevel <= 0) pointsToNextLevel = 20;
                }

                for (int i = 4; i < lines.Length; i++)
                {
                    listTasks.Items.Add(lines[i]);
                }
            }

            UpdateLevelDisplay();

        }

        private void SaveTasks()
        {

            List<string> lines =
            [
                "=== Progress ===",
                $"Level: {currentLevel}",
                $"Points: {currentPoints}",
                $"Points needed for next level: {pointsToNextLevel}",
            ];

            foreach (var item in listTasks.Items)
            {
                lines.Add(item.ToString());
            }

            File.WriteAllLines(filePath, lines);

        }

        private void BtnExitClick(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                caption: "Warning",
                text: "Do you wish to exit the app?",
                buttons: MessageBoxButtons.YesNo,
                icon: MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void CheckBoxCheckedChanged(object sender, EventArgs e)
        {

            var checkboxes = new[] { checkbLow, checkbMedium, checkbHigh };

            if (((CheckBox)sender).Checked)
            {
                foreach (var checkbox in checkboxes.Where(cb => cb != sender))
                {
                    checkbox.Checked = false;
                }
            }

        }

        private void UpdateLevelDisplay()
        {

            lblLevel.Text = $"Level: {currentLevel} | Points: {currentPoints}/{pointsToNextLevel}";

        }
    }
}