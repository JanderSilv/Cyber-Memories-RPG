﻿using _3ReaisEngine;
using System;
using Windows.UI.Xaml.Controls;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace Testes
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
          
            this.InitializeComponent();
            try
            {
              //  AmbienteJogo.window = new _3ReaisEngine.RPG.Core.Window(this);

            }catch (Exception e)
            {

            }
           //  win.SetCurrent();
        }
    }
}
