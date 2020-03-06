using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Classes
{
    class Department : IEquatable<Department>
    {
        public string Name { get; set; }

        /// <summary>Инициализирует отдел</summary>
        /// <param name="name">Название</param>
        public Department(string name)
        {
            Name = name;
        }

        /// <summary>Возвращает название отдела </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}";
        }

        /// <summary>Возвращает информацию о всех сотрудниках в отделе</summary>
        /// <param name="name">Название отдела</param>
        /// <param name="list">Список всех сотрудников</param>
        /// <returns></returns>
        internal string GetEmployees(string name, ObservableCollection<Employee> list)
        {
            var request = from e
                         in list
                         where e.Department == Name
                         select e;

            string result = String.Empty;

            foreach (Employee item in request)
            {
                result += $"{item.Name} {item.Surname}, возраст: {item.Age}, зарплата: {item.Salary}, отдел: {item.Department}\n";
            }

            return result;
        }

        /// <summary>Метод сравнения отдела с другим</summary>
        /// <param name="another">Слово типа Dictionary для сравнения</param>
        /// <returns></returns>
        public bool Equals(Department another)
        {
            if (this.Name == another.Name)
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
