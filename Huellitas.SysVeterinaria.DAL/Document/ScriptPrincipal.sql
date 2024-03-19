CREATE DATABASE SysHuellitaVeterinariaDB;
GO
USE SysHuellitaVeterinariaDB;
GO
CREATE TABLE Employees(
Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
[Name] VARCHAR (50) NOT NULL,
LastName VARCHAR (50) NOT NULL,
Dui VARCHAR (10) NOT NULL,
BirthDate DATE  NOT NULL,
Age VARCHAR (3) NOT NULL,
Gender VARCHAR (10) NOT NULL,
CivilStatus VARCHAR (30) NOT NULL,
[Address] VARCHAR (100) NOT NULL,
Phone VARCHAR (10) NOT NULL,
Email VARCHAR (50) NOT NULL,
EmergencyNumber VARCHAR (10) NOT NULL,
AcademicTitle VARCHAR (100) NOT NULL,
WorkExperience VARCHAR (100) NOT NULL,
AreaOfSpecialization VARCHAR (100) NOT NULL,
Position VARCHAR (100) NOT NULL,
KnownAllergies VARCHAR(100) NOT NULL,
RelevantMedicalConditions VARCHAR (100) NOT NULL,
CreationDate DATETIME NOT NULL,
ModificationDate DATETIME DEFAULT NULL,
);
GO
CREATE TABLE [Services](
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
Price MONEY NOT NULL,
DurationTime VARCHAR(50) NOT NULL,
[Status] VARCHAR(11) NOT NULL,
[Description] VARCHAR(200) NOT NULL
);
GO
CREATE TABLE PetOwners(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Dui VARCHAR(10) NOT NULL,
BirthDate DATE NOT NULL,
Age VARCHAR(3) NOT NULL,
Gender VARCHAR(11) NOT NULL,
[Address] VARCHAR(100) NOT NULL,
Phone VARCHAR(9) NOT NULL,
Email VARCHAR(50) NOT NULL,
EmergencyNumber VARCHAR(9) NOT NULL
);
GO
CREATE TABLE Breed(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(30) NOT NULL
)
GO
CREATE TABLE Pet(
Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
IdBreed INT NOT NULL,
[Name] VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Age VARCHAR(50) NOT NULL,
Gender VARCHAR(11) NOT NULL,
DistinctiveColorOrBrand VARCHAR(100) NOT NULL,
SpecialBehaviorOrNeed VARCHAR(200) NOT NULL,
CreationDate DATETIME NOT NULL,
ModificationDate DATETIME DEFAULT NULL,
CONSTRAINT Fk_Bread FOREIGN KEY(IdBreed) REFERENCES Breed(Id)
)