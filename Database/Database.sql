-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 29-03-2018 a las 00:47:50
-- Versión del servidor: 10.1.28-MariaDB
-- Versión de PHP: 7.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `proyecto`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteCart` (IN `pUsername` VARCHAR(100))  NO SQL
    COMMENT 'Procedure that delete the register of the cart of the client'
BEGIN 
	DELETE FROM cart  
    WHERE getClientID(pUsername) = cart.clientID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteClient` (IN `pUsername` VARCHAR(100))  NO SQL
    COMMENT 'Procedure that delete client'
BEGIN 
	DELETE FROM client  
    WHERE pUsername = client.username;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `deleteOffer` (IN `pProduct` VARCHAR(100))  NO SQL
    COMMENT 'Procedure that delete an offer from the table offer'
BEGIN 
	DELETE FROM offer  
    WHERE getProductID(pProduct) = offer.productID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getCategory` ()  NO SQL
    COMMENT 'Get all the catergory'
BEGIN
SELECT DISTINCT product.category AS Category
FROM product;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getInvoice` (IN `pClientName` VARCHAR(100))  NO SQL
BEGIN
SELECT pClientName AS client, getProductName(purchase.productID) AS product, purchase.amount AS amount, purchase.finalAmount AS finalAmount
FROM purchase
WHERE getClientID(pClientName) = purchase.clientID AND dateOfPurchase >= DATE_SUB(NOW(),INTERVAL 20 MINUTE);
CALL getInvoiceTotal(pClientName);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getInvoiceTotal` (IN `pClientName` VARCHAR(100))  NO SQL
BEGIN
SELECT SUM(purchase.amount) AS amount, SUM(purchase.finalAmount) AS finalAmount, SUM(purchase.amount) - SUM(purchase.finalAmount) AS save
FROM purchase
WHERE getClientID(pClientName) = purchase.clientID AND dateOfPurchase >= DATE_SUB(NOW(), INTERVAL 20 MINUTE)
GROUP BY purchase.clientID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getMessageByClient` (IN `pId` INT)  NO SQL
    COMMENT 'get all the message by client'
BEGIN
SELECT message.clientText AS clientText, message.admiText AS admiText, message.dateOfMessage AS date, message.clientID AS clientID
FROM message
WHERE message.clientID = pId
ORDER BY message.dateOfMessage ASC;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getOffer` ()  NO SQL
    COMMENT 'Get all the offer'
BEGIN
SELECT offer.offerID AS IdOffer, offer.originalPrice AS Original, offer.offerPrice AS OfferPrice, getProductName(offer.productID) AS Name
FROM offer
GROUP BY offer.offerID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getOfferById` (IN `pId` INT)  NO SQL
    COMMENT 'Get the offer by id'
BEGIN
SELECT offer.offerID AS IdOffer, offer.originalPrice AS Original, offer.offerPrice AS OfferPrice, getProductName(offer.productID) AS Name
FROM offer
WHERE offer.offerID = pId
LIMIT 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getProduct` ()  NO SQL
BEGIN
SELECT product.productID AS ID, product.name AS Name, product.price AS Price, product.category AS Category
FROM product
GROUP BY product.productID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getProductByCategory` (IN `pCategory` VARCHAR(100))  NO SQL
    COMMENT 'Get all the product by category'
BEGIN
SELECT product.productID AS ID, product.name AS Name, product.price AS Price, product.category AS Category
FROM product
WHERE product.category = pCategory;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getProductById` (IN `pId` INT)  NO SQL
    COMMENT 'Get the product by id'
BEGIN
SELECT product.productID AS id, product.name AS name, product.price AS price, product.category AS category
FROM product
WHERE product.productID = pId
LIMIT 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getProductName` (IN `pId` INT)  NO SQL
    COMMENT 'Get the product name'
