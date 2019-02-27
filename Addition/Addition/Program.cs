using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addition
{
    class Program
    {

        // Variables pour tous
        const int min = 1;
        const int max = 10;
        static Random random = new Random();

        // Apréciations
        private static void AfficherAppréciations(int points, int nbQ)
        {
            if (points == nbQ)
            {
                Console.WriteLine("Vous avez " + points + "points, BRAVO !!");
            }
            else if (points > (nbQ / 2))
            {
                Console.WriteLine("Vous avez " + points + "points, PAS MAL :)");
            }
            else
            {
                Console.WriteLine("Vous avez " + points + "points, peut mieux faire :/");
            }
        }

  

        // Nouveau type (plus clair)
        enum OPERATEUR
        {
            ADDITION,
            MULTIPLICATION,
            SOUSTRACTION
        }

        // + * -
        private static OPERATEUR GetOperateur()
        {
            int operateur = random.Next(1, 4);
            if (operateur == 1)
            {
                return OPERATEUR.ADDITION;
            }
            else if (operateur == 2)
            {
                return OPERATEUR.MULTIPLICATION;
            }
            return OPERATEUR.SOUSTRACTION;
        }

        // a + b = ?
        private static bool DemanderAddition()
        {

            int a = random.Next(min, max);
            int b = random.Next(min, max);
            OPERATEUR operateur = GetOperateur();
            int resultatFinal = 0;

            // Boucle infinie
            while (true)
            {
                // Calculs cas par cas
                switch (operateur)
                {
                    case OPERATEUR.ADDITION:
                        {
                            Console.Write(a + "+" + b + "= ");
                            resultatFinal = a + b;
                        }
                        break;
                    case OPERATEUR.MULTIPLICATION:
                        {
                            Console.Write(a + "x" + b + "= ");
                            resultatFinal = a * b;
                        }
                        break;
                    case OPERATEUR.SOUSTRACTION:
                        {
                            if (a < b)
                            {
                                int temp = a;
                                a = b;
                                b = temp;
                            }
                            Console.Write(a + "-" + b + "= ");
                            resultatFinal = a - b;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("ERREUR");
                            Environment.Exit(0);
                        }
                        break;
                }
                
                // Compare la réponse vs résultat
                String resultat = Console.ReadLine();
                int resultatNum = 0;
                if (int.TryParse(resultat, out resultatNum))
                {
                    if (resultatNum == resultatFinal)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("ATTENTION, vous devez entrer un nombre.");
                }
            }
        }
        


        static void Main(string[] args)
        {
            const int nbQ = 5;
            int points = 0;

            // Boucler 5 fois.
            for (int i = 1; i <= nbQ; i++)
            {
                Console.WriteLine("Question " + i + "/" + nbQ + " : ");
                if (DemanderAddition())
                {
                    points++;
                }
                Console.WriteLine("");

            }

            AfficherAppréciations(points, nbQ);
           
        }
    }
}
