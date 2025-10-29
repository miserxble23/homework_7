using Class_1num;
using Class_2num;
using Enums;
using System;
using System.IO;
using System.Text;
using static Class_2num.Program;
namespace Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("№1");
            Console.WriteLine();
            // Создаем два счета
            var account1 = new BankAccount1();
            account1.SetBalance1(11111m);
            account1.SetAccountType1(AccType.Tekushchiy);

            var account2 = new BankAccount1();
            account2.SetBalance1(7777m);
            account2.SetAccountType1(AccType.Sberegatelnyy);

            Console.WriteLine("До перевода:");
            account1.DisplayInfo();
            account2.DisplayInfo1();

            // Переводим 3000 руб. с account1 на account2
            account1.Perevesti(account2, 3000m);

            Console.WriteLine("\nПосле перевода:");
            account1.DisplayInfo();
            account2.DisplayInfo1();

            // Пытаемся перевести слишком большую сумму
            account1.Perevesti(account2, 10000m);
            Console.WriteLine();

            //2
            Console.WriteLine("№2");
            Console.WriteLine();
            Console.WriteLine("\nВведите строку для обращения:");
            Console.Write(">>> ");
            string userInput = Console.ReadLine();
            // Обрабатываем строку с помощью метода из класса StringHelper
            string reversed = StringHelper.ReverseString(userInput);

            // Выводим результат
            Console.WriteLine($"\nОригинал:  {userInput}");
            Console.WriteLine($"Результат: {reversed}");
            Console.WriteLine();
            //3
            Console.WriteLine("№3");
            Console.WriteLine();
            Console.Write("Введите имя файла: ");
            string fileName = Console.ReadLine();

            // Проверяем существование файла
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"ОШИБКА: Файл '{fileName}' не существует!");
                Console.WriteLine("Программа завершает работу.");
                return;
            }

            // Создаем имя для выходного файла
            string outputFileName = "UPPERCASE_" + fileName;
            try
            {
                // Читаем содержимое исходного файла
                string fileCoderjimoe = File.ReadAllText(fileName);

                // Преобразуем в заглавные буквы
                string uppercaseCoderjimoe = fileCoderjimoe.ToUpper();

                // Записываем в выходной файл
                File.WriteAllText(outputFileName, uppercaseCoderjimoe, Encoding.UTF8);// outputFileName - имя файла для сохранения, uppercaseCoderjimoe - текст который нужно записать,Encoding.UTF8 - кодировка файла

                Console.WriteLine($"УСПЕХ: Файл '{fileName}' обработан!");
                Console.WriteLine($"Результат сохранен в файл: '{outputFileName}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ОШИБКА при обработке файла: {ex.Message}");
            }
            Console.WriteLine();
            //4
            Console.WriteLine("№4");
            Console.WriteLine();
            Console.WriteLine("Не сделал");
            // dz1
            Console.WriteLine("№dz1");
            Console.WriteLine();
            Console.WriteLine("Не сделал");
            // dz2
            Console.WriteLine("№dz2");
            Console.WriteLine();
            Console.WriteLine("Не сделал");
        }
    }
}
