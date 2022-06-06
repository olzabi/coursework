USE olz;

CREATE TABLE Advisor (
	advisorId INT IDENTITY(1,1) PRIMARY KEY,
    lastName VARCHAR(255),
    firstMidName VARCHAR(255),
    position VARCHAR(255)
);

CREATE TABLE Student(
    studentId INT IDENTITY(1,1) PRIMARY KEY,
    lastName VARCHAR(255),
    firstMidName VARCHAR(255),
    department varchar(255)
);

CREATE TABLE term(
    termPaperID INT IDENTITY(1,1) PRIMARY KEY,
    taken DATETIME NOT NULL,
    due DATETIME NOT NULL,
    grade varchar(5),
    isPassed BIT,

    fk_adv_id INT FOREIGN KEY REFERENCES Advisor(advisorId),
    fk_student_id INT FOREIGN KEY REFERENCES Student(studentId)
);
