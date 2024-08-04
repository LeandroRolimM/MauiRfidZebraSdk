using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MauiRfidSample.MVVM.Models;

namespace MauiRfidSample.MVVM.Views
{
    public partial class ExecucaoConferenciaPage : ContentPage
    {
        private Ordem _ordem;
        private ObservableCollection<string> _epcsNaoEsperados;

        public ExecucaoConferenciaPage(Ordem ordem)
        {
            InitializeComponent();
            _ordem = ordem;
            _epcsNaoEsperados = new ObservableCollection<string>();
            EpcsNaoEsperados.ItemsSource = _epcsNaoEsperados;
            ExibirInformacoesOrdem();
        }

        private void ExibirInformacoesOrdem()
        {
            OrdemNumero.Text = $"Ordem: {_ordem.Numero}";
            ClienteNome.Text = $"Cliente: {_ordem.Cliente.Nome}";
            Quantidade.Text = $"Quantidade: {_ordem.Quantidade}";
            Status.Text = $"Status: {_ordem.Status}";
        }

        private void OnIniciarLeituraEPCsClicked(object sender, EventArgs e)
        {
            ContagemEPCs.IsVisible = true;
            // Simulação de leitura de EPCs não esperados
            var epcsLidos = new List<string> { "EPC1", "EPC2", "EPC3" }; // Exemplos de EPCs lidos
            var epcsEsperados = _ordem.Epcs ?? new List<string>(); // Inicializa se nulo

            foreach (var epc in epcsLidos)
            {
                if (!epcsEsperados.Contains(epc))
                {
                    Device.BeginInvokeOnMainThread(() => _epcsNaoEsperados.Add(epc));
                }
            }
        }
    }
}
