using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace RotationCubeExample.ViewModel
{
    internal class PortaCOM
    {
        public ObservableCollection<string> AvailablePorts { get; set; }

        public ObservableCollection<int> BaudRates { get; set; }

        public int SelectedBaudRate { get; set; }


        public PortaCOM()
        {
            AvailablePorts = new ObservableCollection<string>(SerialPort.GetPortNames());

            BaudRates = new ObservableCollection<int>
            {
                300,
                600,
                1200,
                2400,
                4800,
                9600,
                14400,
                19200,
                38400,
                57600,
                115200,
                230400,
                460800,
                921600
            };

            SelectedBaudRate = 115200; // Define o valor padrão

            BindingOperations.EnableCollectionSynchronization(AvailablePorts, new object());
            StartWatcher();
        }

        private void StartWatcher()
        {
            ManagementEventWatcher watcher = new ManagementEventWatcher();
            WqlEventQuery query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2 OR EventType = 3");
            watcher.EventArrived += new EventArrivedEventHandler(DeviceChangedEvent);
            watcher.Query = query;
            watcher.Start();
        }

        private void DeviceChangedEvent(object sender, EventArrivedEventArgs e)
        {
            UpdateAvailablePorts();
        }

        private void UpdateAvailablePorts()
        {
            var ports = SerialPort.GetPortNames();

            App.Current.Dispatcher.Invoke(() =>
            {
                if (AvailablePorts != null)
                {
                    AvailablePorts.Clear();
                    foreach (var port in ports)
                    {
                        AvailablePorts.Add(port);
                    }
                }
            });
        }

    }
}


