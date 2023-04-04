using Diplom_PP.AppData;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom_PP
{
    /// <summary>
    /// Логика взаимодействия для AddSotrudnik.xaml
    /// </summary>
    public partial class AddSotrudnik : Page
    {
        public AddSotrudnik()
        {
            InitializeComponent();

            otdel.SelectedValuePath = "ID";
            otdel.DisplayMemberPath = "Name";
            otdel.ItemsSource = AppConnect.model1db.Отдел.ToList();

            doljnost.SelectedValuePath = "ID";
            doljnost.DisplayMemberPath = "Name";
            doljnost.ItemsSource = AppConnect.model1db.Должность.ToList();
        }

        private void addOborudovanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Сотрудник СотрудникObj = new Сотрудник()
                {
                    ID = nomer.Text,
                    Фамилия = fam.Text,
                    Имя = name.Text,
                    Отчество = otchestvo.Text,
                    Отдел = otdel.SelectedItem as Отдел,
                    Должность = doljnost.SelectedItem as Должность,
                    Телефон = tel.Text,
                    Email = mail.Text,
                };

                AppConnect.model1db.Сотрудник.Add(СотрудникObj);
                AppConnect.model1db.SaveChanges();
                MessageBox.Show("Запись о сотруднике добавлена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frameMain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
