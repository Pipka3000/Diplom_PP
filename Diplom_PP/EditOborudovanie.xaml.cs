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
    /// Логика взаимодействия для EditOborudovanie.xaml
    /// </summary>
    public partial class EditOborudovanie : Page
    {
        string Nomer;
        public EditOborudovanie(Оборудование оборудование)
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

            Nomer = оборудование.Номер;

            nomer.Text = оборудование.Номер;
            name.Text = оборудование.Наименование;
            colvo.Text = оборудование.Количество;
            calendar.SelectedDate = оборудование.ДатаВнесения;
            calendarSpisanie.SelectedDate = оборудование.ДатаСписания;
            ed.SelectedItem = оборудование.Единицы;            
            mesto.SelectedItem = оборудование.Кабинеты;
            status.SelectedItem = оборудование.Статус;
        }

        private void SaveOborudovanie_Click(object sender, RoutedEventArgs e)
        {
            Оборудование p = AppConnect.model1db.Оборудование.FirstOrDefault(x => x.Номер == Nomer);
            p.Наименование = name.Text;
            p.Количество = colvo.Text;
            p.ДатаСписания = calendarSpisanie.SelectedDate;
            p.ДатаВнесения = calendar.DisplayDate;
            p.Единицы = ed.SelectedItem as Единицы;
            
            p.Кабинеты = mesto.SelectedItem as Кабинеты;
            p.Статус = status.SelectedItem as Статус;
            AppConnect.model1db.SaveChanges();
            AppFrame.frameMain.GoBack();

        }
    }
}
