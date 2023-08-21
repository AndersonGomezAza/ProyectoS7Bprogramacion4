CREATE DATABASE cr_mercantil;

USE DATABASE cr_mercantil;


-- TABLAS FUERTES --
CREATE TABLE Proyecto (
    matricula_inmobiliaria_proyecto INT PRIMARY KEY NOT NULL;
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
    correo_arrendatario VARCHAR(20) NULL;
)

CREATE TABLE ArregloLocativo (
    id_locativa_arreglo INT PRIMARY KEY NOT NULL;
    fecha_inicio_arreglo DATE NOT NULL;
    fecha_finalizacion_arreglo DATE NULL;
    estado_arreglo BOOLEAN NOT NULL;
    observaciones_arreglo TEXT NOT NULL;
)

CREATE TABLE Propietario (
    cedula_propietario INT PRIMARY KEY NOT NULL;
    nombre_propietario VARCHAR(20) NOT NULL;
    apellido_propietario VARCHAR(20) NOT NULL;
    telefono_propietario INT NOT NULL;
    correo_propietario VARCHAR(20) NULL;
    cuenta_bancaria_propietario int NOT NULL;
    tipo_cuenta_propietario VARCHAR(9);
    nombre_banco_propietario VARCHAR(30);
)

-- TABLAS DEBILES --
CREATE TABLE ContratoArriendo (
    id_contrato INT PRIMARY KEY NOT NULL;
    fecha_inicio_contrato DATE NOT NULL;
    valor_canon_contrato DOUBLE NOT NULL;
    valor_administracion_contrato DOUBLE NOT NULL;
    rc_pagos_contrato INT NOT NULL;
    cedula_arrendatario_contrato INT NOT NULL;
)

CREATE TABLE Inmueble (
   matricula_inmobiliaria_inmueble PRIMARY KEY VARCHAR(13) NOT NULL;
   chip_inmueble VARCHAR(11) NOT NULL;
   tipo_inmueble VARCHAR(11) NOT NULL;
   nomenclarura_inmueble VARCHAR(10) NOT NULL;
   area_privada_inmueble DOUBLE NOT NULL;
   area_construida_inmueble DOUBLE NOT NULL;
   numero_escritura_inmueble  VARCHAR(20) NOT NULL;
   alcobas_inmueble INT NOT NULL;
   baños_inmueble INT NOT NULL;
   vehiculo_inmueble INT NOT NULL;
   id_locativa_inmueble INT NOT NULL;
   cedula_propietario_inmueble INT NOT NULL;
   matricula_inmobiliaria_proyecto_inmueble INT NOT NULL;
)

-- TABLAS DE TRANSICION --
CREATE TABLE ContratoInmueble (
    id_contrato INT NOT NULL;
    matricula_inmobiliaria_inmueble VARCHAR(13) NOT NULL;
)

-- CREACION DE CONSTRAINS O RESTRICCIONES
  -- LLAVES FORANEAS TABLAS DEBILES
	ALTER TABLE ContratoArriendo ADD CONSTRAIN pk_contrato_arrendatario FOREIGN KEY (cedula_arrendatario_contrato) REFERENCES Arrendatario (cedula_arrendatario);
	ALTER TABLE ContratoArriendo ADD CONSTRAIN pk_contrato_pagos FOREIGN KEY (rc_pagos_contrato) REFERENCES Pagos (rc_pagos);
	ALTER TABLE Inmueble ADD CONSTRAIN pk_inmueble_arreglo FOREIGN KEY (id_locativa_inmueble) REFERENCES ArregloLocativo (id_locativa_arreglo);
	ALTER TABLE Inmueble ADD CONSTRAIN pk_inmueble_propietario FOREIGN KEY (cedula_propietario_inmueble) REFERENCES Propietario (cedula_propietario);
	ALTER TABLE Inmueble ADD CONSTRAIN pk_inmueble_proyecto FOREIGN KEY (matricula_inmobiliaria_proyecto_inmueble) REFERENCES Proyecto (matricula_inmobiliaria_proyecto);
  
	-- LLAVES FORANEAS TABLAS TRANSICION
	ALTER TABLE ContratoInmueble ADD CONSTRAIN pk_contrato_inmueble_contrato_arriendo FOREIGN KEY (id_contrato) REFERENCES ContratoArriendo (id_contrato);
	ALTER TABLE ContratoInmueble ADD CONSTRAIN pk_contrato_inmueble_inmueble FOREIGN KEY (matricula_inmobiliaria_inmueble) REFERENCES Inmueble (matricula_inmobiliaria_inmueble);
	
	-- OTROS CONSTRAINS
	ALTER TABLE Proyecto ADD CONSTRAINT UQ_correo_administrador_proyecto UNIQUE (correo_administrador_proyecto);
	ALTER TABLE Arrendatario ADD CONSTRAINT UQ_correo_arrendatario UNIQUE (correo_arrendatario);
	ALTER TABLE Propietario ADD CONSTRAINT UQ_correo_propietario UNIQUE (correo_propietario);
	ALTER TABLE Propietario ADD CONSTRAINT CH_tipo_cuenta_propietario CHECK (tipo_cuenta_propietario IN ('AHORROS', 'CORRIENTE'));
	ALTER TABLE Inmueble ADD CONSTRAINT CH_tipo_inmueble CHECK (tipo_inmueble IN ('APARTAMENTO', 'GARAJE', 'BODEGA'));
    
	
	
	