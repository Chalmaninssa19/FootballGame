create database football;

create table team (
	idTeam serial primary key,
	nomTeam varchar(10)
);

create table gamer (
	idGamer serial primary key,
	nomGamer varchar(10),
	idEquipe int,
	poche DOUBLE PRECISION
);

create table match (
	idMatch serial primary key,
	nomTeamA varchar(10),
	nomTeamB varchar(10),
	scoreA int,
	scoreB int,
	caisseA DOUBLE PRECISION,
	caisseB DOUBLE PRECISION,
	jeton DOUBLE PRECISION
);

create table proprio (
	nom varchar(10),
	caisse DOUBLE PRECISION
);

/*create view v_gamerTeam as select idTeam, idGamer, nomGamer as gamer,nomTeam as team, poche from gamer join team on gamer.idEquipe=team.idTeam;

insert INTO proprio VALUES ('chalman',0.0);

insert into team values (1, 'A');
insert into team values (2, 'B');

insert into gamer values (default, 'AA', 1, 2000);
insert into gamer values (default, 'BB', 2, 1500);
