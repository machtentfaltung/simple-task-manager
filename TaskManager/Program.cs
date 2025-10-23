// Simple Task Manager
// Copyright (C) 2024-2025 Matei Pralea <matei.pralea@proton.me>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using System.Globalization;

namespace TaskManager;

class Program
{
    static List<Task> _tasks = new List<Task>();

    static void Main(string[] args)
    {
        Console.Title = "Task Manager";
        while (true)
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Create a new task");
            Console.WriteLine("2. Delete a task");
            Console.WriteLine("3. List all tasks");
            Console.WriteLine("4. Mark task as complete");
            Console.WriteLine("5. Mark task as incomplete");
            Console.Write("Your choice: ");

            string? answer = Console.ReadLine();
            if (answer == null) continue;

            HandleCommand(answer);
        }
    }

    static void HandleCommand(string command)
    {
        switch (command)
        {
            case "1":
                CreateTask();
                break;
            case "2":
                if (_tasks.Count > 0)
                    DeleteTask();
                else
                {
                    Console.WriteLine("There are no tasks to delete.");
                    Thread.Sleep(1000);
                }
                break;
            case "3":
                if (_tasks.Count > 0)
                    ListTasks();
                else
                {
                    Console.WriteLine("There are no tasks to show.");
                    Thread.Sleep(1000);
                }
                break;
            case "4":
                if (_tasks.Count > 0)
                    MarkTaskAsComplete();
                else
                {
                    Console.WriteLine("There are no tasks to be marked as complete.");
                    Thread.Sleep(1000);
                }
                break;
            case "5":
                if (_tasks.Count > 0)
                    MarkTaskAsIncomplete();
                else
                {
                    Console.WriteLine("There are no tasks to be marked as incomplete.");
                    Thread.Sleep(1000);
                }
                break;
            default:
                Console.WriteLine("Unknown command");
                Thread.Sleep(1000);
                break;
        }
    }


    static void MarkTaskAsComplete()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter the task title: ");
            string? taskTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(taskTitle) || _tasks.Find(x => x.Title == taskTitle) == null)
            {
                Console.Clear();
                Console.Write("Task was not found.\nAvailable tasks: ");
                foreach (Task task in _tasks)
                    Console.WriteLine($"{task.Title}");
                Thread.Sleep(1000);
                continue;
            }
            _tasks.Find(x => x.Title == taskTitle)!.MarkComplete();
            Console.WriteLine("The task has been marked as complete.");
            Thread.Sleep(1000);
            break;
        }
    }
    
    static void MarkTaskAsIncomplete()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter the task title: ");
            string? taskTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(taskTitle) || _tasks.Find(x => x.Title == taskTitle) == null)
            {
                Console.Clear();
                Console.Write("Task was not found.\nAvailable tasks: ");
                foreach (Task task in _tasks)
                    Console.WriteLine($"{task.Title}");
                Thread.Sleep(1000);
                continue;
            }
            _tasks.Find(x => x.Title == taskTitle)!.MarkIncomplete();
            Console.WriteLine("The task has been marked as incomplete.");
            Thread.Sleep(1000);
            break;
        }
    }

    static void CreateTask()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter the task title: ");
            string? taskTitle = Console.ReadLine();
            if (taskTitle == null) continue;
            Console.Write("Enter the task description: ");
            string? taskDescription = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(taskDescription))
                taskDescription = null;
            var task = new Task(taskTitle, DateTime.Now, taskDescription);
            _tasks.Add(task);
            Console.WriteLine("The task has been created.");
            Thread.Sleep(1000);
            break;
        }
    }

    static void DeleteTask()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter the task title: ");
            string? taskTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(taskTitle) || _tasks.Find(x => x.Title == taskTitle) == null)
            {
                Console.Clear();
                Console.Write("Task was not found.\nAvailable tasks: ");
                foreach (Task task in _tasks)
                    Console.WriteLine($"{task.Title}");
                Thread.Sleep(1000);
                continue;
            }
            Task? taskToDelete = _tasks.Find(x => x.Title == taskTitle);
            _tasks.Remove(taskToDelete!);
            Console.WriteLine("The task has been deleted.");
            Thread.Sleep(1000);
            break;
        }
    }

    static void ListTasks()
    {
        Console.Clear();
        foreach (Task task in _tasks)
        {
            // string isCompleteString = task.IsComplete ? "complete" : "incomplete";
            Console.WriteLine($"Title: {task.Title}\nIs Complete: {task.IsComplete}\nDescription: {task.Description ?? "None"}\nCreation Date: {task.CreationDate.ToString(CultureInfo.CurrentCulture)}");
            Console.WriteLine("--------------------------");
        }
        Console.ReadKey();
    }
}