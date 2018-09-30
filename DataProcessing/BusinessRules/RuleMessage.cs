namespace DataProcessing.BusinessRules
{
    public struct RuleMessage
    {
        public int Line { get; set; }

        public string[] FieldNames { get; internal set; }

        public string Message { get; set; }
    }
}
