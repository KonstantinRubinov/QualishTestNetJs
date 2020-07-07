use QualishTest;

CREATE TABLE AppointmentTypes(
	appointmentTypeId int IDENTITY PRIMARY KEY,
	appointmentTypeName nvarchar(30) NOT NULL
);

CREATE TABLE AppointmentImportances(
	importanceId int IDENTITY PRIMARY KEY,
	importanceName nvarchar(30) NOT NULL
);

CREATE TABLE Appointments(
	appointmentId int IDENTITY PRIMARY KEY,
	customerName nvarchar(30) NOT NULL,
	appointmentDate date NOT NULL,
	startTime time NOT NULL,
	endTime time NOT NULL,
	appointmentTypeId int NOT NULL FOREIGN KEY REFERENCES AppointmentTypes(appointmentTypeId),
	importanceId int NOT NULL FOREIGN KEY REFERENCES AppointmentImportances(importanceId)
);

INSERT INTO AppointmentImportances(importanceName) VALUES ('Not Important');
INSERT INTO AppointmentImportances(importanceName) VALUES ('Important');
INSERT INTO AppointmentImportances(importanceName) VALUES ('Very Important');