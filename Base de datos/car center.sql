create database prueba_car
go
use prueba_car
go
if OBJECT_ID('prueba_car..p_tipo_documento') is not null
drop table prueba_car..p_tipo_documento
go
create table  p_tipo_documento
(
Id_tipo_documento int primary key identity (0,1),
Nombre varchar(50) not null,
Activo bit
)
go 
insert into p_tipo_documento (nombre, Activo) values ('cedula', 1)
insert into p_tipo_documento (nombre, Activo) values ('nit', 1)
insert into p_tipo_documento (nombre, Activo) values ('pasaporte', 1)
go
if OBJECT_ID('prueba_car..n_persona') is not null
drop table prueba_car..n_persona
go
create table n_persona
(
Id_Persona int primary key identity(0,1),
Primer_nombre varchar(50) not null,
Segundo_nombre varchar(50) ,
Primer_apellido varchar(50) not null,
Segundo_apellido varchar(50) ,
Id_tipo_documento int not null,
Numero_documento bigint not null,
celular bigint not null,
direccion varchar (50) not null,
correo varchar (50) not null
)
go 
if OBJECT_ID('prueba_car..n_mecanico') is not null
drop table prueba_car..n_mecanico
go
create table n_mecanico
(
Id_mecanico int primary key identity(0,1),
Id_Persona int not null,
Activo bit
)
go 
if OBJECT_ID('prueba_car..n_factura') is not null
drop table prueba_car..n_factura
go
create table n_factura (
Id_Factura int primary key identity (0,1),
Id_Persona int not null,
Fecha_factura datetime not null,
Valor_factura decimal(18,2) not null,
Valor_iva decimal (18,2) not null,
Valor_total decimal (18,2) not null,
Placa_vehiculo varchar(10),
AplicaLimitePresupuesto bit,
Valor_limite_presupuesto decimal (18,2)
)
go 
if OBJECT_ID('prueba_car..n_mantenimiento') is not null
drop table prueba_car..n_mantenimiento
go
create table n_mantenimiento (
Id_mantenimiento int primary key identity (0,1),
Nombre_mantenimiento varchar(100) not null,
Descripcion varchar(max),
Id_Estado_mantenimiento int not null,
fecha_registro datetime,
Id_Factura int not null
)
go 
if OBJECT_ID('prueba_car..p_estado_mantenimiento') is not null
drop table prueba_car..p_estado_mantenimiento
go
create table p_estado_mantenimiento (
Id_Estado_mantenimiento int  primary key identity (0,1),
nombre varchar(100), 
activo bit 
)
go 
insert into p_estado_mantenimiento (nombre, activo) values ('terminado', 1)
insert into p_estado_mantenimiento (nombre, activo) values ('en proceso', 1)
insert into p_estado_mantenimiento (nombre, activo) values ('suspendido', 1)
insert into p_estado_mantenimiento (nombre, activo) values ('en planeacion', 1)
go
if OBJECT_ID('prueba_car..n_repuesto_mantenimiento') is not null
drop table prueba_car..n_repuesto_mantenimiento
go
create table n_repuesto_mantenimiento (
Id_Respuesto_mantenimiento int  primary key identity(0,1),
Id_mantenimiento int not null,
Id_Mecanico int not null,
Id_Respuesto int not null,
N_unidades int not null,
Valor_descuento decimal(18,2) not null,
Aplica_servicio_mano_obra bit, 
Id_Servicio_Mano int,
Vlr_mano_obra decimal(18,2)
)
go 
if OBJECT_ID('prueba_car..p_repuesto') is not null
drop table prueba_car..p_repuesto
go
create table p_repuesto
(
Id_repuesto int primary key identity(0,1),
Nombre varchar(50) not null,
Descripcion varchar(50) not null,
codigo int, 
Vlr_unitario decimal(18,2),
Cantidad_disponible int
)
go 
if OBJECT_ID('prueba_car..p_servicio_mano') is not null
drop table prueba_car..p_servicio_mano
go
create table p_servicio_mano(
Id_Servicio_Mano int primary key identity(0,1),
nombre varchar(50),
descripcion varchar (250),
Vlr_minimo decimal(18,2),
Vlr_maximo decimal(18,2),
)
go 
insert into p_servicio_mano values ('Revision inicial', 'ajuste', 1000, 2000) 
insert into p_servicio_mano values ('Ajuste de tuercas', 'ajuste', 1000, 2000) 
insert into p_servicio_mano values ('Cambio de aceite', 'ajuste', 1000, 2000) 
go 
alter table n_persona add
constraint fk_n_persona_tipo_documento
foreign key (Id_tipo_documento)
references p_tipo_documento(Id_tipo_documento)
go 
alter table n_mecanico add
constraint fk_n_persona_n_mecanico
foreign key (Id_Persona)
references n_persona(Id_Persona)
go 
alter table n_factura add
constraint fk_n_factura_n_persona
foreign key (Id_Persona)
references n_persona(Id_Persona)
go 
alter table n_repuesto_mantenimiento add
constraint fk_n_mantenimiento_n_repuesto_mantenimiento
foreign key (Id_mantenimiento)
references n_mantenimiento(Id_mantenimiento)
go 
alter table n_mantenimiento add
constraint fk_n_mantenimiento_n_factura
foreign key (Id_Factura)
references n_factura(Id_Factura)
go 
alter table n_repuesto_mantenimiento add
constraint fk_n_repuesto_mantenimiento_n_mecanico
foreign key (Id_Mecanico)
references n_mecanico(Id_Mecanico)
go 
alter table n_repuesto_mantenimiento add
constraint fk_n_repuesto_mantenimiento_p_repuesto
foreign key (Id_Respuesto)
references p_repuesto(Id_repuesto)
go 
alter table n_mantenimiento add
constraint fk_n_mantenimiento_p_estado_mantenimiento
foreign key (Id_Estado_mantenimiento)
references p_estado_mantenimiento(Id_Estado_mantenimiento)
go 
create procedure pa_tipo_documento_consultar
as begin 
select
*
from p_tipo_documento (nolock)
end 
go 
create procedure pa_persona_consultar
as begin 
select
*
from n_persona (nolock)
end 
go 
create procedure pa_mecanico_consultar
as begin 
select
a.Id_Persona
,Primer_nombre
,Segundo_nombre
,Primer_apellido
,Segundo_apellido
,Id_tipo_documento
,Numero_documento
,celular
,direccion
,correo
,b.activo
from n_persona a (nolock)
inner join n_mecanico b on a.Id_Persona = b.Id_mecanico
end 

