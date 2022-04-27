namespace LinkShortenerShtokal.Queries.Base
{
    public interface IQueryDispatcher
    {
        Task<TQueryResult> QueryAsync<TQuery, TQueryResult>(TQuery command)
            where TQuery : IQuery<TQueryResult>
            //where TQueryResult : IQueryResult
            ;
    }
}