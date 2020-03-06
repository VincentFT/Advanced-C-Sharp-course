using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Company.Classes
{
    class DataBase
    {
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

        private ObservableCollection<Department> departments = new ObservableCollection<Department>();

        public event Action updateData;

        public int emlCount { get; set; } = 20;

        public int depCount { get; set; } = 5;

        Random rand = new Random();

        /// <summary>Конструктор данных</summary>
        public DataBase()
        {
            CreateDep();
            CreateEmpl();
        }

       /// <summary>Создаёт список департаметов</summary>
        public void CreateDep()
        {
            for (int i = 0; i < depCount; i++)
                departments.Add(new Department("Our_Department_" + i));
        }

        /// <summary>Создаёт список сотрудников</summary>
        public void CreateEmpl()
        {
            for (int i = 0; i < emlCount; i++)
            {
                employees.Add(new Employee(
                    "Name_" + i, "Surname_" + i, (uint)rand.Next(18, 90), 
                    rand.Next(35000, 499999),
                    departments[rand.Next(0, depCount)].Name)
                    );
            }
        }

        /// <summary>Возвращает список сотрудников</summary>
        /// <returns></returns>
        public IEnumerable GetEmployees()
        {
            return employees;
        }

        /// <summary>Возвращает список департаментов</summary>
        /// <returns></returns>
        public IEnumerable GetDeptaments()
        {
            return departments;
        }

        /// <summary>Взвращает информацию об объекте</summary>
        /// <param name="sender">Объект</param>
        /// <returns></returns>
        public string GetInfo(object sender)
        {
            if ((sender is ListBox) && (sender as ListBox).SelectedItem is Employee)
            {
                Employee lbi = ((sender as ListBox).SelectedItem as Employee);
                return lbi.GetInfo();
            }
            else if ((sender is ComboBox) && (sender as ComboBox).SelectedItem is Department)
            {
                Department cbi = ((sender as ComboBox).SelectedItem as Department);
                
                string result = cbi.GetEmployees(cbi.Name, employees);

                return result;
            }
            else
                return "";

        }

        /// <summary>Добавляет отдел. Возвращает истину, если добавлен</summary>
        /// <param name="text">Название отдела</param>
        /// <returns></returns>
        internal bool addDep(string text)
        {
            Department newDep = new Department(text);
            if (!departments.Contains(newDep))
            {
                departments.Add(newDep);
                updateData?.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Добавляет сотрудника. Возвращает истину, если добавлен</summary>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="dep">Название отдела</param>
        /// <returns></returns>
        internal bool addEmp(string name, string surname, string age, string salary, string dep)
        {
            if(name.Any(char.IsDigit) || surname.Any(char.IsDigit))
                return false;
            uint intAge = 0;
            if (!uint.TryParse(age, out intAge))
                return false;
            decimal decSal = 0M;
            if (!decimal.TryParse(salary, out decSal))
                return false;

            Employee newEmp = new Employee(name, surname, intAge, decSal, dep);

            if (!employees.Contains(newEmp))
            {
                employees.Add(newEmp);
                updateData?.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Изменяет данные об отделе. Возвращает истину в случае успеха</summary>
        /// <param name="newname">Новое название</param>
        /// <param name="oldname">Старое название</param>
        /// <returns></returns>
        internal bool editDep(string newname, string oldname)
        {
            Department editDep = new Department(newname);
            if (!departments.Contains(editDep))
            {
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i].Name == oldname)
                    {
                        departments.RemoveAt(i);
                        departments.Insert(i, editDep);
                        updateEmpData(newname, oldname);
                    }
                }

                updateData?.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Изменяет данные сотрудника. Возвращает истину в случае успеха</summary>
        /// <param name="old">Старые данные о сотруднике</param>
        /// <param name="name">Новое имя</param>
        /// <param name="surname">Новая фамилия</param>
        /// <param name="age">Новый возраст</param>
        /// <param name="salary">Новая зарплата</param>
        /// <param name="dep">Новый отдел</param>
        /// <returns></returns>
        internal bool editEmp(Employee old, string name, string surname, string age, string salary, string dep)
        {
            if (name.Any(char.IsDigit) || surname.Any(char.IsDigit))
                return false;
            uint intAge = 0;
            if (!uint.TryParse(age, out intAge))
                return false;
            decimal decSal = 0M;
            if (!decimal.TryParse(salary, out decSal))
                return false;
            if (!checkDep(dep))
                return false;

            Employee editmp = new Employee(name, surname, intAge, decSal, dep);

            if (!employees.Contains(editmp))
            {
                for (int i = 0; i < departments.Count; i++)
                {
                    if (employees[i].Equals(old))
                    {
                        employees.RemoveAt(i);
                        employees.Insert(i, editmp);
                    }
                }
                updateData?.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>Проверяет есть существует ли такой отдел</summary>
        /// <param name="dep">Название отдела</param>
        /// <returns></returns>
        private bool checkDep(string dep)
        {
            foreach (var depart in departments)
            {
                if (depart.Name == dep)
                    return true;
            }
            return false;
        }

        /// <summary>Изменяет данные об отделе у сотрудников</summary>
        /// <param name="newname">Новое название отдела</param>
        /// <param name="oldname">Сатрое название отдела</param>
        private void updateEmpData(string newname, string oldname)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Department == oldname)
                    employees[i].Department = newname;
            }
        }
    }
}
