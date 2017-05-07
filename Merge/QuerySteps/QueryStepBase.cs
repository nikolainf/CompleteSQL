
namespace CompleteSQL.Merge
{
    /// <summary>
    /// Базовый класс для шага построения запроса
    /// </summary>
    public abstract class QueryStepBase
    {
        /// <summary>
        /// Компонент для декорирования дальнейшим шагом в запросе
        /// </summary>
        protected QueryPartComponent queryComponent;

        internal QueryStepBase(QueryPartComponent queryComponent)
        {
            this.queryComponent = queryComponent;
        }

        internal QueryStepBase()
        {

        }

        internal QueryPartComponent QueryComponent
        {
            set
            {
                queryComponent = value;
            }
        }

      
    }
}
