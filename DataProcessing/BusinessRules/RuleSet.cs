using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace DataProcessing.BusinessRules
{
    public class RuleSet : INamed, IDescribed
    {  
        /// <summary>
        /// The name of the rule set
        /// </summary>
        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// The rules contained in this rule set
        /// </summary>
        public IEnumerable<Rule> Rules { get; set; }

        /// <summary>
        /// Whether this rule set has been halted by firing a rule
        /// </summary>
        private bool _isHalted;

        /// <summary>
        /// The messages generated when executing the rules
        /// </summary>
        public List<RuleMessage> Messages { get; set; } = new List<RuleMessage>();

        public void Fire(Dictionary<string, object> record, int line)
        {
            _isHalted = false;

            foreach (var rule in Rules.OrderBy(r => r.Order))
            {
                if (_isHalted)
                {
                    break;
                }

                rule.Fire(new RuleContext(Messages, line), record);
            }
        }

        public void Fire(IEnumerable<Dictionary<string, object>> records)
        {
            var i = 0;

            foreach (var record in records)
            {
                Fire(record, ++i);
            }
        }

        public void Halt()
        {
            _isHalted = true;
        }
    }
}
