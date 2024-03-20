using Entities;
using Entities.Exceptions;
using System.Reflection.Metadata.Ecma335;
using static TPFinal_GestionDeVehicules.Tools;

namespace TPFinal_GestionDeVehicules;
public class ActionOnVehicule
{
    /// <summary>
    /// Créer un nouveau véhicule et le sauvegarder dans la liste "vehicules"
    /// </summary>
    /// <param name="vehicules"></param>
    public static void CreateVehicule(List<Vehicule> vehicules)
    {
        int numeroInput = 0;
        string? marqueInput = "1";
        string? modeleInput= null;
        string typeOfVehicule;

        Console.WriteLine("Afin de créer un nouveau véhicule vous devez entrer les informations suivante");

        // Récupération du numéro
        bool formatNum = false;
        while (!formatNum)
        {
            numeroInput = GetIntInput("Indiquer le numéro du véhicule (sans chiffre)");
            if ((numeroInput >= 1000) && (numeroInput <= 999999))
            {
                formatNum = true;
                break;
            }
            Console.WriteLine("le format du numéro entrée n'est pas valide");
        }


        //Récupérer la marque
        bool formatMarque = false;
        while (!formatMarque)
        {
            marqueInput = GetStringInput("Indiquer la marque du véhicule (sans chiffre)");
            if (!marqueInput.Any(c => char.IsDigit(c)) || marqueInput == null)
            {
                formatMarque = true;
                break;
            }
            Console.WriteLine("La marque du véhicule ne doit pas contenir de chiffre");
        }


        //Récupérer le modele
        
        while (modeleInput == null)
        {
            modeleInput = GetStringInput("Indiquer le modèle du véhicule");
        }



        //Créer le véhicule après avoir recupérer la puissance si il s'agit d'une voiture ou le poids si il s'agit d'un camion
        typeOfVehicule = GetStringInput("Taper le chiffre 1 ou 2 pour indiquer le type de véhicule (1 : voiture , 2 : camion)");
        if (typeOfVehicule != "1" && typeOfVehicule != "2")
        {
            Console.WriteLine("Vous devez choisir entre 1 (pour voiture)  et 2 (pour camion)");
            typeOfVehicule = GetStringInput("Indiquer le type de véhicule  : ");
        }
        else
        {
            switch (typeOfVehicule)
            {
                case "1":
                    int puissanceInput = GetIntInput("Indiquer la puissance de la voiture");
                    try
                    {
                        vehicules.Add(new Voiture(numeroInput, marqueInput, modeleInput, puissanceInput));
                    }
                    catch (Exception ex) 
                    { 
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "2":
                    double poidsInput = GetDoubleInput("Indiquer le poids du camion en Tonne");
                    try
                    {
                        vehicules.Add(new Camion(numeroInput, marqueInput, modeleInput, poidsInput));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
            };
            Console.WriteLine("Le véhicule à bien été ajouté à la liste vehicules");
        }

    }

    /// <summary>
    /// Affiche l'ensemble des véhicules de la liste "vehicules"
    /// </summary>
    /// <param name="vehicules"></param>
    public static void GetAllVehicules(List<Vehicule> vehicules)
    {

        foreach (Vehicule v in vehicules)
        {
            Console.WriteLine(v.ToString());
        }
    }

    /// <summary>
    /// Afficher un véhicule à partir de son numéro
    /// </summary>
    /// <param name="vehicules"></param>
    public static void GetVehiculeByNumero(List<Vehicule> vehicules)
    {
        int intUserInput = GetIntInput("Entez le numéro du véhicule à afficher : ");
        var selectedVehicule = vehicules.FirstOrDefault(v => v.Numero == intUserInput) ?? throw new NotImplementedException(message: "Ce numéro n'existe pas.");
        Console.WriteLine(selectedVehicule.ToString());
    }


    /// <summary>
    /// Supprimer un véhicule à partir de son numéro
    /// </summary>
    /// <param name="vehicules"></param>
    public static void DeletedVehiculeByNumero(List<Vehicule> vehicules)
    {
        int intUserInput = GetIntInput("Entez le numéro du véhicule à supprimer : ");
        var selectedVehicule = vehicules.FirstOrDefault(v => v.Numero == intUserInput) ?? throw new NotImplementedException(message: "Ce numéro n'existe pas.");
        vehicules.Remove(selectedVehicule);
    }


    /// <summary>
    /// Permet de mettre à chaque champ de véhicule
    /// </summary>
    /// <param name="vehicules"></param>
    /// <exception cref="NotImplementedException"></exception>
    public static void UpdateVehiculeByNumero(List<Vehicule> vehicules)
    {
        int intUserInput = GetIntInput("Entez le numéro du véhicule à afficher : ");
        var vehiculeToUpdate = vehicules.FirstOrDefault(v => v.Numero == intUserInput) ?? throw new NotImplementedException(message: "Ce numéro n'existe pas.");
        Console.WriteLine(vehiculeToUpdate.ToString());
        string userInput = GetStringInput("Est-ce-qu'il s'agit bien du véhicule que vous voulez modier? (o / n");
        if (userInput == "o")
        {
            // Mise à jour de la Marque
            string marqueInput = GetStringInput("Modifier la marque du véhicule (sans chiffre) ou appuyer sur entrer");
            if (marqueInput != "")
            {
                vehiculeToUpdate.Marque = marqueInput;
                Console.WriteLine(value: "La marque a était modifiée");
            }
            else
            {
                Console.WriteLine(value: "La marque reste inchangée");
            }
            // Mise à jour du modèle
            string modeleInput = GetStringInput("Indiquer le modèle du véhicule");
            if (modeleInput != "")
            {
                vehiculeToUpdate.Modele = modeleInput;
                Console.WriteLine(value: "Le modèle a été modifié");
            }
            else
            {
                Console.WriteLine(value: "Le modele reste inchangé");
            }
            //Mise à jour de la puissance ou du poids
            if (vehiculeToUpdate is Voiture voitureToUpdate)
            {
                int puissanceInput = GetIntInput("Modifier la Puissance du véhicule");
                voitureToUpdate.Puissance = puissanceInput;
                Console.WriteLine(value: "La puissance a été modifiée");
            }
            if (vehiculeToUpdate is Camion camionToUpdate)
            {
                int poidsInput = GetIntInput("Modifier la Puissance du véhicule");
                camionToUpdate.Poids = poidsInput;
                Console.WriteLine(value: "Le poids a été modifié");
            }
        }
        else { UpdateVehiculeByNumero(vehicules); }
    }

    /// <summary>
    /// Permet le tri de la liste de vehicule en fonction du numéro, de la marque, du modèle, de la puissance et du poids.
    /// </summary>
    /// <param name="vehicules"></param>
    public static void SortVehicules(List<Vehicule> vehicules)
    {
        List<Vehicule> vehiculesSortedBy = vehicules;

        Console.WriteLine("Paramètres de trus");
        Console.WriteLine("Par numéro : 1");
        Console.WriteLine("Par marque : 2");
        Console.WriteLine("Par modèle : 3");
        Console.WriteLine("Par puissance : 4 (seulement les voitures)");
        Console.WriteLine("Par poids : 5 (seulement les camions) ");
        Console.WriteLine();

        int parameterOfSort;

        parameterOfSort = GetIntInput("Choisisser le numéro correspondant au paramètre permettant de trierla liste de Véhicule : ");
        Console.WriteLine();
        switch (parameterOfSort)
        {
            case 1:
                vehiculesSortedBy = vehicules.OrderBy(v => v.Numero).ToList();
                Console.WriteLine("Voici la liste de véhicule triée par numéro");
                break;

            case 2:
                vehiculesSortedBy = vehicules.OrderBy(v => v.Marque).ToList();
                Console.WriteLine("Voici la liste de véhicule triée par Marque");
                break;

            case 3:
                vehiculesSortedBy = vehicules.OrderBy(v => v.Modele).ToList();
                Console.WriteLine("Voici la liste de véhicule triée par Modèle");
                break;

            case 4:
                vehiculesSortedBy = vehicules.Where(v => v is Voiture)
                                            .OrderBy(v => ((Voiture)v).Puissance)
                                            .ToList();
                Console.WriteLine("Voici la liste de voiture triée par Puissance");
                break;

            case 5:
                vehiculesSortedBy = vehicules.Where(v => v is Camion).OrderBy(v => ((Camion)v).Poids).ToList();
                Console.WriteLine("Voici la liste de camion triée par Poids");
                break;

            default:
                Console.WriteLine($"Le paramètre {parameterOfSort} ne permet pas le tri de la liste de véhicules");
                return;
        }
        foreach (Vehicule vehicule in vehiculesSortedBy)
            Console.WriteLine(vehicule.ToString());
    }

    /// <summary>
    /// Permet de filtrer par propriété et par mot clés
    /// </summary>
    /// <param name="vehicules"></param>
    public static void FilterVehicule(List<Vehicule> vehicules)
    {
        List<Vehicule> vehiculesFilterdBy = vehicules;

        Console.WriteLine("Paramètres de trus");
        Console.WriteLine("Par numéro : 1");
        Console.WriteLine("Par marque : 2");
        Console.WriteLine("Par modèle : 3");
        Console.WriteLine("Par puissance : 4 (seulement les voitures)");
        Console.WriteLine("Par poids : 5 (seulement les camions) ");
        Console.WriteLine();

        int parameterOfFiltre = GetIntInput("Choisisser le numéro correspondant au paramètre permettant de trierla liste de Véhicule : ");
        Console.WriteLine();
        switch (parameterOfFiltre)
        {
            case 1:
                int numMin = GetIntInput("Entrez le numéro le plus petit");
                int numMax = GetIntInput("Entrez la numéro le plus grand");
                vehiculesFilterdBy = vehicules.Where(v => (v.Numero >= numMin) && (v.Numero <= numMax)).ToList();
                Console.WriteLine("Voici la liste de véhicule triée par numéro");
                break;

            case 2:
                string marqueUserInput = GetStringInput("Entrez la marque recherchée");
                vehiculesFilterdBy = vehicules.Where(v => v.Marque == marqueUserInput).ToList();
                Console.WriteLine("Voici la liste de véhicule triée par numéro");
                break;

            case 3:
                string modeleUserInput = GetStringInput("Entrez la marque recherchée");
                vehiculesFilterdBy = vehicules.OrderBy(v => v.Modele == modeleUserInput).ToList();
                Console.WriteLine("Voici la liste de véhicule triée par Modèle");
                break;

            case 4:
                int puissanceMin = GetIntInput("Entrez la puissance minimum");
                int puissanceMax = GetIntInput("Entrez la puissance maximum");
                vehiculesFilterdBy = vehicules.Where(v => v is Voiture)
                                            .OrderBy(v => (((Voiture)v).Puissance >= puissanceMin) && (((Voiture)v).Puissance <= puissanceMax))
                                            .ToList();
                Console.WriteLine("Voici la liste de voiture triée par Puissance");
                break;

            case 5:
                int poidsMin = GetIntInput("Entrez la puissance minimum");
                int poidsMax = GetIntInput("Entrez la puissance maximum");
                vehiculesFilterdBy = vehicules.Where(v => v is Voiture)
                                            .OrderBy(v => (((Voiture)v).Puissance >= poidsMin) && (((Voiture)v).Puissance <= poidsMax))
                                            .ToList();
                Console.WriteLine("Voici la liste de voiture triée par poids");
                break;

            default:
                Console.WriteLine($"Le paramètre {parameterOfFiltre} ne permet pas le tri de la liste de véhicules");
                return;
        }
        if (vehiculesFilterdBy.Count != 0)
        {
            foreach (Vehicule vehicule in vehiculesFilterdBy)
                Console.WriteLine(vehicule.ToString());
        }
        else { Console.WriteLine("Aucun véhicule ne correspond à vos critère"); }

    }
}
