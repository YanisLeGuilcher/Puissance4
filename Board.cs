using System.Runtime.InteropServices;

namespace Puissance4{

    
    public class Board {
        public int[,] grille{get; private set;}
        public const int largeur = 7;
        public const int hauteur = 6;


        public Board() {
            this.grille = new int[hauteur,largeur];
        }


        public void PrintBoard() {
            for(int i=0;i<hauteur;i++) {
                Console.Write("|");
                for(int j=0;j<largeur;j++) {
                    Console.Write(" "+IntToChar(this.grille[i,j])+" |");
                }
                Console.WriteLine();
                Console.Write("+");
                for(int j=0;j<largeur;j++) {
                    Console.Write("---+");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  1   2   3   4   5   6   7");
        }

        private char IntToChar(int value) {
            switch(value) {
                case 1: return 'X';
                case 2: return 'O';
                default: return ' ';
            }
        }

        public bool GameOver(int player) {
            // Vérification des lignes horizontales
            for (int row = 0; row < hauteur; row++) {
                for (int col = 0; col <= largeur - 4; col++) {
                    if (this.grille[row, col] == player &&
                        this.grille[row, col + 1] == player &&
                        this.grille[row, col + 2] == player &&
                        this.grille[row, col + 3] == player) {
                        return true;
                    }
                }
            }

            // Vérification des colonnes verticales
            for (int col = 0; col < largeur; col++) {
                for (int row = 0; row <= hauteur - 4; row++) {
                    if (this.grille[row, col] == player &&
                        this.grille[row + 1, col] == player &&
                        this.grille[row + 2, col] == player &&
                        this.grille[row + 3, col] == player) {
                        return true;
                    }
                }
            }

            // Vérification des diagonales descendantes (de gauche à droite)
            for (int row = 0; row <= hauteur - 4; row++) {
                for (int col = 0; col <= largeur - 4; col++) {
                    if (this.grille[row, col] == player &&
                        this.grille[row + 1, col + 1] == player &&
                        this.grille[row + 2, col + 2] == player &&
                        this.grille[row + 3, col + 3] == player) {
                        return true;
                    }
                }
            }

            // Vérification des diagonales montantes (de gauche à droite)
            for (int row = 3; row < hauteur; row++) {
                for (int col = 0; col <= largeur - 4; col++) {
                    if (this.grille[row, col] == player &&
                        this.grille[row - 1, col + 1] == player &&
                        this.grille[row - 2, col + 2] == player &&
                        this.grille[row - 3, col + 3] == player) {
                        return true;
                    }
                }
            }

            // Aucune ligne de 4 jetons alignés n'a été trouvée
            return false;
        }
    
        public void Play(Player p) {
            int col;
            do {
                col = ConsoleUI.GetColumnChoice(p)-1;
            }
            while(!AddPiece(p.PieceColor,col));
        }

        private bool AddPiece(int color, int col) {
            int h=hauteur-1;

            while(this.grille[h,col]!=0) {
                h--;
                if(h<0) {
                    return false;
                }
            }
            this.grille[h,col] = color;
            return true;
        }
    }


    
}

