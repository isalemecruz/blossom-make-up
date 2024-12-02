-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 02-Dez-2024 às 01:37
-- Versão do servidor: 10.4.32-MariaDB
-- versão do PHP: 8.1.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `blossommakeup`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `produto`
--

CREATE TABLE `produto` (
  `id` int(11) NOT NULL,
  `preco` float DEFAULT NULL,
  `quantidade` int(11) DEFAULT NULL,
  `nome` varchar(255) DEFAULT NULL,
  `FK_funcionario_id` int(11) DEFAULT NULL,
  `FK_tipo_id` int(11) DEFAULT NULL,
  `FK_marca_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `produto`
--

INSERT INTO `produto` (`id`, `preco`, `quantidade`, `nome`, `FK_funcionario_id`, `FK_tipo_id`, `FK_marca_id`) VALUES
(2, 29.99, 100, 'Nars Afterglow Lip Shine 5,5ml', 6, 10, 3),
(3, 45.5, 150, 'MAC Studio Fix Fluid Foundation 30ml', 1, 1, 2),
(4, 35, 200, 'Urban Decay All Nighter Setting Spray 118ml', 2, 3, 4),
(5, 23.75, 80, 'Too Faced Better Than Sex Mascara 8g', 2, 7, 10),
(6, 21.99, 120, 'Anastasia Beverly Hills Brow Wiz 0,085g', 3, 4, 1),
(7, 19.99, 180, 'Maybelline Fit Me Matte + Poreless Foundation 30ml', 4, 1, 5),
(8, 36, 90, 'Fenty Beauty Pro Filt\'r Soft Matte Longwear Foundation 32ml', 4, 1, 6),
(9, 34.5, 130, 'Charlotte Tilbury Pillow Talk Lipstick 3,5g', 5, 9, 7),
(11, 30, 140, 'Benefit Hoola Matte Bronzer 8g', 6, 5, 9),
(12, 1000, 25, 'Primer Glow', NULL, 5, 6),
(13, 45, 48, 'Base Vegana', 3, 1, 11);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `produto`
--
ALTER TABLE `produto`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_produto_1` (`FK_funcionario_id`),
  ADD KEY `FK_produto_2` (`FK_tipo_id`),
  ADD KEY `FK_produto_3` (`FK_marca_id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `produto`
--
ALTER TABLE `produto`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `produto`
--
ALTER TABLE `produto`
  ADD CONSTRAINT `FK_produto_1` FOREIGN KEY (`FK_funcionario_id`) REFERENCES `funcionario` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_produto_2` FOREIGN KEY (`FK_tipo_id`) REFERENCES `tipo` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_produto_3` FOREIGN KEY (`FK_marca_id`) REFERENCES `marca` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
