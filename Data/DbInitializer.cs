using HMOManagerAPI.Data;
using HMOManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Metadata;
public class DbInitializer
{
    public static void Initialize(ApplicationDbContext context, IServiceProvider services)
    {
        // Get a logger
        var logger = services.GetRequiredService<ILogger<DbInitializer>>();

        context.Database.EnsureCreated();

        if (!IsDataSeeded(context))
        {
            logger.LogInformation("Start seeding the database.");

            SeedData(context);

        }
  
        context.SaveChanges();

        logger.LogInformation("Finished seeding the database.");
    }

    public static void SeedData(ApplicationDbContext context)
    {

        var siteOne = new Site { Name = "Grand Hotel", Address = "123 Main Street" };
        var siteTwo = new Site { Name = "Sunset Beach Resort", Address = "456 Ocean Avenue" };
        var siteThree = new Site { Name = "Mountain View Lodge", Address = "789 Mountain Road" };
        var siteFour = new Site { Name = "Riverfront Cabin", Address = "101 River Street" };
        var siteFive = new Site { Name = "Cozy Cottage", Address = "222 Forest Lane" };
        var siteSix = new Site { Name = "Lakeview Retreat", Address = "333 Lakeside Drive" };
        var siteSeven = new Site { Name = "City Lights Apartment", Address = "444 Downtown Blvd" };
        var siteEight = new Site { Name = "Meadowside Manor", Address = "555 Meadow Avenue" };
        var siteNine = new Site { Name = "Palm Tree Villa", Address = "666 Palm Street" };
        var siteTen = new Site { Name = "Ocean Breeze House", Address = "777 Beachside Court" };

        var sites = new List<Site>
            {
                siteOne,
                siteTwo,
                siteThree,
                siteFour,
                siteFive,
                siteSix,
                siteSeven,
                siteEight,
                siteNine,
                siteTen
            };

        context.Sites.AddRange(sites);

        var rooms = new List<Room>();

        var random = new Random();

        for (int siteIndex = 0; siteIndex < 10; siteIndex++)
        {
            for (int roomIndex = 0; roomIndex < 5; roomIndex++)
            {
                rooms.Add(new Room
                {
                    Name = $"Room {roomIndex + 1}",
                    IsOccupied = random.Next(0, 2) == 1,
                    MovedInDate = DateTime.Now.AddDays(-random.Next(1, 365)),
                    ContractEndDate = DateTime.Now.AddDays(random.Next(1, 365)),
                    RentFrequency = (RentFrequency)random.Next(Enum.GetNames(typeof(RentFrequency)).Length),
                    RentAmount = random.Next(500, 2000),
                    RentDueDate = DateTime.Now.AddDays(random.Next(1, 31)),
                    SiteId = sites[siteIndex].SiteId,
                    Site = sites[siteIndex]
                });
            }
        }

        context.Rooms.AddRange(rooms);

        //var tenants = new List<Tenant>();

        //modelBuilder.Entity<Room>().HasData(
        //    new Tenant { TenantId = 1, FirstName = "", Surname = "", Email = "", PhoneNumber = "", RoomId = rooms[0].RoomId, Room = rooms[0] },
        //    new Tenant { TenantId = 2, FirstName = "", Surname = "", Email = "", PhoneNumber = "", RoomId = rooms[0].RoomId, Room = rooms[0] },
        //    new Tenant { TenantId = 3, FirstName = "", Surname = "", Email = "", PhoneNumber = "", RoomId = rooms[1].RoomId, Room = rooms[1] },
        //    new Tenant { TenantId = 4, FirstName = "", Surname = "", Email = "", PhoneNumber = "", RoomId = rooms[1].RoomId, Room = rooms[1] },
        //    new Tenant { TenantId = 5, FirstName = "", Surname = "", Email = "", PhoneNumber = "", RoomId = rooms[2].RoomId, Room = rooms[2] },
        //    new Tenant { TenantId = 6, FirstName = "", Surname = "", Email = "", PhoneNumber = "", RoomId = rooms[2].RoomId, Room = rooms[2] },
        //    new Tenant { TenantId = 7, FirstName = "", Surname = "", Email = "", PhoneNumber = "", RoomId = rooms[3].RoomId, Room = rooms[3] },
        //    new Tenant { TenantId = 8, FirstName = "", Surname = "", Email = "", PhoneNumber = "", RoomId = rooms[3].RoomId, Room = rooms[3] },
        //    new Tenant { TenantId = 9, FirstName = "", Surname = "", Email = "", PhoneNumber = "", RoomId = rooms[4].RoomId, Room = rooms[4] },
        //    new Tenant { TenantId = 10, FirstName = "", Surname = "", Email = "", PhoneNumber = "", RoomId = rooms[4].RoomId, Room = rooms[4] }

        //    );       
    }
    private static bool IsDataSeeded(ApplicationDbContext context)
    {
        bool sitesSeeded = context.Sites.Any();

        bool roomsSeeded = context.Rooms.Any();

        bool tenantsSeeded = context.Tenants.Any();

        return sitesSeeded || roomsSeeded || tenantsSeeded;
    }
}