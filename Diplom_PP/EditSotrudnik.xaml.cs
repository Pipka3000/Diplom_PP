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
    /// Логика взаимодействия для EditSotrudnik.xaml
    /// </summary>
    public partial class EditSotrudnik : Page
    {
        string Nomer;
        public EditSotrudnik(Сотрудник сотрудник)
        {
            InitializeComponent();

            otdel.SelectedValuePath = "ID";
            otdel.DisplayMemberPath = "Name";
            otdel.ItemsSource = AppConnect.model1db.Отдел.ToList();

            doljnost.SelectedValuePath = "ID";
            doljnost.DisplayMemberPath = "Name";
            doljnost.ItemsSource = AppConnect.model1db.Должность.ToList();

            Nomer = сотрудник.ID;

            nomer.Text = сотрудник.ID;
            fam.Text = сотрудник.Фамилия;
            name.Text = сотрудник.Имя;
            otchestvo.Text = сотрудник.Отчество;
            otdel.SelectedItem = сотрудник.Отдел;
            doljnost.SelectedItem = сотрудник.Должность;
            tel.Text = сотрудник.Телефон;
            mail.Text = сотрудник.Email;
        }

        private void EditSotrudnik_Click(object sender, RoutedEventArgs e)
        {
            Сотрудник p = AppConnect.model1db.Сотрудник.FirstOrDefault(x => x.ID == Nomer);
            p.Фамилия = fam.Text;
            p.Имя = name.Text;
            p.Отчество = otchestvo.Text;
            p.Отдел = otdel.SelectedItem as Отдел;
            p.Должность = doljnost.SelectedItem as Должность;
            p.Телефон = tel.Text;
            p.Email = mail.Text;
            AppConnect.model1db.SaveChanges();
            AppFrame.frameMain.GoBack();
        }
    }
}
