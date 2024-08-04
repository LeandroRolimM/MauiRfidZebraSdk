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
                new Ordem { Numero = "12345", 
                    Cliente = new Cliente { Nome = "Cliente A" ,Codigo="1000"}, 
                    Status = "Pendente" ,
                    DataPrevista = DateTime.Now,
                    EPCs = new List<string>{"2D11C10000000000000145C9", "2D11C10000000000000145C9" },
                    Quantidade = 2
                },
                new Ordem { Numero = "67890", 
                    Cliente = new Cliente { Nome = "Cliente B",Codigo="2000" }, 
                    Status = "Pendente",
                    DataPrevista = DateTime.Now,
                    EPCs = new List<string>{"2D11C10000000000000145D1", "2D11C10000000000000145D2","2D11C10000000000000145D3" },
                    Quantidade = 3
                }
            };
        }

        public Ordem ObterOrdemPorNumero(string numeroOrdem)
        {
            return ordens.Find(o => o.Numero == numeroOrdem);
        }
    }

    public class Ordem
    {
        public string Numero { get; set; }
        public Cliente Cliente { get; set; }
        public string Status { get; set; }
        public DateTime DataPrevista { get; set; }
        public List<string> EPCs { get; set; }
        public int Quantidade { get; set; }
    }

    public class Cliente
    {
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}
