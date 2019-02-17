using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using _3ReaisEngine.RPG;
using _3ReaisEngine.RPG.Events;
using System.Threading.Tasks;
// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace RPG
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
      
        public MainPage()
        {
          
            this.InitializeComponent();
            
            AmbienteJogo.gerenciadorEventos.handleTeclado[(int)PrioridadeEvento.Interface] += KeyE;
            AmbienteJogo.gerenciadorEventos.handleTeclado[(int)PrioridadeEvento.Game] += KeyR;
            
        }
           
        private void Grid_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            TecladoEvento te = new TecladoEvento { Tecla = (int)e.Key, Repeticoes = e.KeyStatus.RepeatCount,Modificador = (byte)ModificadorList.KeyUp };
            AmbienteJogo.gerenciadorEventos.Enviar(te);
            AmbienteJogo.Execute();

        }

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            TecladoEvento te = new TecladoEvento {Tecla = (int)e.Key,Repeticoes = e.KeyStatus.RepeatCount, Modificador = (byte)ModificadorList.KeyDown };
            AmbienteJogo.gerenciadorEventos.Enviar(te);
            AmbienteJogo.Execute();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AmbienteJogo.Run = false;
        }

        private bool KeyE(TecladoEvento e)
        {
           if(e.Modificador == (byte)ModificadorList.KeyUp) txt_text.Text = "key up";
           else txt_text.Text = "key down";
            return false;
        }
        private bool KeyR(TecladoEvento e)
        {
            if (e.Modificador == (byte)ModificadorList.KeyUp) txb_log.Text = "key up";
            else txb_log.Text = "key down";
            return false;
        }
    }
}
