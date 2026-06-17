-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: db95
-- ------------------------------------------------------
-- Server version	8.0.30

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `case_coolers`
--

DROP TABLE IF EXISTS `case_coolers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `case_coolers` (
  `id` int NOT NULL AUTO_INCREMENT,
  `model` varchar(255) NOT NULL,
  `produser` varchar(255) NOT NULL,
  `scale` int NOT NULL,
  `light` varchar(255) NOT NULL,
  `image` varchar(150) DEFAULT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  `cost` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `case_coolers`
--

LOCK TABLES `case_coolers` WRITE;
/*!40000 ALTER TABLE `case_coolers` DISABLE KEYS */;
INSERT INTO `case_coolers` VALUES (1,'Pure Wings 2','be quiet!',120,'no','img/fa64c375-7356-4a7a-9d1e-2a7b141c8ba7.jpg',9,1200),(2,'Pure Wings 2','be quiet!',140,'no','img/4ab54411-ca4d-48b4-97d5-75589fd14080.jpg',9,1800),(3,'SickleFlow 120','Cooler Master',120,'RGB','img/4b2d7b3c-f090-4477-9625-94a4956260c2.jpg',9,1800),(4,'SickleFlow 140','Cooler Master',140,'RGB','img/661b77fe-8180-4424-b87e-c896f2958b12.jpg',9,2200),(5,'NF-P12 redux-1700','Noctua',120,'no','img/e721e4fa-fdbc-4fc9-8429-1472b255132f.jpg',9,2500),(6,'NF-A14 PWM','Noctua',140,'no','img/cce3b6b0-891f-42f8-8860-7aae3b0f9256.jpg',9,3200),(7,'NF-F12 industrialPPC','Noctua',120,'no','img/26ff5e94-30e4-4a90-b011-478d5a5b54ce.jpg',9,4500),(8,'Light Wings','be quiet!',120,'RGB','img/aeec38f8-80a5-4331-9edc-8fdf4724df88.jpg',6,2800),(9,'Light Wings','be quiet!',140,'RGB','img/72f91f6f-1624-4c5b-9a2f-c39f5a7c7705.jpg',6,3200),(10,'ML120 PRO','Corsair',120,'RGB','img/6ecf07ed-a3af-4f00-9b3e-195e9c73fbf5.jpg',9,2700),(11,'ML140 PRO','Corsair',140,'RGB','img/76b7a7c4-1da0-4cae-a621-0f6c8c122203.jpg',9,3100),(12,'LL120','Corsair',120,'RGB','img/94cfe319-0be0-4d9d-a774-3f01fb4e4a92.jpg',9,3500),(13,'LL140','Corsair',140,'RGB','img/251b4de1-e960-4761-b843-d55d9a2831d3.jpg',9,3900),(14,'SP120 RGB ELITE','Corsair',120,'RGB','img/cd916d08-c45c-4393-9501-59d6110e2921.jpg',9,2200),(15,'SP140 RGB ELITE','Corsair',140,'RGB','img/ed0c7971-ba99-4e6b-858e-e5364a19a744.jpg',9,2600),(16,'Silencio FP120','Arctic',120,'no','img/4f577a8b-b8cc-482e-94b2-46d671218060.jpg',9,900),(17,'Silencio FP140','Arctic',140,'no','img/038e451a-df06-4204-8cc8-4968dd9fa154.jpg',9,1100),(18,'P12 PWM','Arctic',120,'no','img/d321c07d-9b00-4634-a08e-ec935e8fc609.jpg',9,800),(19,'P14 PWM','Arctic',140,'no','img/5b57f6f3-7ba9-4193-a023-59b050e97a7f.jpg',9,1000),(20,'F12 PWM','Arctic',120,'no','img/726f3d4c-66a5-4d30-a7c6-4140b6c27807.jpg',9,750),(21,'MasterFan MF120 Halo','Cooler Master',120,'RGB','img/f9a90964-43ce-4d36-b614-df25bd427a90.jpg',9,2000),(22,'MasterFan MF140 Halo','Cooler Master',140,'RGB','img/90d9ac5e-0a5f-4452-9cd7-a3eed50cea64.jpg',9,2400),(23,'RGB Fusion',' be quiet!',120,'RGB','img/a97e1447-0fa2-43e7-9e10-4f54e7da3b8d.jpg',9,2600),(24,'RGB Fusion',' be quiet!',140,'RGB','img/a8db8715-077d-4a41-8622-1c8923ed3f49.jpg',9,3000),(25,'Chromax NF-S12A','Noctua',120,'no','img/e72435db-bf20-4a4e-b54f-872a63e4dc40.jpg',9,3000),(26,'Chromax NF-A12x25','Noctua',120,'no','img/4a0ec3d7-5812-4f17-8d74-19c2bb357e50.jpg',9,4000),(27,'RGB LED','Arctic',120,'RGB','img/29c34640-18cd-44e9-b855-95e75698df73.jpg',5,1200),(28,'RGB LED','Arctic',140,'RGB','img/7b5e3d12-ded2-429f-9a32-d272030a4e58.jpg',99,1400),(29,'Venturi HP','Fractal Design',120,'no','img/af97ca16-d1df-4cab-bcfe-d12da76ae5a0.jpg',9,1800),(30,'Venturi HP','Fractal Design',140,'no','img/ed63cae4-10e9-462e-b879-e64e80e16fda.jpg',9,2100);
/*!40000 ALTER TABLE `case_coolers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cases`
--

DROP TABLE IF EXISTS `cases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cases` (
  `id` int NOT NULL AUTO_INCREMENT,
  `form_factor` varchar(255) NOT NULL,
  `model` varchar(255) NOT NULL,
  `produser` varchar(255) NOT NULL,
  `color` varchar(255) NOT NULL,
  `max_lenght_videocard` int NOT NULL,
  `max_height_cpu_cooler` int NOT NULL,
  `storage_slots` int NOT NULL,
  `image` varchar(150) DEFAULT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  `cost` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `model_UNIQUE` (`model`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cases`
--

