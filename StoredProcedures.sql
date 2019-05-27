GO
DROP PROCEDURE FindUser;
DROP PROCEDURE CreateUser;
DROP PROCEDURE UploadTrack;
DROP PROCEDURE GetUsername;
DROP PROCEDURE UploadPlaylist;
DROP PROCEDURE AddHistory;

GO
CREATE PROCEDURE FindUser @login nvarchar(max), @password int, @result int output AS
BEGIN
	SELECT UserId FROM Users WHERE [Login] = @login AND [Password] = @password;
	IF @@ROWCOUNT = 1
		SET @result = (SELECT UserId FROM Users WHERE [Login] = @login AND [Password] = @password);
	ELSE SET @result = 0;
END
GO

CREATE PROCEDURE CreateUser @login nvarchar(max), @password int, @age tinyint,
@gender nvarchar(max), @username nvarchar(max), @result int output AS 
BEGIN
	IF (NOT EXISTS(SELECT * FROM Users WHERE [Login] = @login))
	BEGIN
		INSERT INTO UsersData VALUES(@gender, @age, @username);
		INSERT INTO Users VALUES(@login, @password);
		SET @result = SCOPE_IDENTITY();
	END
	ELSE SET @result = 0;
END
GO

CREATE PROCEDURE UploadTrack @playlistId int, @userId int, @artist nvarchar(max),
@title nvarchar(max), @path nvarchar(max), @imagePath nvarchar(max),
@genre nvarchar(max) AS
BEGIN
	INSERT INTO Tracks VALUES(@playlistId, @userId, @artist, @title, @path, @imagePath, @genre);
END
GO


CREATE PROCEDURE UploadPlaylist @artist nvarchar(max), @title nvarchar(max),
@imagePath nvarchar(max), @type nvarchar(max), @genre nvarchar(max), @result int output AS
BEGIN
	INSERT INTO Playlists VALUES (@artist, @title, @imagePath, @type, @genre);
	SET @result = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE GetUsername @userId int, @result nvarchar(max) output AS
BEGIN
	SET @result = (SELECT Username FROM UsersData WHERE [UserId] = @userId);
END
GO

CREATE PROCEDURE AddHistory @userId int, @trackId int AS
BEGIN
	INSERT INTO UsersHistory VALUES(@userId, @trackId);
END
GO

CREATE PROCEDURE AddFollow @followerId int, @userId int AS
BEGIN
	INSERT INTO Followers VALUES(@followerId, @userId);
END
GO

DROP PROC DropFollow
GO
CREATE PROCEDURE DropFollow @followerId int, @userId int AS
BEGIN
	DELETE FROM Followers WHERE [FollowerId] = @followerId AND [UserId] = @userId;
	DBCC CHECKIDENT('[Followers]', RESEED, 0);
END
GO



CREATE PROCEDURE CheckForFollow @followerId int, @userId int, @result int output AS
BEGIN
	SELECT * FROM Followers WHERE [FollowerId] = @followerId AND [UserId] = @userId;
	SET @result = @@ROWCOUNT;
END

SELECT * FROM Followers
