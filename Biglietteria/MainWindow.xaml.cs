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
        public MainWindow()
        {
            InitializeComponent();
        }

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
                cmb_cliente.Items.Add(cli.Stampa());

                txt_cellulare.Clear();
                txt_cognome.Clear();
                txt_nome.Clear();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }
    }
}
