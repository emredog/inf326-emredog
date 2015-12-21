-- Create user for SQL Authentication
CREATE LOGIN myuser WITH PASSWORD = '123qweasd'
,DEFAULT_DATABASE = DamacanaWebAPIContext
GO
-- Add User to first database
USE DamacanaWebAPIContext;
CREATE USER myuser FOR LOGIN myuser;
EXEC sp_addrolemember 'db_datareader', 'myuser'
EXEC sp_addrolemember 'db_datawriter', 'myuser'