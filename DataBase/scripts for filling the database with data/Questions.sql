select * from topic
 select * from Question



select * from course


delete from topic where topic.course_ID=1 or topic.course_ID=2
-- Insert topics related to C#
DECLARE @LastTopicId_CSharp INT;
SELECT @LastTopicId_CSharp = ISNULL(MAX(ID), 0) FROM Topic WHERE Course_ID = 1;

INSERT INTO Topic (ID, Name, Course_ID)
VALUES (@LastTopicId_CSharp + 1, 'Introduction to C#', 1),
       (@LastTopicId_CSharp + 2, 'Data Types and Variables in C#', 1),
       (@LastTopicId_CSharp + 3, 'Control Structures in C#', 1),
       (@LastTopicId_CSharp + 4, 'Object-Oriented Programming in C#', 1),
       (@LastTopicId_CSharp + 5, 'Exception Handling in C#', 1),
       (@LastTopicId_CSharp + 6, 'File Handling in C#', 1),
       (@LastTopicId_CSharp + 7, 'Collections in C#', 1),
       (@LastTopicId_CSharp + 8, 'LINQ (Language Integrated Query)', 1);

-- Insert topics related to C++
DECLARE @LastTopicId_CPlusPlus INT;
SELECT @LastTopicId_CPlusPlus = ISNULL(MAX(ID), 0) FROM Topic WHERE Course_ID = 7;

INSERT INTO Topic (ID, Name, Course_ID)
VALUES (@LastTopicId_CPlusPlus + 1, 'Introduction to C++', 7),
       (@LastTopicId_CPlusPlus + 2, 'Data Types and Variables in C++', 7),
       (@LastTopicId_CPlusPlus + 3, 'Control Structures in C++', 7),
       (@LastTopicId_CPlusPlus + 4, 'Object-Oriented Programming in C++', 7),
       (@LastTopicId_CPlusPlus + 5, 'Exception Handling in C++', 7),
       (@LastTopicId_CPlusPlus + 6, 'File Handling in C++', 7),
       (@LastTopicId_CPlusPlus + 7, 'STL (Standard Template Library) in C++', 7),
       (@LastTopicId_CPlusPlus + 8, 'Concurrency in C++', 7);

-- Insert topics related to Database with SQL Server
DECLARE @LastTopicId_SQLServer INT;
SELECT @LastTopicId_SQLServer = ISNULL(MAX(ID), 0) FROM Topic WHERE Course_ID = 2;

INSERT INTO Topic (ID, Name, Course_ID)
VALUES (@LastTopicId_SQLServer + 1, 'Introduction to Databases', 2),
       (@LastTopicId_SQLServer + 2, 'Relational Database Management Systems', 2),
       (@LastTopicId_SQLServer + 3, 'SQL Basics', 2),
       (@LastTopicId_SQLServer + 4, 'Creating and Manipulating Tables', 2),
       (@LastTopicId_SQLServer + 5, 'Querying Data with SELECT Statement', 2),
       (@LastTopicId_SQLServer + 6, 'Filtering and Sorting Data', 2),
       (@LastTopicId_SQLServer + 7, 'Joins and Subqueries', 2),
       (@LastTopicId_SQLServer + 8, 'Indexes and Performance Tuning', 2);

-- Insert topics related to HTML
DECLARE @LastTopicId_HTML INT;
SELECT @LastTopicId_HTML = ISNULL(MAX(ID), 0) FROM Topic WHERE Course_ID = 8;

INSERT INTO Topic (ID, Name, Course_ID)
VALUES (@LastTopicId_HTML + 1, 'Introduction to HTML', 8),
       (@LastTopicId_HTML + 2, 'HTML Structure and Syntax', 8),
       (@LastTopicId_HTML + 3, 'HTML Elements and Attributes', 8),
       (@LastTopicId_HTML + 4, 'HTML Forms and Input Elements', 8),
       (@LastTopicId_HTML + 5, 'HTML Semantic Elements', 8),
       (@LastTopicId_HTML + 6, 'HTML Multimedia and Graphics', 8),
       (@LastTopicId_HTML + 7, 'HTML Tables and Lists', 8),
       (@LastTopicId_HTML + 8, 'HTML Links and Anchors', 8);

-- Insert topics related to JavaScript
DECLARE @LastTopicId_JavaScript INT;
SELECT @LastTopicId_JavaScript = ISNULL(MAX(ID), 0) FROM Topic WHERE Course_ID = 9;

INSERT INTO Topic (ID, Name, Course_ID)
VALUES (@LastTopicId_JavaScript + 1, 'Introduction to JavaScript', 9),
       (@LastTopicId_JavaScript + 2, 'JavaScript Syntax and Variables', 9),
       (@LastTopicId_JavaScript + 3, 'JavaScript Functions', 9),
       (@LastTopicId_JavaScript + 4, 'JavaScript Objects and Prototypes', 9),
       (@LastTopicId_JavaScript + 5, 'JavaScript DOM (Document Object Model)', 9),
       (@LastTopicId_JavaScript + 6, 'JavaScript Events and Event Handling', 9),
       (@LastTopicId_JavaScript + 7, 'JavaScript AJAX and Fetch API', 9),
       (@LastTopicId_JavaScript + 8, 'JavaScript ES6 Features', 9);


	   -- Insert True/False questions related to C#
