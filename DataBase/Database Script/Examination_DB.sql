create database Examination_System_DataBase

---------------------------------------------
use Examination_System_DataBase

create table Branch
(
ID int primary key identity(1,1),
Name nvarchar(30) not null ,
Building_Number int ,
Street nvarchar(20),
City nvarchar(20)  
)

create table Instructor 
(
ID int Primary Key identity(1,1),
FName nvarchar(20) not null ,
LName nvarchar(20) not null ,
Gender nchar(1) not null ,
Email nvarchar(50) not null ,
Password nvarchar(50) not null ,
Street  nvarchar(50) not null,
City   nvarchar(50) not null,
Date_of_birth Date not null ,
Salary decimal not null,
Branch_ID int not null ,
foreign key (Branch_ID ) REFERENCES Branch(ID) 
ON Delete Cascade
ON Update Cascade
);

create table Track
(
ID int Primary Key identity(1,1),
Name nvarchar(20)  unique not null
);
------------------------------------------------
create table course
(
ID int Primary Key identity(1,1),
Name nvarchar(20)  unique not null
)

-------------------------

create table Student
(
ID int Primary Key identity(1,1),
FName nvarchar(20) not null ,
LName nvarchar(20) not null ,
Gender nchar(1) not null ,
Email nvarchar(50) not null,
Password nvarchar(50) not null ,
Street  nvarchar(50),
City   nvarchar(50),
Date_of_birth Date not null ,
Branch_ID int not null,
Track_ID int not null
foreign key (Branch_ID) REFERENCES Branch(ID) ON Delete Cascade ON Update Cascade,
foreign key (Track_ID) REFERENCES Track(ID) ON Delete Cascade ON Update Cascade,
);
-------------------------------------

create table topic 
(
ID int not null,
Name nvarchar(20)  unique not null,
course_ID int not null,
PRIMARY KEY (ID, course_ID),
FOREIGN KEY (course_ID) REFERENCES course(ID) 
ON Delete Cascade 
ON Update Cascade
);

---------------------------------------------------

create table Question
(
ID int Primary Key identity(1,1),
Question_Body Nvarchar(200) unique  not null ,
Question_Type bit not null ,
Question_Answer tinyint not null,
Topic_ID int not null ,-- partial key of Topic, pk in topic 
course_ID int not null,-- pk in Topic , weak entity on Course
foreign key (Topic_ID ,course_ID) references topic(ID,course_ID)
ON Delete Cascade 
ON Update Cascade
);

------------------
create table Multi_Choices_Question_Answers--weak entity on Question
(
Question_ID int not null,
Number_OF_Choice int not null,----------partial key
Body_OF_Choice int not null
primary key(Question_ID,Number_OF_Choice ),
foreign key(Question_ID) references Question(ID)
on Delete cascade 
on update cascade
);

----------------------------------------
create table Exam 
(
ID int primary key identity(1,1),
Date dateTime not null ,
Duration Decimal not null ,
Course_ID int not null,
foreign Key (Course_ID) references course (ID)  

);

-----------------------
create table Track_Branch
(
Branch_ID int not null ,
Track_ID int not null ,
Supervisor_ID int not null,
primary key (Branch_ID,Track_ID),
foreign Key (Branch_ID) references Branch (ID) ON Delete Cascade ON Update Cascade,
foreign Key (Track_ID) references Track (ID)  ON Delete Cascade ON Update Cascade,
foreign Key (Supervisor_ID) references Instructor (ID)  ,

);

--------

create table Student_Exam
(
Student_ID int not null,
Exam_ID int not null,
Grade int not null,
primary key(Student_ID,Exam_ID),
foreign key (Student_ID) references Student(ID) ON Delete Cascade ON Update Cascade,
foreign key (Exam_ID ) references Exam(ID) ON Delete Cascade ON Update Cascade
);

-----------------

Create table Exam_Question
(
Exam_ID int not null,
Question_ID int not null,
primary key(Question_ID,Exam_ID),
foreign key (Question_ID) references Question(ID) ON Delete Cascade ON Update Cascade,
foreign key (Exam_ID ) references Exam(ID) ON Delete Cascade ON Update Cascade
);

------
create table Instructor_Track_Course 
(
Instructor_ID int not null,
Track_ID int not null,
Course_ID int not null,
primary key(Instructor_ID,Track_ID,Course_ID),
foreign key (Course_ID) references Course(ID) ON Delete Cascade ON Update Cascade,
foreign key (Instructor_ID) references Instructor(ID)  ON Delete Cascade ON Update Cascade,
Foreign Key (Track_ID) references Track(ID) ON Delete Cascade ON Update Cascade,
);




create table Student_Exam_Answers
(
Student_ID int not null,
Exam_ID int not null,
Question_ID int not null,
Student_Answer tinyint not null,
primary key(Student_ID,Exam_ID,Question_ID),
foreign key (Student_ID) references Student(ID) on delete cascade on update cascade,
foreign key(Exam_ID) references Exam(ID) on delete cascade on update cascade,
foreign key(Question_ID ) references Question (ID)  on delete cascade on update cascade
);
