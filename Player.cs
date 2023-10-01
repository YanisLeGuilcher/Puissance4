namespace Puissance4 {
    public class Player {

        public string name{get; private set;}
        public int PieceColor{get; private set;}

        public Player(string name, int PieceColor) {
            this.name = name;
            this.PieceColor = PieceColor;
        }
    }
}
