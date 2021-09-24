CREATE DATABASE dbcore5;
GO
USE [dbcore5];
CREATE TABLE autores (
	id int not null check(id between 1 and 9999999999) identity primary key,
	nombre varchar(45),
	apellidos varchar(45)
);

CREATE TABLE editoriales(
	id int not null check(id between 1 and 9999999999) identity primary key,
	nombre varchar(45),
	sede varchar(45)
);

CREATE TABLE libros(
	ISBN int not null check(ISBN between 1 and 9999999999999)  identity primary key,
	editoriales_id int check(editoriales_id between 1 and 9999999999) ,
	titulo varchar(45),
	sinopsis text,
	n_paginas varchar(45)	
);

CREATE TABLE autores_has_libros(
	autores_id int check(autores_id between 1 and 9999999999) ,
	libros_ISBN int check(libros_ISBN between 1 and 9999999999)	
);

ALTER TABLE libros 
ADD constraint fk_editoriales_libros foreign key (editoriales_id) references editoriales(id);

ALTER TABLE autores_has_libros 
ADD constraint fk_autores_has_autores_libros Foreign key (autores_id) references autores(id);

ALTER TABLE autores_has_libros 
ADD constraint fk_libros_has_autores_libros Foreign key (libros_ISBN) references libros(ISBN);