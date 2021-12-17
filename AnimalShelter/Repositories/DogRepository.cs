using System;
using System.Collections.Generic;
using System.Linq;
using AnimalShelter.Entitites;

namespace AnimalShelter.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly List<Dog> _repository = new()
        {
            new() { Id = 1, Name = "Leo" },
            new() { Id = 2, Name = "Simbha" },
            new() { Id = 3, Name = "Tommy" },
            new() { Id = 4, Name = "Sandy" },
            new() { Id = 5, Name = "Roxcy" },
            
        };
        public IEnumerable<Dog> GetDogs()
        {
            return _repository;
        }
        public Dog GetDogById(int id)
        {
            return _repository.FirstOrDefault(dog => dog.Id == id);
        }
        public void AddDog(Dog d)
        {
            var id = _repository.Last().Id;
            var dog = new Dog() { Id = (id + 1), Name = d.Name };
            _repository.Add(dog);

        }
        public bool UpdateDog(int id, Dog d)
        {
            var dog = _repository.FirstOrDefault(dog => dog.Id == id);
            if (dog != null)
            {
                dog.Name = d.Name;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteDog(int id)
        {
            var dog = _repository.FirstOrDefault(dog => dog.Id == id);
            if (dog != null)
            {
                _repository.Remove(dog);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
