using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yamo;
using Microsoft.Data.SqlClient;
using FWAcore.Model;
using System.Data.Common;

namespace FWAdata.DbAccess;

public partial class DbContext : Yamo.DbContext
{
    private readonly string _connectionString;

    public int UserId { get; set; }

    public DbContext(string connectionString, int userId)
    {
        _connectionString = connectionString;
        UserId = userId;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		GeneratedOnModelCreating(modelBuilder);

		// define entity relationships here...
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        optionsBuilder.UseSqlServer(CreateConnection);
    }

    private SqlConnection CreateConnection()
    {
        var conn = new SqlConnection(_connectionString);
        conn.Open();
        return conn;
    }

    // Breakpoint here to see generated SQL statements
    protected override void OnCommandExecuting(DbCommand command)
    {
        base.OnCommandExecuting(command);
    }
}
