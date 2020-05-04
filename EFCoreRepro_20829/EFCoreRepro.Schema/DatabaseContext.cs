using System;
using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreRepro.Schema
{
    public class DatabaseContext : DbContext
    {
        public const string LocalDatabaseFilename = "local.db";

        public DbSet<Entity> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(new LoggerFactory());

            string dbPath = Path.Combine(Path.GetTempPath(), LocalDatabaseFilename);
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        // Used for viewing SQL sent into the DB
        class LoggerFactory : ILoggerFactory
        {
            public void AddProvider(ILoggerProvider provider) { }
            public ILogger CreateLogger(string categoryName) => new Logger();
            public void Dispose() { }

            class Logger : ILogger
            {
                public bool IsEnabled(LogLevel logLevel) => true;
                public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) => Debug.WriteLine(formatter(state, exception));
                public IDisposable BeginScope<TState>(TState state) => null;
            }
        }
    }
}
