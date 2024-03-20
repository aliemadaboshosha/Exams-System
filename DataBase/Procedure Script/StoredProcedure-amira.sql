use Examination_System_DataBase

--------------------get Branch By ID-----------------------
Create PROCEDURE getBranchByID
    @id INT
AS
BEGIN
    SELECT *
    FROM Branch
    WHERE ID = @id;
END;

Create PROCEDURE getBranches
AS
BEGIN
    SELECT *
    FROM Branch
END;


CREATE PROCEDURE insertBranch
    @name NVARCHAR(30),
    @Building_Number int,
    @Street NVARCHAR(20),
    @City NVARCHAR(20)
AS
BEGIN
    INSERT INTO Branch (Name, Building_Number, Street, City)
    VALUES (@name, @Building_Number, @Street, @City);
END;

----insertBranch 'PD' ,2,'flower','Mansoura'----------

create procedure updateBranchByID 
@id int ,@name varchar(30)
as
begin 
update branch set Name = @name 
where ID = @id
end;

CREATE PROCEDURE update_BranchByID
    @id INT,
    @name VARCHAR(30),
    @Building_Number int,
    @Street VARCHAR(20),
    @City VARCHAR(20)
AS
BEGIN
    UPDATE Branch
    SET Name = @name,
        Building_Number = @Building_Number,
        Street = @Street,
        City = @City
    WHERE ID = @id;
END;

--------------- execute update_BranchByID  2,'Program',4,'here','Alex'------------


Alter PROCEDURE DeleteBranchByID
    @id INT
AS
BEGIN
    DELETE FROM Branch
    WHERE ID = @id
END;

-------- execute DeleteBranchByID 3 -----------


------ Track -----------

CREATE PROCEDURE SelectTrackByID
    @id INT
AS
BEGIN
    SELECT *
    FROM Track
    WHERE ID = @id
END;

----- SelectTrackByID 1 ------

CREATE PROCEDURE InsertTrack
    @name VARCHAR(20)
AS
BEGIN
    INSERT INTO Track ( Name)
    VALUES (@name);
END;

-- execute InsertTrack 'css' ------

CREATE PROCEDURE UpdateTrackByID
    @id INT,
    @Name VARCHAR(20)
AS
BEGIN
    UPDATE Track
    SET Name = @Name
    WHERE ID = @id;
END;


---- UpdateTrackByID 1,'bootstrap'----

CREATE PROCEDURE DeleteTrackByID
    @id INT
AS
BEGIN
    DELETE FROM Track
    WHERE ID = @id;
END;

---------- DeleteTrackByID 2 --------------
CREATE PROCEDURE DeleteTrack
AS
BEGIN
    DELETE FROM Track
END;


----------  exec DeleteTrack -------





























