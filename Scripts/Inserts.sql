--Just for TESTING
-- Student

INSERT INTO Student(Name, Surname,Email, GroupID)
VALUES ('Robert', 'Meli','RobertMeli99@mcast.edu.mt',9);

INSERT INTO Student(Name, Surname,Email, GroupID)
VALUES ('Kurt', 'Borg','KurtBorg96@mcast.edu.mt',10);

INSERT INTO Student(Name, Surname,Email, GroupID)
VALUES ('Astrid', 'Kaminski','AstridKaminski98@mcast.edu.mt',12);

INSERT INTO Student(Name, Surname,Email, GroupID)
VALUES ('Nicole', 'Symanski','NicoleSymanski01@mcast.edu.mt',11);

INSERT INTO Student(Name, Surname,Email, GroupID)
VALUES ('Natalia', 'Azzopardi','NataliaAzzopardi97@mcast.edu.mt',12);

-- Group

INSERT INTO [Group](Name, Course)
VALUES ('6.1A', 'ICT_Software_Development');

INSERT INTO [Group](Name, Course)
VALUES ('6.1B', 'ICT_Software_Development');

INSERT INTO [Group](Name, Course)
VALUES ('6.2A', 'ICT_Multimedia_Software_Development');

INSERT INTO [Group](Name, Course)
VALUES ('6.3A', 'ICT_Multimedia_Software_Development');

-- Teacher

INSERT INTO Teacher(Username, Password, Name, Surname,Email)
VALUES ('ICT_JaGr01','JaG01','James', 'Gray','JamesGray@Mcast.edu.mt');

INSERT INTO Teacher(Username, Password, Name, Surname,Email)
VALUES ('ICT_JeAg27','JeA27','Jennifer', 'Agius','JenniferAgius@Mcast.edu.mt');

INSERT INTO Teacher(Username, Password, Name, Surname,Email)
VALUES ('ICT_KlBu19','KlB19','Klara', 'Buttigieg','KlaraButtigieg@Mcast.edu.mt');

-- Lesson

INSERT INTO Lesson(GroupID,[DateTime], TeacherID)
VALUES (9,GETDATE()+1,20);


INSERT INTO Lesson(GroupID,[DateTime], TeacherID)
VALUES (10,GETDATE()+3,21);


INSERT INTO Lesson(GroupID,[DateTime], TeacherID)
VALUES (12,GETDATE()+2,20);


INSERT INTO Lesson(GroupID,[DateTime], TeacherID)
VALUES (11,GETDATE()+4,19);

select *
from Teacher

truncate table teacher