#if DEBUG
/*
 * Copyright (c) .NET Foundation and Contributors
 *
 * This software may be modified and distributed under the terms
 * of the MIT license. See the LICENSE file for details.
 *
 * https://github.com/piranhacms/piranha.core
 *
 */

using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Piranha.Data.EF.SQLServer;

/// <summary>
/// Factory for creating a db context. Only used in dev mode
/// when creating migrations.
/// </summary>
[ExcludeFromCodeCoverage]
public class DbFactory : IDesignTimeDbContextFactory<SQLServerDb>
{
    /// <summary>
    /// Creates a new db context.
    /// </summary>
    /// <param name="args">The arguments</param>
    /// <returns>The db context</returns>
    public SQLServerDb CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<SQLServerDb>();
        builder.UseSqlServer("Server=.;Database=cms;User Id=sa;Password=1q2w3e4r%T;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False");
        return new SQLServerDb(builder.Options);
    }
}
#endif