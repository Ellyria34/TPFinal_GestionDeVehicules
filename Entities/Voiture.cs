using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;
public class Voiture : Vehicule
{
    # region Propriétés
    public int Puissance {  get; set; }

    #endregion

    #region Constructeurs
    public Voiture() { }

    public Voiture (int numero, string marque, string modele, int puissance) : base (numero, marque, modele)
    {
        Puissance = puissance;
    }
    #endregion


    #region methodes

    public override string ToString()
    {
        return string.Format("Numéro : {0, -8} Marque : {1, -15} Modele : {2, -20} Puissance : {3, 5} chevaux", Numero, Marque, Modele, Puissance);
    }

    #endregion



}
