USE master;

DROP DATABASE WoozyTune;
CREATE DATABASE WoozyTune;
USE WoozyTune;

DROP TABLE UsersDate;
DROP TABLE Users;

CREATE TABLE UsersData(
[UserId] int IDENTITY(1, 1) PRIMARY KEY,
[Name] nvarchar(max) NULL,
[Surname] nvarchar(max) NULL,

[Gender] nvarchar(max) NOT NULL,
[Age] tinyint NOT NULL,
[Username] nvarchar(max) NOT NULL,

[Country] nvarchar(max) NULL,
[City] nvarchar(max) NULL,
[BackgroundImage] varbinary(max) NULL,
[Image] varbinary(max) NULL);


CREATE TABLE Users(
[UserId] int IDENTITY(1, 1) PRIMARY KEY FOREIGN KEY REFERENCES UsersData(UserId),
[Login] nvarchar(max),
[Password] int);

DROP TABLE Tracks;
CREATE TABLE Tracks(
[TrackId] int IDENTITY(1, 1) PRIMARY KEY,
[UserId] int FOREIGN KEY REFERENCES UsersData(UserID),
[Path] nvarchar(max),
[Image] image NULL,
[Genre] nvarchar(max));

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