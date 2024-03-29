﻿using DataProcessing.BusinessRules;
using System.Collections.Generic;
using System.Linq;
using Utilities;
using Utilities.Builders;

namespace DataProcessing.Builders
{
    public class RuleSetBuilder : Builder<RuleSet>,
        INamed,
        IRuleBuildersHolder
    {
        string INamed.Name { get; set; }

        List<RuleBuilder> IRuleBuildersHolder.RuleBuilders { get; set; } = new List<RuleBuilder>();

        public override void Initialize(RuleSet ruleSet)
        {
            ruleSet.Name = ((INamed)this).Name;

            ruleSet.Rules = ((IRuleBuildersHolder)this).RuleBuilders.ToList(b => b.Build());
        }
    }
}
