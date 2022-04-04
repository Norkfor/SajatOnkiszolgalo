-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2022. Már 24. 13:51
-- Kiszolgáló verziója: 10.4.21-MariaDB
-- PHP verzió: 8.0.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `termekek`
--
CREATE DATABASE IF NOT EXISTS `termekek` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `termekek`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `arucikkek`
--

CREATE TABLE `arucikkek` (
  `aruid` int(11) NOT NULL,
  `vonalkod_szam` bigint(64) NOT NULL,
  `nev` varchar(255) COLLATE utf8_hungarian_ci NOT NULL,
  `mennyiseg` double(11,2) NOT NULL,
  `mertekegyseg_id` int(11) NOT NULL,
  `ara` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `arucikkek`
--

INSERT INTO `arucikkek` (`aruid`, `vonalkod_szam`, `nev`, `mennyiseg`, `mertekegyseg_id`, `ara`) VALUES
(1, 5999086424907, 'Auchan A5 füz', 1.00, 3, 109),
(2, 4388860409604, 'PENNY REA CAF LAT ESP', 400.00, 1, 299),
(3, 5999885746217, 'HELL Nord Turq', 250.00, 1, 199),
(4, 5999860497554, 'XIXO Ice Tea Mál-Áfo', 1.50, 4, 239),
(5, 4388860407891, 'PENNY REA CAF LAT MAC', 250.00, 1, 299),
(6, 5999860497080, 'HELL CFE Slim Lat', 250.00, 1, 319),
(7, 5997001771532, 'Bradolin Alk fel.fert szer', 1.00, 4, 2994),
(8, 9100000443652, 'SPAR Mult Yel DRK', 1.50, 4, 189),
(10, 9008700121965, 'RAUCH bra GRE APL', 500.00, 1, 369),
(11, 4388860409703, 'PENNY REA CAF LAT CAP', 250.00, 1, 319),
(12, 5900497600330, 'Liptom Lemon', 330.00, 1, 499),
(13, 5999884034650, 'HELL CLASSIC', 250.00, 1, 199),
(14, 5900497310338, 'PEPSI dob', 330.00, 1, 299),
(15, 5997642113753, 'WATT ENER DRK Alm-Kör', 250.00, 1, 199),
(16, 5997642113906, 'WATT ENER DRK Feh-Gua', 250.00, 1, 199),
(17, 5998821511292, 'OLYMPOS SÁRGR-NAR', 1.50, 4, 319),
(18, 7622300570293, 'TUC BACON', 100.00, 6, 189);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `aru_mertekegyseg`
--

CREATE TABLE `aru_mertekegyseg` (
  `id` int(11) NOT NULL,
  `mertekegyseg` varchar(255) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `aru_mertekegyseg`
--

INSERT INTO `aru_mertekegyseg` (`id`, `mertekegyseg`) VALUES
(1, 'ml'),
(2, 'kg'),
(3, 'db'),
(4, 'L'),
(5, 'dl'),
(6, 'g');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `arucikkek`
--
ALTER TABLE `arucikkek`
  ADD PRIMARY KEY (`aruid`),
  ADD KEY `mertekegyseg_id` (`mertekegyseg_id`);

--
-- A tábla indexei `aru_mertekegyseg`
--
ALTER TABLE `aru_mertekegyseg`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `arucikkek`
--
ALTER TABLE `arucikkek`
  MODIFY `aruid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT a táblához `aru_mertekegyseg`
--
ALTER TABLE `aru_mertekegyseg`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `arucikkek`
--
ALTER TABLE `arucikkek`
  ADD CONSTRAINT `arucikkek_ibfk_1` FOREIGN KEY (`mertekegyseg_id`) REFERENCES `aru_mertekegyseg` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
