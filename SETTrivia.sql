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
PRIMARY KEY (A_ID),
FOREIGN KEY (QuestionID) REFERENCES Questions (Q_ID)
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

INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('a', 'Africa', 1, false, 1);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('b', 'South America', 2, false, 1);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('c', 'Antarctica', 3, true, 1);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('d', 'Greenland', 4, false, 1);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('a', 'Uranus', 5, true, 2);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('b', 'Jupiter', 6, false, 2);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('c', 'Mars', 7, false, 2);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('d', 'Moon', 8, false, 2);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('a', 'Plie', 9, false, 3);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('b', 'Pirouette', 10, true, 3);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('c', 'Rond de jambe', 11, false, 3);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('d', 'Adagio', 12, false, 3);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('a', 'Orange', 13, true, 4);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('b', 'Pineapple', 14, false,4);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('c', 'Mango', 15, false,4);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('d', 'Apple', 16, false,4);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('a', 'NCC-1701 C', 17, false,5);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('b', 'NCC-1701 A', 18, false,5);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('c', 'NCC-1701 B', 19, false,5);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('d', 'NCC-1701', 20, true,5);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('a', 'Lizard Circuit', 21, false,6);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('b', 'Strax Circuit', 22, false,6);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('c', 'Chameleon Circuit', 23, true,6);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('d', 'Gallifrey Circuit', 24, false,6);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('a', 'Bubble sort', 25, false,7);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('b', 'Comb sort', 26, false,7);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('c', 'Bucket sort', 27, false,7);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('d', 'Quick sort', 28, true,7);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('a', 'Macintosh', 29, false,8);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('b', 'Unix', 30, true,8);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('c', 'Linux', 31, false,8);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('d', 'QNX', 32, false,8);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('a', 'Alan Turing', 33, true,9);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('b', 'Bob Turing', 34, false,9);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('c', 'Adrian Turing', 35, false,9);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('d', 'Mathison Turing', 36, false,9);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('a', 'Niklaus Wirth', 37, false,10);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('b', 'Bill Gates', 38, false,10);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('c', 'Bjarne Stroustrup', 39, true,10);
INSERT INTO ANSWERS (A_Letter, ADescription, A_ID, ACorrect, QuestionID) VALUES ('d', 'Paul Allen', 40, false,10);
