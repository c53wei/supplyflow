using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace SupplyFlow
{
    partial class Program
    {      
        static void Main()
        {
            // Example user configuration interface
            Volunteer user = new Volunteer( "Victoria", 43.8561, -79.3370, 500, 50 );
            // Calculate inventory distribution
            Distribute( user );
        }
    }
}
