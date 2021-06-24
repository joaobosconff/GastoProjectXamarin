using System;
using System.Collections.Generic;
using System.Text;

namespace GastoProject.Model
{
    public class Gasto
    {
        public double Preco { get; set; }

        public string Descricao { get; set; }

        public Gasto(double v1, string v2)
        {
            Preco = v1;
            Descricao = v2;
        }

    }
}
