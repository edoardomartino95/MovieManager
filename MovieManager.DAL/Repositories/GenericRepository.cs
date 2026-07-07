using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieManager.DAL.Data;
using MovieManager.DAL.Repositories.Interfaces;

namespace MovieManager.DAL.Repositories;
//il cancellation token serve per notificare una chiusura di connessione dell'API dal frontend vs backend per esempio refresh di pagina, o chiudere la scheda 
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly MovieDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(MovieDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context
            .Set<T>();
    }
         
    public  async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .FindAsync(new object[] { id }, cancellationToken);
    }

    public  async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public  async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .ToListAsync(cancellationToken);
    }

    public  async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet
            .AddAsync(entity, cancellationToken);
    }

    public  void Update(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity)
            .State = EntityState
            .Modified;
    }

    public  void Remove(T entity)
    {
        _dbSet
            .Remove(entity);
    }
}