using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ServiceStationAdministration.Models;

namespace ServiceStationAdministration.DAL
{
    public class StationInitializer : System.Data.Entity.DropCreateDatabaseAlways<StationContext>
    {
        protected override void Seed(StationContext context)
        {
            var Clients = new List<Client>
            {
                new Client {Name = new Name {FirstName = "Brad", LastName = "Pitt"},  DateOfBirth = DateTime.Parse("05/01/1975"), Address = "NYC, 5th avenue, 17", PhoneNumber="+7777777", Email="pittbrad@gmail.com"},
                new Client {Name = new Name {FirstName = "Harry", LastName = "Potter"},  DateOfBirth = DateTime.Parse("06/06/1990"), Address = "Surray, Little Winging, Private drive, 4", PhoneNumber="+13131313", Email="thepotter@gmail.com"},
                new Client {Name = new Name {FirstName = "Albus", LastName = "Dumbledor"},  DateOfBirth = DateTime.Parse("06/16/1881"), Address = "Hogwarts", PhoneNumber="+0000000", Email="theGreatestMagician@gmail.com"},
                new Client {Name = new Name {FirstName = "Gregory", LastName = "House"},  DateOfBirth = DateTime.Parse("05/15/1959"), Address = "Prnston, Baker street, 221B", PhoneNumber="+65658658", Email="HouseMD@gmail.com"},
                new Client {Name = new Name {FirstName = "Dean", LastName = "Winchester"},  DateOfBirth = DateTime.Parse("01/24/1979"), Address = "Chevrolet Impala", PhoneNumber="+545472758", Email="DeanW@gmail.com"},
                new Client {Name = new Name {FirstName = "Sam", LastName = "Winchester"},  DateOfBirth = DateTime.Parse("05/02/1983"), Address = "Chevrolet Impala", PhoneNumber="+995959595", Email="SamW@gmail.com"}
            };

            Clients.ForEach(c => context.Clients.Add(c));
            context.SaveChanges();

            var Cars = new List<Car>
            {
                 new Car { ClientID = 1, Make = "Chevrolet", Model="Camaro", Year=2015, Vin="KL1UF756E6B195928"},
                 new Car { ClientID = 1, Make = "Lada", Model="Kalina", Year=2010, Vin="ZFA18800004473122"},
                 new Car { ClientID = 2, Make = "KAMAZ", Model="Master", Year=2014, Vin="JHLRE48577C415490"},
                 new Car { ClientID = 2, Make = "Reno", Model="Sandero", Year=2015, Vin="KMHBT31GP3U013758"},
                 new Car { ClientID = 3, Make = "Nimbus", Model="3000", Year=2000, Vin="PT1GH744E6B193468"},
                 new Car { ClientID = 4, Make = "Audi", Model="TT RS Roadster", Year=2016, Vin="KL1UF756E6B195928"},
                 new Car { ClientID = 6, Make = "Kia", Model="Soul", Year=2016, Vin="FTLRE4st7C4155490"},
                 new Car { ClientID = 5, Make = "Chevrolet", Model="Impala", Year=1967, Vin="KL1UF756E6B165658"}
            };

            Cars.ForEach(c => context.Cars.Add(c));
            context.SaveChanges();

            var Orders = new List<Order>
            {
                new Order { CarID = 1, Date = DateTime.Parse("09/01/2015"), OrderAmount=500, OrderStatus=OrderStatus.completed},
                new Order { CarID = 2, Date = DateTime.Parse("05/01/2015"), OrderAmount=600, OrderStatus=OrderStatus.canceled},
                new Order { CarID = 3, Date = DateTime.Parse("09/01/2016"), OrderAmount=100, OrderStatus=OrderStatus.inProgress},
                new Order { CarID = 3, Date = DateTime.Parse("09/01/2016"), OrderAmount=550, OrderStatus=OrderStatus.inProgress},
                new Order { CarID = 4, Date = DateTime.Parse("06/05/2015"), OrderAmount=1000, OrderStatus=OrderStatus.completed},
                new Order { CarID = 4, Date = DateTime.Parse("06/02/2011"), OrderAmount=15, OrderStatus=OrderStatus.completed},
                new Order { CarID = 4, Date = DateTime.Parse("06/11/2016"), OrderAmount=300, OrderStatus=OrderStatus.inProgress},
                new Order { CarID = 5, Date = DateTime.Parse("06/08/2015"), OrderAmount=800, OrderStatus=OrderStatus.completed},
                new Order { CarID = 5, Date = DateTime.Parse("06/06/2016"), OrderAmount=99, OrderStatus=OrderStatus.canceled},
                new Order { CarID = 6, Date = DateTime.Parse("06/05/2016"), OrderAmount=200, OrderStatus=OrderStatus.completed},
                new Order { CarID = 6, Date = DateTime.Parse("06/01/2016"), OrderAmount=333, OrderStatus=OrderStatus.completed}
            };

            Orders.ForEach(c => context.Orders.Add(c));
            context.SaveChanges();
        }  
    }
}