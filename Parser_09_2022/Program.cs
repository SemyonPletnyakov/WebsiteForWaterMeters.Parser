using System;
using System.Diagnostics;
using System.IO;

namespace Parser_09_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Stopwatch();
            t.Start();

            string path = "zadaine1.txt";
            using (StreamReader reader = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                ApplicationContext db = new ApplicationContext();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                string strZapis = reader.ReadLine(); 
                string[] masZapis = new string[21];
                int id = 0;
                int i = 1;
                while (strZapis != null) 
                {
                    string[] promZapis = strZapis.Split(';');
                    if (promZapis.Length > 0 && (promZapis.Length>3? (promZapis.Length - 3) % 2 == 0 : true))
                    {
                        masZapis[0] = "";
                        masZapis[1] = "";
                        masZapis[2] = "";
                        masZapis[3] = "";
                        masZapis[4] = "0";
                        masZapis[5] = "";
                        masZapis[6] = "0";
                        masZapis[7] = "";
                        masZapis[8] = "0";
                        masZapis[9] = "";
                        masZapis[10] = "0";
                        masZapis[11] = "";
                        masZapis[12] = "0";
                        masZapis[13] = "";
                        masZapis[14] = "0";
                        masZapis[15] = "";
                        masZapis[16] = "0";
                        masZapis[17] = "";
                        masZapis[18] = "0";
                        masZapis[19] = "";
                        masZapis[20] = "0";

                        promZapis.CopyTo(masZapis, 0);

                        if (masZapis[0].Length != 0 && masZapis[0] != " " && Int32.TryParse(masZapis[0], out id))
                        {
                            try
                            {
                                string[] adres = new string[4];
                                adres[0] = "";
                                adres[1] = "";
                                adres[2] = "1";
                                adres[3] = "0";
                                string[] adres2 = masZapis[2].Split(',',4,StringSplitOptions.TrimEntries);
                                adres2.CopyTo(adres, 0);
                                Person person1 = new Person()
                                {
                                    Id = id,
                                    FIO = masZapis[1],
                                    Gorod = adres[0],
                                    Ulica = adres[1],
                                    Dom = adres[2],
                                    Kvartira = adres[3],
                                    NameСounter1 = masZapis[3],
                                    Сounter1 = Convert.ToDouble(masZapis[4].Replace('.', ',')),
                                    NameСounter2 = masZapis[5],
                                    Сounter2 = Convert.ToDouble(masZapis[6].Replace('.', ',')),
                                    NameСounter3 = masZapis[7],
                                    Сounter3 = Convert.ToDouble(masZapis[8].Replace('.', ',')),
                                    NameСounter4 = masZapis[9],
                                    Сounter4 = Convert.ToDouble(masZapis[10].Replace('.', ',')),
                                    NameСounter5 = masZapis[11],
                                    Сounter5 = Convert.ToDouble(masZapis[12].Replace('.', ',')),
                                    NameСounter6 = masZapis[13],
                                    Сounter6 = Convert.ToDouble(masZapis[14].Replace('.', ',')),
                                    NameСounter7 = masZapis[15],
                                    Сounter7 = Convert.ToDouble(masZapis[16].Replace('.', ',')),
                                    NameСounter8 = masZapis[17],
                                    Сounter8 = Convert.ToDouble(masZapis[18].Replace('.', ',')),
                                    NameСounter9 = masZapis[19],
                                    Сounter9 = Convert.ToDouble(masZapis[20].Replace('.', ','))
                                };
                                db.Persons.Add(person1);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Ошибка в строке: " + strZapis);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ошибка в строке: " + strZapis);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка в строке: " + strZapis);
                    }
                    if (i==50000) 
                    {
                        db.SaveChanges();
                        db = new ApplicationContext();
                        i = 0;
                    }
                    i++;
                    strZapis = reader.ReadLine();
                }
                db.SaveChanges();
                
            }

            t.Stop();
            Console.WriteLine("Затраченное время: " + t.Elapsed);
        }
    }
}
