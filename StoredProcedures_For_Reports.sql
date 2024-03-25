use Examination_System_DataBase

 -- Query to retrieve student information based on department number
CREATE PROCEDURE GetStudentsByTrack
    @TrackNo INT
AS
BEGIN
   
    SELECT ID, FName,LName, Gender,Email,Street,City,Date_of_birth,Track_ID
    FROM Student
    WHERE Track_ID = @TrackNo;
END
EXEC GetStudentsByTrack @TrackNo = 13;

-- Query to retrieve total grade for the specified student ID
CREATE PROCEDURE GetTotalStudentGrade
    @StudentID INT
AS
BEGIN
    
    SELECT SUM(Grade) AS TotalGrade
    FROM Student_Exam
    WHERE Student_ID = @StudentID;
END

EXEC GetTotalStudentGrade @StudentID = 4;

--  instructor, courses, students
CREATE PROCEDURE GetInstructorCourseReport
    @InstructorID INT
AS
BEGIN
    SELECT 
        C.Name,
        COUNT(DISTINCT S.ID) AS NumberOfStudents
    FROM 
        Instructor_Track_Course ITC
    INNER JOIN 
        Course C ON ITC.Course_ID = C.ID
    INNER JOIN 
        Student S ON S.Track_ID = ITC.Track_ID
    WHERE 
        ITC.Instructor_ID = @InstructorID
    GROUP BY 
        C.Name;
END

EXEC GetInstructorCourseReport @InstructorID = 4;

-- from course ID  return its topics  
CREATE PROCEDURE GetCourseTopics
    @CourseID INT
AS
BEGIN
    SELECT 
        Name
    FROM 
        Topic
    WHERE 
        course_ID = @CourseID;
END

EXEC GetCourseTopics @CourseID = 1;

--	procedure that takes exam number and returns the Questions in it and chocies 
CREATE PROCEDURE GetExamQuestionsWithAllChoices
    @ExamNumber INT
AS
BEGIN
    SELECT 
      
        q.Question_Body,
        qa.Number_OF_Choice,
        qa.Body_OF_Choice
    FROM 
        exam_question eq
    INNER JOIN 
        question q ON eq.question_id = q.ID
    LEFT JOIN 
        multi_choices_question_answers qa ON q.ID = qa.Question_ID
    WHERE 
        eq.exam_id = @ExamNumber;
END

EXEC GetExamQuestionsWithAllChoices @ExamNumber = 1;

-- exam questions with student answer
CREATE PROCEDURE GetExamQuestionsWithStudentAnswers
    @ExamNumber INT,
    @StudentID INT
AS
BEGIN
    SELECT 
     
        q.Question_Body,
        ans.Student_Answer
    FROM 
        question q
    INNER JOIN 
        student_exam_answers ans ON q.ID = ans.Question_ID
    WHERE 
        ans.Exam_ID = @ExamNumber
        AND ans.Student_ID = @StudentID;
END

EXEC GetExamQuestionsWithStudentAnswers @ExamNumber = 1, @StudentID = 4;

