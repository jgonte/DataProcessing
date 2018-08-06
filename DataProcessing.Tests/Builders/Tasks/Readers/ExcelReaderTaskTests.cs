using DataProcessing.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataProcessing.Tests.Builders
{
    [TestClass]
    public class ExcelReaderTaskTests
    {
        class Person
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string DateOfBirth { get; set; }

            public string IQ { get; set; }
        }

        [TestMethod]
        public void Excel_Reader_Task_Builder_Tests()
        {
            var builder = new ExcelReaderTaskBuilder<Person>
            {
                Description = "Reads an Excel file of smart people",
                FullPath = @"C:\IntegrationTests\SmartPeople.xlsx",
                HasHeader = true,
                ColumnIndexToPropertyMap = new Dictionary<int, string>
                {
                    { 1, "FirstName"},
                    { 2, "LastName" },
                    { 3, "DateOfBirth" },
                    { 4, "IQ" }
                }
            };

            var reader = builder.Build();

            reader.Execute();

            var results = reader.Results;

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
