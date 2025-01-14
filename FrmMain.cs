namespace to_do_list_app
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using Timer = System.Threading.Timer;
    using System.Diagnostics;

    public partial class frmMain : Form
    {
        private List<(string taskName, DateTime dueTime)> scheduledTasks = new List<(string, DateTime)>();
        private string filePath = "tasks.txt";
        private Timer taskTimer;
        private int currentLevel = 1;
        private int currentPoints = 0;
        private int pointsToNextLevel = 20;

        public frmMain()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            listTasks.DrawMode = DrawMode.OwnerDrawFixed;
            listTasks.DrawItem += ListTasks_DrawItem;
            btnAdd.Click += new EventHandler(btnAddTaskClick);
            btnRemove.Click += new EventHandler(btnRemoveTaskClick);
            btnExit.Click += BtnExitClick;
            btnDone.Click += new EventHandler(btnDoneClick);
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
            lvlBar.Maximum = 100;
            lvlBar.Value = 0;
        }

        private void btnAddTaskClick(object sender, EventArgs e)
        {
            string taskName = txbInput.Text;
            if (string.IsNullOrWhiteSpace(taskName))
            {
                MessageBox.Show("Please provide a task!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int points = 0;
            string priority = "";
            if (checkbLow.Checked)
            {
                priority = "Low Priority";
                points = 2;
            }
            else if (checkbMedium.Checked)
            {
                priority = "Medium Priority";
                points = 3;
            }
            else if (checkbHigh.Checked)
            {
                priority = "High Priority";
                points = 5;
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

        private void btnRemoveTaskClick(object sender, EventArgs e)
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

        private void btnDoneClick(object sender, EventArgs e)
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

            UpdateProgressBar(points);
        }

        private void UpdateProgressBar(int pointsToAdd)
        {
            currentPoints += pointsToAdd;

            if (currentPoints >= pointsToNextLevel)
            {
                currentLevel++;
                pointsToNextLevel *= 2;
                currentPoints = 0;

                MessageBox.Show($"Congratulations! You've reached Level {currentLevel}!", "Level Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            int progress = (int)((double)currentPoints / pointsToNextLevel * 100);
            lvlBar.Value = progress;
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

        private void ScheduleTask(string taskName, string timeString)
        {
            if (DateTime.TryParse(timeString, out DateTime taskTime))
            {
                DateTime now = DateTime.Now;
                DateTime dueTime = new DateTime(now.Year, now.Month, now.Day, taskTime.Hour, taskTime.Minute, 0);

                if (dueTime < now)
                {
                    dueTime = dueTime.AddDays(1);
                }

                scheduledTasks.Add((taskName, dueTime));

                if (taskTimer == null)
                {
                    taskTimer = new Timer(CheckScheduledTasks, null, 0, 1000);
                }
            }
        }

        private void CheckScheduledTasks(object state)
        {
            DateTime now = DateTime.Now;

            var expiredTasks = scheduledTasks.Where(t => t.dueTime <= now).ToList();

            foreach (var task in expiredTasks)
            {
                var itemToRemove = listTasks.Items.Cast<string>().FirstOrDefault(i => i.Contains(task.taskName));
                if (itemToRemove != null)
                {
                    listTasks.Items.Remove(itemToRemove);
                }

                scheduledTasks.Remove(task);
            }

            if (!scheduledTasks.Any())
            {
                taskTimer.Dispose();
                taskTimer = null;
            }
        }

        private void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length >= 3)
                {
                    // Load the saved values for current level, points, and points to the next level
                    if (int.TryParse(lines[0], out int level))
                    {
                        currentLevel = level;
                    }

                    if (int.TryParse(lines[1], out int points))
                    {
                        currentPoints = points;
                    }

                    if (int.TryParse(lines[2], out int nextLevelPoints))
                    {
                        pointsToNextLevel = nextLevelPoints;
                    }

                    // Debug: Output the loaded values
                    Debug.WriteLine($"Loaded Level: {currentLevel}");
                    Debug.WriteLine($"Loaded Points: {currentPoints}");
                    Debug.WriteLine($"Loaded Points to Next Level: {pointsToNextLevel}");

                    // Ensure pointsToNextLevel is not zero or negative
                    if (pointsToNextLevel <= 0)
                    {
                        pointsToNextLevel = 20; // Default value if loading is incorrect or zero
                        Debug.WriteLine("pointsToNextLevel was zero or negative, resetting to 20.");
                    }

                    // Calculate progress and update the progress bar
                    if (pointsToNextLevel > 0)
                    {
                        int progress = (int)((double)currentPoints / pointsToNextLevel * 100);
                        progress = Math.Min(progress, 100); // Ensure we don't exceed 100%

                        // Debug: Output the calculated progress bar value
                        Debug.WriteLine($"Calculated Progress Bar Value: {progress}");

                        lvlBar.Value = progress;
                    }
                }

                // Load the tasks starting from the 4th line in the file (skipping level and points)
                for (int i = 3; i < lines.Length; i++)
                {
                    string task = lines[i];
                    var parts = task.Split('|');
                    if (parts.Length >= 3)
                    {
                        string taskName = parts[0].Trim();
                        string priority = parts[1].Trim();
                        string time = parts[2].Trim();
                        listTasks.Items.Add(task);
                    }
                }
            }
        }

        private void SaveTasks()
        {
            List<string> lines = new List<string>
            {
                currentLevel.ToString(),
                currentPoints.ToString(),
                pointsToNextLevel.ToString()
            };

            foreach (var item in listTasks.Items)
            {
                lines.Add(item.ToString());
            }

            File.WriteAllLines(filePath, lines);
        }

        private void BtnExitClick(object sender, EventArgs e)
        {
            Application.Exit();
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

    }
}
