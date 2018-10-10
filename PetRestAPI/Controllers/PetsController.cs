﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.AplicationService;
using PetShop.Core.Entity;

namespace PetRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        readonly IPetService _petService;

        public PetsController(IPetService petService) {
            _petService = petService;

        }
        // GET api/Pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/Pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.FindPetByID(id);
        }

        // POST api/Pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (pet.Name == null)
            {
                return BadRequest("Pet's name is required!");
            }
            else { return _petService.CreatePet(pet); }
        }

        // PUT api/Pets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet pet)
        {
            _petService.UpdatePet(id, pet.Name,pet.Type,pet.Price);
        }

        // DELETE api/Pets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.RemovePet(id);
        }
    }
}
