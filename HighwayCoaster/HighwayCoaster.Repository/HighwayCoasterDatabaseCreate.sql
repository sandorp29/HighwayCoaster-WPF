CREATE TABLE Car
(
	CarId DECIMAL(7) NOT NULL IDENTITY(1,1),
	PointRequirement INT NOT NULL,
	ViewResourcesPath VARCHAR(MAX) NOT NULL,
	WheelResource     VARCHAR (MAX) NOT NULL,
    Thumbnail          VARCHAR (MAX) NOT NULL,
	CONSTRAINT Cars_PK PRIMARY KEY(CarId)
);

CREATE TABLE Player
(
	PlayerId DECIMAL(7) NOT NULL IDENTITY(1,1),
	Username VARCHAR(20) NOT NULL,
	PW BINARY(16) NOT NULL,
	Highscore INT,
	IsAdmin BIT NOT NULL,
	CarId DECIMAL(7) NOT NULL
	CONSTRAINT Player_PK PRIMARY KEY(PlayerId),
	CONSTRAINT UC_Username UNIQUE(Username),
	CONSTRAINT Car_FK FOREIGN KEY(CarId) REFERENCES Car(CarId)
);

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource, Thumbnail)
Values (0, '/Resources/Assets/Supercar.png', '/Resources/Assets/Wheel/SupercarWheel.png', '/Resources/Assets/Supercar_Thumbnail.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource, Thumbnail)
Values (1000, '/Resources/Assets/Supercar_black.png', '/Resources/Assets/Wheel/SupercarWheel.png', '/Resources/Assets/Supercar_black_Thumbnail.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource, Thumbnail)
Values (2000, '/Resources/Assets/Supercar_blackGreen.png', '/Resources/Assets/Wheel/SupercarWheel.png', '/Resources/Assets/Supercar_blackGreen_Thumbnail.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource, Thumbnail)
Values (3000, '/Resources/Assets/Supercar_Venom.png', '/Resources/Assets/Wheel/SupercarWheel.png', '/Resources/Assets/Supercar_Venom_Thumbnail.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource, Thumbnail)
Values (4000, '/Resources/Assets/Supercar_Orange.png', '/Resources/Assets/Wheel/SupercarWheel.png', '/Resources/Assets/Supercar_Orange_Thumbnail.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource, Thumbnail)
Values (5000, '/Resources/Assets/Supercar_red.png', '/Resources/Assets/Wheel/SupercarWheel.png', '/Resources/Assets/Supercar_red_Thumbnail.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource, Thumbnail)
Values (6000, '/Resources/Assets/Supercar_purp.png', '/Resources/Assets/Wheel/SupercarWheel.png', '/Resources/Assets/Supercar_purp_Thumbnail.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource, Thumbnail)
Values (10000, '/Resources/Assets/Supercar_darkGreen.png', '/Resources/Assets/Wheel/SupercarWheel.png', '/Resources/Assets/Supercar_darkGreen_Thumbnail.png');