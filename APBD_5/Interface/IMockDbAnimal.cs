using System.Collections.Generic;
using Api_APBD05.APBD_05.APBD_5.classes;

namespace Api_APBD05.APBD_05.APBD_5.Interface;

public interface IMockDbAnimal
{
    public ICollection<AnimalInfo?> GetAll();
    public AnimalInfo? GetById(int id);
    public void Add(AnimalInfo animal);
    void Edit(int id, AnimalInfo animal);
    void Delete(int id);
}