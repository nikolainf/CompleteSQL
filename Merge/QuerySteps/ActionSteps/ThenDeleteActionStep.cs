﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Merge
{
    public class ThenDeleteActionStep<TSource> : ActionStepBase
    {
        internal ThenDeleteActionStep(QueryPartComponent queryComponent)
            : base(queryComponent)
        { }
    }
}
