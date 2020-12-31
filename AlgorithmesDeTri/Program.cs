/**
 * Application Console Algorithmes de Tri
 * Auteur: Carl Fremault
 * Date: 31/12/2020
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmesDeTri
{
    class Program
    {
        static void Main(string[] args)
        {
            // Affichage du menu, saisi choix utilisateur, appel de la méthode (i.e. algorithme de tri) correspondante
            var choix = "Z";
            choix = AfficheMenu();
            var listeEntiers = new List<int>();
            while (choix.ToLower() != "q")
            {
                switch (choix)
                {
                    case "1": // Tri par sélection
                        Console.Clear();
                        listeEntiers = SaisieListeEntiers();
                        TriParSelection(listeEntiers);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Tapez <Entrée> pour continuer.");
                        Console.ReadLine();
                        break;
                    case "2": // Tri par insertion
                        Console.Clear();
                        listeEntiers = SaisieListeEntiers();
                        TriParInsertion(listeEntiers);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Tapez <Entrée> pour continuer.");
                        Console.ReadLine();
                        break;
                    case "3": // Tri à bulles
                        Console.Clear();
                        listeEntiers = SaisieListeEntiers();
                        TriABulles(listeEntiers);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Tapez <Entrée> pour continuer.");
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Je n'ai pas compris votre choix. Essayez à nouveau.");
                        Console.WriteLine();
                        choix = AfficheMenu();
                        continue;
                }
                Console.Clear();
                choix = AfficheMenu();
            }
            Console.WriteLine();
            Console.WriteLine("A bientôt!");
            Console.WriteLine();
        }
        // Méthode pour afficher le menu. Retourne le choix de l'utilisateur.
        public static string AfficheMenu()
        {
            var menu = new StringBuilder();
            menu
                .Append('*', 29)
                .AppendLine()
                .Append("*   Algorithmes de tri      *")
                .AppendLine()
                .Append('*', 29)
                .AppendLine()
                .Append("*   Tri par sélection :   1 *")
                .AppendLine()
                .Append("*   Tri par insertion :   2 *")
                .AppendLine()
                .Append("*   Tri à bulles :        3 *")
                .AppendLine()
                .Append("*   Quitter :             Q *")
                .AppendLine()
                .Append('*', 29);
            Console.WriteLine(menu);
            Console.Write("Faites votre choix : ");
            return Console.ReadLine();   
        }

        // Méthode pour formater et afficher un intitulé
        public static StringBuilder MakeHeader(string input)
        {
            var header = new StringBuilder();
            var length = input.Length;
            header
                .Append('*', length + 4)
                .AppendLine()
                .Append("* " + input + " *")
                .AppendLine()
                .Append('*', length + 4);
            return header;
        }

        // Méthode pour saisir et retourner une liste d'entiers
        public static List<int> SaisieListeEntiers()
        {
            Console.Clear();
            Console.WriteLine(MakeHeader("Saisie de liste d'entiers"));
            Console.WriteLine();
            var listeEntiers = new List<int>();
            var i = 1;
            while (true)
            {
                try
                {
                    Console.WriteLine("Saisissez entier n°{0} (tapez <Entrée> pour confirmer la liste) : ", i);
                    var entier = Console.ReadLine();
                    if (!String.IsNullOrEmpty(entier))
                    {
                        listeEntiers.Add(int.Parse(entier));
                        i += 1;
                    }
                    else
                    {
                        break; // Sortie de la boucle while si utilisateur appuie Entrée sans saisir un entier
                    }
                }
                catch
                {
                    Console.WriteLine("Ce n'est pas un entier. Veuillez essayer à nouveau.");
                    continue;
                }
            }
            return listeEntiers;
        }

        // Méthode pour trier une liste d'entiers en utilisant l'algorithme "tri par sélection"
        public static void TriParSelection(List<int> liste)
        {
            // Affichage
            Console.Clear();
            Console.WriteLine(MakeHeader("Tri par sélection"));
            Console.WriteLine();
            Console.Write("Liste initiale : ");
            foreach (var entier in liste)
            {
                Console.Write(entier + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Tri
            for (var i = 0; i < (liste.Count - 1); i++)
            {
                // Recherche valeur minimale
                int indexValeurMinimale = i;
                for (var j = i + 1; j < liste.Count; j++)
                {
                    if (liste[j] < liste[indexValeurMinimale])
                    {
                        indexValeurMinimale = j;
                    }
                }
                // Tri
                var valeurTemporaire = liste[indexValeurMinimale];
                liste[indexValeurMinimale] = liste[i];
                liste[i] = valeurTemporaire;
                // Affichage
                if (i == liste.Count - 2)
                {
                    Console.WriteLine();
                    Console.Write("Liste triée    : ");
                }
                else
                {
                    Console.Write("Etape n°{0}      : ", i + 1);
                }
                foreach (var entier in liste)
                {
                    Console.Write(entier + " ");
                }
                Console.WriteLine();
            }
        }

        // Méthode pour trier une liste d'entiers en utilisant l'algorithme "tri par insertion"
        public static void TriParInsertion(List<int> liste)
        {
            // Affichage
            Console.Clear();
            Console.WriteLine(MakeHeader("Tri par insertion"));
            Console.WriteLine();
            Console.Write("Liste initiale : ");
            foreach (var entier in liste)
            {
                Console.Write(entier + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Tri & Affichage
            for (var i = 1; i < liste.Count; i++)
            {
                // Tri
                var valeurTemporaire = liste[i];
                int j = i - 1;
                while (j >= 0 && liste[j] > valeurTemporaire)
                {
                    liste[j + 1] = liste[j];
                    j--;
                }
                liste[j + 1] = valeurTemporaire;
                // Affichage
                if (i == liste.Count - 1)
                {
                    Console.WriteLine();
                    Console.Write("Liste triée    : ");
                }
                else
                {
                    Console.Write("Etape n°{0}      : ", i);
                }
                foreach (var entier in liste)
                {
                    Console.Write(entier + " ");
                }
                Console.WriteLine();
            }
        }

        // Méthode pour trier une liste d'entiers en utilisant l'algorithme "tri à bulles"
        public static void TriABulles(List<int> liste)
        {
            // Affichage
            Console.Clear();
            Console.WriteLine(MakeHeader("Tri à bulles"));
            Console.WriteLine();
            Console.Write("Liste initiale : ");
            foreach (var number in liste)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            // Tri & Affichage
            bool modification;
            var etape = 1;
            do
            {
                modification = false;
                for (var i = 1; i < liste.Count; i++)
                {
                    if (liste[i] < liste[i - 1])
                    {
                        modification = true;
                        var valeurTemporaire = liste[i];
                        liste[i] = liste[i - 1];
                        liste[i - 1] = valeurTemporaire;
                    }
                }
                // Affichage
                if (modification)
                {
                    Console.Write("Etape n°{0}      : ", etape);
                    foreach (var number in liste)
                    {
                        Console.Write(number + " ");
                    }
                    Console.WriteLine();
                    etape++;
                }
            } while (modification);
            // Affichage final
            Console.WriteLine();
            Console.Write("Liste triée    : ");
            foreach (var number in liste)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
