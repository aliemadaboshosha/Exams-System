USE Examination_System_DataBase;
GO

-- Stored Procedure to select a Course by ID
CREATE PROCEDURE GetCourseById
    @course_id INT
AS
BEGIN
    SELECT * FROM Course WHERE ID = @course_id;
END;
GO

-- Stored Procedure to insert a new Course
CREATE PROCEDURE InsertCourse
    @course_name NVARCHAR(20)
AS
BEGIN
    INSERT INTO Course (Name) VALUES (@course_name);
END;
GO

-- Stored Procedure to update a Course
CREATE PROCEDURE UpdateCourse
    @course_id INT,
    @new_course_name NVARCHAR(20)
AS
BEGIN
    UPDATE Course SET Name = @new_course_name WHERE ID = @course_id;
END;
GO

-- Stored Procedure to delete a Course
CREATE PROCEDURE DeleteCourseByID
    @course_id INT
AS
BEGIN
    DELETE FROM Course WHERE ID = @course_id;
END;
GO

-- Stored Procedure to select a Topic by ID
CREATE PROCEDURE GetTopicById
    @topic_id INT
AS
BEGIN
    SELECT * FROM Topic WHERE ID = @topic_id;
END;
GO

-- Stored Procedure to insert a new Topic
CREATE PROCEDURE InsertTopic
    @topic_name NVARCHAR(20),
    @course_id INT
AS
BEGIN
    INSERT INTO Topic (Name, course_ID) VALUES (@topic_name, @course_id);
END;
GO

-- Stored Procedure to update a Topic
alter PROCEDURE UpdateTopic
    @topic_id INT,
    @new_topic_name NVARCHAR(20),
    @new_course_id INT
AS
BEGIN
    UPDATE Topic
	SET Name = @new_topic_name
	WHERE ID = @topic_id and course_ID = @new_course_id
END;
GO

-- Stored Procedure to delete a Topic
CREATE PROCEDURE DeleteTopic
    @topic_id INT
AS
BEGIN
    DELETE FROM Topic WHERE ID = @topic_id;
END;
GO


CREATE PROCEDURE getCourses
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT * FROM course;
END;



CREATE PROCEDURE getTopics
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT * FROM Topic;
END;