// Program.cs
using Microsoft.Build.Utilities;
using System;
using TaskManagementSystem;
using TaskManagementSystem.TaskItems;

class Program
{
    static TaskManager taskManager = new TaskManager();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n1. Add Task");
            Console.WriteLine("2. List Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ListTasks();
                    break;
                case "3":
                    MarkTaskAsCompleted();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.WriteLine("Enter Task title: ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter due date (yyyy-MM-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
        {
            var task = new TodoTask { Title = title, DueDate = dueDate };
            taskManager.AddTask(task);
            Console.WriteLine("Task added successfully");
        }
        else
        {
            Console.WriteLine("Invalid date format. Task not added.");
        }
    }

    static void ListTasks()
    {
        var tasks = taskManager.GetAllTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found");
            return;
        }
        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Due: {task.DueDate.ToString()} Completed: {task.IsCompleted}");
        }
    }

    static void MarkTaskAsCompleted()
    {
        Console.Write("Enter task ID to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            taskManager.MarkTaskAsCompleted(id);
            Console.WriteLine("Task marked as completed (if it exists).");
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }
}