BEGIN
SELECT product.name
FROM product
WHERE product.productID = pId;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getPurchase` ()  NO SQL
BEGIN
SELECT getClientName(purchase.clientID) AS client, SUM(purchase.amount) AS amount, SUM(purchase.finalAmount) AS finalAmount
FROM purchase
GROUP BY purchase.clientID, purchase.dateOfPurchase;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getPurchaseByClient` (IN `pClientName` VARCHAR(100))  NO SQL
BEGIN
SELECT pClientName AS client, getProductName(purchase.productID) AS product, purchase.amount AS amount, purchase.finalAmount AS finalAmount, purchase.dateOfPurchase
FROM purchase
WHERE getClientID(pClientName) = purchase.clientID;
CALL getPurchaseTotal(pClientName);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getPurchaseByName` (IN `pProductName` VARCHAR(100))  NO SQL
BEGIN
SELECT pProductName AS product, getClientName(purchase.clientID) AS client, purchase.amount AS amount, purchase.finalAmount AS finalAmount, purchase.dateOfPurchase
FROM purchase
WHERE getProductID(pProductName) = purchase.productID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getPurchaseTotal` (IN `pClientName` VARCHAR(100))  NO SQL
BEGIN
SELECT SUM(purchase.amount) AS amount, SUM(purchase.finalAmount) AS finalAmount, SUM(purchase.amount) - SUM(purchase.finalAmount) AS save
FROM purchase
WHERE getClientID(pClientName) = purchase.clientID
GROUP BY purchase.clientID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getRate` ()  NO SQL
    COMMENT 'Procedure that get Calification of the products'
BEGIN
	SELECT getProductName(rate.productID), AVG(calification) AS calification
	FROM rate
    GROUP BY rate.productID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertAdmi` (IN `pName` VARCHAR(100), IN `pLastname` VARCHAR(100), IN `pUsername` VARCHAR(100), IN `pPassword` VARCHAR(100), IN `pAddress` VARCHAR(100), IN `pEmail` VARCHAR(100))  NO SQL
    COMMENT 'Procedure that insert into the table admi'
BEGIN 
	INSERT INTO admi(admiID, name, lastname, username, password, address, email)
	VALUES(NULL, pName, pLastname, pUsername, pPassword, pAddress, pEmail);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertAux` (IN `pClientName` VARCHAR(100))  NO SQL
    COMMENT 'Procedure that insert into the table purchase'
BEGIN 
	INSERT INTO purchase(purchaseID, amount, finalAmount, quantity, productID, clientID, dateOfPurchase) 
	SELECT NULL, getPriceByID(cart.productID)*cart.quantity, getOfferPrice(cart.productID)*cart.quantity, cart.quantity, cart.productID, cart.clientID, NULL FROM cart, offer
	WHERE getClientID(pClientName) = cart.clientID AND cart.productID = offer.productID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertCart` (IN `pClientName` VARCHAR(100), IN `pProductName` VARCHAR(100), IN `pQuantity` INT(13) UNSIGNED)  NO SQL
    COMMENT 'Procedure that insert into the table cart'
BEGIN 
	INSERT INTO cart(cartID, quantity, clientID, productID)
	VALUES(NULL, pQuantity, getClientID(pClientName), getProductID(pProductName));
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertClient` (IN `pName` VARCHAR(100), IN `pLastname` VARCHAR(100), IN `pUsername` VARCHAR(100), IN `pPassword` VARCHAR(100), IN `pAddress` VARCHAR(100), IN `pEmail` VARCHAR(100))  NO SQL
    COMMENT 'Procedure that insert into the table client'
BEGIN 
	INSERT INTO client(clientID, name, lastname, username, password, address, email)
	VALUES(NULL, pName, pLastname, pUsername, pPassword, pAddress, pEmail);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertMessage` (IN `pClientText` VARCHAR(100), IN `pClientId` INT)  NO SQL
    COMMENT 'Procedure that insert into the table message'
