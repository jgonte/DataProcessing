using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataProcessing.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataProcessing.Tests.Tasks.Readers
{
    [TestClass]
    public class ExcelWriterAndReaderTests
    {
        class Person
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string DateOfBirth { get; set; }

            public string IQ { get; set; }
        }

        [TestMethod]
        public void Excel_Writer_And_Reader_Tests()
        {
            var path = @"C:\IntegrationTests\SmartPeople.xlsx";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            new ExcelWriterTask<Person>
            {
                Description = "Writes an Excel file of smart people",
                FullPath = path,
                OuputHeader = true,
                WorksheetName = "People",
                PropertyToColumnIndexMap = new Dictionary<string, int>
                {
                    { "FirstName", 1 },
                    { "LastName", 2 },
                    { "DateOfBirth", 3 },
                    { "IQ", 4 }
                },
                ColumnIndexToHeaderTitleMap = new Dictionary<int, string>
                {
                    { 1,  "First Name" },
                    { 2,  "Last Name" },
                    { 3,  "Date Of Birth" }
                },
                Records = new List<Person>
                {
                    new Person
                    {
                        FirstName = "Albert",
                        LastName = "Einstein",
                        DateOfBirth = new DateTime(1879, 3, 14).ToString(),
                        IQ = "160"
                    },
                    new Person
                    {
                        FirstName = "Leonhard",
                        LastName = "Euler",
                        DateOfBirth = new DateTime(1707, 4, 15).ToString(),
                        IQ = "195"
                    },
                    new Person
                    {
                        FirstName = "Isaac",
                        LastName = "Newton",
                        DateOfBirth = new DateTime(1643, 1, 4).ToString(),
                        IQ = "190"
                    },
                }
            }
            .Execute();

            var readerTask = new ExcelReaderTask<Person>
            {
                Description = "Reads an Excel file of smart people",
                FullPath = path,
                HasHeader = true,
                ColumnIndexToPropertyMap = new Dictionary<int, string>
                {
                    { 1, "FirstName"},
                    { 2, "LastName" },
                    { 3, "DateOfBirth" },
                    { 4, "IQ" }
                }
            };

            readerTask.Execute();

            var results = readerTask.Results;

            Assert.AreEqual(3, results.Count);

            var person = results.ElementAt(0);

            Assert.AreEqual("Albert", person.FirstName);

            Assert.AreEqual("Einstein", person.LastName);

            Assert.AreEqual(new DateTime(1879, 3, 14).ToString(), person.DateOfBirth);

            Assert.AreEqual("160", person.IQ);

            person = results.ElementAt(1);

            Assert.AreEqual("Leonhard", person.FirstName);

            Assert.AreEqual("Euler", person.LastName);

            Assert.AreEqual(new DateTime(1707, 4, 15).ToString(), person.DateOfBirth);

            Assert.AreEqual("195", person.IQ);

            person = results.ElementAt(2);

            Assert.AreEqual("Isaac", person.FirstName);

            Assert.AreEqual("Newton", person.LastName);

            Assert.AreEqual(new DateTime(1643, 1, 4).ToString(), person.DateOfBirth);

            Assert.AreEqual("190", person.IQ);
        }
    }
}
