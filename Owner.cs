using System;
using System.Collections.Generic;
using System.Text;

namespace IceCity
{
    internal class Owner
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        private List<House> _houses;
        public IReadOnlyList<House> Houses => _houses;
        public Owner(string name , int id)
        {
            this.Name = name;
            this.Id = id;
            _houses = new List<House>();
        }
        public void AddHouse(House house)
        {
            
            _houses.Add(house);
        }
    }
}
