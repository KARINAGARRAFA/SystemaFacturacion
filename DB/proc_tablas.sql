
BEGIN  -- TABLA CATEGORIA PROC sfe_category
	Create Proc RegistrarCategoria
		@Code_category varchar(10),
		@Category_name varchar (255),
		@description varchar(1000),
		@created_at datetime,
		@updated_at datetime,
		@Mensaje varchar(50) Out
	As Begin
		If(Exists(Select * From sfe_category Where category_name=@Category_name And code_category=@Code_category))
			Set @Mensaje='Esta categoria ya ha sido Registrado.'
		Else Begin
			Insert sfe_category Values(@Code_category,@Category_name,@description,@created_at,@updated_at)
			Set @Mensaje='Registrado Correctamente.'
		End
	End
	

	Create Proc EliminarCategoria
		@Code_category varchar(10),
		@Mensaje varchar(50) Out
	As Begin
		DELETE FROM sfe_category WHERE code_category=@Code_category
		set @Mensaje='categoria eliminada.'
	End


	CREATE Proc ActualizarCategoria
		@Code_category varchar(10),
		@Category_name varchar (255),
		@Description varchar (1000),
		@Updated_at datetime,
		@Mensaje varchar(50) Out
	As Begin
		If(Not Exists(Select * From sfe_category Where code_category=@Code_category))
			Set @Mensaje='Categoria no se encuentra Registrado.'
		Else Begin
			Update sfe_category Set category_name=@Category_name,description=@description,updated_at=@updated_at
			Where code_category=@Code_category
		Set @Mensaje='Registro Actualizado Correctamente.'
		End
	End


	Create Proc ListarCategoria
	As Begin
		Select * From sfe_category
	End


	Create Proc BuscarCategoria
	@Datos Varchar(80)
	As Begin
		Select code_category,category_name,description
		From sfe_category Where code_category like '%'+@Datos+'%' or category_name like '%'+@Datos+'%'
	End
END
GO

BEGIN  -- CLIENTE PROC gen_vendors
-------------
Create Proc RegistrarCliente
	@Ruc_client varchar(11),
	@Business_name varchar (1000),
	@Brand varchar(255),
	@Address varchar(255),
	@Email varchar(255),
	@Telephone varchar(11),
	@Status varchar(50),
	@Condition varchar(50),
	@created_at datetime,
	@updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Exists(Select * From gen_vendors Where business_name=@Business_name And ruc=@Ruc_client))
		Set @Mensaje='Este Cliente ya ha sido Registrado.'
	Else Begin
		Insert gen_vendors Values(@Ruc_client,@Business_name,@Brand,@Address,@Email,@Telephone,@Status,@Condition,@created_at,@updated_at)
		Set @Mensaje='Registrado Correctamente.'
	End
End
-----------

Create Proc EliminarCliente
	@Ruc_client varchar(11),
	@Mensaje varchar(50) Out
As Begin
	DELETE FROM gen_vendors WHERE ruc=@Ruc_client
	set @Mensaje='Cliente eliminado.'
End
------------------
CREATE Proc ActualizarCliente
	@Ruc_client varchar(11),
	@Business_name varchar (1000),
	@Brand varchar(255),
	@Address varchar(255),
	@Email varchar(255),
	@Telephone varchar(11),
	@Status varchar(50),
	@Condition varchar(50),
	@Updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Not Exists(Select * From gen_vendors Where ruc=@Ruc_client))
		Set @Mensaje='Cliente no se encuentra Registrado.'
	Else Begin
		Update gen_vendors Set business_name=@Business_name,brand=@Brand,address = @Address,email= @Email,telephone=@Telephone,status= @Status,condition=@Condition,updated_at=@updated_at
		Where ruc=@Ruc_client
	Set @Mensaje='Registro Actualizado Correctamente.'
	End
End
--------------------
Create Proc FiltrarDatosCliente
@Datos Varchar(80)
As Begin
	Select ruc,business_name,brand,address,email,telephone,status,condition 
	From gen_vendors Where ruc like '%'+@Datos+'%' or business_name like '%'+@Datos+'%'
End
--------------
CREATE Proc ActualizarDireccoinCliente
	@Ruc_client varchar(11),
	@Address varchar(255),
	@Updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Not Exists(Select * From gen_vendors Where ruc=@Ruc_client))
		Set @Mensaje='Cliente no se encuentra Registrado.'
	Else Begin
		Update gen_vendors Set address = @Address,updated_at=@updated_at
		Where ruc=@Ruc_client
	Set @Mensaje='Registro Actualizado Correctamente.'
	End
