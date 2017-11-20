IF NOT EXISTS (SELECT * FROM master.dbo.syslogins WHERE loginname = N'TicketDesk')
CREATE LOGIN [TicketDesk] WITH PASSWORD = 'p@ssw0rd'
GO
CREATE USER [TicketDesk] FOR LOGIN [TicketDesk]
GO
