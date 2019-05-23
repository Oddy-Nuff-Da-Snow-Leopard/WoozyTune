GO
DROP PROCEDURE FindUser;
DROP PROCEDURE CreateUser;

GO
CREATE PROCEDURE FindUser @l nvarchar(max), @p int, @result int output AS
BEGIN
	SELECT UserId FROM Users WHERE [Login] = @l AND [Password] = @p;
	IF @@ROWCOUNT = 1
		SET @result = 1;
	ELSE SET @result = 0;
END



GO
CREATE PROCEDURE CreateUser @l nvarchar(max), @p int, @a tinyint,
@g nvarchar(max), @u nvarchar(max), @result int output AS 
BEGIN
	IF (NOT EXISTS(SELECT * FROM Users WHERE [Login] = @l))
	BEGIN
		INSERT INTO UsersData VALUES(NULL, NULL, @g, @a, @u, NULL, NULL, NULL, NULL);
		INSERT INTO Users VALUES(@l, @p);
		SET @result = 1;
	END
	ELSE SET @result = 0;
END

SELECT * FROM Users
SELECT * FROM UsersData