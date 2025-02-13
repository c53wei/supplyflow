using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace SupplyFlow
{
    partial class Program
    {   
        /// <summary>
        /// Implementation of insertions sort, just because :D
        /// </summary>
        /// <param name="recordsArray">List of OrganizationImportance to be sorted</param>
        public static void InsertionSort( OrganizationImportance[] recordsArray )
        {
            for( int firstUnsortedIndex = 1; firstUnsortedIndex < recordsArray.Length; firstUnsortedIndex ++ )
            {
                int hole = firstUnsortedIndex;
                OrganizationImportance temp = recordsArray[ hole ];

                while( hole > 0 && temp.Importance > recordsArray[ hole - 1 ].Importance ) 
                {
                    recordsArray[ hole ] = recordsArray[ hole - 1 ];
                    hole --;
                }

                recordsArray[ hole ] = temp;
            }
        }

    }
}