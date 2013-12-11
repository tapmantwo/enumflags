enumflags
=========

[Flags] Enums should be treated as integers in ServiceStack Ormlite, but are being treated as strings.

My understanding is that the if enum is declared with a 'Flags' attribute, when entities that have properties of that enum type, they are treated as integers.  However, they are being treated as strings.

This is an example project that demonstrates this - which outputs a table with a string field for the 'Flags' field, and when written to the database the values are strings.

I have scanned through the code in GitHub, it it does seem that in the OrmLiteDialectProviderBase, it just does a simple IsEnum check and if so, determines the DbType to be a string.

In the ServiceStack.Text serialisers, it has more logic to determine whether the enum has the 'Flags' attribute.  I suspect this logic needs to be replicated in the OrmLite project.
