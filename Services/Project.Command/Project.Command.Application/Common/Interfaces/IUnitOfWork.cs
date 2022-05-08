using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Command.Application.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
