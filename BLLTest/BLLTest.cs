using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLTest
{
    [TestClass()]
    public class BLLTests
    {
        VisitorsList testvisit = new VisitorsList();
        DocsList testdocs = new DocsList();
        Find testfind = new Find();

        [TestMethod()]
        public void AddVisitor()
        {
            string Name = "name";
            string Sname = "sname";

            testvisit.Add(Name, Sname, 117, new DocOffers());
            string actual = testvisit.GetInfo(0).Name;

            Assert.AreEqual(Name, actual);
        }

        [TestMethod()]
        public void DeleteVisitor()
        {
            string Name1 = "name1";
            string Name2 = "name2";

            testvisit.Add(Name1, "test", 222, new DocOffers());
            testvisit.Add(Name2, "test", 222, new DocOffers());
            testvisit.Remove(0);
            string actual = testvisit.GetInfo(0).Name;

            Assert.AreEqual(Name2, actual);
        }

        [TestMethod()]
        public void EditInfo()
        {
            string Name1 = "name1";
            string Name2 = "name2";

            testvisit.Add(Name1, "test", 222, new DocOffers());
            testvisit.Edit(0,Name2,"test",222);
            string actual = testvisit.GetInfo(0).Name;

            Assert.AreEqual(Name2, actual);
        }

        [TestMethod()]
        public void SortByName()
        {
            string Name1 = "AAA";
            string Name2 = "BBB";

            testvisit.Add(Name2, "test", 222, new DocOffers());
            testvisit.Add(Name1, "test", 222, new DocOffers());
            testvisit.SortByName();
            string actual = testvisit.GetInfo(0).Name;

            Assert.AreEqual(Name1, actual);
        }

        [TestMethod()]
        public void SortBySurname()
        {
            string SName1 = "AAA";
            string SName2 = "BBB";

            testvisit.Add("test", SName2, 222, new DocOffers());
            testvisit.Add("test", SName1, 222, new DocOffers());
            testvisit.SortBySurname();
            string actual = testvisit.GetInfo(0).Surname;

            Assert.AreEqual(SName1, actual);
        }

        [TestMethod()]
        public void SortByGroup()
        {
            int group1 = 111;
            int group2 = 222;

            testvisit.Add("test", "test", group2, new DocOffers());
            testvisit.Add("test", "test", group1, new DocOffers());
            testvisit.SortByGroup();
            int actual = testvisit.GetInfo(0).AcademGroup;

            Assert.AreEqual(group1, actual);
        }

        [TestMethod()]
        public void FindByName()
        {
            string Name1 = "AAA";

            testvisit.Add(Name1, "test", 222, new DocOffers());
            string actual = testvisit.FindByName("AAA").Name;

            Assert.AreEqual(Name1, actual);
        }
        [TestMethod()]
        public void FindBySurname()
        {
            string SName1 = "AAA";

            testvisit.Add("test", SName1, 222, new DocOffers());
            string actual = testvisit.FindBySurname("AAA").Surname;

            Assert.AreEqual(SName1, actual);
        }

        [TestMethod()]
        public void FindByGroup()
        {
            int group = 123;

            testvisit.Add("test", "test", group, new DocOffers());
            int actual = testvisit.FindByGroup(123).AcademGroup;

            Assert.AreEqual(group, actual);
        }

        [TestMethod()]
        public void DocAdd()
        {
            string Author = "ABS";

            testdocs.Add(Author, "test");
            string actual = testdocs.GetInfo(0).Author;

            Assert.AreEqual(Author,actual);
        }

        [TestMethod()]
        public void DocDelete()
        {
            string Author1 = "ABS";
            string Author2 = "BBB";

            testdocs.Add(Author1, "test");
            testdocs.Add(Author2, "test");
            testdocs.Remove(0);
            string actual = testdocs.GetInfo(0).Author;

            Assert.AreEqual(Author2, actual);
        }

        [TestMethod()]
        public void DocEdit()
        {
            string Author1 = "ABS";
            string Author2 = "BBB";

            testdocs.Add(Author1, "test");
            testdocs.Edit(0,Author2,"test");
            string actual = testdocs.GetInfo(0).Author;

            Assert.AreEqual(Author2, actual);
        }




    }

}
