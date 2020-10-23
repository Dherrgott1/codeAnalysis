
-- Create TMS Database

DROP DATABASE IF EXISTS TMS;
CREATE DATABASE IF NOT EXISTS TMS;
USE TMS;


--
-- Definition of table `Employee`
--

DROP TABLE IF EXISTS `Employee`;
CREATE TABLE `Employee` (
  `EmployeeID` int PRIMARY KEY NOT NULL,
  `AccountName` mediumtext,
  `AccountPassword` mediumtext,
  `EmployeeName` mediumtext 
);

--
-- Dumping data for table `Employee`
--

INSERT INTO `Employee` (`EmployeeID`, `AccountName`, `AccountPassword`, `EmployeeName`) VALUES
('0025', 'Admin', 'nopassword', 'Sean Clarke'),
('0050', 'Buyer', 'nopassword', 'Russel Foubert'),
('0075', 'Planner', 'nopassword', 'Bob Ross');
    

--
-- Definition of table `Admin`
--

DROP TABLE IF EXISTS `Admin`;
CREATE TABLE `Admin` (
  `AdminID` INT PRIMARY KEY NOT NULL,
  `GetConfigAccess` int,
  `EmployeeID` int
);

--
-- Dumping data for table `Admin`
--

INSERT INTO `Admin` (`AdminID`, `GetConfigAccess`, `EmployeeID`) VALUES
('0001', '1', (SELECT EmployeeID FROM Employee WHERE AccountName = 'Admin'));


--
-- Definition of table `Planner`
--

DROP TABLE IF EXISTS `Planner`;
CREATE TABLE `Planner` (
  `PlannerID` int PRIMARY KEY NOT NULL,
  `EmployeeID` int
);

--
-- Dumping data for table `Planner`
--

INSERT INTO `Planner` (`PlannerID`, `EmployeeID`) VALUES
('0001', (SELECT EmployeeID FROM Employee WHERE AccountName = 'Planner'));

--
-- Definition of table `Buyer`
--

