using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nb_magique_console
{
    class Program
    {
        static void Main(string[] args)
        {

            

            // étape 2 : Utiliser des constantes pour le min/max
            const int min = 1;
            const int max = 10;
            const int nbDeVies = 3;
            int vie = 0;

            // étape 1 : Rendre le nombre magique aléatoire
            Random random = new Random();
            int nbMagique = random.Next(min, max);

            

            /* étape 4 : Gérer les cas d'erreur où l'utilisateur a rentré
            un nombre en dehors de min et max*/
            for (vie = nbDeVies; vie > 0; vie--)
            {
                // étape 3 : Afficher "Entre 1 et 10"
                Console.Write("Devinez le nombre magique entre " + min + " et " + max + " (il vous reste " + vie + ") :");
                String nb = Console.ReadLine();
                int nbNum = 0;
                if (int.TryParse(nb, out nbNum))
                {
                    if (nbNum < min)
                    {
                        Console.WriteLine("Erreur, votre nombre est plus petit que le min");
                        vie++;
                    }
                    else if (nbNum > max)
                    {
                        Console.WriteLine("Erreur, votre nombre est plus grand que le max");
                        vie++;
                    }
                    else
                    {
                        if (nbNum < nbMagique)
                        {
                            Console.WriteLine("Le nombre magique est plus grand");
                        }
                        else if (nbNum > nbMagique)
                        {
                            Console.WriteLine("Le nombre magique est plus petit");
                        }
                        else
                        {
                            Console.WriteLine("Bravo, vous avez trouvé le nombre magique");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Erreur, vous devez entrer un nombre");
                }
            }

            // étape 5 : Désolé vous avez perdu, le nombre magique était x
            if (vie == 0)
            {
                Console.WriteLine("Désolé vous avez perdu, le nombre magique était " + nbMagique);
            }
            


        }
    }
}
