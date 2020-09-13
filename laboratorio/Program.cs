using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace laboratorio
{
    class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine("Seleccione la opcion que desea:\n" +
                    "1) Agregar\n" +
                    "2) Leer\n" +
                    "3) Buscar(Cedula)\n");

                int menu;

                menu = Convert.ToInt16(Console.ReadLine());

                switch (menu)

                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Agregar Datos\n");

                        Console.WriteLine("Separar los datos con una `,`\n" +
                            "\nNombre,Apellido,Edad,Cedula\n");

                        string A = (Console.ReadLine());
                        Console.WriteLine("\n" +
                          "\nNombre,Apellido,Edad,Cedula\n");

                        string T = (Console.ReadLine());
                        Console.WriteLine("\n" +
                          "\nNombre,Apellido,Edad,Cedula\n");

                        string Data = (Console.ReadLine());

                        string path = @"C:\Users\bryan pozo\source\repos\laboratorio\laboratorio\archivo.txt";

                        try
                        {
                            if (File.Exists(path))
                            {

                                File.Delete(path);
                            }

                            using (FileStream oFS = File.Create(path))
                            {
                                byte[] miinfo = new UTF8Encoding(true).GetBytes("Nombre,Apellido,Edad,Cedula:\r" + A + "\n" + T + "\n" + Data);
                                oFS.Write(miinfo, 0, miinfo.Length);
                            }

                        }
                        catch (Exception ex)
                        {
                            Console.Write(ex.Message);
                        }
                        break;


                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ver contenido\n");
                        string archivo = @"C:\Users\bryan pozo\source\repos\laboratorio\laboratorio\archivo.txt";

                        string line = "";


                        using (StreamReader file = new StreamReader(archivo))
                        {
                            while ((line = file.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }

                            string Seguir;
                            Console.Write("\nDesea Agregar, leer o Buscar(Cedula) \n               (si/no): ");
                            Seguir = Console.ReadLine().ToLower();
                            Console.Clear();

                            while (Seguir != "n" && Seguir != "no") ;


                        }
                        break;

                    case 3:
                        {
                            FileStream inFile = new FileStream(@"C:\Users\bryan pozo\source\repos\v1 y v2\v1 y v2\archivo.txt", FileMode.Open, FileAccess.Read);
                            StreamReader reader = new StreamReader(inFile);
                            string record;
                            string input;
                            Console.Write("Ingrese la cedula>> ");
                            input = Console.ReadLine();
                            try
                            {
                                //the program reads the record and displays it on the screen
                                record = reader.ReadLine();
                                while (record != null)
                                {
                                    if (record.Contains(input))
                                    {
                                        Console.WriteLine(record);
                                    }
                                    record = reader.ReadLine();
                                }
                            }
                            finally
                            {
                                
                                reader.Close();
                                inFile.Close();
                            }

                        }
                        break;

                }
            }

        }
 }

