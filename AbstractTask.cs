using System;
using System.Collections.Generic;

namespace TaskManagementSystem
{
    public abstract class AbstractTask
    {
        private int id;
        private string title;
        private int priority;
        private List<AbstractTask> subTasks;


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

        public int? ParentId { get; set; }

        public AbstractTask(int id, string title, int priority)
        {
            this.id = id;
            this.title = title;

            Priority = priority;
            subTasks = new List<AbstractTask>();
            ParentId = null;
        }

        public abstract string GetTaskType();

        public string SetPriority(int level)
        {
            if (level >= 1 && level <= 5)
            {
                priority = level;
                return $"Priority set to {level}";
            }
            else
            {
                return "Error: Invalid Priority";
            }
        }
    }
}