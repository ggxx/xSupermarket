create table Category
(
    Id Text,
	Name Text
);
create table Employee
(
    Name Text,
	Sex Text,
	Section Text
);
create table Marketbasket
(
    Id Text,
	Product Text
);
create table Product
(
    Name Text,
    Price Number,
    Cost Number,
    ProductArea Text,
    Section Text,
    Category Test,
    Sales Number
);
create table ProductArea
(
    Id Text,
	Name Text
);
create table Section
(
    Id Text,
	Name Text
);