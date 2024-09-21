using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace RotationCubeExample.Entities
{
    internal class Giroscopio
    {
        // Atributos
        private string Nome { get; set; }

        // Construtor
        public Giroscopio(string nome)
        {
            Nome = nome;
        }

        // Metodos
        public void ConverterResposta(int rawX, int rawY, int rawZ)
        {
            // Angulo
            int anguloConvertidoX = (rawX * 90) / 17000;
            int anguloConvertidoY = (rawY * 90) / 17000;
            int anguloConvertidoZ = (rawZ * 90) / 17000;


            if (anguloConvertidoX < 0)
            {
                //anguloConvertido = anguloConvertido + 360;
            }

            Debug.WriteLine($"--> [{Nome}] Angulo convertido: {anguloConvertidoX}, {anguloConvertidoY}, {anguloConvertidoZ}");

        }

    }
}
