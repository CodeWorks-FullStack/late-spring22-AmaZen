CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS warehouses(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  name VARCHAR(255) NOT NULL COMMENT  'Simple Name',
  location TEXT NOT NULL COMMENT 'Physical Address'
)default charset utf8;

CREATE TABLE IF NOT EXISTS products(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  name VARCHAR(255) NOT NULL COMMENT  'Simple Name',
  description TEXT,
  category ENUM('book', 'equipment', 'food')
)default charset utf8;

CREATE TABLE IF NOT EXISTS warehouseproducts(
  id INT NOT NULL AUTO_INCREMENT primary key,
  quantity INT NOT NULL,
  productId INT NOT NULl,
  warehouseId INT NOT NULL,

  FOREIGN KEY (productId)
    REFERENCES products(id)
    ON DELETE CASCADE,

  FOREIGN KEY (warehouseId)
    REFERENCES warehouses(id)
    ON DELETE CASCADE
)default charset utf8;