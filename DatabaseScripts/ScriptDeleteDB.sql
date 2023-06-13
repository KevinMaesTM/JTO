-- 1) Remove FK from tables so that tables (if already existing) can be deleted

-- 'Trainee' table:
ALTER TABLE JTOMain.Trainee
DROP CONSTRAINT FK_JTOMain_Training;
ALTER TABLE JTOMain.Trainee
DROP CONSTRAINT FK_JTOMain_Role;
ALTER TABLE JTOMain.Trainee
DROP CONSTRAINT FK_JTOMain_Person;

-- 'Participant' table:
ALTER TABLE JTOMain.Participant
DROP CONSTRAINT FK_JTOMain_GroupTour;
ALTER TABLE JTOMain.Trainee
DROP CONSTRAINT FK_JTOMain_Role;
ALTER TABLE JTOMain.Trainee
DROP CONSTRAINT FK_JTOMain_Person;

-- 'GroupTour' table:
ALTER TABLE JTOMain.GroupTour
DROP CONSTRAINT FK_JTOMain_AgeCategory;
ALTER TABLE JTOMain.GroupTour
DROP CONSTRAINT FK_JTOMain_Theme;
ALTER TABLE JTOMain.GroupTour
DROP CONSTRAINT FK_JTOMain_Destination;
ALTER TABLE JTOMain.GroupTour
DROP CONSTRAINT FK_JTOMain_Person;

-- 2) Drop the tables if they already exist
DROP TABLE IF EXISTS JTOMain_AgeCategory;
DROP TABLE IF EXISTS JTOMain_Training;
DROP TABLE IF EXISTS JTOMain_Theme;
DROP TABLE IF EXISTS JTOMain_Destination;
DROP TABLE IF EXISTS JTOMain_GroupTour;
DROP TABLE IF EXISTS JTOMain_Participant;
DROP TABLE IF EXISTS JTOMain_Role;
DROP TABLE IF EXISTS JTOMain_Person;
DROP TABLE IF EXISTS JTOMain_Trainee;

-- 3) Drop whole DB if it already exists
DROP SCHEMA IF EXISTS JTOMain
