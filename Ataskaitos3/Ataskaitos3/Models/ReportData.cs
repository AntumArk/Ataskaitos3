using System;
using System.Collections.Generic;
using System.Text;

namespace Ataskaitos3.Models
{
    public class ReportData
    {
        private string dataString;
        private List<string> dataHeaders = new List<string>
        {
            "Kodas",
            "Aukštas",
            "Vieta",
            "Iš",
            "Į",
            "Instaliacijos tipas",
            "Gaisro klasė",
            "Naudotos medžiagos",
            "Kvadratūra",
            "Kaina"


        };

        public string Code { get; set; }

        public string Story { get; set; }

        public string RoomPlace { get; set; }

        public string InstalledFrom { get; set; }

        public string InstalledTo { get; set; }

        public string InstallationType { get; set; }

        public string FireClass { get; set; }

        public string UsedMaterials { get; set; }

        public string Quadrature { get; set; }


        public string Price { get; set; }


        public string DataString
        {
            get
            {
                var result = String.Join(",", dataHeaders);
                result += '\n';
                result += Code + ",";
                result += Story + ",";
                result += RoomPlace + ",";
                result += InstalledFrom + ",";
                result += InstalledTo + ",";
                result += InstallationType + ",";
                result += FireClass + ",";
                result += UsedMaterials + ",;";
                result += Quadrature + ",";
                result += Price + ",";

                return result;
            }
            set
            {
                dataString = DataString;

            }

        }


    }
}
