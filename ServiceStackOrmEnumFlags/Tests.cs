namespace ServiceStackOrmEnumFlags
{
    using System;
    using System.Data;

    using ServiceStack.OrmLite;

    using Xunit;

    public class Tests : IDisposable
    {
        private IDbConnection db;

        public Tests()
        {
            OrmLiteConfig.DialectProvider = SqliteDialect.Provider;
            db = "Data Source=test.sqlite;Version=3;Enlist=N;New=True;".ToDbConnection();
            db.Open();
            db.CreateTable<Entity>(true);
        }

        [Fact]
        public void EnumFlagIsNumeric()
        {
            db.Insert(new Entity { Id = 1, Flags = EntityFlags.FlagOne & EntityFlags.FlagTwo & EntityFlags.FlagThree });

            try
            {
                Assert.Equal(
                    (int)(EntityFlags.FlagOne & EntityFlags.FlagTwo & EntityFlags.FlagThree),
                    db.Scalar<int>("SELECT Flags FROM Entity WHERE Id = 1"));
            }
            catch (FormatException)
            {
                // Probably a string then
                var value = db.Scalar<string>("SELECT Flags FROM Entity WHERE Id = 1");
                throw new Exception(string.Format("Expected integer value but got string value {0}", value));
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
