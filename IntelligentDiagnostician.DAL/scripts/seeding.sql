INSERT INTO Roles (RoleName)
VALUES
    ('Admin'),
    ('User')

    INSERT INTO Users (Fname, Lname, Email, Password, RoleId)
VALUES
    ('yasmeen', 'hany', 'yasmeenhany@btats.com', '123456', 1),
    ('btats', 'btats2', 'btats@btats', '56789', 1)

INSERT INTO CarSystems (CarSystemName)
VALUES
    ('Motor'),
    ('FuelEngine'),
    ('ElectricEngine')

INSERT INTO Sensors (SensorName, CarSystemId)
VALUES
    ('Speed', 1),
    ('Temperature', 1),
    ('FuelLevel', 2),
    ('BatteryLevel', 3),
    ('MotorStatus', 1),
    ('EngineStatus', 3)
