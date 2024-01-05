-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 05, 2024 at 09:29 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_studentattendancesystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `event`
--

CREATE TABLE `event` (
  `EventID` bigint(20) NOT NULL,
  `EventName` varchar(100) NOT NULL,
  `KodeMataKuliah` varchar(100) NOT NULL,
  `venue` varchar(100) NOT NULL,
  `Tanggal` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `event`
--

INSERT INTO `event` (`EventID`, `EventName`, `KodeMataKuliah`, `venue`, `Tanggal`) VALUES
(1, 'PPDE Kontrak Kuliah', 'PPL425302', 'R. 104', '2024-01-03'),
(2, 'DPRP Kuliah 1', 'PSC425403', 'R. 102', '2024-01-02'),
(12, 'Munif', 'COBA', 'R. 103', '2024-01-03'),
(15, 'PPPL Presentasi 1', 'PPL425304', 'Online', '2023-12-23'),
(20, 'Nyoba II', 'COBA', 'R. 305', '2024-01-03');

-- --------------------------------------------------------

--
-- Table structure for table `matakuliah`
--

CREATE TABLE `matakuliah` (
  `KodeMataKuliah` varchar(100) NOT NULL,
  `NamaMataKuliah` varchar(100) NOT NULL,
  `UserID` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `matakuliah`
--

INSERT INTO `matakuliah` (`KodeMataKuliah`, `NamaMataKuliah`, `UserID`) VALUES
('COBA', 'COBA', 1234),
('MATKUL', 'MATKUL', 1234),
('PPL425302', 'Pemrograman Platform Desktop dan Embedded', 198603062011011009),
('PPL425304', 'Perancangan dan Pembangunan Perangkat Lunak', 197701032005011003),
('PPL425305', 'Penjaminan Kualitas Perangkat Lunak', 197701032005011003),
('PSC425403', 'Dasar Penalaran dan Representasi Pengetahuan', 197801062002122001);

-- --------------------------------------------------------

--
-- Table structure for table `presensi`
--

CREATE TABLE `presensi` (
  `PresensiID` bigint(20) NOT NULL,
  `UserID` bigint(20) NOT NULL,
  `EventID` bigint(100) NOT NULL,
  `Kehadiran` tinyint(1) NOT NULL,
  `waktu` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `presensi`
--

INSERT INTO `presensi` (`PresensiID`, `UserID`, `EventID`, `Kehadiran`, `waktu`) VALUES
(3, 21106050006, 1, 2, '2024-01-02 11:39:42'),
(4, 21106050001, 2, 3, '2024-01-01 23:41:54'),
(5, 21106050006, 12, 1, '2024-01-01 23:22:23'),
(7, 21106050001, 15, 1, '2024-01-01 23:42:27'),
(12, 21106050006, 20, 1, '2024-01-03 10:10:47');

-- --------------------------------------------------------

--
-- Table structure for table `role_value`
--

CREATE TABLE `role_value` (
  `Role` int(1) NOT NULL,
  `job` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `role_value`
--

INSERT INTO `role_value` (`Role`, `job`) VALUES
(1, 'Administrator'),
(2, 'Lecturer'),
(3, 'Student');

-- --------------------------------------------------------

--
-- Table structure for table `status`
--

CREATE TABLE `status` (
  `Kehadiran` tinyint(6) NOT NULL,
  `keterangan` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `status`
--

INSERT INTO `status` (`Kehadiran`, `keterangan`) VALUES
(1, 'Present'),
(2, 'Permission'),
(3, 'Medical Leave'),
(4, 'Absent');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `UserID` bigint(20) NOT NULL,
  `Role` int(1) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Nama` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`UserID`, `Role`, `Email`, `Password`, `Nama`) VALUES
(123, 2, 'dosen@dosen.com', '10bd0c68fcf7c923c781e2e5fbd8cc052b126949eda28de48de758ad58f084cf', 'dosen'),
(1234, 2, 'anjay@anjay.com', '7306601c15e2d0586a1b022a3acde820647ad509127e058123034660686ae164', 'anjay'),
(12345, 1, 'bintang@bintang.com', '15964f639ea2c22614ee4f19aed1ad4461cf65672c9de7158b8b62210d83aeb9', 'bintang'),
(30112023, 1, 'admin@admin.com', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'admin'),
(21106050001, 3, '21106050001@student.uin-suka.ac.id', '3be9a2f1ad2736a9d6380d56440d3ce3ac30d6ce31804ffd85f341c7f7abf145', 'Hikmah Nursidik'),
(21106050006, 3, '21106050006@student.uin-suka.ac.id', '12c3685f48007d522c86eb60f33a7884924583c670a52b0f1ed519d37630a0ab', 'Rahma Bintang Pratama'),
(21106050046, 3, '21106050046@student.uin-suka.ac.id', 'e3d994381e10b96c7bee44fa7cbae37ac8df0cd8cebdc3ade73b8797ed5e7473', 'Muhammad Hafiz'),
(21106050047, 3, '21106050047@student.uin-suka.ac.id', '7e57da2cce93809ed9587aefa3eee84cfe40994918eb23e32a967a2e14009489', 'Ibnu Raju Humam'),
(197701032005011003, 2, 'agung.fatwanto@uin-suka.ac.id', '77444d0dd54f1c088a902282255ddf8472c8f5385540262547814efe7ffb384c', 'Dr. Agung Fatwanto, S.Si., M.Kom.'),
(197801062002122001, 2, 'maria.siregar@uin-suka.ac.id', '87ecb5bd6ea5d929a0ef9e109260222812cbf0e8946bd0868b54bf6a02cf38bf', 'Ir. Maria Ulfah Siregar, S.Kom., MIT., Ph.D.'),
(198603062011011009, 2, 'aulia.faqih@uin-suka.ac.id', 'bf203326bb2da40daa3f4f1bdeb0a144667d88f576d550a63f0a1e450aa885dd', 'Ir. Aulia Faqih Rifa\'i, M.Kom.');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `event`
--
ALTER TABLE `event`
  ADD PRIMARY KEY (`EventID`),
  ADD KEY `fk_event_mk_kodemk` (`KodeMataKuliah`);

--
-- Indexes for table `matakuliah`
--
ALTER TABLE `matakuliah`
  ADD PRIMARY KEY (`KodeMataKuliah`),
  ADD KEY `fk_mk_user_userid` (`UserID`);

--
-- Indexes for table `presensi`
--
ALTER TABLE `presensi`
  ADD PRIMARY KEY (`PresensiID`),
  ADD KEY `fk_presensi_user_userid` (`UserID`),
  ADD KEY `fk_presensi_event_eventid` (`EventID`),
  ADD KEY `fk_presensi_status_kehadiran` (`Kehadiran`);

--
-- Indexes for table `role_value`
--
ALTER TABLE `role_value`
  ADD PRIMARY KEY (`Role`);

--
-- Indexes for table `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`Kehadiran`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`UserID`),
  ADD KEY `fk_user_roleValue_job` (`Role`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `event`
--
ALTER TABLE `event`
  MODIFY `EventID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `presensi`
--
ALTER TABLE `presensi`
  MODIFY `PresensiID` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `event`
--
ALTER TABLE `event`
  ADD CONSTRAINT `fk_event_mk_kodemk` FOREIGN KEY (`KodeMataKuliah`) REFERENCES `matakuliah` (`KodeMataKuliah`) ON UPDATE CASCADE;

--
-- Constraints for table `matakuliah`
--
ALTER TABLE `matakuliah`
  ADD CONSTRAINT `fk_mk_user_userid` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON UPDATE CASCADE;

--
-- Constraints for table `presensi`
--
ALTER TABLE `presensi`
  ADD CONSTRAINT `fk_presensi_event_eventid` FOREIGN KEY (`EventID`) REFERENCES `event` (`EventID`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_presensi_status_kehadiran` FOREIGN KEY (`Kehadiran`) REFERENCES `status` (`Kehadiran`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_presensi_user_userid` FOREIGN KEY (`UserID`) REFERENCES `user` (`UserID`) ON UPDATE CASCADE;

--
-- Constraints for table `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `fk_user_roleValue_job` FOREIGN KEY (`Role`) REFERENCES `role_value` (`Role`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
