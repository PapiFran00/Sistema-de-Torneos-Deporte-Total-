using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo.Logica
{
    public class Equipo
    {
    }
}


public class Equipo
{

    public string Nombre { get; set; }
    public string Ciudad {  get; set; }
    public int GolesAFavor {  get; set; }
    public int GolesEnContra { get; set; }
    public int Puntos { get; set; }
    public int PartidosJugados { get; set; }



    public Equipo(string nombre, string ciudad)
    {

        Nombre = nombre;
        Ciudad = ciudad;
        GolesAFavor = 0;
        GolesEnContra = 0;
        Puntos = 0;

    }

    public int DiferenciaGoles => GolesAFavor - GolesEnContra;

    public override string ToString()
    {
        return $"{Nombre}  ({Ciudad})";

    }

}




