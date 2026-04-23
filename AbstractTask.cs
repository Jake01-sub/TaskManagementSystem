using System;
using System.Collections.Generic;

namespace TaskManagementSystem
{
    public abstract class AbstractTask
    {
        // Private fields (encapsulation)
        private int id;
        private string title;
        private int priority;    // 1 to 5
        private List<AbstractTask> subTasks;

        // Public properties
        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public int Priority
        {
            get => priority;
            set
            {
                if (value >= 1 && value <= 5)
                    priority = value;
                else
                    throw new ArgumentException("Priority must be between 1 and 5.");
            }
        }
        public List<AbstractTask> SubTasks { get => subTasks; set => subTasks = value; }

        // NEW: Nullable Parent ID – null for root tasks, else the parent's ID
        public int? ParentId { get; set; }

        // Constructor
        public AbstractTask(int id, string title, int priority)
        {
            this.id = id;
            this.title = title;
            // Use the property to enforce validation
            Priority = priority;
            subTasks = new List<AbstractTask>();
            ParentId = null;   // by default, assume root
        }

        // Abstract method – to be implemented by concrete classes
        public abstract string GetTaskType();
    }
}