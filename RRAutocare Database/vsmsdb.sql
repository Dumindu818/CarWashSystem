-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 08, 2022 at 03:01 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 8.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `vsmsdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbladmin`
--

CREATE TABLE `tbladmin` (
  `ID` int(5) NOT NULL,
  `AdminName` varchar(120) DEFAULT NULL,
  `AdminuserName` varchar(120) DEFAULT NULL,
  `MobileNumber` bigint(10) DEFAULT NULL,
  `Email` varchar(120) DEFAULT NULL,
  `Password` varchar(120) DEFAULT NULL,
  `AdminRegdate` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbladmin`
--

INSERT INTO `tbladmin` (`ID`, `AdminName`, `AdminuserName`, `MobileNumber`, `Email`, `Password`, `AdminRegdate`) VALUES
(2, 'Dumindu de Silva', 'dumindu', 768070831, 'dumindudesilva1@gmail.com', 'dumindu123', '2022-11-03 07:58:11');

-- --------------------------------------------------------

--
-- Table structure for table `tblcashiers`
--

CREATE TABLE `tblcashiers` (
  `ID` int(11) NOT NULL,
  `FullName` varchar(120) DEFAULT NULL,
  `MobileNumber` bigint(20) DEFAULT NULL,
  `Email` varchar(120) DEFAULT NULL,
  `Address` varchar(120) DEFAULT NULL,
  `Password` varchar(50) NOT NULL,
  `CashieruserName` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblcashiers`
--

INSERT INTO `tblcashiers` (`ID`, `FullName`, `MobileNumber`, `Email`, `Address`, `Password`, `CashieruserName`) VALUES
(9, 'dumindu', 768070831, 'dumindu@gmail.com', 'Galle', 'dumindu123', 'dumindu'),
(12, 'Sapni Ranchagoda', 778899001, 'saapni@gmail.com', 'Galle', 'sapni123', 'sapni');

-- --------------------------------------------------------

--
-- Table structure for table `tblcategory`
--

CREATE TABLE `tblcategory` (
  `ID` int(11) NOT NULL,
  `VehicleCat` varchar(120) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblcategory`
--

INSERT INTO `tblcategory` (`ID`, `VehicleCat`) VALUES
(18, 'Cut & Polish'),
(21, 'EFI Tuning'),
(16, 'Full Service'),
(15, 'Interior Washing'),
(14, 'Oil Change & Lube Service'),
(19, 'Running Repairs'),
(20, 'Underbody Treatment'),
(17, 'Vehicle Wash');

-- --------------------------------------------------------

--
-- Table structure for table `tblenquiry`
--

CREATE TABLE `tblenquiry` (
  `ID` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `EnquiryNumber` varchar(120) NOT NULL,
  `EnquiryType` varchar(120) DEFAULT NULL,
  `Description` varchar(250) DEFAULT NULL,
  `EnquiryDate` timestamp NULL DEFAULT current_timestamp(),
  `AdminResponse` varchar(250) DEFAULT NULL,
  `AdminStatus` int(11) DEFAULT NULL,
  `AdminRemarkdate` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblenquiry`
--

INSERT INTO `tblenquiry` (`ID`, `UserId`, `EnquiryNumber`, `EnquiryType`, `Description`, `EnquiryDate`, `AdminResponse`, `AdminStatus`, `AdminRemarkdate`) VALUES
(6, 14, '364765545', 'Price Related Enquiry', 'kjljlkjkjj', '2021-12-24 03:42:35', '', 0, '2021-12-24 03:42:35'),
(8, 16, '941405798', 'Price Related Enquiry', 'Price is too high.', '2022-11-07 14:55:00', 'ha ha hari hari', 1, '2022-11-07 14:55:00'),
(9, 17, '708118220', 'Parts Related Enquiry', 'low quality', '2022-11-08 12:50:35', 'lol', 1, '2022-11-08 12:50:35');

-- --------------------------------------------------------

--
-- Table structure for table `tblenquirytype`
--

CREATE TABLE `tblenquirytype` (
  `ID` int(11) NOT NULL,
  `EnquiryType` varchar(120) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblenquirytype`
--

INSERT INTO `tblenquirytype` (`ID`, `EnquiryType`) VALUES
(4, 'Other Enquiry'),
(3, 'Parts Related Enquiry'),
(2, 'Price Related Enquiry'),
(1, 'Service Related Enquiry');

-- --------------------------------------------------------

--
-- Table structure for table `tblservicerequest`
--

CREATE TABLE `tblservicerequest` (
  `ID` int(10) NOT NULL,
  `UserId` int(11) DEFAULT NULL,
  `ServiceNumber` char(20) NOT NULL,
  `Category` varchar(120) DEFAULT NULL,
  `VehicleName` varchar(120) DEFAULT NULL,
  `VehicleModel` varchar(120) DEFAULT NULL,
  `VehicleBrand` varchar(120) DEFAULT NULL,
  `VehicleRegno` varchar(120) DEFAULT NULL,
  `ServiceDate` date DEFAULT NULL,
  `ServiceTime` varchar(100) DEFAULT NULL,
  `DeliveryType` varchar(120) DEFAULT NULL,
  `PickupAddress` varchar(120) DEFAULT NULL,
  `ServicerequestDate` timestamp NULL DEFAULT current_timestamp(),
  `ServiceBy` varchar(120) DEFAULT NULL,
  `ServiceCharge` int(10) DEFAULT NULL,
  `PartsCharge` int(10) DEFAULT NULL,
  `OtherCharge` int(10) DEFAULT NULL,
  `AdminRemark` varchar(120) DEFAULT NULL,
  `AdminStatus` varchar(120) DEFAULT NULL,
  `AdminRemarkdate` timestamp NULL DEFAULT NULL ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblservicerequest`
--

INSERT INTO `tblservicerequest` (`ID`, `UserId`, `ServiceNumber`, `Category`, `VehicleName`, `VehicleModel`, `VehicleBrand`, `VehicleRegno`, `ServiceDate`, `ServiceTime`, `DeliveryType`, `PickupAddress`, `ServicerequestDate`, `ServiceBy`, `ServiceCharge`, `PartsCharge`, `OtherCharge`, `AdminRemark`, `AdminStatus`, `AdminRemarkdate`) VALUES
(42, 0, '890498081', 'Body Wash', 'gfrs', 'sfdv', 'bsfb', 'sfb', '2022-11-17', '21:46', 'pickupservice', 'vdsvs', '2022-11-08 08:24:22', 'dumindu', 3566, 4355, 453, 'bdsb', '3', '2022-11-08 08:24:28'),
(43, 0, '992177868', 'Cut & Polish', 'dh', 'wrgs', 'rgsw', 'rwsg', '2022-11-18', '11:00', 'pickupservice', 'reqf', '2022-11-08 08:32:40', 'dumindu', 1000, 1000, 1000, 'dsf', '3', '2022-11-08 08:32:50'),
(44, 0, '358363883', 'Cut & Polish', 'wegw', 'fewfg', 'ef', 'fef', '2022-11-17', '10:00', 'dropservice', NULL, '2022-11-08 08:33:17', 'dumindu', 1444, 444, 44, 'wfweqf', '3', '2022-11-08 08:33:25'),
(45, 17, '692936787', 'Cut & Polish', 'honda', 'tucson', '211', 'CAA-0009', '2022-11-09', '13:19', 'pickupservice', 'colombo', '2022-11-08 12:47:30', 'dumindu', 8000, 100, 500, 'completed', '3', '2022-11-08 12:54:54'),
(46, 17, '679006661', 'EFI Tuning', 'honda', 'fit', '211', 'CAA-0009', '2022-11-09', '22:29', 'pickupservice', 'colombo', '2022-11-08 12:59:31', 'dumindu', 900, 100, 1000, 'completed', '3', '2022-11-08 13:00:13');

-- --------------------------------------------------------

--
-- Table structure for table `tbluser`
--

CREATE TABLE `tbluser` (
  `ID` int(11) NOT NULL,
  `FullName` varchar(120) DEFAULT NULL,
  `MobileNo` bigint(10) DEFAULT NULL,
  `Email` varchar(120) DEFAULT NULL,
  `Password` varchar(120) DEFAULT NULL,
  `RegDate` timestamp NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbluser`
--

INSERT INTO `tbluser` (`ID`, `FullName`, `MobileNo`, `Email`, `Password`, `RegDate`) VALUES
(17, 'siumi', 771234856, 'siumi@gmail.com', '46bfb1c2a69817913a895bf6679e97b5', '2022-11-08 12:46:12');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbladmin`
--
ALTER TABLE `tbladmin`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tblcashiers`
--
ALTER TABLE `tblcashiers`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `FullName` (`FullName`);

--
-- Indexes for table `tblcategory`
--
ALTER TABLE `tblcategory`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `VehicleCat` (`VehicleCat`);

--
-- Indexes for table `tblenquiry`
--
ALTER TABLE `tblenquiry`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `eqtype` (`EnquiryType`);

--
-- Indexes for table `tblenquirytype`
--
ALTER TABLE `tblenquirytype`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `EnquiryType` (`EnquiryType`);

--
-- Indexes for table `tblservicerequest`
--
ALTER TABLE `tblservicerequest`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbluser`
--
ALTER TABLE `tbluser`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbladmin`
--
ALTER TABLE `tbladmin`
  MODIFY `ID` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tblcashiers`
--
ALTER TABLE `tblcashiers`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `tblcategory`
--
ALTER TABLE `tblcategory`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT for table `tblenquiry`
--
ALTER TABLE `tblenquiry`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `tblenquirytype`
--
ALTER TABLE `tblenquirytype`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT for table `tblservicerequest`
--
ALTER TABLE `tblservicerequest`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- AUTO_INCREMENT for table `tbluser`
--
ALTER TABLE `tbluser`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tblenquiry`
--
ALTER TABLE `tblenquiry`
  ADD CONSTRAINT `eqtype` FOREIGN KEY (`EnquiryType`) REFERENCES `tblenquirytype` (`EnquiryType`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
