using DataProcessing.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataProcessing.Tests.Builders.Tasks.Writers
{
    [TestClass]
    public class ExcelWriterTaskTests
    {
        class Person
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string DateOfBirth { get; set; }

            public string IQ { get; set; }
        }

        [TestMethod]
        public void Excel_Writer_Task_Builder_Tests()
        {
            var path = @"C:\IntegrationTests\SmartPeople_Copy.xlsx";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var builder = new ExcelWriterTaskBuilder<Person>
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
                    }
                }
            };

            var writer = builder.Build();

            writer.Execute();
        }
    }
}
