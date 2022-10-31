CREATE TABLE [Passengers] (
    [PassportNumber] nvarchar(7) NOT NULL,
    [FirstName] nvarchar(25) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [BirthDate] datetime2 NOT NULL,
    [TelNumber] int NOT NULL,
    [EmailAddress] nvarchar(max) NOT NULL,
    [Discriminator] nvarchar(max) NOT NULL,
    [Function] nvarchar(max) NULL,
    [EmployementDate] datetime2 NULL,
    [Salary] real NULL,
    [HealthInformation] nvarchar(max) NULL,
    [Nationality] nvarchar(max) NULL,
    CONSTRAINT [PK_Passengers] PRIMARY KEY ([PassportNumber])
);
GO


CREATE TABLE [Planes] (
    [PlaneId] int NOT NULL IDENTITY,
    [PlaneType] int NOT NULL,
    [ManufactureDate] datetime2 NOT NULL,
    [Capacity] int NOT NULL,
    CONSTRAINT [PK_Planes] PRIMARY KEY ([PlaneId])
);
GO


CREATE TABLE [Flights] (
    [FlightId] int NOT NULL IDENTITY,
    [FlightDate] datetime2 NOT NULL,
    [EstimatedDuration] int NOT NULL,
    [EffectiveArrival] datetime2 NOT NULL,
    [Departure] nvarchar(max) NOT NULL,
    [Destination] nvarchar(max) NOT NULL,
    [AirlineLogo] nvarchar(max) NOT NULL,
    [PlaneId] int NOT NULL,
    CONSTRAINT [PK_Flights] PRIMARY KEY ([FlightId]),
    CONSTRAINT [FK_Flights_Planes_PlaneId] FOREIGN KEY ([PlaneId]) REFERENCES [Planes] ([PlaneId]) ON DELETE CASCADE
);
GO


CREATE TABLE [FlightPassenger] (
    [FlightsFlightId] int NOT NULL,
    [PassengersPassportNumber] nvarchar(7) NOT NULL,
    CONSTRAINT [PK_FlightPassenger] PRIMARY KEY ([FlightsFlightId], [PassengersPassportNumber]),
    CONSTRAINT [FK_FlightPassenger_Flights_FlightsFlightId] FOREIGN KEY ([FlightsFlightId]) REFERENCES [Flights] ([FlightId]) ON DELETE CASCADE,
    CONSTRAINT [FK_FlightPassenger_Passengers_PassengersPassportNumber] FOREIGN KEY ([PassengersPassportNumber]) REFERENCES [Passengers] ([PassportNumber]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_FlightPassenger_PassengersPassportNumber] ON [FlightPassenger] ([PassengersPassportNumber]);
GO


CREATE INDEX [IX_Flights_PlaneId] ON [Flights] ([PlaneId]);
GO


