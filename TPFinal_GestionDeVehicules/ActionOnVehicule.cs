using Entities;
using static TPFinal_GestionDeVehicules.Tools;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal_GestionDeVehicules;
public class ActionOnVehicule
{
    public static void CreatVehiculeAsync(List<Vehicule> vehicules)
    {
        Console.WriteLine("Afin de créer un nouveau véhicule vous devez entrer les informations suivante");

        // Récupération du numéro
        int mumeroInput = Tools.GetIntInput("Indiquer le numéro du véhicule (entre 4 et 6 chiffres) : ");

        if (mumeroInput >= 1000 && mumeroInput <= 999999)
        {
            int numero = mumeroInput;
        }
        else
        {
            throw new Exception("Le numéro Entré n'est de contient pas entre 4 et 6 chiffre");
            mumeroInput = Tools.GetIntInput("Indiquer le numéro du véhicule (entre 4 et 6 chiffres) : ");
        }

        //Récupérer la marque
        string marqueInput = Tools.GetStringInput("Indiquer la marque du véhicule (sans chiffre)");

        while (!marqueInput.Any(c => char.IsDigit(c)) && marqueInput == null)
        {
            throw new Exception("La marque ne doit pas contenir de chiffre");
            marqueInput = Tools.GetStringInput("Indiquer la marque du véhicule (sans chiffre");
        }
        string marque = marqueInput;

        //Récupérer le modele
        string modeleInput = Tools.GetStringInput("Indiquer le modèle du véhicule");

        while (modeleInput == null)
        {
            throw new Exception("La marque ne doit pas contenir de chiffre");
            modeleInput = Tools.GetStringInput("Indiquer la marque du véhicule (sans chiffre");
        }
        string modele = modeleInput;

        //Recupérer la puissance si il s'agit d'une voiture ou le poids si il s'agit d'un camion
        string typeOfVehicule = Tools.GetStringInput("Taper le chiffre 1 ou 2 pour indiquer le type de véhicule (1 : voiture , 2 : camion)");
        if (typeOfVehicule == "1" || typeOfVehicule == "2")
        {
            switch (typeOfVehicule)
            {
                case "1":
                    int puissanceInput = Tools.GetIntInput("Indiquer la puissance de la voiture");
                    vehicules.Add(new Voiture
                    {
                        Numero = mumeroInput,
                        Marque = marqueInput,
                        Modele = modeleInput,
                        Puissance = puissanceInput
                    });
                    break;
                case "2":
                    double poidsInput = Tools.GetDoubleInput("Indiquer le poids du camion en Tonne");
                    break;
            };
            Console.WriteLine("Le véhicule à bien été ajouté à la liste vehicules");
        }
        else
        {
            throw new Exception("Vous devez choisir entre 1 (pour voiture)  et 2 (pour camion)");
            typeOfVehicule = Tools.GetStringInput("Indiquer le type de véhicule  : ");
        }
    }

    public static void GetAllVehicules(List<Vehicule> vehicules)
    {
        
        foreach (Vehicule v in vehicules)
        {
            Console.WriteLine(v.ToString());
        }
    }

    public static void GetVehiculeByNumero(List<Vehicule> vehicules)
    {
        int intUserInput = GetIntInput("Entez le numéro du véhicule à afficher : ");
        var selectedVehicule = vehicules.FirstOrDefault(v => v.Numero == intUserInput);
        Console.WriteLine(selectedVehicule.ToString());
    }

    public static void DeletedVehiculeByNumero(List<Vehicule> vehicules)
    {
        int intUserInput = GetIntInput("Entez le numéro du véhicule à supprimer : ");
        var selectedVehicule = vehicules.FirstOrDefault(v => v.Numero == intUserInput);
        vehicules.Remove(selectedVehicule);
    }
}