BEGIN 
	INSERT INTO message(messageID, clientText, admiText, clientID, dateOfMessage) 
	VALUES(NULL, pClientText, "", pClientId, NULL);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertOffer` (IN `pAdmiName` VARCHAR(100), IN `pProductName` VARCHAR(100), IN `pPercentage` INT(13) UNSIGNED)  NO SQL
    COMMENT 'Procedure that insert into the table offer'
BEGIN 
	INSERT INTO offer(offerID, originalPrice, offerPrice, productID, admiID)
	VALUES(NULL, getProductPrice(pProductName), (getProductPrice(pProductName)*pPercentage/100), getProductID(pProductName), getAdmiID(pAdmiName));
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertProduct` (IN `pName` VARCHAR(100), IN `pPrice` INT(13) UNSIGNED, IN `pCategory` VARCHAR(100))  NO SQL
    COMMENT 'Procedure that insert into the table product'
BEGIN 
	INSERT INTO product(productID, name, price, category)
	VALUES(NULL, pName, pPrice, pCategory);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertPurchase` (IN `pClientName` VARCHAR(100))  NO SQL
    COMMENT 'Procedure that insert into the table purchase'
BEGIN 
	INSERT INTO purchase(purchaseID, amount, finalAmount, quantity, productID, clientID, dateOfPurchase)
	SELECT NULL, getPriceByID(cart.productID)*cart.quantity,getPriceByID(cart.productID)*cart.quantity, cart.quantity, cart.productID, cart.clientID, NULL FROM cart, offer
	WHERE getClientID(pClientName) = cart.clientID AND cart.productID != offer.productID;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `insertRate` (IN `pClientName` VARCHAR(100), IN `pProductName` VARCHAR(100), IN `pCalification` INT(13) UNSIGNED)  NO SQL
    COMMENT 'Procedure that insert into the table rate'
BEGIN 
	INSERT INTO rate(rateID, calification, clientID, productID)
	VALUES(NULL, pCalification, getClientID(pClientName), getProductID(pProductName));
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `purchase` (IN `pClientName` VARCHAR(100))  NO SQL
    COMMENT 'Procedure that insert into the table purchase'
BEGIN 
	CALL insertAux(pClientName);
	CALL insertPurchase(pClientName);
	CALL deleteCart(pClientName);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `searchProduct` (IN `pName` VARCHAR(100))  NO SQL
BEGIN
SELECT product.productID AS ID, product.name AS Name, product.price AS Price, product.category AS Category
FROM product
WHERE product.name LIKE pName;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateMessage` (IN `pAdmiText` VARCHAR(100), IN `pClientText` VARCHAR(100))  NO SQL
    COMMENT 'Procedure that update the message table'
BEGIN 
	UPDATE message  
    SET message.admiText = pAdmiText
    WHERE message.messageID = getMessageID(pClientText);
END$$

