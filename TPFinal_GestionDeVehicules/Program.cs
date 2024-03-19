using Entities;
using static TPFinal_GestionDeVehicules.Tools;
using static TPFinal_GestionDeVehicules.ActionOnVehicule;
using static TPFinal_GestionDeVehicules.Tools;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Threading.Channels;
using TPFinal_GestionDeVehicules;

public class Programe
{
    static List<Vehicule> vehicules = new List<Vehicule>()
    {
        new Voiture(1001, "CITROEN", "C3 WCR", 114),
        new Camion(1002, "IVECO", "POWERSTAR", 9.3),
        new Voiture(1003, "RENAULT", "CLIO V RALLY 5", 180 ),
        new Voiture(1004, "HYUNDAY", "i20WRC", 380 ),
        new Camion(1005, "DAF", "TURBOTWIN", 10.3),
        new Voiture(1006, "NISSAN", "GT-R", 600),
        new Voiture(1007, "FORD", "FIESTA Rally2", 300 ),
        new Voiture(1008, "PEUGEOT", "2008 Rally4", 200 ),
    };



    static void Main(string[] args)
    {
        
        string fileName = "ListeVehicules.json";

        //List<Vehicule> vehicules = LoadListVehicules<List<Vehicule>>(fileName);
        //foreach (var vehicule in vehicules)
        //{
        //    Console.WriteLine(vehicule);
        //}

        static void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("MENU :");
            Console.WriteLine("1 - Créer un véhicules");
            Console.WriteLine("2 - Afficher tous les véhicules");
            Console.WriteLine("3 - Afficher un véhicule à l'aide de son numéro");
            Console.WriteLine("4 - Mettre à jour un véhicule à l'aide de son numéro");
            Console.WriteLine("5 - Supprimer un véhicule à l'aide de son numéro");
            Console.WriteLine("6 - Trier les véhicules");
            Console.WriteLine("7 - Filtrer les véhicules");
            Console.WriteLine("8 - Sauvegarder les véhicules");
            Console.WriteLine();
        }


        DisplayMenu();

        int action = 1;

        while (action != 0)
        {
            action = GetIntInput("Choisissez votre action en entrant le chiffre correspondant");
            Console.WriteLine();
            DisplayMenu();
            switch (action)
            {
                case 1 :
                    CreatVehiculeAsync(vehicules);
                    DisplayMenu();
                    break;

                case 2:
                    
                    GetAllVehicules(vehicules);
                    DisplayMenu();
                    break;

                case 3:
                    GetVehiculeByNumero(vehicules);
                    DisplayMenu();
                    break;

                case 4:
                    //UpdateVehiculeByNumero(vehicules);
                    DisplayMenu();
                    break;

                case 5:
                    DeletedVehiculeByNumero(vehicules);
                    DisplayMenu();
                    break;

                case 6:
                    //SortVehicules(vehicules);
                    DisplayMenu();
                    break;

                case 7:
                    //FilterVehicule(vehicules);
                    DisplayMenu();
                    break;

                case 8:
                    SaveInJSONFile<List<Vehicule>>(vehicules, fileName);
                    break;
            }
        }
    }
}






