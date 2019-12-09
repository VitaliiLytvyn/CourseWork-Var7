using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BLL
{
    public class Find
    {
        public string FindVisitor(VisitorsList visitorsList, string key)
        {
            string result = "";
            result += visitorsList.FindByName(key);
            if (result == "")
                result += visitorsList.FindBySurname(key);
            if (result == "")
                if (Regex.IsMatch(key, "[0-9]+"))
                    result += visitorsList.FindByGroup(Convert.ToInt16(key));
            if (result == "")
                result += "Control word not found in list!";
            return result;
        }

        public string FindDocument(DocsList docsList, string key)
        {
            string result = "";
            result += docsList.FindByAuthor(key);
            if (result == "")
                result += docsList.FindByTitle(key);
            if (result == "")
                result += "Control word not found in list!";
            return result;
        }
    }
}
