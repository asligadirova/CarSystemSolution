using CarSystem.Infrastructure;
using CarSystem.Managers;
using System;
using System.Linq;
using System.Text;

namespace CarSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Title = "Student System v.1";

            var carMgr = new CarManager();
            var brandMgr = new BrandManager();
            var modelMgr = new ModelManager();

        readMenu:
            PrintMenu();

            Menu m = ScanerManager.ReadMenu("Menudan seçin: ");
            switch (m)
            {
                case Menu.CarAdd:

                    Console.Clear();
                    Car c = new Car();
                    c.Color= ScanerManager.ReadString("Maşının rəngini daxil edin: ");
                    c.Year = ScanerManager.ReadDate("Maşının ilini daxil edin: ");
                    c.Engine = ScanerManager.ReadDouble("Maşının mühərrikini daxil edin: ");
                    c.Price = ScanerManager.ReadDouble("Maşının qiymətini daxil edin: ");
                    carMgr.Add(c);

                    goto case Menu.CarsAll;
                   
                case Menu.CarEdit:
                    break;
                case Menu.CarRemove:

                    Console.Clear();
                    ShowAllCars(carMgr);
                    int id = ScanerManager.ReadInteger("Silmək istədiyiniz maşının İD-ni daxil edin: ");
                    Car c1 = carMgr.GetAll().FirstOrDefault(g => g.Id == id);
                    carMgr.Remove(c1);
                    goto case Menu.CarsAll;

                  
                case Menu.CarSingle:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    int idForSingle = ScanerManager.ReadInteger("Ətraflı baxmaq istədiyiniz maşının İD-si:  ");
                    Car cSingle = carMgr.GetAll().FirstOrDefault(g => g.Id == idForSingle);
                    carMgr.Remove(cSingle);
                    Console.WriteLine($"-----------------------\n" +
                        $"Rəng: {cSingle.Color}\n" +
                        $"Qiymət: {cSingle.Price}\n" +
                        $"Mühərrik: {cSingle.Engine}\n" +
                        $"Speciality: {cSingle.Year}\n");

                    foreach (var item in carMgr.GetAll())
                    {
                        if (item.ModelId == cSingle.Id)
                            Console.WriteLine(item);
                    }
                    Console.WriteLine("-----------------------");
                    goto readMenu;
                   
                case Menu.CarsAll:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    goto readMenu;

                case Menu.BrandAdd:

                    Console.Clear();
                    Brand b = new Brand();
                    b.Name = ScanerManager.ReadString("Maşının marka adı: ");
                    

                    Console.WriteLine("------------");
                    ShowAllCars(carMgr);
                    Console.WriteLine("------------");

                    b.Id = ScanerManager.ReadInteger("Telebenin Grupu: ");

                    brandMgr.Add(b);
                    goto case Menu.BrandsAll;

                case Menu.BrandEdit:
                    break;
                case Menu.BrandRemove:
                    break;
                case Menu.BrandSingle:
                    break;
                case Menu.BrandsAll:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    goto readMenu;
                case Menu.ModelAdd:
                    break;
                case Menu.ModelEdit:
                    break;
                case Menu.ModelRemove:
                    break;
                case Menu.ModelSingle:
                    break;
                case Menu.ModelsAll:
                    break;
                case Menu.All:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    ShowAllBrands(brandMgr);
                    ShowAllModels(modelMgr);
                    goto readMenu;
                case Menu.Exit:
                    goto lEnd;
                default:
                    break;
            }


        lEnd:
            Console.WriteLine("END....");
            Console.WriteLine("Çıxmaq üçün hər hansı bir düyməni sıxın");
            Console.ReadKey();




        }
        static void PrintMenu()
        {
            Console.WriteLine(new string('-', Console.WindowWidth));
            foreach (var item in Enum.GetNames(typeof(Menu)))
            {
                Menu m = (Menu)Enum.Parse(typeof(Menu), item);

                Console.WriteLine($"{((byte)m).ToString().PadLeft(2)}. {item}");
            }
            Console.WriteLine($"{new string('-', Console.WindowWidth)}\n");
        }

        static void ShowAllCars(CarManager carMgr)
        {
            Console.WriteLine("***************** Cars *****************");
            foreach (var item in carMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }

        static void ShowAllBrands(BrandManager brandMgr)
        {
            Console.WriteLine("***************** Brands *****************");
            foreach (var item in brandMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
        static void ShowAllModels(ModelManager modelMgr)
        {
            Console.WriteLine("***************** Models *****************");
            foreach (var item in modelMgr.GetAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}
