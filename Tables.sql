USE master;

DROP DATABASE WoozyTune;
CREATE DATABASE WoozyTune;
USE WoozyTune;

DROP TABLE UsersData;
DROP TABLE Users;
DROP TABLE PlayLists;
DROP TABLE Tracks;
DROP TABLE UsersHistory;
DROP TABLE Followers;

SELECT * FROM UsersData;
SELECT * FROM Users;
SELECT * FROM Tracks;
SELECT * FROM PlayLists;
SELECT * FROM UsersHistory;
SELECT * FROM Followers;

CREATE TABLE UsersData(
[UserId] int IDENTITY(1, 1) PRIMARY KEY,
[Gender] nvarchar(max) NOT NULL,
[Age] int NOT NULL,
[Username] nvarchar(max) NOT NULL
);

CREATE TABLE Users(
[UserId] int IDENTITY(1, 1) PRIMARY KEY FOREIGN KEY REFERENCES UsersData(UserId),
[Login] nvarchar(max),
[Password] int);

CREATE TABLE Tracks(
[TrackId] int IDENTITY(1, 1) PRIMARY KEY,
[PlaylistId] int FOREIGN KEY REFERENCES Playlists(PlaylistId),
[UserId] int FOREIGN KEY REFERENCES UsersData(UserId),
[Artist] nvarchar(max),
[Title] nvarchar(max),
[TrackPath] nvarchar(max),
[ImagePath] nvarchar(max),
[Genre] nvarchar(max));

CREATE TABLE Playlists(
[PlaylistId] int IDENTITY(0, 1) PRIMARY KEY,
[Artist] nvarchar(max) NULL,
[Title] nvarchar(max) NULL,
[ImagePath] nvarchar(max) NULL,
[Type] nvarchar(max) NULL,
[Genre] nvarchar(max) NULL);
INSERT INTO Playlists VALUES(NULL, NULL, NULL, NULL, NULL);

CREATE TABLE UsersHistory(
HistoryId int IDENTITY(1, 1) PRIMARY KEY,
UserId int REFERENCES UsersData(UserId),
TrackId int REFERENCES Tracks(TrackId));

CREATE TABLE Followers(
Id int IDENTITY(1, 1) PRIMARY KEY,
UserId int REFERENCES UsersData(UserId),
FollowerId int REFERENCES UsersData(UserId));