End
---------------
Create Proc ListarCliente
As Begin
	Select * From gen_vendors
End
END

GO

BEGIN  -- MARCA PROC sfe_trademark

Create Proc RegistrarMarca
	@Code_trademark varchar(10),
	@Trademark_name varchar (255),
	@description varchar(1000),
	@created_at datetime,
	@updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Exists(Select * From sfe_trademark Where trademark_name=@Trademark_name And code_trademark=@Code_trademark))
		Set @Mensaje='Esta Marca ya ha sido Registrado.'
	Else Begin
		Insert sfe_trademark Values(@Code_trademark,@Trademark_name,@description,@created_at,@updated_at)
		Set @Mensaje='Registrado Correctamente.'
	End
End
-------------------
Create Proc EliminarMarca
	@Code_trademark varchar(10),
	@Mensaje varchar(50) Out
As Begin
	DELETE FROM sfe_trademark WHERE code_trademark=@Code_trademark
	set @Mensaje='Marca eliminada.'
End
-------------------
Create Proc ActualizarMarca
	@Code_trademark varchar(10),
	@Trademark_name varchar (1000),
	@Description varchar (10),
	@Updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Not Exists(Select * From sfe_trademark Where code_trademark=@Code_trademark))
		Set @Mensaje='Marca no se encuentra Registrado.'
	Else Begin
		Update sfe_trademark Set trademark_name=@Trademark_name,description=@description,updated_at=@updated_at
		Where code_trademark=@Code_trademark
	Set @Mensaje='Registro Actualizado Correctamente.'
	End
End
------------------
Create Proc ListarMarca
As Begin
	Select * From sfe_trademark
End
---------------------
Create Proc BuscarMarca
@Datos Varchar(80)
As Begin
	Select code_trademark,trademark_name,description
	From sfe_trademark Where code_trademark like '%'+@Datos+'%' or trademark_name like '%'+@Datos+'%'
End
----------------
END
GO

BEGIN  -- MODELO PROC sfe_model

Create Proc RegistrarModelo
	@Code_model varchar(10),
	@Model_name varchar (255),
	@description varchar(1000),
	@created_at datetime,
	@updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Exists(Select * From sfe_model Where Model_name=@Model_name And code_model=@Code_model))
		Set @Mensaje='Este Modelo ya ha sido Registrado.'
	Else Begin
		Insert sfe_model Values(@Code_model,@Model_name,@description,@created_at,@updated_at)
		Set @Mensaje='Registrado Correctamente.'
	End
End
--------------------
Create Proc EliminarModelo
	@Code_model varchar(10),
	@Mensaje varchar(50) Out
As Begin
	DELETE FROM sfe_model WHERE code_model=@Code_model
	set @Mensaje='Marca eliminada.'
End
--------------------
CREATE Proc ActualizarModelo
	@Code_model varchar(10),
	@Model_name varchar (255),
	@Description varchar (1000),
	@Updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Not Exists(Select * From sfe_model Where code_model=@Code_model))
		Set @Mensaje='Modelo no se encuentra Registrado.'
	Else Begin
		Update sfe_model Set model_name=@Model_name,description=@description,updated_at=@updated_at
		Where code_model=@Code_model
	Set @Mensaje='Registro Actualizado Correctamente.'
	End
End
----------------
Create Proc ListarModelo
As Begin
	Select * From sfe_model
End
-----------------
Create Proc BuscarModelo
@Datos Varchar(80)
As Begin
	Select code_model,model_name,description
	From sfe_model Where code_model like '%'+@Datos+'%' or model_name like '%'+@Datos+'%'
End
-----------
END 
GO

BEGIN  -- PRODUCTO PROC sfe_product

Create Proc RegistrarProducto
	@code_product varchar(10),
	@product_name varchar (1000),
@code_trademark varchar (10),
@code_category varchar (10),
@description varchar(1000),
@created_at datetime,
@updated_at datetime,
@Mensaje varchar(50) Out
As Begin
	If(Exists(Select * From sfe_product Where product_name=@product_name And code_category=@code_category))
		Set @Mensaje='Este Producto ya ha sido Registrado.'
	Else Begin
		Insert sfe_product Values(@code_product,@product_name,@code_trademark,@code_category,@description,@created_at,@updated_at)
		Set @Mensaje='Registrado Correctamente.'
	End
