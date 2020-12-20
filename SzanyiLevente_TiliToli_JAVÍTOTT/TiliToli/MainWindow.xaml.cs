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

namespace TiliToli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Üdvözöljük! Nyomja meg az 'Új játék' gombot a kezdéshez.", "Üdvözöljük");
        }
        int[] allas = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        int[] kesz = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        int lepesek = 0;
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button ezGomb = sender as Button;
            Button nullaGomb = (Button)FindName("Button0");
            var fTav = Math.Abs(ezGomb.Margin.Top - nullaGomb.Margin.Top);
            var vTav = Math.Abs(ezGomb.Margin.Left - nullaGomb.Margin.Left);

            //A tömbben elfoglalt pozició
            int ezGombFelirat = int.Parse(ezGomb.Content.ToString());
            int ezGombIndex = Array.IndexOf(allas, ezGombFelirat);
            int nullaGombIndex = Array.IndexOf(allas, 0);

            if ((fTav == 100 && vTav == 0) || (vTav == 100 && fTav == 0)) {
                var seged = ezGomb.Margin;
                ezGomb.Margin = nullaGomb.Margin;
                nullaGomb.Margin = seged;

                allas[nullaGombIndex] = allas[ezGombIndex];
                allas[ezGombIndex] = 0;

                lepesek++;
                lepesekLabel.Content = lepesek;

                //Mikor lesz vége?
                if (allas.SequenceEqual(kesz))
                {
                    //Mit csináljon ha kész
                    MessageBoxResult result = MessageBox.Show("Gratulálunk! Ön " + lepesek + " lépés alatt rakta ki a puzzle-t. Akarja folytatni a játékot?", "Gratulálunk!", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBox.Show("Nyomja meg az 'Új játék' gombot vagy csak szórakozzon el a puzzle-lal.", "Folytatás");
                        lepesek = 0;
                        lepesekLabel.Content = 0;
                    }
                    else
                    {
                        Application.Current.Shutdown();
                    }
                }
                
            }
        }

        private void ujjatekgomb_Click(object sender, RoutedEventArgs e)
        {
            if (!allas.SequenceEqual(kesz))
            {
                MessageBoxResult result = MessageBox.Show("Biztos vagy benne? Nem fejezted be a puzzle-t.", "Figyelem!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    MessageBox.Show("Rendben. Keverjük a táblát...", "Keverés...");
                    lepesek = 0;
                    lepesekLabel.Content = 0;
                    Random r = new Random();
                    int keveresszam = r.Next(60, 401);
                    for (int i = 0; i < keveresszam;)
                    {
                        int kivalasztott = r.Next(1, 9);
                        Convert.ToString(kivalasztott);
                        Button ezGomb = (Button)FindName("Button" + kivalasztott);
                        Button nullaGomb = (Button)FindName("Button0");
                        var fTav = Math.Abs(ezGomb.Margin.Top - nullaGomb.Margin.Top);
                        var vTav = Math.Abs(ezGomb.Margin.Left - nullaGomb.Margin.Left);

                        int ezGombFelirat = int.Parse(ezGomb.Content.ToString());
                        int ezGombIndex = Array.IndexOf(allas, ezGombFelirat);
                        int nullaGombIndex = Array.IndexOf(allas, 0);

                        if ((fTav == 100 && vTav == 0) || (vTav == 100 && fTav == 0))
                        {
                            var seged = ezGomb.Margin;
                            ezGomb.Margin = nullaGomb.Margin;
                            nullaGomb.Margin = seged;

                            allas[nullaGombIndex] = allas[ezGombIndex];
                            allas[ezGombIndex] = 0;

                            i++;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Rendben. Keverjük a táblát...", "Keverés...");
                lepesek = 0;
                lepesekLabel.Content = 0;
                Random r = new Random();
                int keveresszam = r.Next(60, 401);
                for (int i = 0; i < keveresszam; )
                {
                    int kivalasztott = r.Next(1, 9);
                    Convert.ToString(kivalasztott);
                    Button ezGomb = (Button)FindName("Button" + kivalasztott);
                    Button nullaGomb = (Button)FindName("Button0");
                    var fTav = Math.Abs(ezGomb.Margin.Top - nullaGomb.Margin.Top);
                    var vTav = Math.Abs(ezGomb.Margin.Left - nullaGomb.Margin.Left);

                    int ezGombFelirat = int.Parse(ezGomb.Content.ToString());
                    int ezGombIndex = Array.IndexOf(allas, ezGombFelirat);
                    int nullaGombIndex = Array.IndexOf(allas, 0);

                    if ((fTav == 100 && vTav == 0) || (vTav == 100 && fTav == 0))
                    {
                        var seged = ezGomb.Margin;
                        ezGomb.Margin = nullaGomb.Margin;
                        nullaGomb.Margin = seged;

                        allas[nullaGombIndex] = allas[ezGombIndex];
                        allas[ezGombIndex] = 0;

                        i++;
                    }
                }
            }
        }
    }
}
