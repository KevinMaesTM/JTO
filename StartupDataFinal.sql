--Insert user
INSERT INTO JTOTest.dbo.Users (UserName, Password, Role) VALUES ('Admin', 'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', null);

-- Insert AgeCategories
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge, IsActive) VALUES (10, 12, 1);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge, IsActive) VALUES (12, 14, 1);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge, IsActive) VALUES (14, 16, 1);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge, IsActive) VALUES (16, 18, 1);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge, IsActive) VALUES (12, 15, 1);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge, IsActive) VALUES (14, 18, 1);
INSERT INTO JTOTest.dbo.AgeCategories (MinAge, MaxAge, IsActive) VALUES (15, 18, 1);

-- Insert Destinations
INSERT INTO JTOTest.dbo.Destinations (City, Country, Name, Number, Street, Zip, IsActive) VALUES ('Durbuy', 'Belgie', 'Ardennen', 1, 'Ardennenstraat', '2000', 1 );
INSERT INTO JTOTest.dbo.Destinations (City, Country, Name, Number, Street, Zip, IsActive) VALUES ('Oostende', 'Belgie', 'Kust', 12, 'Waterlaan', '1050', 1 );
INSERT INTO JTOTest.dbo.Destinations (City, Country, Name, Number, Street, Zip, IsActive) VALUES ('Brussel', 'Belgie', 'Cultuutrip Hoofdstad - Brussel', '15a', 'Hoofdstadstraat', '1000', 1 );
INSERT INTO JTOTest.dbo.Destinations (City, Country, Name, Number, Street, Zip, IsActive) VALUES ('Alkmaar', 'Nederland', 'Waddenlopen', 15, 'Kaasstraat', '12ABCD', 1 );

-- Insert Themes
INSERT INTO JTOTest.dbo.Themes (Name, IsActive) VALUES ('Avontuur', 1);
INSERT INTO JTOTest.dbo.Themes (Name, IsActive) VALUES ('Cultuur', 1);
INSERT INTO JTOTest.dbo.Themes (Name, IsActive) VALUES ('Jong en oud', 1);
INSERT INTO JTOTest.dbo.Themes (Name, IsActive) VALUES ('Sport', 1);
INSERT INTO JTOTest.dbo.Themes (Name, IsActive) VALUES ('Kunst en artistiek', 1);

-- Insert Roles
INSERT INTO JTOTest.dbo.Roles (Name, IsActive, AssignedObject) VALUES ('Monitor', 1, 'GroupTour');
INSERT INTO JTOTest.dbo.Roles (Name, IsActive, AssignedObject) VALUES ('Leerkracht', 1, 'Training');
INSERT INTO JTOTest.dbo.Roles (Name, IsActive, AssignedObject) VALUES ('Hoofdmonitor', 1, 'GroupTour');
INSERT INTO JTOTest.dbo.Roles (Name, IsActive, AssignedObject) VALUES ('Deelnemer', 1, 'GroupTour');
INSERT INTO JTOTest.dbo.Roles (Name, IsActive, AssignedObject) VALUES ('Cursist', 1,'Training');

-- Insert Persons
INSERT INTO JTOTest.dbo.Persons (City, Country, DateOfBirth, Email, IsMoni, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Weelde', 'Belgie', '1994-10-10 00:00:00', 'kevin.maes@gmail.com', 0, 1, null, 1, 'Kevin', 60, null, 1, 'Lange Wijkstraat', 'Maes', '2381');
INSERT INTO JTOTest.dbo.Persons (City, Country, DateOfBirth, Email, IsMoni, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Bocholt', 'Belgie', '1992-12-08 00:00:00', 'jeroen-baeten@hotmail.com', 0, 0, 'Allergisch aan champignons', 0, 'Jeroen', '40a', '0483063059', 1, 'Heuvelstraat', 'Baeten', '3950');
INSERT INTO JTOTest.dbo.Persons (City, Country, DateOfBirth, Email, IsMoni,GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Geel', 'Belgie', '1990-01-01 00:00:00', 'thomasmore@thomas.more.be', 0, 0, null, 1, 'Thomas', 4, null, 1, 'Kleinhoefstraat', 'More', '2440');
INSERT INTO JTOTest.dbo.Persons (City, Country, DateOfBirth, Email, IsMoni,GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Ver Weg', 'Belgie', '1993-05-28 00:00:00', 'r12345678@student.thomasmore.be', 0, 1, null, 0, 'Maarten', 60, null, 1, 'Ergens', 'Daems', '1000');
INSERT INTO JTOTest.dbo.Persons (City, Country, DateOfBirth, Email, IsMoni,GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Agile', 'Belgie', '1988-10-10 00:00:00', 'MaartenMoonen@docent.com', 1, 1, null, 1, 'Maarten', 60, null, 1, 'Docentenlaan', 'Moonen', '1234');
INSERT INTO JTOTest.dbo.Persons (City, Country, DateOfBirth, Email, IsMoni,GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) VALUES ('Codeerstad', 'Belgie', '1998-03-08', 'csharpmaster@codecamp.co', 1, 1, null, 0, 'Joren', 5, null, 1, 'Frontend laan', 'Synaeve', '1010');

-- Insert Grouptours
INSERT INTO JTOTest.dbo.GroupTours (AgeCategoryID,  DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID) VALUES (4,  1, '2022-05-23 17:00:00', 8, 'Tekenen aan de zee', 20, 2, '2022-06-01 10:00:00', 5);
INSERT INTO JTOTest.dbo.GroupTours (AgeCategoryID,  DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID) VALUES (6,  1, '2023-05-30 16:00:00', 10, 'Avontuur in de Waalse Ardennen', 20, 3, '2023-06-13 10:00:00', 1);
INSERT INTO JTOTest.dbo.GroupTours (AgeCategoryID,  DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID) VALUES (1,  3, '2023-10-10 12:00:00', 12, 'Cultuur aan het MAS', 20, 1, '2023-10-10 10:00:00', 2);

-- Insert Trainings
INSERT INTO JTOTest.dbo.Trainings (Name, Date, IsActive) VALUES ('Monitor', '2023-06-01', 1);
INSERT INTO JTOTest.dbo.Trainings (Name, Date, IsActive) VALUES ('EHBO - Starter', '2022-12-18', 1);
INSERT INTO JTOTest.dbo.Trainings (Name, Date, IsActive) VALUES ('Hoofdmonitor', '2023-10-03', 1);
INSERT INTO JTOTest.dbo.Trainings (Name, Date, IsActive) VALUES ('Monitor', '2022-08-12', 1);

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

