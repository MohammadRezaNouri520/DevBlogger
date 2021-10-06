namespace _01_Framework.Infrastructure
{
    public interface UnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void RollBack();
    }
}
