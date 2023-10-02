public class IA{
    public QLearningAgent log;
    public int PieceColor;

    public string name;


    public IA(string name, int PieceColor) {
        this.name = name;
        this.log = new QLearningAgent();
        this.PieceColor = PieceColor;
    }
}