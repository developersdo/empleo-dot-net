using System.ComponentModel;

namespace EmpleoDotNet.Models
{
    public enum JobCategory
    {
        [Description("Ninguna")]
        None = 0,

        GraphicDesign = 1,
        WebDevelopment = 2,
        MobileDevelopment = 3,
        SoftwareDevelopment = 4,
        SystemAdministrator = 5,
        Networking = 6,
        ItSales = 7
    }
}