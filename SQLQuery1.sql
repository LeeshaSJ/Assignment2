CREATE PROC Sp_Login
@user_id  NVARCHAR (450),
@Password NVARCHAR (150),
@Isvalid BIT OUT
AS
BEGIN
SET @Isvalid = (SELECT COUNT(1) FROM tbl_login WHERE Id = @user_id AND Password=@Password)
end