using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;
public class InvalidNumeroFormatException : Exception
{
    public InvalidNumeroFormatException() : base(message: "Le numéro Entré n'est de contient pas entre 4 et 6 chiffre") { }
}
