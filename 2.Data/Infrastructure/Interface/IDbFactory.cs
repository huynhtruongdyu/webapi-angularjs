using System;

namespace _2.Data.Infrastructure.Interface
{
    public interface IDbFactory : IDisposable
    {
        MyDbContext Init();
    }
}