End
---------------------
Create Proc BuscarProducto
@Datos Varchar(80)
As Begin
	Select code_product,product_name,code_trademark,code_category,description 
	From sfe_product Where product_name=@Datos
End
-----------------
Create Proc FiltrarDatosProducto
@Datos Varchar(80)
As Begin
	Select code_product,product_name,code_trademark,code_category,description
	From sfe_product Where code_product like '%'+@Datos+'%' or product_name like '%'+@Datos+'%'
End
-------------------
Create Proc Listarproducto
As Begin
	Select * From sfe_product
End
--------------

END
go

BEGIN  -- PRODUCTO COMPAÑIA PROC sfe_company_products

Create Proc RegistrarCompanyProducts
	@code_product varchar(50),
	@name_product varchar (1000),
	@code_brand varchar (50),
	@code_category varchar (50),
	@precio decimal(18, 2),
	@unidad_medida varchar(20),
    @ruc_empresa varchar(11),
	@created_at datetime,
	@updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
		If(Exists(Select * From sfe_company_products Where name_product=@name_product))
			Set @Mensaje='Este Producto ya ha sido Registrado.'
		Else Begin
			Insert sfe_company_products Values(@code_product,@name_product,@code_brand,@code_category,@precio,@unidad_medida,@ruc_empresa,@created_at,@updated_at)
			Set @Mensaje='Registrado Correctamente.'
		End
End
------------------------------------------------------------
Create Proc EliminarCompanyProducts
	@code_product varchar(50),
	@Mensaje varchar(50) Out
As Begin
	DELETE FROM sfe_company_products WHERE code_product=@code_product
	set @Mensaje='Producto eliminado.'
End
---------------------------------------------------------------
Create Proc ActualizarCompanyProducts
	@code_product varchar(50),
	@name_product varchar (1000),
	@code_brand varchar (50),
	@code_category varchar (50),
	@precio decimal(18, 2),
	@unidad_medida varchar(20),
    @ruc_empresa varchar(11),
	@updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Not Exists(Select * From sfe_company_products Where code_product=@code_product and ruc_empresa=@ruc_empresa))
		Set @Mensaje='Producto no se encuentra Registrado.'
	Else Begin
		Update sfe_company_products Set name_product=@name_product,code_brand=@code_brand,code_category=@code_category,precio=@precio,unidad_medida=@unidad_medida,
		updated_at=@updated_at
		Where code_product=@code_product
	Set @Mensaje='Registro Actualizado Correctamente.'
	End
End
---------------------------------------------------------------------------
Create Proc BuscarCompanyProducts_codigo
@Datos Varchar(80)
As Begin
	Select code_product,name_product,code_brand,code_category,precio,unidad_medida,ruc_empresa 
	From sfe_company_products Where code_product=@Datos
End
---------------------------------------
Create Proc BuscarCompanyProducts
@Datos Varchar(80)
As Begin
	Select code_product,name_product,code_brand,code_category,precio,unidad_medida,ruc_empresa
	From sfe_company_products Where code_product like '%'+@Datos+'%' or name_product like '%'+@Datos+'%'
End 
-------------------------------
Create Proc ListarCompanyProducts
@ruc varchar(11)
As Begin
	Select * From sfe_company_products where ruc_empresa=@ruc
End
---------------------------------

end
select * from sfe_company_products
go
BEGIN  -- UNIDAD MEDIDA PROC sfe_unit_measurement
Create Proc RegistrarUMedida
	@Code_unit varchar(10),
	@Unit_name varchar (255),
	@description varchar(1000),
	@created_at datetime,
	@updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Exists(Select * From sfe_unit_measurement Where unit_name=@Unit_name And code_unit=@Code_unit))
		Set @Mensaje='Esta Unidad de medida ya ha sido Registrado.'
	Else Begin
		Insert sfe_unit_measurement Values(@Code_unit,@Unit_name,@description,@created_at,@updated_at)
		Set @Mensaje='Registrado Correctamente.'
	End
End
-------------------
Create Proc EliminarUMedida
	@Code_unit varchar(10),
	@Mensaje varchar(50) Out
