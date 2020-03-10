using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Company.Classes;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Company.Windows
{
    
    public partial class AddDepWindow : Window
    {

        public AddDepWindow()
        {
            InitializeComponent();
        }

        /// <summary>Обработчик нажатия кнопки "сохранить"</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSaveDep_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.db.addDep(tboxNewDep.Text))
            {
                MessageBox.Show("Отдел добавлен!");
                this.Close();
            }
            else
                MessageBox.Show("Такой отдел уже существует!");
        }
    }
}
