using System.Collections.Generic;

namespace MauiRfidSample.MVVM.Models
{
    public class OrdemRepository
    {
        private List<Ordem> ordens;

        public OrdemRepository()
        {
            ordens = new List<Ordem>
            {
                new Ordem { NumeroOrdem = "12345", Cliente = new Cliente { Nome = "Cliente A" }, Status = "Pendente" },
                new Ordem { NumeroOrdem = "67890", Cliente = new Cliente { Nome = "Cliente B" }, Status = "Finalizado" }
            };
        }

        public Ordem GetOrdemPorNumero(string numeroOrdem)
        {
            return ordens.Find(o => o.NumeroOrdem == numeroOrdem);
        }
    }

    public class Ordem
    {
        public string NumeroOrdem { get; set; }
        public Cliente Cliente { get; set; }
        public string Status { get; set; }
    }

    public class Cliente
    {
        public string Nome { get; set; }
    }
}
