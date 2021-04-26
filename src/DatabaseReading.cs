using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace SupplyFlow
{
    partial class Program
    {   /// <summary>
        /// Parses text file containing volunteer organization information
        /// </summary>
        /// <returns>
        /// List of Organization objects
        /// </returns>
        public static Organization[] AddOrganizationFromList( )
        {
            // Initizalze empty list of Organizations to return
            List<Organization> organizationList = new List <Organization>();
            // Configure file reading parameters
            const string path = "Organizations.txt";
            const FileMode mode =  FileMode.Open;
            const FileAccess access = FileAccess.Read;
            using FileStream file = new FileStream( path, mode, access );
            using StreamReader reader = new StreamReader( file );
            // Read file
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                // Comma separators
                string [] fields = line.Split(",");
                // Create new object to add to list
                Organization currentOrganization = new Organization(fields[0], double.Parse(fields[1]), double.Parse(fields[2]), 
                                                            Int32.Parse(fields[3]), double.Parse(fields[4]), double.Parse(fields[5]), 
                                                            double.Parse(fields[6]));
                organizationList.Add(currentOrganization);
            }
            // Covert to appropriate type and return
            return organizationList.ToArray();
        }

    }
}