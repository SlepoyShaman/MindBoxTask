USE MindboxTask

IF NOT EXISTS (SELECT * FROM sysobjects WHERE NAME='Products' AND xtype='U')
	BEGIN
    CREATE TABLE Products (
        Id INT CONSTRAINT PK_Product_Id PRIMARY KEY IDENTITY,
		Name NVARCHAR(256) NULL
    );

	SET IDENTITY_INSERT Products ON

	INSERT INTO Products (Id, Name) VALUES
	(1, 'Jeans'),
	(2, 'Trousers'),
	(3, 'T-shirt polo'),
	(4, 'Ushanka'),
	(5, 'Sneakers'),
	(6, 'Slippers'),
	(7, 'Underpants'),
	(8, 'Shirt');
	
	SET IDENTITY_INSERT Products OFF
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE NAME='Categories' AND xtype='U')
	BEGIN
	CREATE TABLE Categories (
	Id INT CONSTRAINT PK_Category_Id PRIMARY KEY IDENTITY,
	Name NVARCHAR(256) NULL
	);

	SET IDENTITY_INSERT Categories ON

	INSERT INTO Categories (Id, Name) VALUES
	(1, 'Pants'),
	(2, 'T-shirts'),
	(3, 'Hats'),
	(4, 'Shoes'),
	(5, 'Jackets'),
	(6, 'Cotton');

	SET IDENTITY_INSERT Categories OFF
END

IF NOT EXISTS (SELECT * FROM sysobjects WHERE NAME='ProductCategories' AND xtype='U')
	BEGIN
	CREATE TABLE ProductCategories (
	ProductId INT NOT NULL,
	CategoryId INT NOT NULL,
	CONSTRAINT PK_ProductCategories PRIMARY KEY (ProductId, CategoryId),
	CONSTRAINT FK_ProductCategories_Product_Id FOREIGN KEY (ProductId) REFERENCES Products (Id) ON DELETE CASCADE,
	CONSTRAINT FK_ProductCategories_Category_Id FOREIGN KEY (CategoryId) REFERENCES Categories (Id) ON DELETE CASCADE
	);

	INSERT INTO ProductCategories (ProductId, CategoryId) VALUES
	(1, 1),
	(2, 1),
	(3, 2),
	(4, 3),
	(5, 4),
	(6, 4),
	(8, 2),
	(3, 6),
	(8, 6);
END


SELECT 
pr.Name AS Product,
ct.Name As Category
FROM  Products pr
	LEFT JOIN ProductCategories pc
	ON pc.ProductId = pr.Id
	LEFT JOIN Categories ct
	ON pc.CategoryId = ct.Id
