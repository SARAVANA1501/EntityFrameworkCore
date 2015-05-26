// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.Data.Entity.SqlServer.Tests
{
    public class SqlServerDataStoreSourceTest
    {
        [Fact]
        public void Returns_appropriate_name()
        {
            Assert.Equal("SQL Server Data Store", new SqlServerDataStoreSource().Name);
        }

        [Fact]
        public void Is_configured_when_configuration_contains_associated_extension()
        {
            var optionsBuilder = new EntityOptionsBuilder();
            optionsBuilder.UseSqlServer("Database=Crunchie");

            Assert.True(new SqlServerDataStoreSource().IsConfigured(optionsBuilder.Options));
        }

        [Fact]
        public void Can_not_be_auto_configured()
        {
            var optionsBuilder = new EntityOptionsBuilder();

            var dataStoreSource = new SqlServerDataStoreSource();
            dataStoreSource.AutoConfigure(optionsBuilder);

            Assert.False(dataStoreSource.IsConfigured(optionsBuilder.Options));
        }

        [Fact]
        public void Is_not_configured_when_configuration_does_not_contain_associated_extension()
        {
            var optionsBuilder = new EntityOptionsBuilder();

            Assert.False(new SqlServerDataStoreSource().IsConfigured(optionsBuilder.Options));
        }
    }
}