DECLARE @TopicId_CSharp INT;
SELECT @TopicId_CSharp = ID FROM Topic WHERE Name = 'Introduction to C#';

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('C# is an object-oriented programming language.', 0, 1, @TopicId_CSharp, 1),
       ('C# is a markup language used for styling web pages.', 0, 0, @TopicId_CSharp, 1),
       ('In C#, int is a data type for storing floating-point numbers.', 0, 0, @TopicId_CSharp, 1),
       ('In C#, the main method serves as the entry point of a program.', 0, 1, @TopicId_CSharp, 1),
       ('C# supports exception handling to manage errors.', 0, 1, @TopicId_CSharp, 1);

-- Insert True/False questions related to C++
DECLARE @TopicId_CPlusPlus INT;
SELECT @TopicId_CPlusPlus = ID FROM Topic WHERE Name = 'Introduction to C++';

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('C++ is a programming language developed by Microsoft.', 0, 0, @TopicId_CPlusPlus, 7),
       ('In C++, a semicolon (;) is used to terminate statements.', 0, 1, @TopicId_CPlusPlus, 7),
       ('C++ is not an object-oriented programming language.', 0, 0, @TopicId_CPlusPlus, 7),
       ('In C++, the syntax for declaring a variable is var.', 0, 0, @TopicId_CPlusPlus, 7),
       ('C++ supports both procedural and object-oriented programming paradigms.', 0, 1, @TopicId_CPlusPlus, 7);

-- Insert True/False questions related to Database with SQL Server
DECLARE @TopicId_SQLServer INT;
SELECT @TopicId_SQLServer = ID FROM Topic WHERE Name = 'Introduction to Databases';

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('SQL Server is a relational database management system developed by Microsoft.', 0, 1, @TopicId_SQLServer, 2),
       ('In SQL Server, DDL stands for Data Definition Language.', 0, 1, @TopicId_SQLServer, 2),
       ('SQL Server does not support transactions.', 0, 0, @TopicId_SQLServer, 2),
       ('SQL Server does not allow users to create indexes to improve query performance.', 0, 0, @TopicId_SQLServer, 2),
       ('SQL Server supports the use of stored procedures for executing SQL code.', 0, 1, @TopicId_SQLServer, 2);
       
-- Insert True/False questions related to HTML
DECLARE @TopicId_HTML INT;
SELECT @TopicId_HTML = ID FROM Topic WHERE Name = 'Introduction to HTML';

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('HTML stands for Hypertext Markup Language.', 0, 1, @TopicId_HTML, 8),
       ('HTML is a programming language used for server-side scripting.', 0, 0, @TopicId_HTML, 8),
       ('HTML uses tags to structure content.', 0, 1, @TopicId_HTML, 8),
       ('In HTML, the <body> tag defines the main content of the document.', 0, 1, @TopicId_HTML, 8),
       ('HTML is primarily used for creating and structuring web pages.', 0, 1, @TopicId_HTML, 8);

-- Insert True/False questions related to JavaScript
DECLARE @TopicId_JavaScript INT;
SELECT @TopicId_JavaScript = ID FROM Topic WHERE Name = 'Introduction to JavaScript';

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('JavaScript is a client-side scripting language.', 0, 1, @TopicId_JavaScript, 9),
       ('JavaScript code is executed on the server.', 0, 0, @TopicId_JavaScript, 9),
       ('JavaScript can be used to dynamically manipulate HTML and CSS.', 0, 1, @TopicId_JavaScript, 9),
       ('In JavaScript, the document object represents the HTML document.', 0, 1, @TopicId_JavaScript, 9),
       ('JavaScript is used for adding interactivity to web pages.', 0, 1, @TopicId_JavaScript, 9);


-- Insert sample questions for Data Types and Variables in C#
DECLARE @TopicId_DataTypes INT;
SELECT @TopicId_DataTypes = ID FROM Topic WHERE Name = 'Data Types and Variables in C#' AND Course_ID = 1;

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('In C#, int is a data type for storing floating-point numbers.', 0, 0, @TopicId_DataTypes, 1),
       ('C# supports both primitive and reference types.', 0, 1, @TopicId_DataTypes, 1),
       ('String is a built-in data type in C#.', 0, 1, @TopicId_DataTypes, 1),
       ('Variables in C# must be explicitly declared with a data type.', 0, 1, @TopicId_DataTypes, 1),
       ('C# does not support type inference.', 0, 0, @TopicId_DataTypes, 1);

