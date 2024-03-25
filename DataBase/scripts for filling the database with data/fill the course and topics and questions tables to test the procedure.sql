-- Inserting data into the Course table
INSERT INTO Course ( Name)
VALUES ( 'C#'),
       ( 'Database with SQL Server');

-- Insert topics related to C#
INSERT INTO Topic (ID, Name, Course_ID)
VALUES (1, 'Introduction to C#', (SELECT ID FROM Course WHERE Name = 'C#')),
       (2, 'Data Types and Variables in C#', (SELECT ID FROM Course WHERE Name = 'C#')),
       (3, 'Control Structures in C#', (SELECT ID FROM Course WHERE Name = 'C#')),
       (4, 'Object-Oriented Programming in C#', (SELECT ID FROM Course WHERE Name = 'C#')),
       (5, 'Exception Handling in C#', (SELECT ID FROM Course WHERE Name = 'C#')),
       (6, 'File Handling in C#', (SELECT ID FROM Course WHERE Name = 'C#')),
       (7, 'Collections in C#', (SELECT ID FROM Course WHERE Name = 'C#')),
       (8, 'LINQ (Language Integrated Query)', (SELECT ID FROM Course WHERE Name = 'C#'))

-- Insert topics related to Database with SQL Server
INSERT INTO Topic (ID, Name, Course_ID)
VALUES (1, 'Introduction to Databases', (SELECT ID FROM Course WHERE Name = 'Database with SQL Server')),
       (2, 'Relational Database Management Systems', (SELECT ID FROM Course WHERE Name = 'Database with SQL Server')),
       (3, 'SQL Basics', (SELECT ID FROM Course WHERE Name = 'Database with SQL Server')),
       (4, 'Creating and Manipulating Tables', (SELECT ID FROM Course WHERE Name = 'Database with SQL Server')),
       (5, 'Querying Data with SELECT Statement', (SELECT ID FROM Course WHERE Name = 'Database with SQL Server')),
       (6, 'Filtering and Sorting Data', (SELECT ID FROM Course WHERE Name = 'Database with SQL Server')),
       (7, 'Joins and Subqueries', (SELECT ID FROM Course WHERE Name = 'Database with SQL Server')),
       (8, 'Indexes and Performance Tuning', (SELECT ID FROM Course WHERE Name = 'Database with SQL Server'))
