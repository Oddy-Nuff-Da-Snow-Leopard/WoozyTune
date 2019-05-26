USE master;

DROP DATABASE WoozyTune;
CREATE DATABASE WoozyTune;
USE WoozyTune;

DROP TABLE UsersData;
DROP TABLE Users;

CREATE TABLE UsersData(
[UserId] int IDENTITY(1, 1) PRIMARY KEY,
[Gender] nvarchar(max) NOT NULL,
[Age] int NOT NULL,
[Username] nvarchar(max) NOT NULL
);

SELECT * FROM UsersData

CREATE TABLE Users(
[UserId] int IDENTITY(1, 1) PRIMARY KEY FOREIGN KEY REFERENCES UsersData(UserId),
[Login] nvarchar(max),
[Password] int);

DROP TABLE Tracks;
CREATE TABLE Tracks(
[TrackId] int IDENTITY(1, 1) PRIMARY KEY,
[PlaylistId] int FOREIGN KEY REFERENCES Playlists(PlaylistId),
[UserId] int FOREIGN KEY REFERENCES UsersData(UserId),
[Artist] nvarchar(max),
[Title] nvarchar(max),
[TrackPath] nvarchar(max),
[ImagePath] nvarchar(max),
[Genre] nvarchar(max));

DROP TABLE Tracks
SELECT * FROM Tracks

DROP TABLE Playlists
CREATE TABLE Playlists(
[PlaylistId] int IDENTITY(0, 1) PRIMARY KEY,
[Artist] nvarchar(max) NULL,
[Title] nvarchar(max) NULL,
[ImagePath] nvarchar(max) NULL,
[Type] nvarchar(max) NULL,
[Genre] nvarchar(max) NULL);
INSERT INTO Playlists VALUES(NULL, NULL, NULL, NULL, NULL);

SELECT * FROM Playlists


DROP TABLE UsersHistory
CREATE TABLE UsersHistory(
HistoryId int IDENTITY(1, 1) PRIMARY KEY,
UserId int REFERENCES UsersData(UserId),
TrackId int REFERENCES Tracks(TrackId));

SELECT * FROM UsersHistory

CREATE TABLE Followers(
Id int IDENTITY(1, 1) PRIMARY KEY,
UserId int REFERENCES UsersData(UserId),
FollowerId int REFERENCES UsersData(UserId));