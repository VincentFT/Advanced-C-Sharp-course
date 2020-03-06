using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Classes
{
    class Employee : IEquatable<Employee>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public uint Age { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        /// <summary>Инициализирует сотрудника</summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="department">Отдел</param>
        public Employee(string name, string surname, uint age, decimal salary, string department)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            Department = department;
        }

        /// <summary>Возвращет имя и фамилию сотрудника</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

        /// <summary>Возвращает всю информацию о сотруднике</summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"Имя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\nЗарплата: {Salary}\nОтдел: {Department}";
        }

        /// <summary>Метод сравнения сотрудника с другим</summary>
        /// <param name="another">Слово типа Dictionary для сравнения</param>
        /// <returns></returns>
        public bool Equals(Employee another)
        {
            if (this.Name == another.Name && this.Surname == another.Surname && this.Age == another.Age &&
                this.Department == another.Department && this.Salary == another.Salary)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
