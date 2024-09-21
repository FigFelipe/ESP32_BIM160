using HelixToolkit.Wpf;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ESP32_BIM160.Views
{
    /// <summary>
    /// Interação lógica para _3DModelUserControl.xam
    /// </summary>
    public partial class _3DModelUserControl : UserControl
    {
        public _3DModelUserControl()
        {
            InitializeComponent();

            

            // Faz a importação e exibição do modelo 3D
            ExibeModelo3D();
        }

        public void ExibeModelo3D()
        {
            Debug.WriteLine("--> Importando o modelo 3D...");

            //Path to the model file
            //private const string MODEL_PATH = "C:\\Users\\Felipe\\Documents\\Dev\\UDT\\Acelerometro\\RotationCubeExample\\RotationCubeExample\\adxl345.obj";
            const string MODEL_PATH = "C:\\Users\\Felipe\\Documents\\Dev\\UDT\\Acelerometro\\RotationCubeExample\\RotationCubeExample\\Models\\GY91\\gy_91.obj";

            // Instanciando um novo objeto 'device3D' do tipo 'ModelVisual3D'
            ModelVisual3D device3D = new ModelVisual3D();

            // Através do método 'Display3d', é adicionado como conteúdo o arquivo do modelo 3D (.obj)
            device3D.Content = Display3d(MODEL_PATH);

            // Instancia um novo objeto 'viewPort3D'
            //HelixViewport3D viewPort3d = new HelixViewport3D();

            // Adiciona o modelo 3D á viewPort
            // 'viewPort3d' é o nome da 'helix:HelixViewport3D x:Name="viewPort3d"' no xaml
            viewPort3d.Children.Add(device3D);

        }

        // Carrega o modelo 3D
        private Model3D Display3d(string model)
        {
            Model3D device = null;

            try
            {
                //Adding a gesture here
                //viewPort3d.RotateGesture = new MouseGesture(MouseAction.LeftClick);

                //Import 3D model file
                ModelImporter import = new ModelImporter();

                //Load the 3D model file
                device = import.Load(model);


            }
            catch (Exception e)
            {
                // Handle exception in case can not file 3D model
                MessageBox.Show("Ocorreu um erro na importação do objeto 3D: " + e.StackTrace);

                // Sends a message notification
                showSnackBarMessage(3, "Theres something wrong with the 3D object loading!");
            }

            Debug.WriteLine("--> O modelo 3D foi importado corretamente.");

            // Exibe a mensagem de carregando objeto 3D por 5 segundos
            showSnackBarMessage(3, "The 3D object was successfully loaded.");

            return device;
        }

        private void RotateCamera(double x, double y, double z)
        {
            var rotation = new Transform3DGroup();
            rotation.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(1, 0, 0), x)));
            rotation.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), y)));
            //rotation.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), z)));

            var translation = new TranslateTransform3D(0, 0, z);
            rotation.Children.Add(translation);

            viewPort3d.Camera.Transform = rotation;
        }

        private void showSnackBarMessage(int duration, string messageContent)
        {
            SnackbarSeven.MessageQueue?.Enqueue(
                $"{messageContent}",
                null,
                null,
                null,
                false,
                true,
                TimeSpan.FromSeconds(duration));
        }
    }
}
