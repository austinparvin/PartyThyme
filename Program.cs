using System;
using System.Linq;

namespace PartyThyme
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"                                                _..
                                       ;-._   .'   `\
                                     .'    `\/       ;
                                     |       `\.---._|
                                  .--;   . ( .'      '.
                                 / _  \_  './ _.       `-._
                                ( = \  )`""'\;--.         /
                                {= (|  )     /`.         /     .'|
                                ( =_/  )__..-\         .'     / /
                                 \    }/    / ;.____.-;/\   .` /
                                  '--' |  .'   |       \ \  |  ;
                                       \  '    /       |. ;  \/
                                        )    .'`-.    / ; |  /\
                                       /__.-'   , \_.'  | | ;  ;
                                                |\      |`| |  |
                                                 \`\    | | |  |
                                                  \ `\  | | ;  ;
                                                   |  ; | | /  /
                                                   |  | | |/  /
                  Party Thyme                      ;  | | /  /
                                                    \  \;/  /
                                                     \  \  /
                                                      \  Y/
                                                       |  |
                                                       |  |
                                                       |  |
                                                       |  |
                                                       \  |
                                                        \_/
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             Welcome to Party Thyme
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

");
            var db = new PlantContext();
            var userInput = "";
            var isRunning = true;

            while (isRunning)
            {
                System.Console.WriteLine("What would you like to do?");
                System.Console.WriteLine("");
                System.Console.WriteLine("View 'v' || Plant 'p' || Remove 'r' || Water 'w' || Need to be watered 'n' || Location summary 'l'");
                userInput = Console.ReadLine();
                System.Console.WriteLine("");
                switch (userInput)
                {
                    case "v":

                        var orderedPlants = db.Plants.OrderBy(p => p.LocatedPlant);
                        foreach (var p in orderedPlants)
                        {
                            System.Console.WriteLine("-------------------------------------------");
                            System.Console.WriteLine($"Id:                    {p.Id}");
                            System.Console.WriteLine($"Species:               {p.Species}");
                            System.Console.WriteLine($"Location Planted:      {p.LocatedPlant}");
                            System.Console.WriteLine($"Date Planted:          {p.PlantedDate.ToString("MM/dd/yyyy")}");
                            System.Console.WriteLine($"Date Last Watered:     {p.LastWateredDate.ToString("MM/dd/yyyy")}");
                            System.Console.WriteLine($"Light needed (hrs/d):  {p.LightNeeded}");
                            System.Console.WriteLine($"WaterNeeded (ml/d):    {p.WaterNeeded}");
                            System.Console.WriteLine("-------------------------------------------");
                            System.Console.WriteLine("");
                        }
                        break;

                    case "p":
                        // Ask for Species
                        System.Console.WriteLine("What species is it?");
                        var newSpecies = Console.ReadLine().ToLower();

                        // Ask for Where it was planted
                        System.Console.WriteLine("Where did you plant it?");
                        var newLocatedPlanted = Console.ReadLine().ToLower();

                        // Ask for When it was planted
                        System.Console.WriteLine("When did you plant it?");
                        DateTime newPlantedDate;
                        var isDate = DateTime.TryParse(Console.ReadLine(), out newPlantedDate);
                        while (!isDate)
                        {
                            System.Console.WriteLine("That is not a valid date. Try again.");
                            isDate = DateTime.TryParse(Console.ReadLine(), out newPlantedDate);
                        }

                        // Ask for The last time it was watered
                        System.Console.WriteLine("When was the last time it was watered?");
                        DateTime newLastWateredDate;
                        isDate = DateTime.TryParse(Console.ReadLine(), out newLastWateredDate);
                        while (!isDate)
                        {
                            System.Console.WriteLine("That is not a valid date. Try again.");
                            isDate = DateTime.TryParse(Console.ReadLine(), out newLastWateredDate);
                        }

                        // Ask for How much light it needs
                        System.Console.WriteLine("How much light does it need per day (in hours)?");
                        int newLightNeeded;
                        var isInt = int.TryParse(Console.ReadLine(), out newLightNeeded);
                        while (!isInt)
                        {
                            System.Console.WriteLine("That is not a number. Try again.");
                            isInt = int.TryParse(Console.ReadLine(), out newLightNeeded);
                        }

                        // Ask for how much water it needs
                        System.Console.WriteLine("How much water does it need per day (in ml)?");
                        int newWaterNeeded;
                        isInt = int.TryParse(Console.ReadLine(), out newWaterNeeded);
                        while (!isInt)
                        {
                            System.Console.WriteLine("That is not a number. Try again.");
                            isInt = int.TryParse(Console.ReadLine(), out newWaterNeeded);
                        }

                        var plantToAdd = new Plant()
                        {
                            Species = newSpecies,
                            LocatedPlant = newLocatedPlanted,
                            PlantedDate = newPlantedDate,
                            LastWateredDate = newLastWateredDate,
                            LightNeeded = newLightNeeded,
                            WaterNeeded = newWaterNeeded
                        };

                        db.Plants.Add(plantToAdd);
                        db.SaveChanges();
                        break;

                    case "r":
                        // Ask for Which plant to remove (by id)
                        System.Console.WriteLine("Which plant would you like to remove (Id)");
                        int plantToRemoveId;
                        isInt = int.TryParse(Console.ReadLine(), out plantToRemoveId);
                        var isInDb = db.Plants.Any(p => p.Id == plantToRemoveId);
                        while (!isInt || !isInDb)
                        {
                            if (!isInt)
                            {
                                System.Console.WriteLine("That is not a number. Try again.");
                            }
                            else if (!isInDb)
                            {
                                System.Console.WriteLine("That Id is not in the database. Try again.");
                            }

                            isInt = int.TryParse(Console.ReadLine(), out plantToRemoveId);
                            isInDb = db.Plants.Any(p => p.Id == plantToRemoveId);
                        }

                        var plantToRemove = db.Plants.First(p => p.Id == plantToRemoveId);
                        db.Plants.Remove(plantToRemove);
                        db.SaveChanges();
                        break;

                    case "w":
                        System.Console.WriteLine("Which plant would you like to water (Id)");
                        int plantToWaterId;
                        isInt = int.TryParse(Console.ReadLine(), out plantToWaterId);
                        isInDb = db.Plants.Any(p => p.Id == plantToWaterId);
                        while (!isInt || !isInDb)
                        {
                            if (!isInt)
                            {
                                System.Console.WriteLine("That is not a number. Try again.");
                            }
                            else if (!isInDb)
                            {
                                System.Console.WriteLine("That Id is not in the database. Try again.");
                            }

                            isInt = int.TryParse(Console.ReadLine(), out plantToWaterId);
                            isInDb = db.Plants.Any(p => p.Id == plantToWaterId);
                        }

                        var plantToWater = db.Plants.First(p => p.Id == plantToWaterId);
                        plantToWater.LastWateredDate = DateTime.Now;

                        db.SaveChanges();


                        break;

                    case "n":
                        var today = DateTime.Today.Date; // "02/26/2020"
                        var dryPlants = db.Plants.Where(p => p.LastWateredDate.Date != today); // "02/26/2020 :00:00 AM"

                        foreach (var p in dryPlants)
                        {
                            System.Console.WriteLine("-------------------------------------------");
                            System.Console.WriteLine($"Id:                    {p.Id}");
                            System.Console.WriteLine($"Species:               {p.Species}");
                            System.Console.WriteLine($"Location Planted:      {p.LocatedPlant}");
                            System.Console.WriteLine($"Date Planted:          {p.PlantedDate.ToString("MM/dd/yyyy")}");
                            System.Console.WriteLine($"Date Last Watered:     {p.LastWateredDate.ToString("MM/dd/yyyy")}");
                            System.Console.WriteLine($"Light needed (hrs/d):  {p.LightNeeded}");
                            System.Console.WriteLine($"WaterNeeded (ml/d):    {p.WaterNeeded}");
                            System.Console.WriteLine("-------------------------------------------");
                            System.Console.WriteLine("");
                        }
                        break;
                    case "l":
                        System.Console.WriteLine("Which location would you like to view?");
                        var location = Console.ReadLine().ToLower();

                        isInDb = db.Plants.Any(p => p.LocatedPlant == location);

                        while (!isInDb)
                        {
                            System.Console.WriteLine("Sorry that location is not in the database. Try again.");
                            location = Console.ReadLine().ToLower();
                            isInDb = db.Plants.Any(p => p.LocatedPlant == location);
                        }

                        var plantsByLocation = db.Plants.Where(p => p.LocatedPlant == location);

                        foreach (var p in plantsByLocation)
                        {
                            System.Console.WriteLine("-------------------------------------------");
                            System.Console.WriteLine($"Id:                    {p.Id}");
                            System.Console.WriteLine($"Species:               {p.Species}");
                            System.Console.WriteLine($"Location Planted:      {p.LocatedPlant}");
                            System.Console.WriteLine($"Date Planted:          {p.PlantedDate.ToString("MM/dd/yyyy")}");
                            System.Console.WriteLine($"Date Last Watered:     {p.LastWateredDate.ToString("MM/dd/yyyy")}");
                            System.Console.WriteLine($"Light needed (hrs/d):  {p.LightNeeded}");
                            System.Console.WriteLine($"WaterNeeded (ml/d):    {p.WaterNeeded}");
                            System.Console.WriteLine("-------------------------------------------");
                            System.Console.WriteLine("");
                        }
                        break;
                    case "q":
                        isRunning = false;
                        break;
                }
            }
        }
    }
}