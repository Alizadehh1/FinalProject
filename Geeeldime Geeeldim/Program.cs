using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Geeeldime_Geeeldim
{
    [Serializable]
    [Obsolete]
    class Program
    {
        static string brandFile = "brands.dat";
        static string modelFile = "models.dat";
        static string carFile = "cars.dat";
        static GenericStore<Brand> brand = LoadFromFile(brandFile);
        static GenericStore<Model> model = LoadFromFile1(modelFile);
        static GenericStore<Car> car = LoadFromFile4(carFile);
        static void Main(string[] args)
        {
            Console.Title = "Alizadehh Saloon";
            Console.CursorVisible = false;

            #region idsohbeti
            try
            {
                using (var fs = new FileStream(brandFile, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    var db = (GenericStore<Brand>)bf.Deserialize(fs);
                    Brand.SetCounter(brand[brand.Count - 1].Id);
                }
            }
            catch (Exception)
            {
            }

            try
            {
                using (var fs = new FileStream(modelFile, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    var db = (GenericStore<Model>)bf.Deserialize(fs);
                    Model.SetCounter(model[model.Count - 1].Id);
                }
            }
            catch (Exception)
            {
            }

            try
            {
                using (var fs = new FileStream(carFile, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    var db = (GenericStore<Car>)bf.Deserialize(fs);
                    Car.SetCounter(car[car.Count - 1].Id);
                }
            }
            catch (Exception)
            {
            } 
            #endregion

            int brandId1;
            int count = 1;
            int index;
            int index1;
            int index2;
            int index3;
            int index4;
            int modelId;
            int index5;

            while (true)
            {
            step:
                Console.Clear();
                string prompt = @"
      _____   .__   .__                     .___       .__     .__                      .__                           
     /  _  \  |  |  |__|_____________     __| _/ ____  |  |__  |  |__     ___________   |  |    ____    ____    ____  
    /  /_\  \ |  |  |  |\___   /\__  \   / __ |_/ __ \ |  |  \ |  |  \   /  ___/\__  \  |  |   /  _ \  /  _ \  /    \ 
   /    |    \|  |__|  | /    /  / __ \_/ /_/ |\  ___/ |   Y  \|   Y  \  \___ \  / __ \_|  |__(  <_> )(  <_> )|   |  \
   \____|__  /|____/|__|/_____ \(____  /\____ | \___  >|___|  /|___|  / /____  >(____  /|____/ \____/  \____/ |___|  /
           \/                 \/     \/      \/     \/      \/      \/       \/      \/                            \/ 
";
                string[] options = { @"
                                                     B R A N D S", @"
                                                     M O D E L S", @"
                                                       C A R S" };
                Menu mainMenu = new Menu(prompt, options);
                int selectedIndex = mainMenu.Run();
                switch (selectedIndex)
                {
                    case 0:
                        {
                            while (true)
                            {
                            step1:
                                Console.Clear();
                                string promptBrand = @"
                                        __________                             .___       
                                        \______   \_______ _____     ____    __| _/ ______
                                         |    |  _/\_  __ \\__  \   /    \  / __ | /  ___/
                                         |    |   \ |  | \/ / __ \_|   |  \/ /_/ | \___ \ 
                                         |______  / |__|   (____  /|___|  /\____ |/____  >
                                                \/              \/      \/      \/     \/
                                    ";  
                                string[] optionsBrand = { @"
                                                    A D D   N E W   B R A N D", @"
                                                       E D I T   B R A N D", @"
                                                   L I S T   O F   B R A N D S", @"
                                                     R E M O V E   B R A N D", @"
                                            B A C K   T O   T H E   M A I N   M E N U", @"
                                                     " };
                                Menu brandMenu = new Menu(promptBrand, optionsBrand);
                                int selectedIndexBrand = brandMenu.Run();
                                switch (selectedIndexBrand)
                                {
                                    case 0:
                                        {
                                            Brand b = new Brand();
                                            Console.Clear();
                                            Console.Write("Enter Brand's Name: ");
                                            b.Name = Console.ReadLine();
                                            brand.Add(b);
                                            SaveToFile(brand, brandFile);
                                            goto step;
                                        }
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Edit Brand by Id ");
                                            GetAllBrand();
                                            index1 = Reader.ReadInteger("Brand Id: ");
                                            Brand selectedBrand = brand.FirstOrDefault(b => b.Id == index1);
                                            Console.Write("Name: ");
                                            selectedBrand.Name = Console.ReadLine();
                                            Console.Clear();
                                            Console.WriteLine("After Editing");
                                            GetAllBrand();
                                            SaveToFile(brand, brandFile);
                                            while (true)
                                            {
                                                Console.WriteLine("1- Back to the menu");
                                                Console.WriteLine("2- Back to the Main Menu");
                                                switch (Reader.ReadInteger("Select Menu: "))
                                                {
                                                    case 1:
                                                        {
                                                            goto step1;
                                                        }
                                                    case 2:
                                                        {
                                                            goto step;
                                                        }
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            GetAllBrand();
                                            while (true)
                                            {
                                                Console.WriteLine("\n1- Back to the menu");
                                                Console.WriteLine("2- Back to the Main Menu");
                                                switch (Reader.ReadInteger("Select Menu: "))
                                                {
                                                    case 1:
                                                        {
                                                            goto step1;
                                                        }
                                                    case 2:
                                                        {
                                                            goto step;
                                                        }
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                    case 3:
                                        {

                                            Console.Clear();
                                            Console.WriteLine("Remove Brand by index");
                                            foreach (var item in brand)
                                            {
                                                Console.WriteLine($"[{count}]{item}");
                                                count++;
                                            }
                                            index = Reader.ReadInteger("Index: ");
                                            brand.RemoveAt(index-1);
                                            count = 1;
                                            SaveToFile(brand, brandFile);
                                            break;
                                        }
                                    case 4:
                                        {
                                            goto step;
                                        }
                                    default:
                                        break;
                                }
                                
                            }
                            
                        }
                    case 1:
                        {
                            
                            while (true)
                            {
                            step2:
                                Console.Clear();
                                string promptModel = @"
                                            _____               .___       .__           
                                           /     \    ____    __| _/ ____  |  |    ______
                                          /  \ /  \  /  _ \  / __ |_/ __ \ |  |   /  ___/
                                         /    Y    \(  <_> )/ /_/ |\  ___/ |  |__ \___ \ 
                                         \____|__  / \____/ \____ | \___  >|____//____  >
                                                 \/              \/     \/            \/ 
";
                                string[] optionsModel = { @"
                                                    A D D   N E W   M O D E L", @"
                                                       E D I T   M O D E L", @"
                                                   L I S T   O F   M O D E L S", @"
                                                     R E M O V E   M O D E L", @"
                                             B A C K   T O   T H E   M A I N   M E N U", @"
                                                     " };
                                Menu modelMenu = new Menu(promptModel, optionsModel);
                                int selectedIndexModel = modelMenu.Run();
                                switch (selectedIndexModel)
                                {
                                    case 0:
                                        {
                                            step4:
                                            Console.Clear();
                                            GetAllBrand();
                                            brandId1 = Reader.ReadInteger("Select Brand: ");
                                            var chooseBrand = brand.Find(x => x.Id == brandId1);
                                            if (chooseBrand==null)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("<<Select Correctly Please!>>");
                                                Task.Delay(1650).Wait();
                                                goto step4;
                                            }
                                            Model m = new Model();
                                            m.MarkaId = chooseBrand.Id;
                                            Console.Write("Enter Model's Name: ");
                                            m.Name = Console.ReadLine();
                                            model.Add(m);
                                            SaveToFile(model, modelFile);
                                            goto step;
                                        }
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Edit Model by ModelId");
                                            GetAllModel();
                                            index3 = Reader.ReadInteger("Model Id: ");
                                            Model selectedModel = model.FirstOrDefault(m => m.Id == index3);
                                            Console.Write("Name: ");
                                            selectedModel.Name = Console.ReadLine();
                                            Console.WriteLine("After Editing");
                                            GetAllModel();
                                            SaveToFile(model, modelFile);
                                            while (true)
                                            {
                                                Console.WriteLine("1- Back to the menu");
                                                Console.WriteLine("2- Back to the Main Menu");
                                                switch (Reader.ReadInteger("Select Menu: "))
                                                {
                                                    case 1:
                                                        {
                                                            goto step2;
                                                        }
                                                    case 2:
                                                        {
                                                            goto step;
                                                        }
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("List Of Model");
                                            GetAllModel();
                                            while (true)
                                            {
                                                Console.WriteLine("\n1- Back to the menu");
                                                Console.WriteLine("2- Back to the Main Menu");
                                                switch (Reader.ReadInteger("Select Menu: "))
                                                {
                                                    case 1:
                                                        {
                                                            goto step2;
                                                        }
                                                    case 2:
                                                        {
                                                            goto step;
                                                        }
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Remove Model by index");
                                            foreach (var item in model)
                                            {
                                                Console.WriteLine($"[{count}]{item}");
                                                count++;
                                            }
                                            index2 = Reader.ReadInteger("Index: ");
                                            model.RemoveAt(index2-1);
                                            count = 1;
                                            SaveToFile(model,modelFile);
                                            break;
                                        }
                                    case 4:
                                        {
                                            goto step;
                                        }
                                    default:
                                        break;
                                }
                            }
                        }
                    case 2:
                        {
                            while (true)
                            {
                            step3:
                                Console.Clear();
                                string promptCar = @"




                                           _________                        
                                           \_   ___ \ _____  _______  ______
                                           /    \  \/ \__  \ \_  __ \/  ___/
                                           \     \____ / __ \_|  | \/\___ \ 
                                            \______  /(____  /|__|  /____  >
                                                   \/      \/            \/
";
                                string[] optionsCar = { @"
                                                 A D D   N E W   C A R", @"
                                                    E D I T   C A R", @"
                                                L I S T   O F   C A R S", @"
                                                  R E M O V E   C A R", @"
                                       B A C K   T O   T H E   M A I N   M E N U", @"
                                                     " };
                                Menu carMenu = new Menu(promptCar, optionsCar);
                                int selectedIndexCar = carMenu.Run();
                                switch (selectedIndexCar)
                                {
                                    case 0:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select Model");
                                            GetAllModel();
                                            modelId = Reader.ReadInteger("Select Model Id: ");
                                            foreach (var item in model)
                                            {
                                                if (item.Id==modelId)
                                                {
                                                    Car c = new Car();
                                                    Console.Write("Enter Car Name: ");
                                                    c.Name = Console.ReadLine();
                                                    c.Year = Reader.ReadInteger("Enter Car's Year: ");
                                                    c.BanNo = Reader.ReadInteger("Enter Car's BanNo: ");
                                                    Console.Write("Enter Car's Transmission: ");
                                                    c.Transmission = Console.ReadLine();
                                                    Console.Write("Enter Car's Color: ");
                                                    c.Color = Console.ReadLine();
                                                    Console.Write("Enter Car's Price: ");
                                                    c.Price = Convert.ToDouble(Console.ReadLine());
                                                    c.Mileage = Reader.ReadInteger("Enter Car's MileAge: ");
                                                    Console.Write("Enter Car's Engine");
                                                    c.Engine = Convert.ToDouble(Console.ReadLine());
                                                    c.ModelId = modelId;
                                                    car.Add(c);
                                                    SaveToFile(car, carFile);
                                                    goto step;
                                                }
                                            }
                                            break;
                                        }
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Edit Car by CarId");
                                            GetAllCar();
                                            index5 = Reader.ReadInteger("Car Id: ");
                                            Car selectedCar = car.FirstOrDefault(c => c.Id == index5);
                                            Console.Write("Enter Car Name: ");
                                            selectedCar.Name = Console.ReadLine();
                                            selectedCar.Year = Reader.ReadInteger("Enter Car's Year: ");
                                            selectedCar.BanNo = Reader.ReadInteger("Enter Car's BanNo: ");
                                            Console.Write("Enter Car's Transmission: ");
                                            selectedCar.Transmission = Console.ReadLine();
                                            Console.Write("Enter Car's Color: ");
                                            selectedCar.Color = Console.ReadLine();
                                            Console.Write("Enter Car's Price: ");
                                            selectedCar.Price = Convert.ToDouble(Console.ReadLine());
                                            selectedCar.Mileage = Reader.ReadInteger("Enter Car's MileAge: ");
                                            Console.Write("Enter Car's Engine");
                                            selectedCar.Engine = Convert.ToDouble(Console.ReadLine());
                                            Console.WriteLine("After Editing");
                                            GetAllCar();
                                            SaveToFile(car, carFile);
                                            while (true)
                                            {
                                                Console.WriteLine("1- Back to the menu");
                                                Console.WriteLine("2- Back to the Main Menu");
                                                switch (Reader.ReadInteger("Select Menu: "))
                                                {
                                                    case 1:
                                                        {
                                                            goto step3;
                                                        }
                                                    case 2:
                                                        {
                                                            goto step;
                                                        }
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("List of Cars");
                                            GetAllCar();
                                            while (true)
                                            {
                                                Console.WriteLine("\n1- Back to the menu");
                                                Console.WriteLine("2- Back to the Main Menu");
                                                switch (Reader.ReadInteger("Select Menu: "))
                                                {
                                                    case 1:
                                                        {
                                                            goto step3;
                                                        }
                                                    case 2:
                                                        {
                                                            goto step;
                                                        }
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Remove Car by index");
                                            foreach (var item in car)
                                            {
                                                Console.WriteLine($"[{count}]{item}");
                                                count++;
                                            }
                                            index4 = Reader.ReadInteger("Select any Index: ");
                                            car.RemoveAt(index4 - 1);
                                            count = 1;
                                            SaveToFile(car, carFile);
                                            while (true)
                                            {
                                                Console.WriteLine("1- Back to the menu");
                                                Console.WriteLine("2- Back to the Main Menu");
                                                switch (Reader.ReadInteger("Select Menu: "))
                                                {
                                                    case 1:
                                                        {
                                                            goto step3;
                                                        }
                                                    case 2:
                                                        {
                                                            goto step;
                                                        }
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                    case 4:
                                        {
                                            goto step;
                                        }
                                    default:
                                        break;
                                }
                            }
                        }
                    default:
                        break;
                }
            }
        }

        static void PrintMenu1()
        {
            Console.WriteLine("<<1>> Brands");
            Console.WriteLine("<<2>> Models");
            Console.WriteLine("<<3>> Cars");
        }
        private static void PrintMenu2()
        {
            Console.WriteLine("<<1>> Add New Brand");
            Console.WriteLine("<<2>> Edit Brand");
            Console.WriteLine("<<3>> List Of Brand");
            Console.WriteLine("<<4>> Remove Brand");
            Console.WriteLine("<<5>> Back to the Main Menu");
        }
        private static void PrintMenu3()
        {
            Console.WriteLine("<<1>> Add New Model");
            Console.WriteLine("<<2>> Edit Model");
            Console.WriteLine("<<3>> List Of Model");
            Console.WriteLine("<<4>> Remove Model");
            Console.WriteLine("<<5>> Back to the Main Menu");
        }
        private static void PrintMenu4()
        {
            Console.WriteLine("<<1>> Add New Car");
            Console.WriteLine("<<2>> Edit Car");
            Console.WriteLine("<<3>> List Of Cars");
            Console.WriteLine("<<4>> Remove Car");
            Console.WriteLine("<<5>> Back to the Main Menu");
        }
        [Obsolete]
        static void SaveToFile(GenericStore<Brand> brand, string brandFile)
        {
            using (var fs=new FileStream(brandFile,FileMode.OpenOrCreate,FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, brand);
            }
        }
        [Obsolete]
        static GenericStore<Brand> LoadFromFile(string brandFile)
        {
            try
            {
                using (var fs = new FileStream(brandFile, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (GenericStore<Brand>)bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                return new GenericStore<Brand>();
            }
        }
        [Obsolete]
        static void SaveToFile(GenericStore<Model> model, string modelFile)
        {
            using (var fs = new FileStream(modelFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, model);
            }
        }
        [Obsolete]
        static GenericStore<Model> LoadFromFile1(string modelFile)
        {
            try
            {
                using (var fs = new FileStream(modelFile, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (GenericStore<Model>)bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                return new GenericStore<Model>();
            }
        }
        [Obsolete]
        static void SaveToFile(GenericStore<Car> car, string carFile)
        {
            using (var fs = new FileStream(carFile, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, car);
            }
        }
        [Obsolete]
        static GenericStore<Car> LoadFromFile4(string carFile)
        {
            try
            {
                using (var fs = new FileStream(carFile, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return (GenericStore<Car>)bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {
                return new GenericStore<Car>();
            }
        }
        static void GetAllBrand()
        {
            Console.WriteLine("                                                   <<LIST OF BRANDS>>                                                   " +
                "\n************************************************************************************************************************");
            foreach (var item in brand)
            {
                Console.WriteLine(item);
            }
        }
        private static void GetAllCar()
        {
            Console.WriteLine("                                                    <<LIST OF CARS>>                                                    " +
                "\n************************************************************************************************************************");
            foreach (var item in car)
            {
                var model1 = model.Find(m => m.Id == item.ModelId);
                Console.WriteLine($"\n|| Model Name: {model1.Name} {item}");
            }
        }
        static void GetAllModel()
        {
            Console.WriteLine("                                                   <<LIST OF MODELS>>                                                   " +
                "\n************************************************************************************************************************");
            foreach (var item in model)
            {
                var brand1 = brand.Find(b => b.Id == item.MarkaId);
                Console.WriteLine($"\n|| {brand1.Name} {item}");
            }
        }
    }
}
