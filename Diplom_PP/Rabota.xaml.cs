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
    /// Логика взаимодействия для Rabota.xaml
    /// </summary>
    public partial class Rabota : Page
    {
        public Rabota()
        {
            InitializeComponent();
            ListR.ItemsSource = AppConnect.model1db.Выполнение_работ.ToList();

            stats.SelectedValuePath = "ID";
            stats.DisplayMemberPath = "Name";
            stats.ItemsSource = AppConnect.model1db.СтатусРаботы.ToList();
        }

        private void Oborudovanie_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new HomePage());
        }

        private void sotrudn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new InfoSotrudniki());
        }

        private void rabota_Click(object sender, RoutedEventArgs e)
        {

        }

        private void sbrosRabota_Click(object sender, RoutedEventArgs e)
        {
            ListR.ItemsSource = null;
            ListR.ItemsSource = AppConnect.model1db.Выполнение_работ.ToList();
        }

        private void addSotrud_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editSotrud_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelSutrud_Click(object sender, RoutedEventArgs e)
        {
            if (ListR.SelectedItems.Count > 0)
            {
                for (int i = 0; i < ListR.SelectedItems.Count; i++)
                {
                    Выполнение_работ Выполнение_работObj = ListR.SelectedItems[i] as Выполнение_работ;
                    AppConnect.model1db.Выполнение_работ.Remove(Выполнение_работObj);
                }
                AppConnect.model1db.SaveChanges();
                MessageBox.Show("Запись удалена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                ListR.ItemsSource = null;
                ListR.ItemsSource = AppConnect.model1db.Выполнение_работ.ToList();
            }
            else
            {
                MessageBox.Show("В таблице нет данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DoljnostFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int СтатусРаботы = Convert.ToInt32(stats.SelectedValue);
            ListR.ItemsSource = AppConnect.model1db.Выполнение_работ.Where(x => x.ID_СтатусРаботы == СтатусРаботы).ToList();
        }

        private void SearchSotrud_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Length > 0)
            {
                string str = Search.Text;
                ListR.ItemsSource = AppConnect.model1db.Выполнение_работ.Where(x => x.НаименованиеРаботы.StartsWith(str)).ToList();
            }
            else
            {
                DataGridUpdate();
            }
        }

        private void DataGridUpdate()
        {
            ListR.ItemsSource = AppConnect.model1db.Единицы.ToList();
        }

        //Двойной щелчек
        private void Search_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search.Clear();
            ListR.ItemsSource = AppConnect.model1db.Выполнение_работ.ToList();
        }

        private void PauseR_Click(object sender, RoutedEventArgs e)
        {
            var R = MessageBox.Show("Подтвердить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (R == MessageBoxResult.Yes)
            {
                (ListR.SelectedItem as Выполнение_работ).ID_СтатусРаботы = 3;               
                AppConnect.model1db.SaveChanges();
                ListR.ItemsSource = AppConnect.model1db.Выполнение_работ.ToList();
            }
        }

        private void DoneR_Click(object sender, RoutedEventArgs e)
        {
            var R = MessageBox.Show("Подтвердить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (R == MessageBoxResult.Yes)
            {
                (ListR.SelectedItem as Выполнение_работ).ID_СтатусРаботы = 2;
                (ListR.SelectedItem as Выполнение_работ).ДатаОкончания = DateTime.Now;
                AppConnect.model1db.SaveChanges();
                ListR.ItemsSource = AppConnect.model1db.Выполнение_работ.ToList();

            }
        }

        private void ResumeR_Click(object sender, RoutedEventArgs e)
        {
            var R = MessageBox.Show("Подтвердить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (R == MessageBoxResult.Yes)
            {
                (ListR.SelectedItem as Выполнение_работ).ID_СтатусРаботы = 1;
                AppConnect.model1db.SaveChanges();
                ListR.ItemsSource = AppConnect.model1db.Выполнение_работ.ToList();
            }            
        }
    }
}
