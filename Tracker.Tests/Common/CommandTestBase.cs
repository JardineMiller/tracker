using System;
using Tracker.DAL;

namespace Tracker.Tests.Common;

public class CommandTestBase : IDisposable
{
    protected readonly ApplicationDbContext Context;

    public CommandTestBase()
    {
        this.Context = DbContextFactory.Create();
    }

    public void Dispose()
    {
        DbContextFactory.Destroy(this.Context);
    }
}