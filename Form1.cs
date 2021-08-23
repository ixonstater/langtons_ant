using System.Drawing;
using System.Windows.Forms;

namespace LangtonsAnt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Red);
            g.DrawEllipse(p, 50, 50, 100, 100);
            g.FillEllipse(sb, 50, 50, 100, 100);
            SolidBrush sb2 = new SolidBrush(Color.Blue);
            g.DrawRectangle(p, 50, 50, 100, 100);
            g.FillRectangle(sb2, 50, 50, 100, 100);

        }
    }
}
