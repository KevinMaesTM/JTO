INSERT INTO JTOTest.dbo.Users (UserName, Password, Role) VALUES ('Admin', 'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', null);

insert into JTOTest.dbo.AgeCategories (MinAge, MaxAge) values (10, 12);
insert into JTOTest.dbo.AgeCategories (MinAge, MaxAge) values (12, 14);

insert into JTOTest.dbo.Themes (Name) values ('Avontuur');
insert into JTOTest.dbo.Themes (Name) values ('Cultuur');

insert into JTOTest.dbo.Destinations (City, Country, Name, Number, Street, Zip) values ('Antwerpen', 'België', 'Het MAS', 20, 'Masstraat', '2000' );

insert into JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) values ('Weelde', 'België', 1, '1994-10-10 00:00:00', 'kevin.maes@gmail.com', 1, null, 1, 'Kevin', 60, null, 1, 'Lange Wijkstraat', 'Maes', '2381');
insert into JTOTest.dbo.Persons (City, Country, CourseResponsible, DateOfBirth, Email, GroupTourResponsible, medicalSheet, MemberHealthInsurance, Name, Number, Phone, Sex, Street, Surname, Zip) values ('Weelde', 'België', 1, '1998-10-10 00:00:00', 'robin.maes@gmail.com', 1, null, 1, 'Robin', 60, null, 1, 'Lange Wijkstraat', 'Maes', '2381');

insert into JTOTest.dbo.GroupTours (AgeCategoryID, Budget, DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID) values (1, 100, 1, '2023-10-10 16:00:00', 10, 'Cultuur aan het MAS', 20, 1, '2023-10-10 10:00:00', 2);
insert into JTOTest.dbo.GroupTours (AgeCategoryID, Budget, DestinationID, Enddate, MaxParticipants, Name, Price, ResponsibleID, Startdate, ThemeID) values (2, 100, 1, '2023-10-10 16:00:00', 10, 'Cultuur aan het MAS', 20, 1, '2023-10-10 10:00:00', 2);