using ClasseCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biglietteria
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Cliente> clienti = new List<Cliente>();
        private List<Prenotazione> prenotazioni = new List<Prenotazione>();
        private string[] ora = new string[] { "18.00", "20.30", "21.00" };

        public MainWindow()
        {
            InitializeComponent();
        }

        List<Prenotazione> prenotazione = new List<Prenotazione>();
        
        string[] orario = new string[3] { "18:00", "20:30", "23:00" };


        
        private void btn_aggiungiCliente_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = new Cliente(txt_nome.Text, txt_cognome.Text);
            try
            {
                string nome = null;
                string cognome = null;

               

                if (txt_nome.Text != null)
                    nome = txt_nome.Text;
                else
                    MessageBox.Show("il nome non può essere vuota", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);

                if (txt_cognome.Text != null)
                    cognome = txt_cognome.Text;
                else
                    MessageBox.Show("il nome non può essere vuota", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                
                cli.SetSesso(rbtn_maschio.IsChecked == true);
                cli.SetNumero(txt_cellulare.Text);

                if (rbtn_maschio.IsChecked == true)
                    cli.SetSesso(true);
                else
                    cli.SetSesso(false);

                cli.SetNumero(txt_cellulare.Text);

                cmb_cliente.Items.Add(cli.Stampa());
                cmb_cliente1.Items.Add(cli.Stampa());

                txt_cellulare.Clear();
                txt_cognome.Clear();
                txt_nome.Clear();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        private void CmbOrario_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in ora)
            {
                cmb_orario.Items.Add(s);
            }
        }


        private void CmbOrario2_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in ora)
            {
                cmb_orario.Items.Add(s);
            }
        }


        private void Btnaggiungi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_cliente.SelectedIndex != -1 && dtp_data.SelectedDate != null && cmb_orario.SelectedIndex != -1)
                {
                    DateTime data = Convert.ToDateTime(dtp_data.Text);
                    string ora = cmb_orario.Text;
                    Cliente cliente = clienti[cmb_cliente.SelectedIndex];
                    Prenotazione prenotazione = new Prenotazione(cliente, data, ora);
                    string prezzo = Convert.ToString(prenotazione);

                    prenotazioni.Add(prenotazione);
                    txt_lista.Items.Add(prenotazione.Stampa());
                }

                //reset delle combobox
                cmb_cliente.SelectedIndex = -1;
                dtp_data.SelectedDate = null;
                cmb_orario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void BtnCancella_Click(object sender, RoutedEventArgs e)
        {
            int selezione = txt_lista.SelectedIndex;
            if (selezione >= 0)
            {
                string nome = prenotazioni[selezione].cliente.Stampa();
                for (int c = 0; c < clienti.Count; c++)
                {
                    if (nome == clienti[c].ToString())
                    {
                        clienti[c].RimuoviPrenotazione(prenotazioni[selezione]);
                    }

                }
            }
            else
            {
                MessageBox.Show("Non è stato selezionato alcun elemento dalla lista", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            prenotazioni.RemoveAt(selezione);
            txt_lista.Items.Remove(txt_lista.SelectedItem);
        }

        private void BtnPrenEvento_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_cliente1.SelectedIndex != -1 && cmb_orario2.SelectedIndex != -1)
            {
                txt_evento.Items.Clear();

                int c = clienti[cmb_cliente1.SelectedIndex].ContaPrenotazioniEvento(cmb_orario2.SelectedItem.ToString());
                txt_evento.Items.Add(c);
            }
            else
            {
                MessageBox.Show("Attenzione", "Non è stato selezionato alcun elemento dalla lista", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnPrenCliente_Click(object sender, RoutedEventArgs e)
        {

            if (cmb_cliente1.SelectedIndex != -1)
            {
                double prezzo = 0;

                int c = clienti[cmb_cliente1.SelectedIndex].ContaPrenotazioni();
                txt_evento.Items.Add($"Il cliente selezionato è {cmb_cliente1.SelectedValue}:");
                txt_evento.Items.Add($"Prenotazioni totali: {c}");

                prezzo = clienti[cmb_cliente1.SelectedIndex].CalcolaCosto();
                txt_evento.Items.Add($"Totale spesa: {prezzo}");

                cmb_cliente1.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Devi selezionare un cliente ed un orario", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnPulisci_Click(object sender, RoutedEventArgs e)
        {
            //pulisce tutto
        }

        private void BtnEsci_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
