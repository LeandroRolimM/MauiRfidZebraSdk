using System;
using MauiRfidSample.MVVM.Models;
using MauiRfidSample.MVVM.ViewModels;

namespace MauiRfidSample.MVVM.Views
{
    public partial class ConferenciaDeExpedicaoPage : ContentPage
    {
        private readonly OrdemRepository _repository;
        private Ordem _ordemSelecionada;
        public ConferenciaDeExpedicaoPage()
        {
            InitializeComponent();
            _repository = new OrdemRepository();
        }

        private void OnPesquisarClicked(object sender, EventArgs e)
        {
            string numeroOrdem = OrdemInput.Text;
            _ordemSelecionada = _repository.ObterOrdemPorNumero(numeroOrdem);

            ResultadoPesquisa.IsVisible = true;

            if (_ordemSelecionada != null)
            {
                MensagemResultado.IsVisible = false;
                DetalhesOrdem.IsVisible = true;
                NumeroOrdem.Text = $"Ordem: {_ordemSelecionada.Numero}";
                ClienteNome.Text = $"Cliente: {_ordemSelecionada.Cliente.Nome}";
                ClienteCodigo.Text = $"Código Cliente: {_ordemSelecionada.Cliente.Codigo}";
                DataPrevista.Text = $"Data Prevista: {_ordemSelecionada.DataPrevista.ToString("g")}";
                Quantidade.Text = $"Quantidade: {_ordemSelecionada.Quantidade}";

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
            if (_ordemSelecionada != null)
            {
                await Navigation.PushAsync(new ExecucaoConferenciaPage(_ordemSelecionada));
            }
            else
            {
                await DisplayAlert("Erro", "Nenhuma ordem selecionada.", "OK");
            }
        }

    }
}
