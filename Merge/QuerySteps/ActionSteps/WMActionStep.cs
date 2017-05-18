using CompleteSQL.Merge.QueryPartsFactory;

namespace CompleteSQL.Merge
{
    public class WMActionStep<TSource>: ActionStepBase
    {
        internal WMActionStep(QueryPartComponent queryComponent) : base(queryComponent) { }

        public WmWnmActionContainer<TSource> WhenNotMatched()
        {
            var whenNotMatchedByTarget = queryComponent.CreateWNMByTargetQueryPart();

            return new WmWnmActionContainer<TSource>(whenNotMatchedByTarget);

        }

        

        public WmWnmBySourceActionContainer<TSource> WhenNotMatchedBySource()
        {
            var whenNotMatchedBySource = queryComponent.CreateWNMBySourceQueryPart();

            return new WmWnmBySourceActionContainer<TSource>(whenNotMatchedBySource);

        }
    }
}
