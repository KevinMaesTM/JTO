INSERT INTO JTOTest.dbo.Users (UserName, Password, Role) VALUES ('Admin', 'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', null);

insert into JTOTest.dbo.AgeCategories (MinAge, MaxAge) values (10, 12);
insert into JTOTest.dbo.AgeCategories (MinAge, MaxAge) values (12, 14);

insert into JTOTest.dbo.Themes (Name) values ('Avontuur');
insert into JTOTest.dbo.Themes (Name) values ('Cultuur');

insert into JTOTest.dbo.Destinations (City, Country, Name, Number, Street, Zip) values ('Antwerpen', 'Belgie', 'Het MAS', 20, 'Masstraat', '2000' );

insert into JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) values ('Weelde', 'Belgie', 1, '1994-10-10 00:00:00', 'kevin.maes@gmail.com', 1, null, 1, 'Kevin', 60, null, 1, 'Lange Wijkstraat', 'Maes', '2381');
insert into JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) values ('Weelde', 'Belgie', 1, '1998-10-10 00:00:00', 'robin.maes@gmail.com', 1, null, 1, 'Robin', 60, null, 1, 'Lange Wijkstraat', 'Maes', '2381');

insert into JTOTest.dbo.GroupTours (AgeCategoryID, Budget, DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID) values (1, 100, 1, '2023-10-10 16:00:00', 10, 'Cultuur aan het MAS', 20, 1, '2023-10-10 10:00:00', 2);
insert into JTOTest.dbo.GroupTours (AgeCategoryID, Budget, DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID) values (2, 100, 1, '2023-10-10 16:00:00', 10, 'Cultuur aan het MAS', 20, 1, '2023-10-10 10:00:00', 2);

INSERT INTO JTOTest.dbo.AgeCategories (MaxAge, MinAge)
VALUES (25, 18), (18, 14), (14, 10);

INSERT INTO JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip)
VALUES ('New York', 'USA', 0, '1990-05-20', 'john@example.com', 1, NULL, 1, 'John', '123', '555-1234', 1, 'Broadway', 'Doe', '10001'),
       ('London', 'UK', 1, '1985-08-10', 'jane@example.com', 0, NULL, 1, 'Jane', '456', NULL, 0, 'Oxford Street', 'Smith', 'SW1A 1AA'),
       ('Paris', 'France', 1, '1995-02-15', 'mark@example.com', 0, NULL, 0, 'Mark', '789', '555-9876', 1, 'Champs-Élysées', 'Brown', '75001');

INSERT INTO JTOTest.dbo.Roles (Name)
VALUES ('Admin'), ('Manager'), ('Participant');

INSERT INTO JTOTest.dbo.Themes (Name)
VALUES ('Adventure'), ('Nature'), ('History');

INSERT INTO JTOTest.dbo.Trainings (Name, Date)
VALUES ('Verantwoordelijkheid', '2023-06-01'), ('EHBO', '2023-05-30'), ('Didacthiek', '2023-07-15');

INSERT INTO JTOTest.dbo.Trainees (PersonID, RoleID, TrainingID, FinishedTraining)
VALUES (1, 2, 1, 0), (2, 2, 2, 0), (3, 2, 3, 0);

INSERT INTO JTOTest.dbo.Users (Password, Role, UserName)
VALUES ('password123', 'Admin', 'admin_user'),
       ('password456', 'Manager', 'manager_user'),
       ('password789', 'Participant', 'participant_user');

INSERT INTO JTOTest.dbo.GroupTours (AgeCategoryID, Budget, DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID)
VALUES (1, 5000.00, 1, '2023-07-15', 20, 'Summer Adventure', 1500.00, 1, '2023-07-01', 1),
       (2, 3000.00, 1, '2023-08-30', 15, 'Historical Journey', 1200.00, 2, '2023-08-15', 3),
       (null, 4000.00, 1, '2023-09-20', 12, 'Nature Expedition', 1800.00, 3, '2023-09-10', 2);

INSERT INTO JTOTest.dbo.Participants (GroupTourID, PersonID, RoleID)
VALUES (1, 1, 1),
       (1, 2, 2),
       (1, 3, 3);