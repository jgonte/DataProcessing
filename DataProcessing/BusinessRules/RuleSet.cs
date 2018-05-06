using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace DataProcessing.BusinessRules
{
    public class RuleSet : INamed
    {  
        /// <summary>
        /// The name of the rule set
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The rules contained in this rule set
        /// </summary>
        public IEnumerable<Rule> Rules { get; set; }

        /// <summary>
        /// Whether this rule set has been halted by firing a rule
        /// </summary>
        private bool _isHalted;

        public void Fire(Dictionary<string, object> record)
        {
            _isHalted = false;

            foreach (var rule in Rules.OrderBy(r => r.Order))
            {
                if (_isHalted)
                {
                    break;
                }

                rule.Fire(record);
            }
        }

        public void Halt()
        {
            _isHalted = true;
        }
    }
}
