using Microsoft.Build.Utilities;
using System.Collections.Generic;
using System.Linq;
using TaskManagementSystem.TaskItems;

namespace TaskManagementSystem
{
    public class TaskManager
    {
        private List<TodoTask> tasks = new List<TodoTask>();

        public void AddTask(TodoTask task)
        {
            tasks.Add(task);
        }

        public List<TodoTask> GetAllTasks()
        {
            return tasks;
        }

        public void MarkTaskAsCompleted(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
        }
    }
}