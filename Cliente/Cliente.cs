using System;
using System.Collections.Generic;

namespace ClasseCliente
{
    public class Cliente
    {
        public string nome { get; set; }
        public string cognome { get; set;}
        private string sesso;
        private string numero;


        public List<Prenotazione> p = new List<Prenotazione>();
        public Cliente(string n ,string c)
        {
            nome = n;
            cognome = c;            
        }
        public string GetSesso()
        {
            return sesso;
        }

        public void SetSesso(bool s)
        {
            if (s == true)
                sesso = "M";
            else
                sesso = "F";         
        }
        public string GetNumero()
        {
            return numero;
        }

        public void SetNumero(string n)
        {
            if (n.Length == 10)
            {
                try
                {
                    Int64.Parse(n);
                    numero = n;
                }
                catch(Exception)
                {
                    throw new Exception("Inserisci soltanto numeri!");
                }
            }
            else
               throw new Exception("il numero non è valido!");
        }
        public string Stampa()
        {
            return $"{nome} {cognome}";
        }

        public void AddPrenotazione(Prenotazione prenotazione)
        {
            p.Add(prenotazione);
        }
        public void RimuoviPrenotazione(Prenotazione prenotazione)
        {
            p.Remove(prenotazione);
        }

        public int ContaPrenotazioni()
        {
            int c = 0;
            for (int i = 0; i < p.Count; i++)
            {
                c++;
            }
            return c;
        }

        public double CalcolaCosto()
        {
            double c = 0;
            for (int i = 0; i < p.Count; i++)
            {
                c = c + p[i].Prezzo();
            }
            return c;
        }

        public int ContaPrenotazioniEvento(string ora)
        {
            int c = 0;

            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].orario == ora)
                {
                    c++;
                }
            }
            return c++;
        }
    }
}
