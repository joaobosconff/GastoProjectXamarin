using GastoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GastoProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GastoInfo : ContentPage
    {
        Gasto gasto;
        int index;
        public GastoInfo(Gasto gasto)
        {
            InitializeComponent();
            this.gasto = gasto;
            descricaoField.Text = gasto.Descricao;
            precoField.Text = gasto.Preco.ToString();
            index = Database.gastos.IndexOf(gasto);

        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(precoField.Text) || string.IsNullOrEmpty(descricaoField.Text))
            {
                await DisplayAlert("Aviso", "Campos inválidos", "OK");
            }
            else
            {
                Gasto gastoNew = new Gasto(double.Parse(precoField.Text), descricaoField.Text);
                Database.gastos.RemoveAt(index);
                Database.gastos.Insert(index, gastoNew);
                await DisplayAlert("Aviso", "Atualizado com sucesso", "OK.");
                await Navigation.PopAsync();
            }
        }

        private async void RemoveButton_Clicked(object sender, EventArgs e)
        {
            Database.gastos.RemoveAt(index);
            await DisplayAlert("Aviso", "Removido com sucesso", "OK.");
            await Navigation.PopAsync();
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