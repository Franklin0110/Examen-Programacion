using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Examen_Programacion
{
    internal class Clsmenu
    {

        
        public static ClsTransacciones Transacciones = new ClsTransacciones();
        static void Main(string[] args)
        {
            menufuncion();
        }

        private static void menufuncion()

        {//voidmenufuncion (
            bool condicion = false;
            byte opcion;
            //variables para el menu
            do
            { //domenu (



                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("|                Menú de opciones:                 |");
                Console.WriteLine("|                                                  |");
                Console.WriteLine("|   1. Inicializar vectores.                       |");
                Console.WriteLine("|   2. Ingresar paso vehicular.                    |");
                Console.WriteLine("|   3. Consulta de vehículos x Número de Placa.    |");
                Console.WriteLine("|   4. Modificar Datos Vehículos x número de Placa.|");
                Console.WriteLine("|   5. Reporte Todos los Datos de los vectores     |");
                Console.WriteLine("|   6. Salir                                       |");
                Console.WriteLine("|                                                  |");
                Console.WriteLine("----------------------------------------------------");

                //intenta pedirle los datos hasta que sea correcto o hasta que el valor sea igual a 3
                opcion = validar();

                switch (opcion)
                {
                    case 1:
                        Transacciones.IniciarVectores();
                        condicion = true;
                        break;
                    case 2:
                        if (condicion == true)
                        {
                            if (Transacciones.GetcantidadRecibos() != 9)
                            {

                                String var3 = "";
                                Boolean var = false;
                                byte var2 = 0;
                                do
                                {
                                    Transacciones.IngresarPasoVehicular();

                                    do
                                    {
                                        try
                                        {
                                            Console.WriteLine("Desea continuar? n/s");
                                            var3 = Console.ReadLine();
                                            if (var3.Equals("") || var3.Equals("n") || var3.Equals("N"))
                                            {
                                                var2 = 3;
                                                break;
                                            }
                                            if (var3.Equals("S") || var3.Equals("s"))
                                            {
                                                Transacciones.IngresarPasoVehicular();
                                            }

                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Porfavor dijite un dijito valido.");
                                            var2++;
                                            if (var2 == 3)
                                            {
                                                Console.WriteLine("Saliendo a menu principal por series de error");
                                            }
                                        }
                                    } while (var2 != 3);


                                } while (var != false);
                            }
                            else
                            {
                                Console.WriteLine("No se pueden ingresar mas pasos vehiculares.");
                            }
                        }
                        else { Console.WriteLine("Porfavor iniciar las variables antes de tomar otra accion."); 
                        }
                        break;
                    case 3:
                        if (condicion == true)
                        {

                        
                        try
                        {
                            Console.WriteLine("Porfavor dijite la placa a consultar");
                            Transacciones.Consultar(Console.ReadLine());
                            Console.WriteLine("");
                            Console.WriteLine("Dijite una tecla para continuar.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error, dijite un String valido");
                        }
                        }
                        else { Console.WriteLine("Porfavor iniciar las variables antes de tomar otra accion."); }


                        break;
                    case 4:
                        if (condicion == true)
                        {

                        
                        try
                        {
                            Console.WriteLine("Porfavor dijite la placa a consultar");
                            String placa = Console.ReadLine();
                                if (Transacciones.ConsultarPlaca(placa) != 100)
                                {
                                    Transacciones.Modificar(placa);
                                }

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error, dijite un String valido");
                        }
                        }
                        else { Console.WriteLine("Porfavor iniciar las variables antes de tomar otra accion."); }

                        break;
                    case 5:
                        if (condicion == true) { 
                        Transacciones.mostrartodo();
                        Console.Clear();
                        }
                        else { Console.WriteLine("Porfavor iniciar las variables antes de tomar otra accion."); }
                        break;
                    case 6:
                        Environment.Exit(1);
                        break;
                }

            } while (opcion != 6); //domenu )



        }//voidmenufuncion )

        public static byte validar()
        {
            byte error = 0;
            byte opcionmenu;
            do
            {
                try
                {
                    Console.Write("Opcion a introducir: ");
                    opcionmenu = Byte.Parse(Console.ReadLine());
                    //en tal caso que no de error a la hora de dijitar el numero se le asignara 3 a la variable error y saldra de loop
                    error = 3;
                    return opcionmenu;
                }
                catch (Exception)
                {
                    //en caso de que haya un error se le suamra a error 1 hasta que sea 3, si es igual a 3 se saldra del loop con un error.
                    error++;
                    if (error != 3)
                    {
                        Console.WriteLine("Error, porfavor introduzca un dijito valido");

                        Console.WriteLine("Dijite una tecla para continuar");
                        Console.ReadKey();
                    }
                    Console.WriteLine("");
                    if (error == 3)
                    {
                        Console.WriteLine("Error en serie, saliendo a menu...");
                        return 0;
                    }

                }
            } while (error != 3);
            return 0;

        }


    }
}
