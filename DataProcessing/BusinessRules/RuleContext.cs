using System.Collections.Generic;

namespace DataProcessing.BusinessRules
{
    public class RuleContext
    {
        /// <summary>
        /// The reference to the messages from the rule set
        /// </summary>
        public List<RuleMessage> Messages { get; set; }

        /// <summary>
        /// The line of the record where the rule executed it
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// The name of the fields involved when its condition evaluated to true
        /// </summary>
        public HashSet<string> FieldNames { get; set; }

        private int line;

        public RuleContext(List<RuleMessage> messages, int line)
        {
            Messages = messages;

            Line = line;
        }
    }
}