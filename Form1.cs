using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TaskManagementSystem
{
    public partial class Form1 : Form
    {
        // Static counter for unique task IDs
        private static int nextId = 1;

        // The flat list of all tasks – used for linear search
        private List<AbstractTask> allTasks = new List<AbstractTask>();

        // Queue for "Next Tasks" – they must be completed in the exact order they were added.
        private Queue<AbstractTask> nextTasksQueue = new Queue<AbstractTask>();

        public Form1()
        {
            InitializeComponent();
            // Set up the DataGridView columns (we'll do it once, not every refresh)
            SetupTaskGrid();
        }

        // ------------------------------------------------------------
        // Button: Add a root task or a subtask
        // ------------------------------------------------------------
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtTitle.Text.Trim();
                if (string.IsNullOrEmpty(title))
                {
                    AppendOutput("Error: Title cannot be empty.");
                    return;
                }

                int priority = (int)numPriority.Value;  // NumericUpDown ensures 1-5
                int parentId;
                if (!int.TryParse(txtParentId.Text.Trim(), out parentId))
                {
                    AppendOutput("Error: Invalid Parent ID. Use 0 for a root task.");
                    return;
                }

                // Create the new task (ParentId initially null)
                AbstractTask newTask = new ProjectTask(nextId++, title, priority);

                if (parentId == 0)
                {
                    // Root task: ParentId remains null
                    allTasks.Add(newTask);
                    nextTasksQueue.Enqueue(newTask);
                    AppendOutput($"Root task added: ID={newTask.Id}, Title={newTask.Title}");
                }
                else
                {
                    // Find parent by linear search in allTasks
                    AbstractTask parent = LinearSearch(allTasks, parentId);
                    if (parent == null)
                    {
                        AppendOutput($"Error: Parent task with ID {parentId} not found.");
                        return;
                    }
                    parent.SubTasks.Add(newTask);
                    allTasks.Add(newTask);
                    // Set the ParentId of the new subtask
                    newTask.ParentId = parent.Id;
                    AppendOutput($"Subtask added under Parent ID {parentId}: ID={newTask.Id}, Title={newTask.Title}");
                }

                // Refresh the grid to show updated list
                RefreshTaskGrid();

                // Clear input fields for next entry
                ClearInputs();
            }
            catch (Exception ex)
            {
                AppendOutput($"Error: {ex.Message}");
            }
        }

        // ------------------------------------------------------------
        // Button: Process the next task from the queue (FIFO)
        // ------------------------------------------------------------
        private void btnProcessNext_Click(object sender, EventArgs e)
        {
            if (nextTasksQueue.Count == 0)
            {
                AppendOutput("No tasks in the queue.");
                return;
            }

            AbstractTask next = nextTasksQueue.Dequeue();
            AppendOutput($"Processed next task: ID={next.Id}, Title={next.Title}");

            // Optionally, remove from allTasks? The requirement is vague.
            // For now we only dequeue, the task still exists in the system.
            // You could remove it from allTasks if needed, but then the grid
            // would lose it. Usually a "process" might just mark it complete.
            RefreshTaskGrid();
        }

        // ------------------------------------------------------------
        // Button: Calculate Workload (linear search + recursive count)
        // ------------------------------------------------------------
        private void btnCalcWorkload_Click(object sender, EventArgs e)
        {
            int searchId;
            if (!int.TryParse(txtSearchId.Text.Trim(), out searchId))
            {
                AppendOutput("Error: Please enter a valid numeric Task ID.");
                return;
            }

            int workload = CalculateTotalWorkload(allTasks, searchId);
            AppendOutput($"Total workload (nested subtasks) for Task ID {searchId}: {workload}");
        }

        // ------------------------------------------------------------
        // Button: Count all subtasks recursively for a given task ID
        // ------------------------------------------------------------
        private void btnCountSubTasks_Click(object sender, EventArgs e)
        {
            int searchId;
            if (!int.TryParse(txtSearchId.Text.Trim(), out searchId))
            {
                AppendOutput("Error: Please enter a valid numeric Task ID.");
                return;
            }

            AbstractTask task = LinearSearch(allTasks, searchId);
            if (task == null)
            {
                AppendOutput($"Task with ID {searchId} not found.");
                return;
            }

            int count = CountAllSubTasks(task);
            AppendOutput($"Recursive subtask count for Task ID {searchId}: {count}");
        }

        // ------------------------------------------------------------
        // REQUIRED METHOD 1: Linear search inside a List<Task>
        // ------------------------------------------------------------
        private AbstractTask LinearSearch(List<AbstractTask> tasks, int targetId)
        {
            foreach (var task in tasks)
            {
                if (task.Id == targetId)
                    return task;
            }
            return null;
        }

        // ------------------------------------------------------------
        // REQUIRED METHOD 2: Calculate total workload
        // ------------------------------------------------------------
        private int CalculateTotalWorkload(List<AbstractTask> tasks, int taskId)
        {
            AbstractTask found = LinearSearch(tasks, taskId);
            if (found == null)
                return -1;

            return CountAllSubTasks(found);
        }

        // ------------------------------------------------------------
        // REQUIRED RECURSIVE FUNCTION: Count all sub-tasks at every level
        // ------------------------------------------------------------
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

        // ------------------------------------------------------------
        // NEW: Clear all input controls
        // ------------------------------------------------------------
        private void ClearInputs()
        {
            txtTitle.Clear();
            numPriority.Value = 1;
            txtParentId.Text = "0";
        }

        // ------------------------------------------------------------
        // NEW: Set up columns for the DataGridView (called once)
        // ------------------------------------------------------------
        private void SetupTaskGrid()
        {
            dgvTasks.Columns.Clear();
            dgvTasks.Columns.Add("TaskId", "Task ID");
            dgvTasks.Columns.Add("Level", "Level");
            dgvTasks.Columns.Add("ParentId", "Parent ID");
            dgvTasks.Columns.Add("Title", "Task Title");
            dgvTasks.Columns.Add("Priority", "Priority Level");
            dgvTasks.Columns.Add("SubtaskCount", "Subtasks");

            // Optionally adjust column widths
            dgvTasks.Columns["TaskId"].Width = 60;
            dgvTasks.Columns["Level"].Width = 70;
            dgvTasks.Columns["ParentId"].Width = 70;
            dgvTasks.Columns["Title"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTasks.Columns["Priority"].Width = 80;
            dgvTasks.Columns["SubtaskCount"].Width = 80;
        }

        // ------------------------------------------------------------
        // NEW: Refresh the DataGridView with current task list
        // ------------------------------------------------------------
        private void RefreshTaskGrid()
        {
            dgvTasks.Rows.Clear();
            foreach (var task in allTasks)
            {
                string level = task.ParentId == null ? "Parent" : "Subtask";
                string parentIdDisplay;
                if (task.ParentId == null)
                    parentIdDisplay = task.Id.ToString();   // For root, show its own ID
                else
                    parentIdDisplay = task.ParentId.Value.ToString();

                int subtaskCount = task.SubTasks.Count;

                dgvTasks.Rows.Add(
                    task.Id,
                    level,
                    parentIdDisplay,
                    task.Title,
                    task.Priority,
                    subtaskCount
                );
            }
        }

        // ------------------------------------------------------------
        // Helper: Write to the output TextBox (if it exists)
        // ------------------------------------------------------------
        private void AppendOutput(string message)
        {
            if (txtOutput != null)
                txtOutput.AppendText(message + Environment.NewLine);
        }
    }
}