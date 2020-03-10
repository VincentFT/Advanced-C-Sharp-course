using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Classes
{
    class Employee : IEquatable<Employee>, INotifyPropertyChanged
    {
        string employeeName;
        public string Name
        {
            get { return this.employeeName; }
            set
            {
                this.employeeName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Name)));
            }
        }
        public string Surname { get; set; }
        public uint Age { get; set; }
        public decimal Salary { get; set; }
        public uint DepartmentID { get; set; }

        /// <summary>Инициализирует сотрудника</summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="department">Отдел</param>
        public Employee(string name, string surname, uint age, decimal salary, uint depid)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            DepartmentID = depid;
        }

        public event PropertyChangedEventHandler PropertyChanged;
                
        /// <summary>Возвращает всю информацию о сотруднике</summary>
        /// <returns></returns>
        public string GetInfo()
        {
            return $"Имя: {Name}\nФамилия: {Surname}\nВозраст: {Age}\nЗарплата: {Salary}\n" +
                $"Отдел: {GetDepartmentName(MainWindow.db.GetDeptaments() as ObservableCollection<Department>)}\n";
        }

        /// <summary>Метод сравнения сотрудника с другим</summary>
        /// <param name="another">Слово типа Dictionary для сравнения</param>
        /// <returns></returns>
        public bool Equals(Employee another)
        {
            if (this.Name == another.Name && this.Surname == another.Surname && this.Age == another.Age &&
                this.DepartmentID == another.DepartmentID && this.Salary == another.Salary)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Возвращает название отдела</summary>
        /// <param name="list">Список всех отделов</param>
        /// <returns></returns>
        internal string GetDepartmentName(ObservableCollection<Department> list)
        {
            var request = from e
                          in list
                          where e.DepartmentID == DepartmentID
                          select e;

            string result = (request.ElementAt(0)).Name;

            return result;
        }
    }
}
