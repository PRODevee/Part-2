using static System.Console;

namespace RogueLike_2._0
{
    public partial class Form1 : Form
    {
        GameEngine gameEngine;
        Hero hero;
        public Form1()
        {
            InitializeComponent();
            GameEngine gameEngine = new GameEngine();
            redDisplay.Text = gameEngine.Display;
            lblHeroStats.Text = hero.ToString();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            CheckMove(e.KeyCode);
            CheckAttack(e.KeyCode);
            redDisplay.Text = gameEngine.Display;

        }

        private void CheckMove(Keys KeyCode)
        {

            if (KeyCode == Keys.W)
            {
                gameEngine.MovePlayer(Movement.Up);
            }
            else if (KeyCode == Keys.S)
            {
                gameEngine.MovePlayer(Movement.Down);
            }
            else if (KeyCode == Keys.A)
            {
                gameEngine.MovePlayer(Movement.Left);
            }
            else if (KeyCode == Keys.D)
            {
                gameEngine.MovePlayer(Movement.Right);
            }
        }

        private void CheckAttack(Keys KeyCode)
        {
            string attackInfo = "";
            if (KeyCode == Keys.I)
            {
                gameEngine.PlayerAttack(Movement.Up);
            }
            else if (KeyCode == Keys.K)
            {
                gameEngine.PlayerAttack(Movement.Down);
            }
            else if (KeyCode == Keys.J)
            {
                gameEngine.PlayerAttack(Movement.Left);
            }
            else if (KeyCode == Keys.L)
            {
                gameEngine.PlayerAttack(Movement.Right);
            }
            if (!(attackInfo == ""))
            {

            }
        }
    }
}