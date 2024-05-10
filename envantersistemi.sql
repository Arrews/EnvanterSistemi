-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 21, 2024 at 02:58 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `envantersistemi`
--

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `customer_phone` varchar(11) NOT NULL,
  `customer_name` varchar(255) DEFAULT NULL,
  `customer_score` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`customer_phone`, `customer_name`, `customer_score`) VALUES
('05309770710', 'Kadir Şahin', 19),
('05309770711', 'Ufuk Aydın', 7);

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE `inventory` (
  `inventory_id` int(11) NOT NULL,
  `inventory_product` int(11) DEFAULT NULL,
  `inventory_amount` int(11) DEFAULT NULL,
  `inventory_store` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`inventory_id`, `inventory_product`, `inventory_amount`, `inventory_store`) VALUES
(190001, 1, 24, 19),
(190002, 2, 5, 19),
(190003, 3, 3, 19),
(190004, 4, 8, 19),
(190005, 5, 45, 19),
(190006, 6, 48, 19),
(190007, 7, 23, 19),
(190008, 8, 78, 19),
(190009, 9, 9, 19),
(230001, 1, 0, 23),
(230002, 2, 0, 23);

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `login_id` int(11) NOT NULL,
  `login_pw` int(11) DEFAULT NULL,
  `login_personel_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`login_id`, `login_pw`, `login_personel_id`) VALUES
(1055, 1764, 1055);

-- --------------------------------------------------------

--
-- Table structure for table `personel`
--

CREATE TABLE `personel` (
  `personel_id` int(11) NOT NULL,
  `personel_name` varchar(255) DEFAULT NULL,
  `personel_contact` varchar(255) DEFAULT NULL,
  `personel_store` int(11) DEFAULT NULL,
  `personel_job` varchar(255) DEFAULT NULL,
  `personel_prim_goal` double DEFAULT NULL,
  `personel_prim_current` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `personel`
--

INSERT INTO `personel` (`personel_id`, `personel_name`, `personel_contact`, `personel_store`, `personel_job`, `personel_prim_goal`, `personel_prim_current`) VALUES
(1055, 'Kadir Şahin', 'kadir@gmail.com', 19, 'Sales', 700, 266.27),
(1111, 'Ufuk Aydın', 'ufuk@aydın.com', 23, 'Sales Assistant', 500, 150.491);

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `product_id` int(11) NOT NULL,
  `product_name` varchar(255) DEFAULT NULL,
  `product_type` varchar(255) DEFAULT NULL,
  `product_size` varchar(255) DEFAULT NULL,
  `product_variant` varchar(255) DEFAULT NULL,
  `product_price` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_name`, `product_type`, `product_size`, `product_variant`, `product_price`) VALUES
(1, 'T-Shirt', 'T-Shirt', 'Large', 'Blue', 29),
(2, 'Jean', 'Pant', '32', 'Dark Blue', 72.99),
(3, 'Cargo Short', 'Short', 'Small', 'Green', 20),
(4, 'Sweatshirt', 'Sweat', 'XL', 'Grey', 10),
(5, 'Winter Gloves', 'Glove', 'Standard', 'black', 5),
(6, 'Polo', 'T-Shirt', 'Medium', 'Red', 65),
(7, 'V-Yaka', 'T-Shirt', 'XS', 'White', 8),
(8, 'Shirt', 'Shirt', 'Small', 'Blue', 99),
(9, 'Kashmir Shirt', 'Shirt', 'Medium', 'Black', 19),
(32, 'Baseball Cap', 'Hat', 'Standard', 'Red White', 10);

-- --------------------------------------------------------

--
-- Table structure for table `receipt`
--