LOCK TABLES `cases` WRITE;
/*!40000 ALTER TABLE `cases` DISABLE KEYS */;
INSERT INTO `cases` VALUES (1,'ATX','Carbide 400C','Corsair','Black',370,170,4,'img/554dbcea-f27f-4462-9847-c9a4a3563c1f.jpg',9,8500),(2,'ATX','Define R7','Fractal Design','Black',450,180,1,'img/2bd2e5fd-6b52-4b55-98ef-b71dc3b669be.jpg',9,9000),(3,'ATX','H500P Mesh','Cooler Master','Black',412,190,5,'img/ab9e7acd-ade1-48ad-bc9a-05b816dc83a7.jpg',9,9500),(4,'ATX','Obsidian 750D','Corsair','Black',450,180,7,'img/fa4220aa-9fc5-4bf7-851d-99a7d772542f.jpg',9,15000),(5,'ATX','Enthoo Pro','Phanteks','Black',420,193,6,'img/62c42c87-62aa-4189-bacb-00aa36c77e0a.jpg',7,11000),(6,'ATX','Lancool 216','Lian Li','Black',392,185,5,'img/3496a826-81d5-415f-9332-75721320bbd9.jpg',9,9000),(7,'ATX','Focus G',' Fractal Design','Black',380,165,4,'img/8f60480f-79be-4480-a77e-77ab069aec3e.jpg',9,6000),(8,'ATX','MasterBox TD500','Cooler Master','Black',410,165,4,'img/f1f086bb-31ab-434f-b989-eda030e164e0.jpg',9,8000),(9,'ATX','5000D Airflow','Corsair','Black',420,180,4,'img/df826a8b-47b3-4fea-8fc8-3b7bc6e39a8a.jpg',99,13000),(10,'ATX','P400A','Phanteks','Black',420,190,5,'img/729f96d1-c009-4ffd-8ed0-842e6756b2a3.jpg',9,10000),(11,'mATX','MasterBox Q300L','Cooler Master','Black',360,158,3,'img/f7c662e5-f6f2-4879-b3b5-0fc84b31ae94.jpg',9,4000),(12,'mATX','Define Mini C','Fractal Design','Black',315,172,4,'img/77826ddd-a5d6-44d1-b3ee-05bfd0631ef3.jpg',9,9000),(13,'mATX','Air 1000 Silent','Silverstone','Black',350,166,4,'img/9ecea31c-7406-4252-9894-53ca105db623.jpg',99,7500),(14,'mATX','Core V21','Thermaltake','Black',330,180,5,'img/fb62b025-e042-40d9-8a15-311451455bf9.jpg',9,6500),(15,'mATX','NR400','Cooler Master','Black',345,166,3,'img/10a98636-1b2c-45b8-a3ff-9d224567f41a.jpg',9,5500),(16,'mATX','OBSIDIAN 350D','Corsair','Black',380,160,4,'img/a8e190a5-11f5-4530-bbaf-65eaaef499fa.jpg',9,11000),(17,'mATX','Macube 110','Deepcool','White',320,155,3,'img/9a9b9074-a80a-4f55-b80c-fd30a5a49b18.jpg',9,4500),(18,'mATX','MB311L','ARCTIC','Black',335,158,3,'img/45f25a61-0e0e-426e-b2c0-3ed10f7a470b.jpg',9,5000),(19,'mATX','Q500L',' Cooler Master','Black',365,156,3,'img/daad4d11-54c6-4a13-8412-06fa3bc892aa.jpg',0,3500),(20,'mATX','Elite 343','Cooler Master','Black',320,155,2,'img/7b58daf5-ebe3-44bc-8ff1-51e4bc276cc6.jpg',9,3000),(21,'Mini-ITX','NZXT H210','NZXT','Black',325,165,3,'img/1224be65-ecec-4556-adc7-9e7dd81be657.jpg',9,8500),(22,'Mini-ITX','Core 500','Fractal Design','Black',310,170,4,'img/75854b6f-d56c-45f8-beac-e6ebaaa2ae10.jpg',9,8000),(23,'Mini-ITX','Elite 110','Cooler Master','Black',210,130,2,'img/ca38dff2-9521-417f-b155-cc621473cf52.jpg',9,4500),(24,'Mini-ITX','SUGO 13','Silverstone','Black',270,83,3,'img/fd8fed64-c09c-4d15-b17e-5be6bec74689.jpg',9,6000),(25,'Mini-ITX','Node 202','Fractal Design','Black',330,56,2,'img/ae3cfc7f-df35-4b7b-a5c2-c6e42a7fe223.jpg',0,7000),(26,'Mini-ITX','Phanteks Evolv ITX','Phanteks','Black',330,185,3,'img/7b3da5bf-a026-4236-bb84-50989d1dd6e2.jpg',9,12000),(27,'Mini-ITX','MasterCase H100','Cooler Master','Black',300,130,2,'img/e8840faf-4fd5-4348-87fc-36dfb19d53b2.jpg',9,5500),(28,'Mini-ITX','RVZ03','Silverstone','Black',330,83,3,'img/5dcfa7c7-99b4-4bd6-818b-cda4d216af7d.jpg',9,7500),(29,'Mini-ITX','TU150','Lian Li','Black',320,165,3,'img/b5cf2526-d7cf-49ba-bc3f-1e646f48d3f5.jpg',8,11000),(30,'Mini-ITX','QBX','Cougar','Black',330,105,3,'img/ed504aff-a656-42b4-a77a-d917f65307c5.jpg',9,5000);
/*!40000 ALTER TABLE `cases` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `config`
--

DROP TABLE IF EXISTS `config`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `config` (
  `id` int NOT NULL,
  `cpu` varchar(255) NOT NULL,
  `mother_board` varchar(255) NOT NULL,
  `case` varchar(255) NOT NULL,
  `ram` varchar(255) NOT NULL,
  `how_many_ram` int NOT NULL,
  `storage` varchar(255) NOT NULL,
  `how_many_storage` int NOT NULL,
  `power_supplier` varchar(255) NOT NULL,
  `cpu_fan` varchar(255) NOT NULL,
  `gpu` varchar(255) NOT NULL,
  `case_fan` varchar(255) NOT NULL,
  `how_many_case_fan` int NOT NULL,
  `thermo_interface` varchar(255) NOT NULL,
  `result_cost` varchar(45) NOT NULL,
  `assembling` tinyint NOT NULL,
  `userid` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `config`
--

LOCK TABLES `config` WRITE;
/*!40000 ALTER TABLE `config` DISABLE KEYS */;
/*!40000 ALTER TABLE `config` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cpu_cooler`
--

DROP TABLE IF EXISTS `cpu_cooler`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cpu_cooler` (
  `id` int NOT NULL AUTO_INCREMENT,
  `socket` varchar(255) NOT NULL,
  `max_heat_sink` int NOT NULL,
  `model` varchar(255) NOT NULL,
  `produser` varchar(255) NOT NULL,
  `cooler_height` int NOT NULL,
  `light_type` varchar(255) NOT NULL,
  `image` varchar(150) DEFAULT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  `cost` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `model_UNIQUE` (`model`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cpu_cooler`
--

LOCK TABLES `cpu_cooler` WRITE;
/*!40000 ALTER TABLE `cpu_cooler` DISABLE KEYS */;
INSERT INTO `cpu_cooler` VALUES (1,'AM4/LGA1700',150,'Pure Rock Slim 2','be quiet!',135,'no','img/7a9159c7-e387-4688-af1e-8e42c386e849.jpg',9,3500),(2,'AM4/LGA1700',150,'Pure Rock 2','be quiet!',159,'no','img/5acaaaa5-db6a-48a8-86d8-40239637a057.jpg',9,6000),(3,'AM4/LGA1700',220,'Dark Rock 4','be quiet!',160,'no','img/573f0818-9dec-4631-8f84-a32d749c37fc.jpg',9,6500),(4,'AM4/LGA1700',250,'Dark Rock Pro 4','be quiet!',163,'no','img/5791a1d0-1a07-41f1-a01a-207647de926d.jpg',9,8500),(5,'AM5/LGA1700',280,'Dark Rock Pro 5','be quiet!',168,'no','img/d6648b87-3fde-449a-b968-b9e6ebb65037.jpg',9,9500),(6,'AM4/LGA1700',165,'Hyper 212 RGB','Cooler Master',159,'RGB','img/184aa886-241a-4d9d-b5fd-cf866215e078.jpg',99,5000),(7,'AM5/LGA1700',200,'Hyper 622 HALO','Cooler Master',160,'RGB','img/1c295ff1-1c11-4d75-a621-c74d1236fe67.jpg',9,6000),(8,'AM4/LGA1700',180,'ML240L','Cooler Master',65,'RGB','img/b79a5d12-b626-48bf-8735-12bddc5061b5.jpg',0,7500),(9,'AM5/LGA1700',240,'ML360L','Cooler Master',65,'RGB','img/c4508652-3ff5-48dc-8d65-82cfb52545e2.jpg',9,9500),(10,'AM4/LGA1700',200,'NH-U12S','Noctua',158,'no','img/71cc9bc6-f0e6-4e69-9027-b095c4fc83b1.jpg',9,7500),(11,'AM5/LGA1700',250,'NH-U12A','Noctua',158,'no','img/0b51c17b-baa1-4e77-80c1-45fc9ca2dd8c.jpg',9,9500),(12,'AM4/LGA1700',280,'NH-D15','Noctua',165,'no','img/dabc8703-5a84-4e18-9102-3d78900e0cba.jpg',9,12000),(13,'AM5/LGA1700',300,'NH-D16','Noctua',168,'no','img/09d17142-a6d3-4001-99c5-9d7a111b3d2c.jpg',7,14000),(14,'AM4/LGA1700',120,'Freezer 7 X','Arctic',49,'no','img/f56b3d39-db03-45ee-b6b8-636cb510b722.jpg',9,2000),(15,'AM4/LGA1700',200,'Freezer 34 eSports','Arctic',157,'no','img/013dfd30-5717-49b5-b2da-a09195d3d831.jpg',9,3500),(16,'AM5/LGA1700',220,'Freezer 36','Arctic',160,'no','img/a1f5ec5c-5f37-4047-b7f0-f2b2e16bd355.jpg',9,4500),(17,'AM4/LGA1700',180,'AIO 120','Deepcool',65,'RGB','img/46a66ecd-240d-4f92-b490-9ce153a841b9.jpg',9,5000),(18,'AM5/LGA1700',240,'AIO 240','Deepcool',65,'RGB','img/2dc404f9-e3ef-4c0f-9f83-33f666c3832d.jpg',9,7000),(19,'AM4/LGA1700',280,'AIO 360','Deepcool',65,'RGB','img/84ac05db-b930-4d88-a309-f57560f3e783.jpg',9,9000),(20,'AM4/LGA1700',165,'Assassin X 120','Deepcool',150,'no','img/121facae-4331-49fd-8308-a56023c212b7.jpg',9,3000),(21,'AM5/LGA1700',190,'Assassin IV','Deepcool',160,'RGB','img/7f9b2ce1-2c33-4ffe-aa7c-9214e423f8b1.jpg',9,5500),(22,'AM4/LGA1700',170,'Hydro Series H60','Corsair',65,'no','img/c5c84b93-16c4-405b-ba0b-fe5ce5fb8dfe.jpg',9,6000),(23,'AM4/LGA1700',240,'Hydro Series H100i','Corsair',65,'RGB','img/24e57f3d-a7d4-4d78-99d0-370f38aa705d.jpg',9,11000),(24,'AM5/LGA1700',280,'Hydro Series H115i','Corsair',65,'RGB','img/8822769d-f336-48fd-b86f-c940f780c1bd.jpg',9,13000),(25,'AM5/LGA1700',360,'Hydro Series H150i','Corsair',65,'RGB','img/940b1910-5b2a-449f-987b-1e6102fc41c3.jpg',9,15000),(26,'AM4/LGA1700',130,'Gammaxx 200T','Deepcool',130,'no','img/043559de-6e05-44e6-b958-e3e5d9eeb31d.jpg',9,2500),(27,'AM4/LGA1700',160,'Gammaxx 400 V2','Deepcool',155,'no','img/8292895b-78ad-45c4-adfe-364053e6c3be.jpg',9,2800),(28,'AM5/LGA1700',190,'Gammaxx 620','Deepcool',158,'RGB','img/464aeb4c-8a30-479c-a681-837d49cf9bce.jpg',9,4500),(29,'AM4/LGA1700',140,'Shadow Rock 3','be quiet!',163,'no','img/3990bcdc-ca86-47d0-a031-fdc3b437ba83.jpg',9,5500),(30,'AM5/LGA1700',230,'Shadow Rock Pro 5','be quiet!',165,'no','img/b4d5e5a1-e0f4-4b69-8db6-35c423aef040.jpg',9,7500);
/*!40000 ALTER TABLE `cpu_cooler` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `motherboards`
--

DROP TABLE IF EXISTS `motherboards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `motherboards` (
  `id` int NOT NULL AUTO_INCREMENT,
  `model` varchar(255) NOT NULL,
  `produser` varchar(255) NOT NULL,
  `form_factor` varchar(255) NOT NULL,
  `cpu_socket` varchar(255) NOT NULL,
  `ram_slots` int NOT NULL,
  `ram_support_type` varchar(255) NOT NULL,
  `ram_max_capacity` varchar(255) NOT NULL,
  `chipset` varchar(255) NOT NULL,
  `expansion_slots` int NOT NULL,
  `expansion_type` varchar(255) NOT NULL,
  `m2_ssd_slots` int NOT NULL,
  `image` varchar(150) DEFAULT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  `cost` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `model_UNIQUE` (`model`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `motherboards`
--

LOCK TABLES `motherboards` WRITE;
/*!40000 ALTER TABLE `motherboards` DISABLE KEYS */;
INSERT INTO `motherboards` VALUES (1,'ROG Crosshair X670E Hero','ASUS','ATX','AM5',4,'DDR5','128GB','X670E',3,'PCIe 5.0 x16',1,'img/7a4de824-9bb1-46cb-b623-0845ad18fb71.png',4,45000),(2,'TUF Gaming B650-PLUS','ASUS','ATX','AM4',4,'DDR4','128GB','B650',0,'PCIe 4.0 x16',1,'img/8f077490-62e9-4109-9c92-c5a8fe70a6e8.jpg',8,22900),(3,'PRIME B650M-A','ASUS','mATX','AM5',4,'DDR5','128GB','B650',2,'PCIe 4.0 x16',2,'img/6c2962a0-6010-448c-89c6-00cc2c7b72a3.jpg',9,15000),(4,'ROG Strix Z790-E Gaming','ASUS','ATX','LGA1700',4,'DDR5','128GB','Z790',3,'PCIe 5.0 x16',1,'img/3b2935da-e617-4c9b-9eb7-b1efee8b78c9.png',5,38000),(5,'TUF Gaming Z790-Plus','ASUS','ATX','LGA1700',4,'DDR5','128GB','Z790',3,'PCIe 5.0 x16',0,'img/e363ed6e-facc-46d2-85c4-7b7770eb4d97.png',9,28000),(6,'PRIME H610M-K','ASUS','mATX','LGA1700',2,'DDR4','64GB','H610',1,'PCIe 4.0 x16',0,'img/828bee39-3422-41c1-b710-8515546ffabc.jpg',8,8000),(7,'MAG B650 TOMAHAWK WIFI','MSI','ATX','AM5',4,'DDR5','128GB','B650',3,'PCIe 4.0 x16',0,'img/bc264107-4277-474e-815f-0a92c74f72e4.jpg',10,24000),(8,'PRO B650-P WIFI','MSI','ATX','AM5',4,'DDR5','128GB','B650',3,'PCIe 4.0 x16',0,'img/ca9d9557-4f9f-4938-a87a-121f9e3cbca7.jpg',3,20000),(9,'MPG Z790 Carbon WIFI','MSI','ATX','LGA1700',4,'DDR5','128GB','Z790',3,'PCIe 5.0 x16',0,'img/69ffbaa6-619a-4975-b26a-a6ea3d5ee9d7.jpg',6,35000),(10,'PRO Z790-A WIFI','MSI','ATX','LGA1700',4,'DDR5','128GB','Z790',3,'PCIe 5.0 x16',0,'img/86c4d255-48b3-487c-a360-7f7b4b3a8270.jpg',85,26000),(11,'B650 AORUS Elite AX','Gigabyte','ATX','AM5',4,'DDR5','128GB','B650',3,'PCIe 4.0 x16',0,'img/2b6b5d35-bda4-4437-9dc8-c6522a80fa73.jpg',6,23000),(12,'B650M AORUS Elite AX','Gigabyte','mATX','AM5',4,'DDR5','128GB','B650',2,'PCIe 4.0 x16',0,'img/e518287d-cbae-4079-b7b7-0f3b4964209e.jpg',6,18000),(13,'Z790 AORUS Elite AX','Gigabyte','ATX','LGA1700',4,'DDR5','128GB','Z790',3,'PCIe 5.0 x16',0,'img/2b229353-0900-4cc8-bde0-7a9252b06b39.png',6,30000),(14,'B760M DS3H','Gigabyte','mATX','LGA1700',2,'DDR4','64GB','B760',1,'PCIe 4.0 x16',0,'img/4df1260e-a278-433f-afde-92cefb783916.jpg',6,12000),(15,'X670E Taichi','ASRock','ATX','AM5',4,'DDR5','128GB','X670E',3,'PCIe 5.0 x16',0,'img/c3830b84-e44a-48d7-b6e4-ee75c1082f7f.jpg',3,40000),(16,'B650E Steel Legend','ASRock','ATX','AM5',4,'DDR5','128GB','B650E',3,'PCIe 5.0 x16',0,'img/c8cc85b0-bc1a-402b-bccc-6b8066de908f.jpg',10,27000),(17,'B650M Pro RS','ASRock','mATX','AM5',4,'DDR5','128GB','B650',2,'PCIe 4.0 x16',0,'img/2c34646b-f647-4123-bec2-c5c53755faf0.jpg',7,16000),(18,'Z790 Taichi','ASRock','ATX','LGA1700',4,'DDR5','128GB','Z790',3,'PCIe 5.0 x16',0,'img/2c3a5eaa-c81e-4207-9581-56bc312833cd.jpg',2,37000),(19,'B760M Steel Legend','ASRock','mATX','LGA1700',4,'DDR5','128GB','B760',2,'PCIe 4.0 x16',0,'img/5fc79793-386b-4ccd-aa92-dd6c72755303.jpg',6,14000),(20,'ROG Strix B550-F Gaming','ASUS','ATX','AM4',4,'DDR4','128GB','B550',3,'PCIe 4.0 x16',0,'img/ed13adab-0d59-42a8-8213-473c6e05f9cd.jpg',6,18000),(21,'TUF Gaming B550-PLUS','ASUS','ATX','AM4',4,'DDR4','128GB','B550',3,'PCIe 4.0 x16',0,'img/1a06c38a-d19e-4105-958a-a1c2e456ec1e.jpg',3,15000),(22,'B550 AORUS Elite','Gigabyte','ATX','AM4',4,'DDR4','128GB','B550',3,'PCIe 4.0 x16',0,'img/ba0528b3-4adf-462e-a5e6-60b1ae35fa7b.jpg',8,14000),(23,'B550M Steel Legend','ASRock','mATX','AM4',4,'DDR4','128GB','B550',2,'PCIe 4.0 x16',0,'img/7f7b864b-a1b3-4060-a3b3-8a98c0eb7615.png',5,12000),(24,'Z590 AORUS Ultra','Gigabyte','ATX','LGA1200',4,'DDR4','128GB','Z590',3,'PCIe 4.0 x16',0,'img/cd5f3f33-5c43-4bf9-826a-d966dde38eab.jpg',4,20000),(25,'B560M AORUS Elite','Gigabyte','mATX','LGA1200',4,'DDR4','128GB','B560',2,'PCIe 4.0 x16',0,'img/bd3e649d-f53a-47c1-8757-4e9dc185be8d.jpg',7,10000),(26,'ROG Strix X570-E Gaming','ASUS','ATX','AM4',4,'DDR4','128GB','X570',3,'PCIe 4.0 x16',0,'img/4d0a903a-9d17-4618-847a-58bd2ce00529.png',7,25000),(27,'PRIME X570-P','ASUS','ATX','AM4',4,'DDR4','128GB','X570',3,'PCIe 4.0 x16',0,'img/39521787-37be-418b-9438-878f90a19417.png',7,17000),(28,'MPG B550 Gaming Plus','MSI','ATX','AM4',4,'DDR4','128GB','B550',3,'PCIe 4.0 x16',0,'img/d3a0eaf0-0ec1-4dcc-91ee-972d85d90a82.jpg',7,13000),(30,'PRIME H510M-K','ASUS','mATX','LGA1200',2,'DDR4','64GB','H510',1,'PCIe 3.0 x16',0,'img/5040deae-ed15-4d12-abe3-df0b5f118daf.jpg',5,6000);
/*!40000 ALTER TABLE `motherboards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `idorder` int NOT NULL AUTO_INCREMENT,
  `iduser` int NOT NULL,
  `id_processors` int DEFAULT NULL,
  `count_processors` int DEFAULT NULL,
  `id_motherboards` int DEFAULT NULL,
  `count_motherboards` int DEFAULT NULL,
  `id_videocards` int DEFAULT NULL,
  `count_videocards` int DEFAULT NULL,
  `id_ram` int DEFAULT NULL,
  `count_ram` int DEFAULT '1',
  `id_cpu_cooler` int DEFAULT NULL,
  `count_cpu_coolers` int DEFAULT NULL,
  `id_cases` int DEFAULT NULL,
  `count_cases` int DEFAULT NULL,
  `id_case_coolers` int DEFAULT NULL,
  `count_case_fan` int DEFAULT '1',
  `id_storage` int DEFAULT NULL,
  `count_storage` int DEFAULT NULL,
  `id_power_supplier` int DEFAULT NULL,
  `count_power_supplier` int DEFAULT NULL,
  `id_thermo_interface` int DEFAULT NULL,
  `count_thermo_interface` int DEFAULT NULL,
  `extra_items` longtext,
  `build` varchar(10) DEFAULT NULL,
  `delivery` varchar(10) DEFAULT NULL,
  `deliveryaddress` varchar(255) DEFAULT NULL,
  `phone_number` varchar(20) NOT NULL,
  `ordertime` datetime DEFAULT NULL,
  `ordercomplitetime` datetime DEFAULT NULL,
  `status` varchar(155) DEFAULT NULL,
  `result_cost` int DEFAULT NULL,
  PRIMARY KEY (`idorder`)
) ENGINE=InnoDB AUTO_INCREMENT=148 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (122,1,5,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'','False','False','','+7 (111) 111-11-11','2026-04-28 12:46:25','2026-07-24 17:43:51','3',29900),(123,1,5,1,1,1,92,1,18,1,13,1,4,1,12,1,26,1,8,1,30,1,'','True','True','Нижегородская область, Балахна, улица Кирова, 14','+7 (960) 172-40-97','2026-04-28 12:52:33','2026-08-28 17:45:59','2',349600),(124,1,5,1,1,1,92,1,18,1,13,1,4,1,12,1,26,1,8,1,30,1,'','True','True','Нижегородская область, Балахна, улица Кирова, 14','+7 (960) 172-40-97','2026-04-28 12:53:40','2026-06-22 00:19:17','5',349600),(125,1,5,1,1,1,92,1,18,1,13,1,4,1,12,1,26,1,8,1,30,1,'','True','True','Нижегородская область, Балахна, улица Кирова, 14 ','+7 (123) 123-12-33','2026-04-28 12:57:58','2026-05-05 12:57:58','1',349600),(126,1,5,1,1,1,92,1,18,1,13,1,4,1,12,1,26,1,8,1,30,1,'','True','True','Нижегородская область, Балахна, улица Кирова, 14 ','+7 (123) 123-12-33','2026-04-28 12:58:04','2026-05-05 12:58:04','1',349600),(127,1,5,1,1,1,92,1,18,1,13,1,4,1,12,1,26,1,8,1,30,1,'','True','True','Нижегородская область, Балахна, улица Кирова, 14 ','+7 (123) 123-12-33','2026-04-28 12:58:59','2026-05-05 12:58:59','1',349600),(128,1,5,1,1,1,92,1,18,1,13,1,4,1,12,1,26,1,8,1,30,1,'','True','True','Нижегородская область, Балахна, улица Кирова, 14 ','+7 (123) 123-12-33','2026-04-28 12:59:18','2026-05-05 12:59:18','1',349600),(129,1,5,1,1,1,92,1,18,1,13,1,4,1,12,1,26,1,8,1,30,1,'','True','True','1 ','+7 (111) 111-11-11','2026-04-29 16:35:00','2026-05-06 16:35:00','1',349600),(130,1,5,1,1,1,92,1,18,1,13,1,4,1,12,1,26,1,8,1,30,1,'','True','False',' ','+7 (111) 111-11-11','2026-04-29 16:35:57','2026-05-06 16:35:57','1',348600),(131,1,5,1,1,1,92,1,18,1,13,1,4,1,12,1,26,1,8,1,30,1,'','True','False',' ','+7 (111) 111-11-11','2026-04-29 16:48:23','2026-05-06 16:48:23','1',348600),(132,1,5,1,1,1,92,1,18,1,13,1,4,1,12,1,26,1,8,1,30,1,'','True','False',' ','+7 (111) 111-11-11','2026-04-29 16:49:17','2026-05-06 16:49:17','1',348600),(133,1,0,0,0,0,0,0,0,0,0,0,0,0,6,1,0,0,0,0,0,0,'','False','True','Нижегородская область, Городецкий муниципальный округ, Заволжье, проспект Мира, 31 ','+7 (123) 123-12-31','2026-05-24 17:25:50','2026-06-04 17:25:50','1',6200),(134,1,0,0,0,0,0,0,0,0,0,0,0,0,6,1,0,0,0,0,0,0,'','False','True','Нижегородская область, Городецкий муниципальный округ, Заволжье, проспект Мира, 31 ','+7 (111) 111-11-11','2026-05-24 17:30:41','2026-05-31 17:30:41','1',6200),(135,1,0,0,0,0,0,0,0,0,0,0,0,0,6,1,0,0,0,0,0,0,'','False','True','Нижегородская область, Городецкий муниципальный округ, Заволжье, проспект Мира, 31','+7 (111) 111-11-11','2026-05-24 17:32:10','2026-06-21 00:15:43','5',6200),(136,1,0,0,0,0,0,0,0,0,0,0,0,0,6,1,0,0,0,0,0,0,'','False','True','Нижегородская область, Городецкий муниципальный округ, Заволжье, проспект Мира, 31 ','+7 (111) 111-11-11','2026-05-24 17:35:07','2026-06-04 17:35:07','1',6200),(137,1,0,0,0,0,0,0,0,0,0,0,0,0,6,2,0,0,0,0,0,0,'','False','True','Нижегородская область, Городецкий муниципальный округ, Заволжье, проспект Мира, 31 ','+7 (111) 111-11-11','2026-05-24 17:35:50','2026-06-04 17:35:50','1',9400),(138,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'aerocool atlantic 1 1 ','False','False',' ','+7 (111) 111-11-11','2026-05-28 19:42:22','2026-06-04 19:42:55','1',10000),(139,1,11,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'aerocool atlantic 1 2 ','False','False',' ','+7 (111) 111-11-11','2026-05-28 19:44:53','2026-06-04 19:44:55','1',42999),(140,1,138,1,16,1,1,1,15,1,13,1,5,1,12,1,6,1,11,1,22,1,'','True','False',' ','+7 (909) 876-94-34','2026-06-10 18:48:40','2026-06-17 18:48:40','1',373300),(141,1,138,1,16,1,1,1,15,1,13,1,5,1,12,1,6,1,11,1,22,1,'','True','False',' ','+7 (909) 876-94-34','2026-06-13 18:49:51','2026-06-17 18:49:51','1',373300),(142,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7,1,0,0,'','False','False',' ','+7 (999) 432-53-77','2026-06-14 00:08:18','2026-06-25 00:08:18','1',13000),(143,1,0,0,0,0,0,0,0,0,0,0,29,1,8,3,0,0,0,0,0,0,'','False','True','Нижегородская область, Городецкий муниципальный округ, Заволжье, Пролетарская улица, 45 ','+7 (909) 035-37-69','2026-06-15 00:09:25','2026-08-14 00:09:25','1',23600),(144,1,11,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,'','False','False',' ','+7 (809) 685-38-55','2026-05-18 00:09:47','2026-06-25 00:09:47','1',45998),(145,1,0,0,0,0,0,0,7,4,0,0,0,0,0,0,0,0,0,0,0,0,'','False','True','Нижегородская область, Городецкий муниципальный округ, Заволжье, проспект Мира, 41 ','+7 (900) 235-35-75','2026-05-18 00:10:30','2026-06-25 00:10:30','1',51000),(146,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,26,10,'','False','True','Нижегородская область, Городецкий муниципальный округ, Заволжье, Лесозаводская улица, 25 ','+7 (907) 234-98-10','2026-06-18 00:11:17','2026-06-25 00:11:17','1',7000),(147,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,26,3,'','False','True','Нижегородская область, Городецкий муниципальный округ, Заволжье, Гражданский переулок, 6','+7 (906) 328-23-33','2026-05-18 00:12:07','2026-06-23 00:19:57','5',4200);
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `power_supplier`
--

DROP TABLE IF EXISTS `power_supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `power_supplier` (
  `id` int NOT NULL AUTO_INCREMENT,
  `model` varchar(255) NOT NULL,
  `power` int NOT NULL,
  `certificate` varchar(255) NOT NULL,
  `produser` varchar(255) NOT NULL,
  `image` varchar(150) DEFAULT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  `cost` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `model_UNIQUE` (`model`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `power_supplier`
--

LOCK TABLES `power_supplier` WRITE;
/*!40000 ALTER TABLE `power_supplier` DISABLE KEYS */;
INSERT INTO `power_supplier` VALUES (1,'RM750x',750,'80 Plus Gold','Corsair','img/285a499c-24ef-4e41-aac6-f0dbe34d346f.jpg',9,12000),(2,'RM850x',850,'80 Plus Gold','Corsair','img/196e836f-25f6-4236-984f-68b2d790571a.jpg',9,14000),(3,'RM1000x',1000,'80 Plus Gold','Corsair','img/e9d1a9c1-9870-4ebe-9bef-5b9837b8982e.jpg',9,9900),(4,'TX750M',750,'80 Plus Gold','Corsair','img/0cfb66e0-7d19-4b62-b3b7-f4ba140ce031.jpg',9,10000),(5,'CX650F',650,'80 Plus Bronze','Corsair','img/1a2f4401-ba4d-4462-92cf-a588d9a5c55c.jpg',9,7000),(6,'Focus GX-750',750,'80 Plus Gold','Seasonic','img/f979cb5f-3cb1-4030-a0d9-0e4920a31c3e.jpg',9,11000),(7,'Focus GX-850',850,'80 Plus Gold','Seasonic','img/0eed7268-f4e2-4bc1-9264-b0f332843af8.jpg',8,13000),(8,'Prime PX-850',850,'80 Plus Platinum','Seasonic','img/43e8316a-fb29-4357-aa38-a4ba6ed79020.jpg',9,17000),(9,'Prime TX-1000',1000,'80 Plus Titanium','Seasonic','img/3545ff31-8bf4-4422-bdec-9983f109684f.jpg',9,25000),(10,'Straight Power 11 750W',750,'80 Plus Platinum','be quiet!','img/45576348-d5c5-4826-9cf6-50f32efe6e06.jpg',9,15000),(11,'Straight Power 11 850W',850,'80 Plus Platinum','be quiet!','img/08e92840-9194-4894-9915-7a19667d04fd.jpg',7,17000),(12,'Dark Power 12 1000W',1000,'80 Plus Titanium','be quiet!','img/4afa2867-820e-4c44-9fd0-867dbcb19595.jpg',9,28000),(13,'System Power 9 600W',600,'80 Plus Bronze','be quiet!','img/033c76a0-202f-49c3-8e43-6c2b404a16dc.jpg',9,5000),(14,'Leadex III 750W',750,'80 Plus Gold','Super Flower','img/17ed4c31-2083-4281-ac17-1ccc9391943b.jpeg',9,10000),(15,'Leadex III 850W',850,'80 Plus Gold','Super Flower','img/43162490-4a15-43e0-93fa-5542ae9ce13a.jpeg',9,12000),(16,'SuperNOVA 750 G5',750,'80 Plus Gold','EVGA','img/277b82ff-3ef1-45af-a1bc-0022e0b96e95.jpeg',9,11000),(17,'SuperNOVA 850 G5',850,'80 Plus Gold','EVGA','img/8934c230-72a0-4ce0-b3aa-c754beb21248.jpeg',9,13000),(18,'Toughpower GF1 750W',750,'80 Plus Gold','Thermaltake','img/7e749229-d9f8-435e-9bab-31913b12c9ce.jpg',9,10000),(19,'Toughpower GF1 850W',850,'80 Plus Gold','Thermaltake','img/0fd4f668-bd57-49fc-a4eb-7155569a576f.jpg',9,12000),(20,'Proton 750W',750,'80 Plus Bronze','Chieftec','img/36478460-fff9-4c91-a225-425362ded3bd.jpg',9,6000),(21,'Proton 850W',850,'80 Plus Bronze','Chieftec','img/79b6849b-e668-40fd-a5c5-10a5cf30e073.jpg',9,7000),(22,'Hydro G 750W',750,'80 Plus Gold','FSP','img/8b172470-e38a-4a24-bb42-90f31abb7598.jpg',9,9000),(23,'Hydro G 850W',850,'80 Plus Gold','FSP','img/510816ce-1bce-444c-a115-d79e154573ee.jpg',9,11000),(24,'Revolution D.F. 750W',750,'80 Plus Gold','Enermax','img/e7a8661c-13dc-451d-9f01-6703845ea23c.jpeg',9,10000),(25,'Revolution D.F. 850W',850,'80 Plus Gold','Enermax','img/f7959174-3b3b-4565-80c4-0d897ebe1ebc.jpeg',9,12000),(26,'PQ750M',750,'80 Plus Gold','Deepcool','img/4e08703e-2c90-427d-8199-40fd426a02a7.jpg',9,8000),(27,'PQ850M',850,'80 Plus Gold','Deepcool','img/9032e623-3c0a-4826-bf0a-e0e8bb81b94a.jpg',9,10000),(28,'MWE Gold 750 V2',750,'80 Plus Gold','Cooler Master','img/3f8193f9-f698-4dce-98d7-9feb57632c56.jpg',99,9000),(29,'MWE Gold 850 V2',850,'80 Plus Gold','Cooler Master','img/0353ca68-88fe-4115-8b9d-82fa18c2ea9d.jpg',9,11000),(30,'Project 7 P750',750,'80 Plus Platinum','Aerocool','img/8942cbfd-fbfe-418f-a861-28d00efec482.jpg',9,13000);
/*!40000 ALTER TABLE `power_supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `processors`
--

DROP TABLE IF EXISTS `processors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `processors` (
  `id` int NOT NULL AUTO_INCREMENT,
  `model` varchar(255) NOT NULL,
  `produser` varchar(255) NOT NULL,
  `socket` varchar(255) NOT NULL,
  `frequency` varchar(255) NOT NULL,
  `architecture` varchar(45) NOT NULL,
  `core_int` int NOT NULL,
  `L3_caсhe` int NOT NULL,
  `thermal_power` int NOT NULL,
  `image` varchar(150) DEFAULT NULL,
  `cost` int NOT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `model_UNIQUE` (`model`)
) ENGINE=InnoDB AUTO_INCREMENT=155 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `processors`
--

LOCK TABLES `processors` WRITE;
/*!40000 ALTER TABLE `processors` DISABLE KEYS */;
INSERT INTO `processors` VALUES (1,'Ryzen 9 7950X','AMD','AM5','4.5 GHz','Zen 4',16,64,170,'img/1e9f383c-ef3f-41cc-b9f6-d5cba6578034.jpg',69900,9),(2,'Core i9-13900K','Intel','LGA1700','3.0 GHz','Raptor Lake',24,36,125,'img/0d3f0315-5436-4c08-b8e1-2684ca859488.jpg',58900,9),(3,'Ryzen 7 7800X3D','AMD','AM5','4.2 GHz','Zen 4',8,96,120,'img/9858efa3-e6ac-4294-be7c-e42d71bf4919.jpg',44900,9),(4,'Core i7-13700K','Intel','LGA1700','3.4 GHz','Raptor Lake',16,30,125,'img/a76bb4c5-49b9-4e8b-90c1-32b0cd601615.jpg',40900,9),(5,'Ryzen 5 7600X','AMD','AM5','4.7 GHz','Zen 4',6,32,105,'img/d30fccbf-a111-417a-8b61-bb9ce195a2b1.jpg',29900,97),(6,'Core i5-13600K','Intel','LGA1700','3.5 GHz','Raptor Lake',14,24,125,'img/ad66a25b-4082-4621-9c73-78a69d90ca60.jpg',31900,9),(7,'Ryzen 9 7900X','AMD','AM5','4.7 GHz','Zen 4',12,64,170,'img/1f84ac08-8623-41ed-b86a-3359e8ab9634.jpg',54900,3),(8,'Core i9-12900K','Intel','LGA1700','3.2 GHz','Alder Lake',16,30,125,'img/09c530d3-8c50-4568-9d1a-f28366023a2d.jpg',49900,9),(9,'Ryzen 7 7700X','AMD','AM5','4.5 GHz','Zen 4',8,32,105,'img/a300c7cc-043f-4f73-ba89-f3ea0e69533c.jpg',39900,8),(10,'Core i7-12700K','Intel','LGA1700','3.6 GHz','Alder Lake',12,25,125,'img/7ed31d0e-2c6b-4063-b1be-3aaeb8ba0c19.jpg',34900,9),(11,'Ryzen 5 5600X','AMD','AM4','3.7 GHz','Zen 3',6,32,65,'img/ryzen55600x.png',22999,9),(12,'Core i5-12600K','Intel','LGA1700','3.7 GHz','Alder Lake',10,20,125,'img/829a2e59-dd86-46c9-a5ff-b04905cd34c4.jpg',28900,9),(13,'Ryzen 9 5950X','AMD','AM4','3.4 GHz','Zen 3',16,64,105,'img/d2e671f3-a6d2-4b57-835d-879b5b1a389c.jpg',54900,9),(14,'Core i9-11900K','Intel','LGA1200','3.5 GHz','Rocket Lake',8,16,125,'img/590c86aa-9e78-4044-a768-c214a9e1313f.jpg',39900,9),(15,'Ryzen 7 5800X3D','AMD','AM4','3.4 GHz','Zen 3',8,96,105,'img/8905300e-64cc-4374-af9d-c2bf2964d31e.jpg',44900,8),(16,'Core i7-11700K','Intel','LGA1200','3.6 GHz','Rocket Lake',8,16,125,'img/2155dfff-f347-4553-b4fd-029d90cac0cb.jpg',31900,9),(17,'Ryzen 5 3600','AMD','AM4','3.6 GHz','Zen 2',6,32,65,'img/e0f437bc-d53e-44ec-a217-25406c3e8eaf.jpg',19900,9),(18,'Core i5-11600K','Intel','LGA1200','3.9 GHz','Rocket Lake',6,12,125,'img/39244606-5bc6-43cc-aad0-ceb776b7c66d.jpg',24900,9),(19,'Ryzen 9 3900X','AMD','AM4','3.8 GHz','Zen 2',12,64,105,'img/61349a7b-e55c-4232-b12f-f50fdd630f9c.jpg',44900,9),(20,'Core i9-10900K','Intel','LGA1200','3.7 GHz','Comet Lake',10,20,125,'img/a72634f3-1bee-4f0b-b67d-d6b9a5527592.jpg',42900,9),(21,'Ryzen 7 5700G','AMD','AM4','3.8 GHz','Zen 3',8,16,65,'img/bdb8e04f-56d5-4b3e-aee7-9818b5b88ca5.jpg',35900,9),(22,'Core i7-10700K','Intel','LGA1200','3.8 GHz','Comet Lake',8,16,125,'img/d2e45ac5-f929-4413-ad8e-392ab24604b7.jpg',32900,9),(23,'Ryzen 5 3400G','AMD','AM4','3.7 GHz','Zen+',4,4,65,'img/242441d1-4d25-44fa-824a-182af6302eee.jpg',14900,9),(24,'Core i5-10600K','Intel','LGA1200','4.1 GHz','Comet Lake',6,12,125,'img/a9aac13f-dde8-4441-b181-9e03c9ee159d.jpg',26200,9),(25,'Ryzen Threadripper 3970X','AMD','sTRX4','3.7 GHz','Zen 2',32,128,280,'img/49915d24-26fd-4114-beee-2c2474514f6e.jpg',199900,9),(26,'Core i3-10100','Intel','LGA1200','3.6 GHz','Comet Lake',4,6,65,'img/3925d384-54b4-4b5d-a449-615912397b70.jpg',12200,9),(27,'Ryzen 3 3300X','AMD','AM4','3.8 GHz','Zen 2',4,16,65,'img/6964d822-8a65-4ec2-bf66-c8c16c31e81e.jpg',12000,9),(28,'Pentium Gold G6400','Intel','LGA1200','4.0 GHz','Comet Lake',2,4,58,NULL,6400,9),(29,'Ryzen 7 4700G','AMD','AM4','3.6 GHz','Zen 2',8,8,65,'img/5b8df801-8b0a-4ca8-8b54-3336f85d4bd0.jpg',32900,9),(30,'Celeron G5900','Intel','LGA1200','3.4 GHz','Comet Lake',2,2,58,NULL,4200,9),(31,'Ryzen 9 9950X3D','AMD','AM5','4.3 GHz','Zen 5',16,128,170,'img/94cbb010-47d3-4714-b3f3-747ad637294f.jpg',89000,9),(32,'Ryzen 7 9800X3D','AMD','AM5','4.7 GHz','Zen 5',8,96,120,'img/f3fb4b5a-c51e-4773-bf5f-bb2ca349a1ce.jpg',59900,9),(33,'Ryzen 5 9600X','AMD','AM5','4.6 GHz','Zen 4',6,32,105,'img/f72efe79-26e6-4c1c-aaae-66775fb7ece3.jpg',34900,9),(34,'Ryzen 9 9900X','AMD','AM5','4.8 GHz','Zen 4',12,64,170,'img/7cc35a1e-cd84-4e95-98a9-aa53078e2b4e.jpg',75900,9),(35,'Ryzen 7 9700X','AMD','AM5','4.5 GHz','Zen 5',8,32,105,'img/0e641764-e1c5-46a5-9702-b4eededa248f.jpg',41900,9),(36,'Ryzen 5 9500F','AMD','AM5','4.5 GHz','Zen 5',6,32,65,'img/c4471513-5549-4b07-bb03-2345039cb82d.jpg',29900,9),(37,'Ryzen 5 7400','AMD','AM5','4.2 GHz','Zen 4',6,16,65,'img/e921354c-61ea-40ba-8449-f9755c18b3d4.jpg',24900,9),(38,'Ryzen 5 5600F','AMD','AM4','3.9 GHz','Zen 3',6,32,65,'img/02d79836-baf2-42fa-95bc-5de45663c168.jpg',19900,9),(39,'Core i5-14600K','Intel','LGA1700','3.5 GHz','Raptor Lake',14,24,125,'img/1d6f933f-364b-40c3-a1bb-92d1bf6096a1.jpg',35900,9),(40,'Core i5-13400F','Intel','LGA1700','2.5 GHz','Raptor Lake',10,20,65,'img/13d8baba-6439-45dd-b862-10b5eaa25b7e.jpg',27900,9),(42,'Core i5-13600KF','Intel','LGA1700','3.6 GHz','Raptor Lake',14,24,125,'img/f8e16a87-fe55-41d8-b733-707f73801fb5.jpg',32900,9),(43,'Core i5-12600KF','Intel','LGA1700','3.7 GHz','Alder Lake',10,20,125,'img/0abf3f3e-c702-4d74-86a9-47a66aab3816.jpg',28900,9),(44,'Core i7-13700KF','Intel','LGA1700','3.6 GHz','Raptor Lake',16,30,125,'img/aaa19b17-f643-41c4-8419-7e38ed3abc85.jpg',41900,9),(45,'Core i9-13900KF','Intel','LGA1700','3.0 GHz','Raptor Lake',24,36,125,'img/8e8199a6-5e9a-451b-b097-2efe0eb81be5.jpg',58900,9),(46,'Core i5-14400F','Intel','LGA1700','2.6 GHz','Raptor Lake',10,20,65,'img/2e7bae5c-1213-46fc-9a99-f7f12103db84.jpg',24900,9),(47,'Core i9-14900K','Intel','LGA1700','3.2 GHz','Raptor Lake',24,36,125,'img/32f2c0bf-00a7-4858-a70c-ebfdb6f8562d.jpg',64900,9),(48,'Core i7-12700KF','Intel','LGA1700','3.6 GHz','Alder Lake',12,25,125,'img/d6b095e6-61dc-4294-a661-0dfe245ef11a.jpg',36900,9),(49,'Ryzen 9 9950','AMD','AM5','4.3 GHz','Zen 5',16,64,170,'img/ec29b98b-41ae-41c8-aa9d-e65503bbf030.jpg',82000,9),(50,'Ryzen 7 9700F','AMD','AM5','4.5 GHz','Zen 5',8,32,65,'img/7a487d98-01e6-4a82-b17f-4045b6958b9a.jpg',37900,9),(52,'Core i3-12400F','Intel','LGA1700','2.5 GHz','Alder Lake',6,12,65,'img/9173236d-29ea-4aec-a7d2-3d599735653c.jpg',14900,9),(53,'Core i5-13600','Intel','LGA1700','3.5 GHz','Raptor Lake',14,24,125,'img/1d727ac2-7efd-47a7-a44e-a45598653b6b.jpg',32900,9),(56,'Core i5-13500','Intel','LGA1700','2.5 GHz','Raptor Lake',14,24,65,'img/4c895d41-9553-43a5-acda-8e20fd34fd9b.jpg',28900,9),(57,'Core i5-13500F','Intel','LGA1700','2.5 GHz','Raptor Lake',14,24,65,'img/59bef808-9c5f-4b4a-b259-bcf71f4e47d2.jpg',26900,9),(58,'Core i5-13400','Intel','LGA1700','2.5 GHz','Raptor Lake',10,20,65,'img/890cd3e9-56b8-4cd3-8001-af448b89963c.jpg',26900,9),(60,'Core i5-13400KF','Intel','LGA1700','3.4 GHz','Raptor Lake',10,20,65,'img/9ba5561c-9b44-44c1-a114-0d41acf45dcb.jpg',27900,9),(61,'Core i3-13100','Intel','LGA1700','3.4 GHz','Raptor Lake',4,12,60,'img/4d189d0a-86d8-4b05-8d03-1aa54a53b332.jpg',14900,9),(62,'Core i3-13100F','Intel','LGA1700','3.4 GHz','Raptor Lake',4,12,60,'img/06cf694c-04f7-4f05-8fd4-602742ac0ac4.jpg',13900,9),(63,'Core i3-13300','Intel','LGA1700','3.5 GHz','Raptor Lake',8,12,60,'img/440b4e41-591a-4e63-bdbe-3d2f9bf8e634.jpg',15900,9),(64,'Core i3-13300F','Intel','LGA1700','3.5 GHz','Raptor Lake',8,12,60,'img/95ebaa2b-cd7d-4465-a93d-ed69b61a3198.jpg',14900,9),(65,'Core i7-13700','Intel','LGA1700','3.1 GHz','Raptor Lake',16,30,125,'img/bea24d4e-5c66-4c0e-af33-29018e93156d.jpg',41900,9),(68,'Core i7-13700F','Intel','LGA1700','3.1 GHz','Raptor Lake',16,30,65,'img/2d0b1a85-5f92-46b0-a3cd-cee4a375c187.jpg',39900,9),(69,'Core i9-13900','Intel','LGA1700','3.0 GHz','Raptor Lake',24,36,125,'img/7693f528-85ef-4695-bf85-9d6d124dfdc4.jpg',55900,9),(72,'Core i9-13900F','Intel','LGA1700','3.0 GHz','Raptor Lake',24,36,65,'img/703f4990-96e2-4865-a0ad-6ebef0335a73.jpg',52900,9),(73,'Core i5-14600','Intel','LGA1700','3.4 GHz','Raptor Lake Refresh',14,24,125,'img/de20b06d-467f-4fa4-90c7-0948c65e9d9e.jpg',36900,9),(75,'Core i5-14600KF','Intel','LGA1700','3.6 GHz','Raptor Lake Refresh',14,24,125,'img/83e59933-66c8-43f8-b488-d91eef6852d6.jpg',37900,9),(76,'Core i5-14500','Intel','LGA1700','3.0 GHz','Raptor Lake Refresh',10,20,65,'img/bf4121d7-f881-4a35-bc39-263ba0e8afb5.jpg',29900,9),(77,'Core i5-14500F','Intel','LGA1700','3.0 GHz','Raptor Lake Refresh',10,20,65,'img/406a9896-b8f2-4eeb-bbd6-eeb64edbf7af.jpg',27900,9),(78,'Core i7-14700','Intel','LGA1700','3.3 GHz','Raptor Lake Refresh',20,33,125,'img/ee97d7a5-1553-4ef2-988f-412bf253c203.jpg',48900,9),(79,'Core i7-14700K','Intel','LGA1700','3.4 GHz','Raptor Lake Refresh',20,33,125,'img/a26f3f8a-ed68-47ae-9a93-7c01cc083948.jpg',51900,9),(80,'Core i7-14700KF','Intel','LGA1700','3.4 GHz','Raptor Lake Refresh',20,33,125,'img/909e44ab-5166-4769-97de-25dd86b2e077.jpg',49900,9),(81,'Core i7-14700F','Intel','LGA1700','3.3 GHz','Raptor Lake Refresh',20,33,65,'img/07e3afa1-0d13-4c59-a8c6-1c9bee1ab9ad.jpg',45900,9),(82,'Core i9-14900','Intel','LGA1700','3.2 GHz','Raptor Lake Refresh',24,36,125,'img/4350e5b5-8902-47fa-8fb4-6f2af3cec10a.jpg',64900,9),(84,'Core i9-14900KF','Intel','LGA1700','3.2 GHz','Raptor Lake Refresh',24,36,125,'img/02ad5e7e-a471-46ad-93dc-79940c15007e.jpg',65900,9),(85,'Core i9-14900F','Intel','LGA1700','3.2 GHz','Raptor Lake Refresh',24,36,65,'img/5e255c7c-16ac-46cb-8672-33fd29bb6ab9.jpg',61900,9),(86,'Ryzen 5 7600','AMD','AM5','3.8 GHz','Zen 4',6,32,65,'img/0d0fcc7c-6728-4cb4-8b2b-6427646b4fc3.jpg',22900,9),(88,'Ryzen 7 7700','AMD','AM5','3.8 GHz','Zen 4',8,32,65,'img/0cb40683-abea-4617-80e2-25d64ec738f4.jpg',29900,9),(90,'Ryzen 9 7900','AMD','AM5','4.0 GHz','Zen 4',12,64,65,'img/459a1607-b388-46f8-afbe-5c2b6727a594.jpg',39900,9),(93,'Ryzen 9 7950X3D','AMD','AM5','4.2 GHz','Zen 4',16,128,120,'img/d6ff09fa-8760-4572-bcfe-935153e213a6.jpg',74900,9),(95,'Ryzen 7 7800X','AMD','AM5','4.2 GHz','Zen 4',8,32,105,'img/534f77c2-00f8-476e-9f59-1ebcad527d7e.jpg',37900,9),(98,'Ryzen 9 7950','AMD','AM5','4.0 GHz','Zen 4',16,64,170,'img/30b636d4-867f-43cd-b2a3-64a545884287.jpg',62900,9),(99,'Ryzen 5 7640X','AMD','AM5','5.1 GHz','Zen 5',6,32,105,'img/472c2e56-cb34-41cf-94a9-53665b114bf2.jpg',27900,99),(100,'Ryzen 7 7840X','AMD','AM5','4.8 GHz','Zen 5',8,32,120,'img/d74f4eed-8017-4421-a483-69c766e53f36.jpg',39900,9),(101,'Ryzen 9 7940X','AMD','AM5','4.5 GHz','Zen 5',12,64,170,'img/94ac72fe-6f21-42f5-ac87-f38c39e8997f.jpg',54900,9),(103,'Ryzen 7 7800','AMD','AM5','4.0 GHz','Zen 5',8,32,65,'img/bc9af00d-ad59-46e1-b289-c0df1ea832b3.jpg',35900,9),(104,'Ryzen 5 7650','AMD','AM5','3.5 GHz','Zen 5',6,32,65,'img/acebd105-25d3-49b2-8583-83cc6befa820.jpg',24900,9),(105,'Ryzen 5 7650X','AMD','AM5','4.2 GHz','Zen 5',6,32,105,'img/b8d76109-2f13-4223-a7bb-1f584cd4ca0d.jpg',26900,9),(106,'Ryzen 9 7960X','AMD','AM5','4.2 GHz','Zen 5',16,64,170,'img/61f21e7e-9d6a-4d8e-8f46-0d93edf6b49a.jpg',74900,9),(107,'Ryzen 9 7980X','AMD','AM5','4.0 GHz','Zen 5',16,64,170,'img/6e5e17ea-13ed-4dc8-b80f-5ff2d947afc9.jpg',84900,9),(108,'Ryzen 7 7850X3D','AMD','AM5','4.0 GHz','Zen 5',8,96,120,'img/2b01da6d-5226-4bd0-8c4a-6d42c9f6e1a1.jpg',49900,9),(110,'Ryzen 5 7600X3D','AMD','AM5','4.0 GHz','Zen 5',6,96,105,'img/6cee49d7-be23-4d63-9cc2-9e2b30d67385.jpg',32900,9),(112,'Ryzen 7 7840','AMD','AM5','4.0 GHz','Zen 5',8,32,65,'img/c9a7ad41-6e37-428d-ab95-82edb3355664.jpg',37900,9),(113,'Ryzen 9 7945X','AMD','AM5','4.2 GHz','Zen 5',12,64,170,'img/304d6f7d-cd40-4272-8045-fcf11b0108cc.jpg',59900,9),(114,'Ryzen 9 7955X','AMD','AM5','4.5 GHz','Zen 5',16,64,170,'img/925a2ba2-3a13-424f-ab5e-f399870f4608.jpg',69900,9),(115,'Ryzen 7 7845X','AMD','AM5','4.5 GHz','Zen 5',8,32,120,'img/523c5ec4-9bd7-42c5-8586-66a406124dec.jpg',42900,9),(116,'Ryzen 5 7645X','AMD','AM5','4.0 GHz','Zen 5',6,32,105,'img/17e29c15-acdb-4489-a231-cae8a9979701.jpg',27900,9),(117,'Ryzen 5 7640','AMD','AM5','3.8 GHz','Zen 5',6,32,65,'img/9d38d4ef-dd40-4e40-835a-40cbc903929f.jpg',25900,9),(119,'Ryzen 7 7845','AMD','AM5','4.5 GHz','Zen 5',8,32,120,'img/56af6399-f189-44b9-93ee-41e5f6b5bc6a.jpg',39900,9),(120,'Ryzen 9 7955X3D','AMD','AM5','4.2 GHz','Zen 5',16,128,120,'img/17fa9a5a-8898-4330-af83-5520427a9e6c.jpg',74900,9),(121,'Ryzen 9 7965X','AMD','AM5','4.2 GHz','Zen 5',16,64,170,'img/7f06306d-7a20-46d1-9004-90a00d0b6e02.jpg',79900,9),(122,'Ryzen 9 7975X','AMD','AM5','4.2 GHz','Zen 5',16,64,170,'img/aa36bacb-7483-4866-9790-700c626bfce1.jpg',82900,9),(123,'Ryzen 9 7985X','AMD','AM5','4.0 GHz','Zen 5',16,64,170,'img/41cda25b-a5f5-467f-833b-2c66375446ff.jpg',84900,9),(124,'Ryzen 5 7655X','AMD','AM5','4.2 GHz','Zen 5',6,32,105,'img/7763d6ec-c31d-42eb-ba65-558ba24c6e89.jpg',26900,9),(125,'Ryzen 5 7660X','AMD','AM5','4.5 GHz','Zen 5',6,32,105,'img/54d6762d-a433-40aa-93bb-9fcf0ae09b2b.jpg',27900,9),(126,'Ryzen 7 7850X','AMD','AM5','4.5 GHz','Zen 5',8,32,120,'img/62308db8-439e-443d-9b8e-683111adeb62.jpg',43900,9),(127,'Ryzen 7 7860X','AMD','AM5','4.6 GHz','Zen 5',8,32,120,'img/500e4814-3c7a-4402-ae03-3ad2c03d9aa1.jpg',44900,9),(128,'Ryzen 9 7960X3D','AMD','AM5','4.2 GHz','Zen 5',16,128,120,'img/bf845aa1-4496-461d-b666-70e20ec1abb2.jpg',79900,9),(129,'Ryzen 9 7970X3D','AMD','AM5','4.2 GHz','Zen 5',16,128,120,'img/02a8030f-db38-4348-9009-df990cf81d3a.jpg',82900,9),(130,'Ryzen 9 7980X3D','AMD','AM5','4.0 GHz','Zen 5',16,128,120,'img/8fbef24c-36c4-48ae-9a4a-8c0a8ff5e16d.jpg',84900,9),(131,'Ryzen 7 7850','AMD','AM5','4.0 GHz','Zen 5',8,32,65,'img/799471bb-94c8-4132-af49-a36489ee4004.jpg',39900,9),(132,'Ryzen 7 7860','AMD','AM5','4.0 GHz','Zen 5',8,32,65,'img/ee7ef93b-d408-4eee-b1ba-b58bc8065bbc.jpg',40900,9),(133,'Ryzen 5 7660','AMD','AM5','3.8 GHz','Zen 5',6,32,65,'img/a0579f8d-c6f1-49b0-8c69-1daedfb74731.jpg',27900,9),(134,'Ryzen 5 7670X','AMD','AM5','4.2 GHz','Zen 5',6,32,105,'img/8a9f0689-807d-498b-bbd9-4438630a9e92.jpg',28900,9),(135,'Ryzen 7 7870X3D','AMD','AM5','4.2 GHz','Zen 5',8,96,120,'img/4dff63f4-dc16-462b-8d9c-d672f37688bb.jpg',49900,9),(136,'Ryzen 7 7880X3D','AMD','AM5','4.2 GHz','Zen 5',8,96,120,'img/8c783181-03d1-48fe-aae2-eb04223cdec7.jpg',50900,9),(137,'Ryzen 9 7990X','AMD','AM5','4.0 GHz','Zen 5',16,64,170,'img/efa2fb31-1785-4b88-8557-227b02f6936f.jpg',86900,9),(138,'Ryzen 9 7995X','AMD','AM5','4.2 GHz','Zen 5',16,64,170,'img/f08a7714-e183-473b-bb99-2f92634d47b2.jpg',87900,9),(139,'Ryzen 9 7995X3D','AMD','AM5','4.2 GHz','Zen 5',16,128,120,'img/e20954f8-3797-4dfe-b0b9-7d083e762f98.jpg',89900,9),(140,'Ryzen 5 7680X','AMD','AM5','4.5 GHz','Zen 5',6,32,105,'img/629e3bc5-123a-4a95-8e1b-76db2ae7a2a9.jpg',29900,9),(141,'Ryzen 5 7690X','AMD','AM5','4.6 GHz','Zen 5',6,32,105,'img/8d3751dc-e177-40cf-b8ba-e1693a5670c3.jpg',30900,9),(142,'Ryzen 7 7890X','AMD','AM5','4.5 GHz','Zen 5',8,32,120,'img/573ae400-7f90-4c15-bfc4-114ea4a4333d.jpg',45900,9),(143,'Ryzen 7 7900X','AMD','AM5','4.5 GHz','Zen 5',8,32,120,'img/a92e6774-97db-482a-975c-0227928c3341.jpg',46900,9),(144,'Ryzen 9 7990X3D','AMD','AM5','4.2 GHz','Zen 5',16,128,120,'img/f18111cc-bdce-4ecc-98e3-22c65ef9fa31.jpg',89900,9),(147,'Ryzen 7 7910X','AMD','AM5','4.5 GHz','Zen 5',8,32,120,'img/379baaa2-a723-4aa7-ab5f-2a66f3dd654b.jpg',47900,9),(148,'Ryzen 7 7920X','AMD','AM5','4.6 GHz','Zen 5',8,32,120,'img/2495fc99-dbbb-4f89-80cc-b6734c9a186f.jpg',48900,9),(149,'Ryzen 5 7700X3D','AMD','AM5','4.2 GHz','Zen 5',6,96,105,'img/1908b75a-bbe5-4387-bf28-5071c9f24bcd.jpg',32900,9),(150,'Ryzen 5 7710X','AMD','AM5','4.5 GHz','Zen 5',6,32,105,'img/1f5ac2fa-c331-4d1a-9d00-906fb7dd1f82.jpg',33900,9);
/*!40000 ALTER TABLE `processors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ram`
--

DROP TABLE IF EXISTS `ram`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ram` (
  `id` int NOT NULL AUTO_INCREMENT,
  `model` varchar(255) NOT NULL,
  `produser` varchar(255) NOT NULL,
  `capacity_gb` int NOT NULL,
  `speed_mhz` int NOT NULL,
  `ram_type` varchar(255) NOT NULL,
  `image` varchar(150) DEFAULT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  `cost` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ram`
--

LOCK TABLES `ram` WRITE;
/*!40000 ALTER TABLE `ram` DISABLE KEYS */;
INSERT INTO `ram` VALUES (1,'Vengeance LPX','Corsair',16,3200,'DDR4','img/416ec5f9-1f36-4e14-aa52-99402b1e386b.jpg',9,5000),(2,'Vengeance LPX','Corsair',16,3200,'DDR4','img/79295735-a915-4de4-9e47-aee62f2f6904.jpg',9,7000),(3,'Vengeance RGB Pro','Corsair',16,3600,'DDR4','img/1199b05e-9216-490a-a6db-c8e49ba77f83.jpg',99,6000),(4,'Vengeance RGB Pro','Corsair',32,3600,'DDR4','img/1ebd7429-fb9a-4c4b-9774-c2c78a3fe14b.jpg',9,11000),(5,'Dominator Platinum','Corsair',32,3600,'DDR4','img/86c4717c-8f8a-4b86-8274-9a28f70e38e3.jpg',9,15000),(6,'Trident Z RGB','G.Skill',16,3600,'DDR4','img/e5ebe4db-ba6a-45c5-88e7-11c86441d596.jpg',9,6500),(7,'Trident Z RGB','G.Skill',32,3600,'DDR4','img/fdd85979-bc8e-450f-a8ec-13fe987a1aeb.jpg',95,12000),(8,'Ripjaws V','G.Skill',16,3200,'DDR4','img/aeac9706-3ecf-4a17-a409-b64b29f9e484.jpg',9,4500),(9,'Ripjaws V','G.Skill',32,3200,'DDR4','img/d7bf48a5-1d91-482d-a348-2fa606af2c7c.jpg',9,8000),(10,'Trident Z Neo','G.Skill',32,3600,'DDR4','img/a67b5186-3ea2-4c3f-8cd4-fff93e8576e7.jpg',9,13000),(11,'Ballistix','Crucial',16,3200,'DDR4','img/bee6ef72-bcee-4d42-a1b0-40dc8074d527.jpg',9,4000),(12,'Ballistix','Crucial',32,3200,'DDR4','img/f5492f9a-6ba4-4303-96fe-9d87d52bd178.jpg',9,7500),(13,'Vengeance','Corsair',32,5600,'DDR5','img/0cf9b771-b790-4700-9e94-c9fa96524c05.jpg',9,12000),(14,'Vengeance','Corsair',64,5600,'DDR5','img/c4212cfa-1fee-4598-8d3c-f3b3cc7575a6.jpg',9,22000),(15,'Trident Z5 RGB','G.Skill',32,6000,'DDR5','img/c73ecfe9-11ad-4fae-a338-a48777e77b93.jpg',7,14000),(16,'Trident Z5 RGB','G.Skill',64,6000,'DDR5','img/454d5b9f-b8b0-477f-9590-328cdfda3a3e.jpg',9,25000),(17,'Ripjaws S5','G.Skill',32,5600,'DDR5','img/4ebb49cb-e3bc-4295-8617-53ff05ade940.jpg',9,11000),(18,'Ripjaws S5','G.Skill',64,5600,'DDR5','img/acc81701-df32-4345-a946-0f915b79c181.jpg',9,20000),(19,'Value Select','Crucial',16,4800,'DDR5','img/c9e48842-ae1b-4e52-a64c-27a3be781ab0.jpg',9,6000),(20,'Value Select','Crucial',32,4800,'DDR5','img/03ea4dff-f605-4c3c-9fe9-89ffc658c306.jpg',9,11000),(21,'Hunter','HyperX',16,3200,'DDR4','img/2dccf62e-7522-49a8-b361-292c85677843.jpg',9,5500),(22,'Fury','HyperX',32,3200,'DDR4','img/96ba91e8-a756-4656-8578-dd780aaad4b3.jpg',9,9500),(23,'Predator','HyperX',32,3600,'DDR4','img/d64c8025-aa1b-420a-ba4b-331fe9c5356f.jpg',9,12000),(24,'ValueRAM','Kingston',8,2666,'DDR4','img/e212ecca-9fdc-4f3d-b568-09fd0c7be5fc.jpg',9,2500),(25,'ValueRAM','Kingston',16,2666,'DDR4','img/82d5f11d-cba9-4ae4-9b4c-1ad6023df64e.jpg',99,4500),(26,'Beast','Team Group',16,3200,'DDR4','img/7e3f0cf9-16e7-48dd-9e02-426adb1eb26d.jpg',9,4200),(27,'Delta RGB','Team Group',32,3600,'DDR4','img/db739ce6-ac04-4795-9c7b-9316cf168974.jpg',9,8500),(28,'T-Force Vulcan Z','Team Group',16,3200,'DDR4','img/26059a4d-e618-47b2-ac2e-87c54e799747.jpg',9,4000),(29,'T-Force Xtreem','Team Group',32,3600,'DDR4','img/8bafc7d4-a48b-403f-be5d-57bb57d6ca8d.jpg',9,9000);
/*!40000 ALTER TABLE `ram` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `id` int NOT NULL AUTO_INCREMENT,
  `role_name` varchar(155) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Пользователь'),(2,'Товаровед'),(3,'Администратор');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `surname` varchar(255) NOT NULL,
  `patronymic` varchar(255) DEFAULT NULL,
  `role` varchar(255) NOT NULL,
  `login` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `activity` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `login_UNIQUE` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (1,'Петя','Петров','','1','petr','5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8',0),(2,'Иван','Иванов','','2','ivan','cd0b9452fc376fc4c35a60087b366f70d883fc901524daf1f122fbd319384f6a',0),(3,'Антон','Антонов','','3','anton','1f29f2d29f02f2608eb72d45625ba3a851eda1ee2be1bda22427a584b787c722',0),(4,'Сергей','сергеев','Сергеевич','1','sergey','e2d279cba45ada22aa30991a04f8fcc7280c7250dcf6454a41e348de6d4627b1',0),(6,'аываываыв','аываываыа','ываываыва','1','sergay','b6602f58690ca41488e97cd28153671356747c951c55541b6c8d8b8493eb7143',1),(7,'Павел','Романгов','Евгеньевич','1','sergey11','96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e',0),(8,'Фыв','Фыв','Ывфыв','1','ads','688787d8ff144c502c7f5cffaafe2cc588d86079f9de88304c26b0cb99ce91c6',1),(9,'Фыв','Фыв','Фвф','1','asd','688787d8ff144c502c7f5cffaafe2cc588d86079f9de88304c26b0cb99ce91c6',1),(10,'Фывфыв','Фыв','Фыв','3','fyvfyv','5757891be082c3d8041bfb013aba35509a032c636254636bd7f78a500d6e18c4',1);
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `statuses`
--

DROP TABLE IF EXISTS `statuses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `statuses` (
  `id` int NOT NULL,
  `status` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `statuses`
--

LOCK TABLES `statuses` WRITE;
/*!40000 ALTER TABLE `statuses` DISABLE KEYS */;
INSERT INTO `statuses` VALUES (1,'Новый'),(2,'В работе'),(3,'Сборка'),(4,'Доставляется'),(5,'Выполен'),(6,'Удалён'),(7,'Отменён'),(8,'Возвращен');
/*!40000 ALTER TABLE `statuses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `storage`
--

DROP TABLE IF EXISTS `storage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `storage` (
  `id` int NOT NULL AUTO_INCREMENT,
  `model` varchar(255) NOT NULL,
  `produser` varchar(255) NOT NULL,
  `type_of_device` varchar(255) NOT NULL,
  `capacity_gb` int NOT NULL,
  `write_speed` int NOT NULL,
  `read_speed` int NOT NULL,
  `interface` varchar(255) NOT NULL,
  `image` varchar(150) DEFAULT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  `cost` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `storage`
--

LOCK TABLES `storage` WRITE;
/*!40000 ALTER TABLE `storage` DISABLE KEYS */;
INSERT INTO `storage` VALUES (1,'870 EVO','Samsung','SSD',1000,530,560,'SATA III','img/0c87caf1-76ff-499f-986d-d2ec021b4a32.jpg',9,8000),(2,'870 EVO','Samsung','SSD',2000,530,560,'SATA III','img/70d9de2f-b9ab-4db5-abb6-7b714ff73795.jpg',9,15000),(3,'870 QVO','Samsung','SSD',1000,520,550,'SATA III','img/125c7829-72b3-460f-8dff-9ba7253eebcd.jpg',9,6000),(4,'870 QVO','Samsung','SSD',2000,520,550,'SATA III','img/f2e9dc33-b46e-4feb-a438-98b331313c4f.jpg',9,12000),(5,'WD Blue','Western Digital','SSD',1000,530,560,'SATA III','img/e7b0af1b-f5a9-4d2d-ba7f-d6d9f996ec2b.jpg',9,7500),(6,'WD Blue','Western Digital','SSD',2000,530,560,'SATA III','img/fa4362b8-0659-4964-9f67-fb81ba8c869c.jpg',7,14000),(7,'MX500','Crucial','SSD',1000,510,560,'SATA III','img/ab5fa530-817d-4228-a565-818cb59ed6de.jpg',9,7000),(8,'MX500','Crucial','SSD',2000,510,560,'SATA III','img/26a1a0ef-fce7-4f5c-8a9e-2796cd676dc1.jpg',9,13000),(9,'970 EVO Plus','Samsung','M.2 SSD',1000,3300,3500,'PCIe 3.0 x4','img/67666ca9-137e-4e07-88f9-2297d751d9eb.png',9,9000),(10,'970 EVO Plus','Samsung','M.2 SSD',2000,3300,3500,'PCIe 3.0 x4','img/d93265e9-ce89-4a20-bfbb-3bcae9c9a3d0.png',9,16000),(11,'980 PRO','Samsung','M.2 SSD',1000,5000,7000,'PCIe 4.0 x4','img/60e9e988-5f61-4b84-8a2e-db5d902ca1e7.png',9,11000),(12,'980 PRO','Samsung','M.2 SSD',2000,5000,7000,'PCIe 4.0 x4','img/db7e1a19-d9b6-4e82-ab73-6d34dab72561.png',9,19000),(13,'SN850','Western Digital','M.2 SSD',1000,5200,7000,'PCIe 4.0 x4','img/425153c6-b6fe-47c2-884f-bc0f8e656226.jpg',9,10000),(14,'SN850','Western Digital','M.2 SSD',2000,5200,7000,'PCIe 4.0 x4','img/93cfa0e7-64ed-48f2-aa85-5e6a40fa4244.jpg',9,18000),(15,'FireCuda 530','Seagate','M.2 SSD',1000,5300,7300,'PCIe 4.0 x4','img/04058f05-9f89-4814-bad3-f6791a9c7455.jpg',9,12000),(16,'FireCuda 530','Seagate','M.2 SSD',2000,5300,7300,'PCIe 4.0 x4','img/03860b7a-e476-478a-94c5-4f88517d9f20.jpg',9,21000),(17,'KC3000','Kingston','M.2 SSD',1000,6000,7000,'PCIe 4.0 x4','img/9b0162d1-faa9-404a-a199-35f90bb72bbe.jpg',9,9500),(18,'KC3000','Kingston','M.2 SSD',2000,6000,7000,'PCIe 4.0 x4','img/d153b697-16d7-4c1f-88f5-daa8c021d523.jpg',9,17000),(19,'WD Blue','Western Digital','HDD',1000,180,180,'SATA III','img/4fca3545-037c-46e0-9acd-0dcc7f28a903.jpg',9,4000),(20,'WD Blue','Western Digital','HDD',2000,180,180,'SATA III','img/b6e92e02-8dad-4b3c-8138-02f47926c9f5.jpg',9,6000),(21,'BarraCuda','Seagate','HDD',1000,190,190,'SATA III','img/49dba90d-7aab-4584-a14b-f5a569bfc2f0.jpg',9,3500),(22,'BarraCuda','Seagate','HDD',2000,190,190,'SATA III','img/2c65b23e-ebef-4ecd-8f2b-e441748afa03.jpg',9,5500),(23,'WD Black','Western Digital','HDD',2000,220,220,'SATA III','img/156f4f17-ce6a-4172-9451-9950f2ec1224.jpg',9,8000),(24,'WD Black','Western Digital','HDD',4000,220,220,'SATA III','img/4326b956-13ad-42f9-b278-3803df2400ad.jpg',9,12000),(25,'BarraCuda Pro','Seagate','HDD',2000,250,250,'SATA III','img/eb21968d-9685-4233-b0ab-887bd9cacc07.jpg',9,9000),(26,'BarraCuda Pro','Seagate','HDD',4000,250,250,'SATA III','img/e4c9075f-8f5a-4061-a81c-ae5c3dc4d810.jpg',9,14000),(27,'970 EVO','Samsung','M.2 SSD',500,2500,3400,'PCIe 3.0 x4','img/a5e98695-e337-4800-bf73-f3b43d95e5a9.png',9,5000),(28,'980','Samsung','M.2 SSD',500,2600,3100,'PCIe 3.0 x4','img/cb5cfd49-552f-4ca4-972a-58b4938ed2c4.png',9,4500),(29,'SN770','Western Digital','M.2 SSD',500,4000,5000,'PCIe 4.0 x4','img/c49cf2f8-2870-4bed-9b36-fff162af1ff7.jpg',9,5500),(30,'P5 Plus','Crucial','M.2 SSD',1000,5000,6600,'PCIe 4.0 x4','img/ba256331-cea8-4790-b7ab-f428824f06c8.jpg',9,8500);
/*!40000 ALTER TABLE `storage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `suppliers` (
  `id` int unsigned NOT NULL,
  `name` varchar(155) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'Комплектующие ВСЕМ'),(2,'Детали для ПК'),(3,'ООО \"ААА\"'),(4,'ЗАО \"Компьютер\"');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `thermo_interface`
--

DROP TABLE IF EXISTS `thermo_interface`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `thermo_interface` (
  `id` int NOT NULL AUTO_INCREMENT,
  `model` varchar(255) NOT NULL,
  `produser` varchar(255) NOT NULL,
  `thermal_conductivity` decimal(19,2) NOT NULL,
  `packege_volume` decimal(19,2) NOT NULL,
  `shel_life` int NOT NULL,
  `composition` varchar(255) NOT NULL,
  `image` varchar(150) DEFAULT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  `cost` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `model_UNIQUE` (`model`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `thermo_interface`
--

LOCK TABLES `thermo_interface` WRITE;
/*!40000 ALTER TABLE `thermo_interface` DISABLE KEYS */;
INSERT INTO `thermo_interface` VALUES (1,'MX-4','Arctic',8.50,4.00,8,'Carbon Micro-Particles','img/a3ee7d57-7f49-4dec-9f38-567a134f4a88.jpg',9,800),(2,'MX-6','Arctic',8.50,3.50,8,'Diamond Particles','img/0854ed0a-40fd-45e5-b43c-a05e06a15cd9.jpg',9,1000),(3,'NT-H1','Noctua',5.60,3.50,3,'Metal Oxide Ceramic','img/df897d86-86ee-456d-92e6-f9f38c7a3031.jpg',9,700),(4,'NT-H2','Noctua',8.90,3.50,3,'Advanced Metal Oxide','img/bcad8373-724d-47af-94de-3210c46e4704.jpg',9,1000),(5,'MasterGel Maker','Cooler Master',11.00,4.00,4,'Nano Diamond','img/0f1ec3f8-eb36-4ca2-a271-25afb681c00c.jpg',9,1500),(6,'MasterGel Pro','Cooler Master',5.00,4.00,4,'Silicone Compound','img/4171d41a-5f24-4b62-b09b-abfccb6825a5.jpg',9,600),(7,'TG-7','Thermal Grizzly',12.50,1.00,5,'Carbon-based','img/4f193378-94b1-4f16-9e72-bfb2708354bc.jpg',9,1800),(8,'Kryonaut','Thermal Grizzly',12.50,1.00,5,'Carbon Micro-Particles','img/82db1ef1-c93f-461c-9266-306484d51b88.jpg',9,2000),(9,'Conductonaut','Thermal Grizzly',73.00,1.00,5,'Liquid Metal','img/8c8366f0-4bb2-48ed-ac2e-81435a22e1c4.jpg',9,2500),(10,'Z3','Zalman',7.50,3.00,3,'Ceramic Compound','img/05e33f3f-dd04-42bb-9e3c-eb96730e8265.jpg',9,500),(11,'Z9','Zalman',9.50,3.00,3,'Diamond Compound','img/e2dd73ed-5397-4275-afd8-ebcec41b5fa6.jpg',99,900),(12,'IC Essential E1','Innovation Cooling',4.50,3.00,3,'Silicone Based','img/f6ff3241-3081-4738-bc6f-84a341e9dd46.jpg',9,400),(13,'IC Diamond','Innovation Cooling',4.50,3.00,3,'Diamond Particles','img/54732b1e-996b-44fb-8903-eed7f8746c66.jpg',9,1100),(14,'GC-Extreme','Gelid Solutions',8.50,3.50,3,'Metal Particles','img/e95e2812-800c-49a3-9804-8d5406c84299.jpg',9,1000),(15,'GC-2','Gelid Solutions',6.50,3.50,3,'Ceramic Compound','img/9a0eec23-7f21-4a4a-811d-10f33867792a.jpg',99,600),(16,'SY-Y820','Deepcool',8.50,3.00,4,'Metal Particles','img/926fe18e-ec4c-4353-9718-0b044ea23ec1.jpg',9,750),(17,'Z5','Deepcool',6.50,3.00,4,'Ceramic Compound','img/c8c87fba-5c75-4b58-bd38-7fe527982f1d.jpg',9,450),(18,'PK-3','ProlimaTech',11.20,5.00,5,'Diamond Particles','img/e8cb4dae-9a1d-4e9d-9496-929e672b4ee7.jpg',9,1300),(19,'Aeronaut','Aeronaut',7.50,3.00,3,'Ceramic Based','img/7aa2be9d-75a8-4cef-96ff-be17a4e4aa0b.jpg',9,550),(20,'KPX','Kexin',13.50,2.00,4,'Diamond Particles','img/99f3ce07-0a00-4b53-8421-41b2ae3fd442.jpg',9,1400),(21,'TF8','Thermalright',13.80,2.00,5,'Diamond Particles','img/f251ef1b-a4ec-4a68-8f7c-a0a921403616.jpg',9,1600),(22,'TFX','Thermalright',14.30,2.00,5,'High-density Compound','img/b9c6eca1-d844-4c9e-aba0-fed1588772ee.jpg',7,1900),(23,'SHIN ETSU','X23-7783D',6.00,2.00,5,'Silicone Based','img/8f66c22f-fa14-4262-b35c-df37d8ea32ba.jpg',9,900),(24,'HY883','HuiYao',8.50,3.00,3,'Ceramic Compound','img/4cf480d6-0145-4537-92d6-10a3015eb27a.jpg',9,600),(25,'GD-2','G.D.',9.50,3.00,3,'Metal Oxide','img/4772a0d9-6b72-4f72-b2f5-370a49fe0125.jpg',9,700),(26,'KPT-8','Kafuter',6.50,3.00,3,'Silicone Thermal Grease','img/15fca06c-df30-4928-b334-b9f3cdcf2e72.jpg',86,400),(27,'GT-2','Goot',7.50,3.00,3,'Ceramic Based','img/12412c3c-be9c-424c-a898-c47ba015a27e.jpg',9,500),(28,'AS5','Arctic Silver',8.90,3.50,8,'Silver Compound','img/52425a72-af64-45a7-adcc-7327f87a6b30.jpg',9,1000),(29,'AS Ceramique','Arctic Silver',4.50,3.50,8,'Ceramic Compound','img/e18162bd-f83b-4946-abbc-7cd48778c6f9.jpg',9,600),(30,'CMT-4','Coollaboratory',38.00,1.00,5,'Liquid Metal','img/2513919e-6931-4b13-9d08-cee412733a3e.jpg',9,2200);
/*!40000 ALTER TABLE `thermo_interface` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_cart`
--

DROP TABLE IF EXISTS `user_cart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_cart` (
  `iduser` int NOT NULL,
  `id_processors` int DEFAULT NULL,
  `id_motherboards` int DEFAULT NULL,
  `id_videocards` int DEFAULT NULL,
  `id_ram` int DEFAULT NULL,
  `count_ram` int DEFAULT '1',
  `id_cpu_cooler` int DEFAULT NULL,
  `id_cases` int DEFAULT NULL,
  `id_case_coolers` int DEFAULT NULL,
  `count_case_fan` int DEFAULT '1',
  `id_thermo_interface` int DEFAULT NULL,
  `id_storage` int DEFAULT NULL,
  `count_storage` int DEFAULT NULL,
  `id_power_supplier` int DEFAULT NULL,
  `extra_items` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci,
  PRIMARY KEY (`iduser`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_cart`
--

LOCK TABLES `user_cart` WRITE;
/*!40000 ALTER TABLE `user_cart` DISABLE KEYS */;
INSERT INTO `user_cart` VALUES (0,0,0,0,0,0,0,0,0,0,0,0,0,8,NULL),(1,0,0,0,0,0,0,0,0,0,26,0,0,0,'');
/*!40000 ALTER TABLE `user_cart` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `videocards`
--

DROP TABLE IF EXISTS `videocards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `videocards` (
  `id` int NOT NULL AUTO_INCREMENT,
  `model` varchar(255) NOT NULL,
  `produser` varchar(255) NOT NULL,
  `memory` int NOT NULL,
  `bus_width` int NOT NULL,
  `memory_type` varchar(255) NOT NULL,
  `interface` varchar(255) NOT NULL,
  `power_consumption` int NOT NULL,
  `vender` varchar(255) NOT NULL,
  `gpu_lenght` int NOT NULL,
  `image` varchar(150) DEFAULT NULL,
  `inStock` int NOT NULL DEFAULT '0',
  `cost` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `videocards`
--

LOCK TABLES `videocards` WRITE;
/*!40000 ALTER TABLE `videocards` DISABLE KEYS */;
INSERT INTO `videocards` VALUES (1,'GeForce RTX 4090','NVIDIA',24,384,'GDDR6X','PCIe 4.0',450,'ASUS',340,'img/27438a53-821d-4d03-b0d0-bbbe3c8e4cbf.png',1,180000),(2,'GeForce RTX 4090','NVIDIA',24,384,'GDDR6X','PCIe 4.0',450,'MSI',336,'img/d0caa1f2-773b-4dea-9d70-6c43de25385a.png',2,175000),(3,'GeForce RTX 4080 SUPER','NVIDIA',16,256,'GDDR6X','PCIe 4.0',320,'Gigabyte',331,'img/741281f1-9b4c-4c2e-8cae-2de95b4fa63f.png',4,120000),(4,'GeForce RTX 4080 SUPER','NVIDIA',16,256,'GDDR6X','PCIe 4.0',320,'ASUS',335,'img/9386ac50-849e-46d9-8c06-f3decf86b938.png',4,125000),(5,'GeForce RTX 4070 Ti SUPER','NVIDIA',16,256,'GDDR6X','PCIe 4.0',285,'MSI',308,'img/3986206c-f64a-486e-9849-d30c31e6fb70.png',4,90000),(6,'GeForce RTX 4070 Ti SUPER','NVIDIA',16,256,'GDDR6X','PCIe 4.0',285,'Zotac',326,'img/7ac75326-0aeb-4e77-8e13-1205a4d07051.png',4,85000),(7,'GeForce RTX 4070 SUPER','NVIDIA',12,192,'GDDR6X','PCIe 4.0',220,'ASUS',300,'img/4dc6ce29-1a73-460b-819f-2af8527e59c7.png',4,70000),(8,'GeForce RTX 4070 SUPER','NVIDIA',12,192,'GDDR6X','PCIe 4.0',220,'Gigabyte',281,'img/f5decd06-0a31-4b96-9628-3accb918ad0b.png',4,65000),(9,'GeForce RTX 4060 Ti','NVIDIA',8,128,'GDDR6','PCIe 4.0',160,'MSI',247,'img/e2a1d884-8f75-476a-a4c5-230de20614ea.png',4,45000),(10,'GeForce RTX 4060 Ti','NVIDIA',8,128,'GDDR6','PCIe 4.0',160,'ASUS',226,'img/cdcc6e4e-7d78-4cf4-814d-9af6668782c1.png',4,48000),(11,'GeForce RTX 4060','NVIDIA',8,128,'GDDR6','PCIe 4.0',115,'Gigabyte',199,'img/02401176-4f13-4e6a-ab12-437201b53ebc.png',4,35000),(14,'Radeon RX 7900 XTX','AMD',24,384,'GDDR6','PCIe 4.0',355,'PowerColor',330,'img/85e357b9-157b-4696-92ad-c208f5b99730.jpg',8,105000),(15,'Radeon RX 7900 XT','AMD',20,320,'GDDR6','PCIe 4.0',315,'XFX',266,'img/e1a527f3-e719-4435-ad6d-38d13d444184.jpg',8,85000),(16,'Radeon RX 7900 XT','AMD',20,320,'GDDR6','PCIe 4.0',315,'ASRock',280,'img/3e567ee9-a23b-466a-ae49-56643fa86577.jpg',8,80000),(18,'Radeon RX 7800 XT','AMD',16,256,'GDDR6','PCIe 4.0',263,'MSI',258,'img/48f4022f-5a3a-4199-a4be-8c04b2e5517d.jpg',8,62000),(20,'Radeon RX 7700 XT','AMD',12,192,'GDDR6','PCIe 4.0',245,'ASUS',280,'img/a96b10e1-a90e-4392-b60f-d01d1c3d319e.jpg',8,47000),(21,'Radeon RX 7600 XT','AMD',8,128,'GDDR6','PCIe 4.0',190,'PowerColor',202,'img/4f7d2e2b-9c7d-4005-9da6-36bb45510787.jpg',8,30000),(24,'GeForce RTX 3060','NVIDIA',12,192,'GDDR6','PCIe 4.0',170,'Gigabyte',282,'img/gigabyte3060.png',4,36000),(25,'Radeon RX 6600','AMD',8,128,'GDDR6','PCIe 4.0',132,'ASRock',190,'img/d81503ae-d504-49ea-ba6e-ef4d331ef8d3.jpg',8,25000),(27,'GeForce RTX 3050','NVIDIA',8,128,'GDDR6','PCIe 4.0',130,'ASUS',200,'img/7046505c-3e53-4b23-924f-eb8105385f89.png',4,28000),(29,'Radeon RX 6400','AMD',4,64,'GDDR6','PCIe 4.0',53,'ASRock',168,'img/5c952f17-30ea-4366-94f9-cc647f22d518.jpg',8,15000),(30,'GeForce GT 1030','NVIDIA',2,64,'GDDR5','PCIe 3.0',30,'Gigabyte',150,'img/5eaf4207-a000-418c-9733-21065319d576.png',4,8000),(31,'GeForce RTX 4080','NVIDIA',16,256,'GDDR6X','PCIe 4.0',320,'ASUS',335,'img/02182b27-94b5-49a5-b08d-6817143dc2e3.png',4,120000),(32,'GeForce RTX 4080','NVIDIA',16,256,'GDDR6X','PCIe 4.0',320,'MSI',331,'img/4a0cd561-f177-48c5-b3f9-8ba05723bc28.png',4,118000),(33,'GeForce RTX 4070 Ti','NVIDIA',12,192,'GDDR6X','PCIe 4.0',285,'ASUS',308,'img/2ba28e76-104d-4384-a141-858be5b1c602.png',4,85000),(34,'GeForce RTX 4070 Ti','NVIDIA',12,192,'GDDR6X','PCIe 4.0',285,'Gigabyte',326,'img/534275bc-460f-4c38-8fb0-b422ca22ede9.png',4,82000),(35,'GeForce RTX 4070','NVIDIA',12,192,'GDDR6X','PCIe 4.0',220,'MSI',300,'img/7f0cb99d-e124-4c4e-80a4-9c0023635485.png',4,70000),(36,'GeForce RTX 4070','NVIDIA',12,192,'GDDR6X','PCIe 4.0',220,'ASRock',281,'img/580803ea-f297-4d8e-ba7d-12d958aa692e.png',6,68000),(37,'GeForce RTX 4060 Ti','NVIDIA',8,128,'GDDR6','PCIe 4.0',160,'Gigabyte',247,'img/5f1a8e9a-3cc8-4408-872c-4b832ba8ede9.png',5,45000),(38,'GeForce RTX 4060 Ti','NVIDIA',8,128,'GDDR6','PCIe 4.0',160,'Zotac',226,'img/2ee93c78-6b17-4690-8f39-c0e506cc91f8.png',8,44000),(39,'GeForce RTX 4060','NVIDIA',8,128,'GDDR6','PCIe 4.0',115,'ASUS',199,'img/dadf0cb6-4f57-4441-94c9-36a7346a4de8.png',56,35000),(59,'GeForce RTX 4070 Ti SUPER','NVIDIA',16,256,'GDDR6X','PCIe 4.0',285,'ASUS',308,'img/899b404a-7177-4e17-aace-b9170cfe2497.png',8,90000),(66,'GeForce RTX 4060','NVIDIA',8,128,'GDDR6','PCIe 4.0',115,'Palit',220,'img/3ab755f0-c3fd-4d1c-abce-e6d00c4739ae.png',5,32000),(67,'Radeon RX 7900 XTX','AMD',24,384,'GDDR6','PCIe 4.0',355,'Sapphire',287,'img/8dec5fc5-f5e8-496c-981b-3d738d6a0bf2.jpg',8,110000),(71,'Radeon RX 7800 XT','AMD',16,256,'GDDR6','PCIe 4.0',263,'Sapphire',267,'img/80b7ff1e-9dbd-47d3-bc67-7319cf7a3b41.jpg',7,60000),(73,'Radeon RX 7700 XT','AMD',12,192,'GDDR6','PCIe 4.0',245,'Gigabyte',261,'img/0c762237-0f96-4a73-8bea-c4c5bba12ba1.jpg',57,45000),(76,'Radeon RX 7600 XT','AMD',8,128,'GDDR6','PCIe 4.0',190,'Sapphire',204,'img/8a3abba4-94bd-47fe-9944-26817db332e5.jpg',5,29000),(77,'GeForce RTX 3060','NVIDIA',12,192,'GDDR6','PCIe 4.0',170,'Zotac',225,'img/8211e643-61d6-458d-9f5e-46440e98301a.png',8,35000),(80,'Radeon RX 6600','AMD',8,128,'GDDR6','PCIe 4.0',132,'MSI',235,'img/fdf1800b-179e-40d7-99b1-52ee69544e0f.jpg',3,26000),(82,'GeForce RTX 3050','NVIDIA',8,128,'GDDR6','PCIe 4.0',130,'Palit',215,'img/c19e0748-8c6d-43ab-90fb-ccfe3a1592ec.png',5,27000),(85,'GeForce RTX 5060 Ti 16GB','NVIDIA',16,128,'GDDR7','PCIe 5.0',180,'ASUS',240,'img/412d6e33-8bdd-4329-88e0-a613b4291d63.png',7,90000),(86,'GeForce RTX 5060 Ti 8GB','NVIDIA',8,128,'GDDR7','PCIe 5.0',180,'MSI',238,'img/b46f82d3-611e-4f88-b58a-4986c8fb8ccf.png',5,85000),(87,'GeForce RTX 5070','NVIDIA',12,192,'GDDR7','PCIe 5.0',250,'Gigabyte',280,'img/96f9e68d-3394-40c9-90bc-9ef46b39b326.png',7,120000),(88,'GeForce RTX 5070','NVIDIA',12,192,'GDDR7','PCIe 5.0',250,'Palit',282,'img/6754713f-1d1b-4474-9359-3c2fc2a634bc.png',5,118000),(89,'GeForce RTX 5070 Ti','NVIDIA',16,256,'GDDR7','PCIe 5.0',300,'MSI',310,'img/088e008b-e1c4-4ab8-9aad-937b1194c38e.png',7,150000),(90,'GeForce RTX 5070 Ti','NVIDIA',16,256,'GDDR7','PCIe 5.0',300,'Zotac',312,'img/51f138a0-c006-4274-af8b-6201da9af41a.png',86,148000),(91,'GeForce RTX 5080','NVIDIA',16,256,'GDDR7','PCIe 5.0',360,'Gigabyte',330,'img/f7bcce50-2919-4530-ac6e-ba5e0061a72e.png',5,180000),(92,'GeForce RTX 5080','NVIDIA',16,256,'GDDR7','PCIe 5.0',360,'ASUS',328,'img/12c93530-5568-4ce4-8329-2ff66cedb880.png',8,185000),(93,'GeForce RTX 5090','NVIDIA',32,512,'GDDR7','PCIe 5.0',575,'ASUS',350,'img/02df6ee0-2bec-4a14-bb99-1e58936300f6.png',5,250000),(94,'GeForce RTX 5090','NVIDIA',32,512,'GDDR7','PCIe 5.0',575,'MSI',348,'img/b7e07d60-e5eb-4829-9213-638b65f3cf82.png',7,245000),(95,'Radeon RX 9070 XT','AMD',16,256,'GDDR6','PCIe 4.0',220,'Sapphire',270,'img/f1a10640-8233-405f-985e-635ee6a907f0.jpg',5,85000),(96,'Radeon RX 9070 XT','AMD',16,256,'GDDR6','PCIe 4.0',220,'ASRock',272,'img/c0e64589-1138-4a20-af03-428a952a5d1d.jpg',6,84000),(97,'Radeon RX 9070','AMD',16,256,'GDDR6','PCIe 4.0',190,'Gigabyte',260,'img/d589cd75-4ed2-43a9-92bc-184cccd2db3b.jpg',7,78000),(98,'Radeon RX 9070','AMD',16,256,'GDDR6','PCIe 4.0',190,'PowerColor',262,'img/40ca8ea8-585a-4d0a-907b-39054ff587c5.jpg',6,77000);
/*!40000 ALTER TABLE `videocards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'db95'
--

--
-- Dumping routines for database 'db95'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-06-18  0:36:10
