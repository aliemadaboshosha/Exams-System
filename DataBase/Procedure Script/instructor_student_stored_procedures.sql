use Examination_System_DataBase

--CRUD operations for student
--create student
CREATE PROCEDURE sp_CreateStudent
    @FirstName NVARCHAR(20),
    @LastName NVARCHAR(20),
	@Gender nchar(1),
	@Email  NVARCHAR(50),
	@Password  NVARCHAR(50),
	@Street  NVARCHAR(50),
	@City  NVARCHAR(50),
	@DateOfBirth date ,
	@BranchID INT ,
	@TrackID INT

AS
BEGIN
    INSERT INTO Student (FName,LName,Gender,Email,Password,Street,City,Date_of_birth,Branch_ID,Track_ID)
    VALUES (@FirstName, @LastName, @Gender, @Email, @Password,
			@Street, @City, @DateOfBirth,@BranchID,@TrackID);
END;

-- read

CREATE PROCEDURE sp_GetStudentById
    @StudentID INT
AS
BEGIN
    SELECT * FROM Student WHERE ID = @StudentID;
END;
-----get all students
create procedure sp_GetStudents
As
begin
	SELECT * FROM Student ;
End


--update
CREATE PROCEDURE sp_UpdateStudent
    @StudentID INT,
    @FirstName NVARCHAR(20),
    @LastName NVARCHAR(20),
	@Gender nchar(1),
	@Email  NVARCHAR(50),
	@Password  NVARCHAR(50),
	@Street  NVARCHAR(50),
	@City  NVARCHAR(50),
	@DateOfBirth date ,
	@BranchID INT ,
	@TrackID INT
AS
BEGIN
    UPDATE Student
    SET FName = @FirstName,
        LName = @LastName,
        Gender = @Gender,
        Email = @Email,
		Password=@Password,
		Street=@Street,
		City=@City,
		Date_of_birth=@DateOfBirth,
		Branch_ID=@BranchID,
		Track_ID=@TrackID
    WHERE ID = @StudentID;
END;

--delete
CREATE PROCEDURE sp_DeleteStudent
    @StudentID INT
AS
BEGIN
    DELETE FROM Student WHERE ID = @StudentID;
END;

--#######################################################################################

--CRUD operations for instructor

--create instructor
CREATE PROCEDURE sp_CreateInstructor
   @FirstName NVARCHAR(20),
    @LastName NVARCHAR(20),
	@Gender nchar(1),
	@Email  NVARCHAR(50),
	@Password  NVARCHAR(50),
	@Street  NVARCHAR(50),
	@City  NVARCHAR(50),
	@DateOfBirth date ,
	@Salary DECIMAL(18,0),
	@BranchID INT 
	
AS
BEGIN
    INSERT INTO Instructor (FName,LName,Gender,Email,Password,Street,City,Date_of_birth,Salary,Branch_ID)
    VALUES (@FirstName, @LastName, @Gender, @Email, @Password,
			@Street, @City, @DateOfBirth,@Salary,@BranchID);
END;

--read
CREATE PROCEDURE sp_GetInstructorById
    @InstructorID INT
AS
BEGIN
    SELECT * FROM Instructor WHERE ID = @InstructorID;
END;

--update
CREATE PROCEDURE sp_UpdateInstructor
    @InstructorID INT,
    @FirstName NVARCHAR(20),
    @LastName NVARCHAR(20),
	@Gender nchar(1),
	@Email  NVARCHAR(50),
	@Password  NVARCHAR(50),
	@Street  NVARCHAR(50),
	@City  NVARCHAR(50),
	@DateOfBirth date ,
	@Salary DECIMAL(18,0),
	@BranchID INT 
	
AS
BEGIN
    UPDATE Instructor
    SET FName = @FirstName,
        LName = @LastName,
        Gender = @Gender,
        Email = @Email,
		Password=@Password,
		Street=@Street,
		City=@City,
		Date_of_birth=@DateOfBirth,
		Salary=@Salary,
		Branch_ID=@BranchID
		
    WHERE ID = @InstructorID;
END;


--delete
CREATE PROCEDURE sp_DeleteInstructor
    @InstructorID INT
AS
BEGIN
    DELETE FROM Instructor WHERE ID = @InstructorID;
END;


CREATE PROCEDURE GetIstructors
AS
BEGIN
    SELECT * FROM Instructor;
END;