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

Alter Table Car
Add TumbNail VARCHAR(MAX);

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (0, '/Resources/Final_Assets/Supercar.png', '/Resources/Wheel/SupercarWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (1000, '/Resources/Final_Assets/Supercar_black.png', '/Resources/Wheel/SupercarWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (2000, '/Resources/Final_Assets/Supercar_blackGreen.png', '/Resources/Wheel/SupercarWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (3000, '/Resources/Final_Assets/Supercar_Venom.png', '/Resources/Wheel/SupercarWheel.gif');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (4000, '/Resources/Final_Assets/Supercar_Orange.png', '/Resources/Wheel/SupercarWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (5000, '/Resources/Final_Assets/Supercar_red.png', '/Resources/Wheel/SupercarWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (6000, '/Resources/Final_Assets/Supercar_purp.png', '/Resources/Wheel/SupercarWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (0, '/Resources/Final_Assets/Supercar_BluePurp.png', '/Resources/Wheel/SupercarWheel.png');

Insert into Car (PointRequirement, ViewResourcesPath, WheelResource)
Values (0, '/Resources/Final_Assets/Supercar_darkGreen.png', '/Resources/Wheel/SupercarWheel.png');

update Car
Set TumbNail = '/Resources/Final_Assets/Supercar_TumbNail.png'
where ViewResourcesPath = '/Resources/Final_Assets/Supercar.png';

update Car
Set TumbNail = '/Resources/Final_Assets/Supercar_black_TumbNail.png'
where ViewResourcesPath = '/Resources/Final_Assets/Supercar_black.png';;


update Car
Set TumbNail = '/Resources/Final_Assets/Supercar_blackGreen_TumbNail.png'
where ViewResourcesPath = '/Resources/Final_Assets/Supercar_blackGreen.png';

update Car
Set TumbNail = '/Resources/Final_Assets/Supercar_Venom_TumbNail.png'
where ViewResourcesPath = '/Resources/Final_Assets/Supercar_Venom.png';

update Car
Set TumbNail = '/Resources/Final_Assets/Supercar_Orange_TumbNail.png'
where ViewResourcesPath = '/Resources/Final_Assets/Supercar_Orange.png';

update Car
Set TumbNail = '/Resources/Final_Assets/Supercar_red_TumbNail.png'
where ViewResourcesPath = '/Resources/Final_Assets/Supercar_red.png';

update Car
Set TumbNail = '/Resources/Final_Assets/Supercar_purp_TumbNail.png'
where ViewResourcesPath = '/Resources/Final_Assets/Supercar_purp.png';

update Car
Set TumbNail = '/Resources/Final_Assets/Supercar_BluePurp_TumbNail.png'
where ViewResourcesPath = '/Resources/Final_Assets/Supercar_BluewPurp.png';

update Car
Set TumbNail = '/Resources/Final_Assets/Supercar_darkGreen_TumbNail.png'
where ViewResourcesPath = '/Resources/Final_Assets/Supercar_darkGreen.png';

