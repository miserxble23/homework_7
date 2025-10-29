using Enums;
using System;
using System.Security.AccessControl;
namespace Class_1num
{
    public class BankAccount1
    {
        // Статическая переменная для генерации уникального номера счета
        private static int nextAccNumber1 = 100;
        private string accountNumber1 = "";
        private decimal balance1 = 0m;
        private AccType accountType1 = AccType.Tekushchiy;

        // Конструктор, который генерирует номер счета
        public BankAccount1()
        {
            accountNumber1 = GenerateAccountNumber1();
        }

        // Метод для генерации уникального номера счета
        private string GenerateAccountNumber1()
        {
            string newNumber = nextAccNumber1.ToString();
            nextAccNumber1++;
            return newNumber;
        }

        public void SetBalance1(decimal sum)
        {
            balance1 = sum;
        }

        public void SetAccountType1(AccType type)
        {
            accountType1 = type;
        }

        public string GetAccountNumber1()
        {
            return accountNumber1;
        }

        public decimal GetBalance1()
        {
            return balance1;
        }

        public AccType GetAccountType1()
        {
            return accountType1;
        }

        public void Polojit(decimal sum)
        {
            if (sum > 0)
            {
                balance1 += sum;
                Console.WriteLine($"Счет пополнен на {sum} руб. Новый баланс: {balance1} руб.");
            }
            else
            {
                Console.WriteLine("Сумма пополнения должна быть положительной!");
            }
        }

        public void Cnyat(decimal sum)
        {
            if (sum > 0 && sum <= balance1)
            {
                balance1 -= sum;
                Console.WriteLine($"Со счета снято {sum} руб. Новый баланс: {balance1} руб.");
            }
            else
            {
                Console.WriteLine("Недостаточно средств!");
            }
        }

        // Метод для перевода денег между счетами
        public void Perevesti(BankAccount1 targetAccount, decimal sum)
        {
            if (targetAccount == null)
            {
                Console.WriteLine("Ошибка: целевой счет не существует!");
                return;
            }

            if (sum <= 0)
            {
                Console.WriteLine("Сумма перевода должна быть положительной!");
                return;
            }

            if (sum > balance1)
            {
                Console.WriteLine($"Недостаточно средств для перевода! Доступно: {balance1} руб., запрошено: {sum} руб.");
                return;
            }

            // Снимаем деньги с текущего счета
            balance1 -= sum;

            // Кладем деньги на целевой счет
            targetAccount.balance1 += sum;

            Console.WriteLine($"Успешно переведено {sum} руб. со счета {accountNumber1} на счет {targetAccount.GetAccountNumber1()}");
            Console.WriteLine($"Ваш новый баланс: {balance1} руб.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Информация о вашем счете");
            Console.WriteLine($"Номер счета: {accountNumber1}");
            Console.WriteLine($"Баланс: {balance1} рублей.");
            Console.WriteLine($"Тип счета: {accountType1}");
        }
        public void DisplayInfo1()
        {
            Console.WriteLine("Информация о другом счете");
            Console.WriteLine($"Номер счета: {accountNumber1}");
            Console.WriteLine($"Баланс: {balance1} рублей.");
            Console.WriteLine($"Тип счета: {accountType1}");
        }
    }
}

