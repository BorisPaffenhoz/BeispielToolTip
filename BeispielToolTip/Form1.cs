//  #   Funktions Beschreibung der Windows Form Anwendung   #
//  #   Das Programm "BeispielToolTip" zeigt eine Picture Box an, das Bild wird aus dem Ordner Resources geladen.    #
//  #   Der toolTip1 bezieht sich auf die Form und gibt den Namen Fenster aus.   #
//  #   Der toolTip2 bezieht sich auf den Button 1, der mit dem Bild aus dem Resources Ordner und einem Text gefüllt wird.   #
//  #   Dokumentation   #
//  #   Erfolgreicher durchlauf des Programms   #




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeispielToolTip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //pictureBox1 mit einem Bild aus dem Odrner Resoources füllen
            pictureBox1.Image = Properties.Resources.Hund;

            //Text für den toolTip2
            toolTip2.SetToolTip(button1, "Hallo das ist ein Hund mit dem Namen Alf.\nDer ist so müde.");
        }

        // Rand Abstand
        private new const int Margin = 10;

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {
            int image_wid = 2 * Margin +
            Properties.Resources.Hund.Width;
            int image_hgt = 2 * Margin +
            Properties.Resources.Hund.Height;

            int wid = e.ToolTipSize.Width + 2 * Margin + image_wid;
            int hgt = e.ToolTipSize.Height;
            if (hgt < image_hgt) hgt = image_hgt;

            e.ToolTipSize = new Size(wid, hgt);
        }

        private void toolTip2_Draw(object sender, DrawToolTipEventArgs e)
        {
            // Draw the background and border.
            e.DrawBackground();
            e.DrawBorder();

            // Draw the image.
            e.Graphics.DrawImage(Properties.Resources.Hund,
                Margin, Margin);

            // Draw the text.
            using (StringFormat sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;

                int image_wid = 2 * Margin +
                    Properties.Resources.Hund.Width;

                Rectangle rect = new Rectangle(image_wid, 0,
                    e.Bounds.Width - image_wid, e.Bounds.Height);
                e.Graphics.DrawString(
                    e.ToolTipText, e.Font, Brushes.Aqua, rect, sf);
                
            }
        }
    }
}
        

        