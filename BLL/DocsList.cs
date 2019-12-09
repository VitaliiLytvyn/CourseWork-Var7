using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DocsList
    {
        List<Docs> docs { get; set; } = new List<Docs>();
        private Serialize<Docs> Database;
        public DocsList()
        {
            Database = new Serialize<Docs>("Docs");
            try
            {
                var a = Database.Load();
                docs = a.ToList();
            }
            catch 
            {
                Database.Save(docs.ToArray());
            }
        }
        public DocsList(Serialize<Docs> sr)
        {
            Database = sr;
            try
            {
                var a = Database.Load();
                docs = a.ToList();
            }
            catch 
            {
                Database.Save(docs.ToArray());
            }
        }
        public int Last
        {
            get { return docs.Count; }
        }
        //добавить книгу
        public void Add(string aut, string title) => docs.Add(new Docs
        {
            Author = String.IsNullOrEmpty(aut.Trim()) ? throw new LibraryException("Invald Author") : aut,
            Title = String.IsNullOrEmpty(title.Trim()) ? throw new LibraryException("Invalide Title") : title
        });
        //удалить книгу
        public void Remove(int ind)
        {
            if (ind < 0 || ind >= docs.Count)
                throw new LibraryException("Index out of range");
            docs.RemoveAt(ind);
        }
        //изменить данные книги
        public void Edit(int ind, string auth, string title)
        {
            if (ind < 0 || ind >= docs.Count)
                throw new LibraryException("Index out of range");
            var doc = docs[ind];
            doc.Author = auth;
            doc.Title = title;
            docs[ind] = doc;
        }
        //поулчить информацию о книге
        public Docs GetInfo(int ind) => ind < 0 || ind >= docs.Count ? null : docs[ind];
        //Сортировка по автору
        public List<Docs> SortByAuthor()
        {
            var temp = docs;
            for (int i = 0; i < docs.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < docs.Count; j++)
                    if (temp[j].Author.CompareTo(temp[min].Author) < 0)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }
        //Сортировка по названию
        public List<Docs> SortByTitle()
        {
            var temp = docs;
            for (int i = 0; i < docs.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < docs.Count; j++)
                    if (temp[j].Title.CompareTo(temp[min].Title) < 0)
                        min = j;
                var a = temp[min];
                temp[min] = temp[i];
                temp[i] = a;
            }
            return temp;
        }
        //поиск по заголовку 
        public Docs FindByTitle(string title) => docs.Find(x => x.Title == title);
        //поиск по Автору
        public Docs FindByAuthor(string author) => docs.Find(x => x.Author == author);
        //получить список литературы
        public string GetDocs()
        {
            string list = "";
            foreach (var a in docs)
                list += $"Title {a.Title}\tAuthor: {a.Author}\n";
            return list;
        }
        //сохранение
        public void Save()
        {
            Database.Save(docs.ToArray());
        }
    }
}

