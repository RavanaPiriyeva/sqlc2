using ConsoleApp11.Data.DAL;
using ConsoleApp11.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            GameDbContext dbContext = new GameDbContext();
            bool check = true;
            bool check1 = true;

            do
            {
                Console.WriteLine(" 1. Stadion elave et");
                Console.WriteLine(" 2. Stadionları goster");
                Console.WriteLine(" 3. Verilmiş id-li stadionu goster");
                Console.WriteLine(" 4. Verilmiş id-li stadionu sil");
                Console.WriteLine(" 5. Istifadeci elave et");
                Console.WriteLine(" 6. Istifadeci goster");
                Console.WriteLine(" 7. Rezervasiya elave et");
                Console.WriteLine(" 8. Rezervasiya goster");
                Console.WriteLine(" 9.  Verilmiş id-li stadionun rezervasiyalarını göstər");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                        string name = "";
                        string horlypricestr = "";
                        string capasitystr = "";
                        Console.WriteLine("Ad daxil et:");
                        name = CheckString(name);
                        Console.WriteLine("Hourly price daxil et:");
                        int horlyprice = CheckInt(horlypricestr);
                        Console.WriteLine("Capasity daxil et:");
                        int capasity = CheckInt(capasitystr);
                        Stadium stadium = new Stadium
                        {
                            Name = name,
                            HourlyPrice = horlyprice,
                            Capacity = capasity,
                        };
                        dbContext.Stadiums.Add(stadium);
                        dbContext.SaveChanges();
                        break;
                    case "2":

                        List<Stadium> stadiums = dbContext.Stadiums.ToList();

                        foreach (var item in stadiums)
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.HourlyPrice} - {item.Capacity}");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Id daxil et");
                        string idstr = "";
                        int id = CheckInt(idstr);
                        var data = dbContext.Stadiums.Find(id);
                        Console.WriteLine($"{data.Id} - {data.Name} - {data.HourlyPrice} - {data.Capacity}");

                        break;
                    case "4":
                        Console.WriteLine("Id daxil et");
                        string idstr2 = "";
                        int id2 = CheckInt(idstr2);
                        var data2 = dbContext.Stadiums.FirstOrDefault(x => x.Id == id2);
                        dbContext.Stadiums.Remove(data2);

                        dbContext.SaveChanges();
                        break;
                    case "5":
                        string fullanme = "";
                        string email = "";
                        Console.WriteLine("Ad ve soyad daxil et:");
                        fullanme = CheckString(fullanme);
                        Console.WriteLine("Email daxil et");
                        email = CheckString(email);
                    
                        User user = new User
                        {
                            FullName = fullanme,
                            Emaile=email,
                        };
                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                        break;
                    case "6":

                        List<User> users = dbContext.Users.ToList();

                        foreach (var item in users)
                        {
                            Console.WriteLine($"{item.Id} - {item.FullName} - {item.Emaile}");
                        }
                        break;
                    case "7":
                        string stadiumid = "";
                        string userid = "";
                        string startdatestr = "";
                        string enddatestr = "";
                        DateTime startdate;
                        DateTime enddate;
                        bool x = true;
                        bool y = true;
                        bool check2 = true;
                        bool check3 = true;
                        Console.WriteLine("Stadium id daxil et:");
                        int stadiumidint;
                        ;
                        do
                        {
                            stadiumidint = CheckInt(stadiumid);
                            var data4 = dbContext.Stadiums.FirstOrDefault(x => x.Id == stadiumidint);
                            if (data4 != null)
                            {
                                check2 = false;
                            }
                            else
                            {
                                Console.WriteLine("Bele id yoxdur!!!!");
                            }
                        }
                        while (check2);
                      
                        Console.WriteLine("User id  daxil et");
                        int useridint;
                        do
                        {
                            useridint = CheckInt(userid);
                            var data5 = dbContext.Users.FirstOrDefault(x => x.Id == useridint);
                            if (data5 != null)
                            {
                                check3 = false;
                            }
                            else
                            {
                                Console.WriteLine("Bele id yoxdur!!!!");
                            }
                        }
                        while (check3);
                        do
                        {
                            if (x)
                            {
                                Console.WriteLine("Baslangic tarix daxil et!!!");
                            }
                            else
                            {
                                Console.WriteLine("Duzgun daxil et!!!");
                            }
                            startdatestr = Console.ReadLine();
                        }
                        while (!DateTime.TryParse(startdatestr ,out startdate));
                        do
                        {
                            if (y)
                            {
                                Console.WriteLine("Son tarix daxil et!!!");
                            }
                            else
                            {
                                Console.WriteLine("Duzgun daxil et!!!");
                            }
                            enddatestr = Console.ReadLine();
                        }
                        while (!DateTime.TryParse(enddatestr, out enddate));

                        Reservations reservations = new Reservations
                        {
                            StadiumId = stadiumidint,
                            UserId =useridint,
                            StartDate=startdate,
                            EndDate=enddate,
                        };
                        dbContext.Reservations.Add(reservations);
                        dbContext.SaveChanges();
                        break;
                    case "8":

                        List<Reservations> reservations1 = dbContext.Reservations.ToList();
                        
                        foreach (var item in reservations1)
                        {
                            Console.WriteLine($"{item.Id} - {item.StadiumId} - {item.UserId} - {item.StartDate} - {item.EndDate}");
                        }
                        break;
                    case "9":
                        do {
                            Console.WriteLine("Id daxil et");
                            string idstr3 = "";
                            int id3 = CheckInt(idstr3);
                            List<Reservations> reservations12 = dbContext.Reservations.Where(x => x.StadiumId == id3).ToList();
                            dbContext.SaveChanges();
                            if (reservations12.Count!=0)
                            {
                                foreach (var item in reservations12)
                                {

                                    Console.WriteLine($"{item.Id} - {item.StadiumId} - {item.UserId} - {item.StartDate} - {item.EndDate}");
                                    check1 = false;
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Bele id yoxdur!!!!");
                            }
                            
                        }
                        while (check1);
                        break;
                }

            }
            while (check);


        }
        static string CheckString(string word)
        {
            bool check = true;
            do
            {
                if (!check)
                {
                    Console.WriteLine("Duzgun daxil edin !!!!");
                }
                check = false;
                word = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(word));

            return word;
        }

        static int CheckInt(string number)
        {
            int count;
            bool check = true;
            do
            {
                if (!check)
                {
                    Console.WriteLine("Duzgun daxil edin !!!!");
                }
                check = false;
                number = Console.ReadLine();
            }
            while (!int.TryParse(number, out count));

            return count;
        }
    }
}
