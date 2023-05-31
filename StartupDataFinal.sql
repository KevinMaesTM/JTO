--Insert user
INSERT INTO JTOTest.dbo.Users (UserName, Password, Role) VALUES ('Admin', 'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', null);

-- Insert AgeCategories
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge) VALUES (10, 12);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge) VALUES (12, 14);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge) VALUES (14, 16);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge) VALUES (16, 18);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge) VALUES (12, 15);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge) VALUES (14, 18);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge) VALUES (15, 18);

-- Insert Destinations
INSERT INTO JTOTest.dbo.Destinations (City, Country, Name, Number, Street, Zip) VALUES ('Durbuy', 'Belgie', 'Ardennen', 1, 'Ardennenstraat', '2000' );
INSERT INTO JTOTest.dbo.Destinations (City, Country, Name, Number, Street, Zip) VALUES ('Oostende', 'Belgie', 'Kust', 12, 'Waterlaan', '1050' );
INSERT INTO JTOTest.dbo.Destinations (City, Country, Name, Number, Street, Zip) VALUES ('Brussel', 'Belgie', 'Cultuutrip Hoofdstad - Brussel', '15a', 'Hoofdstadstraat', '1000' );
INSERT INTO JTOTest.dbo.Destinations (City, Country, Name, Number, Street, Zip) VALUES ('Alkmaar', 'Nederland', 'Waddenlopen', 15, 'Kaasstraat', '12ABCD' );

-- Insert Themes
INSERT INTO JTOTest.dbo.Themes (Name) VALUES ('Avontuur');
INSERT INTO JTOTest.dbo.Themes (Name) VALUES ('Cultuur');
INSERT INTO JTOTest.dbo.Themes (Name) VALUES ('Jong en oud');
INSERT INTO JTOTest.dbo.Themes (Name) VALUES ('Sport');
INSERT INTO JTOTest.dbo.Themes (Name) VALUES ('Kunst en artistiek');

-- Insert Roles
INSERT INTO JTOTest.dbo.Roles (Name) VALUES ('Monitor');
INSERT INTO JTOTest.dbo.Roles (Name) VALUES ('Leerkracht');
INSERT INTO JTOTest.dbo.Roles (Name) VALUES ('Hoofdmonitor');
INSERT INTO JTOTest.dbo.Roles (Name) VALUES ('Deelnemer');
INSERT INTO JTOTest.dbo.Roles (Name) VALUES ('Cursist');

-- Insert Persons
INSERT INTO JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Weelde', 'Belgie', 1, '1994-10-10 00:00:00', 'kevin.maes@gmail.com', 1, null, 1, 'Kevin', 60, null, 1, 'Lange Wijkstraat', 'Maes', '2381');
INSERT INTO JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Bocholt', 'Belgie', 0, '1992-12-08 00:00:00', 'jeroen-baeten@hotmail.com', 0, 'Allergisch aan champignons', 0, 'Jeroen', '40a', '0483063059', 1, 'Heuvelstraat', 'Baeten', '3950');
INSERT INTO JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Geel', 'Belgie', 0, '1990-01-01 00:00:00', 'thomasmore@thomas.more.be', 0, null, 0, 'Thomas', 4, null, 1, 'Kleinhoefstraat', 'More', '2440');
INSERT INTO JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Ver Weg', 'Belgie', 0, '1993-05-28 00:00:00', 'r12345678@student.thomasmore.be', 1, null, 1, 'Maarten', 60, null, 1, 'Ergens', 'Daems', '1000');
INSERT INTO JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Agile', 'Belgie', 1, '1988-10-10 00:00:00', 'MaartenMoonen@docent.com', 0, null, 1, 'Maarten', 60, null, 1, 'Docentenlaan', 'Moonen', '1234');
INSERT INTO JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Codeerstad', 'Belgie', 0, '1998-03-08', 'csharpmaster@codecamp.co', 1, null, 0, 'Joren', 5, null, 1, 'Frontend laan', 'Synaeve', '1010');

-- Insert Grouptours
INSERT INTO JTOTest.dbo.GroupTours (AgeCategoryID, Budget, DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID) VALUES (4, 500, 1, '2022-05-23 17:00:00', 8, 'Tekenen aan de zee', 20, 2, '2022-06-01 10:00:00', 5);
INSERT INTO JTOTest.dbo.GroupTours (AgeCategoryID, Budget, DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID) VALUES (6, 850, 1, '2023-05-30 16:00:00', 10, 'Avontuur in de Waalse Ardennen', 20, 3, '2023-06-13 10:00:00', 1);
INSERT INTO JTOTest.dbo.GroupTours (AgeCategoryID, Budget, DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID) VALUES (1, 100, 3, '2023-10-10 12:00:00', 12, 'Cultuur aan het MAS', 20, 1, '2023-10-10 10:00:00', 2);

-- Insert Trainings
INSERT INTO JTOTest.dbo.Trainings (Name, Date) VALUES ('Monitor', '2023-06-01');
INSERT INTO JTOTest.dbo.Trainings (Name, Date) VALUES ('EHBO - Starter', '2022-12-18');
INSERT INTO JTOTest.dbo.Trainings (Name, Date) VALUES ('Hoofdmonitor', '2023-10-03');
INSERT INTO JTOTest.dbo.Trainings (Name, Date) VALUES ('Monitor', '2022-08-12');

-- Insert Trainees
INSERT INTO JTOTest.dbo.Trainees (PersonID, RoleID, TrainingID, FinishedTraining) VALUES (1, 2, 1, 0);
INSERT INTO JTOTest.dbo.Trainees (PersonID, RoleID, TrainingID, FinishedTraining) VALUES (2, 5, 1, 0);
INSERT INTO JTOTest.dbo.Trainees (PersonID, RoleID, TrainingID, FinishedTraining) VALUES (4, 5, 1, 0);
INSERT INTO JTOTest.dbo.Trainees (PersonID, RoleID, TrainingID, FinishedTraining) VALUES (5, 5, 4, 1);
INSERT INTO JTOTest.dbo.Trainees (PersonID, RoleID, TrainingID, FinishedTraining) VALUES (6, 2, 4, 1);
INSERT INTO JTOTest.dbo.Trainees (PersonID, RoleID, TrainingID, FinishedTraining) VALUES (3, 5, 2, 0);
INSERT INTO JTOTest.dbo.Trainees (PersonID, RoleID, TrainingID, FinishedTraining) VALUES (5, 2, 2, 1);
INSERT INTO JTOTest.dbo.Trainees (PersonID, RoleID, TrainingID, FinishedTraining) VALUES (6, 5, 2, 1);

-- Insert Participants
INSERT INTO JTOTest.dbo.Participants (GroupTourID, PersonID, RoleID) VALUES (1, 1, 4)
INSERT INTO JTOTest.dbo.Participants (GroupTourID, PersonID, RoleID) VALUES (1, 2, 4)
INSERT INTO JTOTest.dbo.Participants (GroupTourID, PersonID, RoleID) VALUES (1, 4, 4)
INSERT INTO JTOTest.dbo.Participants (GroupTourID, PersonID, RoleID) VALUES (1, 6, 3)

