CREATE TABLE Car
(
	CarId DECIMAL(7) NOT NULL IDENTITY(1,1),
	PointRequirement INT NOT NULL,
	ViewResourcesPath VARCHAR(MAX) NOT NULL,
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

Alter Table Car
Add WheelResource VARCHAR(MAX) NOT NULL;

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (0, '/Resources/Final_Assets/Audi.png', '/Resources/Wheel/AudiWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (1000, '/Resources/Final_Assets/Offroad.png', '/Resources/Wheel/OffroadWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (2000, '/Resources/Final_Assets/Unknown.png', '/Resources/Wheel/UnknownWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (3000, '/Resources/Final_Assets/Mustang.gif', '/Resources/Wheel/MustangWheel.gif');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (4000, '/Resources/Final_Assets/truck.png', '/Resources/Wheel/TruckWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (5000, '/Resources/Final_Assets/Supercar.png', '/Resources/Wheel/SupercarWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (6000, '/Resources/Final_Assets/Icecream.png', '/Resources/Wheel/IcecreamWheel.png');