use Examination_System_DataBase

-- Create Procedure for Inserting a Question
CREATE PROCEDURE InsertQuestion
    @Question_Body NVARCHAR(200),
    @Question_Type BIT,
    @Question_Answer TINYINT,
    @Topic_ID INT,
    @Course_ID INT
AS
BEGIN
    INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, Course_ID)
    VALUES (@Question_Body, @Question_Type, @Question_Answer, @Topic_ID, @Course_ID);
END;



-- Create Procedure for Inserting an Exam
CREATE PROCEDURE InsertExam
    @Date DATETIME,
    @Duration DECIMAL,
    @Course_ID INT
AS
BEGIN
    INSERT INTO Exam (Date, Duration, Course_ID)
    VALUES (@Date, @Duration, @Course_ID);
END



-- Create Procedure for Updating a Question
CREATE PROCEDURE UpdateQuestion
    @Question_ID INT,
    @Question_Body NVARCHAR(200),
    @Question_Type BIT,
    @Question_Answer TINYINT,
    @Topic_ID INT,
    @Course_ID INT
AS
BEGIN
    UPDATE Question
    SET Question_Body = @Question_Body,
        Question_Type = @Question_Type,
        Question_Answer = @Question_Answer,
        Topic_ID = @Topic_ID,
        Course_ID = @Course_ID
    WHERE ID = @Question_ID;
END;


-- Create Procedure for Updating an Exam
CREATE PROCEDURE UpdateExam
    @Exam_ID INT,
    @Date DATETIME,
    @Duration DECIMAL,
    @Course_ID INT
AS
BEGIN
    UPDATE Exam
    SET Date = @Date,
        Duration = @Duration,
        Course_ID = @Course_ID
    WHERE ID = @Exam_ID;
END;
