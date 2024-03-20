using Entities;
using Entities.Exceptions;
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
        int numeroInput;
        string marqueInput;
        string modeleInput;
        string typeOfVehicule;

        Console.WriteLine("Afin de créer un nouveau véhicule vous devez entrer les informations suivante");
        // Récupération du numéro
        try
        {
            numeroInput = GetIntInput("Indiquer le numéro du véhicule (entre 4 et 6 chiffres) : ");
        }
        catch (InvalidNumeroFormatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        //Récupérer la marque
        try
        {
            marqueInput = GetStringInput("Indiquer la marque du véhicule (sans chiffre)");
        }
        catch (InvalidMarqueFormatException ex)
        {
            Console.WriteLine(ex.Message);
        }


        //Récupérer le modele

        try
        {
            modeleInput =GetStringInput("Indiquer le modèle du véhicule");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        //Recupérer la puissance si il s'agit d'une voiture ou le poids si il s'agit d'un camion

        typeOfVehicule =GetStringInput("Taper le chiffre 1 ou 2 pour indiquer le type de véhicule (1 : voiture , 2 : camion)");
        if (typeOfVehicule == "1" || typeOfVehicule == "2")
        {
            switch (typeOfVehicule)
            {
                case "1":
                    int puissanceInput = GetIntInput("Indiquer la puissance de la voiture");
                    vehicules.Add(new Voiture(numeroInput, marqueInput, modeleInput, puissanceInput));
                    break;
                case "2":
                    double poidsInput =GetDoubleInput("Indiquer le poids du camion en Tonne");
                    vehicules.Add(new Camion(numeroInput, marqueInput, modeleInput, poidsInput));
                    break;
            };
            Console.WriteLine("Le véhicule à bien été ajouté à la liste vehicules");
        }
        else
        {
            Console.WriteLine("Vous devez choisir entre 1 (pour voiture)  et 2 (pour camion)");
            typeOfVehicule =GetStringInput("Indiquer le type de véhicule  : ");
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