USE master;

DROP DATABASE WoozyTune;
CREATE DATABASE WoozyTune;
USE WoozyTune;

DROP TABLE UsersData;
DROP TABLE Users;

CREATE TABLE UsersData(
[UserId] int IDENTITY(1, 1) PRIMARY KEY,
[Name] nvarchar(max) NULL,
[Surname] nvarchar(max) NULL,

[Gender] nvarchar(max) NOT NULL,
[Age] int NOT NULL,
[Username] nvarchar(max) NOT NULL,

[Country] nvarchar(max) NULL,
[City] nvarchar(max) NULL,
[BackgroundImagePath] varbinary(max) NULL,
[ImagePath] varbinary(max) NULL);


CREATE TABLE Users(
[UserId] int IDENTITY(1, 1) PRIMARY KEY FOREIGN KEY REFERENCES UsersData(UserId),
[Login] nvarchar(max),
[Password] int);

SELECT * FROM Users
SELECT * FROM UsersData


DROP TABLE Tracks;
CREATE TABLE Tracks(
[TrackId] int IDENTITY(1, 1) PRIMARY KEY,
[PlaylistId] int FOREIGN KEY REFERENCES Playlists(PlaylistId),
[UserId] int FOREIGN KEY REFERENCES UsersData(UserId),
[Artist] nvarchar(max),
[Title] nvarchar(max),
[Path] nvarchar(max),
[ImagePath] nvarchar(max),
[Genre] nvarchar(max));

DROP TABLE Playlists
CREATE TABLE Playlists(
[PlaylistId] int IDENTITY(0, 1) PRIMARY KEY,
[Artist] nvarchar(max) NULL,
[Title] nvarchar(max) NULL);
INSERT INTO Playlists VALUES(NULL, NULL);

CREATE TABLE UsersHistory(
HistoryId int IDENTITY(1, 1) PRIMARY KEY,
UserId int REFERENCES UsersData(UserId),
TrackId int REFERENCES Tracks(TrackId));

CREATE TABLE Likes(
LikeId int IDENTITY(1, 1) PRIMARY KEY,
UserId int REFERENCES UsersData(UserId),
TrackId int REFERENCES Tracks(TrackId));

CREATE TABLE Followers(
Id int IDENTITY(1, 1) PRIMARY KEY,
UserId int REFERENCES UsersData(UserId),
FollowerId int REFERENCES UsersData(UserId));