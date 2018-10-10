﻿using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastucture.Data
{
    public class InitialiseDB
    {
        public static void SeedDB(PetShopContext ctx){

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var owner3 = ctx.Owner.Add(new Owner()
            {
                Address = "asd",
                Email = "asd@Gmakil",
                FirstName = "Armandas",
                LastName = "Bruzas",
                PhoneNumber = "84654"

            }).Entity;
            var owner2 = ctx.Owner.Add(new Owner()
            {
                Address = "asd",
                Email = "asd@Gmakil",
                FirstName = "Armandas",
                LastName = "Bruzas",
                PhoneNumber = "84654"
            }).Entity;
            var owner1 = ctx.Owner.Add(new Owner()
            {
                Address = "asd",
                Email = "asd@Gmakil",
                FirstName = "Armandas",
                LastName = "Bruzas",
                PhoneNumber = "84654"

            }).Entity;
            ctx.Pet.Add(new Pet()
            {
                Name = "Ducky",
                Color = "White/Black",
                Price = 99.69,
                PreviousOwner = owner1,
                Type = "Duck"




            });
            ctx.Pet.Add(new Pet()
            {
                Name = "Katoo",
                Color = "Ginger",
                Price = 99.69,
                PreviousOwner = owner2,
                Type = "cat"



            });
            ctx.Pet.Add(new Pet()
            {
                Name = "Lmao",
                Color = "Any",
                Price = 99.69,
                PreviousOwner = owner2,
                Type = "Doh"


            });
            ctx.SaveChanges();
        }
    }
}