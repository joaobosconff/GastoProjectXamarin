using GastoProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GastoProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = "Cadastro de Gastos";
            InitializeComponent();
            Gasto gasto1 = new Gasto(34.5, "Netflix");
            Gasto gasto2 = new Gasto(32.5, "Disney+");
            Gasto gasto3 = new Gasto(32.5, "HBO");
            Database.gastos.Add(gasto1);
            Database.gastos.Add(gasto2);
            Database.gastos.Add(gasto3);
            getGastos.ItemsSource = Database.gastos;

        }


        private async void Button_Clicked(object sender, EventArgs e) 
        {
            if (string.IsNullOrEmpty(precoField.Text) || string.IsNullOrEmpty(descricaoField.Text))
            {
                await DisplayAlert("Aviso", "Campos inválidos", "OK");
            }
            else {
                Gasto gasto = new Gasto(double.Parse(precoField.Text), descricaoField.Text);
                Database.gastos.Add(gasto);
                await DisplayAlert("Aviso","Cadastrado com sucesso", "OK.");
            }
        }

        private async void getGastos_itemSelected(object sender,SelectedItemChangedEventArgs e) {
            Gasto gasto = (Gasto) e.SelectedItem;
            GastoInfo gastoInfo = new GastoInfo(gasto);
            await Navigation.PushAsync(gastoInfo);
            
        }

        private void OnTextNumberChanged(object sender, TextChangedEventArgs e)
        {
            //Convertendo String para numero
            if (string.IsNullOrEmpty(e.NewTextValue)) return;

            if (!double.TryParse(e.NewTextValue, out double value))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }

    }
}
