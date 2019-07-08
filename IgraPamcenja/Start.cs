using System.Windows.Forms;

namespace IgraPamcenja
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            OsnovniNivo osnovniNivo = new OsnovniNivo();
            osnovniNivo.ShowDialog();
            this.Close();
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            SrednjiNivo srednjiNivo = new SrednjiNivo();
            srednjiNivo.ShowDialog();
            this.Close();
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            NapredniNivo napredniNivo = new NapredniNivo();
            napredniNivo.ShowDialog();
            this.Close();
        }

        private void Start_Load(object sender, System.EventArgs e)
        {
        }
    }
}