using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;
public class InvalidMarqueFormatException : Exception
{
    public InvalidMarqueFormatException(): base(message: "La marque ne doit pas contenir de chiffre") { }
}
