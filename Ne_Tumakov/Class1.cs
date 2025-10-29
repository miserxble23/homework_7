using System;
using System.Collections.Generic;
namespace Class1
{
    public class Company
    {
        public Dictionary<string, string> Employees { get; private set; }
        public Dictionary<string, List<string>> Hierarchy { get; private set; }
        public List<(string from, string to, string task, string type)> Tasks { get; private set; }// { get; private set; } можно читать извне, но устанавливать значение только внутри класса
        public Company() //конструктор 
        {
            Employees = new Dictionary<string, string>(); //должность
            Hierarchy = new Dictionary<string, List<string>>();
            Tasks = new List<(string from, string to, string task, string type)>();// список задач

            InitializeEmployees(); //Создает пустой список для задач
            InitializeHierarchy();
            InitializeTasks(); 
        }
        private void InitializeEmployees()
        {
            Employees.Add("Тимур", "директор");
            Employees.Add("Рашид", "финдир");
            Employees.Add("Ильхам", "дир автоматизации");
            Employees.Add("Лукас", "главбух");
            Employees.Add("Оркадий", "начальник ИТ");
            Employees.Add("Володя", "зам ИТ");
            Employees.Add("Ильшат", "главный системщик");
            Employees.Add("Иваныч", "зам системщика");
            Employees.Add("Илья", "системщик");
            Employees.Add("Витя", "системщик");
            Employees.Add("Сергей", "главный разработчик");
            Employees.Add("Ляйсан", "зам разработчика");
            Employees.Add("Марат", "разработчик");
            Employees.Add("Дина", "разработчик");
        }
        private void InitializeHierarchy()
        {
            Hierarchy.Add("Тимур", new List<string> { "Рашид", "Ильхам" });
            Hierarchy.Add("Рашид", new List<string> { "Лукас" });
            Hierarchy.Add("Ильхам", new List<string> { "Оркадий", "Володя" });
            Hierarchy.Add("Оркадий", new List<string> { "Ильшат", "Сергей" });
            Hierarchy.Add("Володя", new List<string> { "Ильшат", "Сергей" });
            Hierarchy.Add("Ильшат", new List<string> { "Иваныч" });
            Hierarchy.Add("Иваныч", new List<string> { "Илья", "Витя" });
            Hierarchy.Add("Сергей", new List<string> { "Ляйсан" });
            Hierarchy.Add("Ляйсан", new List<string> { "Марат", "Дина" });
        }
        private void InitializeTasks()
        {
            Tasks.Add(("Тимур", "Илья", "Настроить сеть", "системщикам"));
            Tasks.Add(("Рашид", "Лукас", "Свести отчет", "бухгалтерии"));
            Tasks.Add(("Ильхам", "Сергей", "Сделать программу", "разработчикам"));
            Tasks.Add(("Оркадий", "Володя", "Провести собрание", "начальству"));
            Tasks.Add(("Ильшат", "Илья", "Починить сервер", "системщикам"));
            Tasks.Add(("Сергей", "Дина", "Написать код", "разработчикам"));
            Tasks.Add(("Илья", "Сергей", "Сделать фичу", "разработчикам"));
            Tasks.Add(("Дина", "Иваныч", "Настроить вайфай", "системщикам"));
        }
    }

    public class TaskManager // конструктор
    {
        private Company company1;

        public TaskManager(Company company)
        {
            company1 = company;
        }
        public bool CanAssignTask(string from, string to, string type)
        {
            return CheckTaskType(to, type) && CheckHierarchy(from, to);
        }
        private bool CheckTaskType(string to, string taskType)
        {
            string position = company1.Employees[to];
            return (taskType == "системщикам" && position.Contains("систем")) ||
                   (taskType == "разработчикам" && position.Contains("разработ")) ||
                   (taskType == "бухгалтерии" && position.Contains("бух")) ||
                   (taskType == "начальству" && (position.Contains("начальник") || position.Contains("зам")));
        }
        private bool CheckHierarchy(string from, string to)
        {
            if (from == "Тимур") return true;

            return company1.Hierarchy.ContainsKey(from) && //проверяет существует ли начальник в иерархии
                   company1.Hierarchy[from].Contains(to); //проверяет есть ли сотрудник to в списке подчиненных from
        }
    }
}
