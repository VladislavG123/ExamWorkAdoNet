using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppContext())
            {
                while (true)
                {
                    Console.WriteLine("1 - Добавить страну");
                    Console.WriteLine("2 - Работа с страной");
                    Console.WriteLine("3 - Вывод информации");
                    Console.WriteLine("4 - Выход");

                    int chouse = IntParser(1, 4);
                    Country country = new Country();

                    if (chouse == 1)
                    {
                        country = AddCountry();
                        context.Countries.Add(country);
                        context.SaveChanges();
                    }
                    else if (chouse == 2)
                    {
                        country = GetCountry();
                    }
                    else if (chouse == 3)
                    {
                        PrintInfo();
                        continue;
                    }
                    else break;


                    while (true)
                    {
                        Console.WriteLine("1 - Добавить город");
                        Console.WriteLine("2 - Работа с городом");
                        Console.WriteLine("3 - Назад");

                        chouse = IntParser(1, 3);
                        City city;

                        if (chouse == 1)
                        {
                            city = AddCity();
                            city.Country = country;
                            context.Cities.Add(city);
                            context.SaveChanges();
                        }
                        else if (chouse == 2)
                        {
                            city = GetCity();
                        }
                        else break;


                        while (true)
                        {
                            Console.WriteLine("1 - Добавить улицу");
                            Console.WriteLine("2 - Назад");

                            chouse = IntParser(1, 2);
                            Street street;

                            if (chouse == 1)
                            {
                                street = AddStreet();
                                street.City = city;
                                context.Streets.Add(street);
                                context.SaveChanges();
                            }
                            else break;
                        }
                    }
                }
            }
        }

        public static void PrintInfo()
        {
            using (var context = new AppContext())
            {
                foreach (var existedCountry in context.Countries)
                {
                    Console.WriteLine($"Страна - {existedCountry.Name}");
                    Console.WriteLine($"Население - {existedCountry.Population}");

                    foreach (var city in existedCountry.Cities)
                    {
                        Console.WriteLine($"\tГород - {city.Name}");
                        Console.WriteLine($"\tНаселение - {city.Population}");

                        foreach (var street in city.Streets)
                        {
                            Console.WriteLine($"\t\tУлица - {street.Name}");
                        }

                    }
                    Console.WriteLine();
                }
            }
        }

        public static Street AddStreet()
        {
            using (var context = new AppContext())
            {
                Street newStreet = new Street();

                while (true)
                {
                    Console.WriteLine("Введите название улицы");
                    newStreet.Name = Console.ReadLine();

                    var streets = context.Streets.Where(street => street.Name == newStreet.Name).ToList();

                    if (streets.Count > 0)
                    {
                        Console.WriteLine("Такая улица уже есть");
                    }
                    else
                        return newStreet;
                }

            }
        }

        public static City AddCity()
        {
            using (var context = new AppContext())
            {
                City newCity = new City();

                while (true)
                {
                    Console.WriteLine("Введите название города");
                    newCity.Name = Console.ReadLine();

                    var cities = context.Cities.Where(city => city.Name == newCity.Name).ToList();

                    if (cities.Count > 0)
                    {
                        Console.WriteLine("Такой город уже есть");
                    }
                    else break;
                }

                Console.WriteLine("Введите население");
                newCity.Population = IntParser(0);
                return newCity;
            }
        }

        public static City GetCity()
        {
            using (var context = new AppContext())
            {
                while (true)
                {
                    Console.WriteLine("Введите название города");
                    string cityName = Console.ReadLine();

                    var cities = context.Cities.Where(city => city.Name == cityName).ToList();
                    if (cities.Count <= 0)
                    {
                        Console.WriteLine("Этого города не существует!");
                    }
                    else
                    {
                        return cities[0];
                    }
                }

            }

        }

        public static Country AddCountry()
        {
            using (var context = new AppContext())
            {
                Country newCountry = new Country();

                while (true)
                {
                    Console.WriteLine("Введите название страны");
                    newCountry.Name = Console.ReadLine();

                    var countries = context.Countries.Where(country => country.Name == newCountry.Name).ToList();

                    if (countries.Count > 0)
                    {
                        Console.WriteLine("Такая страна уже есть");
                    }
                    else break;
                }

                Console.WriteLine("Введите население");
                newCountry.Population = IntParser(0);
                return newCountry;
            }
        }

        public static Country GetCountry()
        {
            using (var context = new AppContext())
            {
                while (true)
                {
                    Console.WriteLine("Введите название страны");
                    string countryName = Console.ReadLine();

                    var countries = context.Countries.Where(country => country.Name == countryName).ToList();
                    if (countries.Count <= 0)
                    {
                        Console.WriteLine("Этой страны не существует!");
                    }
                    else
                    {
                        return countries[0];
                    }
                }

            }

        }

        public static int IntParser(int from, int to)
        {
            int result;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out result) && result >= from && result <= to)
                {
                    return result;
                }
                Console.WriteLine("Неверный ввод!");
            }
        }

        public static int IntParser(int from)
        {
            int result;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out result) && result >= from)
                {
                    return result;
                }
                Console.WriteLine("Неверный ввод!");
            }
        }


    }
}
