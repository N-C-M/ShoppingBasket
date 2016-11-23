using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShoppingBasketForm
{
    public partial class SplashScreen : Form
    {
        Timer t = new Timer();
        Basket frm = new Basket();
        //pb = ProgressBar
        double pbUnit;
        int pbWIDTH, pbHEIGHT, pbComplete;

        Bitmap bmp;
        Graphics g;

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //get picboxPB dimension
            pbWIDTH = picboxPB.Width;
            pbHEIGHT = picboxPB.Height;

            pbUnit = pbWIDTH / 100.0;

            //pbComplete - This is equal to work completed in % [min = 0 max = 100]
            pbComplete = 0;

            //create bitmap
            bmp = new Bitmap(pbWIDTH, pbHEIGHT);

            //timer
            t.Interval = 50;    //in millisecond
            t.Tick += new EventHandler(this.timer1_Tick);
            t.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //graphics
            g = Graphics.FromImage(bmp);

            //clear graphics
            g.Clear(Color.Gray);

            //draw progressbar
            g.FillRectangle(Brushes.MediumPurple, new Rectangle(0, 0, (int)(pbComplete * pbUnit), pbHEIGHT));

            //draw % complete
            g.DrawString(pbComplete + "%", new Font("Arial", pbHEIGHT / 2), Brushes.AliceBlue, new PointF(pbWIDTH / 2 - pbHEIGHT, pbHEIGHT / 10));

            //load bitmap in picturebox picboxPB
            picboxPB.Image = bmp;

            //update pbComplete
            //Note!
            //To keep things simple I am adding +1 to pbComplete every 50ms
            //You can change this as per your requirement :)
            pbComplete++;
            if (pbComplete > 100)
            {
                g.Dispose();
                t.Stop();
            }

            if (pbComplete.Equals(10))
            {
                lbl3.Text = String.Format("Starting Modules...");
            }

            if (pbComplete.Equals(40))
            {
                lbl3.Text = String.Format("Loading Modules...");
            }

            if (pbComplete.Equals(60))
            {
                lbl3.Text = String.Format("Database Initializing...");
            }

            if (pbComplete.Equals(80))
            {
                lbl3.Text = String.Format("Database Loaded...");
            }

            if (pbComplete.Equals(100))
            {
                frm.Show();
                t.Enabled = false;
                this.Hide();
            }
        }
    }
}

