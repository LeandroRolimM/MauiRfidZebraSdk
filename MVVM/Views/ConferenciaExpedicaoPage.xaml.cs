using MauiRfidSample.MVVM.Models;

namespace MauiRfidSample.MVVM.Views;

public partial class ConferenciaExpedicaoPage : ContentPage
{
    private OrdemRepository ordemRepository;

    public ConferenciaExpedicaoPage()
	{
		InitializeComponent();
        ordemRepository = new OrdemRepository();
    }

    private void OnPesquisarClicked(object sender, EventArgs e)
    {
        string numeroOrdem = OrdemEntry.Text;
        var ordem = ordemRepository.GetOrdemPorNumero(numeroOrdem);
        if (ordem != null)
        {
            DisplayAlert("Ordem Encontrada", $"Ordem: {ordem.NumeroOrdem}\nCliente: {ordem.Cliente.Nome}\nStatus: {ordem.Status}", "OK");
        }
        else
        {
            DisplayAlert("Ordem Não Encontrada", "Nenhuma ordem encontrada com esse número.", "OK");
        }
    }
}