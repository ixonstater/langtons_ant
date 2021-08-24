using System.Windows.Forms;

namespace LangtonsAnt
{
    public class Simulation
    {
        public int Width;
        public int Height;
        public int TermsCalculated = 0;
        public int StepLimit;
        public int StepsPerSecond;
        public bool runSim = true;
        public SimulationModel Model;
        public Form1 Form;

        public Simulation(int xPos, int yPos, int width, int height, bool randomize, int stepLimit, int stepsPerSecond, Form1 form)
        {
            this.Width = width;
            this.Height = height;
            this.StepsPerSecond = stepsPerSecond;
            this.StepLimit = stepLimit;
            this.Form = form;
            this.Model = new SimulationModel(xPos, yPos, width, height, randomize);
            this.Form.DrawInitialGrid(this.Model, this.Width, this.Height);
        }

        public async void CalculationLoop()
        {
            while (this.runSim)
            {
                try
                {
                    await Task.Delay(1000 / this.StepsPerSecond);
                    this.CalculateStep();
                    this.TermsCalculated++;
                    if (this.StepLimit < 0)
                    {
                        continue;
                    }
                    if (this.TermsCalculated > this.StepLimit)
                    {
                        this.StopSimulation();
                    }
                }
                catch
                {
                    this.StopSimulation();
                    MessageBox.Show("Ant has left the screen.", "Range Error");
                }
            }
        }

        public void CalculateStep()
        {
            var x = this.Model.XPos;
            var y = this.Model.YPos;
            var translatedX = x + this.Width / 2;
            var translatedY = y + this.Height / 2;
            var color = this.Model.Playground[translatedX][translatedY];

            if (color == SimulationModel.Color.black)
            {
                this.Form.Invoke(() =>
                {
                    this.Form.ChangeTile(SimulationModel.Color.white, translatedX, translatedY, this.Width, this.Height);
                });
                this.Model.SetSquareWhite(translatedX, translatedY);
                this.Model.RotateCounterClockwise();
            }
            else
            {
                this.Form.Invoke(() =>
                {
                    this.Form.ChangeTile(SimulationModel.Color.black, translatedX, translatedY, this.Width, this.Height);
                });
                this.Model.SetSquareBlack(translatedX, translatedY);
                this.Model.RotateClockwise();
            }
            this.Model.AdvanceAnt();
        }

        public void StopSimulation()
        {
            this.runSim = false;
        }
    }
}

