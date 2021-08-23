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
            /*Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.Red);
            g.DrawEllipse(p, 50, 50, 100, 100);
            g.FillEllipse(sb, 50, 50, 100, 100);
            SolidBrush sb2 = new SolidBrush(Color.Blue);
            g.DrawRectangle(p, 50, 50, 100, 100);
            g.FillRectangle(sb2, 50, 50, 100, 100);*/


            var width = textBox1.Text;
            var height = textBox2.Text;
            var xPos = textBox3.Text;
            var yPos = textBox4.Text;
            var animationSpeed = textBox5.Text;
            var totalSteps = textBox6.Text;

            var randomize = radioButton1.Checked;
            int widthF;
            int heightF;
            int xPosF;
            int yPosF;
            int animationSpeedF;
            int totalStepsF;

            bool parseSucceeded = true;
            parseSucceeded = int.TryParse(width, out widthF) && parseSucceeded;
            parseSucceeded = int.TryParse(height, out heightF) && parseSucceeded;
            parseSucceeded = int.TryParse(xPos, out xPosF) && parseSucceeded;
            parseSucceeded = int.TryParse(yPos, out yPosF) && parseSucceeded;
            parseSucceeded = int.TryParse(animationSpeed, out animationSpeedF) && parseSucceeded;
            parseSucceeded = int.TryParse(totalSteps, out totalStepsF) && parseSucceeded;

            if (parseSucceeded)
            {
                var sim = new Simulation(xPosF, yPosF, widthF, heightF, randomize, totalStepsF, animationSpeedF);
                sim.CalculationLoop();
            }
            else
            {
                MessageBox.Show("Failed to parse integers from supplied text.", "Parse Error");
            }
        }
    }
}
