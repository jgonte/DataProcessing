namespace Integration.Core.Exports
{
    public class FixedLengthField
    {
        /// <summary>
        /// Name of the field that should match the one in the record
        /// In case of a filler, the name must be null
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The length of the field to output
        /// </summary>
        public int Length { get; set; }

        public enum DataTypes
        {
            Filler,
            Alphabetic,
            AlphaNumeric,
            Numeric
        }

        public DataTypes DataType { get; set; }

        public enum FieldFormats
        {
            None,
            RightJustifiedLeadingZeroes,
            LeftJustified,
            RightJustifiedLeadingBlanks
        }

        public FieldFormats FieldFormat { get; set; }
    }
}