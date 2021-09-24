create database FoCstackoverflow;

use FoCstackoverflow;

create table questions (
id int not null auto_increment,
username varchar(30),
title varchar(30),
detail varchar(300),
posted datetime,
category varchar(30),
tags varchar(60),
status int,
primary key(id)
);

create table answers (
id int not null auto_increment,
username varchar(30),
detail varchar(300),
questionid int,
posted datetime,
upvotes int,
primary key(id),
foreign key(questionid) references questions(id)
);

insert into questions (id, username, title, detail, posted, category, tags, status) values(1, 'Tbruyere', 'How to print hello world', 'Ive been stuck on this for days', '2021-8-12 12:30:58', 'C#', 'Basic help', 0);
insert into questions (id, username, title, detail, posted, category, tags, status) values(2, 'Tbruyere', 'How to boolean', 'I need to learn true or false', '2020-10-30 11:36:28', 'C#', 'Basic help', 0);

insert into answers (id, username, detail, questionid, posted, upvotes) values(1, 'Tbruyere', 'type console.writeline(hello world)', 1, '2021-8-12 8:15;10', 0);
insert into answers (id, username, detail, questionid, posted, upvotes) values(2, 'Tbruyere', 'put in vs studio console.writeline(hello world)', 1, '2021-10-12 9:05;45', 0);

