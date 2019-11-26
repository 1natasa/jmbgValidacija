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

            bool tacnost = false; 
            bool tacnost1 = false; 
            bool tacnost2 = false; 
            bool tacnost3 = false;
            bool tacnost4 = false;
            bool tacnost5 = false;
            
            try
            {

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
                long jmbgVr = Int64.Parse(txtBjmbgVrednost.Text);
                long dd = jmbgVr / 100000000000;
                long ostatak = jmbgVr % 100000000000;
                string opstina = "";
                string regija = "";

                lblDanJ.Content = dd.ToString();
                Console.WriteLine("Dan " + dd);
                Console.WriteLine("Ostatak " + ostatak);

                long mm = ostatak / 1000000000;
                ostatak = ostatak % 1000000000;


                Console.WriteLine("Mesec " + mm);
                Console.WriteLine("Ostatak " + ostatak);

                long ggg = ostatak / 1000000;
                if (ggg <= 100)
                {
                    ggg = 2000 + ggg;
                }
                else {
                    ggg = 1000 + ggg;
                }
                
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

                //cifre za kontrolnu cifru   ABVGDĐEŽZIJKL

                long ostatak2;

                long a = jmbgVr / 1000000000000;
                ostatak2 = jmbgVr % 1000000000000;

                long b = ostatak2 / 100000000000;
                ostatak2 = ostatak2 % 100000000000;

                long v = ostatak2 / 10000000000;
                ostatak2 = ostatak2 % 10000000000;

                long g = ostatak2 / 1000000000;
                ostatak2 = ostatak2 % 1000000000;

                long d = ostatak2 / 100000000;
                ostatak2 = ostatak2 % 100000000;

                long dj = ostatak2 / 10000000;
                ostatak2 = ostatak2 % 10000000;

                long e1 = ostatak2 / 1000000;
                ostatak2 = ostatak2 % 1000000;

                long zj = ostatak2 / 100000;
                ostatak2 = ostatak2 % 100000;

                long z = ostatak2 / 10000;
                ostatak2 = ostatak2 % 10000;

                long i = ostatak2 / 1000;
                ostatak2 = ostatak2 % 1000;

                long j = ostatak2 / 100;
                ostatak2 = ostatak2 % 100;

                long k1 = ostatak2 / 10;
                ostatak2 = ostatak2 / 10;

                long l = ostatak2;

                long formula = 11 - ((7 * (a + e1) + 6 * (b + zj) + 5 * (v + z) + 4 * (g + i) + 3 * (d + j) + 2 * (dj + k1)) % 11);
                Console.WriteLine("Formula : " + formula);

                if (txtBoxIme.Text.Length < 1 || txtBoxPrezime.Text.Length < 1 || txtBjmbgVrednost.Text.Length < 1)
                {

                    MessageBox.Show("Popunite sva polja!");
                    tacnost5 = false;

                }
                else
                {
                    tacnost5 = true;
                }
                if (txtBjmbgVrednost.Text.Length != 13)
                {
                    MessageBox.Show("Jmbg mora da ima 13 cifara");
                    tacnost = false;
                    return;
                }

                if (ggg >2019)
                {
                    MessageBox.Show("Godina ne sme da bude veca od 2019");
                    tacnost4 = false;
                    return;

                }
                else
                {
                    tacnost4 = true;
                }


                if (ggg % 4 == 0)
                {
                    if (ggg % 100 != 0 || ggg % 400 == 0)
                    {
                        //prestupna
                        switch (mm)
                        {
                            case 1: case 3: case 5: case 7: case 8: case 10: case 12: if (dd > 31) { MessageBox.Show("Ovaj mesec ne sme da ima vise od 31 dan"); tacnost1 = false; return; } else { tacnost1 = true; }; break;
                            case 4: case 6: case 9: case 11: if (dd > 30) { MessageBox.Show("Ovaj mesec ne sme da ima vise od 30 dana"); tacnost1 = false; return; } else { tacnost1 = true; }; break;
                            case 2:
                                if (dd > 29)
                                {
                                    MessageBox.Show("Februar ne sme da ima vise od 29 dana");
                                    tacnost1 = false;
                                    return;
                                }
                                else { tacnost1 = true; }; break;
                            default: MessageBox.Show("Datum nije validan"); tacnost1 = false; break;
                        }

                    }
                    else
                    {
                        //nije prestupna
                        switch (mm)
                        {
                            case 1:
                            case 3:
                            case 5:
                            case 7:
                            case 8:
                            case 10:
                            case 12:
                                if (dd > 31)
                                {
                                    MessageBox.Show("Ovaj mesec ne sme da ima vise od 31 dan"); tacnost1 = false; return;
                                }
                                else { tacnost1 = true; }; break;
                            case 4:
                            case 6:
                            case 9:
                            case 11:
                                if (dd > 30)
                                {
                                    MessageBox.Show("Ovaj mesec ne sme da ima vise od 30 dana");

                                    tacnost1 = false;
                                    return;
                                }
                                else { tacnost1 = true; }
                                break;
                            case 2:
                                if (dd > 28)
                                {
                                    MessageBox.Show("Februar ne sme da ima vise od 28 dana"); tacnost1 = false; return;
                                }
                                else { tacnost1 = true; }; break;
                            default: MessageBox.Show("Datum nije validan"); tacnost1 = false; break;
                        }
                    }

                }
                else
                {
                    //nije prestupna
                    switch (mm)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 8:
                        case 10:
                        case 12:
                            if (dd > 31)
                            {
                                MessageBox.Show("Ovaj mesec ne sme da ima vise od 31 dan");
                                tacnost1 = false;
                                return;
                            }
                            else { tacnost1 = true; }; break;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            if (dd > 30)
                            {
                                MessageBox.Show("Ovaj mesec ne sme da ima vise od 30 dana");
                                tacnost1 = false;
                                return;
                            }
                            else { tacnost1 = true; }
                            break;
                        case 2:
                            if (dd > 28)
                            {
                                MessageBox.Show("Februar ne sme da ima vise od 28 dana");
                                tacnost1 = false;
                                return;
                            }
                            else { tacnost1 = true; }; break;
                        default: MessageBox.Show("Datum nije validan"); tacnost1 = false; break;
                    }

                }

                lblDanJ.Content = dd;
                lblMesecJ.Content = mm;
                lblGodinaJ.Content = ggg;

                //opstina
                switch (rr)
                {
                    case 1:
                        opstina = "stranci u BiH";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        tacnost = true;
                        break;
                    case 2:
                        opstina = "stranci u Crnoj Gori";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        tacnost = true;
                        break;
                    case 3:
                        opstina = "stranci u Hrvatskoj";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        break;
                    case 4:
                        opstina = "stranci u Makedoniji";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        tacnost = true;
                        break;
                    case 5:
                        opstina = "stranci u Sloveniji";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        tacnost = true;
                        break;
                    case 7:
                        opstina = "stranci u  Srbiji (bez pokrajina)";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        tacnost = true;
                        break;
                    case 8:
                        opstina = "stranci u Vojvodini";

                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        tacnost = true;
                        break;
                    case 9:
                        opstina = "stranci na Kosovu i Metohiji";
                        regija = "stranci bez državljanstva bivše SFRJ ili njenih naslednica";
                        tacnost = true;
                        break;
                    case 10:
                        opstina = "Banja Luka";
                        regija = "Bosna i Hercegovina";
                        tacnost = true;
                        break;
                    case 11:
                        opstina = "Bihać";
                        regija = "Bosna i Hercegovina";
                        tacnost = true;
                        break;
                    case 12:
                        opstina = "Doboj";
                        regija = "Bosna i Hercegovina";
                        tacnost = true;
                        break;
                    case 13:
                        opstina = "Goražde";
                        regija = "Bosna i Hercegovina";
                        tacnost = true;
                        break;
                    case 14:
                        opstina = "Livno";
                        regija = "Bosna i Hercegovina";
                        tacnost = true;
                        break;
                    case 15:
                        opstina = "Mostar";
                        regija = "Bosna i Hercegovina";
                        tacnost = true;
                        break;
                    case 16:
                        opstina = "Prijedor";
                        regija = "Bosna i Hercegovina";
                        tacnost = true;
                        break;
                    case 17:
                        opstina = "Sarajevo";
                        regija = "Bosna i Hercegovina";
                        tacnost = true;
                        break;
                    case 18:
                        opstina = "Tuzla";
                        regija = "Bosna i Hercegovina";
                        tacnost = true;
                        break;
                    case 19:
                        opstina = "Zenica";
                        regija = "Bosna i Hercegovina";
                        tacnost = true;
                        break;
                    case 21:
                        opstina = "Podgorica";
                        regija = "Crna Gora";
                        tacnost = true;
                        break;
                    case 26:
                        opstina = "Nikšić";
                        regija = "Crna Gora";
                        tacnost = true;
                        break;
                    case 29:
                        opstina = "Pljevlja";
                        regija = "Crna Gora";
                        tacnost = true;
                        break;
                    case 30:
                        opstina = "Osijek, Slavonija region";
                        tacnost = true;
                        regija = "Hrvatska";
                        break;
                    case 31:
                        opstina = "Bjelovar, Virovitica, Koprivnica, Pakrac, Podravina region";
                        tacnost = true;
                        regija = "Hrvatska";
                        break;
                    case 32:
                        opstina = "Varaždin, Međimurje region";
                        tacnost = true;
                        regija = "Hrvatska";
                        break;
                    case 33:
                        opstina = "Zagreb";
                        regija = "Hrvatska";
                        tacnost = true;
                        break;
                    case 34:
                        opstina = "Karlovac";
                        regija = "Hrvatska";
                        break;
                    case 35:
                        opstina = "Gospić, Lika region";
                        regija = "Hrvatska";
                        tacnost = true;

                        break;
                    case 36:
                        opstina = "Rijeka, Pula, Istra and Primorje region";
                        regija = "Hrvatska";
                        tacnost = true;
                        break;
                    case 37:
                        opstina = "Sisak, Banovina region";
                        regija = "Hrvatska";
                        tacnost = true;
                        break;
                    case 38:
                        opstina = "Split, Zadar, Dubrovnik, Dalmacija region";
                        regija = "Hrvatska";
                        tacnost = true;
                        break;
                    case 39:
                        opstina = "";
                        regija = "Hrvatska";
                        tacnost = true;
                        break;
                    case 41:
                        opstina = "Bitola";
                        regija = "Makedonija";
                        tacnost = true;
                        break;
                    case 42:
                        opstina = "Kumanovo";
                        regija = "Makedonija";
                        tacnost = true;
                        break;
                    case 43:
                        opstina = "Ohrid";
                        regija = "Makedonija";
                        tacnost = true;
                        break;
                    case 44:
                        opstina = "Prilep";
                        regija = "Makedonija";
                        tacnost = true;
                        break;
                    case 45:
                        opstina = "Skoplje";
                        regija = "Makedonija";
                        tacnost = true;
                        break;
                    case 46:
                        opstina = "Strumica";
                        regija = "Makedonija";
                        tacnost = true;
                        break;
                    case 47:
                        opstina = "Tetovo";
                        regija = "Makedonija";
                        tacnost = true;
                        break;
                    case 48:
                        opstina = "Veles";
                        regija = "Makedonija";
                        tacnost = true;
                        break;
                    case 49:
                        opstina = "Štip";
                        regija = "Makedonija";
                        tacnost = true;
                        break;
                    case 50:
                        opstina = "";
                        regija = "Slovenija";
                        tacnost = true;
                        break;
                    case 71:
                        opstina = "Beograd region";
                        regija = "Centralna Srbija";
                        tacnost = true;
                        break;
                    case 72:
                        opstina = "Šumadija";
                        regija = "Centralna Srbija";
                        tacnost = true;
                        break;
                    case 73:
                        opstina = "Niš region";
                        regija = "Centralna Srbija";
                        tacnost = true;
                        break;
                    case 74:
                        opstina = "Južna Morava";
                        regija = "Centralna Srbija";
                        tacnost = true;
                        break;
                    case 75:
                        opstina = "Zaječar";
                        regija = "Centralna Srbija";
                        tacnost = true;
                        break;
                    case 76:
                        opstina = "Podunavlje";
                        regija = "Centralna Srbija";
                        tacnost = true;
                        break;
                    case 77:
                        opstina = "Podrinje i Kolubara";
                        regija = "Centralna Srbija";
                        tacnost = true;
                        break;
                    case 78:
                        opstina = "Kraljevo region";
                        regija = "Centralna Srbija";
                        tacnost = true;
                        break;
                    case 79:
                        opstina = "Užice region";
                        regija = "Centralna Srbija";
                        tacnost = true;
                        break;
                    case 80:
                        opstina = "Novi Sad region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        tacnost = true;
                        break;
                    case 81:
                        opstina = "Sombor region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        tacnost = true;
                        break;
                    case 82:
                        opstina = "Subotica region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        tacnost = true;
                        break;
                    case 85:
                        opstina = "Zrenjanin region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        tacnost = true;
                        break;
                    case 86:
                        opstina = "Pančevo region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        tacnost = true;
                        break;
                    case 87:
                        opstina = "Kikinda region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        tacnost = true;
                        break;
                    case 88:
                        opstina = "Ruma region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        tacnost = true;
                        break;
                    case 89:
                        opstina = "Sremska Mitrovica region";
                        regija = "Autonomna Pokrajina Vojvodina";
                        tacnost = true;
                        break;
                    case 91:
                        opstina = "Priština region";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        tacnost = true;
                        break;
                    case 92:
                        opstina = "Kosovska Mitrovica region";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        tacnost = true;
                        break;
                    case 93:
                        opstina = "Peć region";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        tacnost = true;
                        break;
                    case 94:
                        opstina = "Đakovica region";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        tacnost = true;
                        break;
                    case 95:
                        opstina = "Prizren region";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        tacnost = true;
                        break;
                    case 96:
                        opstina = "Kosovsko Pomoravski okrug";
                        regija = "Autonomna Pokrajina Kosovo i Metohija";
                        tacnost = true;
                        //lblOpstinaJ.Content = opstina;
                        break;
                    default:
                        Console.WriteLine("Nevalidan JMBG. Problem vezan za Regiju."); tacnost = false; break;


                }
                lblOpstinaJ.Content = opstina;
                lblRegijaJ.Content = regija;

                //pol
                if (bbb >= 0 && bbb <= 499)
                {
                    lblPolJ.Content = "musko";
                    tacnost2 = true;
                }
                else if (bbb > 500 && bbb <= 999)
                {
                    lblPolJ.Content = "zensko";
                    tacnost2 = true;

                }
                else
                {
                    MessageBox.Show("Pol nije validan");
                    tacnost2 = false;
                    return;
                }


                //kontrolna cifra


                if (formula >= 1 && formula <= 9)
                {
                    
                    l = formula;
                    
                }
                else if (formula > 9)
                {
                    l = 0;
                    
                }
                 
                if (l == k)
                {
                    
                    tacnost3 = true;
                }
                else
                {
                    MessageBox.Show("Kontrolna cifra nije dobra!");
                    tacnost3 = false;
                }

                Console.WriteLine("Formula :" + formula);
                lblKontrolnaCifraJ.Content = k;

                if (tacnost == true && tacnost1 == true && tacnost2 == true && tacnost3 == true && tacnost4==true && tacnost5==true)
                {
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
                else

                {
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

                

            }
            catch
            {

                MessageBox.Show("Unos određenih podataka nije validan!");
            }
            finally
            {

            }

        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        
        
    }
}
