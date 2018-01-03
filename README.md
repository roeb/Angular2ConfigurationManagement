## Reusable Angular Services: Configuration Management

This sample describes how you can implement a configuration layer with angular. The configuration data can be loaded from sql server or JSON files. Its using the local storage.

### SQL Server support
If you like to use the SQL Server support, then you must execute the following SQL Script on your local SQL Server.

To access the SQL Server configurations, you must start also the .NET Core WebAPI Project.

```sql
CREATE DATABASE ConfigSample;

USE ConfigSample;


CREATE TABLE AppSettings (
	AppSettingsId INT NOT NULL IDENTITY(1,1) PRIMARY KEY NONCLUSTERED,
	DefaultPrice money NOT NULL DEFAULT(1),
	DefaultUrl NVARCHAR(100) NOT NULL,
	IsFromLocalStorage BIT NOT NULL DEFAULT(0)
);

INSERT INTO AppSettings (DefaultPrice, DefaultUrl) VALUES (42, 'http://google.de');
``` 