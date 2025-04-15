CREATE DATABASE SPADB;
GO

CREATE TABLE [dbo].[maitre]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[prenom] VARCHAR(50) NOT NULL,
	[nom] VARCHAR(50) NOT NULL
);
GO

CREATE TABLE [dbo].[chien]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[nom] VARCHAR(50) NOT NULL,
	[date_naissance] DATETIME2 NOT NULL,
	[maitre_id] INT,
	CONSTRAINT FK_maitre_chien_maitre_id FOREIGN KEY([maitre_id]) REFERENCES maitre(id)
);
GO