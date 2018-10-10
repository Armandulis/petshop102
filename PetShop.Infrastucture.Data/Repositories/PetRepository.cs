
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainSerivice;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastucture.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        readonly PetShopContext _ctx;

        public PetRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Pet GetByID(int id)
        {
           
            return _ctx.Pet.FirstOrDefault(pet => pet.ID == id);
        }

        public IEnumerable<Pet> ListPets()
        {
            return _ctx.Pet;
        }

        public Pet PetCreate(Pet pet)
        {
            var pets = _ctx.Pet.Add(pet).Entity;
            _ctx.SaveChanges();
            return pets;
        }

        public Pet PetRemove(int id)
        {
            var pet = _ctx.Pet.Remove(GetByID(id)).Entity;
            _ctx.SaveChanges();
            return pet;
        }

        public Pet PetSearch(string petName)
        {
            return _ctx.Pet.FirstOrDefault(pet => pet.Name == petName);
        }

        public Pet PetUpdate(Pet pet)
        {
            var oldPet = GetByID(pet.ID);
            if (oldPet != null) {
                oldPet.Name = pet.Name;
                oldPet.PreviousOwner = pet.PreviousOwner;
                oldPet.Price = pet.Price;
                oldPet.SoldDate = pet.SoldDate;
                oldPet.Color = pet.Color;
                oldPet.Birthdate = pet.Birthdate;
                return oldPet;
            }
            else return null;

        }
    }
}
