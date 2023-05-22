INSERT INTO JTOTest.dbo.AgeCategories (MaxAge, MinAge)
VALUES (25, 18), (18, 14), (14, 10);

INSERT INTO JTOTest.dbo.Countries (Name)
VALUES ('United States'), ('Canada'), ('United Kingdom');

INSERT INTO JTOTest.dbo.Courses (Name)
VALUES ('Verantwoordelijkheid'), ('EHBO'), ('Didacthiek');

INSERT INTO JTOTest.dbo.Destinations (City, CountryID, Name, Number, Street, Zip)
VALUES ('New York', 1, 'Times Square', '123', 'Broadway', '10036'),
       ('London', 3, 'Buckingham Palace', '1', 'The Mall', 'SW1A 1AA'),
       ('Paris', 2, 'Eiffel Tower', 'Champ de Mars', '5 Avenue Anatole', '75007');

INSERT INTO JTOTest.dbo.Persons (City, CountryID, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip)
VALUES ('New York', 1, 0, '1990-05-20', 'john@example.com', 1, NULL, 1, 'John', '123', '555-1234', 1, 'Broadway', 'Doe', '10001'),
       ('London', 3, 1, '1985-08-10', 'jane@example.com', 0, NULL, 1, 'Jane', '456', NULL, 0, 'Oxford Street', 'Smith', 'SW1A 1AA'),
       ('Paris', 2, 1, '1995-02-15', 'mark@example.com', 0, NULL, 0, 'Mark', '789', '555-9876', 1, 'Champs-Élysées', 'Brown', '75001');

INSERT INTO JTOTest.dbo.Roles (Name)
VALUES ('Admin'), ('Manager'), ('Participant');

INSERT INTO JTOTest.dbo.Themes (Name)
VALUES ('Adventure'), ('Nature'), ('History');

INSERT INTO JTOTest.dbo.Trainings (CourseID, Date, PersonID, RoleID)
VALUES (1, '2023-07-01', 1, 1),
       (2, '2023-08-15', 2, 2),
       (3, '2023-09-10', 3, 3);

INSERT INTO JTOTest.dbo.Users (Password, Role, UserName)
VALUES ('password123', 'Admin', 'admin_user'),
       ('password456', 'Manager', 'manager_user'),
       ('password789', 'Participant', 'participant_user');

INSERT INTO JTOTest.dbo.GroupTours (AgeCategoryID, Budget, DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID)
VALUES (1, 5000.00, 1, '2023-07-15', 20, 'Summer Adventure', 1500.00, 1, '2023-07-01', 1),
       (2, 3000.00, 2, '2023-08-30', 15, 'Historical Journey', 1200.00, 2, '2023-08-15', 3),
       (null, 4000.00, 3, '2023-09-20', 12, 'Nature Expedition', 1800.00, 3, '2023-09-10', 2);

INSERT INTO JTOTest.dbo.Participants (GroupTourID, PersonID, RoleID)
VALUES (2, 1, 1),
       (2, 2, 2),
       (4, 3, 3);

INSERT INTO JTOTest.dbo.MedicalSheets (Description, PersonID)
VALUES ('Allergy test results', 1),
       ('Blood pressure measurements', 2),
       ('X-ray report', 3);