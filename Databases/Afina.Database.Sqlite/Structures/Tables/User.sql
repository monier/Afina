CREATE TABLE IF NOT EXISTS `User` 
( 
`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT
, `Name` TEXT NOT NULL UNIQUE
, `Password` TEXT 
)