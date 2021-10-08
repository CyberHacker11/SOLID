using System;
using System.Collections.Generic;

namespace SOLID
{
    class Program
    {
        #region Single Responsibility Principle

        // *************[Single Responsibility Principle]*************

        public class Product
        {
            public Product() { }

            public Product(string name, string color, int price)
            {
                Name = name;
                Color = color;
                Price = price;
            }

            public string Name { get; private set; }
            public string Color { get; private set; }
            public float Price { get; private set; }
        }

        public class Stock
        {
            public Stock()
            {
                Products = new List<Product>();
                Products.Add(new Product("Samsung", "Black", 2000));
                Products.Add(new Product("Xiaomi", "White", 5000));
                Products.Add(new Product("Iphone", "Blue", 8000));
            }

            public void AddProduct(Product product)
            {
                Products.Add(product);
            }

            public List<Product> Products { get; private set; }
        }

        public class Sale
        {
            public Sale()
            {
                Stock = new Stock();
            }

            public void Purchase(string name)
            {
                for (int i = 0; i < Stock.Products.Count; i++)
                {
                    if (Stock.Products[i].Name == name)
                    {
                        Console.WriteLine("Purchase completed successfully. Have a nice day ;)");
                    }
                }
            }

            public Stock Stock { get; private set; }
        }

        #endregion Single Responsibility Principle

        #region Open/Closed Principle

        // *************[Open/Closed Principle]*************

        public abstract class Cofee
        {
            public Cofee(string name, float price) {
                Name = name;
                Price = price;
            }

            public abstract void PreparationTime();

            public DateTime PrepDate { get; set; }
            public string Name { get; set; }
            public float Price { get; set; }
        }


        public class Capuchino : Cofee
        {
            public Capuchino(string name, float price) : base(name, price) { }

            public override void PreparationTime()
            {
                Name = "Capuchino";
                Price = 5.23F;
            }
        }

        public class Amerikano : Cofee
        {
            public Amerikano(string name, float price) : base(name, price) { }

            public override void PreparationTime()
            {
                Name = "Amerikano";
                Price = 8.5F;
            }
        }

        public class CofeeMachine
        {
            public CofeeMachine() {
                cofees = new List<Cofee>();
            }

            public void Start(Cofee cofee)
            {
                cofee.PrepDate = DateTime.Now;
                cofees.Add(cofee);
            }

            List<Cofee> cofees { get; set; }
        }


        #endregion

        #region Liskov Substition Principle

        // *************[Liskov Substition Principle]*************

        public interface IWrite
        {
            void Write();
        }


        public abstract class OpticalDrive
        {
            public string Type { get; set; }

            public abstract void Read();
        }

        public class DVDRW : OpticalDrive, IWrite
        {
            public override void Read()
            {
                Console.WriteLine("Successfully Read");
            }

            public void Write()
            {
                Console.WriteLine("Successfully Write");
            }
        }

        public class DVDROM : OpticalDrive
        {
            public override void Read()
            {
                Console.WriteLine("Successfully Read");
            }
        }

        public class CDROM : OpticalDrive
        {
            public override void Read()
            {
                Console.WriteLine("Successfully Read");
            }
        }

        #endregion

        #region Interface Segregation Principle

        // *************[Interface Segregation Principle]*************

        public abstract class Car
        {
            public Car(string model, string color, short year)
            {
                Model = model;
                Color = color;
                Year = year;
            }

            public string Model { get; set; }
            public string Color { get; set; }
            public short Year { get; set; }

            public abstract override string ToString();
        }

        interface ISpoiler
        {
            public bool Spoiler { get; set; }
        }

        interface INitro
        {
            public bool Nitro { get; set; }
        }

        interface IBumper
        {
            public bool Bumper { get; set; }
        }

        interface INeon
        {
            public bool Neon { get; set; }
        }

        public class VAZ : Car
        {
            public VAZ(string model, string color, short year) : base(model, color, year) { }
            public override string ToString() {
                return $"Model: {Model} Color: {Color} Year: {Year}";
            }
        }

        public class BMW : Car, ISpoiler
        {
            public BMW(string model, string color, short year, bool spoiler) : base(model, color, year) { Spoiler = spoiler; }

            public override string ToString() {
                return $"Model: {Model} Color: {Color} Year: {Year} Spoiler: {Spoiler}";
            }

            public bool Spoiler { get; set; }
        }

        public class NissanSkyline : Car, ISpoiler, IBumper, INeon
        {
            public NissanSkyline(string model, string color, short year, bool spoiler, bool bumper, bool neon) 
                : base(model, color, year) { 
                Spoiler = spoiler;
                Bumper = bumper;
                Neon = neon;
            }

            public override string ToString() {
                return $"Model: {Model} Color: {Color} Year: {Year} Spoiler: {Spoiler} Bumper: {Bumper} Neon: {Neon}";
            }

            public bool Spoiler { get; set; }
            public bool Bumper { get; set; }
            public bool Neon { get; set; }
        }

        #endregion

        #region Dependency Inversion Principle

        // *************[Dependency Inversion Principle]*************

        public abstract class Phone
        {
            public Phone(string model, string color, int price) {
                Model = model;
                Color = Color;
                Price = Price;
            }

            public abstract override string ToString();

            public int Price { get; set; }
            public string Color { get; set; }
            public string Model { get; set; }
        }

        public class Samsung : Phone
        {
            public Samsung(string model, string color, int price) : base(model, color, price) { }

            public override string ToString() {
                return $"Model: {Model} Color: {Color} Price: {Price}";
            }
        }

        public class Iphone : Phone
        {
            public Iphone(string model, string color, int price) : base(model, color, price) { }

            public override string ToString()
            {
                return $"Model: {Model} Color: {Color} Price: {Price}";
            }
        }

        public class Stock2
        {
            public Stock2() {
                phones = new List<Phone>();
            }
            public void AddProduct(Phone phone) {
                phones.Add(phone);
            }
            List<Phone> phones { get; set; }
        }


        #endregion

        static void Main(string[] args)
        {
            

        }
    }
}
