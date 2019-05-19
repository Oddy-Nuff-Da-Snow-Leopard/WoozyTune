USE master;
GO

DROP DATABASE WoozyTune;
CREATE DATABASE WoozyTune;
USE WoozyTune;
GO

CREATE TABLE UsersData(
[UserId] int IDENTITY(1, 1) CONSTRAINT PK_UsersData_UserId PRIMARY KEY,
[Name] nvarchar(max) NULL,
[Surname] nvarchar(max) NULL,
[Gender] nvarchar(max) NOT NULL,
[Age] tinyint NOT NULL,
[Username] nvarchar(max) NOT NULL,
[Photo] image NULL);

DROP TABLE Users
CREATE TABLE Users(
[UserId] int IDENTITY(1, 1) CONSTRAINT PK_Users_UserId PRIMARY KEY CONSTRAINT FK_Users_UserId FOREIGN KEY REFERENCES UsersData(UserID),
[Username] nvarchar(max),
[Password] int);


CREATE TABLE Music(
[MusicId] int CONSTRAINT PK_Music_TrackId PRIMARY KEY,
[UserId] int CONSTRAINT FK_Music_UserId FOREIGN KEY REFERENCES UsersData(UserID),
[Path] nvarchar(max),
[Image] image);


CREATE TABLE UsersHistory(
HistoryId int PRIMARY KEY,
UserId int CONSTRAINT FK_UsersHistory_UserId FOREIGN KEY REFERENCES UsersData(UserID),
MusicId int CONSTRAINT FK_UsersHistory_MusicId FOREIGN KEY REFERENCES Music(MusicID));


INSERT INTO UsersData VALUES
('Maksim', 'Alekseev', 'male', 19, NULL);

INSERT INTO Users VALUES
('admin', 1);

GO
DROP PROCEDURE GetUser;

GO
CREATE PROCEDURE GetUser @l nvarchar(max), @p int, @result int output AS
BEGIN
	SELECT UserId FROM Users WHERE [Login] = @l AND [Password] = @p;
	IF @@ROWCOUNT = 1
		SET @result = 1;
	ELSE SET @result = 0;
END