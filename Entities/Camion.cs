using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;
public class Camion : Vehicule
{
    #region Propriétés
    public double Poids { get; set; }

    #endregion

    #region Constructeurs
    public Camion() { }
    public Camion(int numero, string marque, string modele, double poids) : base(numero, marque, modele)
    {
        Poids = poids;
    }
    #endregion


    #region methodes

    public override string ToString()
    {
        return string.Format("Numéro : {0, -8} Marque : {1, -15} Modele : {2, -20} Poids :      {3, 5} Tonne", Numero, Marque, Modele, Poids);
    }

    #endregion
}
