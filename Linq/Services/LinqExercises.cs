using Linq.DTOs;
using Linq.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Linq.Services
{
    public static class LinqExercises
    {

        public static void PureVsImpure()
        {
            Console.WriteLine("===== Pure Function =====");

            var cost = UtilityFunctions.CalculateCost(100, 5);

            Console.WriteLine($"Cost: {cost}");
            Console.WriteLine("CalculateCost does not modify any external data.");



            Console.WriteLine("\n===== Impure Function =====");

            List<Models.DailyUsage> usages = Repository.DailyUsages;

            var countBefore = usages.Count();

            Console.WriteLine($"Usages Before Add: {countBefore}");


            UtilityFunctions.AddUsage(new Models.DailyUsage
            {
                DailyUsageId = Guid.NewGuid(),
                HouseId = Repository.Houses[0].HouseId,
                HeaterId = Repository.Heaters[0].HeaterId,
                UsageDate = DateTime.Today,
                HoursWorked = 3,
                HeaterValue = 6
            });


            var countAfter = usages.Count();

            Console.WriteLine($"Usages After Add: {countAfter}");
            Console.WriteLine("AddUsage modifies Repository.DailyUsages, so it is an impure function.");
        }
        public static void FunctionalProgramming()
        {
            Console.WriteLine("===== Method Syntax (Fluent Syntax) =====");

            var methodSyntax = Repository.Heaters
                .Where(h => h.PowerValue > 1500)
                .Select(h => new
                {
                    h.HeaterId,
                    h.PowerValue
                });


            foreach (var heater in methodSyntax)
            {
                Console.WriteLine(
                    $"HeaterId: {heater.HeaterId} | Power: {heater.PowerValue}"
                );
            }



            Console.WriteLine("\n===== Query Syntax =====");

            var querySyntax =
                from h in Repository.Heaters
                where h.PowerValue > 1500
                select new
                {
                    h.HeaterId,
                    h.PowerValue
                };


            foreach (var heater in querySyntax)
            {
                Console.WriteLine(
                    $"HeaterId: {heater.HeaterId} | Power: {heater.PowerValue}"
                );
            }
        }
        public static void Projection()
        {
            Console.WriteLine("===== Projection =====");
            Console.WriteLine("\n===== Select =====");
            var houses = Repository.Houses;
            var houseReports = houses.Select(h =>
            {
                return new
                {
                    HouseId = h.HouseId,
                    TotalMonthlyHours = h.DailyUsages.Sum(u => u.HoursWorked),
                    OwnerName = Repository.Owners.FirstOrDefault(o => o.OwnerId == h.OwnerId)?.FullName,

                };
            });
            foreach (var item in houseReports)
            {
                Console.WriteLine(
                    $"{item.HouseId} | {item.TotalMonthlyHours} | {item.OwnerName}"
                );
            }
            Console.WriteLine("\n===== Select Many =====");
            var projectedHeatersMany = houses.SelectMany(h => h.DailyUsages, (h, u) => new
            {
                HouseAddress = h.Address,
                HeaterType = Repository.Heaters.FirstOrDefault(he => he.HeaterId == u.HeaterId)?.HeaterType,
                UsageDate = u.UsageDate,
                HoursWorked = u.HoursWorked
            });
            foreach (var item in projectedHeatersMany)
            {
                Console.WriteLine
                (
                    $"{item.HouseAddress} | {item.HeaterType} | {item.UsageDate:d} | {item.HoursWorked}"
                );
            }
        }
        public static void Sorting()
        {
            Console.WriteLine("===== Sorting =====");
            Console.WriteLine("\n===== Sort houses =====");
            var sortedHeaters = Repository.Houses
                .OrderByDescending(h => h.DailyUsages.Sum(u => u.HoursWorked))
                .ThenBy(h => h.HouseId);
            foreach (var heater in sortedHeaters)
            {
                Console.WriteLine(
                    $"HouseId: {heater.HouseId} | TotalMonthlyHours: {heater.DailyUsages.Sum(u => u.HoursWorked)}"
                );
            }
            Console.WriteLine("\n===== sort heaters =====");
            foreach (var house in Repository.Houses)
            {
                Console.WriteLine($"\nHouse: {house.Address}");
                var sorted = house.Heaters
                    .OrderByDescending(h => h.PowerValue)
                    .ThenBy(h => h.HeaterType);
                foreach (var heater in sorted)
                {
                    Console.WriteLine(
                        $"HeaterId: {heater.HeaterId} | Power: {heater.PowerValue} | Type: {heater.HeaterType}"
                    );
                }
            }

        }
        public static void Partitioning()
        {
            Console.WriteLine("===== Partitioning =====");
            Console.WriteLine("\n===== Take =====");
            var houses = Repository.Houses
                .OrderByDescending(h => h.DailyUsages.Sum(u => u.HoursWorked))
                .Take(5);
            foreach (var house in houses)
            {
                Console.WriteLine(
                    $"HouseId: {house.HouseId} | TotalMonthlyHours: {house.DailyUsages.Sum(u => u.HoursWorked)}"
                );
            }
            Console.WriteLine("\n===== Skip =====");
            var housesSkip = Repository.Houses
             .OrderByDescending(h => h.DailyUsages.Sum(u => u.HoursWorked))
             .Skip(2);
            foreach (var house in housesSkip)
            {
                Console.WriteLine(
                    $"HouseId: {house.HouseId} | TotalMonthlyHours: {house.DailyUsages.Sum(u => u.HoursWorked)}"
                );
            }
            Console.WriteLine("\n===== Take While =====");
            var housesTakeWhile = Repository.Houses.First();
            double threshold = 15;
            double runningTotal = 0;
            var dailyUsagesTakeWhile = housesTakeWhile.DailyUsages
                .OrderBy(d => d.UsageDate)
                .TakeWhile(d =>
                {
                    runningTotal += d.HoursWorked;
                    return runningTotal <= threshold;
                });
            foreach (var usage in dailyUsagesTakeWhile)
            {
                Console.WriteLine(
                    $"HouseId: {usage.HouseId} | HoursWorked: {usage.HoursWorked}"
                    );
            }
            Console.WriteLine("\n===== Skip While =====");
            var housesSkipWhile = Repository.Houses.First();
            var dailyUsagesSkipWhile = housesSkipWhile.DailyUsages
                .OrderBy(d => d.UsageDate)
                .SkipWhile(d => d.HoursWorked < 5);
            foreach (var usage in dailyUsagesSkipWhile)
            {
                Console.WriteLine(
                    $"HouseId: {usage.HouseId} | HoursWorked: {usage.HoursWorked}"
                    );
            }
        }
        public static void Quantifiers()
        {
            Console.WriteLine("===== Quantifiers =====");
            Console.WriteLine("\n===== Any =====");
            var houses = Repository.Houses;
            var result = houses.Any(e => e.Heaters.Any(h => h.PowerValue > 2000));
            Console.WriteLine($"Any powerful heater exists: {result}");
            foreach (var house in houses)
            {
                var powerfulHeaters = house.Heaters
                    .Where(h => h.PowerValue > 2000);

                foreach (var heater in powerfulHeaters)
                {
                    Console.WriteLine(
                        $"HouseId: {house.HouseId} | PowerValue: {heater.PowerValue}"
                    );
                }
            }
            Console.WriteLine("\n===== All =====");
            var housesAll = Repository.Houses.First();
            var resultAll = housesAll.DailyUsages.All(u => u.HoursWorked <= 24);
            Console.WriteLine(
                $"All usages <= 24 hours: {resultAll}"
            );
            foreach (var usage in housesAll.DailyUsages)
            {
                Console.WriteLine(
                    $"HouseId: {usage.HouseId} | HoursWorked: {usage.HoursWorked}"
                );
            }
            Console.WriteLine("\n===== Contains =====");
            var housesContains = Repository.Heaters
                .Select(h => h.PowerValue);
            var resultContains = housesContains.Contains(2000);




        }
        public static void Grouping()
        {
            Console.WriteLine("===== Grouping =====");
            var groupedHeaters = Repository.DailyUsages
                .GroupBy(h => h.HouseId)
                .Select(g => new
                {
                    HouseId = g.Key,
                    Count = g.Count(),
                    AverageHoursWorked = g.Average(h => h.HoursWorked)
                });
            foreach (var group in groupedHeaters)
            {
                Console.WriteLine(
                    $"HouseId: {group.HouseId} | Count: {group.Count} | AverageHoursWorked: {group.AverageHoursWorked}"
                );
            }
            Console.WriteLine("===== ToLookup =====");
            var lookupHeaters = Repository.Heaters
                .ToLookup(h => h.HeaterType);
            foreach (var group in lookupHeaters)
            {
                Console.WriteLine($"HeaterType: {group.Key}");
                foreach (var heater in group)
                {
                    Console.WriteLine(
                        $"HeaterId: {heater.HeaterId} | PowerValue: {heater.PowerValue}"
                    );
                }
            }

        }
        public static void JoinOperations()
        {
            Console.WriteLine("===== Join Operations =====");
            var joinResult = Repository.Houses
                .Join(
                    Repository.Owners,
                    house => house.OwnerId,
                    owner => owner.OwnerId,
                    (house, owner) => new
                    {
                        HouseId = house.HouseId,
                        OwnerName = owner.FullName,
                        Address = house.Address
                    }
                );
            foreach (var item in joinResult)
            {
                Console.WriteLine(
                    $"HouseId: {item.HouseId} | OwnerName: {item.OwnerName} | Address: {item.Address}"
                );
            }
            Console.WriteLine("\n===== GroupJoin Operations =====");
            var groupJoinResult = Repository.Houses
                .GroupJoin(
                    Repository.DailyUsages,
                    house => house.HouseId,
                    usage => usage.HouseId,
                    (house, usages) => new
                    {
                        HouseId = house.HouseId,
                        Address = house.Address,
                        HoursWorked = usages.Sum(x => x.HoursWorked)
                    }
                );
            foreach (var group in groupJoinResult)
            {
                Console.WriteLine(
                    $"HouseId: {group.HouseId} | Address: {group.Address} | HourWorked: {group.HoursWorked}"
                    );
            }
        }
        public static void GenerationOperations()
        {
            Console.WriteLine("===== Generation Operations =====");
            Console.WriteLine("\n===== Enumerable Range =====");
            var days = Enumerable.Range(1, 30);
            foreach (var day in days)
            {
                Console.WriteLine($"Day: {day}");
            }
            Console.WriteLine("\n===== Enumerable Repeat =====");
            var repeated = Enumerable.Repeat("Heating", 5);
            foreach (var item in repeated)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n===== Select with index =====");
            var indexedHouses = Repository.Houses.Select((h, index) => new
            {
                Index = index,
                HouseId = h.HouseId,
                Address = h.Address
            });
            foreach (var house in indexedHouses)
            {
                Console.WriteLine($"Index: {house.Index} | HouseId: {house.HouseId} | Address: {house.Address}");
            }
        }
        public static void DeferredVsImmediate()
        {
            Console.WriteLine("===== Deferred vs Immediate =====");
            Console.WriteLine("\n===== Deferred =====");
            var deferredQuery = Repository.Heaters
                .Where(h => h.PowerValue > 2000);
            Repository.Heaters.Add
                (
                    new Heater
                    {
                        HeaterId = Guid.NewGuid(),
                        HeaterType = "Carbon",
                        PowerValue = 2500
                    }
                );
            foreach (var heater in deferredQuery)
            {
                Console.WriteLine(
                    $"HeaterId: {heater.HeaterId} | Power: {heater.PowerValue}"
                );
            }
            Console.WriteLine("\n===== Immediate =====");
            var immediateQuery = Repository.Heaters
                .Where(h => h.PowerValue > 2000)
                .ToList();
            Repository.Heaters.Add
                (
                    new Heater
                    {
                        HeaterId = Guid.NewGuid(),
                        HeaterType = "Carbon",
                        PowerValue = 2500
                    }
                );
            foreach (var heater in immediateQuery)
            {
                Console.WriteLine(
                   $"HeaterId: {heater.HeaterId} | Power: {heater.PowerValue}"
               );
            }
        }
    }
}