--
-- Funciones
--
CREATE DEFINER=`root`@`localhost` FUNCTION `getAdmiID` (`pAdmiName` VARCHAR(100)) RETURNS INT(11) BEGIN
	DECLARE vAdmiID INT(11) DEFAULT 0;
  	SELECT admiID INTO vAdmiID FROM admi WHERE admi.username = pAdmiName;
  	RETURN vAdmiID;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `getAdmiName` (`pAdmiID` INT(11)) RETURNS VARCHAR(100) CHARSET latin1 BEGIN
	DECLARE vName VARCHAR(100) DEFAULT "";
  	SELECT username INTO vName FROM admi WHERE admi.admiID = pAdmiID;
  	RETURN vName;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `getClientID` (`pClientName` VARCHAR(100)) RETURNS INT(11) BEGIN
  DECLARE vClientID INT(11) DEFAULT 0;
    SELECT clientID INTO vClientID FROM client WHERE client.username = pClientName;
    RETURN vClientID;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `getClientName` (`pClientID` INT(11)) RETURNS VARCHAR(100) CHARSET latin1 BEGIN
  DECLARE vName VARCHAR(100) DEFAULT "";
    SELECT username INTO vName FROM client WHERE client.clientID = pClientID;
    RETURN vName;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `getMessageID` (`pMessageText` VARCHAR(500)) RETURNS INT(11) BEGIN
  DECLARE vMessageID INT(11) DEFAULT 0;
    SELECT messageID INTO vMessageID FROM message WHERE message.clientText = pMessageText;
    RETURN vMessageID;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `getOfferPrice` (`pProductID` INT(11)) RETURNS INT(11) BEGIN
  DECLARE vPrice INT(11) DEFAULT 0;
    SELECT offerPrice INTO vPrice FROM offer WHERE offer.productID = pProductID;
    RETURN vPrice;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `getPriceByID` (`pProductID` INT(11)) RETURNS INT(11) BEGIN
  DECLARE vPrice INT(11) DEFAULT 0;
    SELECT price INTO vPrice FROM product WHERE product.productID = pProductID;
    RETURN vPrice;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `getProductID` (`pProductName` VARCHAR(100)) RETURNS INT(11) BEGIN
  DECLARE vProductID INT(11) DEFAULT 0;
    SELECT productID INTO vProductID FROM product WHERE product.name = pProductName;
    RETURN vProductID;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `getProductName` (`pProductID` INT(11)) RETURNS VARCHAR(100) CHARSET latin1 BEGIN
  DECLARE vName VARCHAR(100) DEFAULT "";
    SELECT name INTO vName FROM product WHERE product.productID = pProductID;
    RETURN vName;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `getProductPrice` (`pProductName` VARCHAR(100)) RETURNS INT(11) BEGIN
  DECLARE vProductPrice INT(11) DEFAULT 0;
    SELECT price INTO vProductPrice FROM product WHERE product.name = pProductName;
    RETURN vProductPrice;
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `isAdmi` (`pUsername` VARCHAR(100), `pPassword` VARCHAR(100)) RETURNS TINYINT(1) NO SQL
BEGIN
RETURN EXISTS(SELECT admi.name FROM admi WHERE admi.username = pUsername AND admi.password = pPassword);
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `isClient` (`pUsername` VARCHAR(100), `pPassword` VARCHAR(100)) RETURNS TINYINT(1) NO SQL
BEGIN
RETURN EXISTS(SELECT client.name FROM client WHERE client.username = pUsername AND client.password = pPassword);
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `validateAdmiName` (`pUsername` VARCHAR(100)) RETURNS TINYINT(1) NO SQL
BEGIN
RETURN EXISTS(SELECT admi.username FROM admi WHERE admi.username = pUsername);
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `validateCalification` (`pClient` VARCHAR(100), `pProduct` VARCHAR(100)) RETURNS TINYINT(1) NO SQL
BEGIN
RETURN EXISTS(SELECT rate.clientID, rate.productID FROM rate WHERE rate.clientID = getClientID(pClient) and rate.productID = getProductID(pProduct));
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `validateClientName` (`pUsername` VARCHAR(100)) RETURNS TINYINT(1) NO SQL
BEGIN
RETURN NOT EXISTS(SELECT client.username FROM client WHERE client.username = pUsername);
END$$

CREATE DEFINER=`root`@`localhost` FUNCTION `validateOffer` (`pProduct` VARCHAR(100)) RETURNS TINYINT(1) NO SQL
BEGIN
RETURN EXISTS(SELECT offer.productID FROM offer WHERE offer.productID = getProductID(pProduct));
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `admi`
--

