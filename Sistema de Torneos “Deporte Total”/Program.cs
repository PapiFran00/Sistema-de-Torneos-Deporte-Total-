using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Torneo.Logica;

namespace Sistema_de_Torneos__Deporte_Total_
{
    internal class Program
    {
                
        static List<Equipo> listaEquipos = new List<Equipo>();
        static List<Partido> listaPartidos = new List<Partido>();

        static void Main(string[] args)
        {

            int opcion;

            while (true)
            {

                Console.WriteLine("Bienvenidos");
                Console.WriteLine("\nSeleccione una opcion:");
                Console.WriteLine(" 1. Registrar nuevo equipo");
                Console.WriteLine(" 2. Ver equipos");
                Console.WriteLine(" 3. Jugar partido");
                Console.WriteLine(" 4. Ver tabla de posiciones");
                Console.WriteLine(" 5. Ver historial de partidos");
                Console.WriteLine(" 6. Salir\n");

                opcion = Convert.ToInt32(Console.ReadLine());


                switch (opcion)
                {
                    case 1:

                        CrearEquipo();

                        break;

                    case 2:

                        if (listaEquipos.Count == 0)
                        {

                            Console.WriteLine("No hay equipos");

                        }

                        else
                        {

                            Console.WriteLine("Lista de equipos actuales:");
                            foreach (var equipo in listaEquipos)
                            {

                                Console.WriteLine(equipo);

                            }
                            Console.WriteLine();
                        }

                        break;

                    case 3:

                        CrearPartido(listaEquipos, listaPartidos);

                        break;

                    case 4:

                        TablaDePosiciones(listaEquipos);

                        break;

                    case 5:

                        if (listaPartidos.Count == 0)
                        {

                            Console.WriteLine("Aun no hay partidos");

                        }

                        else
                        {

                            Console.WriteLine("Lista de partidos");
                            foreach (var partido in listaPartidos)
                            {

                                Console.WriteLine(partido);

                            }
                            Console.WriteLine();
                        }

                        break;

                    case 6:

                        Console.WriteLine("Saliendo...\n");

                        return;

                    default:

                        Console.WriteLine("Opcion invalidad. Intente de nuevo\n");

                        break;


                }




            }

        }










        
           public static void CrearEquipo()
           {

            Console.WriteLine("Cual es el nombre del equipo:");
            string nombre = Console.ReadLine();

            Console.WriteLine("De que ciudad es:");
            string ciudad = Console.ReadLine();

            Equipo nuevoEquipo = new Equipo(nombre, ciudad);

            listaEquipos.Add(nuevoEquipo);

            Console.WriteLine($"El equipo {nombre} se creo correctamente\n");

           }

           public static void CrearPartido (List<Equipo> equipos, List<Partido> partidos)
           {

              if (listaEquipos.Count <2)
              {

                Console.WriteLine("No hay equipos suficientes.\n");

                return;
              }

               Console.WriteLine("Equipos:");


              for (int i = 0; i < equipos.Count; i++)
              {

                Console.WriteLine($"{i+1}. {equipos[i].Nombre}  ({equipos[i].Ciudad})");

              }

              Console.WriteLine("Seleccione el equipo Local: ");
              int local = int.Parse(Console.ReadLine()) -1;

              Console.WriteLine("Seleccione el equipo visitante: ");
              int visitante = int.Parse(Console.ReadLine()) - 1;

              if (local == visitante)
              {

                Console.WriteLine("No se puede lo mismos equipos. \n");
                return ;

              }

              Console.WriteLine("Ingrese la fecha del partido: ");
              string fecha = Console.ReadLine();



              Console.WriteLine($"Goles de {equipos[local].Nombre}: ");
              int golesLocal = int.Parse(Console.ReadLine());

              Console.WriteLine($"Goles de {equipos[visitante].Nombre}: ");
              int golesVisitante = int.Parse(Console.ReadLine());



              equipos[local].GolesAFavor += golesLocal;
              equipos[local].GolesEnContra += golesVisitante;

              equipos[visitante].GolesAFavor += golesVisitante;
              equipos[visitante].GolesEnContra += golesLocal;


              equipos[local].PartidosJugados++;
              equipos[visitante].PartidosJugados++;


            if (golesLocal > golesVisitante)
              {

                  equipos[local].Puntos += 3;

              }

              else if (golesVisitante > golesLocal)
              {

                equipos[visitante].Puntos += 3;

              }

              else
              {

                equipos[local].Puntos += 1;
                equipos[visitante].Puntos += 1;

              }




                Partido nuevoPartido = new Partido
                (

                    equipos[local],
                    equipos[visitante],
                    fecha,
                    golesLocal,
                    golesVisitante


                );



              partidos.Add( nuevoPartido );
              Console.WriteLine("Partido registrado.\n");
           }

        public static void TablaDePosiciones(List<Equipo> equipos)
        {



            if (equipos.Count == 0)
            {

                Console.WriteLine("No hay equipos");
                return;

            }

            else
            {
                for (int i = 0; i < equipos.Count - 1; i++)
                {

                    for (int j = i; j < equipos.Count; j++)
                    {

                        if (equipos[j].Puntos > equipos[i].Puntos)
                        {
                            Equipo aux = equipos[i];
                            equipos[i] = equipos[j];
                            equipos[j] = aux;

                        }

                    }

                }
                Console.WriteLine("        TABLA DE POSICIONES      \n");
                Console.WriteLine("EQUIPO              PJ  GF  GC  DG  PTS\n");

                foreach (Equipo equipo in equipos)
                {

                    Console.WriteLine($"{equipo.Nombre,-18} {equipo.PartidosJugados,2}  {equipo.GolesAFavor,2}  {equipo.GolesEnContra,2}  {equipo.DiferenciaGoles,3}  {equipo.Puntos,3}\n");
                }

            }
        }
             
    }

}


    




