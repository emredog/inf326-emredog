-- Create user for SQL Authentication
CREATE LOGIN myuser2 WITH PASSWORD = '123qweasd'
,DEFAULT_DATABASE = DamacanaWebAPIContext
GO
-- Add User to first database
USE DamacanaWebAPIContext;
CREATE USER myuser2 FOR LOGIN myuser2;
exec sp_addrolemember 'db_owner', 'myuser2'
EXEC sp_addrolemember 'db_datareader', 'myuser2'
EXEC sp_addrolemember 'db_datawriter', 'myuser2'