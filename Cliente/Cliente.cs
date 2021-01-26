using System;

namespace ClasseCliente
{
    public class Cliente
    {
        public string nome { get; set; }
        public string cognome { get; set;}
        private string sesso;
        private string numero;
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
                    int cellulare = int.Parse(n);
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
    }
}
