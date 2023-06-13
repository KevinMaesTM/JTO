-- 2) Create tables

CREATE TABLE JTOMain.Trainings(
TrainingID int IDENTITY (1,1),
[Name] nvarchar(max) NOT NULL,
[Date] date NULL,
IsActive bit NULL,
CONSTRAINT PK_Trainings PRIMARY KEY (TrainingID)
);

CREATE TABLE JTOMain.AgeCategories(
AgeCategoryID int IDENTITY (1,1),
MinAge int NULL,
MaxAge int NULL,
IsActive bit NULL,
CONSTRAINT PK_AgeCategories PRIMARY KEY (AgeCategoryID)
);

CREATE TABLE JTOMain.Themes(
ThemeID int IDENTITY (1,1),
[Name] nvarchar(max) NOT NULL,
CONSTRAINT PK_Themes PRIMARY KEY (ThemeID)
);

CREATE TABLE JTOMain.Destinations(
DestinationID int IDENTITY (1,1),
[Name] nvarchar(max) NOT NULL,
Street nvarchar(max) NOT NULL,
Number nvarchar(max) NOT NULL,
Zip nvarchar(max) NOT NULL,
City nvarchar(max) NOT NULL,
Country nvarchar(max) NOT NULL,
IsActive bit NULL,
CONSTRAINT PK_Destinations PRIMARY KEY (DestinationID)
);

CREATE TABLE JTOMain.Persons(
PersonID int IDENTITY (1,1),
[Name] nvarchar(max) NOT NULL,
Surname nvarchar(max) NOT NULL,
DateOfBirth date NOT NULL,
Sex bit NOT NULL,
MemberHealthInsurance bit NOT NULL,
GroupTourResponsible bit NOT NULL,
Phone nvarchar(max) NULL,
Email nvarchar(max) NOT NULL,
Street nvarchar(max) NOT NULL,
Number nvarchar(max) NOT NULL,
Zip nvarchar(max) NOT NULL,
City nvarchar(max) NOT NULL,
Country nvarchar(max) NOT NULL,
MedicalSheet nvarchar(max) NULL
CONSTRAINT PK_Persons PRIMARY KEY (PersonID)
);

CREATE TABLE JTOMain.Roles(
RoleID int IDENTITY (1,1),
[Name] varchar(max) NOT NULL,
CONSTRAINT PK_Roles PRIMARY KEY (RoleID)
);

CREATE TABLE JTOMain.GroupTours(
GroupTourID int IDENTITY (1,1),
[Name] nvarchar(max) NOT NULL,
Price decimal(5,2) NOT NULL,
MaxParticipants int NOT NULL,
StartDate date NOT NULL,
EndDate date NOT NULL,
ResponsibleID int NOT NULL,
DestinationID int NOT NULL,
ThemeID int NOT NULL,
AgeCategoryID int NOT NULL,
CONSTRAINT PK_GroupTours PRIMARY KEY (GroupTourID),
CONSTRAINT FK_GroupTours_AgeCategories_AgeCategoryID FOREIGN KEY (AgeCategoryID) REFERENCES JTOMain.AgeCategories(AgeCategoryID),
CONSTRAINT FK_GroupTours_Destinations_DestinationID FOREIGN KEY (DestinationID) REFERENCES JTOMain.Destinations(DestinationID),
CONSTRAINT FK_GroupTours_Persons_ResponsibleID FOREIGN KEY (ResponsibleID) REFERENCES JTOMain.Persons(PersonID),
CONSTRAINT FK_GroupTours_Themes_ThemeID FOREIGN KEY (ThemeID) REFERENCES JTOMain.Themes(ThemeID)
);

CREATE TABLE JTOMain.Participants (
ParticipantID int IDENTITY (1, 1) NOT NULL,
GroupTourID int NOT NULL,
PersonID int NOT NULL,
RoleID int NOT NULL,
CONSTRAINT PK_Participants PRIMARY KEY (ParticipantID),
CONSTRAINT FK_Participants_GroupTours_GroupTourID FOREIGN KEY (GroupTourID) REFERENCES JTOMain.GroupTours (GroupTourID),
CONSTRAINT FK_Participants_Persons_PersonID FOREIGN KEY (PersonID) REFERENCES JTOMain.Persons (PersonID),
CONSTRAINT FK_Participants_Roles_RoleID FOREIGN KEY (RoleID) REFERENCES JTOMain.Roles (RoleID),
);

CREATE TABLE JTOMain.Trainees (
TraineeID int IDENTITY (1, 1) NOT NULL,
FinishedTraining bit NOT NULL,
PersonID int NOT NULL,
RoleID int NOT NULL,
TrainingID int NOT NULL,
CONSTRAINT PK_Trainees PRIMARY KEY (TraineeID),
CONSTRAINT FK_Trainees_Persons_PersonID FOREIGN KEY (PersonID) REFERENCES JTOMain.Persons (PersonID),
CONSTRAINT FK_Trainees_Roles_RoleID FOREIGN KEY (RoleID) REFERENCES JTOMain.Roles (RoleID),
CONSTRAINT FK_Trainees_Trainings_TrainingID FOREIGN KEY (TrainingID) REFERENCES JTOMain.Trainings (TrainingID)
);
