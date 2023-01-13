CREATE TABLE `Users`.`Users` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `UserName` VARCHAR(40) NOT NULL,
  `PasswordHash` VARBINARY(45) NOT NULL,
  `PasswordSalt` BINARY(45) NOT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `PasswordChangeDate` DATETIME NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE)
COMMENT = 'Users table for CS Hangout';
