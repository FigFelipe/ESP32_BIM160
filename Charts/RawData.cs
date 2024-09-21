using LiveCharts.Wpf;
using LiveCharts;
using RotationCubeExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiveCharts;
using LiveCharts.Wpf;
using System.Globalization;
using System.Windows.Data;
using LiveCharts.Definitions.Charts;
using System.Windows;

namespace ESP32_BIM160.Charts
{
    class RawData
    {
        // Atributos
        public SeriesCollection Series { get; set; }
        public Axis AxisX { get; set; }
        public Axis AxisY { get; set; }
        public Axis AxisZ { get; set; }


        // Construtor
        public RawData()
        {
            // Exemplo de dados para os eixos X, Y e Z
            var valuesX = new ChartValues<double> { 3, 5, 7, 4, 2, 6 };
            var valuesY = new ChartValues<double> { 2, 4, 6, 8, 10, 12 };
            var valuesZ = new ChartValues<double> { 1, 3, 5, 7, 9, 11 };

            Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Série X",
                    Values = valuesX
                },
                new LineSeries
                {
                    Title = "Série Y",
                    Values = valuesY
                },
                new LineSeries
                {
                    Title = "Série Z",
                    Values = valuesZ
                }
            };

            AxisX = new Axis
            {
                Title = "Time",
                Labels = new[] { "A", "B", "C", "D", "E", "F" }
            };

            AxisY = new Axis
            {
                Title = "Eixo Y"
            };

            // Simulação do Eixo Z
            AxisZ = new Axis
            {
                Title = "Eixo Z",
                Position = AxisPosition.RightTop
            };
        }

    }

}
