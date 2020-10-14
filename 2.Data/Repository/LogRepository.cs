﻿using _1.Core.Domain;
using _2.Data.Infrastructure.Implement;
using _2.Data.Infrastructure.Interface;

namespace _2.Data.Repository
{
    public interface ILogRepository:IRepository<Log>
    {
    }

    public class LogRepository : RepositoryBase<Log>, ILogRepository
    {
        public LogRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}