As Begin
	DELETE FROM sfe_unit_measurement WHERE code_unit=@Code_unit
	set @Mensaje='Unidad de medida eliminada.'
End
-------------------------------
CREATE Proc ActualizarUMedida
	@Code_unit varchar(10),
	@Unit_name varchar (255),
	@Description varchar (1000),
	@Updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Not Exists(Select * From sfe_unit_measurement Where code_unit=@Code_unit))
		Set @Mensaje='Unidad de medida no se encuentra Registrado.'
	Else Begin
		Update sfe_unit_measurement Set unit_name=@Unit_name,description=@description,updated_at=@updated_at
		Where code_unit=@Code_unit
	Set @Mensaje='Registro Actualizado Correctamente.'
	End
End
-------------------------
Create Proc BuscarUM
@Datos Varchar(80)
As Begin
	Select code_unit,unit_name,description
	From sfe_unit_measurement Where code_unit like '%'+@Datos+'%' or unit_name like '%'+@Datos+'%'
End
------------------------------
Create Proc ListarUMedida
As Begin
	Select * From sfe_unit_measurement
End
-----------------
end
GO

BEGIN  -- USUARIO  PROC  sfe_users-------------------------------

Create Proc RegistrarUsuario
	@Code_ruc varchar(11),
	@Business_name varchar (1000),
	@Brand varchar(255),
	@Cod_sector varchar(20),
	@Address varchar(255),
	@Email varchar(255),
	@Telephone varchar(11),
	@Status varchar(50),
	@Condition varchar(50),
	@created_at datetime,
	@updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Exists(Select * From sfe_users Where business_name=@Business_name And ruc=@Code_ruc))
		Set @Mensaje='Esta empresa ya ha sido Registrado.'
	Else Begin
		Insert sfe_users Values(@Code_ruc,@Business_name,@Brand,@Cod_sector,@Address,@Email,@Telephone,@Status,@Condition,@created_at,@updated_at)
		Set @Mensaje='Registrado Correctamente.'
	End
End
------------------------------
Create Proc EliminarUsuario
	@Code_ruc varchar(11),
	@Mensaje varchar(50) Out
As Begin
	DELETE FROM sfe_users WHERE ruc=@Code_ruc
	set @Mensaje='Cliente eliminado.'
End
-----------------------
CREATE Proc ActualizarUsuario
	@Code_ruc varchar(11),
	@Business_name varchar (1000),
	@Brand varchar(255),
	@Cod_sector varchar(20),
	@Address varchar(255),
	@Email varchar(255),
	@Telephone varchar(11),
	@Status varchar(50),
	@Condition varchar(50),
	@Updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Not Exists(Select * From sfe_users Where ruc=@Code_ruc))
		Set @Mensaje='USUARIO no se encuentra Registrado.'
	Else Begin
		Update sfe_users Set business_name=@Business_name,brand=@Brand,cod_sector=@Cod_sector,address = @Address,email= @Email,telephone=@Telephone,status= @Status,condition=@Condition,updated_at=@updated_at
		Where ruc=@Code_ruc
	Set @Mensaje='Registro Actualizado Correctamente.'
	End
End
-----------------------
Create Proc FiltrarDatosUsuario
@Datos Varchar(80)
As Begin
	Select ruc,business_name,brand,cod_sector,address,email,telephone,status,condition 
	From sfe_users Where ruc like '%'+@Datos+'%' or business_name like '%'+@Datos+'%'
End
----------------------------
Create Proc ListarUsuario
@ruc varchar(11)
As Begin
	Select * From sfe_users where ruc=@ruc 
End
------------------
END
GO
BEGIN  -- DETALLE-VENTA PROC  sfe_sales_detail

Create Proc RegistrarDetalleVenta
	@Code_sales varchar(100),
	@code_product varchar(50),
	@Cantidad int,
	@precio Decimal(18,2),
	@code_unit varchar(10),
	@base_imponible decimal(18, 2),
	@igv decimal(18, 2),
	@importe decimal(18, 2),
	@created_at datetime,
	@updated_at datetime,
	@Mensaje Varchar(50) Out
As Begin
	Insert sfe_sales_detail Values(@Code_sales,@Code_product,@Cantidad,@precio,@code_unit,@base_imponible,@igv,@importe,@created_at,@updated_at)
	Set @Mensaje='Registrado Correctamente. Detalle Venta'
