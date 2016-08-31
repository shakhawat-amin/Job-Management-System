-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Mar 30, 2016 at 02:52 AM
-- Server version: 10.1.9-MariaDB
-- PHP Version: 5.6.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `job_management_two`
--

-- --------------------------------------------------------

--
-- Table structure for table `education`
--

CREATE TABLE `education` (
  `id_education` bigint(20) NOT NULL,
  `id_employee` bigint(20) NOT NULL,
  `degree_name` varchar(50) DEFAULT NULL,
  `score` decimal(4,2) DEFAULT NULL,
  `scale` decimal(4,2) DEFAULT NULL,
  `passing_year` timestamp NULL DEFAULT NULL,
  `institute_name` varchar(150) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `education`
--

INSERT INTO `education` (`id_education`, `id_employee`, `degree_name`, `score`, `scale`, `passing_year`, `institute_name`) VALUES
(2, 3, 'hsc', '5.00', '5.00', NULL, 'MIT'),
(4, 3, 'ssc', '5.00', '5.00', NULL, 'govt: science'),
(5, 6, 'hsc', '5.00', '5.00', NULL, 'adfafg'),
(6, 1, 'ssc', '5.00', '5.00', NULL, 'badda alatunnesa higher secondary school'),
(7, 1, 'hsc', '5.00', '5.00', NULL, 'adfafd');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `id_employee` bigint(20) NOT NULL,
  `id_user` bigint(20) NOT NULL,
  `age` int(3) DEFAULT NULL,
  `sex` varchar(20) DEFAULT NULL,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `father_name` varchar(45) DEFAULT NULL,
  `mother_name` varchar(45) DEFAULT NULL,
  `contact_number` varchar(45) DEFAULT NULL,
  `local_address` varchar(45) DEFAULT NULL,
  `parmanent_address` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`id_employee`, `id_user`, `age`, `sex`, `first_name`, `last_name`, `father_name`, `mother_name`, `contact_number`, `local_address`, `parmanent_address`) VALUES
(1, 1, 23, 'male', 'shakhawat', 'amin', 'lutfor rahman', 'sanowara begum', '01926238182', 'aldkf', 'aldkjfljdf'),
(2, 2, 23, 'male', 'shakhawat', 'amin', 'alkdf', 'ldkajf', 'ldakfjald', 'adkfj', 'aldkfj'),
(3, 3, 12, 'female', 'asdf', 'adfdf;k', ';dlfk;dflk', ';asdlkf;fdk', '20120301230', ';lkdasf;lkdf', ';ld;fks;'),
(4, 16, 23, 'male', 'adfdfrg', 'eghh', NULL, NULL, '23123213123', 'fjfjf', 'kdfkad'),
(5, 20, 20, 'male', 'af', 'df.,/.,al;k', ';adlkf;lkf', ';peoirpeori', '01926235454', 'pofiporepor', 'porieporpeoi'),
(6, 21, 22, 'male', 's', 'h', 'u', 'v', '01234567890', 'asd', 'asdff');

-- --------------------------------------------------------

--
-- Table structure for table `employeer`
--

