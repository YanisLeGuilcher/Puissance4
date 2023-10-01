using System;
namespace Puissance4 {
    public static class ConsoleUI {
        public const char p1='X';
        public const char p2='O';


        public static int GetColumnChoice(Player player) {
            int columnChoice;
            bool isValidInput = false;

            do
            {
                Console.Write($"Joueur {player.name}, choisissez une colonne (1-7) : ");
                
                // Essayez de convertir l'entrée de l'utilisateur en un entier
                if(int.TryParse(Console.ReadLine(), out columnChoice)) {
                    // Vérifiez si le choix est dans la plage valide
                    if(columnChoice >= 1 && columnChoice <= 7) {
                        isValidInput = true;
                    }
                    else {
                        Console.WriteLine("Veuillez entrer un nombre entre 1 et 7.");
                    }
                }
                else {
                    Console.WriteLine("Veuillez entrer un nombre valide.");
                }
            } while(!isValidInput);
            return columnChoice;
        }


        public static void PrintWinner(Player p) {
            Console.WriteLine("Bravo "+p.name+" a gagné");
        }

        public static string GetName(int playerNumber) {
                string playerName = "";

                while (string.IsNullOrWhiteSpace(playerName)) {
                    Console.Write($"Entrez le nom du Joueur {playerNumber}: ");

                    try
                    {
                        playerName = Console.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(playerName))
                        {
                            Console.WriteLine("Le nom du joueur ne peut pas être vide ou composé uniquement d'espaces.");
                        }
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Une erreur d'entrée/sortie s'est produite. Veuillez réessayer.");
                    }
                }

                return playerName;
            }
    }
}
