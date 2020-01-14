using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Console.Models
{


    public class Presidente : ICalculoImpostoRenda
    {
        public double Salario { get; set; } = 5000;

        public double CalcularValorImposto()
        {
            return (Salario * 0.25);
        }
    }
}
