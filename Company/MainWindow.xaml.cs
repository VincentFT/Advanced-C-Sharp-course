using Company.Classes;
using Company.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Company
{
    // Алексей Петриленков

    //    Создать WPF-приложение для ведения списка сотрудников компании.

    //1. Создать сущности Employee и Department и заполнить списки сущностей начальными данными.

    //2. Для списка сотрудников и списка департаментов предусмотреть визуализацию (отображение).
    //    Это можно сделать, например, с использованием ComboBox или ListView.

    //3. Предусмотреть возможность редактирования сотрудников и департаментов. Должна быть возможность изменить департамент у сотрудника.
    //    Список департаментов для выбора можно выводить в ComboBox. Это все можно выводить на дополнительной форме.

    //4. Предусмотреть возможность создания новых сотрудников и департаментов.Реализовать данную возможность либо на форме редактирования,
    //    либо сделать новую форму





    public partial class MainWindow : Window
    {
        internal static DataBase db;
        public MainWindow()
        {
            InitializeComponent();
            db = new DataBase();
            empList.ItemsSource = db.GetEmployees();
            cbDepList.ItemsSource = db.GetDeptaments();
            db.updateData += Update;
        }

        /// <summary>Обработка события выбора элемента из списка</summary>
        /// <param name="sender">Объект</param>
        /// <param name="args">Параметры</param>
        private void Selected(object sender, SelectionChangedEventArgs args)
        {
            tbInfo.Text = db.GetInfo(sender);
        }

        /// <summary>Обработка нажатия кнопки "редактировать департамент"</summary>
        /// <param name="sender">Объект</param>
        /// <param name="args">Параметры</param>
        private void BtnEditDep_Click(object sender, RoutedEventArgs e)
        {
            if (cbDepList.SelectedItem != null)
            {
                DepEditWindow depEditWindow = new DepEditWindow(cbDepList.SelectedItem.ToString());
                depEditWindow.Owner = this;
                depEditWindow.Show();
            }
            else
                MessageBox.Show("Выберете департамент для редактирования!");
        }

        /// <summary>Обработка нажатия кнопки "редактировать сотрудника"</summary>
        /// <param name="sender">Объект</param>
        /// <param name="args">Параметры</param>
        private void BtnEditEmp_Click(object sender, RoutedEventArgs e)
        {
            if (empList.SelectedItem != null)
            {
                EmpEditWindow empEditWindow = new EmpEditWindow(empList.SelectedItem as Employee);
                empEditWindow.Owner = this;
                empEditWindow.Show();
            }
            else
                MessageBox.Show("Выберете сотрудника для редактирования!");
        }

        /// <summary>Обработка нажатия кнопки "добавить сотрудника"</summary>
        /// <param name="sender">Объект</param>
        /// <param name="args">Параметры</param>
        private void BtnCreateEmp_Click(object sender, RoutedEventArgs e)
        {
            AddEmpWindow addEmpWindow = new AddEmpWindow();
            addEmpWindow.Owner = this;
            addEmpWindow.Show();
        }

        /// <summary>Обработка нажатия кнопки "добавить департамент"</summary>
        /// <param name="sender">Объект</param>
        /// <param name="args">Параметры</param>
        private void BtnCreateDep_Click(object sender, RoutedEventArgs e)
        {
            AddDepWindow addDepWindow = new AddDepWindow();
            addDepWindow.Owner = this;
            addDepWindow.Show();
        }

        /// <summary>Обновляет данные на форме</summary>
        internal void Update()
        {
            empList.ItemsSource = db.GetEmployees();
            cbDepList.ItemsSource = db.GetDeptaments();
        }
    }
}
