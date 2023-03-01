create database Zubar
use Zubar

create table Doktor(
id INT IDENTITY(1,1) PRIMARY KEY,
ime NVARCHAR(20),
prezime NVARCHAR(20),
specijalizacija NVARCHAR(20),
broj_tel INT)

create table Pacijent(
id INT IDENTITY(1,1) PRIMARY KEY,
ime NVARCHAR(20),
prezime NVARCHAR(20),
broj_tel INT,
doktor_id INT FOREIGN KEY REFERENCES Doktor(id))

create table Dijagnoza(
id INT IDENTITY(1,1) PRIMARY KEY,
opis_dijagnoze NVARCHAR(120),
pacijent_id INT FOREIGN KEY REFERENCES Pacijent(id),)

create table Tretman(
id INT IDENTITY(1,1) PRIMARY KEY,
cena INT,
dijagnoza_id INT FOREIGN KEY REFERENCES Dijagnoza(id))

create table Termin(
datum DATE,
vreme_pocetka TIME,
vreme_zavrsetka TIME,
pacijent_id INT FOREIGN KEY REFERENCES Pacijent(id),
doktor_id INT FOREIGN KEY REFERENCES Doktor(id),
tretman_id INT FOREIGN KEY REFERENCES Tretman(id))




