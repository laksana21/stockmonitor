-- MySQL dump 10.13  Distrib 8.2.0, for Win64 (x86_64)
--
-- Host: localhost    Database: stock_data_warehouse
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.32-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tb_item_category`
--

DROP TABLE IF EXISTS `tb_item_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_item_category` (
  `id` varchar(50) NOT NULL,
  `category_name` text NOT NULL,
  `user_add` varchar(50) NOT NULL,
  `user_update` varchar(50) NOT NULL,
  `date_add` datetime NOT NULL,
  `date_update` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_item_category`
--

LOCK TABLES `tb_item_category` WRITE;
/*!40000 ALTER TABLE `tb_item_category` DISABLE KEYS */;
INSERT INTO `tb_item_category` VALUES ('202412020001','Food','202412020001','202412020001','2024-12-02 00:00:00','2024-12-02 00:00:00'),('202412020002','Drink','202412020001','202412020001','2024-12-02 00:00:00','2024-12-02 00:00:00'),('202412020003','Others','202412020001','202412020001','2024-12-02 00:00:00','2024-12-02 00:00:00');
/*!40000 ALTER TABLE `tb_item_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_items`
--

DROP TABLE IF EXISTS `tb_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_items` (
  `id` varchar(50) NOT NULL,
  `item_name` mediumtext DEFAULT NULL,
  `price` double NOT NULL DEFAULT 0,
  `stock` int(15) NOT NULL DEFAULT 0,
  `category` varchar(50) NOT NULL,
  `image_url` text DEFAULT NULL,
  `date_add` datetime NOT NULL,
  `date_edit` datetime NOT NULL,
  `user_add` varchar(50) NOT NULL,
  `user_edit` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_items`
--

LOCK TABLES `tb_items` WRITE;
/*!40000 ALTER TABLE `tb_items` DISABLE KEYS */;
INSERT INTO `tb_items` VALUES ('202412020001','Caramel Machiato',20000,30,'202412020002','CaramelMacchiato-hero.1fb90577.jpg','2024-12-02 00:00:00','2024-12-02 23:03:14','202412020001','202412020001'),('202412020002','Affogato',15000,28,'202412020002','181abce0-46e9-4ce9-8012-4f07f31da591.jpg','2024-12-02 22:59:02','2024-12-02 23:03:58','202412020001','202412020001'),('202412030001','Cappuccino',12000,43,'202412020002','324576d6-7824-42e5-949b-554855f6a46c.jpg','2024-12-03 23:21:34','2024-12-03 23:21:34','202412020001','202412020001');
/*!40000 ALTER TABLE `tb_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_sessions`
--

DROP TABLE IF EXISTS `tb_sessions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_sessions` (
  `id` varchar(50) NOT NULL,
  `user_id` varchar(50) NOT NULL,
  `token` varchar(100) NOT NULL,
  `date_add` datetime NOT NULL,
  `date_expired` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_sessions`
--

LOCK TABLES `tb_sessions` WRITE;
/*!40000 ALTER TABLE `tb_sessions` DISABLE KEYS */;
INSERT INTO `tb_sessions` VALUES ('202412030001','202412020001','e26514e62a8ed71db60cc169da859da4de96c12587ceea5dfd65583f9238d937','2024-12-03 14:26:56','2024-12-04 05:26:56'),('202412030002','202412020001','105885d4a6bdd745e5f755b0d1e52b96b1750ad724d17db0c99d0bfae4c8a022','2024-12-03 23:20:14','2024-12-04 08:20:14');
/*!40000 ALTER TABLE `tb_sessions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_transaction`
--

DROP TABLE IF EXISTS `tb_transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_transaction` (
  `id` varchar(100) NOT NULL,
  `user_id` varchar(50) NOT NULL,
  `item` varchar(50) NOT NULL DEFAULT '0',
  `pcs` int(11) NOT NULL DEFAULT 0,
  `price` decimal(10,0) NOT NULL DEFAULT 0,
  `transaction_time` time NOT NULL,
  `transaction_date` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_transaction`
--

LOCK TABLES `tb_transaction` WRITE;
/*!40000 ALTER TABLE `tb_transaction` DISABLE KEYS */;
INSERT INTO `tb_transaction` VALUES ('202412020001','202412020001','202412020001',3,20000,'10:10:13','2024-12-02'),('202412030001','202412020001','202412020001',2,20000,'10:10:13','2024-12-03'),('202412030002','202412020001','202412020002',2,15000,'10:10:13','2024-12-03'),('202412030003','202412020001','202412020002',2,15000,'18:36:24','2024-12-03'),('202412030004','202412020001','202412030001',2,12000,'23:22:26','2024-12-03');
/*!40000 ALTER TABLE `tb_transaction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_users`
--

DROP TABLE IF EXISTS `tb_users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_users` (
  `id` varchar(50) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(100) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `date_add` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_users`
--

LOCK TABLES `tb_users` WRITE;
/*!40000 ALTER TABLE `tb_users` DISABLE KEYS */;
INSERT INTO `tb_users` VALUES ('202412020001','admin','123qweasd','Dwitya Kurnia Widi','2024-12-02 00:00:00');
/*!40000 ALTER TABLE `tb_users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'stock_data_warehouse'
--

--
-- Dumping routines for database 'stock_data_warehouse'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-03 23:33:38
