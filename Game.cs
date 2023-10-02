using System.Threading;

namespace Puissance4 {
    public class Game{
        public int mode{get; private set;}
        public Player p1{get; private set;}
        public Player p2{get; private set;}
        public Board b{get; private set;}

        public IA bob{get; private set;}
        public IA Joshua{get; private set;}

        public IA CurrentIA{get; private set;}

        public Player CurrentPlayer{get; private set;}


        public Game(int mode) {

            this.mode = mode;
            //this.p1 = new Player(ConsoleUI.GetName(1), 1);
            //this.p2 = new Player(ConsoleUI.GetName(2), 2);
            this.b = new Board();

            this.bob = new IA("BOB",1);
            this.Joshua = new IA("Joshua",2);

            this.CurrentIA = this.bob;

            //this.CurrentPlayer = this.p2;
            for(int i=0;i<100;i++) {
                this.b = new Board();
                this.b.PrintBoard();
                while(!(b.GameOver(this.CurrentIA.PieceColor))) {
                    ChangeIA();
                    this.b.PlayIA(this.CurrentIA);
                    Console.Clear();
                    this.b.PrintBoard();
                    Thread.Sleep(100);
                }
                ConsoleUI.PrintIAWinner(CurrentIA);
            }
            
        }

        private void ChangePlayer(){
            if(CurrentPlayer == p1) {
                CurrentPlayer = this.p2;
            }
            else {
                CurrentPlayer = this.p1;
            }
        }

        private void ChangeIA(){
            if(CurrentIA == bob) {
                CurrentIA = this.Joshua;
            }
            else {
                CurrentIA = this.bob;
            }
        }
    }
}
