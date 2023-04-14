-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 29, 2019 at 12:22 AM
-- Server version: 5.7.24
-- PHP Version: 7.2.14

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `vision_core`
--

-- --------------------------------------------------------

--
-- Table structure for table `container_chain_events`
--

DROP TABLE IF EXISTS `container_chain_events`;
CREATE TABLE IF NOT EXISTS `container_chain_events` (
  `event_unique_id` int(20) NOT NULL AUTO_INCREMENT,
  `container_unique_id` int(20) DEFAULT NULL,
  `container_id` varchar(20) DEFAULT NULL,
  `status` varchar(30) NOT NULL,
  `start_datetime` varchar(30) NOT NULL,
  `stop_datetime` varchar(30) NOT NULL,
  PRIMARY KEY (`event_unique_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `event_alarms`
--

DROP TABLE IF EXISTS `event_alarms`;
CREATE TABLE IF NOT EXISTS `event_alarms` (
  `alarm_unique_id` int(30) NOT NULL AUTO_INCREMENT,
  `process_status` varchar(20) NOT NULL,
  `event_name` varchar(30) NOT NULL,
  `event_type` varchar(30) NOT NULL,
  `status` varchar(30) NOT NULL,
  `event_datetime` varchar(30) NOT NULL,
  `related_unique_id` int(30) NOT NULL,
  `related_data` varchar(30) DEFAULT NULL,
  `debounce_time` int(10) NOT NULL,
  UNIQUE KEY `alarm_unique_id` (`alarm_unique_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `video_files`
--

DROP TABLE IF EXISTS `video_files`;
CREATE TABLE IF NOT EXISTS `video_files` (
  `video_unique_id` int(20) NOT NULL AUTO_INCREMENT,
  `event_unique_id` int(20) NOT NULL,
  `type` varchar(30) NOT NULL,
  `status` varchar(30) NOT NULL,
  `channel_number` int(5) NOT NULL,
  `ftp_url` varchar(300) DEFAULT NULL,
  `file_name` varchar(300) DEFAULT NULL,
  `start_datetime` varchar(30) NOT NULL,
  `end_datetime` varchar(30) NOT NULL,
  PRIMARY KEY (`video_unique_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
