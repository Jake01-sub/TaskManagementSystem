using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TaskManagementSystem
{
    public partial class Form1 : Form
    {
        private static int nextId = 1;
        private List<AbstractTask> allTasks = new List<AbstractTask>();
        private Queue<AbstractTask> nextTasksQueue = new Queue<AbstractTask>();

        public Form1()
        {
            InitializeComponent();
            SetupTaskGrid();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtTitle.Text.Trim();
                if (string.IsNullOrEmpty(title))
                {
                    MessageBox.Show("Error: Title cannot be empty.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int priority = (int)numPriority.Value;
                int parentId;
                if (!int.TryParse(txtParentId.Text.Trim(), out parentId))
                {
                    MessageBox.Show("Error: Invalid Parent ID. Use 0 for a root task.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                AbstractTask newTask = new ProjectTask(nextId++, title, priority);

                if (parentId == 0)
                {

                    allTasks.Add(newTask);
                    nextTasksQueue.Enqueue(newTask);
                    MessageBox.Show($"Root task added successfully.\nID: {newTask.Id}\nTitle: {newTask.Title}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    AbstractTask parent = LinearSearch(allTasks, parentId);
                    if (parent == null)
                    {
                        MessageBox.Show($"Error: Parent task with ID {parentId} not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    parent.SubTasks.Add(newTask);
                    allTasks.Add(newTask);
                    newTask.ParentId = parent.Id;
                    MessageBox.Show($"Subtask added under Parent ID {parentId}.\nNew Subtask ID: {newTask.Id}\nTitle: {newTask.Title}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                RefreshTaskGrid();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProcessNext_Click(object sender, EventArgs e)
        {
            int? selectedId = GetSelectedTaskId();
            if (selectedId == null)
            {
                MessageBox.Show("Please select a task in the grid first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AbstractTask task = LinearSearch(allTasks, selectedId.Value);
            if (task == null)
            {
                MessageBox.Show($"Task with ID {selectedId} no longer exists.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (task.SubTasks.Count > 0)
            {
                MessageBox.Show($"Cannot delete Task {selectedId} because it still has {task.SubTasks.Count} Direct Subtask(s). Remove or reassign them first.", "Deletion Blocked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            allTasks.Remove(task);

            if (task.ParentId != null)
            {
                AbstractTask parent = LinearSearch(allTasks, task.ParentId.Value);
                if (parent != null)
                {
                    parent.SubTasks.Remove(task);
                }
            }

            Queue<AbstractTask> newQueue = new Queue<AbstractTask>();
            while (nextTasksQueue.Count > 0)
            {
                AbstractTask qTask = nextTasksQueue.Dequeue();
                if (qTask != task)
                    newQueue.Enqueue(qTask);
            }
            nextTasksQueue = newQueue;

            RefreshTaskGrid();
            MessageBox.Show($"Task ID {selectedId} has been completed!", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int? GetSelectedTaskId()
        {
            if (dgvTasks.SelectedRows.Count == 0)
                return null;

            DataGridViewRow row = dgvTasks.SelectedRows[0];
            if (row.Cells["TaskId"].Value == null)
                return null;

            return Convert.ToInt32(row.Cells["TaskId"].Value);
        }

        private void btnCalcWorkload_Click(object sender, EventArgs e)
        {
            int searchId;
            if (!int.TryParse(txtSearchId.Text.Trim(), out searchId))
            {
                MessageBox.Show("Please enter a valid numeric Task ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AbstractTask found = LinearSearch(allTasks, searchId);
            if (found == null)
            {
                MessageBox.Show($"Task with ID {searchId} not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int workload = CountAllSubTasks(found);
            string details = $"Task ID: {found.Id}\n" +
                             $"Title: {found.Title}\n" +
                             $"Priority: {found.Priority}\n" +
                             $"Level: {(found.ParentId == null ? "Parent" : "Subtask")}\n" +
                             $"Direct Subtasks: {found.SubTasks.Count}\n" +
                             $"Total Nested Subtasks (Workload): {workload}";
            MessageBox.Show(details, "Workload Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCountSubTasks_Click(object sender, EventArgs e)
        {
            int searchId;
            if (!int.TryParse(txtSearchId.Text.Trim(), out searchId))
            {
                MessageBox.Show("Please enter a valid numeric Task ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AbstractTask task = LinearSearch(allTasks, searchId);
            if (task == null)
            {
                MessageBox.Show($"Task with ID {searchId} not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int count = CountAllSubTasks(task);
            string details = $"Task ID: {task.Id}\n" +
                             $"Title: {task.Title}\n" +
                             $"Priority: {task.Priority}\n" +
                             $"Level: {(task.ParentId == null ? "Parent" : "Subtask")}\n" +
                             $"Direct Subtasks: {task.SubTasks.Count}\n" +
                             $"Total Subtasks (All Levels): {count}";
            MessageBox.Show(details, "Recursive Subtask Count", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private AbstractTask LinearSearch(List<AbstractTask> tasks, int targetId)
        {
            foreach (var task in tasks)
            {
                if (task.Id == targetId)
                    return task;
            }
            return null;
        }

        private int CalculateTotalWorkload(List<AbstractTask> tasks, int taskId)
        {
            AbstractTask found = LinearSearch(tasks, taskId);
            if (found == null)
                return -1;
            return CountAllSubTasks(found);
        }

        private int CountAllSubTasks(AbstractTask task)
        {
            if (task.SubTasks == null || task.SubTasks.Count == 0)
                return 0;

            int count = 0;
            foreach (var sub in task.SubTasks)
            {
                count += 1 + CountAllSubTasks(sub);
            }
            return count;
        }

        private void ClearInputs()
        {
            txtTitle.Clear();
            numPriority.Value = 1;
            txtParentId.Text = "0";
        }

        private void SetupTaskGrid()
        {
            dgvTasks.Columns.Clear();
            dgvTasks.Columns.Add("TaskId", "Task ID");
            dgvTasks.Columns.Add("Level", "Level");
            dgvTasks.Columns.Add("ParentId", "Parent ID");
            dgvTasks.Columns.Add("Title", "Task Title");
            dgvTasks.Columns.Add("Priority", "Priority Level");
            dgvTasks.Columns.Add("SubtaskCount", "Subtasks");

            dgvTasks.Columns["TaskId"].Width = 60;
            dgvTasks.Columns["Level"].Width = 70;
            dgvTasks.Columns["ParentId"].Width = 70;
            dgvTasks.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTasks.Columns["Priority"].Width = 80;
            dgvTasks.Columns["SubtaskCount"].Width = 80;
        }

        private void RefreshTaskGrid()
        {
            dgvTasks.Rows.Clear();
            foreach (var task in allTasks)
            {
                string level = task.ParentId == null ? "Parent" : "Subtask";
                string parentIdDisplay = task.ParentId == null ? task.Id.ToString() : task.ParentId.Value.ToString();
                int subtaskCount = task.SubTasks.Count;

                dgvTasks.Rows.Add(task.Id, level, parentIdDisplay, task.Title, task.Priority, subtaskCount);
            }
        }

        private void dgvTasks_SelectionChanged(object sender, EventArgs e)
        {
            int? selectedId = GetSelectedTaskId();
            if (selectedId.HasValue)
            {
                txtSearchId.Text = selectedId.Value.ToString();
            }
            else
            {
                txtSearchId.Clear();
            }
        }
    }
}