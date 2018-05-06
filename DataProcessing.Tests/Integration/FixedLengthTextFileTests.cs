using Integration.Core.Exports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Integration.Tests
{
    [TestClass]
    public class Fixed_Length_Text_File_Write_Tests
    {
        [TestMethod]
        public void Fixed_Length_Text_File_Write_Test()
        {
            var file = new FixedLengthTextFile
            {
                FilePath = @"c:\IntegrationTests\FixedLengthTextFile.txt",
                FieldDefinitions = new List<FixedLengthField>
                {
                    new FixedLengthField
                    {
                        Name = "DistrictNumberCurrentEnrollment",
                        DataType = FixedLengthField.DataTypes.Numeric,
                        Length = 2,
                        FieldFormat = FixedLengthField.FieldFormats.RightJustifiedLeadingZeroes
                    },
                    new FixedLengthField
                    {
                        Name = "SchoolNumberCurrentEnrollment",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 4,
                        FieldFormat = FixedLengthField.FieldFormats.RightJustifiedLeadingZeroes
                    },
                    new FixedLengthField
                    {
                        Name = "StudentNumberIdentifierFlorida",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 10,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "SurveyPeriodCode",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "FiscalYear",
                        DataType = FixedLengthField.DataTypes.Numeric,
                        Length = 4,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DistrictNumberCurrentInstructionOrService",
                        DataType = FixedLengthField.DataTypes.Numeric,
                        Length = 2,
                        FieldFormat = FixedLengthField.FieldFormats.RightJustifiedLeadingZeroes
                    },
                    new FixedLengthField
                    {
                        Name = "SchoolNumberCurrentInstructionOrService",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 4,
                        FieldFormat = FixedLengthField.FieldFormats.RightJustifiedLeadingZeroes
                    },
                    new FixedLengthField
                    {
                        Name = "CourseNumber",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 7,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "SectionNumber",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 5,
                        FieldFormat = FixedLengthField.FieldFormats.LeftJustified
                    },
                    new FixedLengthField
                    {
                        Name = "PeriodNumber",
                        DataType = FixedLengthField.DataTypes.Numeric,
                        Length = 4,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DaysPerWeek",
                        DataType = FixedLengthField.DataTypes.Numeric,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "LocationOfStudent",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        DataType = FixedLengthField.DataTypes.Filler,
                        Length = 4,
                    },
                    new FixedLengthField
                    {
                        Name = "ClassMinutesWeekly",
                        DataType = FixedLengthField.DataTypes.Numeric,
                        Length = 4,
                        FieldFormat = FixedLengthField.FieldFormats.RightJustifiedLeadingZeroes
                    },
                    new FixedLengthField
                    {
                        Name = "FEFPProgramNumbers",
                        DataType = FixedLengthField.DataTypes.Numeric,
                        Length = 3,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "FTEReportedCourse",
                        DataType = FixedLengthField.DataTypes.Numeric,
                        Length = 4,
                        FieldFormat = FixedLengthField.FieldFormats.RightJustifiedLeadingZeroes
                    },
                    new FixedLengthField
                    {
                        Name = "OnlineCourseProvider",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 3,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        DataType = FixedLengthField.DataTypes.Filler,
                        Length = 4,
                    },
                    new FixedLengthField
                    {
                        Name = "GradeLevel",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 2,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "VirtualInstructionProvider",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 3,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "TransactionCode",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "EnglishLanguageLearnersInstructionalModel",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "YearRoundOrExtendedSchoolYearFTEIndicator",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DualEnrollmentIndicator",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "Term",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "CareerandTechnicalEducationOrAdultGeneralEducationProgramCode",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 7,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DayofWeekScheduledMonday",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DayofWeekScheduledTuesday",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DayofWeekScheduledWednesday",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DayofWeekScheduledThursday",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DayofWeekScheduledFriday",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DayofWeekScheduledSaturday",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DayofWeekScheduledDateCertain",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "DayofWeekScheduledDateCertain",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "ReadingInterventionComponent",
                        DataType = FixedLengthField.DataTypes.Alphabetic,
                        Length = 1,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "FloridaEducationIdentifier",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 14,
                        FieldFormat = FixedLengthField.FieldFormats.None
                    },
                    new FixedLengthField
                    {
                        Name = "CourseGrade",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 3,
                        FieldFormat = FixedLengthField.FieldFormats.RightJustifiedLeadingBlanks
                    },
                    new FixedLengthField
                    {
                        DataType = FixedLengthField.DataTypes.Filler,
                        Length = 36,
                    },
                    new FixedLengthField
                    {
                        Name = "StudentNumberIdentifierLocal",
                        DataType = FixedLengthField.DataTypes.AlphaNumeric,
                        Length = 10,
                        FieldFormat = FixedLengthField.FieldFormats.RightJustifiedLeadingZeroes
                    },
                    new FixedLengthField
                    {
                        DataType = FixedLengthField.DataTypes.Filler,
                        Length = 8,
                    },
                }
            };

            var data = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object>
                {
                    { "DistrictNumberCurrentEnrollment", 6 },
                    { "SchoolNumberCurrentEnrollment", 388 },
                    { "StudentNumberIdentifierFlorida", "123456789X" },
                    { "SurveyPeriodCode", 8 },
                    { "FiscalYear", 1718 },
                    { "DistrictNumberCurrentInstructionOrService", 12 },
                    { "SchoolNumberCurrentInstructionOrService", 9388 },
                    { "CourseNumber", "XXX9999" },
                    { "SectionNumber", "ZZZZZ" },
                    { "PeriodNumber", "0103" },
                    { "DaysPerWeek", 5 },
                    { "LocationOfStudent", 'S' },
                    { "ClassMinutesWeekly", 45 },
                    { "FEFPProgramNumbers", 111 },
                    { "FTEReportedCourse", 123 },
                    { "OnlineCourseProvider", "ZZZ" },
                    { "GradeLevel", "KG" },
                    { "VirtualInstructionProvider", "123" },
                    { "TransactionCode", "A" },
                    { "EnglishLanguageLearnersInstructionalModel", "C" },
                    { "YearRoundOrExtendedSchoolYearFTEIndicator", "A" },
                    { "DualEnrollmentIndicator", "A" },
                    { "Term", "3" },
                    { "CareerandTechnicalEducationOrAdultGeneralEducationProgramCode", "XXXXXXX" },
                    { "DayofWeekScheduledMonday", "Y" },
                    { "DayofWeekScheduledTuesday", "N" },
                    { "DayofWeekScheduledWednesday", "Y" },
                    { "DayofWeekScheduledThursday", "N" },
                    { "DayofWeekScheduledFriday", "Y" },
                    { "DayofWeekScheduledSaturday", "N" },
                    { "DayofWeekScheduledDateCertain", "Y" },
                    { "ReadingInterventionComponent", "Y" },
                    { "FloridaEducationIdentifier", "FL123456789012" },
                    { "CourseGrade", "A+" },
                    { "StudentNumberIdentifierLocal", 1 }
                    
                },
                new Dictionary<string, object>
                {
                    { "DistrictNumberCurrentEnrollment", 12 },
                    { "SchoolNumberCurrentEnrollment", 9388 },
                    { "StudentNumberIdentifierFlorida", "0634567891" },
                    { "SurveyPeriodCode", 'X' },
                    { "FiscalYear", 1718 },
                    { "DistrictNumberCurrentInstructionOrService", 6 },
                    { "SchoolNumberCurrentInstructionOrService", 388 },
                    { "CourseNumber", "ZZZC99C" },
                    { "SectionNumber", "ZZ11" },
                    { "PeriodNumber", "9999" },
                    { "DaysPerWeek", 0 },
                    { "LocationOfStudent", 'Z' },
                    { "ClassMinutesWeekly", 9945 },
                    { "FEFPProgramNumbers", 222 },
                    { "FTEReportedCourse", 1234 },
                    { "OnlineCourseProvider", "YYY" },
                    { "GradeLevel", "12" },
                    { "VirtualInstructionProvider", "ZZZ" },
                    { "TransactionCode", "U" },
                    { "EnglishLanguageLearnersInstructionalModel", "Z" },
                    { "YearRoundOrExtendedSchoolYearFTEIndicator", "Z" },
                    { "DualEnrollmentIndicator", "Z" },
                    { "Term", "Z" },
                    { "CareerandTechnicalEducationOrAdultGeneralEducationProgramCode", "ZZZZZZZ" },
                    { "DayofWeekScheduledMonday", "N" },
                    { "DayofWeekScheduledTuesday", "Y" },
                    { "DayofWeekScheduledWednesday", "N" },
                    { "DayofWeekScheduledThursday", "Y" },
                    { "DayofWeekScheduledFriday", "N" },
                    { "DayofWeekScheduledSaturday", "Y" },
                    { "DayofWeekScheduledDateCertain", "N" },
                    { "ReadingInterventionComponent", "Z" },
                    { "FloridaEducationIdentifier", "FL003456789012" },
                    { "CourseGrade", "100" },
                    { "StudentNumberIdentifierLocal", 2 }
                }
            };

            file.Write(data);
        }
    }
}
