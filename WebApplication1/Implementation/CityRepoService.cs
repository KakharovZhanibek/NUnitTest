using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.DB;

namespace WebApplication1.Implementation
{
    public class CityRepoService : ICityRepo<City>
    {
        Context db;
        public CityRepoService()
        {
            db = new Context();
        }
        public City Create(City item)
        {
            db.City.Add(item);
            db.SaveChanges();
            return item;
        }

        public void Delete(int? id)
        {
            City item = db.City.Find(id);
            db.City.Remove(item);
            db.SaveChanges();
        }

        public City Edit(City item)
        {
            City itemTemp = db.City.Find(item.Id);
            itemTemp.Name = item.Name;
            db.SaveChanges();
            return itemTemp;
        }

        public IEnumerable<City> getAll()
        {
            return db.City.ToList();
        }

        public City getById(int? id)
        {
            City itemTemp = db.City.Find(id);            
            return itemTemp;
        }

        public IEnumerable<City> getCitiesByFirstLetters(string v)
        {
            return db.City.ToList().Where(z => z.Name.StartsWith(v)).AsEnumerable();
        }
    }
}