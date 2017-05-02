
namespace CompleteSQL.Merge
{
    /// <summary>
    /// Базовый класс для элементов-декораторов
    /// </summary>
    public abstract class QueryPartDecorator : QueryPartComponent
    {
        /// <summary>
        /// Декорируемый компонент
        /// </summary>
        private QueryPartComponent m_queryPartComponent;

        /// <summary>
        /// Декорируемый компонент
        /// </summary>
        internal QueryPartComponent QueryPartComponent
        {
            get
            {
                // Возвращает декорируемый компонент
                return m_queryPartComponent;
            }
            set
            {
                // Копирование членов из декорируемого компонента
                this.tableSchema = value.tableSchema;
                if (value.mergePredicateBody != null)
                    this.mergePredicateBody = value.mergePredicateBody;

                // Установка декорируемого компонента
                m_queryPartComponent = value;
            }
        }
       
        /// <summary>
        /// Возвращает построенный SQL-запрос с учетом декорированных компонентов
        /// </summary>
        /// <returns></returns>
        internal override string GetQueryPart()
        {
            return QueryPartComponent != null 
                ? QueryPartComponent.GetQueryPart()
                : string.Empty;
        }

    }
}
