using System.ComponentModel.DataAnnotations;

namespace Entities;

public abstract class Vehicule
{
    public int numero;
    #region Propriété

    public int Numero { get; set; }
    public string? Marque { get; set; }
    public string? Modele { get; set; }

    #endregion

    #region Constructeurs

    public Vehicule() { }
    public Vehicule(int numero, string? marque, string? modele)
    {
        Numero = numero;
        Marque = marque;
        Modele = modele;
    }

    #endregion

    #region methodes

    public override string ToString()
    {
        return string.Format("Numéro : {0, -8} Marque : {1, -10}, Modele : {2, -10}", Numero, Marque, Modele);
    }

    #endregion
}