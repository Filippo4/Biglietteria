using System;
using System.Collections.Generic;
using System.Text;

namespace ClasseCliente
{
    public class Prenotazione
    {
        public Cliente cliente { get; set; }

        public DateTime data { get; set; }

        public string orario { get; set; }

        const int PREZZO = 10;
        public Prenotazione(Cliente c , DateTime data, string ora)
        {
            cliente = c;
            this.data = data;
            orario = ora;
        }

        public string Stampa()
        {
            return $"{cliente.nome} {cliente.cognome} {data} {orario} {Prezzo()}€";
        }

        public double Prezzo()
        {
            double prezzo = 0;
            if (cliente.GetSesso() == "M" && orario =="18:30" || cliente.GetSesso() == "F")
            {
                prezzo = (PREZZO * 10) / 100;
            } else
                prezzo = PREZZO;
            return prezzo;
        }
    }
}
