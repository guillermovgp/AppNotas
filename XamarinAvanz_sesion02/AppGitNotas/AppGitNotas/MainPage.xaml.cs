using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
//Agregar
using System.IO;
using System.Runtime.CompilerServices;

namespace AppGitNotas
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //Obtener el directorio local para almacenar el archivo notas.txt
        string archivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"nota.txt");
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(archivo))
            {
                txteditor.Text = File.ReadAllText(archivo);
            }
        }

        private void btnGrabar_Clicked(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(archivo, txteditor.Text);//Guarda el archivo en esa ruta
                DisplayAlert("Exito", "Archivo grabado con éxito", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(archivo))
            {
                try
                {
                    File.Delete(archivo);
                    txteditor.Text = string.Empty;
                    DisplayAlert("Exito", "Archivo eliminado con éxito", "OK");
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
    }
}
