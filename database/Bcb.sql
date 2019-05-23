
# 新增飲料店資料表
CREATE TABLE BeverageStore (  
	shopName varchar(50) NOT NULL primary key,  # 店名
	shopTotal INT # 店數
);

# 插入資料
INSERT INTO BeverageStore (shopName, shopTotal)
  VALUES ("COMEBUY", 93)
		,("清心福全", 179)
        ,("叮哥茶飲", 1)
        ,("50嵐", 147)
        ,("迷客夏milkshop", 60)
        ,("一芳水果茶", 75)
        ,("茶湯會", 54)
        ,("大苑子", 37);
        
# 新增推薦飲料資料表
CREATE TABLE RecommendedDrink (  
	RecommendedDrinkId int not null auto_increment PRIMARY KEY,
	shopName varchar(50),  # 店名
	Drink varchar(50),  # 飲料
	DrinkPrice INT,  # 飲料價格
	FOREIGN KEY (shopName) REFERENCES BeverageStore(shopName) on delete cascade on update cascade # 外來索引
);

# 插入資料
INSERT INTO RecommendedDrink (shopName,Drink, DrinkPrice)
  VALUES ("COMEBUY","碧螺春", 40)
		,("清心福全","多多綠茶", 45)
		,("叮哥茶飲","洛神花茶", 40)
        ,("50嵐","四季春+珍波椰(1號)", 40)
        ,("迷客夏milkshop","珍珠大正紅茶拿鐵", 65)
        ,("一芳水果茶","水果茶", 60)
        ,("茶湯會","觀音拿鐵", 59)
		,("大苑子","鳳梨冰茶", 55);

# 新增茶類資料表
CREATE TABLE Tea (
	TeaId int not null auto_increment PRIMARY KEY,
	shopName varchar(50),  # 店名
	Variety varchar(50),  # 品種
	VarietyPrice INT,  # 品種價格
	FOREIGN KEY (shopName) REFERENCES BeverageStore(shopName) on delete cascade on update cascade # 外來索引
);

# 插入資料
INSERT INTO Tea (shopName, Variety, VarietyPrice)
  VALUES ("COMEBUY","碧螺春茶葉", 300)
		,("清心福全","特級綠茶茶葉", 350)
		,("叮哥茶飲","洛神花", 50)
		,("50嵐","四季春", 250)
		,("迷客夏milkshop","紅茶", 100)
		,("一芳水果茶","青茶", 220)
		,("茶湯會","鐵觀音青茶", 187)
		,("大苑子","鐵觀音青茶", 187);


# 新增客群資料表
CREATE TABLE UserGroup (  
	UserGroupId int not null auto_increment PRIMARY KEY,
	shopName varchar(50),  # 店名
	UGroup varchar(50),  # 客群
	AverageAge INT,  # 平均年齡
	FOREIGN KEY (shopName) REFERENCES BeverageStore(shopName) on delete cascade on update cascade # 外來索引
);

# 插入資料
INSERT INTO UserGroup (shopName, UGroup, AverageAge)
  VALUES ("COMEBUY","青少年", 18)
		,("清心福全","青少年", 18)
		,("叮哥茶飲","青少年", 18)
		,("50嵐","青少年", 18)
		,("迷客夏milkshop","青少年", 18)
		,("一芳水果茶","中年", 35)
		,("茶湯會","中年", 35)
		,("大苑子","青少年", 18);
        
delimiter |
create trigger `Crt_shopName_Trg`
after insert on `BeverageStore`
for each row
begin
	insert into `RecommendedDrink`(`shopName`) Values (new.`shopName`);
    insert into `Tea`(`shopName`) Values (new.`shopName`);
    insert into `UserGroup`(`shopName`) Values (new.`shopName`);
end |
delimiter ;
  
