using _01_Framework.Infrastructure;

namespace DB.Infrastructure.EFCore
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly DevBloggerContext _context;

        public UnitOfWorkEF(DevBloggerContext context)
        {
            _context = context;
        }

        public void BeginTran()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTran()
        {
            _context.SaveChanges();
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
