using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorteren;
using Catalogus;

namespace TestSorteren
{
    [TestClass]
    public class UnitTestSorteren
    {
        [TestMethod]
        public void TestSorteerMethodesInt()
        {
            int[] start = { 5, 1, -10, 667, 4 };
            int[] getallen = { 5, 1, -10, 667, 4 };
            SorteerBib<int>.SelectieSorteer(getallen);
            int[] resultaat = { -10, 1, 4, 5, 667 };
            CollectionAssert.AreEqual(resultaat, getallen);
            getallen = start;
            IList<int> reeks = new List<int>(getallen);
            IList<int> gesorteerd = SorteerBib<int>.SelectieSorteer(reeks);
            CollectionAssert.AreEqual(resultaat, gesorteerd.ToArray<int>());
            getallen = start;
            SorteerBib<int>.BubbleSorteer(getallen);
            CollectionAssert.AreEqual(resultaat, getallen);
            getallen = start;
            reeks = new List<int>(getallen);
            gesorteerd = SorteerBib<int>.BubbleSorteer(reeks);
            CollectionAssert.AreEqual(resultaat, gesorteerd.ToArray<int>());
        }

        [TestMethod]
        public void TestSorteermethodesString()
        {
            string[] namen = { "Jeroen", "Ann", "Els", "Veerle", "Thomas" };
            SorteerBib<string>.SelectieSorteer(namen);
            string[] resultaat = { "Ann", "Els", "Jeroen", "Thomas", "Veerle" };
            CollectionAssert.AreEqual(resultaat, namen);
            namen = new string[] { "Jeroen", "Ann", "Els", "Veerle", "Thomas" };
            SorteerBib<string>.BubbleSorteer(namen);
            CollectionAssert.AreEqual(resultaat, namen);
        }

        [TestMethod]
        public void TestSorteerIBibItem()
        {
            IList<Boek> subafdeling = new List<Boek>();
            Boek boek = new Boek { Id = "ID04", Titel = "Ik ben Pelgrim", Auteur = "Terry Hayes", Uitgeverij = "Bruna", Jaartal = 2014 };
            subafdeling.Add(boek);
            boek = new Boek { Id = "ID05", Titel = "Kou uit het oosten", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            subafdeling.Add(boek);
            boek = new Boek { Id = "ID06", Titel = "De monogrammoorden", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            subafdeling.Add(boek);
            boek = new Boek { Id = "ID07", Titel = "Kou uit het oosten", Auteur = "Ken Follett", Uitgeverij = "Van Holkema", Jaartal = 2014 };
            subafdeling.Add(boek);

            IList<Boek> resultaat = new List<Boek>();
            resultaat.Add(subafdeling[2]);
            resultaat.Add(subafdeling[1]);
            resultaat.Add(subafdeling[3]);
            resultaat.Add(subafdeling[0]);
            IList<Boek> gesorteerd = SorteerBib<Boek>.BubbleSorteer(subafdeling, new Sorteerder());
            CollectionAssert.AreEqual(resultaat.ToArray<Boek>(), gesorteerd.ToArray<Boek>());
            gesorteerd = SorteerBib<Boek>.SelectieSorteer(subafdeling, new Sorteerder());
            CollectionAssert.AreEqual(resultaat.ToArray<Boek>(), gesorteerd.ToArray<Boek>());
        }
    }
}
