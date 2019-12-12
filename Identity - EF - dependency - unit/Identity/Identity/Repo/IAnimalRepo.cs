using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Repo
{
    public interface IAnimalRepo
    {
        public List<Animals> Get();
        public Animals Get(int id);
        public void Save(Animals animal);
        public void Delete(int id);
        public List<Animals> Find(string searchString);
    }
}
