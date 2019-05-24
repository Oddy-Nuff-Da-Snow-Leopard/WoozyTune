GO
DROP PROCEDURE FindUser;
DROP PROCEDURE CreateUser;

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
		INSERT INTO UsersData VALUES(NULL, NULL, @gender, @age, @username, NULL, NULL, NULL, NULL);
		INSERT INTO Users VALUES(@login, @password);
		SET @result = (SELECT UserId FROM Users WHERE [Login] = @login AND [Password] = @password);
	END
	ELSE SET @result = 0;
END
GO

CREATE PROCEDURE UploadTrack @userId int, @artist nvarchar(max),
@title nvarchar(max), @path nvarchar(max), @imagePath nvarchar(max),
@genre nvarchar(max) AS
BEGIN
	INSERT INTO Tracks VALUES(0, @userId, @artist, @title, @path, @imagePath, @genre);
END