﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

using HelixToolkit.Wpf;
using System.Windows.Threading;
using System.Reflection;
using System.Diagnostics;
using RotationCubeExample.Connections;
using RotationCubeExample.Entities;
using Sharer;
using RotationCubeExample.ViewModel;
using System.IO.Ports;
using ESP32_BIM160.Charts;
using LiveCharts.Wpf;
using LiveCharts.Wpf.Charts.Base;
using ESP32_BIM160.Views;


namespace RotationCubeExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Exibe as informações de rotação do objeto
        public string posicaoCamera = "";
        
        // Instancia um novo objeto 'esp32' do tipo 'ESP32'
        ESP32 esp32 = new ESP32();

        // Instancia uma nova conexão Serial com o ESP32
        SharerConnection conexaoSerial = new SharerConnection("COM3", 115200);


        public MainWindow()
        {
            InitializeComponent();

            // Obter as portas COM disponíveis
            //string[] portas = SerialPort.GetPortNames();

            // Exibindo as portas COM disponíveis no 'comboBoxPortaCOM'
            //comboBoxPortaCOM.ItemsSource = portas;

            // Realiza a tentativa de conexão com o ESP32
            //esp32.Conectar(conexaoSerial);

            // Teste
            //esp32.BMI160_ObterAngulos(conexaoSerial);

            // Conexão com o ESP32
            //esp32.SerialConnection();

            // Faz a chamada da primeira UserControl
            gridModelo3D.Children.Clear();
            gridModelo3D.Children.Add(new _3DModelUserControl());


            var rawData = new RawData();

            //sensorAxisData.Series = rawData.Series;

            //sensorAxisData.AxisX.Add(rawData.AxisX);
            //sensorAxisData.AxisY.Add(rawData.AxisY);
            //sensorAxisData.AxisY.Add(rawData.AxisZ);

        }

        

        // Sliders X, Y e Z


        // Permite clicar e mover a janela (grid) principal
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch(System.InvalidOperationException ex)
            {
                Debug.WriteLine("Não foi possível ajustar a posição da tela principal. " + ex.Message);
            }
        }

        // Botão Minimizar Janela
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Botão 'Fechar'
        private void button_Fechar_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        // Animação botão Minimizar
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            button_Fechar.Foreground = new SolidColorBrush(Colors.Red);
        }

        // Animação botão Fechar
        private void button_Fechar_MouseLeave(object sender, MouseEventArgs e)
        {
            button_Fechar.Foreground = new SolidColorBrush(Colors.Black);
        }

        // Radio button '3D Model'
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("--> [Radio Button] 3D Model");

            //gridSecundario.Children.Clear();
            gridModelo3D.Visibility = Visibility.Visible;

            gridAuxiliar.Children.Clear();
            //gridSecundario.Children.Add(new _3DModelUserControl());

        }

        // Radio button 'ESP32 Code'
        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("--> [Radio Button] ESP32 Code");

            gridModelo3D.Visibility = Visibility.Collapsed;

            gridAuxiliar.Children.Clear();
            gridAuxiliar.Children.Add(new ESP32CodeUserControl());
        }

        // Radio button 'C# Code'
        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("--> [Radio Button] C# Code");

            gridModelo3D.Visibility = Visibility.Collapsed;

            gridAuxiliar.Children.Clear();
            gridAuxiliar.Children.Add(new CCodeUserControl());
        }

        // Radio button 'About'
        private void RadioButton_Click_3(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("--> [Radio Button] About");

            gridModelo3D.Visibility = Visibility.Collapsed;

            gridAuxiliar.Children.Clear();
            gridAuxiliar.Children.Add(new AboutUserControl());
        }
    }
}