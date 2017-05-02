
namespace CompleteSQL.Merge
{
    /// <summary>
    /// Базовый класс для шага построения запроса
    /// </summary>
    abstract public class QueryStepBase
    {
        /// <summary>
        /// Компонент для декорирования дальнейшим шагом в запросе
        /// </summary>
        protected readonly QueryPartComponent queryComponent;

        internal QueryStepBase(QueryPartComponent queryComponent)
        {
            this.queryComponent = queryComponent;
        }
    }
}