CREATE TABLE `employeer` (
  `id_employeer` bigint(20) NOT NULL,
  `id_user` bigint(20) NOT NULL,
  `office_name` varchar(45) DEFAULT NULL,
  `contact_number` varchar(45) DEFAULT NULL,
  `office_address` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employeer`
--

INSERT INTO `employeer` (`id_employeer`, `id_user`, `office_name`, `contact_number`, `office_address`) VALUES
(1, 4, 'boss boss boss^2', '01920123123', 'office address ki lagbei?'),
(2, 7, 'lkfdjalfkj', 'lkdjfdalfj', 'ldskfjldfkj'),
(3, 17, 'officer''s club', '01926238182', 'adfdfadfdf'),
(4, 18, 'aldkfjadf', 'aldkfjaldfkj', 'a;lkdfjadlfkj'),
(5, 19, 'officer''s club', '12312312312', 'a;lsdkf');

-- --------------------------------------------------------

--
-- Table structure for table `employee_tag`
--

CREATE TABLE `employee_tag` (
  `id_employee_tag` bigint(20) NOT NULL,
  `tag_name` varchar(45) DEFAULT NULL,
  `id_employee` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee_tag`
--

INSERT INTO `employee_tag` (`id_employee_tag`, `tag_name`, `id_employee`) VALUES
(1, 'java', 1),
(2, 'c#', 1);

-- --------------------------------------------------------

--
-- Table structure for table `job_applicant`
--

CREATE TABLE `job_applicant` (
  `id_job_applicant` bigint(20) NOT NULL,
  `id_employee` bigint(20) DEFAULT NULL,
  `id_job_circular` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `job_applied`
--

CREATE TABLE `job_applied` (
  `id_job_applied` bigint(20) NOT NULL,
  `id_employee` bigint(20) NOT NULL,
  `id_job_circular` bigint(20) NOT NULL,
  `status` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `job_circular`
--

CREATE TABLE `job_circular` (
  `id_job_circular` bigint(20) NOT NULL,
  `title` varchar(100) NOT NULL,
  `salary` varchar(20) DEFAULT NULL,
  `deadline` datetime NOT NULL,
  `experience` int(11) DEFAULT NULL,
  `vacancy` int(11) DEFAULT NULL,
  `id_employeer` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `job_circular_tag`
--

CREATE TABLE `job_circular_tag` (
  `id_job_circular_tag` bigint(20) NOT NULL,
  `tag_name` varchar(45) DEFAULT NULL,
  `id_job_circular` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `job_circular_tag`
--

INSERT INTO `job_circular_tag` (`id_job_circular_tag`, `tag_name`, `id_job_circular`) VALUES
(1, 'c#', NULL),
(2, 'c#', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `id_user` bigint(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(128) NOT NULL,
  `user_role` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id_user`, `email`, `username`, `password`, `user_role`) VALUES
(1, 's.shakhawat.amin@gmail.com', 'shantim', '123', 'jobseeker'),
(2, 's.ashs@gmail.co', 'shantim1', '123', 'jobseeker'),
(3, 'adf@aldskfj.com', 'nebir', '123', 'jobseeker'),
(4, 'boss420@yahoo.com', 'boss', '1231234', 'employeer'),
(7, 'aldfkj@a.com', 'sh', 'lkfjaldkjf', 'employeer'),
(16, 'adfad@gmail.com', 'adfadf', '123', 'jobseeker'),
(17, 'asd@asfldfj.com', 'eshantim', '123', 'employeer'),
(18, 's.sha@gmail.com', 'shantimE', '123', 'employeer'),
(19, 's.shakhawat.adfamin@gmail.com', 'arnob', 'hfbrnu234', 'employeer'),
(20, 'sf@asdf.com', 'shuvo', '123123', 'jobseeker'),
(21, 'shuvo012@a.com', 'tarmim', '1234', 'jobseeker');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `education`
--
ALTER TABLE `education`
  ADD PRIMARY KEY (`id_education`),
  ADD KEY `id_employee_education_fk_idx` (`id_employee`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`id_employee`),
  ADD KEY `id_user_employee_fk_idx` (`id_user`);

--
-- Indexes for table `employeer`
--
ALTER TABLE `employeer`
  ADD PRIMARY KEY (`id_employeer`),
  ADD KEY `fk_table1_user1_idx` (`id_user`);

--
-- Indexes for table `employee_tag`
--
ALTER TABLE `employee_tag`
  ADD PRIMARY KEY (`id_employee_tag`),
  ADD KEY `id_tag_employee_fk_idx` (`id_employee`);

--
-- Indexes for table `job_applicant`
--
ALTER TABLE `job_applicant`
  ADD PRIMARY KEY (`id_job_applicant`),
  ADD KEY `id_job_applicant_job_circular_fk_idx` (`id_job_circular`),
  ADD KEY `id_job_applicant_employee_fk_idx` (`id_employee`);

--
-- Indexes for table `job_applied`
--
ALTER TABLE `job_applied`
  ADD PRIMARY KEY (`id_job_applied`),
  ADD KEY `fk_job_applied_employee1_idx` (`id_employee`),
  ADD KEY `fk_job_applied_job_circular1_idx` (`id_job_circular`);

--
-- Indexes for table `job_circular`
--
ALTER TABLE `job_circular`
  ADD PRIMARY KEY (`id_job_circular`),
  ADD KEY `fk_job_circular_employeer1_idx` (`id_employeer`);

--
-- Indexes for table `job_circular_tag`
--
ALTER TABLE `job_circular_tag`
  ADD PRIMARY KEY (`id_job_circular_tag`),
  ADD KEY `id_tag_job_circular_fk_idx` (`id_job_circular`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id_user`),
  ADD UNIQUE KEY `email_UNIQUE` (`email`),
  ADD UNIQUE KEY `username_UNIQUE` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `education`
--
ALTER TABLE `education`
  MODIFY `id_education` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `id_employee` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `employeer`
--
ALTER TABLE `employeer`
  MODIFY `id_employeer` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `employee_tag`
--
ALTER TABLE `employee_tag`
  MODIFY `id_employee_tag` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `job_applicant`
--
ALTER TABLE `job_applicant`
  MODIFY `id_job_applicant` bigint(20) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `job_circular_tag`
--
ALTER TABLE `job_circular_tag`
  MODIFY `id_job_circular_tag` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT for table `user`
--
ALTER TABLE `user`
  MODIFY `id_user` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
--
-- Constraints for dumped tables
--

--
-- Constraints for table `education`
--
ALTER TABLE `education`
  ADD CONSTRAINT `id_employee_education_fk` FOREIGN KEY (`id_employee`) REFERENCES `employee` (`id_employee`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `employee`
--
ALTER TABLE `employee`
  ADD CONSTRAINT `id_user_employee_fk` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `employeer`
--
ALTER TABLE `employeer`
  ADD CONSTRAINT `fk_table1_user1` FOREIGN KEY (`id_user`) REFERENCES `user` (`id_user`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `employee_tag`
--
ALTER TABLE `employee_tag`
  ADD CONSTRAINT `id_tag_employee_fk` FOREIGN KEY (`id_employee`) REFERENCES `employee` (`id_employee`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `job_applicant`
--
ALTER TABLE `job_applicant`
  ADD CONSTRAINT `id_job_applicant_employee_fk` FOREIGN KEY (`id_employee`) REFERENCES `employee` (`id_employee`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `id_job_applicant_job_circular_fk` FOREIGN KEY (`id_job_circular`) REFERENCES `job_circular` (`id_job_circular`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `job_applied`
--
ALTER TABLE `job_applied`
  ADD CONSTRAINT `fk_job_applied_employee1` FOREIGN KEY (`id_employee`) REFERENCES `employee` (`id_employee`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_job_applied_job_circular1` FOREIGN KEY (`id_job_circular`) REFERENCES `job_circular` (`id_job_circular`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `job_circular`
--
ALTER TABLE `job_circular`
  ADD CONSTRAINT `fk_job_circular_employeer1` FOREIGN KEY (`id_employeer`) REFERENCES `employeer` (`id_employeer`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `job_circular_tag`
--
ALTER TABLE `job_circular_tag`
  ADD CONSTRAINT `id_tag_job_circular_fk` FOREIGN KEY (`id_job_circular`) REFERENCES `job_circular` (`id_job_circular`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
