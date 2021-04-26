using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace SupplyFlow
{
    /// <summary>
    /// This object houses all information related to an organization in need of supplies
    /// </summary>
    public class Organization
    {
        public string Name { get; set; } // Organization's name
        // Location information
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Inventory { get; set; } // Inventory count
        // Measures of business & funding
        public double Traffic { get; set; } 
        public double RateOfDepletion { get; set; }
        public double Income { get; set; }

        // Sets above attributes
        public Organization(string newName, double newLatitude, double newLongitude, 
                            int newInventory, double newTraffic, double newRate, double newIncome) 
        {
            this.Name = newName;
            this.Latitude = newLatitude;
            this.Longitude = newLongitude;
            this.Inventory = newInventory;
            this.Traffic = newTraffic/100;
            this.RateOfDepletion = newRate;
            this.Income = newIncome/10000;
        }
        // Reformat how Organization objects are printed for improved readability
        public override string ToString() {
            return $"Organization name: {Name}, latitude: {Latitude}, longitude: {Longitude}, inventory: {Inventory}, traffic: {Traffic}, area's financial average: {Income}";
        }
    }
    /// <summary>
    /// This object houses all information related to a potentail supplyflow user
    /// </summary>
    public class Volunteer
    {
        public string Name { get; set; } // Person's name
        // Location data
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Inventory { get; set; } // Available supplies to give out
        public double Radius { get; set; } // Max distance they will travel
        // Sets above attributes
        public Volunteer( string newName, double newLatitude, double newLongitude, int newInventory, double newRadius )
        {
            this.Name = newName;
            this.Latitude = newLatitude;
            this.Longitude = newLongitude;
            this.Inventory = newInventory;
            this.Radius = newRadius;
        }
        // Reformat how Volunteer objects are printed for improved readability
        public override string ToString()
        {
            return $"Organization name {Name}, latitude: {Latitude}, longitude: {Longitude}, inventory: {Inventory}, radius: {Radius}";
        }
    }
    /// <summary>
    /// This object houses all information related to how distribution is calculated
    /// </summary>
    public class OrganizationImportance
    {
        public string Name { get; set; }
        public double Importance { get; set; }

        public OrganizationImportance( string newName, double newImportance )
        {
            this.Name = newName;
            this.Importance = newImportance;
        }

        public override string ToString()
        {
            return $"{Name} {Importance}";
        }
    }
}