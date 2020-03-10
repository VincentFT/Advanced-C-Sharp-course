using Company.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Company
{

    public partial class EmpEditWindow : Window
    {
        Employee oldemp;
        internal EmpEditWindow(Employee employee)
        {
            InitializeComponent();
            oldemp = employee;
            tboxName.Text = employee.Name;
            tboxSurname.Text = employee.Surname;
            tboxAge.Text = employee.Age.ToString();
            tboxSalary.Text = employee.Salary.ToString();
            tboxDep.Text = employee.DepartmentID.ToString();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.db.editEmp(oldemp, tboxName.Text, tboxSurname.Text, tboxAge.Text, tboxSalary.Text, uint.Parse(tboxDep.Text)))
            {
                MessageBox.Show("Данные о сотруднике изменены!");
                this.Close();
            }
            else
                MessageBox.Show("Такой сотрудник уже существует или введены некоректные данные!");
        }
    }
}
