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

namespace JmbgValidacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtBoxIme.Focus();

            lblDan.Visibility = Visibility.Collapsed;
            lblMesec.Visibility = Visibility.Collapsed;
            lblGodina.Visibility = Visibility.Collapsed;
            lblOpstina.Visibility = Visibility.Collapsed;
            lblRegija.Visibility = Visibility.Collapsed;
            lblPol.Visibility = Visibility.Collapsed;
            lblKcifra.Visibility = Visibility.Collapsed;

            lblDanJ.Visibility = Visibility.Collapsed;
            lblMesecJ.Visibility = Visibility.Collapsed;
            lblGodinaJ.Visibility = Visibility.Collapsed;
            lblOpstinaJ.Visibility = Visibility.Collapsed;
            lblRegijaJ.Visibility = Visibility.Collapsed;
            lblPolJ.Visibility = Visibility.Collapsed;
            lblKontrolnaCifraJ.Visibility = Visibility.Collapsed;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {



            //long proba = 1705996815061;
            //Console.Write(proba % 100000000000);
            
            try
            {


                long jmbgVr = Int64.Parse(txtBjmbgVrednost.Text);
                long dd = jmbgVr / 100000000000;
                long ostatak = jmbgVr % 100000000000;
                string opstina="";
                string regija = "";

                lblDanJ.Content = dd.ToString();
                Console.WriteLine("Dan " + dd);
                Console.WriteLine("Ostatak " + ostatak);

                long mm = ostatak / 1000000000;
                ostatak = ostatak % 1000000000;


                Console.WriteLine("Mesec " + mm);
                Console.WriteLine("Ostatak " + ostatak);

                long ggg = ostatak / 1000000;
                ggg = 1000 + ggg;
                ostatak = ostatak % 1000000;

                Console.WriteLine("Godina " + ggg);
                Console.WriteLine("Ostatak " + ostatak);

                long rr = ostatak / 10000;
                ostatak = ostatak % 10000;

                Console.WriteLine("Regija " + rr);
                Console.WriteLine("Ostatak " + ostatak);

                long bbb = ostatak / 10;
                ostatak = ostatak % 10;
                Console.WriteLine("Jedinstveni broj pol " + bbb);
                Console.WriteLine("Ostatak " + ostatak);

                long k = ostatak;
                Console.WriteLine("Kontrolna cifra " + k);






                if (txtBjmbgVrednost.Text.Length != 13)
                {
                    MessageBox.Show("Jmbg mora da ima 13 cifara");
                }
                if (ggg % 4 == 0)
                {
                    if (ggg % 100 != 0 || ggg % 400 == 0)
                    {
                        //prestupna
                        switch (mm)
                        {
                            case 1: case 3: case 5: case 7: case 8: case 10: case 12: if (dd > 31) { lblDanJ.Content = ""; lblMesecJ.Content = ""; lblGodinaJ.Content = ""; MessageBox.Show("Ovaj mesec ne sme da ima vise od 31 dan"); } else { lblDanJ.Content = dd; lblMesecJ.Content = mm; lblGodinaJ.Content = ggg; }; break;
                            case 4: case 6: case 9: case 11: if (dd > 30) { lblDanJ.Content = ""; lblMesecJ.Content = ""; lblGodinaJ.Content = ""; MessageBox.Show("Ovaj mesec ne sme da ima vise od 30 dana"); } else { lblDanJ.Content = dd; lblMesecJ.Content = mm; lblGodinaJ.Content = ggg; }; break;
                            case 2: if (dd > 29)
                                {
                                    lblDanJ.Content = ""; lblMesecJ.Content = ""; lblGodinaJ.Content = ""; MessageBox.Show("Februar ne sme da ima vise od 29 dana");
                                }
                                else { lblDanJ.Content = dd; lblMesecJ.Content = mm; lblGodinaJ.Content = ggg; }; break;
                            default: MessageBox.Show("Datum nije validan"); break;
                        }

                    }
                    else
                    {
                        //nije prestupna
                        switch (mm)
                        {
                            case 1: case 3: case 5: case 7: case 8: case 10: case 12: if (dd > 31) {
                                    lblDanJ.Content = ""; lblMesecJ.Content = ""; lblGodinaJ.Content = ""; MessageBox.Show("Ovaj mesec ne sme da ima vise od 31 dan");
                                } else { lblDanJ.Content = dd; lblMesecJ.Content = mm; lblGodinaJ.Content = ggg; }; break;
                            case 4: case 6: case 9: case 11: if (dd > 30)
                                {
                                    lblDanJ.Content = ""; lblMesecJ.Content = ""; lblGodinaJ.Content = ""; MessageBox.Show("Ovaj mesec ne sme da ima vise od 30 dana");
                                }
                                else { lblDanJ.Content = dd; lblMesecJ.Content = mm; lblGodinaJ.Content = ggg; }
                                break;
                            case 2: if (dd > 28)
                                {
                                    lblDanJ.Content = ""; lblMesecJ.Content = ""; lblGodinaJ.Content = ""; MessageBox.Show("Februar ne sme da ima vise od 28 dana");
                                }
                                else { lblDanJ.Content = dd; lblMesecJ.Content = mm; lblGodinaJ.Content = ggg; }; break;
                            default: MessageBox.Show("Datum nije validan"); break;
                        }
                    }

                }
                else
                {
                    //nije prestupna
                    switch (mm)
                    {
                        case 1:case 3:case 5:case 7:case 8:case 10:case 12:
                            if (dd > 31)
                            {
                                lblDanJ.Content = ""; lblMesecJ.Content = ""; lblGodinaJ.Content = ""; MessageBox.Show("Ovaj mesec ne sme da ima vise od 31 dan");
                            }
                            else { lblDanJ.Content = dd; lblMesecJ.Content = mm; lblGodinaJ.Content = ggg; }; break;
                        case 4:case 6:case 9:case 11:
                            if (dd > 30)
                            {
                                lblDanJ.Content = ""; lblMesecJ.Content = ""; lblGodinaJ.Content = ""; MessageBox.Show("Ovaj mesec ne sme da ima vise od 30 dana");
                            }
                            else { lblDanJ.Content = dd; lblMesecJ.Content = mm; lblGodinaJ.Content = ggg; }
                            break;
                        case 2:
                            if (dd > 28)
                            {
                                lblDanJ.Content = ""; lblMesecJ.Content = ""; lblGodinaJ.Content = ""; MessageBox.Show("Februar ne sme da ima vise od 28 dana");
                            }
                            else { lblDanJ.Content = dd; lblMesecJ.Content = mm; lblGodinaJ.Content = ggg; }; break;
                        default: MessageBox.Show("Datum nije validan"); break;
                    }

                }

                //opstina
                switch (rr)
                {
                    case 1:
                        opstina = "stranci u BiH";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        break;
                    case 2:
                        opstina = "stranci u Crnoj Gori";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        break;
                    case 3:
                        opstina = "stranci u Hrvatskoj";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        break;
                    case 4:
                        opstina = "stranci u Makedoniji";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        break;
                    case 5:
                        opstina = "stranci u Sloveniji";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        break;
                    case 7:
                        opstina = "stranci u  Srbiji (bez pokrajina)";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        break;
                    case 8:
                        opstina = "stranci u Vojvodini";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        break;
                    case 9:
                        opstina = "stranci na Kosovu i Metohiji";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        break;
                    case 10:
                        opstina = "Banja Luka";
                        regija = "Bosna i Hercegovina";
                        break;
                    case 11:
                        opstina = "Bihać";
                        regija = "Bosna i Hercegovina";
                        break;
                    case 12:
                        opstina = "Doboj";
                        regija = "Bosna i Hercegovina";
                        break;
                    case 13:
                        opstina = "Goražde";
                        regija = "Bosna i Hercegovina";
                        break;
                    case 14:
                        opstina = "Livno";
                        regija = "Bosna i Hercegovina";
                        break;
                    case 15:
                        opstina = "Mostar";
                        regija = "Bosna i Hercegovina";
                        break;
                    case 16:
                        opstina = "Prijedor";
                        regija = "Bosna i Hercegovina";
                        break;
                    case 17:
                        opstina = "Sarajevo";
                        regija = "Bosna i Hercegovina";
                        break;
                    case 18:
                        opstina = "Tuzla";
                        regija = "Bosna i Hercegovina";
                        break;
                    case 19:
                        opstina = "Zenica";
                        regija = "Bosna i Hercegovina";
                        break;
                    case 21:
                        opstina = "Podgorica";
                        regija = "Crna Gora";
                        break;
                    case 26:
                        opstina = "Nikšić";
                        regija = "Crna Gora";
                        break;
                    case 29:
                        opstina = "Pljevlja";
                        regija = "Crna Gora";
                        break;
                    case 30:
                        opstina = "Osijek, Slavonija region";
                        regija = "Hrvatska";
                        break;
                    case 31:
                        opstina = "Bjelovar, Virovitica, Koprivnica, Pakrac, Podravina region";
                        regija = "Hrvatska";
                        break;
                    case 32:
                        opstina = "Varaždin, Međimurje region";
                        regija = "Hrvatska";
                        break;
                    case 33:
                        opstina = "Zagreb";
                        regija = "Hrvatska";
                        break;
                    case 34:
                        opstina = "Karlovac";
                        regija = "Hrvatska";
                        break;
                    case 35:
                        opstina = "Gospić, Lika region";
                        regija = "Hrvatska";
                        break;
                    case 36:
                        opstina = "Rijeka, Pula, Istra and Primorje region";
                        regija = "Hrvatska";
                        break;
                    case 37:
                        opstina = "Sisak, Banovina region";
                        regija = "Hrvatska";
                        break;
                    case 38:
                        opstina = "Split, Zadar, Dubrovnik, Dalmacija region";
                        regija = "Hrvatska";
                        break;
                    case 39:
                        opstina = "";
                        regija = "Hrvatska";
                        break;
                    case 41:
                        opstina = "Bitola";
                        regija = "Makedonija";
                        break;
                    case 42:
                        opstina = "Kumanovo";
                        regija = "Makedonija";
                        break;
                    case 43:
                        opstina = "Ohrid";
                        regija = "Makedonija";
                        break;
                    case 44:
                        opstina = "Prilep";
                        regija = "Makedonija";
                        break;
                    case 45:
                        opstina = "Skoplje";
                        regija = "Makedonija";
                        break;
                    case 46:
                        opstina = "Strumica";
                        regija = "Makedonija";
                        break;
                    case 47:
                        opstina = "Tetovo";
                        regija = "Makedonija";
                        break;
                    case 48:
                        opstina = "Veles";
                        regija = "Makedonija";
                        break;
                    case 49:
                        opstina = "Štip";
                        regija = "Makedonija";
                        break;
                    case 50:
                        opstina = "";
                        regija = "Slovenija";
                        break;
                    case 71:
                        opstina = "Beograd region";
                        regija = "Centralna Srbija";
                        break;
                    case 72:
                        opstina = "Šumadija";
                        regija = "Centralna Srbija";
                        break;
                    case 73:
                        opstina = "Niš region";
                        regija = "Centralna Srbija";
                        break;
                    case 74:
                        opstina = "Južna Morava";
                        regija = "Centralna Srbija";
                        break;
                    case 75:
                        opstina = "Zaječar";
                        regija = "Centralna Srbija";
                        break;
                    case 76:
                        opstina = "Podunavlje";
                        regija = "Centralna Srbija";
                        break;
                    case 77:
                        opstina = "Podrinje i Kolubara";
                        regija = "Centralna Srbija";
                        break;
                    case 78:
                        opstina = "Kraljevo region";
                        regija = "Centralna Srbija";
                        break;
                    case 79:
                        opstina = "Užice region";
                        regija = "Centralna Srbija";
                        break;
                    case 80:
                        opstina = "Novi Sad region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        break;
                    case 81:
                        opstina = "Sombor region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        break;
                    case 82:
                        opstina = "Subotica region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        break;
                    case 85:
                        opstina = "Zrenjanin region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        break;
                    case 86:
                        opstina = "Pančevo region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        break;
                    case 87:
                        opstina = "Kikinda region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        break;
                    case 88:
                        opstina = "Ruma region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        break;
                    case 89:
                        opstina = "Sremska Mitrovica region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        break;
                    case 91:
                        opstina = "Priština region";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        break;
                    case 92:
                        opstina = "Kosovska Mitrovica region";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        break;
                    case 93:
                        opstina = "Peć region";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        break;
                    case 94:
                        opstina = "Đakovica region";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        break;
                    case 95:
                        opstina = "Prizren region";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        break;
                    case 96:
                        opstina = "Kosovsko Pomoravski okrug";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        //lblOpstinaJ.Content = opstina;
                        break;
                    default:
                        Console.WriteLine("Nevalidan JMBG. Problem vezan za Regiju."); break;
                

                }
                lblOpstinaJ.Content = opstina;
                lblRegijaJ.Content = regija;

               //pol
                if (bbb >= 0 && bbb <= 499)
                {
                    lblPolJ.Content = "musko";
                }
                else if (bbb > 500 && bbb <= 999)
                {
                    lblPolJ.Content = "zensko";
                }
                else
                {
                    MessageBox.Show("Pol nije validan");
                }

                lblDan.Visibility = Visibility.Visible;
                lblMesec.Visibility = Visibility.Visible;
                lblGodina.Visibility = Visibility.Visible;
                lblOpstina.Visibility = Visibility.Visible;
                lblRegija.Visibility = Visibility.Visible;
                lblPol.Visibility = Visibility.Visible;
                lblKcifra.Visibility = Visibility.Visible;

                lblDanJ.Visibility = Visibility.Visible;
                lblMesecJ.Visibility = Visibility.Visible;
                lblGodinaJ.Visibility = Visibility.Visible;
                lblOpstinaJ.Visibility = Visibility.Visible;
                lblRegijaJ.Visibility = Visibility.Visible;
                lblPolJ.Visibility = Visibility.Visible;
                lblKontrolnaCifraJ.Visibility = Visibility.Visible;

            }
            catch {

                MessageBox.Show("Unos određenih podataka nije validan!");
            }
            finally { 
            
            }
         
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
