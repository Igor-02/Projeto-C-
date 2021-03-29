
create database projeto_locadora;

use projeto_locadora;

create table categorias (
 idcategoria int auto_increment primary key,
 nome_categoria varchar(255)
);


create table filmes (
 idfilme int auto_increment primary key,
 categoria_id int,
 nome_filme varchar(255),
 diretor varchar(255),
 valor_locacao decimal(12,2),

 FOREIGN KEY (categoria_id) REFERENCES categorias (idcategoria)
);


create table usuario(
 idusuario int auto_increment primary key,
 login varchar(255),
 senha varchar(255)
);

create table clientes(
 idcliente int auto_increment primary key,
 nome varchar(255),
 rg varchar(255),
 telefone varchar(30),
 endereco varchar(255),
 bairro varchar(100),
 cidade varchar(200),
 uf varchar(255),
 email varchar(255),
 datanascimento varchar(16),
 sexo varchar(40)

);

select * from clientes;


create table locacoes (
 idlocacoes int auto_increment primary key,
 cliente_id int,
 filme_id int,
 data_retirada date,
 data_devolucao date,

 FOREIGN KEY (cliente_id) REFERENCES clientes (idcliente),
 FOREIGN KEY (filme_id) REFERENCES filmes (idfilme)

);







