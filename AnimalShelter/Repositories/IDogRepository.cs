using System;
using System.Collections.Generic;
using AnimalShelter.Entitites;

namespace AnimalShelter.Repositories
{
    public interface IDogRepository
    {
        IEnumerable<Dog> GetDogs();
        Dog GetDogById(int id);
        void AddDog(Dog d);
        bool UpdateDog(int id, Dog d);
        bool DeleteDog(int id);
    }
}
