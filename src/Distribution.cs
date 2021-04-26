using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace SupplyFlow
{
    partial class Program
    {
        /// <summary>
        /// Calculates the distance between two points using the Haversine equation
        /// </summary>
        /// <param name="lat1">Latitude of first point.</param>
        /// <param name="lon1">Longitude of first point.</param>
        /// <param name="lat2">Latitude of second point.</param>
        /// <param name="lon2">Longitude of second point.</param>
        /// <returns>
        /// Returns distance in kilometers
        /// </returns>
        static double Haversine(double lat1, double lon1, double lat2, double lon2) 
        { 
            // distance between latitudes and longitudes 
            double dLat = (Math.PI / 180) * (lat2 - lat1); 
            double dLon = (Math.PI / 180) * (lon2 - lon1); 
        
            // convert to radians 
            lat1 = (Math.PI / 180) * (lat1); 
            lat2 = (Math.PI / 180) * (lat2); 
        
            // apply formulae 
            double a = Math.Pow(Math.Sin(dLat / 2), 2) +  
                    Math.Pow(Math.Sin(dLon / 2), 2) *  
                    Math.Cos(lat1) * Math.Cos(lat2); 
            double rad = 6371; 
            double c = 2 * Math.Asin(Math.Sqrt(a)); 
            return rad * c; 
        } 
        /// <summary>
        /// Writes optimal organizations and supply amounts to console
        /// </summary>
        /// <param name="sortedImportance">List of Organizations ordered by rank</param>
        /// <param name="sum">Total inventory count to be given</param>
        /// <param name="Organizations current donation inventory">Latitude of second point.</param>
        public static void ReturnAmounts( OrganizationImportance[] sortedImportance, double sum, int donations ) 
        {
            for( int i = 0; i < sortedImportance.Length; i ++ ) 
            {   
                // Allocation of items is weighed by how much is needed
                WriteLine( $"Rank: { i + 1 } {sortedImportance[ i ].Name} should be given {(int)(donations*sortedImportance[ i ].Importance/sum)} items.");
            }
        }
        /// <summary>
        /// Overarching function call to calculate supply distribution
        /// </summary>
        /// <param name="person">Volunteer user configuration</param>
        public static void Distribute( Volunteer person )
        {
            // Get organizations from database
            Organization[] array = AddOrganizationFromList();
            // Instantiate empty importance object for each organization
            List<OrganizationImportance> organizationList = new List<OrganizationImportance>();
            // Compute distance and relative benefit for supply distribution for each organization
            for( int i =0; i < array.Length; i++ )
            {
                // Only consider if within worthwhile location
                if( Haversine( array[i].Latitude, array[i].Longitude, person.Latitude, person.Longitude) < person.Radius )
                {
                    OrganizationImportance newOrganization = new OrganizationImportance( array[ i ].Name, Importance( array[ i ] ) );
                    organizationList.Add( newOrganization );
                }
            }
            // Rank organizations by optimal benefit
            OrganizationImportance[] sortedImportance = organizationList.ToArray(); 
            // Fun implementation of insertion sort just because!
            InsertionSort( sortedImportance );
            // Compile total 'importance weighting' to use in later calculations
            double importanceSum = 0;
            foreach( OrganizationImportance x in sortedImportance ) 
            {
                importanceSum += x.Importance;
            }
            // Determine distribution based on benefit
            ReturnAmounts( sortedImportance, importanceSum, person.Inventory );
        }
        

    }
}