CREATE TABLE `admi` (
  `admiID` int(11) NOT NULL COMMENT 'identificator admi',
  `name` varchar(100) NOT NULL COMMENT 'admi name',
  `lastname` varchar(100) NOT NULL COMMENT 'admi lastname',
  `username` varchar(100) NOT NULL COMMENT 'username of the admi',
  `password` varchar(100) NOT NULL COMMENT 'admi password',
  `address` varchar(100) NOT NULL COMMENT 'admi address',
  `email` varchar(100) NOT NULL COMMENT 'admi email'
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Information of the admi';

--
-- Volcado de datos para la tabla `admi`
--

INSERT INTO `admi` (`admiID`, `name`, `lastname`, `username`, `password`, `address`, `email`) VALUES
(1, 'Esteban', 'Coto', 'ecoto', '12345678', 'San Jose', 'ecoto@gmail.com'),
(2, 'Jose', 'Moya', 'jmoya', '123456', 'San Jose', 'jmoya@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cart`
--

CREATE TABLE `cart` (
  `cartID` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `clientID` int(11) NOT NULL,
  `productID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `client`
--

CREATE TABLE `client` (
  `clientID` int(11) NOT NULL COMMENT 'identificator for the client',
  `name` varchar(100) NOT NULL COMMENT 'client name',
  `lastname` varchar(100) NOT NULL COMMENT 'client lastname',
  `username` varchar(100) NOT NULL COMMENT 'username of the client',
  `password` varchar(100) NOT NULL COMMENT 'password of the client',
  `address` varchar(100) NOT NULL COMMENT 'address of the client',
  `email` varchar(100) NOT NULL COMMENT 'email of the client'
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Information of the client';

--
-- Volcado de datos para la tabla `client`
--

INSERT INTO `client` (`clientID`, `name`, `lastname`, `username`, `password`, `address`, `email`) VALUES
(1, 'Juan', 'Perez', 'jPerez', '54321', 'Cartago', 'jperez@gmail.com'),
(2, 'Ana', 'Blanco', 'aBlanco', '12345', 'Alajuela', 'ablanco@gmail.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `message`
--

CREATE TABLE `message` (
  `messageID` int(11) NOT NULL,
  `clientText` varchar(500) NOT NULL,
  `admiText` varchar(500) DEFAULT NULL,
  `clientID` int(11) NOT NULL,
  `dateOfMessage` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `message`
--

INSERT INTO `message` (`messageID`, `clientText`, `admiText`, `clientID`, `dateOfMessage`) VALUES
(1, 'Does Coca-Cola is 3L?', 'Yes, it is', 2, '2018-03-20 16:22:36'),
(3, 'How much does it cost the bottle of alcohol?', '500', 2, '2018-03-28 15:19:37'),
(4, 'Hola', '\"\"', 2, '2018-03-28 16:08:39'),
(5, 'Adios', '\"\"', 2, '2018-03-28 16:21:06'),
(6, 'Hola Coto', '', 2, '2018-03-28 16:22:39'),
(7, 'Usted es administrador?', '', 2, '2018-03-28 16:25:26');

--
-- Disparadores `message`
--
DELIMITER $$
CREATE TRIGGER `beforeInsertMessage` BEFORE INSERT ON `message` FOR EACH ROW BEGIN
	SET NEW.dateOfMessage = NOW();
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `offer`
--

CREATE TABLE `offer` (
  `offerID` int(11) NOT NULL,
  `originalPrice` int(11) NOT NULL,
  `offerPrice` int(11) NOT NULL,
  `productID` int(11) NOT NULL,
  `admiID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `offer`
--

INSERT INTO `offer` (`offerID`, `originalPrice`, `offerPrice`, `productID`, `admiID`) VALUES
(1, 2500, 1250, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `product`
--

CREATE TABLE `product` (
  `productID` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `price` int(11) NOT NULL,
  `category` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `product`
--

INSERT INTO `product` (`productID`, `name`, `price`, `category`) VALUES
(1, 'Heinz', 2500, 'Food'),
(2, 'Coca-Cola', 1250, 'Beverage'),
(3, 'Butter', 550, 'Frozen');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `purchase`
--

CREATE TABLE `purchase` (
  `purchaseID` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `finalAmount` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `productID` int(11) NOT NULL,
  `clientID` int(11) NOT NULL,
  `dateOfPurchase` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `purchase`
--

INSERT INTO `purchase` (`purchaseID`, `amount`, `finalAmount`, `quantity`, `productID`, `clientID`, `dateOfPurchase`) VALUES
(8, 2500, 2500, 2, 2, 2, '2018-03-20 16:09:53'),
(9, 1650, 1650, 3, 3, 2, '2018-03-20 16:09:53'),
(10, 3750, 3750, 3, 2, 2, '2018-03-22 10:06:15'),
(11, 1100, 1100, 2, 3, 2, '2018-03-22 10:06:15'),
(12, 7500, 3750, 3, 1, 1, '2018-03-22 11:38:49'),
(14, 2500, 2500, 2, 2, 1, '2018-03-22 11:45:42'),
(15, 7500, 3750, 3, 1, 2, '2018-03-22 11:48:52'),
(16, 1100, 1100, 2, 3, 2, '2018-03-22 11:48:52');

--
-- Disparadores `purchase`
--
DELIMITER $$
CREATE TRIGGER `beforeInsertPurchase` BEFORE INSERT ON `purchase` FOR EACH ROW BEGIN
	SET NEW.dateOfPurchase = NOW();
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rate`
--

CREATE TABLE `rate` (
  `rateID` int(11) NOT NULL,
  `calification` int(11) NOT NULL,
  `clientID` int(11) NOT NULL,
  `productID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `rate`
--

INSERT INTO `rate` (`rateID`, `calification`, `clientID`, `productID`) VALUES
(1, 10, 1, 1),
(2, 9, 2, 1),
(3, 8, 2, 2);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `admi`
--
ALTER TABLE `admi`
  ADD PRIMARY KEY (`admiID`);

--
-- Indices de la tabla `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`cartID`),
  ADD KEY `clientID` (`clientID`),
  ADD KEY `productID` (`productID`);

--
-- Indices de la tabla `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`clientID`);

--
-- Indices de la tabla `message`
--
ALTER TABLE `message`
  ADD PRIMARY KEY (`messageID`),
  ADD KEY `clientID` (`clientID`);

--
-- Indices de la tabla `offer`
--
ALTER TABLE `offer`
  ADD PRIMARY KEY (`offerID`),
  ADD KEY `admiID` (`admiID`),
  ADD KEY `productID` (`productID`);

--
-- Indices de la tabla `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`productID`);

--
-- Indices de la tabla `purchase`
--
ALTER TABLE `purchase`
  ADD PRIMARY KEY (`purchaseID`),
  ADD KEY `productID` (`productID`),
  ADD KEY `clientID` (`clientID`);

--
-- Indices de la tabla `rate`
--
ALTER TABLE `rate`
  ADD PRIMARY KEY (`rateID`),
  ADD KEY `clientID` (`clientID`),
  ADD KEY `productID` (`productID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `admi`
--
ALTER TABLE `admi`
  MODIFY `admiID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificator admi', AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `cart`
--
ALTER TABLE `cart`
  MODIFY `cartID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `client`
--
ALTER TABLE `client`
  MODIFY `clientID` int(11) NOT NULL AUTO_INCREMENT COMMENT 'identificator for the client', AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `message`
--
ALTER TABLE `message`
  MODIFY `messageID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `offer`
--
ALTER TABLE `offer`
  MODIFY `offerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `product`
--
ALTER TABLE `product`
  MODIFY `productID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `purchase`
--
ALTER TABLE `purchase`
  MODIFY `purchaseID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT de la tabla `rate`
--
ALTER TABLE `rate`
  MODIFY `rateID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cart`
--
ALTER TABLE `cart`
  ADD CONSTRAINT `cart_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`),
  ADD CONSTRAINT `cart_ibfk_2` FOREIGN KEY (`productID`) REFERENCES `product` (`productID`);

--
-- Filtros para la tabla `message`
--
ALTER TABLE `message`
  ADD CONSTRAINT `message_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`);

--
-- Filtros para la tabla `offer`
--
ALTER TABLE `offer`
  ADD CONSTRAINT `offer_ibfk_1` FOREIGN KEY (`admiID`) REFERENCES `admi` (`admiID`),
  ADD CONSTRAINT `offer_ibfk_2` FOREIGN KEY (`productID`) REFERENCES `product` (`productID`);

--
-- Filtros para la tabla `purchase`
--
ALTER TABLE `purchase`
  ADD CONSTRAINT `purchase_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`),
  ADD CONSTRAINT `purchase_ibfk_2` FOREIGN KEY (`productID`) REFERENCES `product` (`productID`);

--
-- Filtros para la tabla `rate`
--
ALTER TABLE `rate`
  ADD CONSTRAINT `rate_ibfk_1` FOREIGN KEY (`clientID`) REFERENCES `client` (`clientID`),
  ADD CONSTRAINT `rate_ibfk_2` FOREIGN KEY (`productID`) REFERENCES `product` (`productID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
