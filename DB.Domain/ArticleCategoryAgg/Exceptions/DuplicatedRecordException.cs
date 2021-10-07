using System;

namespace DB.Domain.ArticleCategoryAgg.Exceptions
{
    public class DuplicatedRecordException : Exception
    {
        public DuplicatedRecordException()
        {
        }

        public DuplicatedRecordException(string message):base(message)
        {
        }
    }
}
