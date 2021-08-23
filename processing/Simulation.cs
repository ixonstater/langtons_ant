namespace LangtonsAnt
{
    public class Simulation
    {
        public int Width;
        public int Height;
        public int TermsCalculated = 0;
        public int TermsDisplayed = 0;
        public int StepLimit;
        public int StepsPerSecond;
        public SimulationModel Model;

        public Simulation(int xPos, int yPos, int width, int height, bool randomize, int stepLimit, int stepsPerSecond)
        {
            this.Width = width;
            this.Height = height;
            this.StepsPerSecond = stepsPerSecond;
            this.StepLimit = stepLimit;
            this.Model = new SimulationModel(xPos, yPos, width, height, randomize);
        }

        public void CalculationLoop()
        {

        }

        public void UpdateUi()
        {

        }
    }
}

