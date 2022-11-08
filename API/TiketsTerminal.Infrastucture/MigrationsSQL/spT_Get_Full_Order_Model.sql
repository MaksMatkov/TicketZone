IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'fbd'
    AND SPECIFIC_NAME = N'Get_Full_Order_Model'
)
DROP PROCEDURE fbd.Get_Full_Order_Model
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE fbd.Get_Full_Order_Model
AS
    SELECT 
		tko.PK_Ticket_Order as id,
		tko.FK_User as userId,
		tko.FK_Film_Viewing_Time as filmViewingTimeId,
		f.Name as filmName,
		r.Number as roomNumber,
		u.Email as userEmail,
		tko.Creation_Date as creationDate,
		tko.Status as status
	FROM fbd.T_Ticket_Order tko
			JOIN fbd.T_User u on tko.FK_User = u.PK_User
			JOIN fbd.T_Film_Viewing_Time fvt  on tko.FK_Film_Viewing_Time = fvt.PK_Film_Viewing_Time
			JOIN fbd.T_Film f on fvt.FK_Film = f.PK_Film
			JOIN fbd.T_Room r on fvt.FK_Room = r.PK_Room
GO
