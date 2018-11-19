using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WcfWebService
{
    /// <summary>
    /// Summary description for TemperatureConverter
    /// </summary>
    [WebService(Namespace = "http://www.eextreme.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TemperatureConverter : System.Web.Services.WebService
    {

        [WebMethod]
        public double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            double celsius = ((fahrenheit - 32) * 5) / 9;
            return celsius;
        }
    }
}
