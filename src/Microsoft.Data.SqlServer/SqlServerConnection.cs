﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Data.Common;
using JetBrains.Annotations;
using Microsoft.Data.Entity;
using Microsoft.Data.Relational;
using System.Data.SqlClient;

namespace Microsoft.Data.SqlServer
{
    public class SqlServerConnection : RelationalConnection
    {
        public SqlServerConnection([NotNull] ContextConfiguration configuration)
            : base(configuration)
        {
        }

        protected override DbConnection CreateDbConnection()
        {
            // TODO: Consider using DbProviderFactory to create connection instance
            return new SqlConnection(ConnectionString);
        }

        public virtual DbConnection CreateMasterConnection()
        {
            var builder = new DbConnectionStringBuilder { ConnectionString = ConnectionString };
            builder.Add("Initial Catalog", "master");
            return new SqlConnection(builder.ConnectionString);
        }
    }
}
