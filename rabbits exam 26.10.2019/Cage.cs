namespace Rabbits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Cage
    {
        private readonly List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.data.Count; //(a => a.Available == true)

        //Method Add(Rabbit rabbit) - adds an entity to the data if there is room for it
        public void Add(Rabbit rabbit)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        //Method RemoveRabbit(string name) - 
        //removes a rabbit by given name, if such exists, and returns bool
        public bool RemoveRabbit(string name)
        {
            var rabbit = this.data.FirstOrDefault(r => r.Name == name);
            if (rabbit != null)
            {
                data.Remove(rabbit);
                this.Capacity++;
                return true;
            }
            return false;
        }

        //Method RemoveSpecies(string species) - removes all rabbits by given species
        public void RemoveSpecies(string species)
        {
            int count = this.data.Count(s => s.Species == species);
            this.data.RemoveAll(r => r.Species == species);
            this.Capacity += count;
        }

        //Method SellRabbit(string name) - sell(set its Available property to false 
        //without removing it from the collection) the first rabbit with the given name, 
        //also return the rabbit
        public string SellRabbit(string name)
        {
            var rabbit = this.data.Where(r => r.Name == name).FirstOrDefault();
            if (rabbit != null)
            {
                rabbit.Available = false;
            }
            return rabbit.ToString();
        }
        //Method SellRabbitsBySpecies(string species) - sells
        //(set their Available property to false without removing them from the collection) 
        //and returns all rabbits from that species as an array
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            foreach (var rabbit in this.data.Where(r => r.Species == species))
            {
                rabbit.Available = false;
            }

            return this.data.Where(r => r.Species == species).ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in this.data.Where(a => a.Available == true))
            {
                sb.AppendLine(rabbit.ToString());
            }

            return sb.ToString();
        }

    }
}
