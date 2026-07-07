namespace MovieManager.DAL.Repositories.Interfaces
{
    public interface IMovieActorRepository<T> where T : class 
    {
        //task permette 
        Task<T?> GetByIdsAsync(int movieId, int actorId, CancellationToken cancellationToken);
        Task<T?> GetByMovieIdAsync(int movieId, CancellationToken cancellationToken);
        Task<T?> ExistsAsync(int movieId, int actorId, CancellationToken cancellationToken);
    }
}
