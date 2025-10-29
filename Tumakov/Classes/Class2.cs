using System;
using System.Text;
namespace Class_2num
{
    class Program
    {
        public static class StringHelper // ReverseString должен быть объявлен, без этой строки не работает
        {
            public static string ReverseString(string input) //static означает, что метод принадлежит классу, а не конкретному объекту, можно вызывать без создания экземпляра класса
            {
                if (string.IsNullOrEmpty(input))
                    return input; //возвращает строку обратно в место вызова
                StringBuilder reversed = new StringBuilder(input.Length);
                for (int i = input.Length - 1; i >= 0; i--) //input.Length - 1 - индекс последнего символа
                {
                    reversed.Append(input[i]); //добавляем символ в StringBuilder
                }
                return reversed.ToString(); //возвращает перевернутую строку обратно в место вызова
            }
        }
    }
}
