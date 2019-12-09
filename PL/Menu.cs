using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    public class Menu
    {
        private Find find;
        private VisitorsList visitorsList;
        private DocsList docsList;

        public void Run()
        {
            visitorsList = new VisitorsList();
            find = new Find();
            docsList = new DocsList();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Visitors\n2. Docs\n3. Find\n0. Exit");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "0":
                        visitorsList.Save();
                        docsList.Save();
                        Environment.Exit(0);
                        break;
                    case "1":
                        Visitor();
                        break;
                    case "2":
                        Docs();
                        break;
                    case "3":
                        Find();
                        break;
                    default:
                        Console.WriteLine("Wrong input\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        #region Visitor
        private void Visitor()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Add Visitor\n2. Remove Visitor\n3. Edit Visitor\n4. Show Visitor info\n5. Show list with all Visiors\n6. Sort\n7. Offers taked by this Visitor\n0.Exit");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "0":
                        run = false;
                        visitorsList.Save();
                        docsList.Save();
                        break;
                    case "1":
                        try
                        {
                            Console.Write("Write Name: ");
                            string n = Console.ReadLine();
                            Console.Write("Write Surname: ");
                            string sn = Console.ReadLine();
                            Console.Write("Write Academ Group: ");
                            int group = Convert.ToInt32(Console.ReadLine());
                            DocOffers b = new DocOffers();
                            visitorsList.Add(n, sn, group, b);
                            Console.WriteLine(visitorsList.GetInfo(visitorsList.Last - 1).ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Write index of client who want delete: ");
                            int ind = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (ind < 0 || ind >= visitorsList.Last)
                                throw new LibraryException("Index out of range");
                            visitorsList.Remove(ind);
                            Console.WriteLine("Succesfull deleted");
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "3":
                        try
                        {
                            Console.Write("Write index of Visitor: ");
                            int ind = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (ind < 0 || ind >= visitorsList.Last)
                                throw new LibraryException("Index out of range");
                            Console.Write("Write Name: ");
                            string n = Console.ReadLine();
                            Console.Write("Write Surname: ");
                            string sn = Console.ReadLine();
                            Console.Write("Write Academ Group: ");
                            int group = Convert.ToInt32(Console.ReadLine());
                            visitorsList.Edit(ind, n, sn, group);
                            Console.Write("Succesfull edited!");
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "4":
                        try
                        {
                            Console.Write("Write index of client: ");
                            int ind = Convert.ToInt16(Console.ReadLine()) - 1;
                            if (ind < 0 || ind >= visitorsList.Last)
                                throw new LibraryException("Index out of range");
                            Console.WriteLine(visitorsList.GetInfo(ind).ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine(visitorsList.GetAllVisitors());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "6":
                        try
                        {
                            Console.WriteLine("1. Sort by Name\n2. Sort by Surname\n3. Sort by first digit AcademGroup\n0. Exit");
                            string ans = Console.ReadLine();
                            Console.Clear();
                            switch (ans)
                            {
                                case "0":
                                    run = false;
                                    visitorsList.Save();
                                    docsList.Save();
                                    break;
                                case "1":
                                    try
                                    {
                                        for (int i = 0; i < visitorsList.Last; i++)
                                            Console.WriteLine(visitorsList.SortByName()[i].Name);
                                        Console.WriteLine("Succesfull");
                                        Console.ReadKey();
                                    }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "2":
                                    try
                                    {
                                        visitorsList.SortBySurname();
                                        Console.WriteLine("Succesfull");
                                        Console.ReadKey();
                                    }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "3":
                                    try
                                    {
                                        visitorsList.SortByGroup();
                                        Console.WriteLine("Succesfull");
                                        Console.ReadKey();
                                    }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                default:
                                    Console.WriteLine("Wrong input\nPress any key to continue");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "7":
                        try
                        {
                            Console.WriteLine("1. Add to Offer's\n2. Remove from Offers\n3. Check who take the same Book\n0.Exit");
                            string answ = Console.ReadLine();
                            Console.Clear();
                            switch (answ)
                            {
                                case "0":
                                    run = false;
                                    visitorsList.Save();
                                    docsList.Save();
                                    break;
                                case "1":
                                    try { AddOffer(); }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "2":
                                    try { RemoveOffer(); }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "3":
                                    try { Avaible(); }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                default:
                                    Console.WriteLine("Wrong input\nPress any key to continue");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong input\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddOffer()
        {
            Console.WriteLine("Write Author:\n");
            string aut = Console.ReadLine();
            Console.WriteLine("Write title:\n");
            string title = Console.ReadLine();
            if(docsList.FindByTitle(title).Title==title)
            {
                try
                {
                    Console.Write("Write index of client who takes book ");
                    int ind = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (ind < 0 || ind >= visitorsList.Last)
                        throw new LibraryException("Index out of range");
                    
                    visitorsList.GetInfo(ind - 1).Offer.Add(title);
                }
                catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
            }
            Console.WriteLine("Succesfull");
            Console.ReadKey();
        }

        private void RemoveOffer()
        {
            Console.WriteLine("Write Author:\n");
            string aut = Console.ReadLine();
            Console.WriteLine("Write title:\n");
            string title = Console.ReadLine();
            if (docsList.FindByTitle(title).Title == title)
            {
                try
                {
                    Console.Write("Write index of client who has book ");
                    int ind = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (ind < 0 || ind >= visitorsList.Last)
                        throw new LibraryException("Index out of range");

                    visitorsList.GetInfo(ind - 1).Offer.Remove(title);
                }
                catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
            }
            Console.WriteLine("Succesfull");
            Console.ReadKey();
        }

        private void Avaible()
        {
            Console.WriteLine("Write Author:\n");
            string aut = Console.ReadLine();
            Console.WriteLine("Write title:\n");
            string title = Console.ReadLine();
            Console.WriteLine(visitorsList.FindByBookOwner(aut, title));
            Console.ReadKey();
        }

        #endregion
        #region Docs
        private void Docs()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Add Doc\n2. Remove Doc\n3. Edit Doc\n4. Show Doc info\n5. Show list with all Docs\n6. Sort\n\n0.Exit");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "0":
                        run = false;
                        visitorsList.Save();
                        docsList.Save();
                        break;
                    case "1":
                        try
                        {
                            Console.Write("Write Author: ");
                            string n = Console.ReadLine();
                            Console.Write("Write Title: ");
                            string title = Console.ReadLine();
                            docsList.Add(n, title);
                            Console.WriteLine(docsList.GetInfo(docsList.Last - 1).ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Write index of doc what want delete: ");
                            int ind = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (ind < 0 || ind >= docsList.Last)
                                throw new LibraryException("Index out of range");
                            docsList.Remove(ind);
                            Console.WriteLine("Succesfull deleted");
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "3":
                        try
                        {
                            Console.Write("Write index of Doc: ");
                            int ind = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (ind < 0 || ind >= visitorsList.Last)
                                throw new LibraryException("Index out of range");
                            Console.Write("Write Author: ");
                            string n = Console.ReadLine();
                            Console.Write("Write Title: ");
                            string sn = Console.ReadLine();
                            docsList.Edit(ind, n, sn);
                            Console.Write("Succesfull edited!");
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "4":
                        try
                        {
                            Console.Write("Write index of doc: ");
                            int ind = Convert.ToInt16(Console.ReadLine()) - 1;
                            if (ind < 0 || ind >= docsList.Last)
                                throw new LibraryException("Index out of range");
                            Console.WriteLine(docsList.GetInfo(ind).ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "5":
                        try
                        {
                            Console.WriteLine(docsList.GetDocs());
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "6":
                        try
                        {
                            Console.WriteLine("1. Sort by Author\n2. Sort by Title\n0. Exit");
                            string ans = Console.ReadLine();
                            Console.Clear();
                            switch (ans)
                            {
                                case "0":
                                    run = false;
                                    visitorsList.Save();
                                    docsList.Save();
                                    break;
                                case "1":
                                    try
                                    {
                                        for (int i = 0; i < docsList.Last; i++)
                                            Console.WriteLine(docsList.SortByAuthor()[i].Author);
                                        Console.WriteLine("Succesfull");
                                        Console.ReadKey();
                                    }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                case "2":
                                    try
                                    {
                                        docsList.SortByTitle();
                                        Console.WriteLine("Succesfull");
                                        Console.ReadKey();
                                    }
                                    catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                                    break;
                                default:
                                    Console.WriteLine("Wrong input\nPress any key to continue");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong input\nPress any key to continue");
                        Console.ReadKey();
                        break;
                }
            }
        }
        #endregion
        #region Find
        private void Find()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.WriteLine("\t\tMenu");
                Console.WriteLine("1. Find in Doc\n2. Find in Visitors\n0.Exit");
                string answer = Console.ReadLine();
                Console.Clear();
                switch (answer)
                {
                    case "0":
                        run = false;
                        visitorsList.Save();
                        docsList.Save();
                        break;
                    case "1":
                        try
                        {
                            Console.Write("Write Keyword:\n ");
                            string key = Console.ReadLine();
                            string output = find.FindDocument(docsList, key);
                            Console.WriteLine(output);
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    case "2":
                        try
                        {
                            Console.Write("Write Keyword:\n ");
                            string key = Console.ReadLine();

                            string output = find.FindVisitor(visitorsList, key);
                            Console.WriteLine(output);
                            Console.ReadKey();
                        }
                        catch (Exception e) { Console.WriteLine($"{e.Message}\nPress any key to continue..."); Console.ReadKey(); }
                        break;
                    default:
                        Console.WriteLine("Wrong input\nPress any key to continue");
                        Console.ReadKey();
                        break;

                }
            }
        }
        #endregion
    }
}
