using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Programacion
{
    internal class ClsTransacciones
    {
        short[] NumeroFactura;
        String[] NumeroDePlaca;
        String[] Fecha;
        String[] Hora;
        Byte[] TipoVehiculo;
        Byte[] NumeroCaseta;
        float[] MontoApagar;
        float[] PagaCon;
        float[] Vuelto;
        byte CantidadRecibos = 0;

        public byte GetcantidadRecibos()
        {
            return this.CantidadRecibos;
        }


        public void IniciarVectores()
        {

            NumeroFactura = new short[10];
            NumeroDePlaca = new String[10];
            Fecha = new String[10];
            Hora = new String[10];
            TipoVehiculo = new Byte[10];
            NumeroCaseta = new Byte[10];
            MontoApagar = new float[10];
            PagaCon = new float[10];
            Vuelto = new float[10];



            for (int i = 0; i < 9; i++)
            {
                this.NumeroFactura[i] = 0;
                this.NumeroDePlaca[i] = "";
                this.Fecha[i] = "";
                this.Hora[i] = "";
                this.TipoVehiculo[i] = 0;
                this.NumeroCaseta[i] = 0;
                this.MontoApagar[i] = 0;
                this.PagaCon[i] = 0;
                this.Vuelto[i] = 0;
            }
            Console.WriteLine("Valores se han vaciado o Inicializados.");
            Console.WriteLine("Dijite una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        public void IngresarPasoVehicular()
        {

            try
            {
                Boolean var = false;
                Console.WriteLine("");
                //Se introduce dato de NumeroFactura
                Console.Write("Porfavor introduzca el numero de factura: ");
                this.NumeroFactura[CantidadRecibos] = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();

                //Se introduce dato de NumeroDePlaca
                Console.Write("Porfavor introduzca el numero de placa: ");
                this.NumeroDePlaca[CantidadRecibos] = Console.ReadLine();
                Console.WriteLine();

                //Se introduce dato de Fecha
                Console.Write("Porfavor introduzca la fecha 00/00/0000: ");
                this.Fecha[CantidadRecibos] = Console.ReadLine();
                Console.WriteLine();

                //Se introduce dato de Hora
                Console.Write("Porfavor introduzca la Hora: ");
                this.Hora[CantidadRecibos] = Console.ReadLine();
                Console.WriteLine();

                do
                {
                    //Se introduce dato de Tipo de vehiculo
                    Console.Write("Porfavor introduzca el Tipo de Vehiculo (1= Moto ,2= Vehículo Liviano, 3 =Camión o Pesado 4=Autobús):");
                    this.TipoVehiculo[CantidadRecibos] = byte.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (this.TipoVehiculo[CantidadRecibos] == 1 || this.TipoVehiculo[CantidadRecibos] == 2 || this.TipoVehiculo[CantidadRecibos] == 3 || this.TipoVehiculo[CantidadRecibos] == 4)
                    {
                        var = true;
                    }
                    else
                    {
                        Console.WriteLine("Introduzca un numero entre 1 y 4");
                    }

                } while (var != true);


                var = false;
                do
                {
                    //Se introduce dato de NumeroCaseta
                    Console.Write("Porfavor introduzca el Numero de Caseta (1,2,3): ");
                    this.NumeroCaseta[CantidadRecibos] = byte.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (this.NumeroCaseta[CantidadRecibos] == 1 || this.NumeroCaseta[CantidadRecibos] == 2 || this.NumeroCaseta[CantidadRecibos] == 3)
                    {
                        var = true;
                    }
                    else
                    {
                        Console.WriteLine("Introduzca un numero entre 1 y 3");
                    }
                } while (var != true);

                switch (this.TipoVehiculo[CantidadRecibos])
                {

                    case 1:
                        this.MontoApagar[CantidadRecibos] = 500;
                        break;
                    case 2:
                        this.MontoApagar[CantidadRecibos] = 700;
                        break;
                    case 3:
                        this.MontoApagar[CantidadRecibos] = 2700;
                        break;
                    case 4:
                        this.MontoApagar[CantidadRecibos] = 3700;
                        break;


                }



                //Se introduce dato de Pagacon, se guarda vuelto y se hace verificacion
                byte temp = 0;
                do
                {


                    Console.WriteLine("Valor a pagar: " + this.MontoApagar[CantidadRecibos]);
                    Console.WriteLine("Introduzca con cuanto va a pagar");
                    this.PagaCon[CantidadRecibos] = float.Parse(Console.ReadLine());


                    if (this.PagaCon[CantidadRecibos] < this.MontoApagar[CantidadRecibos])
                    {
                        Console.WriteLine("No se puede introducir un valor menor al monto a pagar");
                        temp++;
                        if (temp == 3)
                        {
                            IniciarVectores();
                        }
                    }
                    else
                    {
                        temp = 3;
                        this.Vuelto[CantidadRecibos] = this.PagaCon[CantidadRecibos] - this.MontoApagar[CantidadRecibos];
                        Console.WriteLine("El vuelto es: " + this.Vuelto[CantidadRecibos]);

                    }



                } while (temp != 3);
                this.CantidadRecibos++;
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("----INICIO DE ERROR----");
                Console.WriteLine("Hubo un error, para evitar conflictos se le rediccionara al menu principal y se limpiaran los vectores.");
                Console.WriteLine("----FIN DE ERROR----");
                Console.WriteLine("Dijite una tecla para continuar");
                Console.ReadKey();
                Console.WriteLine();
                Console.WriteLine();
                IniciarVectores();
            }






        }

        public byte ConsultarPlaca(String placa)
        {

            for (byte i = 0; i < 9; i++)
            {
                if (this.NumeroDePlaca[i].Equals(placa))
                {
                    return i;
                }

            }

            return 100;

        }



        public void Consultar(String Placa)
        {
            byte var = ConsultarPlaca(Placa);
            if (var == 100)
            {
                Console.WriteLine("El vehiculo no existe.");
                Console.WriteLine("Dijite una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Numero de factura: " + this.NumeroFactura[var]);
                Console.WriteLine("Numero de palca: " + this.NumeroDePlaca[var]);
                Console.WriteLine("Fecha de ingreso: " + this.Fecha[var]);
                Console.WriteLine("Hora de ingreso: " + this.Hora[var]);
                Console.WriteLine("Tipo de vehiculo [1= Moto  2= Vehículo Liviano 3=Camión o Pesado 4=Autobús]: " + this.TipoVehiculo[var]);
                Console.WriteLine("Numero de caseta (1,2,3): " + this.NumeroCaseta[var]);
                Console.WriteLine("Monto a pagar: " + this.MontoApagar[var]);
                Console.WriteLine("Se pago con: " + this.PagaCon[var]);
                Console.WriteLine("Se le dio de vuelto: " + this.Vuelto[var]);

                Console.WriteLine("");


            }

        }

        public void Modificar(String placa)
        {
            Boolean condicion = false;
            do
            {
                Console.Clear();
                Consultar(placa);
                Console.WriteLine("Porfavor dijite que desea modificar.");
            Console.WriteLine("1. Numero de factura");
            Console.WriteLine("2. Numero de caseta");
            Console.WriteLine("3. Pagar con y vuelto");
            Console.WriteLine("4. Fecha");
            Console.WriteLine("5. Hora");
            Console.WriteLine("6. Salir");
            byte CantidadRecibo = ConsultarPlaca(placa);
                
            Boolean var = false;
            byte temp = 0;
            try
            {
               
                    byte vari = Clsmenu.validar();

                    switch (vari)
                {
                    case 1:
                        //Se introduce dato de NumeroFactura
                        Console.Write("Porfavor introduzca el numero de factura: ");
                        this.NumeroFactura[CantidadRecibo] = Convert.ToInt16(Console.ReadLine());
                        Console.WriteLine();

                        break;
                    case 2:
                  var = false;
                        do
                        {
                            //Se introduce dato de NumeroCaseta
                            Console.Write("Porfavor introduzca el Numero de Caseta (1,2,3): ");
                            this.NumeroCaseta[CantidadRecibo] = byte.Parse(Console.ReadLine());
                            Console.WriteLine();
                            if (this.NumeroCaseta[CantidadRecibo] == 1 || this.NumeroCaseta[CantidadRecibo] == 2 || this.NumeroCaseta[CantidadRecibo] == 3)
                            {
                                var = true;
                            }
                            else
                            {
                                Console.WriteLine("Introduzca un numero entre 1 y 3");
                            }
                        } while (var != true);
                        break;
                    case 3:
                        var = false;
                        do
                        {


                            Console.WriteLine("Valor a pagar: " + this.MontoApagar[CantidadRecibo]);
                            Console.WriteLine("Introduzca con cuanto va a pagar");
                            this.PagaCon[CantidadRecibo] = float.Parse(Console.ReadLine());


                            if (this.PagaCon[CantidadRecibo] < this.MontoApagar[CantidadRecibo])
                            {
                                Console.WriteLine("No se puede introducir un valor menor al monto a pagar");
                                temp++;
                                if (temp == 3)
                                {
                                    IniciarVectores();
                                }
                            }
                            else
                            {
                                temp = 3;
                                this.Vuelto[CantidadRecibo] = this.PagaCon[CantidadRecibo] - this.MontoApagar[CantidadRecibo];
                                Console.WriteLine("El vuelto es: " + this.Vuelto[CantidadRecibo]);

                            }

                        } while (temp != 3);
                        break;
                    case 4:
                        //Se introduce dato de Fecha
                        Console.Write("Porfavor introduzca la fecha 00/00/0000: ");
                        this.Fecha[CantidadRecibo] = Console.ReadLine();
                        Console.WriteLine();
                        break;
                    case 5:
                        //Se introduce dato de Hora
                        Console.Write("Porfavor introduzca la Hora: ");
                        this.Hora[CantidadRecibo] = Console.ReadLine();
                        Console.WriteLine();

                        break;
                    case 6:
                            condicion = true;
                            Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Dijite un valor valido.");
                            Console.WriteLine("Dijite una tecla para continuar");
                            Console.ReadKey();  
                            Console.Clear();
                        break;
                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("Error, Volviendo a menu.");
            }
            } while (condicion != true);
        }

        public void mostrartodo() {

            for (byte var = 0; var <= 9; var++)
            {
                if (this.NumeroCaseta[var] != 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("|Registro de paso vehicular #"+var+"|");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Numero de factura: " + this.NumeroFactura[var]);
                    Console.WriteLine("Numero de palca: " + this.NumeroDePlaca[var]);
                    Console.WriteLine("Fecha de ingreso: " + this.Fecha[var]);
                    Console.WriteLine("Hora de ingreso: " + this.Hora[var]);
                    Console.WriteLine("Tipo de vehiculo [1= Moto  2= Vehículo Liviano 3=Camión o Pesado 4=Autobús]: " + this.TipoVehiculo[var]);
                    Console.WriteLine("Numero de caseta (1,2,3): " + this.NumeroCaseta[var]);
                    Console.WriteLine("Monto a pagar: " + this.MontoApagar[var]);
                    Console.WriteLine("Se pago con: " + this.PagaCon[var]);
                    Console.WriteLine("Se le dio de vuelto: " + this.Vuelto[var]);
                    Console.WriteLine("");
                    Console.WriteLine();
                    Console.WriteLine("Dijite una tecla para continuar.");
                    Console.ReadKey();
                }
                
            }

        }

    }
}