End              
----------------
Create Proc ListarDetalleVentaCln
@Code varchar(100)
As Begin
	select m.nombre,v.fecha_emision,v.fecha_pago,v.company_ruc,t.nombre+' ELECTRONICA',v.cdp_serie,v.cdp_numero,c.ruc,c.business_name,c.address,v.observacion,v.base_imponible,v.igv,v.importe_total
	from sfe_sales as v inner join gen_vendors as c on v.proveedor_numero=c.ruc
						inner join sfe_voucher_type as t on v.cdp_tipo=t.id
						inner join sfe_type_money as m on v.tipo_moneda =m.id
	where v.code=@Code
End
------------------------------------------------
Create Proc ListarDetalleVenta
@Code varchar(100)
As Begin
	select p.code_product,p.name_product,dv.cantidad,p.precio,dv.base_imponible,dv.igv,dv.importe
	from sfe_sales_detail as dv inner join sfe_company_products as p on p.code_product=dv.code_product
	where dv.code_sales=@Code
End
------------------------------------------------------------
END
GO

BEGIN  -- VENTA PROC  sfe_sales
Create Proc RegistrarVenta
@Code varchar(100),
@Numero int,
@Fecha_emision datetime,
@fecha_pago datetime,
@Cdp_tipo varchar(2),
@Cdp_serie varchar(4),
@Cdp_numero int,
@Proveedor_tipo varchar(1),
@Proveedor_numero varchar(11),
@Valor_exportacion decimal(18, 2),
@Base_imponible decimal(18, 2),
@Importe_total_exonerada decimal(18, 2),
@Importe_total_inafecta decimal(18, 2),
@Igv decimal(18, 2),
@Importe_total decimal(18, 2),
@Dolares decimal(18, 2),
@Igv_retencion decimal(18, 2),
@Detraccion_id int,
@constancia_detraccion_numero varchar(50),
@constancia_detraccion_fecha_pago date,
@constancia_detraccion_monto decimal(18, 2),
@constancia_detraccion_referencia_monto decimal(18, 2),
@observacion varchar(1000),
@created_at datetime,
@Updated_at datetime,
@Company_ruc char(11),
@Tipo_moneda varchar(5),
@Mensaje Varchar(100) Out
As Begin
	Declare @Tipo_cambio decimal(4, 3)
	Set @Tipo_cambio=(SELECT TOP 1 sale FROM ext_exchange_rates ORDER BY id DESC)
	Begin
		Insert sfe_sales Values(@Code,@Numero,@Fecha_emision,@fecha_pago,@Cdp_tipo,@Cdp_serie,@Cdp_numero,@Proveedor_tipo,@Proveedor_numero,@Valor_exportacion,@Base_imponible,
		@Importe_total_exonerada,@Importe_total_inafecta,@Igv,@Importe_total,@Dolares,@Tipo_cambio,@Igv_retencion,@Detraccion_id,@constancia_detraccion_numero,
		@constancia_detraccion_fecha_pago,@constancia_detraccion_monto,@constancia_detraccion_referencia_monto,@observacion,@created_at,@Updated_at,@Company_ruc,@Tipo_moneda)
			Set @Mensaje='La Venta se ha Generado Correctamente.'
		End
	End
----------------------------
Create Proc BuscarVenta
@ruc char(11),
@Datos Varchar(80)
As Begin
	Select v.code,v.fecha_emision,v.fecha_pago,c.business_name,v.base_imponible,v.igv,v.importe_total,v.observacion,t.nombre
	From sfe_sales as v inner join gen_vendors as c on v.proveedor_numero=c.ruc inner join sfe_voucher_type as t on v.cdp_tipo=t.id
	Where v.company_ruc=@ruc and (v.proveedor_numero like '%'+@Datos+'%' or c.business_name like '%'+@Datos+'%' or t.nombre like '%'+@Datos+'%')
End
------------------------------------
Create Procedure consecutive_number
@serie varchar(10),
@NroCorrelativo Char(20)Out
As Begin
	Declare @Cant Int
	If(@serie='B001')
	Begin
	Select @Cant=numero+1 From sfe_consecutive_number where serie='B001'
		Set @NroCorrelativo='000'+Ltrim(Str(@Cant))
		
	End
	if(@serie='F001')
	begin
		Select @Cant=numero+1 From sfe_consecutive_number where serie='F001'		
			Set @NroCorrelativo='000'+Ltrim(Str(@Cant))		
			End
	End
