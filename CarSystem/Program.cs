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
                    c.Year = ScanerManager.ReadInteger("Maşının ilini daxil edin: ");
                    c.Engine = ScanerManager.ReadDouble("Maşının mühərrikini daxil edin: ");
                    c.Price = ScanerManager.ReadDouble("Maşının qiymətini daxil edin: ");
                    Console.WriteLine("------");
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("------");
                    c.ModelId = ScanerManager.ReadInteger("Marka ID-ni daxil edin:  ");
                    carMgr.Add(c);

                    goto case Menu.CarsAll;
                   
                case Menu.CarEdit:                   
                    
                        int id1 = ScanerManager.ReadInteger("Redaktə etmək istədiyiniz maşının İD-ni daxil edin: ");
                        Car carForEdit = carMgr.GetAll().FirstOrDefault(g => g.Id == id1);
                        carForEdit.Color = ScanerManager.ReadString("Maşının rəngini dəyiş:  ");
                        carForEdit.Year= ScanerManager.ReadInteger("Maşının ilini dəyiş:  ");
                        carForEdit.Price = ScanerManager.ReadDouble("Maşının qiymətini dəyiş:  ");
                        carForEdit.Engine = ScanerManager.ReadDouble("Maşının mühərrikini dəyiş:  ");
                                       
                    carMgr.Edit(carForEdit);

                    foreach (var item in carMgr.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    goto case Menu.CarsAll;

                case Menu.CarRemove:

                    Console.Clear();
                    ShowAllCars(carMgr);
                    int id = ScanerManager.ReadInteger("Silmək istədiyiniz maşının İD-ni daxil edin: ");
                    Car c1 = carMgr.GetAll().FirstOrDefault(c1 => c1.Id == id);
                    carMgr.Remove(c1);
                    goto case Menu.CarsAll;

                  
                case Menu.CarSingle:
                    Console.Clear();
                    ShowAllCars(carMgr);
                    int idForSingle = ScanerManager.ReadInteger("Ətraflı baxmaq istədiyiniz maşının İD-si:  ");
                    Car cSingle = carMgr.GetAll().FirstOrDefault(cSingle => cSingle.Id == idForSingle);
                  
                    Console.WriteLine($"-----------------------\n" +
                        $"Marka İD-si: {cSingle.ModelId}\n" +
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
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("------------");                   

                    brandMgr.Add(b);
                    goto case Menu.BrandsAll;

                case Menu.BrandEdit:
                    int idg = ScanerManager.ReadInteger("Redaktə etmək istədiyiniz markanın İD-ni daxil edin: ");
                    Brand edit2 = brandMgr.GetAll().FirstOrDefault(g => g.Id == idg);
                    edit2.Name = ScanerManager.ReadString("Markanın adını dəyiş:  ");
                    brandMgr.Edit(edit2);

                    foreach (var item in brandMgr.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    goto case Menu.BrandsAll;
                case Menu.BrandRemove:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    int bİd = ScanerManager.ReadInteger("Silmək istədiyiniz brandın İD-ni daxil edin: ");
                    Brand b1 =brandMgr.GetAll().FirstOrDefault(b1 => b1.Id == bİd);
                    brandMgr.Remove(b1);
                    goto case Menu.BrandsAll;

                case Menu.BrandSingle:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    int idForSingleBrand = ScanerManager.ReadInteger("Ətraflı baxmaq istədiyiniz markanın İD-si:  ");
                    Brand bSingle = brandMgr.GetAll().FirstOrDefault(bSingle => bSingle.Id == idForSingleBrand);
                    Console.WriteLine($"-----------------------\n" +
                        $"Marka adı: {bSingle.Name}\n");
                        

                    foreach (var item in modelMgr.GetAll())
                    {
                        if (item.BrandId == bSingle.Id)
                            Console.WriteLine(item);
                    }
                    Console.WriteLine("-----------------------");
                    goto readMenu;

                case Menu.BrandsAll:
                    Console.Clear();
                    ShowAllBrands(brandMgr);
                    goto readMenu;

                case Menu.ModelAdd:
                    Console.Clear();
                    Model mm = new Model();
                   mm.Name = ScanerManager.ReadString("Maşının modelini daxil edin: ");
                    Console.WriteLine("---------");
                    ShowAllBrands(brandMgr);
                    Console.WriteLine("---------");
                    mm.BrandId = ScanerManager.ReadInteger("Modelin ID-ni daxil edin: ");
                    modelMgr.Add(mm);

                    goto case Menu.ModelsAll;
                case Menu.ModelEdit:
                    int idm = ScanerManager.ReadInteger("Redaktə etmək istədiyiniz modelin İD-ni daxil edin: ");
                    Model edit1 = modelMgr.GetAll().FirstOrDefault(g => g.Id == idm);
                    edit1.Name = ScanerManager.ReadString("Modeli dəyiş:  ");
                    modelMgr.Edit(edit1);

                    foreach (var item in modelMgr.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    goto case Menu.ModelsAll;
                case Menu.ModelRemove:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    int mId = ScanerManager.ReadInteger("Silmək istədiyiniz modelin İD-ni daxil edin: ");
                  Model m1 = modelMgr.GetAll().FirstOrDefault(m1 => m1.Id == mId);
                   modelMgr.Remove(m1);
                    goto case Menu.ModelsAll;
                case Menu.ModelSingle:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    int idForSingleModel = ScanerManager.ReadInteger("Ətraflı baxmaq istədiyiniz modelin İD-si:  ");
                    Model mSingle = modelMgr.GetAll().FirstOrDefault(mSingle => mSingle.Id == idForSingleModel);
                    
                    Console.WriteLine($"-----------------------\n" +
                        $"Marka adı: {mSingle.Name}\n"+
                        $"Marka ID-si: {mSingle.BrandId}\n");


                    foreach (var item in carMgr.GetAll())
                    {
                        if (item.ModelId == mSingle.Id)
                            Console.WriteLine(item);
                    }
                    Console.WriteLine("-----------------------");
                    goto readMenu;
                case Menu.ModelsAll:
                    Console.Clear();
                    ShowAllModels(modelMgr);
                    goto readMenu;
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
