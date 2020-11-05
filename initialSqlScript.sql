CREATE TABLE Characters(
    CharacterId int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255),
    Strength INT NOT NULL,
    Defense INT NOT NULL,
    Intelligence INT NOT NULL,
    CreatedAt DATETIME NOT NULL,
)

CREATE TABLE Weapons(
    WeaponId int IDENTITY(1,1) PRIMARY KEY,
    Name Varchar(255) NOT NULL,
    Damage INT NOT NULL,
    CharacterId INT NOT NULL,
    CreatedAt DATETIME NOT NULL
)

CREATE TABLE Episodes(
    EpisodeId int IDENTITY(1,1) PRIMARY KEY,
    Name varchar(255),
    CreatedAt DATETIME NOT NULL,
    ReleaseDate DATETIME NOT NULL,
    NumberOfEpisode INT NOT NULL
)

CREATE TABLE CharacterEpisodes(
    EpisodeId int NOT NULL,
    CharacterId int NOT NULL
)

CREATE TABLE CharacterFriends(
    FriendId int NOT NULL,
    CharacterId int NOT NULL,
)

DROP TABLE Characters;
DROP TABLE Episodes;
DROP TABLE Weapons;
DROP TABLE CharacterEpisodes;
DROP TABLE CharacterFriends;


SELECT * FROM Weapons;
SELECT * FROM Characters;
SELECT * FROM Episodes;
SELECT * FROM CharacterEpisodes;
SELECT * FROM CharacterFriends;

SELECT c.CharacterId, c.CreatedAt, c.Name, c.Strength, c.Defense, c.Intelligence, 
e.Name as EpisodeName, e.EpisodeId, f.Name as FriendName, f.CharacterId as FriendId
FROM characters c
LEFT JOIN characterEpisodes ec ON ec.CharacterId = c.CharacterId
LEFT JOIN episodes e ON e.EpisodeId = ec.EpisodeId
LEFT JOIN CharacterFriends ef ON ef.CharacterId = c.CharacterId
LEFT JOIN Characters f ON f.CharacterId = ef.FriendId
ORDER BY c.CreatedAt
OFFSET @Offset ROWS
FETCH NEXT @PageSize ROWS ONLY;