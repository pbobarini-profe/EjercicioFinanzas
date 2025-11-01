Este trabajo es para evaluar la aplicacion correcta de los contenidos vistos sobre arquitectura de 3 capas en una aplicacion Windows Form. Las temáticas fueron sugeridas por los alumnos.  
A tener en cuenta:  
1-No vamos a usar Entity Framework, por lo que les pido que me envien los comandos para sql server de los create de las tablas. Por defecto si son varchar comunes (no esta comentado en la clase varchar max) los varchar seran de 120 caracteres.  
2-Debe funcionar completo el CRUD - SOLO DEBEN TOCAR LOS ARCHIVOS DE LAS CLASES QUE LES FUERON DADAS - NO TOCAR ARCHIVO DE LOS OTROS.  
3-Como implica que varios alumnos van a necesitar funciones y metodos de otras clases que le corresponde a otro compañero, vamos a simplificar y van a poder hacer JOIN y crear los objetos que necesite el modelo elegido. Esto, si bien no es lo optimo, en terminos prácticos va a simplificar los posibles conflictos en la cooperacion.  
4-Deben presentar un reporte en RDLC. Los dejo a criterio de ustedes. Ese tema lo vamos a ver la clase del 01/11.  
5-Cada alumno debe pasarme su link de cuenta de github para que yo lo agregue como colaborador.  
6-Tema manejo de ramas que no pudimos ver en clase. Antes de comenzar a editar deben crear una rama haciendo click en donde dice master en la esquina inferior derecha del visual studio. Ahi les saldra estas opciones:  
<img width="625" height="436" alt="image" src="https://github.com/user-attachments/assets/ca2281f5-bc50-45e2-8b81-d1a298d7e701" />
Ponen nueva rama y le colocan su nombre.  
Siempre que esten desarrollando asegurense tener su rama seleccionada. Cualquier duda la vemos en clase  
//
--create de las tablas

-- Tabla: TiposAsientos
CREATE TABLE dbo.TiposAsientos (
    id            INT IDENTITY(1,1) NOT NULL,
    descripcion   NVARCHAR(200)     NOT NULL,
    CONSTRAINT PK_TiposAsientos PRIMARY KEY CLUSTERED (id)
);
GO

-- Tabla: TipoComprobantes
CREATE TABLE dbo.TipoComprobantes (
    id            INT IDENTITY(1,1) NOT NULL,
    descripcion   NVARCHAR(200)     NOT NULL,
    CONSTRAINT PK_TipoComprobantes PRIMARY KEY CLUSTERED (id)
);
GO

-- Tabla: Rubros
-- tipoRubro: 1-Activo | 2-Pasivo | 3-Patrimonio Neto | 4-Ingresos | 5-Egresos
CREATE TABLE dbo.Rubros (
    id            INT IDENTITY(1,1) NOT NULL,
    descripcion   NVARCHAR(200)     NOT NULL,
    tipoRubro     INT               NOT NULL,
    CONSTRAINT PK_Rubros PRIMARY KEY CLUSTERED (id),
    CONSTRAINT CK_Rubros_Tipo CHECK (tipoRubro IN (1,2,3,4,5))
);
GO

-- Tabla: Cuentas
CREATE TABLE dbo.Cuentas (
    id          INT IDENTITY(1,1) NOT NULL,
    descripcion NVARCHAR(200)     NOT NULL,
    rubroId     INT               NOT NULL,
    CONSTRAINT PK_Cuentas PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_Cuentas_Rubros
        FOREIGN KEY (rubroId) REFERENCES dbo.Rubros(id)
);
GO

-- Tabla: Comprobantes
CREATE TABLE dbo.Comprobantes (
    id                 INT IDENTITY(1,1) NOT NULL,
    descripcion        NVARCHAR(200)     NOT NULL,
    numero             NVARCHAR(50)      NOT NULL,
    monto              DECIMAL(18,2)     NOT NULL,
    fecha              DATETIME2(7)      NOT NULL,
    tipoComprobanteId  INT               NOT NULL,
    CONSTRAINT PK_Comprobantes PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_Comprobantes_TipoComprobantes
        FOREIGN KEY (tipoComprobanteId) REFERENCES dbo.TipoComprobantes(id)
);
GO

-- Tabla: Asientos
-- descripcion: NVARCHAR(MAX) según comentario del modelo
CREATE TABLE dbo.Asientos (
    id            INT IDENTITY(1,1) NOT NULL,
    fecha         DATETIME2(7)      NOT NULL,
    descripcion   NVARCHAR(MAX)     NOT NULL,
    tipoAsientoId INT               NOT NULL,
    CONSTRAINT PK_Asientos PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_Asientos_TiposAsientos
        FOREIGN KEY (tipoAsientoId) REFERENCES dbo.TiposAsientos(id)
);
GO

-- Tabla: Movimientos
-- debeHaber: 1-Debe | 2-Haber
CREATE TABLE dbo.Movimientos (
    id            INT IDENTITY(1,1) NOT NULL,
    cuentaId      INT               NOT NULL,
    comprobanteId INT               NOT NULL,
    debeHaber     INT               NOT NULL,
    monto         DECIMAL(18,2)     NOT NULL,
    CONSTRAINT PK_Movimientos PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_Movimientos_Cuentas
        FOREIGN KEY (cuentaId) REFERENCES dbo.Cuentas(id),
    CONSTRAINT FK_Movimientos_Comprobantes
        FOREIGN KEY (comprobanteId) REFERENCES dbo.Comprobantes(id),
    CONSTRAINT CK_Movimientos_DebeHaber CHECK (debeHaber IN (1,2))
);
GO

-- Tabla: MovimientosAsientos
CREATE TABLE dbo.MovimientosAsientos (
    id           INT IDENTITY(1,1) NOT NULL,
    movimientoId INT               NOT NULL,
    asientoId    INT               NOT NULL,
    CONSTRAINT PK_MovimientosAsientos PRIMARY KEY CLUSTERED (id),
    CONSTRAINT FK_MovAsi_Movimientos
        FOREIGN KEY (movimientoId) REFERENCES dbo.Movimientos(id),
    CONSTRAINT FK_MovAsi_Asientos
        FOREIGN KEY (asientoId) REFERENCES dbo.Asientos(id)
);
GO
