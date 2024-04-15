-- phpMyAdmin SQL Dump
-- version 4.9.4
-- https://www.phpmyadmin.net/
--
-- Počítač: localhost
-- Vytvořeno: Pon 15. dub 2024, 18:07
-- Verze serveru: 10.3.25-MariaDB-0+deb10u1
-- Verze PHP: 5.6.36-0+deb8u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Databáze: `4b1_gazikmarcel_db2`
--

-- --------------------------------------------------------

--
-- Struktura tabulky `tbAdmins`
--

CREATE TABLE `tbAdmins` (
  `id` int(11) NOT NULL,
  `role` enum('user','broker','admin') COLLATE utf8_czech_ci NOT NULL,
  `username` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `password` text COLLATE utf8_czech_ci NOT NULL,
  `name` varchar(255) COLLATE utf8_czech_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_czech_ci NOT NULL,
  `tel` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `pfp` char(36) COLLATE utf8_czech_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbAdmins`
--

INSERT INTO `tbAdmins` (`id`, `role`, `username`, `password`, `name`, `email`, `tel`, `pfp`) VALUES
(1, 'admin', 'jirka', '$2a$11$O.OJ.l2yD90UgsF.cW5Q8e5s77MfuD3fXyovJ..K6bixMgAu.9fdW', 'Ing. Jirka Král', 'jirka@kral.cz', '1234567892', 'jpg'),
(3, 'admin', 'jordan', '$2a$11$RMap3uJlCG2uIUyBo8X2buzy4ZysmLN5TN8eMmvRqjfYJuWO5hpuq', 'jordanek2325555', 'jordan@spyridon.ieremiadis', '1234567895555', 'png'),
(4, 'broker', 'ales', '$2a$11$t2zRR7huPSQ2RxKk9387WulNl78lGG98LLflyWgyg9ACCeYpeByNC', 'ales pichtr222', 'ales@gay.cz', '789456123', 'png'),
(6, 'broker', 'bales', '$2a$11$J3aoNjfwTT2F53dSzTf65OfCirCfpYaJGG0Lwh/3GvsIztq4Nq3r6', 'bales pichtr', 'bales@gay.cz', '789456123', 'png'),
(9, 'user', 'fanousekjirky4', '$2a$11$G3BzTLKkodles6STwwYpLOgfFKIc58GIOIPJRz7syDTCq7n/0ElFi', 'jirkajetop', 'jirka@jemujkulisek.cz', '123456789', 'jpg'),
(10, 'user', 'fanousekjirky3', '$2a$11$L/qqNR9NgpmXYfj1VfaLAONxRS8pVD7TxWBot01Nox66lViuel7om', 'jirkajetop', 'jirka@jemujkulisek.cz', '123456789', 'jpg'),
(11, 'user', 'fanousekjirky', '$2a$11$muHLUn96/ciRwYx4OnusSurDh.DA9tVFSUuwOxYzYxSyoC9XH7zxm', 'jirkajetop2', 'jirka@jemujkulisek.cz', '123456789', 'jpg'),
(12, 'user', 'fanousekjirky2', '$2a$11$0ct3Xmgy8rqmj0MheYO2EOAYd2nTEw984ekPbrsVWs61hexSxfcC.', 'jirkajetop2', 'jirka2@jemujkulisek.cz', '123456789', 'jpg'),
(13, 'user', 'jordan2', '$2a$11$s3Vk//jyyA8P6a.QzSTHL.f0vqg/hrxJY3rhRn3t5zZ1r9kuvm6di', 'pan spermidon', 'jordan@spermidon.cz', '123456789', 'png'),
(14, 'user', 'davit', '$2a$11$GrtNOReUOXa7/revj1QZi./aLITPLxOVQeC6NcR3jFmq/JTpVXavm', 'Bom. B. Shakira', 'IhaveA@bomb.tnt', '4206969420', 'jpg'),
(16, 'broker', 'racho', '$2a$11$zKeUiyACMjBVrHcss5FVium3wMBP1x2fc6IXHRVzsXzNAzc6Rtep6', 'racho', 'racho@isbest.com', '12345698', 'png'),
(17, 'user', 'racho2', '$2a$11$qkXRee2SmrNPzhlvrOnYuOliuXYOgNs1zJYA9HxZ3CH1oGuFwvwFy', 'racho', 'raacho@is.com', '489159981', 'png'),
(18, 'broker', 'gif', '$2a$11$fBTPug3fNSKnEpFlqJp/uehbHjxk1rffLkE9H6TPTLvwwFP8lZLRC', 'gif', 'gif@gif.gif', '123456', 'gif'),
(19, 'user', 'test1', '$2a$11$aWnk7CBZ9N1t77mLh5TXC.0/RhpmF6EfW4FUsICPzxdKLFFHk.w4O', 'test1', 'test@test.com', '123456', 'jpg'),
(20, 'user', 'testicek', '$2a$11$YtBSy3JG14uyvlwNFnkg8emjofhdZy1Y4coRgA4SGZ4pH3WTybube', 'testicek', 'test@test.com', '95195', 'png');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbCategories`
--

CREATE TABLE `tbCategories` (
  `id` int(11) NOT NULL,
  `name` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `imgRoute` varchar(500) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbCategories`
--

INSERT INTO `tbCategories` (`id`, `name`, `imgRoute`) VALUES
(1, 'Byt', 'Images/podklady/home-img-03-442-280.jpg'),
(2, 'Dům', 'Images/podklady/home-img-04-442-280.jpg'),
(3, 'Pozemek', 'Images/podklady/home-img-01-442-280.jpg'),
(4, 'Komerční', 'Images/podklady/home-img-02-442-280.jpg');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbFavorites`
--

CREATE TABLE `tbFavorites` (
  `id` int(11) NOT NULL,
  `idUser` int(11) NOT NULL,
  `idOffer` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbFavorites`
--

INSERT INTO `tbFavorites` (`id`, `idUser`, `idOffer`) VALUES
(13, 4, 3),
(16, 1, 1),
(26, 1, 3),
(28, 1, 7),
(29, 1, 33),
(30, 1, 4),
(31, 1, 5);

-- --------------------------------------------------------

--
-- Struktura tabulky `tbImages`
--

CREATE TABLE `tbImages` (
  `id` varchar(36) COLLATE utf8_czech_ci NOT NULL,
  `idOffer` int(11) NOT NULL,
  `fileExtension` varchar(8) COLLATE utf8_czech_ci NOT NULL,
  `main` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbImages`
--

INSERT INTO `tbImages` (`id`, `idOffer`, `fileExtension`, `main`) VALUES
('00b6280a-882a-4e24-a9ad-c66e29f85434', 36, 'png', 1),
('0a263845-4f6c-45f7-abfd-a6c01a1f1cf2', 32, 'png', 0),
('0ab80caa-c2df-42f3-9934-36ee78fe294c', 30, 'png', 0),
('0c3e04e0-4554-46ae-a26d-d65ac44b50a4', 37, 'png', 1),
('10cc3586-3b7b-44bf-9098-acefdc9d0fd2', 7, 'jpg', 1),
('1ffea316-9f4b-428f-b7bc-abbd7ad9a81b', 32, 'jpg', 0),
('2b992d56-bb87-4cfd-bf0b-f37c5851e982', 30, 'png', 0),
('31dd1d4b-75ef-40be-867b-441eab7a6371', 38, 'png', 1),
('37df0b54-eded-48fb-a58d-bf70415a5cd1', 35, 'jpg', 1),
('40819034-c6bc-49d2-8de8-8a2fcc71b19d', 37, 'png', 0),
('467df30d-b0e2-4655-9755-cb5bfecfcb86', 29, 'jpg', 0),
('4c5852ec-3708-46a2-a58f-d297f1102e45', 32, 'jpg', 1),
('5bf80da8-d650-45f7-9d78-a4f7f3da15cc', 4, 'jpg', 1),
('5c9d68e3-e254-4338-afe9-b9dfe803b710', 38, 'png', 0),
('65f08cf7-dabc-4e79-8fdd-26d43b2a783f', 40, 'png', 1),
('67801dcd-a1f1-4231-b4bf-d5a4387f0b63', 38, 'png', 0),
('6ca52f58-59e4-4789-a59a-6b2d1be27892', 40, 'png', 0),
('6e14c841-ee18-4a1c-889c-96e1b0442565', 35, 'png', 0),
('71064b7d-9606-46d4-8cf8-8bd776d303c6', 34, 'jpeg', 1),
('72511fc5-7967-4566-ac5c-0fb8ab18bd85', 1, 'jpg', 1),
('81fb032a-1364-4478-8cb6-9f6a07708634', 3, 'jpg', 1),
('821954f2-09ec-47ba-9586-ca6b262fe8a8', 36, 'png', 0),
('8226a7b5-efcb-458d-b872-e837af0869ec', 1, 'jpg', 0),
('906b1821-dc37-4472-8128-c5d88081ca27', 5, 'jpg', 1),
('9bbfad99-73ec-437b-9f3b-155f8258e820', 30, 'png', 0),
('a58d291e-82bf-43cc-a318-abd2b9b04d9a', 36, 'png', 0),
('a894d2d2-d45c-4973-a9fe-8b28015a0211', 29, 'jpg', 0),
('ac51a751-c1c8-498c-b9c4-d974e1318751', 30, 'png', 0),
('adc73485-5432-4497-bd4c-1a2b1c990056', 32, 'jpg', 0),
('b215df67-ee14-47f8-92eb-50c3333c7b17', 30, 'png', 1),
('b5c6d54a-c351-4ac4-8728-c2840613a5a9', 29, 'jpg', 1),
('bf8ef40b-f6e9-40e4-be78-fd269d513de9', 33, 'jpg', 1),
('c0ae0074-4c11-4c8e-a8d6-70ddc3f6d674', 31, 'jpg', 1),
('d51ea2ef-28e9-448e-92ef-8345ae857dd1', 39, 'png', 1),
('d6168e00-79b2-43c7-bb2f-dd13b3549606', 39, 'png', 0),
('d8287104-0974-49b1-91b1-064dfa055b5d', 39, 'png', 0),
('d9c91d3c-c74c-405a-b665-6fa887417f71', 30, 'png', 0),
('e15614da-6094-4ac7-81ef-38c1a084b77e', 30, 'png', 0),
('e26a1f03-a6ce-41f7-8dd8-15895115baa5', 37, 'png', 0),
('e4cc2a51-bbfb-4877-90df-04529f36613d', 1, 'jpg', 0),
('e5be00cc-eea8-4ca9-b324-89dd62b17c00', 8, 'jpg', 1),
('eb9b05b8-2e19-4f32-a914-13ac754a1c76', 31, 'jpg', 0),
('fd9f2b5f-9374-4a0f-975d-91270873ad4e', 40, 'png', 0);

-- --------------------------------------------------------

--
-- Struktura tabulky `tbInquiries`
--

CREATE TABLE `tbInquiries` (
  `id` int(11) NOT NULL,
  `idOwner` int(11) NOT NULL,
  `idSender` int(11) NOT NULL,
  `idOffer` int(11) NOT NULL,
  `isActive` bit(1) NOT NULL,
  `name` varchar(255) COLLATE utf8_czech_ci NOT NULL,
  `tel` varchar(50) COLLATE utf8_czech_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbInquiries`
--

INSERT INTO `tbInquiries` (`id`, `idOwner`, `idSender`, `idOffer`, `isActive`, `name`, `tel`, `email`) VALUES
(1, 9, 1, 1, b'0', 'davit shartava', '12345698', 'miluju@jirkukrale.com'),
(3, 4, 1, 1, b'0', 'Ahmed Ahmed Mohammed', '7355608', 'immablow@thiswholething.up'),
(4, 11, 1, 1, b'0', 'davit shakira', '123456789', 'davit@shakira.cz'),
(5, 1, 1, 1, b'0', 'davit shakira', '123', 'davit@shakira.cz'),
(6, 3, 1, 3, b'0', 'richard mnam', '123456789', 'ja@fakt.ntsm'),
(7, 4, 16, 4, b'0', 'racho', '12345698', 'racho@isbest.com'),
(8, 1, 16, 1, b'0', 'racho', '12345698', 'racho@isbest.com'),
(10, 1, 16, 1, b'0', 'racho', '12345698', 'racho@isbest.com'),
(11, 3, 2, 3, b'0', 'ahah', '123', 'a@a.cz'),
(12, 1, 18, 1, b'0', 'gif', '123456', 'gif@gif.gif'),
(13, 1, 18, 1, b'0', 'gif', '123456', 'gif@gif.gif');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbLabels`
--

CREATE TABLE `tbLabels` (
  `id` int(11) NOT NULL,
  `label` varchar(255) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbLabels`
--

INSERT INTO `tbLabels` (`id`, `label`) VALUES
(1, 'Konstrukce budovy'),
(2, 'Stav budovy'),
(3, 'Užitná plocha bytu'),
(4, 'Počet podlaží budovy2'),
(5, '222'),
(6, '555'),
(7, 'Stav budovy2'),
(8, 'aaa'),
(9, 'aaa'),
(10, 'aaa');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbMessages`
--

CREATE TABLE `tbMessages` (
  `id` int(11) NOT NULL,
  `idInquiry` int(11) NOT NULL,
  `idUser` int(11) DEFAULT NULL,
  `text` text COLLATE utf8_czech_ci NOT NULL,
  `time` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbMessages`
--

INSERT INTO `tbMessages` (`id`, `idInquiry`, `idUser`, `text`, `time`) VALUES
(1, 1, 11, 'Jirko udělej mi dítě pls', '2023-12-27 22:04:47'),
(2, 1, 3, 'Jirko udělej mi dítě pls znovu', '2023-12-27 23:04:47'),
(3, 3, 11, 'Jirko, já tě fakt zbožnuju Jirko FAKT KAMO PROSÍM ...', '2023-12-20 22:09:01'),
(4, 4, 11, 'I Ahmed IV. will blow this up (I love davit shartava)', '2023-12-20 22:09:01'),
(5, 5, 11, 'ahooj', '2023-12-25 22:09:32'),
(6, 4, 11, 'ahooj', '2023-12-25 22:09:32'),
(7, 6, 11, 'gejmr', '2023-12-14 22:18:00'),
(8, 3, 1, 'Zmrde', '2023-12-18 22:09:05'),
(9, 3, 1, 'https://media3.giphy.com/media/jV1E7JDBy6Pno62Z3A/giphy.gif', '2023-12-18 22:09:05'),
(10, 3, 4, 'JIRKA KRÁL ŘEKL CO?????????', '2023-12-19 19:51:48'),
(11, 3, 1, 'Čteš správně ty zmrde', '2023-12-19 19:52:29'),
(12, 3, 1, 'https://media1.tenor.com/m/3GsO0PrT0-EAAAAd/epic-spongebob.gif', '2023-12-19 19:52:41'),
(13, 3, 4, 'COOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO', '2023-12-19 19:53:38'),
(14, 3, 4, 'Jirko, já tě fakt zbožnuju Jirko FAKT KAMO PROSÍM PROSÍM (PROSÍM DEJ MI ČESKÉ OBČANSTVÍ ;(((()', '2023-12-19 21:09:55'),
(15, 3, 4, 'Hej jirko kamo hej jako ja te mam fakt rad bro, nebud zmrd ;( prosim hej fakt kamo plsky pwosim', '2023-12-19 21:39:42'),
(16, 3, 1, 'https://media.discordapp.net/attachments/935514902947332136/935631587469582417/ezgif.com-gif-maker_1.gif', '2023-12-19 21:41:29'),
(17, 3, 4, 'Hej Jirko takhle zlej bys nemel bejt na fanousky fr kamo proc ses takovej :(', '2023-12-19 21:42:58'),
(18, 3, 1, 'https://media.discordapp.net/attachments/900333208007213089/1156596687108845618/caption.gif', '2023-12-19 21:44:32'),
(19, 3, 1, 'Drž už hubu bro dělám tady realnej bussiness kamo přestaň mě spamovat', '2023-12-19 21:44:47'),
(20, 3, 4, 'https://media1.tenor.com/m/apns_8-5xl8AAAAd/huh-verne.gif', '2023-12-19 21:45:11'),
(21, 3, 1, 'https://media.discordapp.net/attachments/800677966082080791/1007258188632047626/ezgif.com-gif-maker_1.gif', '2023-12-19 21:45:36'),
(22, 3, 1, 'to cumis co', '2023-12-20 08:10:30'),
(23, 3, 1, 'kundo', '2023-12-20 09:21:19'),
(24, 7, 16, 'hello me big like house this', '2024-01-01 21:38:25'),
(25, 7, 16, 'yeah very much', '2024-01-01 21:44:23'),
(26, 8, 16, 'Heelo, this Dati Shakira? The famous georgian military leader?', '2024-01-01 21:45:45'),
(27, 8, 16, 'I big much like is you!', '2024-01-01 21:45:54'),
(28, 8, 16, 'I would like your toe suck', '2024-01-01 21:45:59'),
(29, 9, 16, 'davitův byt', '2024-01-01 21:46:32'),
(30, 10, 16, '123456', '2024-01-01 21:47:38'),
(31, 11, 0, 'funguje? 50 sf flat', '2024-01-01 21:47:59'),
(32, 11, 1, 'jo funguje more co testuješ ty kundo', '2024-01-01 21:49:12'),
(33, 3, 1, 'drz uz kurva hubu vole', '2024-01-01 22:15:17'),
(34, 7, 4, 'damn bitch you one sexy aah mf', '2024-01-02 18:29:07'),
(35, 12, 18, 'KUNDO TO ČUMÍŠ NA TU MOJÍ PROFILOVKU VIĎ PÍČO', '2024-01-02 19:46:39'),
(36, 13, 18, 'KUNDO TO ČUMÍŠ NA TU MOJÍ PROFILOVKU VIĎ PÍČO ', '2024-01-02 19:46:48'),
(37, 13, 18, 'https://tenor.com/bGUQ6.gif', '2024-01-02 19:46:54'),
(38, 1, 1, '<div class=\"tenor-gif-embed\" data-postid=\"22582318\" data-share-method=\"host\" data-aspect-ratio=\"1.78771\" data-width=\"100%\"><a href=\"https://tenor.com/view/roblox-kai-tqk-red-stephanie-gif-22582318\">Roblox Kai GIF</a>from <a href=\"https://tenor.com/search/roblox-gifs\">Roblox GIFs</a></div> <script type=\"text/javascript\" async src=\"https://tenor.com/embed.js\"></script>', '2024-01-02 19:48:13'),
(39, 1, 1, 'UNLUCKY KUNDO', '2024-01-02 19:48:20');

-- --------------------------------------------------------

--
-- Struktura tabulky `tbOffers`
--

CREATE TABLE `tbOffers` (
  `id` int(11) NOT NULL,
  `idBroker` int(11) NOT NULL,
  `name` varchar(255) COLLATE utf8_czech_ci NOT NULL,
  `price` int(11) NOT NULL,
  `location` varchar(255) COLLATE utf8_czech_ci NOT NULL,
  `area` int(11) NOT NULL,
  `description` text COLLATE utf8_czech_ci NOT NULL,
  `idCategory` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbOffers`
--

INSERT INTO `tbOffers` (`id`, `idBroker`, `name`, `price`, `location`, `area`, `description`, `idCategory`) VALUES
(1, 1, 'Davitův BytX', 12966700, 'Gruzie (Ne Tbilisi)', 2179, 'Exkluzivně nabízíme prostorný, výborně řešený byt 3+1/L o celkové výměře 81 m2 (včetně lodžie plus sklep), který se nachází ve 4.NP zatepleného zrekonstruovaného domu, v příjemné a klidné lokalitě Praha 9 – Horní Počernice.<br><br>Byt má zděnou koupelnu s vanou a samostatné WC, vstupní předsíň, dvě ložnice o výměře 12,6 m2 a 12,5 m2, obývací pokoj 22 m2 a kuchyň s jídelnou o výměře 12,4 m2. Na jižně orientovanou lodžii je vstup z obývacího pokoje a je z ní hezký výhled do otevřeného prostoru a na dětské hřiště. Ložnice jsou orientované na severní stranu.<br><br>Na podlaze je dlažba, laminátová plovoucí podlaha a koberec, okna jsou plastová se žaluziemi.<br><br>Byt je vybaven kuchyňskou linkou na míru s vestavěnou elektrickou troubou a sklokeramickou varnou deskou, vestavěnými skříněmi v předsíni a v ložnici. Další vybavení bytu může po dohodě také zůstat.<br><br>K bytu náleží sklepní kóje cca 4 m2 a lze využívat kočárkárnu/kolárnu umístěnou v přízemí domu.<br><br>Měsíční poplatky jsou pro čtyřčlennou rodinu cca 5 300,- včetně fondu oprav, který je ve výši 1 000,-Kč. Výborně fungující SVJ je pouze jeden vchod domu o jedenácti bytových jednotkách. SVJ není zatíženo žádným úvěrem.<br><br>Poloha zrekonstruovaného zatepleného panelového domu je velice výhodná. Přímo u domu je Penny Market a lékárna, v pěším dosahu je pak veškerá občanská vybavenost – MŠ, ZŠ, SOŠ, lékaři, obchody, restaurace, divadlo, několik dětských hřišť a sportovišť. K větším procházkám a sportovnímu vyžití Vás naláká Klánovický les. Stanice metra B – Černý Most je vzdálena jednu cca 1,2 KM od domu a na metro se tak můžete dostat i pěšky nebo pohodlně dojet autobusem za 3 minuty.<br><br>Nemovitost doporučuji pro pohodlné, klidné rodinné bydlení.<br><br>Osobní vlastnictví s možností financování hypotékou, kterou Vám rádi pomůžeme vyřídit.', 2),
(3, 1, 'SF FlatXXXXX', 50, 'Brno', 46, 'AVA Nob Hill includes studios and 1 and 2 bedroom apartments that                    feature an urban-inspired design that extends beyond your walls and                    throughout the entire community. AVA Nob Hill includes studios and 1                    and 2 bedroom apartments that feature an urban-inspired design that                    extends beyond your walls and throughout the entire community.', 3),
(4, 4, 'SF Flat58X', 500000, 'Brno', 647, 'AVA Nob Hill includes studios and 1 and 2 bedroom apartments that\r\n                    feature an urban-inspired design that extends beyond your walls and\r\n                    throughout the entire community. AVA Nob Hill includes studios and 1\r\n                    and 2 bedroom apartments that feature an urban-inspired design that\r\n                    extends beyond your walls and throughout the entire community.', 3),
(5, 4, 'Vesecky ahojX', 1296666, 'praha', 747, 'ahoj :3', 1),
(7, 4, 'SF FlatX', 500000, 'Brno', 3736, 'AVA Nob Hill includes studios and 1 and 2 bedroom apartments that\r\n                    feature an urban-inspired design that extends beyond your walls and\r\n                    throughout the entire community. AVA Nob Hill includes studios and 1\r\n                    and 2 bedroom apartments that feature an urban-inspired design that\r\n                    extends beyond your walls and throughout the entire community.', 3),
(8, 1, 'Vesecky ahojX', 1296666, 'praha', 1795, 'ahoj :3', 3),
(29, 1, 'offer1X', 500, 'Azerbaijan', 50, 'Popis', 3),
(30, 1, 'Dům Jirky KráleX', 69420, 'JsiChudej, Praha 10', 5000, 'Barák co bys chtěl to koukas co vole', 2),
(31, 1, 'AlahX', 57, 'Islamabad', 17, 'Alaaah', 3),
(32, 1, 'Al-Qaeda', 159, 'Islamabad', 77, 'THE HISTORIC HOUSE OF BIN LADIN', 2),
(33, 1, 'MEOW', 179500, 'Praha', 17, 'Meow meow meeeow meow meow meow meow meow ?', 1),
(34, 1, 'DALSI DATAAAA', 500, 'Brno', 500, 'ntsm bro supa sorry', 4),
(35, 1, 'POSLEDNI DATA CHCI SPAT', 2353, 'Praha', 2354, 'CHCI SPAT PROSIM', 3),
(36, 1, 'test', 129, 'Islamabad', 129, 'AHOJ AHOJ TEST', 2),
(37, 1, 'test1', 55, 'Islamabad', 89, 'Popisek', 1),
(38, 1, 'aaa', 111, 'Brno', 111, '111', 1),
(39, 1, 'aaa', 111, 'JsiChudej, Praha 10', 111, 'Popisek prosim funguj', 3),
(40, 1, 'test', 222, 'Islamabad', 222, 'Nový popisek tentokrat snad bude fungovat lol', 3);

-- --------------------------------------------------------

--
-- Struktura tabulky `tbValues`
--

CREATE TABLE `tbValues` (
  `id` int(11) NOT NULL,
  `idLabel` int(11) NOT NULL,
  `idOffer` int(11) NOT NULL,
  `value` varchar(255) COLLATE utf8_czech_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

--
-- Vypisuji data pro tabulku `tbValues`
--

INSERT INTO `tbValues` (`id`, `idLabel`, `idOffer`, `value`) VALUES
(1, 1, 1, 'panelová'),
(2, 4, 1, '7 podlaží'),
(3, 2, 1, 'dobrý'),
(4, 3, 1, '41 m&sup2;'),
(8, 9, 1, 'pánvička'),
(15, 1, 3, 'fakt krutopřísnáx3'),
(16, 2, 3, 'stojí ještě (myslim)x3'),
(17, 3, 3, 'kámo jako tolik plochy to je insanex3'),
(21, 3, 40, '12'),
(22, 1, 40, '12');

--
-- Klíče pro exportované tabulky
--

--
-- Klíče pro tabulku `tbAdmins`
--
ALTER TABLE `tbAdmins`
  ADD PRIMARY KEY (`id`);

--
-- Klíče pro tabulku `tbCategories`
--
ALTER TABLE `tbCategories`
  ADD PRIMARY KEY (`id`);

--
-- Klíče pro tabulku `tbFavorites`
--
ALTER TABLE `tbFavorites`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idOffer` (`idOffer`),
  ADD KEY `idUser` (`idUser`);

--
-- Klíče pro tabulku `tbImages`
--
ALTER TABLE `tbImages`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idOffer` (`idOffer`);

--
-- Klíče pro tabulku `tbInquiries`
--
ALTER TABLE `tbInquiries`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idBroker` (`idOwner`),
  ADD KEY `idOffer` (`idOffer`),
  ADD KEY `idSender` (`idSender`);

--
-- Klíče pro tabulku `tbLabels`
--
ALTER TABLE `tbLabels`
  ADD PRIMARY KEY (`id`);

--
-- Klíče pro tabulku `tbMessages`
--
ALTER TABLE `tbMessages`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idInquiry` (`idInquiry`),
  ADD KEY `idUser` (`idUser`);

--
-- Klíče pro tabulku `tbOffers`
--
ALTER TABLE `tbOffers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idBroker` (`idBroker`),
  ADD KEY `idCategory` (`idCategory`);

--
-- Klíče pro tabulku `tbValues`
--
ALTER TABLE `tbValues`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idLabel` (`idLabel`),
  ADD KEY `idOffer` (`idOffer`);

--
-- AUTO_INCREMENT pro tabulky
--

--
-- AUTO_INCREMENT pro tabulku `tbAdmins`
--
ALTER TABLE `tbAdmins`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT pro tabulku `tbCategories`
--
ALTER TABLE `tbCategories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pro tabulku `tbFavorites`
--
ALTER TABLE `tbFavorites`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT pro tabulku `tbInquiries`
--
ALTER TABLE `tbInquiries`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT pro tabulku `tbLabels`
--
ALTER TABLE `tbLabels`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT pro tabulku `tbMessages`
--
ALTER TABLE `tbMessages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT pro tabulku `tbOffers`
--
ALTER TABLE `tbOffers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT pro tabulku `tbValues`
--
ALTER TABLE `tbValues`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- Omezení pro exportované tabulky
--

--
-- Omezení pro tabulku `tbFavorites`
--
ALTER TABLE `tbFavorites`
  ADD CONSTRAINT `tbFavorites_ibfk_2` FOREIGN KEY (`idOffer`) REFERENCES `tbOffers` (`id`),
  ADD CONSTRAINT `tbFavorites_ibfk_3` FOREIGN KEY (`idUser`) REFERENCES `tbAdmins` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Omezení pro tabulku `tbInquiries`
--
ALTER TABLE `tbInquiries`
  ADD CONSTRAINT `tbInquiries_ibfk_1` FOREIGN KEY (`idOwner`) REFERENCES `tbAdmins` (`id`),
  ADD CONSTRAINT `tbInquiries_ibfk_2` FOREIGN KEY (`idOffer`) REFERENCES `tbOffers` (`id`),
  ADD CONSTRAINT `tbInquiries_ibfk_3` FOREIGN KEY (`id`) REFERENCES `tbMessages` (`idInquiry`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Omezení pro tabulku `tbOffers`
--
ALTER TABLE `tbOffers`
  ADD CONSTRAINT `idCategoryFK` FOREIGN KEY (`idCategory`) REFERENCES `tbCategories` (`id`),
  ADD CONSTRAINT `tbOffers_ibfk_1` FOREIGN KEY (`idBroker`) REFERENCES `tbAdmins` (`id`);

--
-- Omezení pro tabulku `tbValues`
--
ALTER TABLE `tbValues`
  ADD CONSTRAINT `tbValues_ibfk_1` FOREIGN KEY (`idLabel`) REFERENCES `tbLabels` (`id`),
  ADD CONSTRAINT `tbValues_ibfk_2` FOREIGN KEY (`idOffer`) REFERENCES `tbOffers` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
