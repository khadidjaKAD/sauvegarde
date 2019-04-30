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
using System.Runtime.Serialization; //
using System.Runtime.Serialization.Formatters.Binary; //
using System.IO; //
using Microsoft.Win32; //

namespace testSave
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary> 


    public partial class MainWindow : Window
    {
        Container cont;
        File f, ff,fclone;
        public MainWindow()
        {
            InitializeComponent();
            Processus P1 = new Processus("P1",100,true,0);
            Processus P2 = new Processus("P2", 50,true,100);
            Processus P3 = new Processus("P3", 150, false, 150);
            cont = new Container();
            cont.Mem.mem.Add(P1);
            cont.Mem.mem.Add(P2);
            cont.Mem.mem.Add(P3);
            f = new File("file");
            ff = new File("ffile");
            cont.files.Add(f);
            cont.files.Add(ff);

            datagrid.ItemsSource = cont.Mem.mem;
            datagrid1.ItemsSource = cont.files;

        }

        private void click1(object sender, RoutedEventArgs e)
        {
            datagrid.ItemsSource = null;
             datagrid1.ItemsSource = null;

            cont.Mem.mem.RemoveAt(1);
            cont.Mem.mem.Add(new Processus("P4", 20, true, 250));

            cont.files.RemoveAt(1);

            datagrid.ItemsSource = cont.Mem.mem;
            datagrid1.ItemsSource = cont.files;
        }

        private void click2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = @"C:\Users\Slash\Documents\khadidja\etudes\2CPI\projet S2\testSave\testSave";
            saveFileDialog.Filter = "fichier de simulation (*.mem)|*.mem";
            saveFileDialog.Title = "Sauvegarder ";
            if (saveFileDialog.ShowDialog() == true)
            {
                IFormatter formatter = new BinaryFormatter();  // c'est celui qui s'occupe du format : binary / xml / soap ...
                Stream stream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write); // le flux d'E/S 
                formatter.Serialize(stream, cont); // la sauvegarde
                stream.Close(); // fermeture du flux
            }
        }

        private void click3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\Slash\Documents";
            openFileDialog.Filter = "fichier de simulation (*.mem)|*.mem";
            openFileDialog.Title = "Ouvrir";
            if (openFileDialog.ShowDialog() == true)
            {
                datagrid.ItemsSource = null;
                datagrid1.ItemsSource = null;
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                cont = (Container)formatter.Deserialize(stream); // la recuperation
                stream.Close();
                datagrid.ItemsSource = cont.Mem.mem;
                datagrid1.ItemsSource = cont.files;
            }


            /* datagrid.ItemsSource = null;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C:\\Users\\Slash\\Documents\\khadidja\\etudes\\2CPI\\projet S2\\testSave\\testSave\\Save.mem", FileMode.Open, FileAccess.Read);
            Mem = (Memoire)formatter.Deserialize(stream); // la recuperation
            datagrid.ItemsSource = Mem.mem;*/
        }
    }

    [Serializable]
    public class Container
    {
        public Memoire Mem;
        public List<File> files;

        public Container()
        {
            Mem = new Memoire(300);
            files = new List<File>();
        }

    }
}
