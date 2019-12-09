using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Docs
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public bool InLib { get; set; }

        public Docs(string aut, string title)
        {
            Author = aut;
            Title = title;
            InLib = true;
        }

        public Docs()
        {
        }

        public override string ToString() => "Title of Book:\t\t" + Title + "\tAutor:\t\t" + Author;
    }
}

