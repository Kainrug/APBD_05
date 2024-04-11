using System;
using System.Collections.Generic;
using System.Linq;
using Api_APBD05.APBD_05.APBD_5.Interface;

namespace Api_APBD05.APBD_05.APBD_5.classes;

public class MockDbVisit : IMockDbVisit
{
    public static IMockDbAnimal _mockDbAnimal = new MockDbAnimals();
    public ICollection<Visit?> _visits = new List<Visit?>()
    {
        new(new DateTime(2023, 10, 3), _mockDbAnimal.GetById(1), "Broken Leg", 200),
        new (new DateTime(2023, 11, 15), _mockDbAnimal.GetById(2), "Ear Infection", 150),
        new (new DateTime(2023, 12, 5), _mockDbAnimal.GetById(3), "Dental Cleaning", 100),
        new (new DateTime(2024, 1, 8), _mockDbAnimal.GetById(4), "Vaccination", 80),
        new (new DateTime(2024, 2, 20), _mockDbAnimal.GetById(1), "Check-up", 120)
    };

    public ICollection<Visit?> GetByAnimal(AnimalInfo animalInfo)
    {
        return _visits.Where(visit => visit!.Animal!.Equals(animalInfo)).ToList();
    }

    public void Add(Visit visit)
    {
        _visits.Add(visit);
    }
}