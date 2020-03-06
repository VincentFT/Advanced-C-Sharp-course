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
    /// <summary>
    /// Interaction logic for DepEditWindow.xaml
    /// </summary>
    public partial class DepEditWindow : Window
    {

        public DepEditWindow(string oldName)
        {
            InitializeComponent();
            tblOldName.Text = oldName;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.db.editDep(tboxNewName.Text, tblOldName.Text))
            {
                MessageBox.Show("Название отдела изменено!");
                this.Close();
            }
            else
                MessageBox.Show("Такое название уже используется!");
        }
    }
}
