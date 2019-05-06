USE [master]
GO

/****** Object:  Login [NT AUTHORITY\Network Service]    Script Date: 06/05/2019 11:09:56 ******/
CREATE LOGIN [NT AUTHORITY\Network Service] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT AUTHORITY\Network Service]
GO

ALTER SERVER ROLE [securityadmin] ADD MEMBER [NT AUTHORITY\Network Service]
GO

ALTER SERVER ROLE [serveradmin] ADD MEMBER [NT AUTHORITY\Network Service]
GO

ALTER SERVER ROLE [setupadmin] ADD MEMBER [NT AUTHORITY\Network Service]
GO

ALTER SERVER ROLE [processadmin] ADD MEMBER [NT AUTHORITY\Network Service]
GO

ALTER SERVER ROLE [diskadmin] ADD MEMBER [NT AUTHORITY\Network Service]
GO

ALTER SERVER ROLE [dbcreator] ADD MEMBER [NT AUTHORITY\Network Service]
GO

ALTER SERVER ROLE [bulkadmin] ADD MEMBER [NT AUTHORITY\Network Service]
GO


