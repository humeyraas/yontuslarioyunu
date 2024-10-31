using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace yontuslarioyunu
{
    public partial class Form1 : Form
    {
        Button btn = new Button();
        private Button geriDonButonu;
        private int adim = 150;
        private int toplamAdim = 10;
        private List<Point> yolKaydi = new List<Point>();
        private int mevcutAdim = 0;
        private System.Windows.Forms.Timer geriDonTimer;


        private Rectangle baslangicBolgesi = new Rectangle(0, 2, 150,640);
        private Rectangle bitisBolgesi = new Rectangle(554,2,620,640 );
        private Rectangle bolge1 = new Rectangle(158, 2, 192, 312);
        private Rectangle bolge2 = new Rectangle(158, 330, 192, 312);
        private Rectangle bolge3 = new Rectangle(356, 2, 192, 312);
        private Rectangle bolge4 = new Rectangle(356, 330, 192, 312);


        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;

            geriDonTimer = new System.Windows.Forms.Timer();
            geriDonTimer.Interval = 100; 
            geriDonTimer.Tick += GeriDonTimer_Tick;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            btn = new Button();
            btn.Size = new Size(100, 50);
            btn.Location = new Point(baslangicBolgesi.Left, baslangicBolgesi.Top);
            btn.Text = "Hareket Et";
            this.Controls.Clear();
            this.Controls.Add(btn);


            geriDonButonu = new Button();
            geriDonButonu.Size = new Size(100, 50);
            geriDonButonu.Location = new Point(bitisBolgesi.Left, bitisBolgesi.Top + 120);
            geriDonButonu.Text = "Geri Dön";
            geriDonButonu.Click += GeriDonButonu_Click;
            geriDonButonu.Visible = false;
            this.Controls.Add(geriDonButonu);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {



        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (mevcutAdim < toplamAdim)
            {
                yolKaydi.Add(btn.Location);
                {

                    if (keyData == Keys.Up)
                    {
                        btn.Top -= adim;
                    }
                    else if (keyData == Keys.Down)
                    {
                        btn.Top += adim;
                    }
                    else if (keyData == Keys.Left)
                    {
                        btn.Left -= adim;
                    }
                    else if (keyData == Keys.Right)
                    {
                        btn.Left += adim;
                    }


                }
                mevcutAdim++;
                BolgeKontrolu(btn.Location);

            }
            if (mevcutAdim == toplamAdim && bitisBolgesi.Contains(btn.Location))
            {
                geriDonButonu.Visible = true;
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void BolgeKontrolu(Point konum)
        {

            if (bolge1.Contains(konum))
            {
                btn.ForeColor = Color.Red;
                btn.Font = new Font("Arial", 7);
                btn.Size = new Size(75, 75);
            }
            else if (bolge2.Contains(konum))
            {
                btn.ForeColor = Color.Green;
                btn.Size = new Size(75, 75);
                btn.Font = new Font("Time New Roman",8);
            }
            else if (bolge3.Contains(konum))
            {
                btn.BackColor = Color.White;
                btn.ForeColor= Color.Pink; 
                btn.Font = new Font("Cardano", 9);
                btn.Size = new Size(60,60);

            }
            else if (bolge4.Contains(konum))
            {
                btn.BackColor = Color.Navy;
                btn.Size = new Size(80, 80);
                btn.Font = new Font("Monotype", 8);

            }
        }
        private void GeriDonButonu_Click(object sender, EventArgs e)
        {

            geriDonButonu.Visible = false;
            geriDonTimer.Start();


        }
        private void GeriDonTimer_Tick(object sender, EventArgs e)
        {
            if (yolKaydi.Count > 0)
            {
               
                Point geriKonum = yolKaydi[yolKaydi.Count - 1];
                btn.Location = geriKonum;

               
                BolgeKontrolu(geriKonum);

               
                yolKaydi.RemoveAt(yolKaydi.Count - 1);
            }
            else
            {
               
                geriDonTimer.Stop();
                btn.ForeColor = DefaultForeColor;
                btn.BackColor = DefaultBackColor;
            }
        }


    }
}
