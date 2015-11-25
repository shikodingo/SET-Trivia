CREATE DATABASE SETTrivia;
USE SETTrivia;

CREATE TABLE Questions (
Q_ID INTEGER,
QDescription VARCHAR(120),
PRIMARY KEY (Q_ID)
);

CREATE TABLE ANSWERS (
A_ID INTEGER,
ADescription VARCHAR(45),
ACorrect bool,
PRIMARY KEY (A_ID)
);

CREATE TABLE Users (
U_ID INTEGER,
U_Name VARCHAR (50), 
UStatus bool,
PRIMARY KEY (U_ID)
);

CREATE TABLE UsersAnswers (
UA_ID INTEGER,
UA_Answer INTEGER,
PRIMARY KEY (UA_ID),
FOREIGN KEY (UA_Answer) REFERENCES ANSWERS (A_ID)
);

CREATE TABLE Leaderboard (
uNID INTEGER,
uACW INTEGER,
UScore INTEGER,
FOREIGN KEY (uNID) REFERENCES Users (U_ID),
FOREIGN KEY (uACW) REFERENCES ANSWERS (A_ID)
);


INSERT INTO Questions (Q_ID, QDescription) VALUES (1, 'What Continent has the fewest watering plants?');
INSERT INTO Questions (Q_ID, QDescription) VALUES (2, 'What was the first planet to be discovered using the telescope, in 1781?');
INSERT INTO Questions (Q_ID, QDescription) VALUES (3, 'What is the ballet term or a 360-degree turn on one foot?');
INSERT INTO Questions (Q_ID, QDescription) VALUES (4, 'What flavour is Cointreau?');
INSERT INTO Questions (Q_ID, QDescription) VALUES (5, 'What was Kirks first Enterprise ship registered as?');
INSERT INTO Questions (Q_ID, QDescription) VALUES (6, 'What device in the TARDIS is broken that keeps it looking like a Police Box?');
INSERT INTO Questions (Q_ID, QDescription) VALUES (7, 'If you need to sort a very large list of integers(billions), what efficient sorting algorithm would be your best bet?');
INSERT INTO Questions (Q_ID, QDescription) VALUES (8, 'Dennis Richie also developed what computer operating system at Bell Labs wth Ken Thompson and Douglas Mcllroy?');
INSERT INTO Questions (Q_ID, QDescription) VALUES (9, 'Name the famous computer scientist who worked to break the Nazi codes at Bletchey Park during WWII.');
INSERT INTO Questions (Q_ID, QDescription) VALUES (10,'Who created the C++ programming language?');

INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('a', 'Africa', 1, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('b', 'South America', 2, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('c', 'Antarctica', 3, true);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('d', 'Greenland', 4, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('a', 'Uranus', 5, true);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('b', 'Jupiter', 6, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('c', 'Mars', 7, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('d', 'Moon', 8, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('a', 'Plie', 9, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('b', 'Pirouette', 10, true);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('c', 'Rond de jambe', 11, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('d', 'Adagio', 12, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('a', 'Orange', 13, true);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('b', 'Pineapple', 14, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('c', 'Mango', 15, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('d', 'Apple', 16, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('a', 'NCC-1701 C', 17, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('b', 'NCC-1701 A', 18, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('c', 'NCC-1701 B', 19, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('d', 'NCC-1701', 20, true);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('a', 'Lizard Circuit', 21, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('b', 'Strax Circuit', 22, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('c', 'Chameleon Circuit', 23, true);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('d', 'Gallifrey Circuit', 24, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('a', 'Bubble sort', 25, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('b', 'Comb sort', 26, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('c', 'Bucket sort', 27, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('d', 'Quick sort', 28, true);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('a', 'Macintosh', 29, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('b', 'Unix', 30, true);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('c', 'Linux', 31, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('d', 'QNX', 32, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('a', 'Alan Turing', 33, true);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('b', 'Bob Turing', 34, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('c', 'Adrian Turing', 35, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('d', 'Mathison Turing', 36, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('a', 'Niklaus Wirth', 37, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('b', 'Bill Gates', 38, false);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('c', 'Bjarne Stroustrup', 39, true);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect) VALUES ('d', 'Paul Allen', 40, false);
