# DotaForDiscord

Copy App.config.example to App.config
Insert missing values into App.config
Run CreateTables.sql against the Database.

Add players to be tracked by executing:
INSERT INTO `lastmatch`(`id`, `matchid`, `name`) VALUES (@@OPENDOTA_ID@@,0,NULL)

You must replace @@OPENDOTA_ID@@ with the OpenDota ID of that player.
