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
    /// Логика взаимодействия для AddOborudovanieHome.xaml
    /// </summary>
    public partial class AddOborudovanieHome : Page
    {
        Оборудование оборудование = new Оборудование();

        public AddOborudovanieHome()
        {
            
            InitializeComponent();
            ed.SelectedValuePath = "ID";
            ed.DisplayMemberPath = "Name";
            ed.ItemsSource = AppConnect.model1db.Единицы.ToList();

            mesto.SelectedValuePath = "ID";
            mesto.DisplayMemberPath = "Name";
            mesto.ItemsSource = AppConnect.model1db.Кабинеты.ToList();

            status.SelectedValuePath = "ID";
            status.DisplayMemberPath = "Name";
            status.ItemsSource = AppConnect.model1db.Статус.ToList();
        }

        private void addOborudovanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Оборудование ОборудованиеObj = new Оборудование()
                {
                    Номер = nomer.Text,
                    Наименование = name.Text,
                    Количество = colvo.Text,
                    ДатаВнесения = calendar.DisplayDate,
                    Единицы = ed.SelectedItem as Единицы,                 
                    Кабинеты = mesto.SelectedItem as Кабинеты,
                    Статус = status.SelectedItem as Статус,
                };

                AppConnect.model1db.Оборудование.Add(ОборудованиеObj);
                AppConnect.model1db.SaveChanges();
                MessageBox.Show("Оборудование добавлено!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.frameMain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

