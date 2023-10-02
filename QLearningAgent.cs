using System;
using System.Collections.Generic;
using System.Linq;

public class QLearningAgent
{
    private Dictionary<Tuple<int[,], int>, double> QTable; // Table Q (état, action -> valeur Q)
    private double learningRate = 0.1; // Taux d'apprentissage
    private double discountFactor = 0.9; // Facteur de remise
    private double explorationRate = 0.2; // Taux d'exploration

    public QLearningAgent()
    {
        QTable = new Dictionary<Tuple<int[,], int>, double>();
    }

    public int ChooseAction(int[,] board)
    {
        // Exploration : avec une probabilité d'explorationRate, choisir une action aléatoire
        if (Random.NextDouble() < explorationRate)
        {
            List<int> legalActions = GetLegalActions(board);
            return legalActions[Random.Next(legalActions.Count)];
        }
        // Exploitation : choisir l'action avec la plus grande valeur Q
        else
        {
            List<int> legalActions = GetLegalActions(board);
            Tuple<int[,], int> maxAction = legalActions
                .Select(action => new Tuple<int[,], int>(CloneBoard(board), action))
                .OrderBy(action => GetQValue(action))
                .LastOrDefault();

            return maxAction?.Item2 ?? -1; // -1 signifie aucune action valide
        }
    }

    public void UpdateQValue(Tuple<int[,], int> stateAction, double reward, int[,] nextState)
    {
        double currentQValue = GetQValue(stateAction);

        // Trouver la meilleure valeur Q pour l'état suivant
        double maxNextQValue = GetLegalActions(nextState)
            .Select(action => new Tuple<int[,], int>(CloneBoard(nextState), action))
            .Select(action => GetQValue(action))
            .Max();

        // Mettre à jour la valeur Q
        QTable[stateAction] = currentQValue + learningRate * (reward + discountFactor * maxNextQValue - currentQValue);
    }

    private double GetQValue(Tuple<int[,], int> stateAction)
    {
        if (!QTable.ContainsKey(stateAction))
            QTable[stateAction] = 0.0;
        return QTable[stateAction];
    }

    private List<int> GetLegalActions(int[,] board)
    {
        List<int> legalActions = new List<int>();
        int numRows = board.GetLength(0);
        int numCols = board.GetLength(1);

        for (int col = 0; col < numCols; col++)
        {
            if (board[0, col] == 0) // Vérifiez la rangée du bas de la colonne
            {
                legalActions.Add(col);
            }
        }

        return legalActions;
    }

    private int[,] CloneBoard(int[,] board)
    {
        int numRows = board.GetLength(0);
        int numCols = board.GetLength(1);
        int[,] clonedBoard = new int[numRows, numCols];

        for (int row = 0; row < numRows; row++)
        {
            for (int col = 0; col < numCols; col++)
            {
                clonedBoard[row, col] = board[row, col];
            }
        }

        return clonedBoard;
    }

    private static readonly Random Random = new Random();
}