-----------------------------------
CREATE Proc Update_sfe_consecutive_number
	@serie varchar(10),
	@numero int,
	@Updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Not Exists(Select * From sfe_consecutive_number Where serie=@serie))
		Set @Mensaje='serie no se encuentra Registrado.'
	Else Begin
		Update sfe_consecutive_number Set numero=@numero,updated_at=@updated_at
		Where serie=@serie
	Set @Mensaje='Registro Actualizado Correctamente.'
	End
	end
----------------------------------
Create Proc GenerarIdVentas
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
---------------------
Create Proc ListarVentas
@ruc char(11)
As Begin
	Select v.code,v.fecha_emision,v.fecha_pago,c.business_name,v.base_imponible,v.igv,v.importe_total,v.observacion,t.nombre
	From sfe_sales as v inner join gen_vendors as c on v.proveedor_numero=c.ruc inner join sfe_voucher_type as t on v.cdp_tipo=t.id
	where v.company_ruc=@ruc
End
-----------------------------------------------



END
GO
BEGIN  -- TIPO BAUCHER PROC  sfe_voucher_type
Create Proc ListarTipoComprobante
As Begin
	Select id, nombre From sfe_voucher_type
End
----------------------------

END
GO
BEGIN  -- USUARIO DE COMPAÑIA sfe_company_users
Create Proc RegistrarUsuarioCompania
	@username varchar (50),
	@password varchar (255),
	@state varchar(10),
	@ruc_company varchar(50),
	@created_at datetime,
	@updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Exists(Select * From sfe_company_users Where username=@username and ruc_company=@ruc_company))
		Set @Mensaje='Este usuario ya a sido Registrado.'
	Else Begin
		Insert sfe_company_users Values(@username,@password,@state,@ruc_company,@created_at,@updated_at)
		Set @Mensaje='Registrado Correctamente.'
	End
End
---------------------
Create Proc DevolverDatosSesion
@Usuario Varchar(50),
@Contraseña Varchar(255)
As Begin
     If(Exists(Select * From sfe_company_users Where username=@Usuario and password=@Contraseña))
	 Select username,state,ruc_company From sfe_company_users Where username=@Usuario And password=@Contraseña
	 Else Begin
		If(Exists(Select * From gen_users Where username=@Usuario and password=@Contraseña))
			Select username,state From gen_users Where username=@Usuario And password=@Contraseña
	End
end
---------------------------
Create Proc IniciarSesion4
@Usuario Varchar(20),
@Password Varchar(50),
@Mensaje Varchar(50) Out
As Begin
	If(Not Exists(Select username From gen_users Where username=@Usuario))
		begin
			If(Not Exists(Select username from sfe_company_users Where username=@Usuario))
			Set @Mensaje='El Nombre de Usuario no Existe.'
			Else Begin
				If(Not Exists(Select password From sfe_company_users Where password=@Password))
					Set @Mensaje='Su Contraseña es Incorrecta.'
				Else Begin
					if(Exists(Select username,password From sfe_company_users Where username=@Usuario And password=@Password))
						Set @Mensaje='Bienvenido'
				 End
			End
		End
		Else Begin
			If(Not Exists(Select password From gen_users Where password=@Password))
				Set @Mensaje='Su ContraseñaADMIN es Incorrecta.'
				Else Begin
				  if(Exists(Select username,password From gen_users Where username=@Usuario And password=@Password))
						Set @Mensaje='Bienvenido ADMIN'					
		        end
			end
   end
---------------------
Create Proc ListarUserCompany
@ruc varchar(11)
As Begin
	Select * From sfe_company_users where ruc_company=@ruc
End
-----------------------------
CREATE Proc ActualizarUsuarioCompania
	@username varchar (50),
	@password varchar (255),
	@state varchar(10),
	@ruc_company varchar(50),
	@updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Not Exists(Select * From sfe_company_users Where username=@username))
		Set @Mensaje='Modelo no se encuentra Registrado.'
	Else Begin
		Update sfe_company_users Set password=@password,state=@state,ruc_company=@ruc_company,updated_at=@updated_at
		Where username=@username
	Set @Mensaje='Registro Actualizado Correctamente.'
	End
End
-----------------------------------------
Create Proc EliminarUserCompany
	@username varchar(50),
	@Mensaje varchar(50) Out
