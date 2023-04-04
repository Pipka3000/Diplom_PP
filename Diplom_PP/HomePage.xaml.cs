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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        string login;

        public HomePage()
        {
            InitializeComponent();
            List.ItemsSource = AppConnect.model1db.Оборудование.ToList();

            sortKab.SelectedValuePath = "ID";
            sortKab.DisplayMemberPath = "Name";
            sortKab.ItemsSource = AppConnect.model1db.Кабинеты.ToList();

            Spisat.SelectedValuePath = "ID";
            Spisat.DisplayMemberPath = "Name";
            Spisat.ItemsSource = AppConnect.model1db.Статус.ToList();
        }
        
        //Обновление таблицы 
        private void DataGridUpdate()
        {
            List.ItemsSource = AppConnect.model1db.Единицы.ToList();
        }

        //Поиск по наименованию
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Length > 0)
            {
                string str = Search.Text;
                List.ItemsSource = AppConnect.model1db.Оборудование.Where(x => x.Наименование.StartsWith(str)).ToList();
            }
            else
            {
                DataGridUpdate();
            }
        }
        
        //Двойной щелчек
        private void Search_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search.Clear();
            List.ItemsSource = AppConnect.model1db.Оборудование.ToList();
        }

        //Кнопка сброса/обновления таблицы
        private void sbros_Click(object sender, RoutedEventArgs e)
        {
            List.ItemsSource = null;
            List.ItemsSource = AppConnect.model1db.Оборудование.ToList();
        }

        //Фильтрация по кабинетам
        private void Sortirovka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Кабинеты = Convert.ToInt32(sortKab.SelectedValue);
            List.ItemsSource = AppConnect.model1db.Оборудование.Where(x => x.ID_Расположение == Кабинеты).ToList();
        }

        //Перенос на страницу добавления оборудования
        private void addOborud_Click(object sender, RoutedEventArgs e)
        {
           AppFrame.frameMain.Navigate(new AddOborudovanieHome());
        }

        //Удаление записи
        private void DelOborud_Click(object sender, RoutedEventArgs e)
        {
            if (List.SelectedItems.Count > 0)
            {
                for (int i = 0; i < List.SelectedItems.Count; i++)
                {
                    Оборудование ОборудованиеObj = List.SelectedItems[i] as Оборудование;
                    AppConnect.model1db.Оборудование.Remove(ОборудованиеObj);
                }
                AppConnect.model1db.SaveChanges();
                MessageBox.Show("Оборудование удалено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                List.ItemsSource = null;
                List.ItemsSource = AppConnect.model1db.Оборудование.ToList();
            }
            else
            {
                MessageBox.Show("В таблице нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Кнопка Списать
        private void SpisatOB_Click(object sender, RoutedEventArgs e)
        {
            var R = MessageBox.Show("Подтвердить списание?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (R == MessageBoxResult.Yes)
            {
                (List.SelectedItem as Оборудование).ID_Статус = 2;
                (List.SelectedItem as Оборудование).ДатаСписания = DateTime.Now;
                AppConnect.model1db.SaveChanges();
                List.ItemsSource = AppConnect.model1db.Оборудование.ToList();
            }
        }

        private void List_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                Оборудование оборудование = (Оборудование)e.Row.DataContext;
                if (оборудование.ID_Статус == 1)
                {
                    e.Row.Background = new SolidColorBrush(Colors.LightSlateGray);
                }
                else
                {
                    e.Row.Background = new SolidColorBrush(Colors.White);
                }
            }
            catch
            {

            }
        }

        //Фильтрация по статусу
        private void SpisatOB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int Статус = Convert.ToInt32(Spisat.SelectedValue);
            List.ItemsSource = AppConnect.model1db.Оборудование.Where(x => x.ID_Статус == Статус).ToList();
        }

        //Перенос на страницу с работой сотрудников
        private void Radota_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Rabota());
        }

        //Перенос на страницу с информацией о сотрудниках
        private void Sotrudniki_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new InfoSotrudniki());
        }

        //Перенос на страницу редактирования оборудования
        private void editOborud_Click(object sender, RoutedEventArgs e)
        {
            Оборудование p = List.SelectedItem as Оборудование;
            AppFrame.frameMain.Navigate(new EditOborudovanie(p));
        }

        
    }
}
