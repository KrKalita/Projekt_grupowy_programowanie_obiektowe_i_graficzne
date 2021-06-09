-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 09 Cze 2021, 22:06
-- Wersja serwera: 10.4.18-MariaDB
-- Wersja PHP: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `firma_architektoniczna`
--
CREATE DATABASE IF NOT EXISTS `firma_architektoniczna` DEFAULT CHARACTER SET utf8 COLLATE utf8_polish_ci;
USE `firma_architektoniczna`;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `architekci`
--

CREATE TABLE `architekci` (
  `pesel` char(11) COLLATE utf8_polish_ci NOT NULL,
  `imię` char(30) COLLATE utf8_polish_ci NOT NULL,
  `nazwisko` char(30) COLLATE utf8_polish_ci NOT NULL,
  `numer` char(9) COLLATE utf8_polish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `architekci`
--

INSERT INTO `architekci` (`pesel`, `imię`, `nazwisko`, `numer`) VALUES
('00282905147', 'Marta', 'Kirsch', '123123123'),
('45612367890', 'Jan', 'Kowalski', '555000888');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `klienci`
--

CREATE TABLE `klienci` (
  `nazwa_klienta` char(255) COLLATE utf8_polish_ci NOT NULL,
  `ilość_pracowników` int(11),
  `wartość_na_rynku` double
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `klienci`
--

INSERT INTO `klienci` (`nazwa_klienta`, `ilość_pracowników`, `wartość_na_rynku`) VALUES
('Firma ABC', 567, 13500),
('Zakład IJK', 890, 20103);
INSERT INTO `klienci` (`nazwa_klienta`) VALUES
('t');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `projekty`
--

CREATE TABLE `projekty` (
  `nazwa_projektu` char(255) COLLATE utf8_polish_ci NOT NULL,
  `cena` double NOT NULL,
  `czas_wykonania` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `projekty`
--

INSERT INTO `projekty` (`nazwa_projektu`, `cena`, `czas_wykonania`) VALUES
('Dom dwupiętrowy Alfred', 4500, 21),
('Garaż podziemny jednostanowiskowy', 4201.45, 14);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `umowy`
--

CREATE TABLE `umowy` (
  `nazwa_projektu` char(255) COLLATE utf8_polish_ci NOT NULL,
  `nazwa_klienta` char(255) COLLATE utf8_polish_ci NOT NULL,
  `pesel` char(11) COLLATE utf8_polish_ci NOT NULL,
  `nazwa_umowy` char(255) COLLATE utf8_polish_ci NOT NULL,
  `data_zawarcia` date NOT NULL,
  `termin_ostateczny_do_zrealizowania_projektu` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `umowy`
--

INSERT INTO `umowy` (`nazwa_projektu`, `nazwa_klienta`, `pesel`, `nazwa_umowy`, `data_zawarcia`, `termin_ostateczny_do_zrealizowania_projektu`) VALUES
('Dom dwupiętrowy Alfred', 'Firma ABC', '00282905147', 'Nowy dom', '2021-06-09', '2021-07-09');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `architekci`
--
ALTER TABLE `architekci`
  ADD PRIMARY KEY (`pesel`);

--
-- Indeksy dla tabeli `klienci`
--
ALTER TABLE `klienci`
  ADD PRIMARY KEY (`nazwa_klienta`);

--
-- Indeksy dla tabeli `projekty`
--
ALTER TABLE `projekty`
  ADD PRIMARY KEY (`nazwa_projektu`);

--
-- Indeksy dla tabeli `umowy`
--
ALTER TABLE `umowy`
  ADD KEY `architekt` (`pesel`),
  ADD KEY `nazwaKlienta` (`nazwa_klienta`),
  ADD KEY `nazwaProjektu` (`nazwa_projektu`);

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `umowy`
--
ALTER TABLE `umowy`
  ADD CONSTRAINT `umowy_ibfk_1` FOREIGN KEY (`pesel`) REFERENCES `architekci` (`pesel`),
  ADD CONSTRAINT `umowy_ibfk_2` FOREIGN KEY (`nazwa_klienta`) REFERENCES `klienci` (`nazwa_klienta`),
  ADD CONSTRAINT `umowy_ibfk_3` FOREIGN KEY (`nazwa_projektu`) REFERENCES `projekty` (`nazwa_projektu`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