As Begin
	DELETE FROM sfe_company_users WHERE username=@username
	set @Mensaje='Usuario Eliminado'
End
---------------------------------------------------



Go
BEGIN  --COMPRA PROC  sfe_purchages
Create Proc RegistrarCompra
	@code_purchages varchar(100),
	@numero int,-----------VACIO
	@fecha_emision datetime,
	@fecha_pago datetime,
	@cdp_tipo char(2),
	@cdp_serie varchar(4),
	@cdp_numero int,
	@proveedor_tipo varchar(1),---------VACIO
	@proveedor_numero char(11),
	@base_imponible decimal(18, 2),-----------SUB TOTAL		
	@igv decimal(18, 2), -------- ------------total igv
	@no_gravada decimal(18, 2),---vacio
	@descuento decimal(18, 2),  --vacio
	@importe_total decimal(18, 2),------------importe total
	@dolares decimal(18, 2),---vacio
	@percepcion decimal(18, 2),--vacio
	@detraccion_id int,----vacio
	@constancia_detraccion_numero varchar(50),----vacio
	@constancia_detraccion_fecha_pago datetime,----vacio
	@constancia_detraccion_monto decimal(18, 2),----vacio
	@monto_referencial decimal(18, 2),----vacio
	@nota_credito_referencia_fecha datetime,----vacio
	@nota_credito_referencia_tipo varchar(2),----vacio
	@nota_credito_referencia_serie varchar(4),----vacio
	@nota_credito_referencia_numero varchar(50),----vacio
	@observacion varchar(1000),
	@created_at datetime,
	@updated_at datetime,
	@company_ruc char(11),-------------------------ruc-compania propia
	@Tipo_moneda varchar(5),
	@Mensaje Varchar(100) Out
As Begin
	Declare @Tipo_cambio decimal(4, 3)
	Set @Tipo_cambio=(SELECT TOP 1 sale FROM ext_exchange_rates ORDER BY id DESC)
	Begin
		Insert sfe_purchages Values(@code_purchages,@numero,@fecha_emision,@fecha_pago,@cdp_tipo,@cdp_serie,@cdp_numero,@proveedor_tipo,@proveedor_numero,@base_imponible,
									@igv,@no_gravada,@descuento,@importe_total,@dolares,@tipo_cambio,@percepcion,@detraccion_id,@constancia_detraccion_numero,
									@constancia_detraccion_fecha_pago,@constancia_detraccion_monto,@monto_referencial,@nota_credito_referencia_fecha,@nota_credito_referencia_tipo,
									@nota_credito_referencia_serie,@nota_credito_referencia_numero,@observacion,@created_at,@updated_at,@company_ruc,@Tipo_moneda)
			Set @Mensaje='La compra se ha registrado Correctamente.'
		End
	End
---------------------------- 
Create Proc BuscarCompra
@ruc char(11),
@Datos Varchar(80)
As Begin
	Select v.code_purchages,v.fecha_emision,v.fecha_pago,c.business_name,v.base_imponible,v.igv,v.importe_total,v.observacion,t.nombre
	From sfe_purchages as v inner join gen_vendors as c on v.proveedor_numero=c.ruc inner join sfe_voucher_type as t on v.cdp_tipo=t.id
	Where v.company_ruc=@ruc and (v.proveedor_numero like '%'+@Datos+'%' or c.business_name like '%'+@Datos+'%' or t.nombre like '%'+@Datos+'%')
End
------------------------ select * from sfe_purchages
Create Proc GenerarIdCompra
@ruc varchar(11),
@Cdp_tipo varchar(2),
@Cdp_serie varchar(4),
@Cdp_numero int,
@CodeCompra varchar(100) Out
As Begin
	Set @CodeCompra=CONCAT(@ruc,'-',@Cdp_tipo,'-',@Cdp_serie,'-',@Cdp_numero)
	If(Exists(Select code_purchages From sfe_purchages where code_purchages=@CodeCompra))
		Set @CodeCompra=CONCAT(@ruc,'-',@Cdp_tipo,'-',@Cdp_serie,'-',(@Cdp_numero+1))
	End
