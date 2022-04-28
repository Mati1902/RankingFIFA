using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RankingFigaV2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        
        public string[] textabc = System.IO.File.ReadAllLines(@"D:\Gry\Generally REPR\RankingV2.txt");
        double liczba_panstw = System.IO.File.ReadAllLines(@"D:\Gry\Generally REPR\RankingV2.txt").Length;
        public string[,] bez_znaczka = new string[System.IO.File.ReadAllLines(@"D:\Gry\Generally REPR\RankingV2.txt").Length,15];       
        public string[] x;  //tablica zawierająca linijke tekstu (każdą po kolei w pętli). poszczególne wyrazy to poszczególne iteracje
        public string nazwa_druz;
        public double obecne_punkty;
        public int ostatni_mecz;
        public double[] tablica_wynikow;
        public string zmienna_testowa;
        public int format;        
        public double pozycja_w_locie;
        //drużyna 1
        public object druz1;
        public string druz1_str;
        public string[] subs1;
        public double ilosc_punktow1;
        public string nazwa_panstwa1;
        public int wart_porz1;
        public double[] wartosci_punktowe1 = new double[12];
        public double obecnie_ostatni_mecz1;
        public int wynik1;
        public double nowa_wartosc_w_rank1;
        //drużyna 2
        public object druz2;
        public string druz2_str;
        public string[] subs2;
        public double ilosc_punktow2;
        public string nazwa_panstwa2;
        public int wart_porz2;
        public double[] wartosci_punktowe2 = new double[12];
        public double obecnie_ostatni_mecz2;
        public int wynik2;
        public double nowa_wartosc_w_rank2;


        private void button1_Click(object sender, EventArgs e)
        {
            Array.Sort(textabc);
            Array.Reverse(textabc);
            for (int i = 0; i < liczba_panstw; i++) 
            {
                x = textabc[i].Split('|');                
                for (int j = 0; j <= 14; j++)
                {
                    bez_znaczka[i, j] = x[j];                                
                }
            }
            if (zmienna_testowa is null)
            {            
                for (int i = 0; i < liczba_panstw; i++)
                {               
                    comboBox1.Items.Add(Regex.Replace(bez_znaczka[i,1], @"\d", ""));
                    comboBox2.Items.Add(Regex.Replace(bez_znaczka[i,1], @"\d", ""));
                }
                for (int i = 0; i < liczba_panstw; i++)
                {
                    
                }
                zmienna_testowa = "0";
            }
            else
            {
                MessageBox.Show("Ranking już załadowany!");
            }
            listBox1.Items.Clear();
            for (int i = 0; i < liczba_panstw; i++)
            {
                listBox1.Items.Add(
                      bez_znaczka[i, 0] + "  " 
                    + bez_znaczka[i, 1] + "  "
                    + bez_znaczka[i, 2] + "     "
                    + bez_znaczka[i, 3] + "  "
                    + bez_znaczka[i, 4] + "  "
                    + bez_znaczka[i, 5] + "  "
                    + bez_znaczka[i, 6] + "  "
                    + bez_znaczka[i, 7] + "  "
                    + bez_znaczka[i, 8] + "  "
                    + bez_znaczka[i, 9] + "  "
                    + bez_znaczka[i, 10] + "  "
                    + bez_znaczka[i, 11] + "  "
                    + bez_znaczka[i, 12] + "  "
                    + bez_znaczka[i, 13] + "  "
                    + bez_znaczka[i, 14] + "  "
                    );
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            druz1 = comboBox1.SelectedItem;
            druz1_str = Convert.ToString(druz1);
            for (int i = 0; i < liczba_panstw; i++)
            {
                if (druz1_str == bez_znaczka[i,1])
                {                    
                    pozycja_w_locie = i + 1;
                    subs1 = textabc[i].Split('|');
                    ilosc_punktow1 = Convert.ToDouble(bez_znaczka[i,0]);
                    nazwa_panstwa1 = bez_znaczka[i,1];
                    wart_porz1 = Convert.ToInt16(bez_znaczka[i, 2]);
                    textBox1.Text = Convert.ToString(Convert.ToString(pozycja_w_locie));
                    textBox3.Text = Convert.ToString(ilosc_punktow1);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            druz2 = comboBox2.SelectedItem;
            druz2_str = Convert.ToString(druz2);
            for (int i = 0; i < liczba_panstw; i++)
            {
                if (druz2_str == bez_znaczka[i, 1])
                {
                    
                    pozycja_w_locie = i + 1;
                    subs2 = textabc[i].Split('|');
                    ilosc_punktow2 = Convert.ToDouble(bez_znaczka[i,0]);
                    nazwa_panstwa2 = bez_znaczka[i,1];
                    wart_porz2 = Convert.ToInt16(bez_znaczka[i, 2]);
                    textBox2.Text = Convert.ToString(Convert.ToString(pozycja_w_locie));
                    textBox4.Text = Convert.ToString(ilosc_punktow2);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                wynik1 = 3;
                wynik2 = 0;
                checkBox2.Checked = false;  //checkbox2 zostaje ODZNACZONY
                checkBox3.Checked = false;  //checkbox3 zostaje ODZNACZONY
                checkBox4.Checked = false;  //checkbox4 zostaje ODZNACZONY
                checkBox5.Checked = false;  //checkbox5 zostaje ODZNACZONY
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                wynik1 = 2;
                wynik2 = 1;
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                wynik1 = 1;
                wynik2 = 1;
                checkBox1.Checked = false; 
                checkBox2.Checked = false; 
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                wynik1 = 1;
                wynik2 = 2;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox5.Checked = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                wynik1 = 0;
                wynik2 = 3;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                format = 1;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                format = 2;
                checkBox6.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                format = 3;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                format = 4;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //obsługa wyjątków
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Nie załadowano RANKINGU!");
            }

            else if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Nie wybrano drużyn(y)!");
            }

            else if (druz1 == druz2)
            {
                MessageBox.Show("Wybrano te same drużyny!");
            }

            else if ((checkBox1.Checked == false &&
                checkBox2.Checked == false &&
                checkBox3.Checked == false &&
                checkBox4.Checked == false &&
                checkBox5.Checked == false) ||
                (checkBox6.Checked == false &&
                checkBox7.Checked == false &&
                checkBox8.Checked == false &&
                checkBox9.Checked == false))
            {
                MessageBox.Show("Nie wybrano wyniku i/lub formatu!");
            }

            //koniec obsługi wyjątków
            else
            {
                
                for (int i = 0; i< liczba_panstw; i++)
                {
                    for (int j = 0; j<15; j++)
                    {
                        bez_znaczka[i, j] = bez_znaczka[i, j];
                    }
                }

                label10.Text = druz1_str;
                label12.Text = druz2_str;
                int miejsce1 = Convert.ToInt16(textBox1.Text);
                int miejsce2 = Convert.ToInt16(textBox2.Text);

                if (miejsce1 == 1)
                {
                    double punkty_za_ten_mecz2 = wynik2 * format * 200;
                    textBox6.Text = Convert.ToString(punkty_za_ten_mecz2);
                    bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, Convert.ToInt32(wart_porz2) + 2] = Convert.ToString(punkty_za_ten_mecz2);
                    double nowa_wartosc_czastkowa2 = Math.Round(
                        (Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 3]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 4]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 5]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 6]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 7]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 8]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 9]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 10]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 11]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 12]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 13]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 14])) / 12);

                    bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 0] = Convert.ToString(nowa_wartosc_czastkowa2);
                    int zmienna_meczu = Convert.ToInt16(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 2]);
                    if (zmienna_meczu < 12)
                    {
                        int zmiennaplus = zmienna_meczu + 1;
                        string zmiennaplus_str = Convert.ToString(zmiennaplus);
                        if (zmiennaplus_str.Length < 2)
                        {
                            zmiennaplus_str = "000" + zmiennaplus_str;
                        }
                        if (zmiennaplus_str.Length == 2)
                        {
                            zmiennaplus_str = "00" + zmiennaplus_str;
                        }
                        bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 2] = zmiennaplus_str;
                    }
                    else
                    {
                        int zmiennaplus = 1;
                        string zmiennaplus_str = Convert.ToString(zmiennaplus);
                        bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 2] = zmiennaplus_str;
                    }                    
                    textBox8.Text = Convert.ToString(nowa_wartosc_czastkowa2);              
                }

                if (miejsce1 > 1)
                {
                    double punkty_za_ten_mecz2 = wynik2 * format * (200 - miejsce1);
                    textBox6.Text = Convert.ToString(punkty_za_ten_mecz2);
                    bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, Convert.ToInt32(wart_porz2) + 2] = Convert.ToString(punkty_za_ten_mecz2);
                    double nowa_wartosc_czastkowa2 = Math.Round(
                        (Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 3]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 4]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 5]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 6]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 7]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 8]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 9]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 10]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 11]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 12]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 13]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 14])) / 12);

                    bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 0] = Convert.ToString(nowa_wartosc_czastkowa2);
                    textBox8.Text = Convert.ToString(nowa_wartosc_czastkowa2);
                    int zmienna_meczu = Convert.ToInt16(bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 2]);
                    if (zmienna_meczu < 12)
                    {
                        int zmiennaplus = zmienna_meczu + 1;
                        string zmiennaplus_str = Convert.ToString(zmiennaplus);
                        if (zmiennaplus_str.Length < 2)
                        {
                            zmiennaplus_str = "000" + zmiennaplus_str;
                        }
                        if (zmiennaplus_str.Length == 2)
                        {
                            zmiennaplus_str = "00" + zmiennaplus_str;
                        }
                        bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 2] = zmiennaplus_str;
                    }
                    else
                    {
                        int zmiennaplus = 1;
                        string zmiennaplus_str = Convert.ToString(zmiennaplus);
                        if (zmiennaplus_str.Length < 2)
                        {
                            zmiennaplus_str = "000" + zmiennaplus_str;
                        }
                        if (zmiennaplus_str.Length == 2)
                        {
                            zmiennaplus_str = "00" + zmiennaplus_str;
                        }
                        bez_znaczka[Convert.ToInt32(textBox2.Text) - 1, 2] = zmiennaplus_str;
                    }
                }

                if (miejsce2 == 1)
                {
                    double punkty_za_ten_mecz1 = wynik1 * format * 200;
                    textBox5.Text = Convert.ToString(punkty_za_ten_mecz1);
                    bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, Convert.ToInt32(wart_porz1) + 2] = Convert.ToString(punkty_za_ten_mecz1);
                    double nowa_wartosc_czastkowa1 = Math.Round(
                        (Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 3]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 4]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 5]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 6]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 7]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 8]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 9]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 10]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 11]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 12]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 13]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 14])) / 12);

                    bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 0] = Convert.ToString(nowa_wartosc_czastkowa1);
                    textBox7.Text = Convert.ToString(nowa_wartosc_czastkowa1);

                    int zmienna_meczu = Convert.ToInt16(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 2]);
                    if (zmienna_meczu < 12)
                    {
                        int zmiennaplus = zmienna_meczu + 1;
                        string zmiennaplus_str = Convert.ToString(zmiennaplus);
                        if (zmiennaplus_str.Length < 2)
                        {
                            zmiennaplus_str = "000" + zmiennaplus_str;
                        }
                        if (zmiennaplus_str.Length == 2)
                        {
                            zmiennaplus_str = "00" + zmiennaplus_str;
                        }
                        bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 2] = zmiennaplus_str;
                    }
                    else
                    {
                        int zmiennaplus = 1;
                        string zmiennaplus_str = Convert.ToString(zmiennaplus);
                        bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 2] = zmiennaplus_str;
                    }
                    
                }

                if (miejsce2 > 1)
                {
                    double punkty_za_ten_mecz1 = wynik1 * format * (200 - miejsce2);
                    textBox5.Text = Convert.ToString(punkty_za_ten_mecz1);
                    bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, Convert.ToInt32(wart_porz1) + 2] = Convert.ToString(punkty_za_ten_mecz1);
                    double nowa_wartosc_czastkowa1 = Math.Round(
                        (Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 3]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 4]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 5]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 6]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 7]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 8]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 9]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 10]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 11]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 12]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 13]) +
                        Convert.ToDouble(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 14])) / 12);

                    bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 0] = Convert.ToString(nowa_wartosc_czastkowa1);
                    textBox7.Text = Convert.ToString(nowa_wartosc_czastkowa1);

                    int zmienna_meczu = Convert.ToInt16(bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 2]);
                    if (zmienna_meczu < 12)
                    {
                        int zmiennaplus = zmienna_meczu + 1;
                        string zmiennaplus_str = Convert.ToString(zmiennaplus);
                        if (zmiennaplus_str.Length < 2)
                        {
                            zmiennaplus_str = "000" + zmiennaplus_str;
                        }
                        if (zmiennaplus_str.Length == 2)
                        {
                            zmiennaplus_str = "00" + zmiennaplus_str;
                        }
                        bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 2] = zmiennaplus_str;
                    }
                    else
                    {
                        int zmiennaplus = 1;
                        string zmiennaplus_str = Convert.ToString(zmiennaplus);
                        bez_znaczka[Convert.ToInt32(textBox1.Text) - 1, 2] = zmiennaplus_str;
                    }
                }
                listBox1.Items.Clear();
                
                
                

                string[] nowa_lista = new string[System.IO.File.ReadAllLines(@"D:\Gry\Generally REPR\RankingV2.txt").Length];
                for (int i = 0; i < liczba_panstw; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (bez_znaczka[i, j].Length == 1)
                        {
                            bez_znaczka[i, j] = "000" + bez_znaczka[i, j];
                        }
                        else if (bez_znaczka[i, j].Length == 2)
                        {
                            bez_znaczka[i, j] = "00" + bez_znaczka[i, j];
                        }
                        else if (bez_znaczka[i, j].Length == 3)
                        {
                            bez_znaczka[i, j] = "0" + bez_znaczka[i, j];
                        }
                    }
                    nowa_lista[i] = (
                        bez_znaczka[i, 0] + "  " +
                        bez_znaczka[i, 1] + "  " +
                        bez_znaczka[i, 2] + "     " +
                        bez_znaczka[i, 3] + "  " +
                        bez_znaczka[i, 4] + "  " +
                        bez_znaczka[i, 5] + "  " +
                        bez_znaczka[i, 6] + "  " +
                        bez_znaczka[i, 7] + "  " +
                        bez_znaczka[i, 8] + "  " +
                        bez_znaczka[i, 9] + "  " +
                        bez_znaczka[i, 10] + "  " +
                        bez_znaczka[i, 11] + "  " +
                        bez_znaczka[i, 12] + "  " +
                        bez_znaczka[i, 13] + "  " +
                        bez_znaczka[i, 14] + "  "
                        );
                }
                Array.Sort(nowa_lista);
                Array.Reverse(nowa_lista);

                string[] bez_znaczka1d = new string[System.IO.File.ReadAllLines(@"D:\Gry\Generally REPR\RankingV2.txt").Length];
                for (int i = 0; i < liczba_panstw; i++)
                {
                    bez_znaczka1d[i] =
                        bez_znaczka[i, 0] + "|" +
                        bez_znaczka[i, 1] + "|" +
                        bez_znaczka[i, 2] + "|" +
                        bez_znaczka[i, 3] + "|" +
                        bez_znaczka[i, 4] + "|" +
                        bez_znaczka[i, 5] + "|" +
                        bez_znaczka[i, 6] + "|" +
                        bez_znaczka[i, 7] + "|" +
                        bez_znaczka[i, 8] + "|" +
                        bez_znaczka[i, 9] + "|" +
                        bez_znaczka[i, 10] + "|" +
                        bez_znaczka[i, 11] + "|" +
                        bez_znaczka[i, 12] + "|" +
                        bez_znaczka[i, 13] + "|" +
                        bez_znaczka[i, 14] + "|";
                }
                Array.Sort(bez_znaczka1d);
                Array.Reverse(bez_znaczka1d);
                for (int i = 0; i < liczba_panstw; i++)
                {
                    string[] rozbita_linijka = bez_znaczka1d[i].Split('|');
                    for (int j = 0; j < 15; j++)
                    {
                        bez_znaczka[i, j] = rozbita_linijka[j];
                    }
                }

                for (int i = 0; i < liczba_panstw; i++)
                {                 
                        listBox1.Items.Add(nowa_lista[i]);
                }
                for (int i = 0; i < liczba_panstw; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        bez_znaczka[i, j] = bez_znaczka[i, j];
                    }
                }

                string[] zapisSTR_tabl = new string[System.IO.File.ReadAllLines(@"D:\Gry\Generally REPR\RankingV2.txt").Length];
                string zapisSTR = "";
                for (int i = 0; i < liczba_panstw; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        zapisSTR += bez_znaczka[i, j] + "|";
                    }
                    zapisSTR += "\r\n";
                }               
                System.IO.File.WriteAllText(@"D:\Gry\Generally REPR\RankingV2.txt", zapisSTR);
            }
        }
    }
}
