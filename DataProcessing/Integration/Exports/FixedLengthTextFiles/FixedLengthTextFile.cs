using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Integration.Core.Exports
{
    public class FixedLengthTextFile
    {
        /// <summary>
        /// The path of the file to write to
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// The definitions of the fields to format
        /// </summary>
        public List<FixedLengthField> FieldDefinitions { get; set; }

        /// <summary>
        /// Internal buffer for a line
        /// </summary>
        private StringBuilder _buffer = new StringBuilder();

        public void Write(List<Dictionary<string, object>> data)
        {
            using (StreamWriter file = new StreamWriter(FilePath))
            {
                var i = 1;

                foreach (var record in data)
                {
                    var line = FormatRecord(record, i);

                    ++i;

                    file.WriteLine(line);
                }                
            }
        }

        private string FormatRecord(Dictionary<string, object> record, int line)
        {
            _buffer.Clear();

            foreach (var field in FieldDefinitions)
            {
                // In case of a filler, the field name is null
                var value = string.IsNullOrWhiteSpace(field.Name) ? null : GetFieldValue(record, field.Name, line);

                var formattedField = FormatField(value, field, line);

                _buffer.Append(formattedField);
            }

            return _buffer.ToString();
        }

        private object GetFieldValue(Dictionary<string, object> record, string name, int line)
        {
            if (!record.ContainsKey(name))
            {
                throw new InvalidOperationException($"Record does not contain data in field: '{name}' in line: {line}");
            }

            return record[name];
        }

        private string FormatField(object value, FixedLengthField field, int line)
        {
            string stringValue = null;

            switch (field.DataType)
            {
                case FixedLengthField.DataTypes.Filler: return new string(' ', field.Length);
                case FixedLengthField.DataTypes.Alphabetic:
                    {
                        stringValue = value.ToString();

                        ValidateLength(stringValue, field.Length, field.Name, line);

                        ValidateAlphabetic(stringValue, field.Name, line);
                    }
                    break;
                case FixedLengthField.DataTypes.AlphaNumeric:
                    {
                        stringValue = value.ToString();

                        ValidateLength(stringValue, field.Length, field.Name, line);

                        ValidateAlphaNumeric(stringValue, field.Name, line);
                    }
                    break;
                case FixedLengthField.DataTypes.Numeric:
                    {
                        stringValue = value.ToString();

                        ValidateLength(stringValue, field.Length, field.Name, line);

                        ValidateNumeric(stringValue, field.Name, line);
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            switch (field.FieldFormat)
            {
                case FixedLengthField.FieldFormats.None: return stringValue;
                case FixedLengthField.FieldFormats.RightJustifiedLeadingZeroes:
                    {
                        if (stringValue.Length == field.Length)
                        {
                            return stringValue; // Nothing to pad
                        }

                        return new String('0', field.Length - stringValue.Length) + stringValue;
                    }
                case FixedLengthField.FieldFormats.RightJustifiedLeadingBlanks:
                    {
                        if (stringValue.Length == field.Length)
                        {
                            return stringValue; // Nothing to pad
                        }

                        return new String(' ', field.Length - stringValue.Length) + stringValue;
                    }
                case FixedLengthField.FieldFormats.LeftJustified:
                    {
                        if (stringValue.Length == field.Length)
                        {
                            return stringValue; // Nothing to pad
                        }

                        return stringValue + new String(' ', field.Length - stringValue.Length);
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        private void ValidateLength(string stringValue, int length, string name, int line)
        {
            if (stringValue.Length > length)
            {
                throw new InvalidOperationException($"Field: '{name}' has a length ({stringValue.Length}) greater that the maximum ({length}) in line: {line}");
            }
        }

        private void ValidateAlphabetic(string stringValue, string name, int line)
        {
            if (!stringValue.All(c => Char.IsLetter(c)))
            {
                throw new InvalidOperationException($"Field: '{name}' is not alphabetic in line: {line}");
            }
        }

        private void ValidateAlphaNumeric(string stringValue, string name, int line)
        {
            if (!stringValue.All(c => Char.IsLetterOrDigit(c) || Char.IsSymbol(c)))
            {
                throw new InvalidOperationException($"Field: '{name}' is not alphanumeric in line: {line}");
            }
        }

        private void ValidateNumeric(string stringValue, string name, int line)
        {
            if (!stringValue.All(c => Char.IsDigit(c)))
            {
                throw new InvalidOperationException($"Field: '{name}' is not numeric in line: {line}");
            }
        }
    }
}
