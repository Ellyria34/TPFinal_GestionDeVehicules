using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPFinal_GestionDeVehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal_GestionDeVehicules.Tests;

[TestClass()]
public class ActionOnVehiculeTests
{
    [TestMethod()]
    public void CreatVehiculeAsyncTest()
    {
        Assert.Fail();
    }





    public void DiviserTestdivionpardeuxentier()
    {
        //Arrange
        int a = 10;
        int b = 5;

        double resultAttentu = 2;

        // Act
        double result = MathHelper.Diviser(a, b);

        //Assert

        Assert.AreEqual(resultAttentu, result);
    }
}