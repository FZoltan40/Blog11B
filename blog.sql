-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Feb 14. 13:28
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 7.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `blog`
--
CREATE DATABASE IF NOT EXISTS `blog` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `blog`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `blogtable`
--

CREATE TABLE `blogtable` (
  `Id` int(11) NOT NULL,
  `Title` varchar(30) DEFAULT NULL,
  `Post` longtext DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `blogtable`
--

INSERT INTO `blogtable` (`Id`, `Title`, `Post`, `UserId`) VALUES
(1, 'Bejegyzés1', 'Ez az első bejegyzés', 3),
(2, 'Bejegyzés1', 'Ez az első bejegyzés', 1),
(3, 'Bejegyzés1', 'Ez az első bejegyzés', 2),
(4, 'Bejegyzés2', 'Ez a második bejegyzés', 3),
(5, 'Bejegyzés3', 'Ez a haramdik bejegyzés', 3);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `usertable`
--

CREATE TABLE `usertable` (
  `Id` int(11) NOT NULL,
  `UserName` varchar(20) DEFAULT NULL,
  `Email` varchar(30) DEFAULT NULL,
  `Password` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `usertable`
--

INSERT INTO `usertable` (`Id`, `UserName`, `Email`, `Password`) VALUES
(1, 'peti01', 'peti01@gmail.com', 'Alma'),
(2, 'kata01', 'kata01@gmail.com', 'Alma'),
(3, 'ilona11', 'ilona111@gmail.com', 'Alma');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `blogtable`
--
ALTER TABLE `blogtable`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `UserId` (`UserId`);

--
-- A tábla indexei `usertable`
--
ALTER TABLE `usertable`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserName` (`UserName`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `blogtable`
--
ALTER TABLE `blogtable`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT a táblához `usertable`
--
ALTER TABLE `usertable`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `blogtable`
--
ALTER TABLE `blogtable`
  ADD CONSTRAINT `blogtable_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `usertable` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
