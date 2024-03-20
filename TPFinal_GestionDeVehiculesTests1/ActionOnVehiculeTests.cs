using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFinal_GestionDeVehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Exceptions;

namespace TPFinal_GestionDeVehicules.Tests;

[TestClass()]
public class ActionOnVehiculeTests
{
    [TestMethod()]
    [ExpectedException(typeof(InvalidNumeroFormatException))]
    public void CreateVehiculeAsyncTestNumeroFormatInvalid()
    {
        //Arrange
        List<Vehicule> vehicules = new List<Vehicule>();
        int numero = 0;
        string? marque = "NISSAN";
        string? modele = "Note";
        string typeOfVehicule = "1";
        int puissance = 140;


    }
}