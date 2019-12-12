using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Models;

namespace Identity.Repo
{
    public class AnimalRepo : IAnimalRepo
    {
        private readonly IdentityContext _context;
        public AnimalRepo(IdentityContext context) { this._context = context; }
        public void Delete(int id)
        {
            _context.Animals.Remove(this.Get(id));
            _context.SaveChanges();
        }

        public List<Animals> Find(string searchString)
        {
            var animals = from s in _context.Animals
                          select s;

            if (!String.IsNullOrEmpty(searchString)) 
            {
                animals = animals.Where(dyr => dyr.Name.Contains(searchString));
            }

            return animals.ToList();
        }

        public List<Animals> Get()
        {
            return _context.Animals.ToList();
        }

        public Animals Get(int id)
        {
            return _context.Animals.Find(id);
        }

        public void Save(Animals animal)
        {
            if (animal.ID == 0)
            {
                _context.Animals.Add(animal);
            }
            else
            {
                _context.Animals.Update(animal);
            }
            _context.SaveChanges();
        }
    }
}
