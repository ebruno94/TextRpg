-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Mar 07, 2018 at 01:25 AM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `text_rpg`
--
CREATE DATABASE IF NOT EXISTS `text_rpg` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `text_rpg`;

-- --------------------------------------------------------

--
-- Table structure for table `characters`
--

CREATE TABLE `characters` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `level` int(11) NOT NULL,
  `experience` int(11) NOT NULL,
  `max_hp` int(11) NOT NULL,
  `hp` int(11) NOT NULL,
  `armor` int(11) NOT NULL,
  `ad` int(11) NOT NULL,
  `iq` int(11) NOT NULL,
  `dexterity` int(11) NOT NULL,
  `luck` int(11) NOT NULL,
  `charisma` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `room_number` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `inventories`
--

CREATE TABLE `inventories` (
  `id` int(11) NOT NULL,
  `character_id` int(11) NOT NULL,
  `item_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `items`
--

CREATE TABLE `items` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `img_url` varchar(255) NOT NULL,
  `hp` int(11) NOT NULL,
  `armor` int(11) NOT NULL,
  `ad` int(11) NOT NULL,
  `iq` int(11) NOT NULL,
  `luck` int(11) NOT NULL,
  `charisma` int(11) NOT NULL,
  `dexterity` int(11) NOT NULL,
  `equippable` int(11) NOT NULL,
  `action` varchar(255) NOT NULL,
  `audio_source` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Dumping data for table `items`
--

INSERT INTO `items` (`id`, `name`, `img_url`, `hp`, `armor`, `ad`, `iq`, `luck`, `charisma`, `dexterity`, `equippable`, `action`, `audio_source`) VALUES
(2, 'Med-Kit', 'img/Consumables/medkit.png', 1, 1, 1, 1, 1, 1, 1, -1, 'none', 'audio/Items/Consumables/medkit.wav'),
(3, 'Adrenaline Shot', 'img/Consumables/adrenaline.png', 1, 1, 1, 1, 1, 1, 1, -1, 'none', 'audio/Items/Consumables/adrenaline-shot.wav'),
(4, 'Alien Pistol', 'img/Weapons/alien-pistol.png', 1, 1, 1, 1, 1, 1, 1, 5, 'none', 'audio/Items/Weapons/a-pistol.wav'),
(5, 'Alien Rifle', 'img/Weapons/alien-rifle.png', 1, 1, 1, 1, 1, 1, 1, 5, 'none', 'img/Items/Weapons/alien-rifle.png'),
(6, 'Alien Sword', 'img/Weapons/alien-sword.png', 1, 1, 1, 1, 1, 1, 1, 5, 'none', 'audio/Items/Weapons/a-sword.wav'),
(7, 'Machine Gun', 'img/Weapons/human-mg.png', 1, 1, 1, 1, 1, 1, 1, 5, 'none', 'audio/Items/Weapons/mg.wav'),
(8, 'Pistol', 'img/Weapons/human-shotgun.png', 1, 1, 1, 1, 1, 1, 1, 5, 'none', 'audio/Items/Weapons/pistol.mp3'),
(9, 'Shotgun', 'img/Weapons/human-shotgun.png', 1, 1, 1, 1, 1, 1, 1, 5, 'none', 'audio/Items/Weapons/shotgun.mp3'),
(10, 'The Mighty Crowbar', 'img/Weapons/crowbar.png', 1, 1, 1, 1, 1, 1, 1, 5, 'none', 'audio/Items/Weapons/crowbar.mp3'),
(11, 'Hide Helm', 'img/Armor/hide-helm.png\r\n', 1, 1, 1, 1, 1, 1, 1, 0, 'none', 'null'),
(12, 'Hide Chest', 'img/Armor/hide-chest.png\r\n', 1, 1, 1, 1, 1, 1, 1, 1, 'none', 'null'),
(13, 'Hide Gauntlets', 'img/Armor/hide-gaunts.png\r\n', 1, 1, 1, 1, 1, 1, 1, 2, 'none', 'null'),
(14, 'Hide Leggings', 'img/Armor/hide-legs.png\r\n', 1, 1, 1, 1, 1, 1, 1, 3, 'none', 'null'),
(15, 'Hide Boots', 'img/Armor/hide-boots.png\r\n', 1, 1, 1, 1, 1, 1, 1, 4, 'none', 'null'),
(16, 'Guard Helm', 'img/Armor/riot-helm.png\r\n', 1, 1, 1, 1, 1, 1, 1, 0, 'none', 'null'),
(17, 'Guard Chestpiece', 'img/Armor/riot-chest.png\r\n', 1, 1, 1, 1, 1, 1, 1, 1, 'none', 'null'),
(18, 'Guard Gauntlets', 'img/Armor/riot-gaunts.png\r\n', 1, 1, 1, 1, 1, 1, 1, 2, 'none', 'null'),
(19, 'Guard Legs', 'img/Armor/riot-legs.png\r\n', 1, 1, 1, 1, 1, 1, 1, 3, 'none', 'null'),
(20, 'Guard Boots', 'img/Armor/riot-boots.png\r\n', 1, 1, 1, 1, 1, 1, 1, 4, 'none', 'null'),
(21, 'Hi-Tech Helm', 'img/Armor/tek-helm.png\r\n', 1, 1, 1, 1, 1, 1, 1, 0, 'none', 'null'),
(22, 'Hi-Tech Chestpiece', 'img/Armor/tek-chest.png\r\n', 1, 1, 1, 1, 1, 1, 1, 1, 'none', 'null'),
(23, 'Hi-Tech Gauntlets', 'img/Armor/tek-gaunts.png\r\n', 1, 1, 1, 1, 1, 1, 1, 2, 'none', 'null'),
(24, 'Hi-Tech Leggins', 'img/Armor/tek-legs.png\r\n', 1, 1, 1, 1, 1, 1, 1, 3, 'none', 'null'),
(25, 'Hi-Tech Boots', 'img/Armor/tek-boots.png\r\n', 1, 1, 1, 1, 1, 1, 1, 4, 'none', 'null'),
(26, 'Key Card', 'img/Consumables/keycard.png', 1, 1, 1, 1, 1, 1, 1, 1, 'none', 'audio/Items/Consumables/keycard-success.WAV');

-- --------------------------------------------------------

--
-- Table structure for table `monsters`
--

CREATE TABLE `monsters` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `img_url` varchar(255) NOT NULL,
  `level` int(11) NOT NULL,
  `max_hp` int(11) NOT NULL,
  `hp` int(11) NOT NULL,
  `armor` int(11) NOT NULL,
  `ad` int(11) NOT NULL,
  `charisma` int(11) NOT NULL,
  `dexterity` int(11) NOT NULL,
  `item_id` int(11) NOT NULL,
  `experience` int(11) NOT NULL,
  `audio_source` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `monsters`
--

INSERT INTO `monsters` (`id`, `name`, `img_url`, `level`, `max_hp`, `hp`, `armor`, `ad`, `charisma`, `dexterity`, `item_id`, `experience`, `audio_source`) VALUES
(1, 'Alien Critter', 'img/Monster/critter.png', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'audio/Monster/zergling.wav'),
(2, 'Alien Humanoid', 'img/Monster/alien-humanoid-maybe.png', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'audio/Monster/humanoid.wav'),
(3, 'Zombie Human', 'img/Monster/zombie-naut.png', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'audio/Monster/zombie-human.wav'),
(4, 'Destroyer', 'img/Monster/hydralisk.png', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'audio/Monster/hydralisk.wav'),
(5, 'Alien Queen', 'img/Monster/alien-queen2.png', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'audio/Monster/queen-attack.wav'),
(6, 'The Alien Commander', 'img/Monster/u-knuck.png', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'audio/Monster/uganda-youdonotknow.mp3');

-- --------------------------------------------------------

--
-- Table structure for table `rooms`
--

CREATE TABLE `rooms` (
  `id` int(11) NOT NULL,
  `number` int(11) NOT NULL,
  `monster_id` int(11) NOT NULL,
  `item_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `character_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `characters`
--
ALTER TABLE `characters`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `inventories`
--
ALTER TABLE `inventories`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `monsters`
--
ALTER TABLE `monsters`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `rooms`
--
ALTER TABLE `rooms`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `characters`
--
ALTER TABLE `characters`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `inventories`
--
ALTER TABLE `inventories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `items`
--
ALTER TABLE `items`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;
--
-- AUTO_INCREMENT for table `monsters`
--
ALTER TABLE `monsters`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `rooms`
--
ALTER TABLE `rooms`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
