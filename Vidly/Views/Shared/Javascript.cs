using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Views.Shared
{
    public class Javascript
    {
        static string scriptTag = "<script type=\"\" language=\"\">{0}</script>";
        public static void ConsoleLog(string message)
        {
            string function = "console.log('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            HttpContext.Current.Response.Write(log);
        }

        public static void ConsoleLogged(object message)
        {
            string function = "console.log('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            HttpContext.Current.Response.Write(log);
        }

        public static void Alert(string message)
        {
            string function = "alert('{0}');";
            string log = string.Format(GenerateCodeFromFunction(function), message);
            HttpContext.Current.Response.Write(log);
        }

        static string GenerateCodeFromFunction(string function)
        {
            return string.Format(scriptTag, function);
        }
    }
}