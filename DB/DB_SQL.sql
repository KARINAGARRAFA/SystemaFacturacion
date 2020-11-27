select *from gen_vendors
select * from gen_companies
select * from gen_company_users
select * from gen_company_customers
select * from gen_employees
select * from cont_purchases
select *from cont_sales


CREATE TABLE sfe_users (
  ruc varchar(11) primary key NOT NULL,
  business_name VARCHAR(1000) NULL,
  brand varchar(255) NULL,
  cod_sector varchar(20) NULL,
  address varchar(255) NULL,
  email char(255) NULL,
  telephone varchar(11) NULL,
  status varchar(50) NULL,
  condition varchar(50) NULL,
  created_at date NULL,
  updated_at date NULL
)

INSERT INTO sfe_users VALUES ('10012924262', 'LIPA RAMOS ANGELUZZI','','comercio','','','','','', '2020-09-20', '2020-09-20')


CREATE TABLE sfe_product(
   code_product varchar(50) primary key NOT NULL,
   product_name varchar (1000) NULL,
   code_trademark varchar (10) NULL,
   code_category varchar (10) NULL,
   description varchar(1000) NULL,
   created_at datetime NULL,
	updated_at datetime NULL,
)
CREATE TABLE sfe_trademark(
	code_trademark varchar(10) primary key NOT NULL,
	trademark_name varchar (255) NULL,
	description varchar (1000) NULL,
	created_at datetime NULL,
	updated_at datetime NULL,
)
select * from sfe_trademark

CREATE TABLE sfe_category(
	code_category varchar(10) primary key NOT NULL,
	category_name varchar (255) NULL,
	description varchar (1000) NULL,
	created_at datetime NULL,
	updated_at datetime NULL,
)
select * from sfe_category


CREATE TABLE sfe_model(
	code_model varchar(10) primary key NOT NULL,
	model_name varchar (255) NULL,
	description varchar (1000) NULL,
	created_at datetime NULL,
	updated_at datetime NULL,
)
select * from sfe_model

CREATE TABLE sfe_unit_measurement(
	code_unit varchar(10) primary key NOT NULL,
	unit_name varchar (255) NULL,
	description varchar (1000) NULL,
	created_at datetime NULL,
	updated_at datetime NULL,
)
select * from sfe_unit_measurement
CREATE TABLE sfe_purchages(
	code_purchages varchar(100) primary key NOT NULL,
	numero int NULL,
	fecha_emision date NULL,
	fecha_pago date NULL,
	cdp_tipo char(2) NULL,
	cdp_serie varchar(4) NULL,
	cdp_numero int NULL,
	proveedor_tipo varchar(1) NULL,
	proveedor_numero char(11) NULL,
	base_imponible decimal(18, 2) NULL,
	igv decimal(18, 2) NULL,
	no_gravada decimal(18, 2) NULL,
	descuento decimal(18, 2) NULL,
	importe_total decimal(18, 2) NULL,
	dolares decimal(18, 2) NULL,
	tipo_cambio decimal(4, 3) NULL,
	percepcion decimal(18, 2) NULL,
	detraccion_id int NULL,
	constancia_detraccion_numero varchar(50) NULL,
	constancia_detraccion_fecha_pago date NULL,
	constancia_detraccion_monto decimal(18, 2) NULL,
	monto_referencial decimal(18, 2) NULL,
	nota_credito_referencia_fecha date NULL,
	nota_credito_referencia_tipo varchar(2) NULL,
	nota_credito_referencia_serie varchar(4) NULL,
	nota_credito_referencia_numero varchar(50) NULL,
	observacion varchar(1000) NULL,
	created_at datetime NULL,
	updated_at datetime NULL,
	company_ruc char(11) NULL,
)
CREATE TABLE sfe_purchages_detail(
    code varchar(100) primary key NOT NULL,
	code_purchages varchar(100) NOT NULL,
	code_product varchar(10),
	cantidad int NULL,
	precio int NULL,
	code_unit varchar(10) NULL,
	base_imponible decimal(18, 2) NULL,
	igv decimal(18, 2) NULL,
	created_at datetime NULL,
	updated_at datetime NULL,
)
select * from sfe_purchages_detail
CREATE TABLE sfe_sales(
	code varchar(100) primary key NOT NULL,
	numero int NULL,
	fecha_emision datetime NULL,
	fecha_pago datetime NULL,
	cdp_tipo varchar(2) NULL,
	cdp_serie varchar(4) NULL,
	cdp_numero int NULL,
	proveedor_tipo varchar(1) NULL,
	proveedor_numero varchar(11) NULL,
	valor_exportacion decimal(18, 2) NULL,
	base_imponible decimal(18, 2) NULL,
	importe_total_exonerada decimal(18, 2) NULL,
	importe_total_inafecta decimal(18, 2) NULL,
	igv decimal(18, 2) NULL,
	importe_total decimal(18, 2) NULL,
	dolares decimal(18, 2) NULL,
	tipo_cambio decimal(4, 3) NULL,
	igv_retencion decimal(18, 2) NULL,
	detraccion_id int NULL,
	constancia_detraccion_numero varchar(50) NULL,
	constancia_detraccion_fecha_pago date NULL,
	constancia_detraccion_monto decimal(18, 2) NULL,
	constancia_detraccion_referencia_monto decimal(18, 2) NULL,
	observacion varchar(1000) NULL,
	created_at datetime NULL,
	updated_at datetime NULL,
	company_ruc char(11) NULL,
)

