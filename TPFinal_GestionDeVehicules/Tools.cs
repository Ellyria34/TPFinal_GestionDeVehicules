using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TPFinal_GestionDeVehicules;
public class Tools
{
    /// <summary>
    /// Recupère l'entré utilisateur de type string.
    /// </summary>
    /// <returns>La valeur saisie par l'utilisateur de type string.</returns>
    ///
    public static string GetStringInput(string label)
    {
        Console.WriteLine(label);
        string userInputString = Console.ReadLine();
        return userInputString;
    }

    /// <summary>
    /// Récupère l'entré utilisateur de type int
    /// </summary>
    /// <returns>La valeur saisie par l'utilisateur de type int.</returns>
    public static int GetIntInput(string label)
    {
        Console.WriteLine(label);
        string userInputString = Console.ReadLine();
        int userInputInt;
        int.TryParse(userInputString, out userInputInt);
        return userInputInt;
    }

    /// <summary>
    /// Récupère l'entré utilisateur de type int
    /// </summary>
    /// <returns>La valeur saisie par l'utilisateur de type int.</returns>
    public static double GetDoubleInput(string label)
    {
        Console.WriteLine(label);
        string userInputString = Console.ReadLine();
        double userInputDouble;
        double.TryParse(userInputString, out userInputDouble);
        return userInputDouble;
    }

    /// <summary>
    /// Enregistre tous les véhicules de la liste vehicules dans un fichier JSON
    /// </summary>
    /// <typeparam name="List"></typeparam>
    /// <param name=""></param>
    /// <param name=""></param>
    public static void SaveInJSONFile<List>(List<Vehicule> listDeVehicules, string fileName)
    {
        string jsonString = JsonSerializer.Serialize(listDeVehicules);
        File.WriteAllText(fileName, jsonString);
    }

    /// <summary>
    /// Récupère tout les véhicules stocké dans un fichier JSON et le stock dans une liste
    /// </summary>
    /// <typeparam name="List"></typeparam>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static List<Vehicule> LoadListVehicules<List>(string fileName)
    {
        if(File.Exists(fileName))
        {
            string fileContent = File.ReadAllText(fileName);
            List<Vehicule> vehicules = JsonSerializer.Deserialize<List<Vehicule>>(fileContent);
            return vehicules;
        }
        else {
            Console.WriteLine("Le fichier n'a pas était trouvé");
            List<Vehicule> vehicules = new List<Vehicule>() { };
            return (vehicules);
        }
    }

}

