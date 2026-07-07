using Microsoft.EntityFrameworkCore;
using MovieManager.DAL.Data;
using MovieManager.DAL.Repositories.Interfaces;


namespace MovieManager.DAL.Repositories
{
    public class MovieActorRepository<T> : IMovieActorRepository<T> where T : class
    {
        private readonly MovieDbContext _context;
        private readonly DbSet<T> _dbSet;

        public MovieActorRepository(MovieDbContext movieDbContext)
        {
            _context = movieDbContext;
            _dbSet = _context.Set<T>();
        }

        public Task<T?> ExistsAsync(int movieId, int actorId, CancellationToken cancellationToken)
        {
           
            return _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => EF.Property<int>(e, "MovieId") == movieId
                                          && EF.Property<int>(e, "ActorId") == actorId,
                                        cancellationToken);
        }

        public Task<T?> GetByIdsAsync(int movieId, int actorId, CancellationToken cancellationToken)
        {
           
            try
            {
                return _dbSet.FindAsync(new object[] { movieId, actorId }, cancellationToken).AsTask();
            }
            catch
            {
                return _dbSet
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => EF.Property<int>(e, "MovieId") == movieId
                                              && EF.Property<int>(e, "ActorId") == actorId,
                                            cancellationToken);
            }
        }

        public Task<T?> GetByMovieIdAsync(int movieId, CancellationToken cancellationToken)
        {
            return _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(e => EF.Property<int>(e, "MovieId") == movieId, cancellationToken);
        }

    }
}