-- Insert sample questions for Control Structures in C#
DECLARE @TopicId_ControlStructures INT;
SELECT @TopicId_ControlStructures = ID FROM Topic WHERE Name = 'Control Structures in C#' AND Course_ID = 1;

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('In C#, if-else statements are used for conditional branching.', 0, 1, @TopicId_ControlStructures, 1),
       ('A loop in C# is used to repeat a block of code.', 0, 1, @TopicId_ControlStructures, 1),
       ('C# supports switch statements for multi-way branching.', 0, 1, @TopicId_ControlStructures, 1),
       ('The "for" loop in C# cannot iterate over collections.', 0, 0, @TopicId_ControlStructures, 1),
       ('In C#, "break" is used to exit a loop.', 0, 1, @TopicId_ControlStructures, 1);

-- Insert sample questions for Object-Oriented Programming in C#
DECLARE @TopicId_OOP INT;
SELECT @TopicId_OOP = ID FROM Topic WHERE Name = 'Object-Oriented Programming in C#' AND Course_ID = 1;

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('Inheritance allows a class to inherit properties and methods from another class.', 0, 1, @TopicId_OOP, 1),
       ('Encapsulation is the bundling of data with the methods that operate on that data.', 0, 1, @TopicId_OOP, 1),
       ('Polymorphism allows objects of different types to be treated as objects of a single type.', 0, 1, @TopicId_OOP, 1),
       ('In C#, classes can only inherit from one superclass.', 0, 0, @TopicId_OOP, 1),
       ('Abstraction is the process of hiding the implementation details and showing only the functionality.', 0, 1, @TopicId_OOP, 1);



	   -- Insert sample questions for Exception Handling in C#
DECLARE @TopicId_ExceptionHandling INT;
SELECT @TopicId_ExceptionHandling = ID FROM Topic WHERE Name = 'Exception Handling in C#' AND Course_ID = 1;

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('In C#, exceptions are used to handle runtime errors.', 0, 1, @TopicId_ExceptionHandling, 1),
       ('A try-catch block in C# is used to handle exceptions.', 0, 1, @TopicId_ExceptionHandling, 1),
       ('C# does not support throwing custom exceptions.', 0, 0, @TopicId_ExceptionHandling, 1),
('In C#, finally block is always executed, regardless of whether an exception is thrown or not.', 0, 1, @TopicId_ExceptionHandling, 1),
('It is recommended to catch all exceptions using a general catch block in C#.', 0, 0, @TopicId_ExceptionHandling, 1);

-- Insert sample questions for File Handling in C#
DECLARE @TopicId_FileHandling INT;
SELECT @TopicId_FileHandling = ID FROM Topic WHERE Name = 'File Handling in C#' AND Course_ID = 1;

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('In C#, FileStream class is used to read from and write to files.', 0, 1, @TopicId_FileHandling, 1),
('File.WriteAllText() method is used to read data from a file.', 0, 0, @TopicId_FileHandling, 1),
('C# does not support file manipulation operations.', 0, 0, @TopicId_FileHandling, 1),
('Using statement in C# ensures that the file is properly closed after its scope is exited.', 0, 1, @TopicId_FileHandling, 1),
('File.Exists() method checks if a file exists at the specified location.', 0, 1, @TopicId_FileHandling, 1);

-- Insert sample questions for Collections in C#
DECLARE @TopicId_Collections INT;
SELECT @TopicId_Collections = ID FROM Topic WHERE Name = 'Collections in C#' AND Course_ID = 1;

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('List<T> is a generic collection in C# that stores elements in a sequence.', 0, 1, @TopicId_Collections, 1),
('HashSet<T> in C# allows duplicate elements.', 0, 0, @TopicId_Collections, 1),
('C# does not provide built-in support for collections.', 0, 0, @TopicId_Collections, 1),
('Dictionary<TKey, TValue> in C# stores key-value pairs.', 0, 1, @TopicId_Collections, 1),
('Queue<T> in C# follows the Last-In-First-Out (LIFO) principle.', 0, 0, @TopicId_Collections, 1);

-- Insert sample questions for LINQ (Language Integrated Query)
DECLARE @TopicId_LINQ INT;
SELECT @TopicId_LINQ = ID FROM Topic WHERE Name = 'LINQ (Language Integrated Query)' AND Course_ID = 1;

INSERT INTO Question (Question_Body, Question_Type, Question_Answer, Topic_ID, course_ID)
VALUES ('LINQ allows querying data from different data sources using a unified syntax.', 0, 1, @TopicId_LINQ, 1),
('In C#, LINQ stands for Lightweight Interactive Query.', 0, 0, @TopicId_LINQ, 1),
('LINQ queries are always executed on the client side.', 0, 0, @TopicId_LINQ, 1),
('The result of a LINQ query is always a collection.', 0, 1, @TopicId_LINQ, 1),
('C# does not support LINQ to XML for querying XML documents.', 0, 0, @TopicId_LINQ, 1);