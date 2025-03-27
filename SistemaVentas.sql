CREATE DATABASE SistemaVentas;
GO
USE SistemaVentas;
EXEC sp_rename 'Categoria', 'Categoria';
GO

-- Tabla de Clientes
CREATE TABLE Clientes (
    IdCliente INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100) NOT NULL,
    DNI VARCHAR(14) NOT NULL,
    Telefono VARCHAR(8) NOT NULL,
    Correo VARCHAR(100) NULL,
    Activo BIT NOT NULL,
    UsuarioRegistra INT NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    UsuarioActualiza INT NULL,
    FechaActualiza DATETIME NULL
);

INSERT INTO Clientes (Nombre, DNI, Telefono, Correo, Activo, UsuarioRegistra, FechaRegistro, UsuarioActualiza, FechaActualiza)
  VALUES ('Arles Gonzalez', '1234', '12345678', 'arlesgonzalez', 1, 1, GETDATE(), 0, GETDATE());

-- Tabla de Proveedores
CREATE TABLE Proveedores (
    IdProveedor INT PRIMARY KEY IDENTITY,
    Proveedor VARCHAR(100) NOT NULL,
    RUC VARCHAR(10) NOT NULL,
    Telefono VARCHAR(8) NOT NULL,
    Correo VARCHAR(100) NULL,
    Activo BIT NOT NULL,
    UsuarioRegistra INT NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    UsuarioActualiza INT NULL,
    FechaActualiza DATETIME NULL
);

-- Tabla de Categoría
CREATE TABLE Categorias (
    IdCategoria INT PRIMARY KEY IDENTITY,
    Categoria VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(100) NULL,
    Activo BIT NOT NULL,
    UsuarioRegistra INT NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    UsuarioActualiza INT NULL,
    FechaActualiza DATETIME NULL
);

-- Tabla de Empleados
CREATE TABLE Empleado (
    IdEmpleado INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    DNI VARCHAR(14) NOT NULL,
    Username VARCHAR(20) NOT NULL,
    Password VARBINARY(MAX) NOT NULL,
    Activo BIT NOT NULL
);

-- Tabla de Artículos
CREATE TABLE Articulos (
    IdArticulo INT PRIMARY KEY IDENTITY,
    Articulo VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(100) NULL,
    CodigoArticulo VARCHAR(20) NOT NULL,
    Categoria INT NOT NULL,
    Activo BIT NOT NULL,
    UsuarioRegistra INT NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    UsuarioActualiza INT NULL,
    FechaActualiza DATETIME NULL,
    FOREIGN KEY (Categoria) REFERENCES Categorias(IdCategoria)
);

-- Tabla de Ingresos
CREATE TABLE Ingreso (
    IdIngreso INT PRIMARY KEY IDENTITY,
    Empleado INT NOT NULL,
    Proveedor INT NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    Activo BIT NOT NULL,
    FOREIGN KEY (Empleado) REFERENCES Empleado(IdEmpleado),
    FOREIGN KEY (Proveedor) REFERENCES Proveedores(IdProveedor)
);

-- Tabla de DetalleIngreso
CREATE TABLE DetalleIngreso (
    IdDetalle INT PRIMARY KEY IDENTITY,
    Ingreso INT NOT NULL,
    Articulo INT NOT NULL,
    PrecioCosto DECIMAL(18,2) NOT NULL,
    Cantidad DECIMAL(18,2) NOT NULL,
    PrecioVenta DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (Ingreso) REFERENCES Ingreso(IdIngreso),
    FOREIGN KEY (Articulo) REFERENCES Articulos(IdArticulo)
);

-- Tabla de Inventario
CREATE TABLE Inventario (
    IdInventario INT PRIMARY KEY IDENTITY,
    Articulo INT NOT NULL,
    Ingreso INT NOT NULL,
    Cantidad DECIMAL(18,2) NOT NULL,
    PrecioVenta DECIMAL(18,2) NULL,
    FOREIGN KEY (Ingreso) REFERENCES Ingreso(IdIngreso),
    FOREIGN KEY (Articulo) REFERENCES Articulos(IdArticulo)
);

-- Tabla de Ventas
CREATE TABLE Venta (
    IdVenta INT PRIMARY KEY IDENTITY,
    Empleado INT NOT NULL,
    Cliente INT NOT NULL,
    SubTotal DECIMAL(18,2) NOT NULL,
    IVA DECIMAL(18,2) NOT NULL,
    Total DECIMAL(18,2) NOT NULL,
    Fecha DATETIME NOT NULL,
    FOREIGN KEY (Empleado) REFERENCES Empleado(IdEmpleado),
    FOREIGN KEY (Cliente) REFERENCES Clientes(IdCliente)
);

-- Tabla de DetalleVenta
CREATE TABLE DetalleVenta (
    IdDetalleVenta INT PRIMARY KEY IDENTITY,
    Articulo INT NOT NULL,
    Venta INT NOT NULL,
    Ingreso INT NOT NULL,
    PrecioVenta DECIMAL(18,2) NOT NULL,
    Cantidad DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (Venta) REFERENCES Venta(IdVenta),
    FOREIGN KEY (Articulo) REFERENCES Articulos(IdArticulo),
    FOREIGN KEY (Ingreso) REFERENCES Ingreso(IdIngreso)
);

-- Tabla de Movimientos de Inventario
CREATE TABLE MovimientoInventario (
    IdMovimiento INT PRIMARY KEY IDENTITY,
    Ingreso INT NOT NULL,
    Articulo INT NOT NULL,
    CantidadSalida DECIMAL(18,2) NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (Ingreso) REFERENCES Ingreso(IdIngreso),
    FOREIGN KEY (Articulo) REFERENCES Articulos(IdArticulo)
);
