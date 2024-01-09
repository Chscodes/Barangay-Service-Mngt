-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 06, 2023 at 03:50 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.1.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_brgypotrero`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `col_ID` int(11) NOT NULL,
  `col_admin_Uname` varchar(20) NOT NULL,
  `col_admin_pass` varchar(20) NOT NULL,
  `col_admin_name` varchar(50) NOT NULL,
  `col_admin_email` varchar(50) NOT NULL,
  `col_admin_bday` date NOT NULL,
  `_dateTime` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_ctzn`
--

CREATE TABLE `tbl_ctzn` (
  `ctzn_ID` int(11) NOT NULL,
  `ctzn_col_uname` varchar(50) NOT NULL,
  `ctzn_col_pass` varchar(50) NOT NULL,
  `ctzn_col_fname` varchar(20) NOT NULL,
  `ctzn_col_mname` varchar(20) DEFAULT NULL,
  `ctzn_col_lname` varchar(20) NOT NULL,
  `ctzn_col_bday` date NOT NULL,
  `ctzn_col_gender` varchar(6) NOT NULL,
  `ctzn_col_email` varchar(50) NOT NULL,
  `ctzn_col_addrss_Hnum` int(3) NOT NULL,
  `col_ctzn_addrss_street` varchar(50) NOT NULL,
  `col_ctzn_addrss_city` varchar(100) NOT NULL,
  `_datetime` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_docsreq`
--

CREATE TABLE `tbl_docsreq` (
  `ID` int(11) NOT NULL,
  `ctzn_col_vouch` longblob NOT NULL,
  `ctzn_col_ctznPIC` longblob NOT NULL,
  `col_rqstDOC_lname` varchar(30) NOT NULL,
  `col_rqstDOC_fname` varchar(30) NOT NULL,
  `col_rqstDOC_mname` varchar(30) NOT NULL,
  `col_rqstDOC_address` varchar(100) NOT NULL,
  `col_rqstDOC_year` varchar(11) NOT NULL,
  `col_rqstDOC_cnum` bigint(20) NOT NULL,
  `col_rqstDOC_ctznshp` varchar(20) NOT NULL,
  `col_rqstDOC_bday` date NOT NULL,
  `col_rqstDOC_pday` varchar(100) NOT NULL,
  `col_rqstDOC_spouse` varchar(50) NOT NULL,
  `col_rqstDOC_childrens` varchar(150) NOT NULL,
  `col_rqstDOC_residency` varchar(50) NOT NULL,
  `col_rqstDOC_gender` varchar(6) NOT NULL,
  `col_rqstDOC_status` varchar(10) NOT NULL,
  `col_rqstDOC_docsType` varchar(50) NOT NULL,
  `col_rqstDOC_purpose` varchar(30) NOT NULL,
  `col_rqstDOC_action` varchar(10) NOT NULL,
  `col_ctzn_requname` varchar(20) NOT NULL,
  `col_req_refNum` varchar(100) NOT NULL,
  `_datetime` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_docs_declined`
--

CREATE TABLE `tbl_docs_declined` (
  `ID` int(11) NOT NULL,
  `col_reqID` int(11) NOT NULL,
  `col_action` varchar(20) NOT NULL,
  `col_remarks` varchar(100) NOT NULL,
  `_dateTime` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_docs_pickup`
--

CREATE TABLE `tbl_docs_pickup` (
  `col_ID` int(11) NOT NULL,
  `col_req_ID` int(11) NOT NULL,
  `col_action` varchar(50) NOT NULL,
  `_datetime` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_docs_processing`
--

CREATE TABLE `tbl_docs_processing` (
  `col_ID` int(11) NOT NULL,
  `col_reqID` int(11) NOT NULL,
  `col_action` varchar(20) NOT NULL,
  `_datetime` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_docs_settled`
--

CREATE TABLE `tbl_docs_settled` (
  `col_ID` int(11) NOT NULL,
  `col_req_ID` int(11) NOT NULL,
  `col_validation` date NOT NULL,
  `_datetime` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_docu`
--

CREATE TABLE `tbl_docu` (
  `ID` int(11) NOT NULL,
  `col_Doc_name` varchar(50) NOT NULL,
  `col_Price` float NOT NULL,
  `col_availability` varchar(50) NOT NULL,
  `col_Description` varchar(100) NOT NULL,
  `_datetime` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_logs`
--

CREATE TABLE `tbl_logs` (
  `ID` int(11) NOT NULL,
  `col_uname` varchar(20) NOT NULL,
  `col_desc` varchar(300) NOT NULL,
  `_datetime` date NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_resident`
--

CREATE TABLE `tbl_resident` (
  `col_ID` int(11) NOT NULL,
  `col_rsdnt_lname` varchar(50) NOT NULL,
  `col_rsdnt_fname` varchar(50) NOT NULL,
  `col_rsdnt_mname` varchar(50) NOT NULL,
  `col_rsdnt_address` varchar(100) NOT NULL,
  `col_rsdnt_residency` varchar(50) NOT NULL,
  `col_rsdnt_year` int(3) NOT NULL,
  `col_rsdnt_gender` varchar(6) NOT NULL,
  `col_rsdnt_cnum` bigint(20) NOT NULL,
  `col_rsdnt_ctznshp` varchar(20) NOT NULL,
  `col_rsdnt_bday` date NOT NULL,
  `col_rsdnt_pday` varchar(20) NOT NULL,
  `col_rsdnt_status` varchar(10) NOT NULL,
  `col_rsdnt_health` varchar(10) NOT NULL,
  `col_rsdnt_spouse` varchar(50) NOT NULL,
  `col_rsdnt_childrens` varchar(100) NOT NULL,
  `col_rsdnt_purpose` varchar(50) NOT NULL,
  `col_rsdnt_Rname` varchar(20) NOT NULL,
  `col_rsdnt_Rcnum` bigint(20) NOT NULL,
  `col_rsdnt_Radd` varchar(100) NOT NULL,
  `_datetime` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  ADD PRIMARY KEY (`col_ID`),
  ADD UNIQUE KEY `col_admin_Uname` (`col_admin_Uname`);

--
-- Indexes for table `tbl_ctzn`
--
ALTER TABLE `tbl_ctzn`
  ADD PRIMARY KEY (`ctzn_ID`),
  ADD UNIQUE KEY `ctzn_col_uname` (`ctzn_col_uname`),
  ADD UNIQUE KEY `ctzn_col_email` (`ctzn_col_email`);

--
-- Indexes for table `tbl_docsreq`
--
ALTER TABLE `tbl_docsreq`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_docs_declined`
--
ALTER TABLE `tbl_docs_declined`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_docs_pickup`
--
ALTER TABLE `tbl_docs_pickup`
  ADD PRIMARY KEY (`col_ID`);

--
-- Indexes for table `tbl_docs_processing`
--
ALTER TABLE `tbl_docs_processing`
  ADD PRIMARY KEY (`col_ID`);

--
-- Indexes for table `tbl_docs_settled`
--
ALTER TABLE `tbl_docs_settled`
  ADD PRIMARY KEY (`col_ID`);

--
-- Indexes for table `tbl_docu`
--
ALTER TABLE `tbl_docu`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_logs`
--
ALTER TABLE `tbl_logs`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `tbl_resident`
--
ALTER TABLE `tbl_resident`
  ADD PRIMARY KEY (`col_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  MODIFY `col_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_ctzn`
--
ALTER TABLE `tbl_ctzn`
  MODIFY `ctzn_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_docsreq`
--
ALTER TABLE `tbl_docsreq`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_docs_declined`
--
ALTER TABLE `tbl_docs_declined`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_docs_pickup`
--
ALTER TABLE `tbl_docs_pickup`
  MODIFY `col_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_docs_processing`
--
ALTER TABLE `tbl_docs_processing`
  MODIFY `col_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_docs_settled`
--
ALTER TABLE `tbl_docs_settled`
  MODIFY `col_ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_docu`
--
ALTER TABLE `tbl_docu`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_logs`
--
ALTER TABLE `tbl_logs`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_resident`
--
ALTER TABLE `tbl_resident`
  MODIFY `col_ID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
