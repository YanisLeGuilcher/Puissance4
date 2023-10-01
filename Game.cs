using System.Security.Authentication.ExtendedProtection;

namespace Puissance4 {
    public class Game{
        public int mode{get; private set;}
        public Player p1{get; private set;}
        public Player p2{get; private set;}
        public Board b{get; private set;}

        public Player CurrentPlayer{get; private set;}


        public Game(int mode) {
            this.mode = mode;
            this.p1 = new Player(ConsoleUI.GetName(1), 1);
            this.p2 = new Player(ConsoleUI.GetName(2), 2);
            this.b = new Board();

            this.CurrentPlayer = this.p2;

            this.b.PrintBoard();
            while(!(b.GameOver(this.CurrentPlayer.PieceColor))) {
                ChangePlayer();
                this.b.Play(this.CurrentPlayer);
                Console.Clear();
                this.b.PrintBoard(); 
            }
            ConsoleUI.PrintWinner(CurrentPlayer);
        }

        private void ChangePlayer(){
            if(CurrentPlayer == p1) {
                CurrentPlayer = this.p2;
            }
            else {
                CurrentPlayer = this.p1;
            }
        }
    }
}
