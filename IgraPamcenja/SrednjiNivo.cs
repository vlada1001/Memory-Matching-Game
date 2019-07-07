using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgraPamcenja
{
    public partial class SrednjiNivo : Form
    {
        Random lokacija = new Random();
        PictureBox PrvaOtvorenaSlika;
        PictureBox DrugaOtvorenaSlika;
        List<Point> tacke = new List<Point>();
        List<PictureBox> preostale_slike = new List<PictureBox>();
        public SrednjiNivo()
        {
            InitializeComponent();
 
        }
        private void SrednjiNivo_Load(object sender, EventArgs e)
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
            slika1.Image = Properties.Resources.cetvorougao;
            slika1dupl.Image = Properties.Resources.cetvorougao_srednji;
            slika2.Image = Properties.Resources.deltoid;
            slika2dupl.Image = Properties.Resources.deltoid_srednji;
            slika3.Image = Properties.Resources.krug;
            slika3dupl.Image = Properties.Resources.krug_srednji;
            slika4.Image = Properties.Resources.kvadrat;
            slika4dupl.Image = Properties.Resources.kvadrat_srednji;
            slika5.Image = Properties.Resources.paralelogram;
            slika5dupl.Image = Properties.Resources.paralelogram_srednji;
            slika6.Image = Properties.Resources.pravougaonik;
            slika6dupl.Image = Properties.Resources.pravougaonik_srednji;
            slika7.Image = Properties.Resources.romb;
            slika7dupl.Image = Properties.Resources.romb_srednji;
            slika8.Image = Properties.Resources.trapezoid;
            slika8dupl.Image = Properties.Resources.trapez_srednji;
            slika9.Image = Properties.Resources.trougao;
            slika9dupl.Image = Properties.Resources.trougao_srednji;
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
            Start start = new Start();
            start.ShowDialog();
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
        private void kartica_logika(PictureBox slika, PictureBox slikaDupl) {
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
                    if (preostale_slike.Count == 0) {
                        MessageBox.Show("Честитамо!");

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
        private void Slika1_Click(object sender, EventArgs e)
        {
            slika1.Image = Properties.Resources.cetvorougao;
            kartica_logika(slika1, slika1dupl);
        }

        private void Slika1dupl_Click(object sender, EventArgs e)
        {
            slika1dupl.Image = Properties.Resources.cetvorougao_srednji;
            kartica_logika(slika1dupl, slika1);
        }

        private void Slika2_Click(object sender, EventArgs e)
        {
            slika2.Image = Properties.Resources.deltoid;
            kartica_logika(slika2, slika2dupl);
        }

        private void Slika2dupl_Click(object sender, EventArgs e)
        {
            slika2dupl.Image = Properties.Resources.deltoid_srednji;
            kartica_logika(slika2dupl, slika2);
        }

        private void Slika3_Click(object sender, EventArgs e)
        {
            slika3.Image = Properties.Resources.krug;
            kartica_logika(slika3, slika3dupl);
        }

        private void Slika3dupl_Click(object sender, EventArgs e)
        {
            slika3dupl.Image = Properties.Resources.krug_srednji;
            kartica_logika(slika3dupl, slika3);
        }

        private void Slika4_Click(object sender, EventArgs e)
        {
            slika4.Image = Properties.Resources.kvadrat;
            kartica_logika(slika4,slika4dupl);
        }

        private void Slika4dupl_Click(object sender, EventArgs e)
        {
            slika4dupl.Image = Properties.Resources.kvadrat_srednji;
            kartica_logika(slika4dupl, slika4);
        }

        private void Slika5_Click(object sender, EventArgs e)
        {
            slika5.Image = Properties.Resources.paralelogram;
            kartica_logika(slika5, slika5dupl);
        }

        private void Slika5dupl_Click(object sender, EventArgs e)
        {
            slika5dupl.Image = Properties.Resources.paralelogram_srednji;
            kartica_logika(slika5dupl, slika5);
        }

        private void Slika6_Click(object sender, EventArgs e)
        {
            slika6.Image = Properties.Resources.pravougaonik;
            kartica_logika(slika6, slika6dupl);
        }

        private void Slika6dupl_Click(object sender, EventArgs e)
        {
            slika6dupl.Image = Properties.Resources.pravougaonik_srednji;
            kartica_logika(slika6dupl, slika6);
        }

        private void Slika7_Click(object sender, EventArgs e)
        {
            slika7.Image = Properties.Resources.romb;
            kartica_logika(slika7, slika7dupl);
        }

        private void Slika7dupl_Click(object sender, EventArgs e)
        {
            slika7dupl.Image = Properties.Resources.romb_srednji;
            kartica_logika(slika7dupl, slika7);
        }

        private void Slika8_Click(object sender, EventArgs e)
        {
            slika8.Image = Properties.Resources.trapezoid;
            kartica_logika(slika8, slika8dupl);
        }

        private void Slika8dupl_Click(object sender, EventArgs e)
        {
            slika8dupl.Image = Properties.Resources.trapez_srednji;
            kartica_logika(slika8dupl, slika8);
        }

        private void Slika9_Click(object sender, EventArgs e)
        {
            slika9.Image = Properties.Resources.trougao;
            kartica_logika(slika9, slika9dupl);
        }

        private void Slika9dupl_Click(object sender, EventArgs e)
        {
            slika9dupl.Image = Properties.Resources.trougao_srednji;
            kartica_logika(slika9dupl, slika9);
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
            SrednjiNivo srednjiNivo = new SrednjiNivo();
            srednjiNivo.ShowDialog();
            this.Close();
        }
    }
}
