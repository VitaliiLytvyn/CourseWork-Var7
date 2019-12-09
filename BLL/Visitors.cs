using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Visitors
    {
        private int academGroup;
        private string name;
        private string surname;
        public string Name { get { return name; } set { name = String.IsNullOrEmpty(value.Trim()) ? throw new LibraryException("Invalide name") : value; } }
        public string Surname { get { return surname; } set { surname = String.IsNullOrEmpty(value.Trim()) ? throw new LibraryException("Invalide surname") : value; } }
        
        public int AcademGroup
        {
            get { return academGroup; }
            set
            {
                if (value <= 0)
                    throw new LibraryException("Wrong group");
                else academGroup = value;
            }
        }
        public List<string> Offer { get; set; }

        public Visitors(int group, string n, string sn, DocOffers doc)
        {
            this.AcademGroup = group;
            this.Name = n;
            this.Surname = sn;
            this.Offer = doc.Offer;
        }
        public Visitors() { }
        public override string ToString() => "AcademGroup:\t" + AcademGroup + "\tName:\t" + Name + "\tSurname:\t" + Surname + $"\tHave a {Offer.Count} books";

    }
}
