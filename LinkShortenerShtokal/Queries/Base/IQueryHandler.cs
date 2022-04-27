namespace LinkShortenerShtokal.Queries.Base
{
    public interface IQueryHandler<TQuery, TResult>  
        where TQuery : IQuery<TResult>
        //where TResult : IQueryResult
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
