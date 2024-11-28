/* Lógico_1: */

CREATE TABLE produto (
    id INTEGER AUTO_INCREMENT PRIMARY KEY,
    preco FLOAT,
    quantidade INT,
    FK_funcionario_id INTEGER,
    FK_tipo_id INTEGER,
    FK_marca_id INTEGER
);

CREATE TABLE cliente (
    nome VARCHAR(250),
    cpf VARCHAR(250),
    telefone VARCHAR(250),
    email VARCHAR(250),
    id INTEGER AUTO_INCREMENT PRIMARY KEY,
    FK_funcionario_id INTEGER
);

CREATE TABLE funcionario (
    cpf VARCHAR(250),
    salario VARCHAR(250),
    cep VARCHAR(250),
    email VARCHAR(250),
    id INTEGER AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(250),
    numeroCasa VARCHAR(250)
);

CREATE TABLE venda (
    id INTEGER AUTO_INCREMENT PRIMARY KEY,
    valor FLOAT,
    FK_funcionario_id INTEGER,
    FK_cliente_id INTEGER
);

CREATE TABLE tipo (
    id INTEGER AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(250)
);

CREATE TABLE marca (
    id INTEGER AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(250)
);

CREATE TABLE vendaProduto (
    FK_venda_id INTEGER,
    FK_produto_id INTEGER
);
 
ALTER TABLE produto ADD CONSTRAINT FK_produto_1
    FOREIGN KEY (FK_funcionario_id)
    REFERENCES funcionario (id)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE produto ADD CONSTRAINT FK_produto_2
    FOREIGN KEY (FK_tipo_id)
    REFERENCES tipo (id)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE produto ADD CONSTRAINT FK_produto_3
    FOREIGN KEY (FK_marca_id)
    REFERENCES marca (id)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE cliente ADD CONSTRAINT FK_cliente_1
    FOREIGN KEY (FK_funcionario_id)
    REFERENCES funcionario (id)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE venda ADD CONSTRAINT FK_venda_1
    FOREIGN KEY (FK_funcionario_id)
    REFERENCES funcionario (id)
    ON DELETE CASCADE ON UPDATE CASCADE;
 
ALTER TABLE venda ADD CONSTRAINT FK_venda_2
    FOREIGN KEY (FK_cliente_id)
    REFERENCES cliente (id)
    ON DELETE CASCADE ON UPDATE RESTRICT;
 
ALTER TABLE vendaProduto ADD CONSTRAINT FK_vendaProduto_0
    FOREIGN KEY (FK_venda_id)
    REFERENCES venda (id)
    ON DELETE CASCADE ON UPDATE RESTRICT;
 
ALTER TABLE vendaProduto ADD CONSTRAINT FK_vendaProduto_1
    FOREIGN KEY (FK_produto_id)
    REFERENCES produto (id)
    ON DELETE CASCADE ON UPDATE RESTRICT;