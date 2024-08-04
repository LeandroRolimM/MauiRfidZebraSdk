using System;
using MauiRfidSample.MVVM.Models;
using MauiRfidSample.MVVM.ViewModels;

namespace MauiRfidSample.MVVM.Views
{
    public partial class ConferenciaDeExpedicaoPage : ContentPage
    {
        private readonly OrdemRepository _repository;

        public ConferenciaDeExpedicaoPage()
        {
            InitializeComponent();
            _repository = new OrdemRepository();
        }

        private void OnPesquisarClicked(object sender, EventArgs e)
        {
            string numeroOrdem = OrdemInput.Text;
            Ordem ordem = _repository.ObterOrdemPorNumero(numeroOrdem);

            ResultadoPesquisa.IsVisible = true;

            if (ordem != null)
            {
                MensagemResultado.IsVisible = false;
                DetalhesOrdem.IsVisible = true;
                NumeroOrdem.Text = $"Ordem: {ordem.Numero}";
                ClienteNome.Text = $"Cliente: {ordem.Cliente.Nome}";
                ClienteCodigo.Text = $"Código Cliente: {ordem.Cliente.Codigo}";
                DataPrevista.Text = $"Data Prevista: {ordem.DataPrevista.ToString("g")}";
                Quantidade.Text = $"Quantidade: {ordem.Quantidade}";

            }
            else
            {
                MensagemResultado.IsVisible = true;
                DetalhesOrdem.IsVisible = false;
                MensagemResultado.Text = "Ordem não encontrada.";
            }
        }

        private async void OnIniciarConferenciaClicked(object sender, EventArgs e)
        {
            // await Navigation.PushAsync(new InventoryPage());
            DisplayAlert("Navegacao","Navegando...","Ok");
        }
    }
}
