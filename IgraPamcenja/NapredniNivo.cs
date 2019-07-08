using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IgraPamcenja
{
    public partial class NapredniNivo : Form
    {
        private Random lokacija = new Random();
        private PictureBox PrvaOtvorenaSlika;
        private PictureBox DrugaOtvorenaSlika;
        private List<Point> tacke = new List<Point>();
        private List<PictureBox> preostale_slike = new List<PictureBox>();

        public NapredniNivo()
        {
            InitializeComponent();
        }

        private void NapredniNivo_Load(object sender, EventArgs e)
        {
            timer1.Start();

            foreach (PictureBox slika in panel1.Controls)
            {
                slika.Enabled = false;
                tacke.Add(slika.Location);
                preostale_slike.Add(slika);
            }

            foreach (PictureBox slika in panel1.Controls)
            {
                int neka_tacka = lokacija.Next(tacke.Count);
                Point p = tacke[neka_tacka];
                slika.Location = p;
                tacke.Remove(p); // da ne bismo opet iskoristili istu tacku
            }

            Kartica1.Image = Properties.Resources.cetvorougao;
            Kartica1Dupl.Image = Properties.Resources.cetvorougao_napredni;
            Kartica2.Image = Properties.Resources.deltoid;
            Kartica2Dupl.Image = Properties.Resources.deltoid_napredni;
            Kartica3.Image = Properties.Resources.krug;
            Kartica3Dupl.Image = Properties.Resources.krug_napredni;
            Kartica4.Image = Properties.Resources.kvadrat;
            Kartica4Dupl.Image = Properties.Resources.kvadrat_napredni;
            Kartica5.Image = Properties.Resources.paralelogram;
            Kartica5Dupl.Image = Properties.Resources.paralelogram_napredni;
            Kartica6.Image = Properties.Resources.pravougaonik;
            Kartica6Dupl.Image = Properties.Resources.pravougaonik_napredni;
            Kartica7.Image = Properties.Resources.romb;
            Kartica7Dupl.Image = Properties.Resources.romb_napredni;
            Kartica8.Image = Properties.Resources.trapezoid;
            Kartica8Dupl.Image = Properties.Resources.trapez_napredni;
            Kartica9.Image = Properties.Resources.trougao;
            Kartica9Dupl.Image = Properties.Resources.trougao_napredni;
        }

        private void DisableImages()
        {
            foreach (PictureBox slika in panel1.Controls)
            {
                slika.Enabled = false;
            }
        }

        private void EnableImages()
        {
            foreach (PictureBox slika in preostale_slike)
            {
                slika.Enabled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NapredniNivo napredniNivo = new NapredniNivo();
            napredniNivo.ShowDialog();
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            foreach (PictureBox slika in panel1.Controls)
            {
                slika.Enabled = true;
                slika.Cursor = Cursors.Hand;
                slika.Image = Properties.Resources.question_mark_jpg;
            }
        }

        private void kartica_logika(PictureBox slika, PictureBox slikaDupl)
        {
            if (PrvaOtvorenaSlika == null)
            {
                PrvaOtvorenaSlika = slika;
                PrvaOtvorenaSlika.Enabled = false;
            }
            else if (DrugaOtvorenaSlika == null)
            {
                DrugaOtvorenaSlika = slika;
                DrugaOtvorenaSlika.Enabled = false;
            }
            if (PrvaOtvorenaSlika != null && DrugaOtvorenaSlika != null)
            {
                if (PrvaOtvorenaSlika.Tag == DrugaOtvorenaSlika.Tag)
                {
                    PrvaOtvorenaSlika = null;
                    DrugaOtvorenaSlika = null;
                    preostale_slike.Remove(slika);
                    preostale_slike.Remove(slikaDupl);
                    EnableImages();
                    if (preostale_slike.Count == 0)
                    {
                        Poruka krajIgre = new Poruka();
                        krajIgre.ShowDialog();
                        this.Hide();
                    }
                }
                else
                {
                    timer2.Start();
                    DisableImages();
                    PrvaOtvorenaSlika.Enabled = true;
                    DrugaOtvorenaSlika.Enabled = true;
                }
            }
        }

        private void Kartica1_Click(object sender, EventArgs e)
        {
            Kartica1.Image = Properties.Resources.cetvorougao;
            kartica_logika(Kartica1, Kartica1Dupl);
        }

        private void Kartica1Dupl_Click(object sender, EventArgs e)
        {
            Kartica1Dupl.Image = Properties.Resources.cetvorougao_napredni;
            kartica_logika(Kartica1Dupl, Kartica1);
        }

        private void Kartica2_Click(object sender, EventArgs e)
        {
            Kartica2.Image = Properties.Resources.deltoid;
            kartica_logika(Kartica2, Kartica2Dupl);
        }

        private void Kartica2Dupl_Click(object sender, EventArgs e)
        {
            Kartica2Dupl.Image = Properties.Resources.deltoid_napredni;
            kartica_logika(Kartica2Dupl, Kartica2);
        }

        private void Kartica3_Click(object sender, EventArgs e)
        {
            Kartica3.Image = Properties.Resources.krug;
            kartica_logika(Kartica3, Kartica3Dupl);
        }

        private void Kartica3Dupl_Click(object sender, EventArgs e)
        {
            Kartica3Dupl.Image = Properties.Resources.krug_napredni;
            kartica_logika(Kartica3Dupl, Kartica3);
        }

        private void Kartica4_Click(object sender, EventArgs e)
        {
            Kartica4.Image = Properties.Resources.kvadrat;
            kartica_logika(Kartica4, Kartica4Dupl);
        }

        private void Kartica4Dupl_Click(object sender, EventArgs e)
        {
            Kartica4Dupl.Image = Properties.Resources.kvadrat_napredni;
            kartica_logika(Kartica4Dupl, Kartica4);
        }

        private void Kartica5_Click(object sender, EventArgs e)
        {
            Kartica5.Image = Properties.Resources.paralelogram;
            kartica_logika(Kartica5, Kartica5Dupl);
        }

        private void Kartica5Dupl_Click(object sender, EventArgs e)
        {
            Kartica5Dupl.Image = Properties.Resources.paralelogram_napredni;
            kartica_logika(Kartica5Dupl, Kartica5);
        }

        private void Kartica6_Click(object sender, EventArgs e)
        {
            Kartica6.Image = Properties.Resources.pravougaonik;
            kartica_logika(Kartica6, Kartica6Dupl);
        }

        private void Kartica6Dupl_Click(object sender, EventArgs e)
        {
            Kartica6Dupl.Image = Properties.Resources.pravougaonik_napredni;
            kartica_logika(Kartica6Dupl, Kartica6);
        }

        private void Kartica7_Click(object sender, EventArgs e)
        {
            Kartica7.Image = Properties.Resources.romb;
            kartica_logika(Kartica7, Kartica7Dupl);
        }

        private void Kartica7Dupl_Click(object sender, EventArgs e)
        {
            Kartica7Dupl.Image = Properties.Resources.romb_napredni;
            kartica_logika(Kartica7Dupl, Kartica7);
        }

        private void Kartica8_Click(object sender, EventArgs e)
        {
            Kartica8.Image = Properties.Resources.trapezoid;
            kartica_logika(Kartica8, Kartica8Dupl);
        }

        private void Kartica8Dupl_Click(object sender, EventArgs e)
        {
            Kartica8Dupl.Image = Properties.Resources.trapez_napredni;
            kartica_logika(Kartica8Dupl, Kartica8);
        }

        private void Kartica9_Click(object sender, EventArgs e)
        {
            Kartica9.Image = Properties.Resources.trougao;
            kartica_logika(Kartica9, Kartica9Dupl);
        }

        private void Kartica9Dupl_Click(object sender, EventArgs e)
        {
            Kartica9Dupl.Image = Properties.Resources.trougao_napredni;
            kartica_logika(Kartica9Dupl, Kartica9);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            EnableImages();
            PrvaOtvorenaSlika.Image = Properties.Resources.question_mark_jpg;
            DrugaOtvorenaSlika.Image = Properties.Resources.question_mark_jpg;
            PrvaOtvorenaSlika = null;
            DrugaOtvorenaSlika = null;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start start = new Start();
            start.ShowDialog();
            this.Close();
        }
    }
}