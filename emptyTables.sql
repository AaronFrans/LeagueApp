delete from dbo.Transfers;
delete from dbo.Spelers;
delete from dbo.Teams;
DBCC CHECKIDENT ('[Spelers]', RESEED, 0);
GO