go 
create procedure pa_factura_consultar
as begin 
select
*
from n_factura a (nolock)
end 
go 
create procedure pa_mantenimiento_consultar
@idfactura int 
as begin 
select
*
from n_mantenimiento a (nolock)
where Id_Factura = @idfactura
end 
go 
create procedure pa_estado_mantenimiento_consultar
as begin 
select
*
from p_estado_mantenimiento a (nolock)
end 
go 
create procedure pa_repuesto_consultar
as begin 
select
*
from p_repuesto a (nolock)
end 
go 
create procedure pa_servicio_mano_consultar
as begin 
select
*
from p_servicio_mano a (nolock)
end 
go 
create procedure pa_persona_insertar
@Primer_nombre varchar (50)
,@Segundo_nombre varchar (50)
,@Primer_apellido varchar (50)
,@Segundo_apellido varchar (50)
,@Id_tipo_documento int 
,@Numero_documento bigint 
,@celular bigint 
,@direccion varchar(50) 
,@correo varchar(50) 
,@Resultado INT = 0 OUTPUT
as begin 
insert into n_persona (Primer_nombre,Segundo_nombre,Primer_apellido,Segundo_apellido,Id_tipo_documento,Numero_documento,celular,direccion,correo) 
values (@Primer_nombre,@Segundo_nombre,@Primer_apellido,@Segundo_apellido,@Id_tipo_documento,@Numero_documento,@celular,@direccion,@correo)
SET @Resultado = @@IDENTITY
end 
go 
create procedure pa_mecanico_insertar
@Id_Persona int
,@Activo bit 
,@Resultado INT = 0 OUTPUT
as begin 
insert into n_mecanico (Id_Persona, Activo) values (@Id_Persona, @Activo)
SET @Resultado = @@IDENTITY
end 
go 
create procedure p_factura_insertar
@Id_Persona int 
,@Valor_factura decimal(18,2)
,@Valor_iva decimal(18,2)
,@Valor_total decimal(18,2)
,@Placa_vehiculo varchar (10)
,@AplicaLimitePresupuesto bit 
,@Valor_limite_presupuesto decimal(18,2)
,@Resultado INT = 0 OUTPUT
as begin 
insert into n_factura (Id_Persona,Fecha_factura,Valor_factura,Valor_iva,Valor_total,Placa_vehiculo,AplicaLimitePresupuesto,Valor_limite_presupuesto) 
values (@Id_Persona,getdate(),@Valor_factura,@Valor_iva,@Valor_total,@Placa_vehiculo,@AplicaLimitePresupuesto,@Valor_limite_presupuesto)
SET @Resultado = @@IDENTITY
end 
go 
create procedure pa_mantenimiento_insertar
@Nombre_mantenimiento varchar (50)
,@Descripcion varchar (50)
,@Id_Estado_mantenimiento int 
,@Id_Factura int 
,@Resultado INT = 0 OUTPUT
as begin 
insert into n_mantenimiento (Nombre_mantenimiento,Descripcion,Id_Estado_mantenimiento,fecha_registro,Id_Factura)
values (@Nombre_mantenimiento,@Descripcion,@Id_Estado_mantenimiento,GETDATE(),@Id_Factura) 
SET @Resultado = @@IDENTITY
end
go 
create procedure pa_repuesto_mantenimiento_insertar
@Id_mantenimiento int 
,@Id_Mecanico int 
,@Id_Respuesto int 
,@N_unidades int 
,@Valor_descuento decimal
,@Aplica_servicio_mano_obra bit
,@Id_Servicio_Mano int 
,@Vlr_mano_obra decimal 
,@Resultado INT = 0 OUTPUT
as begin 
insert into n_repuesto_mantenimiento (Id_mantenimiento,Id_Mecanico,Id_Respuesto,N_unidades,Valor_descuento,Aplica_servicio_mano_obra,Id_Servicio_Mano,Vlr_mano_obra)
values (@Id_mantenimiento,@Id_Mecanico,@Id_Respuesto,@N_unidades,@Valor_descuento,@Aplica_servicio_mano_obra,@Id_Servicio_Mano,@Vlr_mano_obra)
SET @Resultado = @@IDENTITY
end 

