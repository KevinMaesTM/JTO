-- 1) Remove FK from tables so that tables (if already existing) can be deleted

-- 'Trainee' table:
ALTER TABLE JTOTest.Trainee
DROP CONSTRAINT FK_JTOTest_Training;
ALTER TABLE JTOTest.Trainee
DROP CONSTRAINT FK_JTOTest_Role;
ALTER TABLE JTOTest.Trainee
DROP CONSTRAINT FK_JTOTest_Person;

-- 'Participant' table:
ALTER TABLE JTOTest.Participant
DROP CONSTRAINT FK_JTOTest_GroupTour;
ALTER TABLE JTOTest.Trainee
DROP CONSTRAINT FK_JTOTest_Role;
ALTER TABLE JTOTest.Trainee
DROP CONSTRAINT FK_JTOTest_Person;

-- 'GroupTour' table:
ALTER TABLE JTOTest.GroupTour
DROP CONSTRAINT FK_JTOTest_AgeCategory;
ALTER TABLE JTOTest.GroupTour
DROP CONSTRAINT FK_JTOTest_Theme;
ALTER TABLE JTOTest.GroupTour
DROP CONSTRAINT FK_JTOTest_Destination;
ALTER TABLE JTOTest.GroupTour
DROP CONSTRAINT FK_JTOTest_Person;

-- 2) Drop the tables if they already exist
DROP TABLE IF EXISTS JTOTest_AgeCategory;
DROP TABLE IF EXISTS JTOTest_Training;
DROP TABLE IF EXISTS JTOTest_Theme;
DROP TABLE IF EXISTS JTOTest_Destination;
DROP TABLE IF EXISTS JTOTest_GroupTour;
DROP TABLE IF EXISTS JTOTest_Participant;
DROP TABLE IF EXISTS JTOTest_Role;
DROP TABLE IF EXISTS JTOTest_Person;
DROP TABLE IF EXISTS JTOTest_Trainee;
DROP TABLE IF EXISTS JTOTest_Users;

-- 3) Drop whole DB if it already exists
DROP DATABASE IF EXISTS JTOTest
