CREATE table Product(
ProductId int primary key identity(1,1) not null,
ProductName varchar(20) not null
)
GO
Create table Supplier(
SupplierId int not null identity(100,5) primary key,
SupplierName varchar(25) not null
)
GO
Create table Purchase(
PurchaseId int not null identity(101,1) primary key,
VoucherNo int not null,
PurchaseDate datetime not null,
Quantity int not null,
UnitPrice decimal(18,4),
ImagePath varchar(100),
ProductId int references Product(ProductId) ON DELETE CASCADE ON UPDATE CASCADE not null,
Supplier int References Supplier(SupplierId) ON DELETE CASCADE ON UPDATE CASCADE not null,
EmpId int References Employee(EmployeeId) ON DELETE CASCADE ON UPDATE CASCADE not null
);
GO