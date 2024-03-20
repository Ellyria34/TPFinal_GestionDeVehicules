using Entities.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Entities;

[JsonDerivedType(typeof(Voiture), typeDiscriminator: "voiture")]
[JsonDerivedType(typeof(Camion), typeDiscriminator: "camion")]

public class Vehicule
{
    #region attributs
    public int numero;
    public string? marque;
    #endregion

    #region Propriétés

    public int Numero
    {
        get { return numero; }
        set
        {
            if (value >= 1000 && value <= 999999)
            {
                numero = value;
            }
            else
            {
                throw new InvalidNumeroFormatException();
            }
        ;
        }
    }
    public string? Marque
    {
        get { return marque; }
        set
        {
            if (!value.Any(c => char.IsDigit(c)) && value == null)
                throw new InvalidMarqueFormatException();
            else
            {
                marque = value;
            }
            ;
        }
    }

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