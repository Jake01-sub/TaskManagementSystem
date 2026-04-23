namespace TaskManagementSystem
{
    public class ProjectTask : AbstractTask
    {
        public ProjectTask(int id, string title, int priority)
            : base(id, title, priority)
        {
        }

        public override string GetTaskType()
        {
            return "Project Task";
        }
    }
}