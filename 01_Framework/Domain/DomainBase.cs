using System;

namespace _01_Framework.Domain
{
    public class DomainBase<TKey>
    {
        public TKey Id { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DomainBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
