-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mer. 04 mai 2022 à 16:11
-- Version du serveur : 5.7.36
-- Version de PHP : 7.4.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `prinvedreservationhotel`
--

-- --------------------------------------------------------

--
-- Structure de la table `categories`
--

DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `NUMEROCATEGORIE` int(11) NOT NULL,
  `NUMEROCHAMBRE` varchar(10) NOT NULL,
  `NOMCATEGORIE` varchar(50) DEFAULT NULL,
  `PRIX` int(11) DEFAULT NULL,
  `DESCRIPTION` longtext,
  PRIMARY KEY (`NUMEROCATEGORIE`),
  KEY `FK_APPARTENIR` (`NUMEROCHAMBRE`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `categories`
--

INSERT INTO `categories` (`NUMEROCATEGORIE`, `NUMEROCHAMBRE`, `NOMCATEGORIE`, `PRIX`, `DESCRIPTION`) VALUES
(1, 'B12', 'vip5', 55000, '3 chambre 1 salon');

-- --------------------------------------------------------

--
-- Structure de la table `chambre`
--

DROP TABLE IF EXISTS `chambre`;
CREATE TABLE IF NOT EXISTS `chambre` (
  `NUMEROCHAMBRE` varchar(10) NOT NULL,
  `NUMERORESERV` int(11) NOT NULL,
  `TELEPHONECHAMBRE` int(11) DEFAULT NULL,
  `NIVEAU` int(11) DEFAULT NULL,
  `STATUT` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`NUMEROCHAMBRE`),
  KEY `FK_CONCERNER` (`NUMERORESERV`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `chambre`
--

INSERT INTO `chambre` (`NUMEROCHAMBRE`, `NUMERORESERV`, `TELEPHONECHAMBRE`, `NIVEAU`, `STATUT`) VALUES
('B12', 1, 112345, 2, 'Libre');

-- --------------------------------------------------------

--
-- Structure de la table `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `CNI` int(11) NOT NULL,
  `NUMERORESERVATION` int(11) NOT NULL,
  `NOMCLIENT` varchar(50) DEFAULT NULL,
  `PRENOMCLIENT` varchar(50) DEFAULT NULL,
  `GENRE` varchar(10) DEFAULT NULL,
  `TELEPHONECLIENT` varchar(13) DEFAULT NULL,
  `EMAIL` varchar(50) DEFAULT NULL,
  `STATUTCLIENT` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`CNI`),
  KEY `FK_EFFECTUER` (`NUMERORESERVATION`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `clients`
--

INSERT INTO `clients` (`CNI`, `NUMERORESERVATION`, `NOMCLIENT`, `PRENOMCLIENT`, `GENRE`, `TELEPHONECLIENT`, `EMAIL`, `STATUTCLIENT`) VALUES
(98765432, 1, 'iya', 'daniel', 'Homme', '650505050', 'iyadaniel@gmail.com', 'Actif');

-- --------------------------------------------------------

--
-- Structure de la table `reservation`
--

DROP TABLE IF EXISTS `reservation`;
CREATE TABLE IF NOT EXISTS `reservation` (
  `NUMEROR` int(11) NOT NULL,
  `DATEDEBUT` date NOT NULL,
  `DATEFIN` date NOT NULL,
  PRIMARY KEY (`NUMEROR`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `reservation`
--

INSERT INTO `reservation` (`NUMEROR`, `DATEDEBUT`, `DATEFIN`) VALUES
(1, '2022-04-06', '2022-04-29');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
