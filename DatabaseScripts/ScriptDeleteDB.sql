-- 1) Remove FK from tables so that tables (if already existing) can be deleted

-- 'Trainee' table:
ALTER TABLE JTOTest.Trainee
DROP CONSTRAINT FK_JTOMainDB_Training;
ALTER TABLE JTOTest.Trainee
DROP CONSTRAINT FK_JTOMainDB_Role;
ALTER TABLE JTOTest.Trainee
DROP CONSTRAINT FK_JTOMainDB_Person;

-- 'Participant' table:
ALTER TABLE JTOTest.Participant
DROP CONSTRAINT FK_JTOMainDB_GroupTour;
ALTER TABLE JTOTest.Trainee
DROP CONSTRAINT FK_JTOMainDB_Role;
ALTER TABLE JTOTest.Trainee
DROP CONSTRAINT FK_JTOMainDB_Person;

-- 'GroupTour' table:
ALTER TABLE JTOTest.GroupTour
DROP CONSTRAINT FK_JTOMainDB_AgeCategory;
ALTER TABLE JTOTest.GroupTour
DROP CONSTRAINT FK_JTOMainDB_Theme;
ALTER TABLE JTOTest.GroupTour
DROP CONSTRAINT FK_JTOMainDB_Destination;
ALTER TABLE JTOTest.GroupTour
DROP CONSTRAINT FK_JTOMainDB_Person;

-- 2) Drop the tables if they already exist
DROP TABLE IF EXISTS JTOMainDB_AgeCategory;
DROP TABLE IF EXISTS JTOMainDB_Training;
DROP TABLE IF EXISTS JTOMainDB_Theme;
DROP TABLE IF EXISTS JTOMainDB_Destination;
DROP TABLE IF EXISTS JTOMainDB_GroupTour;
DROP TABLE IF EXISTS JTOMainDB_Participant;
DROP TABLE IF EXISTS JTOMainDB_Role;
DROP TABLE IF EXISTS JTOMainDB_Person;
DROP TABLE IF EXISTS JTOMainDB_Trainee;
DROP TABLE IF EXISTS JTOMainDB_Users;

-- 3) Drop whole DB if it already exists
DROP DATABASE IF EXISTS JTOTest
