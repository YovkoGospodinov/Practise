CREATE DATABASE [FootBall Manager]

--Data Definition
CREATE TABLE Countries
 (
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(20) NOT NULL
 )

CREATE TABLE Cities
 (
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(30) NOT NULL,
  CountryId INT NOT NULL,
  CONSTRAINT FK_City_Country FOREIGN KEY (CountryId) REFERENCES Countries(Id)
 )

CREATE TABLE Leagues
 (
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(30) NOT NULL,
  NumberOfTeams INT NOT NULL,
  CountryId INT NOT NULL,
  CONSTRAINT FK_League_Country FOREIGN KEY (CountryId) REFERENCES Countries(Id)
 )

CREATE TABLE Teams
 (
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(30) NOT NULL,
  NickName NVARCHAR(30),
  CountryId INT NOT NULL,
  LeagueId INT NOT NULL,
  CityId INT NOT NULL,
  CONSTRAINT FK_Team_Country FOREIGN KEY (CountryId) REFERENCES Countries(Id),
  CONSTRAINT FK_Team_League FOREIGN KEY (LeagueId) REFERENCES Leagues (Id),
  CONSTRAINT FK_Team_City FOREIGN KEY (CityId) REFERENCES Cities (Id)
 )

CREATE TABLE Coaches
 (
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(50) NOT NULL,
  TeamId INT NOT NULL,
  CONSTRAINT FK_Coach_Team FOREIGN KEY (TeamId) REFERENCES Teams (Id)
 )

CREATE TABLE Players
 (
  Id INT PRIMARY KEY IDENTITY,
  Name NVARCHAR(50) NOT NULL,
  BirthDate DATE NOT NULL,
  Position VARCHAR(2) NOT NULL,
  TeamId INT NOT NULL,
  CountryId INT NOT NULL,
  MonthlyWage MONEY,
  PreviousTeadmId INT NOT NULL,
  CONSTRAINT FK_Player_Team FOREIGN KEY (TeamId) REFERENCES Teams (Id),
  CONSTRAINT CHK_Position CHECK (Position = 'GK' OR Position = 'DF' OR Position = 'MF' OR Position = 'FW'),
  CONSTRAINT FK_Player_Country FOREIGN KEY (CountryId) REFERENCES Countries(Id),
  CONSTRAINT FK_Player_PreviousTeam FOREIGN KEY (PreviousTeadmId) REFERENCES Teams (Id)
 )

--Data Manipulation (Insertion of data entries)

INSERT INTO Countries (Name)
	VALUES
	('England'),
	('Spain'),
	('Bulgaria')

INSERT INTO Cities (Name, CountryId)
	VALUES
	('London', 1),
	('Manchester', 1),
	('Liverpool', 1),
	('Hull', 1),
	('Sunderland', 1),
	('Newcastle', 1),
	('Leicester', 1),
	('Swansea', 1),
	('Madrid', 2),
	('Barcelona', 2),
	('Sofia', 3),
	('Plovdiv', 3),
	('Varna', 3),
	('Burgas', 3)


INSERT INTO Leagues (Name, NumberOfTeams, CountryId)
	VALUES
	('Premier League', 20, 1),
	('Premera Devision', 20, 2),
	('First League', 14, 3)

INSERT INTO Teams (Name, NickName, CountryId, LeagueId, CityId)
	VALUES
	('Arsenal F.C.', 'Gunners', 1, 1, 1),
	('Tottenham Hotspur F.C.', 'Spurs', 1, 1, 1),
	('Newcastle United', 'Magpies', 1, 1, 6),
	('Manchester City', 'Citizens', 1, 1, 2),
	('Manchester United', 'Red Devils', 1, 1, 2),
	('Liverpool', 'Reds', 1, 1, 3),
	('Hull City', NULL, 1, 1, 4),
	('Sunderland A.F.C.', NULL, 1, 1, 5),
	('Newcastle United', 'Magpies', 1, 1, 6),
	('Leicester City', 'Foxes' , 1, 1, 7),
	('Swansea City', 'Swans' , 1, 1, 8),
	('FC Barcelona', NULL, 2, 2, 9),
	('Real Madrid C.F.', NULL, 2, 2, 10),
	('Levski Sofia',  NULL, 3, 3, 11),
	('CSKA Sofia', NULL, 3, 3, 11),
	('Botev Plovdiv', NULL, 3, 3, 12),
	('Cherno More Varna', NULL, 3, 3, 13),
	('Neftochimik Burgas', 'Sheihovete', 3, 3, 14)


INSERT INTO Coaches (Name, TeamId)
	VALUES
	('Arsene Wenger', 1),
	('Pep Guardiola', 4),
	('José Mourinho', 5),
	('Jurgen Klopp', 6),
	('Hristo Yanev', 14)

INSERT INTO Players (Name, BirthDate, Position, TeamId, CountryId, MonthlyWage, PreviousTeadmId)
	VALUES
	('Yanko Georgiev', '1988-10-22', 'GK', 18, 3, 10125, 17),
	('Mariyan Ognyanov', '1988-10-30','MF', 18, 3, 30500, 16),
	('Theo Walcott', '1989-03-16', 'MF', 1, 1, 76000, 8),
	('Alex Oxlade-Chamberlain', '1993-08-15', 'MF', 1, 1, 54000, 9),
	('David Silva', '1986-01-08', 'MF', 4, 2, 145000, 12),
	('Raheem Sterling', '1994-12-08', 'FW', 4, 1, 98000, 6),
	('Juan Mata', '1988-04-28', 'MF', 5, 2, 79000, 7),
	('David de Gea', '1990-11-07', 'GK', 5, 2, 67800, 13)




