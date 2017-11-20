using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Web;

namespace StatusBoard
{
    public class OpeningStatus
    {
        public static bool CheckWhetherLiveHelpSystemIsOpen()
        {
            OpeningHours openingHours = GetOpeningHoursConfiguration();

            foreach (OpeningHoursDaysDay day in openingHours.Items[0].Day)
            {
                if (day.name == DateTime.Now.DayOfWeek.ToString())
                {
                    foreach (OpeningHoursDaysDayTime time in day.Time)
                    {
                        if ((int)DateTime.Now.Hour >= int.Parse(time.begin) &&
                            (int)DateTime.Now.Hour < int.Parse(time.end))
                            return true;
                    }
                }
            }
            return false;
        }

        private static OpeningHours GetOpeningHoursConfiguration()
        {
            Type[] extraTypes = new Type[1];
            extraTypes[0] = typeof(OpeningRestrictions);
            XmlSerializer serializer = new XmlSerializer(typeof(OpeningHours), extraTypes);

            using (XmlReader reader = XmlReader.Create(HttpContext.Current.Server.MapPath("~/OpeningHours.xml")))
            {
                return (OpeningHours)serializer.Deserialize(reader);
            }
        }
    }

    public class OpeningRestrictions
    {
       //Add other restrictions here as requested by mgmt
    }
}