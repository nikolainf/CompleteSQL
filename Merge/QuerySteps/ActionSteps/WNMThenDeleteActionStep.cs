﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class WNMThenDeleteActionStep<TSource> : ActionStepBase
    {
        internal WNMThenDeleteActionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }

        public WMFirstConditionStep<TSource> WhenMatched()
        {
            throw new NotImplementedException();
        }
    }
}