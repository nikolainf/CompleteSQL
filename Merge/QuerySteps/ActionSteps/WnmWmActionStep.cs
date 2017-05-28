using CompleteSQL.Merge.QueryPartsFactory;
using System;


namespace CompleteSQL.Merge
{
    public class WnmWmActionStep<TSource>: ActionStepBase
    {
        internal WnmWmActionStep(QueryPartComponent queryComponent): base(queryComponent)
        {

        }

        public object WhenNotMatchedBySource()
        {
            var whenNotMatchedBySource = queryComponent.CreateWNMBySourceQueryPart();

            throw new NotImplementedException();
        }
    }
}
