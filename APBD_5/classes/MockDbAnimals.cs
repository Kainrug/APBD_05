using System.Collections.Generic;
using System.Linq;
using Api_APBD05.APBD_05.APBD_5.Interface;

namespace Api_APBD05.APBD_05.APBD_5.classes;

public class MockDbAnimals : IMockDbAnimal
{
    private readonly ICollection<AnimalInfo> _animalList = new List<AnimalInfo>()
    {
        new(1, "Zenek", AnimalCategory.Hamster, 5.5, HairColor.White),
        new(2, "Mirek", AnimalCategory.Dog, 10.2, HairColor.Yellow),
        new(3, "Filip", AnimalCategory.Cat, 6.8, HairColor.Brown),
        new(4, "Bozydar", AnimalCategory.Fox, 7.5, HairColor.Grey),
        new(5, "Kazik", AnimalCategory.Hamster, 4.2, HairColor.Brown),
        new(6, "Burek", AnimalCategory.Dog, 12.5, HairColor.Black),
        new(7, "Mruczek", AnimalCategory.Cat, 5.9, HairColor.White),
        new(8, "Lisek", AnimalCategory.Fox, 8.3, HairColor.Red),
        new (9, "Bugs", AnimalCategory.Rabbit, 3.0, HairColor.Black),
        new (10, "Shadow", AnimalCategory.Horse, 15.0, HairColor.Red),
        new (11, "Slither", AnimalCategory.Snake, 2.5, HairColor.Green),
        new (12, "Thumper", AnimalCategory.Rabbit, 3.5, HairColor.White),
        new (13, "Blaze", AnimalCategory.Horse, 14.0, HairColor.Orange),
        new (14, "Fang", AnimalCategory.Snake, 2.0, HairColor.Black)
    };

    public ICollection<AnimalInfo?> GetAll()
    {
        return _animalList;
    }

    public AnimalInfo? GetById(int id)
    {
        return _animalList.FirstOrDefault(a=> a.Id == id);
    }

    public void Add(AnimalInfo animal)
    {
         _animalList.Add(animal);
    }

    public void Edit(int id, AnimalInfo animal)
    {
        var animalToChange = GetById(id);
        animalToChange!.Name = animal.Name;
        animalToChange.Category = animal.Category;
        animalToChange.Mass = animal.Mass;
        animalToChange.HairHairColor = animal.HairHairColor;

    }

    public void Delete(int id)
    {
        var animalToRemove = GetById(id);
        _animalList.Remove(animalToRemove!);
    }
}