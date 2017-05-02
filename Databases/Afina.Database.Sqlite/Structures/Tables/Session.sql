CREATE TABLE IF NOT EXISTS `Session` 
( 
`Id` INTEGER PRIMARY KEY AUTOINCREMENT
, `ExternalId` TEXT NOT NULL UNIQUE
, `EncryptionKey` TEXT NOT NULL
, `CreationDate` INTEGER
, `LastAccessDate` INTEGER
, `TimeToLiveInSeconds` INTEGER 
)