using System.Drawing;
using System.Windows.Forms;

namespace LangtonsAnt
{
    public partial class Form1 : Form
    {
        Graphics Graphic;
        SolidBrush BrushBlack;
        SolidBrush BrushWhite;
        Simulation? Sim;
        const int PANEL_HEIGHT = 430;
        const int PANEL_WIDTH = 430;

        public Form1()
        {
            InitializeComponent();
            this.Graphic = panel1.CreateGraphics();
            this.BrushBlack = new SolidBrush(Color.Black);
            this.BrushWhite = new SolidBrush(Color.White);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dimension = textBox1.Text;
            var xPos = textBox3.Text;
            var yPos = textBox4.Text;
            var animationSpeed = textBox5.Text;
            var totalSteps = textBox6.Text;

            var randomize = radioButton2.Checked;
            int widthF;
            int heightF;
            int xPosF;
            int yPosF;
            int animationSpeedF;
            int totalStepsF;

            bool parseSucceeded = true;
            parseSucceeded = int.TryParse(dimension, out widthF) && parseSucceeded;
            parseSucceeded = int.TryParse(dimension, out heightF) && parseSucceeded;
            parseSucceeded = int.TryParse(xPos, out xPosF) && parseSucceeded;
            parseSucceeded = int.TryParse(yPos, out yPosF) && parseSucceeded;
            parseSucceeded = int.TryParse(animationSpeed, out animationSpeedF) && parseSucceeded;
            parseSucceeded = int.TryParse(totalSteps, out totalStepsF) && parseSucceeded;

            if (parseSucceeded)
            {
                if (this.Sim != null)
                {
                    this.Sim.StopSimulation();
                }
                this.Sim = new Simulation(xPosF, yPosF, widthF, heightF, randomize, totalStepsF, animationSpeedF, this);
                this.Sim.CalculationLoop();
            }
            else
            {
                MessageBox.Show("Failed to parse integers from supplied text.", "Parse Error");
            }
        }

        public void DrawInitialGrid(SimulationModel model, int width, int height)
        {
            this.ResetPlayground();

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    if (model.Playground[x][y] == SimulationModel.Color.black)
                    {
                        this.ChangeTile(SimulationModel.Color.black, x, y, width, height);
                    }
                    else
                    {
                        this.ChangeTile(SimulationModel.Color.white, x, y, width, height);
                    }
                }
            }
        }

        public void ChangeTile(SimulationModel.Color color, int x, int y, int width, int height)
        {
            var boxWidth = PANEL_WIDTH / width;
            var boxHeight = PANEL_HEIGHT / height;
            var translatedX = x * boxWidth;
            var translatedY = y * boxHeight;

            if (color == SimulationModel.Color.black)
            {
                this.Graphic.FillRectangle(this.BrushBlack, translatedX, translatedY, boxWidth, boxHeight);
            }
            else
            {
                this.Graphic.FillRectangle(this.BrushWhite, translatedX, translatedY, boxWidth, boxHeight);
            }

        }

        public void ResetPlayground()
        {
            panel1.Refresh();
        }
    }
}