CREATE TABLE `receipt` (
  `receipt_id` int(11) NOT NULL,
  `receipt_price` double DEFAULT NULL,
  `receipt_customer` varchar(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `receipt`
--

INSERT INTO `receipt` (`receipt_id`, `receipt_price`, `receipt_customer`) VALUES
(1, 136, '05309770711'),
(2, 100, '05309770710'),
(3, 198, '05309770710'),
(4, 39, '05309770710');

-- --------------------------------------------------------

--
-- Table structure for table `sale`
--

CREATE TABLE `sale` (
  `sale_id` int(11) NOT NULL,
  `sale_personel` int(11) DEFAULT NULL,
  `sale_price` double DEFAULT NULL,
  `sale_product` int(11) DEFAULT NULL,
  `sale_amount` int(11) DEFAULT NULL,
  `sale_receipt` int(11) DEFAULT NULL,
  `sale_store` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `store`
--

CREATE TABLE `store` (
  `store_id` int(11) NOT NULL,
  `store_name` varchar(255) DEFAULT NULL,
  `store_prim_goal` double DEFAULT NULL,
  `store_prim_current` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `store`
--

INSERT INTO `store` (`store_id`, `store_name`, `store_prim_goal`, `store_prim_current`) VALUES
(19, 'Ege Myo', 1000, 473),
(23, 'Bergama MYO', 1300, 688.8909999999998),
(38, 'Aliaga MYO', 700, 50);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`customer_phone`);

--
-- Indexes for table `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`inventory_id`),
  ADD KEY `inventory_product` (`inventory_product`),
  ADD KEY `inventory_store` (`inventory_store`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`login_id`),
  ADD KEY `login_personel_id` (`login_personel_id`);

--
-- Indexes for table `personel`
--
ALTER TABLE `personel`
  ADD PRIMARY KEY (`personel_id`),
  ADD KEY `personel_store` (`personel_store`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`);

--
-- Indexes for table `receipt`
--
ALTER TABLE `receipt`
  ADD PRIMARY KEY (`receipt_id`),
  ADD KEY `fk_receipt_customer` (`receipt_customer`);

--
-- Indexes for table `sale`
--
ALTER TABLE `sale`
  ADD PRIMARY KEY (`sale_id`),
  ADD KEY `sale_personel` (`sale_personel`),
  ADD KEY `sale_product` (`sale_product`),
  ADD KEY `sale_store` (`sale_store`),
  ADD KEY `fk_sale_receipt` (`sale_receipt`);

--
-- Indexes for table `store`
--
ALTER TABLE `store`
  ADD PRIMARY KEY (`store_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `receipt`
--
ALTER TABLE `receipt`
  MODIFY `receipt_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `inventory`
--
ALTER TABLE `inventory`
  ADD CONSTRAINT `inventory_ibfk_1` FOREIGN KEY (`inventory_product`) REFERENCES `products` (`product_id`),
  ADD CONSTRAINT `inventory_ibfk_2` FOREIGN KEY (`inventory_store`) REFERENCES `store` (`store_id`);

--
-- Constraints for table `login`
--
ALTER TABLE `login`
  ADD CONSTRAINT `login_ibfk_1` FOREIGN KEY (`login_personel_id`) REFERENCES `personel` (`personel_id`);

--
-- Constraints for table `personel`
--
ALTER TABLE `personel`
  ADD CONSTRAINT `personel_ibfk_1` FOREIGN KEY (`personel_store`) REFERENCES `store` (`store_id`);

--
-- Constraints for table `receipt`
--
ALTER TABLE `receipt`
  ADD CONSTRAINT `fk_receipt_customer` FOREIGN KEY (`receipt_customer`) REFERENCES `customers` (`customer_phone`) ON DELETE CASCADE;

--
-- Constraints for table `sale`
--
ALTER TABLE `sale`
  ADD CONSTRAINT `fk_sale_receipt` FOREIGN KEY (`sale_receipt`) REFERENCES `receipt` (`receipt_id`) ON DELETE CASCADE,
  ADD CONSTRAINT `sale_ibfk_1` FOREIGN KEY (`sale_personel`) REFERENCES `personel` (`personel_id`),
  ADD CONSTRAINT `sale_ibfk_2` FOREIGN KEY (`sale_product`) REFERENCES `products` (`product_id`),
  ADD CONSTRAINT `sale_ibfk_4` FOREIGN KEY (`sale_store`) REFERENCES `store` (`store_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
