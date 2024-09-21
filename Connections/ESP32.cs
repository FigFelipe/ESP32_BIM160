using RotationCubeExample.Entities;
using Sharer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RotationCubeExample.Connections
{
    internal class ESP32
    {
        // Biblioteca para comunicação com o ESP32
        //https://github.com/Rufus31415/Sharer

        // Instanciando um novo objeto 'bmi160' do tipo 'Acelerometro'
        Giroscopio bmi160 = new Giroscopio("Bosch BMI160");

        // Atributos
        public string connection { get; set; }

        // Construtor
        public ESP32()
        {

        }

        // Métodos
        public void Conectar(SharerConnection connection)
        {
            try
            {
                Debug.WriteLine("--> Conectando via serial ao ESP32...");

                // Realiza a conexão Serial com o ESP32
                connection.Connect();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro na tentativa de conexão serial com ESP32: " + ex.Message);
            }

            Debug.WriteLine("--> Conectado via serial ao ESP32!");

        }

        public void BMI160_ObterAngulos(SharerConnection connection)
        {
            var anguloX = connection.ReadVariable("x");
            var anguloY = connection.ReadVariable("y");
            var anguloZ = connection.ReadVariable("z");

            // Exibindo os valores recebidos do BIM160 via ESP32
            Debug.WriteLine($"--> Informação recebida do ESP32.BMI160: [X]{anguloX} [Y]{anguloY} [Z]{anguloZ}");

            // Realiza a conversão da resposta 'bruta' para o formato 'angular'
            bmi160.ConverterResposta(Convert.ToInt32(anguloX.Value), Convert.ToInt32(anguloY.Value), Convert.ToInt32(anguloZ.Value));

        }

        public void ChamarMetodo(SharerConnection connection)
        {
            // Realiza a chamada da função existente no ESP32
            var result = connection.Call("Sum", 10, 12);

            var value = connection.ReadVariable("myVar");

            var boardInfo = connection.GetInfos();

            Debug.WriteLine($"Resultado ESP32: {result} {value} {boardInfo}");
        }


    }
}
