CREATE DATABASE cr_mercantil;

USE DATABASE cr_mercantil;


-- TABLAS FUERTES --
CREATE TABLE Proyecto (
    matricula_inmobiliaria INT PRIMARY KEY NOT NULL;
    nombre_proyecto VARCHAR(30) NOT NULL;
    direccion_proyecto VARCHAR(30) NOT NULL;
    estrato_proyecto INT NOT NULL;
    escritura_reglamento_proyecto VARCHAR(30) NOT NULL;
    administrador_proyecto VARCHAR(40) NOT NULL;
    telefono_administrador_proyecto VARCHAR(10) NOT NULL;
    correo_administrador_proyecto VARCHAR(30) NULL;
)

CREATE TABLE Pagos (
    rc_pagos INT PRIMARY KEY NOT NULL AUTO_INCREMENT;
    factura_pagos INT NOT NULL;
    fecha_pagos DATE NOT NULL;
    fecha_abono_canon_pagos DATE NOT NULL;
    abono_administracion_pagos DOUBLE NOT NULL;
    interes_pagos DOUBLE NOT NULL;
    tasa_interes_pagos DOUBLE NOT NULL;
)

CREATE TABLE Arrendatario (
    cedula_arrendatario INT PRIMARY KEY NOT NULL;
    nombre_arrendatario VARCHAR(20) NOT NULL;
    apellido_arrendatario VARCHAR(20) NOT NULL;
    telefono_arrendatario INT NOT NULL;
    corrreo_arrendatario VARCHAR(20) NULL;
)

CREATE TABLE ArregloLocativo (
    id_locativa_arreglo INT PRIMARY KEY NOT NULL;
    fecha_inicio_arreglo DATE NOT NULL;
    fecha_finalizacion_arreglo DATE NOT NULL;
    estado_arreglo BOOLEAN NOT NULL;
    observaciones_arreglo TEXT NOT NULL;
)

CREATE TABLE Propietario (
    cedula_propietario INT PRIMARY KEY NOT NULL;
    nombre_propietario VARCHAR(20) NOT NULL;
    apellido_propietario VARCHAR(20) NOT NULL;
    telefono_propietario INT NOT NULL;
    corrreo_propietario VARCHAR(20) NULL;
    cuenta_bancaria_propietario int NOT NULL;
    tipo_cuenta_propietario VARCHAR(9);
    nombre_banco_propietario VARCHAR(30);
)

-- TABLAS DEBILES --