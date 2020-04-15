using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HotelConsole.Mangers;
using HotelWebService;

namespace HotelConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MangeFacilities.ReadFacilities();
            MangeFacilities.CreateFacility(new Facility() {Facility_No = 4, Name = "Opholdsrum"});
            MangeFacilities.ReadFacilities();

            Console.ReadLine();
        }
    }
}
