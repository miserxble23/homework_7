using System;
using Class1;
namespace Ne_Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем компанию с данными
            var company = new Company();
            var taskManager = new TaskManager(company);
            Console.WriteLine("СИСТЕМА РАСПРЕДЕЛЕНИЯ ЗАДАЧ\n");
            // Проверяем все задачи
            foreach (var task in company.Tasks)
            {
                Console.WriteLine($"{task.from} - {task.to}: {task.task}");

                bool canAssign = taskManager.CanAssignTask(task.from, task.to, task.type);

                if (canAssign)
                    Console.WriteLine($" {task.to} берет задачу\n");
                else
                    Console.WriteLine($" {task.to} отказывается");
            }
        }
    }
}