CREATE TABLE sfe_sales_detail(
    code Int Identity primary key NOT NULL,
	code_sales varchar(100) NOT NULL,
	code_product varchar(10),
	cantidad int NULL,
	precio int NULL,
	code_unit varchar(10) NULL,
	base_imponible decimal(18, 2) NULL,
	igv decimal(18, 2) NULL,
	created_at datetime NULL,
	updated_at datetime NULL,
)

select * from sfe_sales_detail

Create Proc GenerarIdDetalleVentas
@ruc varchar(11),
@Cdp_tipo varchar(2),
@Cdp_serie varchar(4),
@Cdp_numero int,
@CodeVenta varchar(100) Out
As Begin
	Set @CodeVenta=CONCAT(@ruc,'-',@Cdp_tipo,'-',@Cdp_serie,'-',@Cdp_numero)
	If(Exists(Select code From sfe_sales where code=@CodeVenta))
		Set @CodeVenta=CONCAT(@ruc,'-',@Cdp_tipo,'-',@Cdp_serie,'-',(@Cdp_numero+1))
	End
Go

Create Table sfe_user_login(
	code_user_login varchar(100) Primary Key,
	ruc_user varchar(11) Not Null ,
	usuario Varchar(20) Not Null,
	password Varchar(20) Not Null
)
Go

create table sfe_company_users
(
	username varchar (50) primary key,
	password varchar (255) not null,
	state varchar(10) null,
	ruc_company varchar(50) not null,
	created_at datetime NULL,
	updated_at datetime NULL,
)


DROP TABLE sfe_company_users
Create Table sfe_voucher_type(
	id varchar(100) Primary Key,
	nombre varchar(11) Not Null ,
	created_at datetime NULL,
	updated_at datetime NULL
)
Go

Create Table sfe_consecutive_number(
	id varchar(100) Primary Key,
	ruc varchar(11) Not Null ,
	serie varchar(10) Not Null ,
	numero int Not Null ,
	created_at datetime NULL,
	updated_at datetime NULL
)
Go






INSERT INTO sfe_consecutive_number VALUES ('01','20605971343','B001',0,'2020-11-12 00:00:00.000','2020-11-12 00:00:00.000')
INSERT INTO sfe_consecutive_number VALUES ('02','20605971343','F001',0,'2020-11-12 00:00:00.000','2020-11-12 00:00:00.000')

select * from sfe_consecutive_number

INSERT INTO sfe_user_login VALUES ('8545','10012924262','admin', '123')
select * from sfe_user_login
select * from sfe_users
Select E.business_name  From sfe_users E Inner Join sfe_user_login U On E.ruc=U.ruc_user Where U.Usuario='admin'
select * from sfe_product
select * from sfe_voucher_type


select * from sfe_voucher_type
INSERT INTO sfe_voucher_type VALUES ('01','FACTURA','2020-11-12 00:00:00.000','2020-11-12 00:00:00.000')
INSERT INTO sfe_voucher_type VALUES ('03','BOLETA','2020-11-12 00:00:00.000','2020-11-12 00:00:00.000')

DROP TABLE sfe_product


DELETE FROM sfe_sales_detail
DELETE FROM sfe_sales
INSERT INTO sfe_model VALUES ('8545','samsung','----', '2020-11-12 00:00:00.000','2020-11-12 00:00:00.000')

select * from sfe_trademark
select * from sfe_model
select * from gen_vendors
INSERT INTO sfe_trademark VALUES ('8545','samsung','----', '2020-11-12 00:00:00.000','2020-11-12 00:00:00.000')

DELETE FROM sfe_voucher_type