---------------------
Create Proc ListarCompras
@ruc char(11)
As Begin
	Select v.code_purchages,v.fecha_emision,v.fecha_pago,c.business_name,v.base_imponible,v.igv,v.importe_total,v.observacion,t.nombre
	From sfe_purchages as v inner join gen_vendors as c on v.proveedor_numero=c.ruc inner join sfe_voucher_type as t on v.cdp_tipo=t.id
	Where v.company_ruc=@ruc
End
-----------------------------------------------



END
GO

BEGIN  -- DETALLE-COMPRA PROC  sfe_purchages_detail

Create Proc RegistrarDetalleCompra
	@code_purchages varchar(100),
	@code_product varchar(50),
	@cantidad int,
	@precio Decimal(18,2),
	@code_unit varchar(10),
	@base_imponible decimal(18, 2),
	@igv decimal(18, 2),
	@importe decimal(18, 2),
	@created_at datetime,
	@updated_at datetime,
	@Mensaje Varchar(50) Out
As Begin
	Insert sfe_purchages_detail Values(@code_purchages,@Code_product,@cantidad,@precio,@code_unit,@base_imponible,@igv,@importe,@created_at,@updated_at)
	Set @Mensaje='Registrado Correctamente. Detalle Compra'
End             
select * from sfe_purchages_detail
select * from sfe_purchages
---------------- FALTAAAAAAAA

Create Proc ListarDetalleVentaPro
@Code varchar(100)
As Begin
	select m.nombre,v.fecha_emision,v.fecha_pago,v.company_ruc,t.nombre+' ELECTRONICA',v.cdp_serie,v.cdp_numero,c.ruc,c.business_name,c.address,v.observacion,v.base_imponible,v.igv,v.importe_total
	from sfe_purchages_detail as v inner join gen_vendors as c on v.proveedor_numero=c.ruc
						inner join sfe_voucher_type as t on v.cdp_tipo=t.id
						inner join sfe_type_money as m on v.tipo_moneda =m.id
	where v.code=@Code
End
------------------------------------------------
Create Proc ListarDetalleVenta
@Code varchar(100)
As Begin
	select p.code_product,p.name_product,dv.cantidad,p.precio,dv.base_imponible,dv.igv,dv.importe
	from sfe_sales_detail as dv inner join sfe_company_products as p on p.code_product=dv.code_product
	where dv.code_sales=@Code
End
------------------------------------------------------------
END
GO



exec DevolverDatosSesion ''
END
GO








Select * From sfe_company_users select * from gen_users

Select v.code,v.fecha_emision,v.fecha_pago,c.business_name,v.base_imponible,v.igv,v.importe_total,v.observacion,t.nombre
	From sfe_sales as v inner join gen_vendors as c on v.proveedor_numero=c.ruc inner join sfe_voucher_type as t on v.cdp_tipo=t.id
	Where v.company_ruc='20605971343' and (v.proveedor_numero like '%'+'bo'+'%' or c.business_name like '%'+'bo'+'%' or t.nombre like '%'+'bo'+'%')


Select v.code,v.fecha_emision,v.fecha_pago,c.business_name,v.base_imponible,v.igv,v.importe_total,v.observacion,t.nombre
	From sfe_sales as v inner join gen_vendors as c on v.proveedor_numero=c.ruc  inner join sfe_voucher_type as t on v.cdp_tipo=t.id
	where v.company_ruc='20605971343'

--------------------------------------------------
	select m.nombre,v.fecha_emision,v.fecha_pago,v.company_ruc,t.nombre+' ELECTRONICA',v.cdp_serie,v.cdp_numero,c.ruc,c.business_name,c.address,v.observacion
	from sfe_sales as v inner join gen_vendors as c on v.proveedor_numero=c.ruc
						inner join sfe_voucher_type as t on v.cdp_tipo=t.id
						inner join sfe_type_money as m on v.tipo_moneda =m.id
	where v.code='20363916008-01-F001-1'


	select p.code_product,p.name_product,dv.cantidad,p.precio,dv.base_imponible,dv.igv,dv.importe
	from sfe_sales_detail as dv inner join sfe_company_products as p on p.code_product=dv.code_product
	where dv.code_sales='20363916008-01-F001-1'
----------------------------------------
	

select * from sfe_sales_detail
select * from sfe_company_products
select * from sfe_sales
select * from sfe_type_money


-- HELP
DROP PROC ListarDetalleVentaCln

exec FiltrarDatosProducto 'papel'

Select * From gen_users Where username='20363916008' and password='5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8'