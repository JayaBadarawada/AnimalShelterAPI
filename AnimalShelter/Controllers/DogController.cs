using System.Collections.Generic;
using AnimalShelter.Entitites;
using AnimalShelter.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace AnimalShelter.Controllers
{
    [Route("api/dogs")]
    [ApiController]
    public class DogController : ControllerBase
    {
        public readonly IDogRepository _repository;

        public DogController(IDogRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Dog> GetDogs()
        {
            return _repository.GetDogs();
        }
        [HttpGet("{id}")]
        public ActionResult<Dog> GetDogById(int id)
        {
            var dog = _repository.GetDogById(id);
            if (dog == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dog);
            }
        }
        [HttpPut("{id}")]
        public ActionResult UpdateDog(int id, Dog d)
        {
            var resp = _repository.UpdateDog(id, d);
            if (!resp)
            {
                return NotFound();
            }
            else
            {
                return Ok("Dog Successfully Updated!");
            }
        }
        [HttpPost]
        public ActionResult AddDog(Dog d)
        {
            _repository.AddDog(d);
            return Ok("Dog Successfully Created!");

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDog(int id)
        {
            var resp = _repository.DeleteDog(id);
            if (!resp)
            {
                return NotFound();
            }
            else
            {
                return Ok("Dog Successfully Deleted!");
            }
        }


    }
}