DROP TABLE IF EXISTS `Buyer`;
CREATE TABLE `Buyer` (
  `BuyerID` int PRIMARY KEY NOT NULL,
  `EmployeeID` int
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `Buyer`
--

INSERT INTO `Buyer` (`BuyerID`, `EmployeeID`) VALUES
('0001', (SELECT EmployeeID FROM Employee WHERE AccountName = 'Buyer'));


--
-- Definition of table `backupFiles`
--

DROP TABLE IF EXISTS `BackupFileInformation`;
CREATE TABLE `BackupFileInformation` (
  `BackUpID` int PRIMARY KEY NOT NULL,
  `BackUpDirectory` mediumtext,
  `BackUpFileName` mediumtext,
  `BackUpDescription` mediumtext,
  `AdminID` INT
  );

--
-- Dumping data for table `BackUpFiles`
--

INSERT INTO `BackUpFileInformation` (`BackUpID`, `BackUpDirectory`, `BackUpFileName`, `BackUpDescription`, `AdminID`) VALUES
('0001', 'C:/TMSBackUp', 'TmsBackUp.sql', 'Initial Back Up Information', (SELECT AdminID FROM Admin WHERE AdminID = '1'));


--
-- Definition of table `backupFileLog`
--

DROP TABLE IF EXISTS `BackupFileLog`;
CREATE TABLE `BackupFileLog` (
  `BackUpID` int AUTO_INCREMENT PRIMARY KEY NOT NULL ,
  `BackUpDirectory` mediumtext,
  `BackUpFileName` mediumtext,
  `BackUpDescription` mediumtext,
  `BackUpDate` mediumtext,
  `AdminID` INT
  );

--
-- Dumping data for table `BackUpFiles`
--



--
-- Definition of table `GenConfigOptions`
--

DROP TABLE IF EXISTS `GenConfigOptions`;
CREATE TABLE `GenConfigOptions` (
  `GenConfigID` int PRIMARY KEY NOT NULL,
  `AdminID` int,
  `LogDirectory` mediumtext,
  `TargetIPAddress` mediumtext,
  `CommPorts` mediumtext  
);

--
-- Dumping data for table `GenConfigOptions`
--

INSERT INTO `GenConfigOptions` (`GenConfigID`, `AdminID`, `TargetIPAddress`, `CommPorts`) VALUES
('1', (SELECT AdminID FROM Admin WHERE AdminID = '1'), '127.0.0.1', '3306');

--
-- Definition of table `LogFiles`
--

DROP TABLE IF EXISTS `LogFiles`;
CREATE TABLE `LogFiles` (
  `LogFileID` int PRIMARY KEY NOT NULL,
  `AdminID` int,
  `FileName` mediumtext,
  `LoggedDate` mediumtext,
  `LogDirectory` mediumtext,
  `TargetIPAddress` mediumtext,
  `CommPorts` mediumtext  
);


--
-- Dumping data for table `LogFiles`
--

-- TEST DATA TO BE DELETED

INSERT INTO `LogFiles` (`LogFileID`, `AdminID`, `FileName`, `LoggedDate`, `LogDirectory`, `TargetIPAddress`, `CommPorts`) VALUES
('0001', (SELECT AdminID FROM Admin WHERE AdminID = '1'), 'FirstLog.txt', '2019/11/20', 'C:/TMSys', '127.0.01', '3306'),
('0002', (SELECT AdminID FROM Admin WHERE AdminID = '1'), 'SecondLog.txt', '2019/11/21', 'C:/TMSys', '127.0.01', '3306'),
('0003', (SELECT AdminID FROM Admin WHERE AdminID = '1'),'ThirdLog.txt', '2019/11/25', 'C:/TMSys', '127.0.01', '3306'),
('0004', (SELECT AdminID FROM Admin WHERE AdminID = '1'),'FourthLog.txt', '2019/11/30', 'C:/TMSys', '127.0.01', '3306');

-- TEST DATA TO BE DELETED


--
-- Definition of table `CarrierData`
--

DROP TABLE IF EXISTS `CarrierData`;
CREATE TABLE `CarrierData` (
  `CarrierID` int PRIMARY KEY NOT NULL,
  `AdminID` int,
  `CarrierName` mediumtext,
  `DepotCity` mediumtext,
  `FTLAvailability` int,
  `LTLAvailability` int,
  `FTLRate` double,
  `LTLRate` double,
  `ReeferCharge` double
);

--
-- Dumping data for table `CarrierData`
--

INSERT INTO `carrierData` (`CarrierID`,`AdminID`,`CarrierName`, `DepotCity`, `FTLAvailability`, `LTLAvailability`, `FTLRate`, `LTLRate`, `ReeferCharge`) VALUES 
 (0001, (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'Planet Express', 'Windsor', '50', 640, 5.21, 0.3621, 0.08),
 (0002, (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'Planet Express', 'Hamilton', '50', 640, 5.21, 0.3621, 0.08),
 (0003, (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'Planet Express', 'Oshawa', '50', 640, 5.21, 0.3621, 0.08),
 (0004, (SELECT AdminID FROM Admin WHERE AdminID = '0001'),'Planet Express', 'Belleville', '50', 640, 5.21, 0.3621, 0.08),
 (0005, (SELECT AdminID FROM Admin WHERE AdminID = '0001'),'Planet Express', 'Ottawa', '50', 640, 5.21, 0.3621, 0.08),
 (0010, (SELECT AdminID FROM Admin WHERE AdminID = '0001'),'Schooners', 'London', '18', 98, 5.05, 0.3434, 0.07),
 (0011, (SELECT AdminID FROM Admin WHERE AdminID = '0001'),'Schooners', 'Toronto', '18', 98, 5.05, 0.3434, 0.07),
 (0012, (SELECT AdminID FROM Admin WHERE AdminID = '0001'),'Schooners', 'Kingston', '18', 98, 5.05, 0.3434, 0.07),
 (0020, (SELECT AdminID FROM Admin WHERE AdminID = '0001'),'Tillman Transport', 'Windsor', '24', 35, 5.11, 0.3012, 0.09),
 (0021, (SELECT AdminID FROM Admin WHERE AdminID = '0001'),'Tillman Transport', 'London', '18', 45, 5.11, 0.3012, 0.09),
 (0022, (SELECT AdminID FROM Admin WHERE AdminID = '0001'),'Tillman Transport', 'Hamilton', '18', 45, 5.11, 0.3012, 0.09),
 (0030, (SELECT AdminID FROM Admin WHERE AdminID = '0001'),'We Haul', 'Ottawa', '11', 0, 5.2, 0, 0.065),
 (0031, (SELECT AdminID FROM Admin WHERE AdminID = '0001'),'We Haul', 'Toronto', '11', 0, 5.2, 0, 0.065);


--
-- Definition of table `RateFee`
--

DROP TABLE IF EXISTS `RateFee`;
CREATE TABLE `RateFee` (
  `RateFeeID` int PRIMARY KEY NOT NULL,
  `CarrierID` int,
  `CarrierName` mediumtext,
  `AdminID` int,
  `DateUpdated` mediumtext,
  `FTLRate` double,
  `LTLRate` double,
  `ReeferCharge` double,
  `FTLMarkup` double,
  `LTLMarkup` double,
  `FTLTotalCost/KM` double,
  `LTLTotalCost/KM` double
);

--
-- Dumping data for table `RateFee`
--

INSERT INTO `RateFee` (`RateFeeID`, `CarrierID`, `CarrierName`, `AdminID`, `DateUpdated`, `FTLRate`, `LTLRate`, `ReeferCharge`, `FTLMarkup`, `LTLMarkup`, `FTLTotalCost/KM`, `LTLTotalCost/KM`) VALUES
('1', (SELECT CarrierID FROM CarrierData WHERE CarrierID = '0001'), (SELECT CarrierName FROM CarrierData WHERE CarrierID = '0001'), (SELECT AdminID FROM Admin WHERE AdminID = '1'),
'11/29/2019', (SELECT FTLRate FROM CarrierData WHERE CarrierID = '0001'), (SELECT LTLRate FROM CarrierData WHERE CarrierID = '0001'),
(SELECT ReeferCharge FROM CarrierData WHERE CarrierID = '0001'), '0.08', '0.05', (FTLRate * (FTLMarkup + 1)), (LTLRate * (LTLMarkup + 1))),
('2', (SELECT CarrierID FROM CarrierData WHERE CarrierID = '0010'), (SELECT CarrierName FROM CarrierData WHERE CarrierID = '0010'), (SELECT AdminID FROM Admin WHERE AdminID = '1'),
 '11/29/2019', (SELECT FTLRate FROM CarrierData WHERE CarrierID = '0010'), (SELECT LTLRate FROM CarrierData WHERE CarrierID = '0010'),
(SELECT ReeferCharge FROM CarrierData WHERE CarrierID = '0010'), '0.08', '0.05', (FTLRate * (FTLMarkup + 1)), (LTLRate * (LTLMarkup + 1))),
('3', (SELECT CarrierID FROM CarrierData WHERE CarrierID = '0020'), (SELECT CarrierName FROM CarrierData WHERE CarrierID = '0020'), (SELECT AdminID FROM Admin WHERE AdminID = '1'),
 '11/29/2019', (SELECT FTLRate FROM CarrierData WHERE CarrierID = '0020'), (SELECT LTLRate FROM CarrierData WHERE CarrierID = '0020'),
(SELECT ReeferCharge FROM CarrierData WHERE CarrierID = '0020'), '0.08', '0.05', (FTLRate * (FTLMarkup + 1)), (LTLRate * (LTLMarkup + 1))),
('4', (SELECT CarrierID FROM CarrierData WHERE CarrierID = '0030'), (SELECT CarrierName FROM CarrierData WHERE CarrierID = '0030'), (SELECT AdminID FROM Admin WHERE AdminID = '1'),
 '11/29/2019', (SELECT FTLRate FROM CarrierData WHERE CarrierID = '0030'), (SELECT LTLRate FROM CarrierData WHERE CarrierID = '0030'),
(SELECT ReeferCharge FROM CarrierData WHERE CarrierID = '0030'), '0.08', '0.05', (FTLRate * (FTLMarkup + 1)), (LTLRate * (LTLMarkup + 1)));




--
-- Definition of table `Route`
--

DROP TABLE IF EXISTS `Route`;
CREATE TABLE `Route` (
  `RouteID` int PRIMARY KEY NOT NULL,
  `AdminID` int,
  `Destination` mediumtext,
  `Kilometers` mediumtext,
  `TimeInHours` mediumtext,
  `West` mediumtext,
  `East` mediumtext  
);

--
-- Dumping data for table `Route`
--

INSERT INTO `Route` (`RouteID`, `AdminID`, `Destination`, `Kilometers`, `TimeInHours`, `West`, `East`) VALUES
('1', (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'Windsor', '191', '2.5', 'END', 'London'),
('2', (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'London', '128', '1.75', 'Windsor', 'Hamilton'),
('3', (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'Hamilton', '68', '1.25', 'London', 'Toronto'),
('4', (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'Toronto', '60', '1.3', 'Hamilton', 'Oshawa'),
('5', (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'Oshawa', '134', '1.65', 'Toronto', 'Belleville'),
('6', (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'Belleville', '82', '1.2', 'Oshawa', 'Kingston'),
('7', (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'Kingston', '196', '2.5', 'Belleville', 'Ottawa'),
('8', (SELECT AdminID FROM Admin WHERE AdminID = '0001'), 'Ottawa', 'N/A', '', 'Kingston', 'END');

--
-- Definition of table `Invoice`
--

DROP TABLE IF EXISTS `Invoice`;
CREATE TABLE `Invoice` (
  `InvoiceID` int PRIMARY KEY NOT NULL,
  `CarrierID` int,
  `CustomerID` int,
  `Address` mediumtext,
  `City` mediumtext,
  `OrderID` int,
  `Final Price` mediumtext,
  `BuyerID` int
);

--
-- Dumping data for table `Invoice`
--


--
-- Definition of table `Customer`
--

DROP TABLE IF EXISTS `Customer`;
CREATE TABLE `Customer` (
  `CustomerID` int PRIMARY KEY AUTO_INCREMENT NOT NULL,
  `CustomerName` mediumtext,
  `CustomerAddress` mediumtext,
  `CustomerCity` mediumtext,
  `CustomerProvince` mediumtext,
  `CustomerPostalCode` int,
  `CustomerPhone` mediumtext
);

--
-- Dumping data for table `Customer`
--

INSERT INTO `Customer` (`CustomerName`, `CustomerCity`, `CustomerProvince`) VALUES
('Hardware Depot', 'Oshawa', 'Ontario'),
('Malmart', 'Ottawa', 'Ontario'),
('MacDongles', 'Kingston', 'Ontario'),
('Wallys World', 'Belleville', 'Ontario'),
('Sushi Noodle', 'Ottawa', 'Ontario');



--
-- Definition of table `Orders`
--

DROP TABLE IF EXISTS `Orders`;
CREATE TABLE `Orders` (
  `OrderID` int PRIMARY KEY NOT NULL,
  `StartingCityID` int,
  `EndingCityID` int,
  `CarrierID` int,
  `JobType` mediumtext,
  `FTLRate` double,
  `LTLRate` double,  
  `OrderStartDate` mediumtext,
  `OrderCompleteDate` mediumtext,
  `TotalCost` double,
  `Quantity` int,
  `VanType` mediumtext,
  `OrderStatus` mediumtext
);

--
-- Dumping data for table `Orders`
--


INSERT INTO `Orders` (`OrderId`, `StartingCityID`, `EndingCityID`, `CarrierID`, `JobType`, `FTLRate`, `LTLRate`, `OrderStartDate`,`OrderCompleteDate`, `TotalCost`, `Quantity`, `VanType`, `OrderStatus`) VALUES
('1', '1', '7', '1', '0', '5.21', '0', '12-07-2019','12-09-2019', '5000.99', '200', '0', 'Confirmed'),
('2', '3', '7', '4', '0', '5.21', '0', '10-07-2019', '10-08-2019', '2654.99', '103', '0', 'Confirmed');


--
-- Definition of table `City`
--

DROP TABLE IF EXISTS `City`;
CREATE TABLE `City` (
  `CityID` int PRIMARY KEY NOT NULL,
  `CityName` mediumtext
);

--
-- Dumping data for table `City`
--

 INSERT INTO `City` (`CityID`, `CityName`) VALUES
 ('1', 'Windsor'),
 ('2', 'London'),
 ('3', 'Hamilton'),
 ('4', 'Toronto'),
 ('5', 'Oshawa'),
 ('6', 'Belleville'),
 ('7', 'Kingston'),
 ('8', 'Ottawa');


-- ALTER TABLE BackUpFiles

-- ADD Foreign Keys
ALTER TABLE BackupFileInformation 
ADD CONSTRAINT FOREIGN KEY (AdminID)
REFERENCES Admin (AdminID);




-- ALTER TABLE genConfigOptions 

-- ADD Foreign Keys
ALTER TABLE GenConfigOptions 
ADD CONSTRAINT FOREIGN KEY (AdminID)
REFERENCES Admin (AdminID);




-- ALTER TABLE logFiles 

-- ADD Foreign Keys
ALTER TABLE LogFiles 
ADD CONSTRAINT FOREIGN KEY (AdminID)
REFERENCES Admin (AdminID);




-- ALTER TABLE RateFee 

-- ADD Foreign Keys
ALTER TABLE RateFee 
ADD CONSTRAINT FOREIGN KEY (AdminID)
REFERENCES Admin (AdminID);

ALTER TABLE RateFEE
ADD CONSTRAINT FOREIGN KEY (CarrierID)
REFERENCES CarrierData (CarrierID);


-- ALTER TABLE CarrierData 

-- ADD Foreign Keys
ALTER TABLE CarrierData 
ADD CONSTRAINT FOREIGN KEY (AdminID)
REFERENCES Admin (AdminID) ON DELETE CASCADE;




-- ALTER TABLE Route 

-- ADD Foreign Keys
ALTER TABLE Route 
ADD CONSTRAINT FOREIGN KEY (AdminID)
REFERENCES Admin (AdminID);



-- ALTER TABLE Admin 

-- ADD Foreign Keys
ALTER TABLE Admin 
ADD CONSTRAINT FOREIGN KEY (EmployeeID)
REFERENCES Employee (EmployeeID);




-- ALTER TABLE Buyer 

-- ADD Foreign Keys
ALTER TABLE Buyer 
ADD CONSTRAINT FOREIGN KEY (EmployeeID)
REFERENCES Employee (EmployeeID);




-- ALTER TABLE Planner 

-- ADD Foreign Keys
ALTER TABLE Planner 
ADD CONSTRAINT FOREIGN KEY (EmployeeID)
REFERENCES Employee (EmployeeID);




-- ALTER TABLE Invoice 

-- ADD Foreign Keys
ALTER TABLE Invoice 
ADD CONSTRAINT FOREIGN KEY (CarrierID)
REFERENCES CarrierData (CarrierID);

ALTER TABLE Invoice 
ADD CONSTRAINT FOREIGN KEY (CustomerID)
REFERENCES Customer (CustomerID);

ALTER TABLE Invoice 
ADD CONSTRAINT FOREIGN KEY (OrderID)
REFERENCES Orders (OrderID);

ALTER TABLE Invoice 
ADD CONSTRAINT FOREIGN KEY (BuyerID)
REFERENCES Buyer (BuyerID);




-- ALTER TABLE Orders 

-- ADD Foreign Keys
ALTER TABLE Orders 
ADD CONSTRAINT FOREIGN KEY (StartingCityID)
REFERENCES City (CityID);

ALTER TABLE Orders 
ADD CONSTRAINT FOREIGN KEY (CarrierID)
REFERENCES CarrierData (CarrierID);


