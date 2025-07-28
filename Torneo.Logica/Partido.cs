using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torneo.Logica
{
    internal class Partido
    {
    }
}

public class Partido
{
    

    public Equipo Local { get; set; }
    public Equipo Visitante { get; set; }
    public int GolesLocal { get; set; }
    public int GolesVisitante { get; set; }

    public string Fecha { get; set; }



    public Partido (Equipo local, Equipo visitante, string fecha, int golesLocal, int golesVisitante)
    {

        Local = local;
        Visitante = visitante;
        Fecha = fecha;
        GolesLocal = golesLocal;
        GolesVisitante = golesVisitante;
        

    }


    public override string ToString()
    {
        return $"{Fecha} - {Local.Nombre} ({GolesLocal}) vs ({GolesVisitante}) {Visitante.Nombre}";
    }



}