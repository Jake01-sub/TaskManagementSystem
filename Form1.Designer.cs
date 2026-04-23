namespace TaskManagementSystem
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtParentId = new TextBox();
            label4 = new Label();
            numPriority = new NumericUpDown();
            btnAddTask = new Button();
            label3 = new Label();
            label2 = new Label();
            txtTitle = new TextBox();
            groupBox2 = new GroupBox();
            label5 = new Label();
            txtSearchId = new TextBox();
            groupBox3 = new GroupBox();
            btnCountSubTasks = new Button();
            btnCalcWorkload = new Button();
            btnProcessNext = new Button();
            groupBox4 = new GroupBox();
            dgvTasks = new DataGridView();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numPriority).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-4, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1193, 77);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 45F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkBlue;
            label1.Location = new Point(250, 1);
            label1.Name = "label1";
            label1.Size = new Size(680, 75);
            label1.TabIndex = 0;
            label1.Text = "TASK MANAGEMENT SYSTEM";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtParentId);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(numPriority);
            groupBox1.Controls.Add(btnAddTask);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtTitle);
            groupBox1.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.DarkBlue;
            groupBox1.Location = new Point(12, 93);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(373, 276);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add New Task";
            // 
            // txtParentId
            // 
            txtParentId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtParentId.ForeColor = Color.DarkBlue;
            txtParentId.Location = new Point(254, 155);
            txtParentId.Name = "txtParentId";
            txtParentId.Size = new Size(96, 29);
            txtParentId.TabIndex = 7;
            txtParentId.Text = "0";
            txtParentId.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 157);
            label4.Name = "label4";
            label4.Size = new Size(225, 25);
            label4.TabIndex = 6;
            label4.Text = "Parent Task ID (0 = root):";
            // 
            // numPriority
            // 
            numPriority.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            numPriority.ForeColor = Color.DarkBlue;
            numPriority.Location = new Point(254, 112);
            numPriority.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numPriority.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numPriority.Name = "numPriority";
            numPriority.Size = new Size(96, 29);
            numPriority.TabIndex = 5;
            numPriority.TextAlign = HorizontalAlignment.Center;
            numPriority.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddTask
            // 
            btnAddTask.BackColor = Color.SkyBlue;
            btnAddTask.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            btnAddTask.FlatAppearance.MouseOverBackColor = Color.LightCyan;
            btnAddTask.FlatStyle = FlatStyle.Flat;
            btnAddTask.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTask.Location = new Point(23, 204);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(327, 42);
            btnAddTask.TabIndex = 4;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = false;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 114);
            label3.Name = "label3";
            label3.Size = new Size(134, 25);
            label3.TabIndex = 2;
            label3.Text = "Priority Level: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(23, 37);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 1;
            label2.Text = "Task Title:";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTitle.ForeColor = Color.DarkBlue;
            txtTitle.Location = new Point(23, 65);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(327, 29);
            txtTitle.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(txtSearchId);
            groupBox2.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.ForeColor = Color.DarkBlue;
            groupBox2.Location = new Point(12, 375);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(373, 117);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Search Task";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 37);
            label5.Name = "label5";
            label5.Size = new Size(166, 25);
            label5.TabIndex = 1;
            label5.Text = "Search by Task ID:";
            // 
            // txtSearchId
            // 
            txtSearchId.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtSearchId.ForeColor = Color.DarkBlue;
            txtSearchId.Location = new Point(23, 65);
            txtSearchId.Name = "txtSearchId";
            txtSearchId.Size = new Size(327, 29);
            txtSearchId.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnCountSubTasks);
            groupBox3.Controls.Add(btnCalcWorkload);
            groupBox3.Controls.Add(btnProcessNext);
            groupBox3.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.ForeColor = Color.DarkBlue;
            groupBox3.Location = new Point(12, 498);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(373, 218);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Task Actions";
            // 
            // btnCountSubTasks
            // 
            btnCountSubTasks.BackColor = Color.SkyBlue;
            btnCountSubTasks.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            btnCountSubTasks.FlatAppearance.MouseOverBackColor = Color.LightCyan;
            btnCountSubTasks.FlatStyle = FlatStyle.Flat;
            btnCountSubTasks.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCountSubTasks.Location = new Point(23, 153);
            btnCountSubTasks.Name = "btnCountSubTasks";
            btnCountSubTasks.Size = new Size(327, 42);
            btnCountSubTasks.TabIndex = 7;
            btnCountSubTasks.Text = "Count All SubTasks";
            btnCountSubTasks.UseVisualStyleBackColor = false;
            btnCountSubTasks.Click += btnCountSubTasks_Click;
            // 
            // btnCalcWorkload
            // 
            btnCalcWorkload.BackColor = Color.SkyBlue;
            btnCalcWorkload.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            btnCalcWorkload.FlatAppearance.MouseOverBackColor = Color.LightCyan;
            btnCalcWorkload.FlatStyle = FlatStyle.Flat;
            btnCalcWorkload.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalcWorkload.Location = new Point(23, 92);
            btnCalcWorkload.Name = "btnCalcWorkload";
            btnCalcWorkload.Size = new Size(327, 42);
            btnCalcWorkload.TabIndex = 6;
            btnCalcWorkload.Text = "Calculate Workload";
            btnCalcWorkload.UseVisualStyleBackColor = false;
            btnCalcWorkload.Click += btnCalcWorkload_Click;
            // 
            // btnProcessNext
            // 
            btnProcessNext.BackColor = Color.SkyBlue;
            btnProcessNext.FlatAppearance.MouseDownBackColor = Color.SteelBlue;
            btnProcessNext.FlatAppearance.MouseOverBackColor = Color.LightCyan;
            btnProcessNext.FlatStyle = FlatStyle.Flat;
            btnProcessNext.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProcessNext.Location = new Point(23, 32);
            btnProcessNext.Name = "btnProcessNext";
            btnProcessNext.Size = new Size(327, 42);
            btnProcessNext.TabIndex = 5;
            btnProcessNext.Text = "Process Next Task";
            btnProcessNext.UseVisualStyleBackColor = false;
            btnProcessNext.Click += btnProcessNext_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dgvTasks);
            groupBox4.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.ForeColor = Color.DarkBlue;
            groupBox4.Location = new Point(407, 93);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(765, 623);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "All Tasks";
            // 
            // dgvTasks
            // 
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTasks.BackgroundColor = Color.SkyBlue;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.LightCyan;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.LightCyan;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.DarkBlue;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTasks.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTasks.Location = new Point(19, 37);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.ReadOnly = true;
            dgvTasks.Size = new Size(723, 563);
            dgvTasks.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1184, 731);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Task Management System";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numPriority).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private GroupBox groupBox1;
        private Label label2;
        private TextBox txtTitle;
        private Label label3;
        private Button btnAddTask;
        private GroupBox groupBox2;
        private Button button1;
        private ComboBox comboBox2;
        private Label label5;
        private TextBox txtSearchId;
        private NumericUpDown numPriority;
        private TextBox txtParentId;
        private Label label4;
        private GroupBox groupBox3;
        private Button btnCalcWorkload;
        private Button btnProcessNext;
        private Button btnCountSubTasks;
        private GroupBox groupBox4;
        private DataGridView dgvTasks;
    }
}
