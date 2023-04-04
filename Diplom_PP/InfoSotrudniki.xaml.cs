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
    /// Логика взаимодействия для InfoSotrudniki.xaml
    /// </summary>
    public partial class InfoSotrudniki : Page
    {
        public InfoSotrudniki()
        {
            InitializeComponent();
            ListSotrudniki.ItemsSource = AppConnect.model1db.Сотрудник.ToList();

            Doljnost.SelectedValuePath = "ID";
            Doljnost.DisplayMemberPath = "Name";
            Doljnost.ItemsSource = AppConnect.model1db.Должность.ToList();
        }

        private void Oborudovanie_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new HomePage());
        }

        private void Radota_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Rabota());
        }

        //Обновление таблицы 
        private void DataGridUpdate()
        {
            ListSotrudniki.ItemsSource = AppConnect.model1db.Единицы.ToList();
        }

        //Поиск по фамилии
        private void SearchSotrud_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Length > 0)
            {
                string str = Search.Text;
                ListSotrudniki.ItemsSource = AppConnect.model1db.Сотрудник.Where(x => x.Фамилия.StartsWith(str)).ToList();
            }
            else
            {
                DataGridUpdate();
            }
        }

        //Кнопка сброса/обновления таблицы
        private void sbrosSotrud_Click(object sender, RoutedEventArgs e)
        {
            ListSotrudniki.ItemsSource = null;
            ListSotrudniki.ItemsSource = AppConnect.model1db.Сотрудник.ToList();
        }

        private void DelSutrud_Click(object sender, RoutedEventArgs e)
        {
            if (ListSotrudniki.SelectedItems.Count > 0)
            {
                for (int i = 0; i < ListSotrudniki.SelectedItems.Count; i++)
                {
                    Сотрудник СотрудникObj = ListSotrudniki.SelectedItems[i] as Сотрудник;
                    AppConnect.model1db.Сотрудник.Remove(СотрудникObj);
                }
                AppConnect.model1db.SaveChanges();
                MessageBox.Show("Запись о сотруднике удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                ListSotrudniki.ItemsSource = null;
                ListSotrudniki.ItemsSource = AppConnect.model1db.Оборудование.ToList();
            }
            else
            {
                MessageBox.Show("В таблице нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Фитрация по должности
        private void DoljnostFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Должность = Convert.ToInt32(Doljnost.SelectedValue);
            ListSotrudniki.ItemsSource = AppConnect.model1db.Сотрудник.Where(x => x.ID_Должность == Должность).ToList();
        }

        private void Search_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search.Clear();
            ListSotrudniki.ItemsSource = AppConnect.model1db.Сотрудник.ToList();
        }

        //Перенос на страницу добавления
        private void addSotrud_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddSotrudnik());
        }

        //Перенос на страницу редактирования
        private void editSotrud_Click(object sender, RoutedEventArgs e)
        {
            Сотрудник p = ListSotrudniki.SelectedItem as Сотрудник;
            AppFrame.frameMain.Navigate(new EditSotrudnik(p));
        }
    }
}
