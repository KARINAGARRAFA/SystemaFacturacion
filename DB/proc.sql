--PROCEDIMIENTOS ALMACENADOS 

Create Proc IniciarSesion
@Usuario Varchar(20),
@Password Varchar(20),
@Mensaje Varchar(50) Out
As Begin
	Declare @Empleado Varchar(50)
	If(Not Exists(Select usuario From sfe_user_login Where usuario=@Usuario))
		Set @Mensaje='El Nombre de Usuario no Existe.'
		Else Begin
			If(Not Exists(Select password From sfe_user_login Where password=@Password))
				Set @Mensaje='Su Contraseña es Incorrecta.'
				Else Begin
					Set @Empleado=(Select E.business_name  From sfe_users E Inner Join sfe_user_login U 
								   On E.ruc=U.ruc_user Where U.Usuario=@Usuario)
					    Begin
					Select usuario,password From sfe_user_login Where usuario=@Usuario And password=@Password
							Set @Mensaje='Bienvenido Sr(a): '+@Empleado+'.'
						End
				  End
		   End
   End
Go select * from gen_users Select * From sfe_user_login Select * From sfe_users Select * From gen_vendors select * from gen_company_users
Create Proc IniciarSesion2
@Usuario Varchar(20),
@Password Varchar(20),
@Mensaje Varchar(50) Out
As Begin
	If(Not Exists(Select username From gen_users Where username=@Usuario))
		Set @Mensaje='El Nombre de Usuario no Existe.'
		Else Begin
			If(Not Exists(Select password From gen_users Where password=@Password))
				Set @Mensaje='Su Contraseña es Incorrecta.'
				Else Begin
					Select username,password From gen_users Where username=@Usuario And password=@Password
							Set @Mensaje='Bienvenido Sr(a): .'						
				  End
		   End
   End
Go



Create Proc IniciarSesion3
@Usuario Varchar(20),
@Password Varchar(50),
@Mensaje Varchar(50) Out
As Begin
	If(Not Exists(Select username From gen_users Where username=@Usuario))
		
		Set @Mensaje='El Nombre de UsuarioADMIN no Existe.'
		Else Begin
			If(Not Exists(Select password From gen_users Where password=@Password))
				Set @Mensaje='Su ContraseñaADMIN es Incorrecta.'
				Else Begin
				  if(Exists(Select username,password From gen_users Where username=@Usuario And password=@Password))
						Set @Mensaje='Bienvenido ADMIN'
					ELSE begin
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
		   End
   End
end

go


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

go

   select * from gen_users Select * From sfe_company_users

exec IniciarSesion3 '20363916008','5BAA61E4C9B93F3F0682250B6CF8331B7EE68FD8',''
exec IniciarSesion3 'admin','123',''
DROP PROC IniciarSesion3

Create Proc [Serie Documento]
@Serie char(5) out
as begin
Set @Serie='00001'
end
go

Create Procedure [Numero Correlativo]
@TipoDocumento Varchar(7),
@NroCorrelativo Char(7)Out
As Begin
	Declare @Cant Int
	If(@TipoDocumento='FACTURA')
	Begin
	Select @Cant=Count(*)+1 From sfe_sales where cdp_tipo='02'
		If @Cant<10
			Set @NroCorrelativo='000000'+Ltrim(Str(@Cant))
		Else
			If @Cant<100
				Set @NroCorrelativo='00000'+Ltrim(Str(@Cant))
			Else
				If @Cant<1000
					Set @NroCorrelativo='0000'+Ltrim(Str(@Cant))
				Else
					If(@Cant<10000)
						Set @NroCorrelativo='000'+LTRIM(STR(@Cant))
					Else
						If(@Cant<100000)
							Set @NroCorrelativo='00'+LTRIM(STR(@Cant))
						Else
							If(@Cant<1000000)
								Set @NroCorrelativo='0'+LTRIM(str(@Cant))
							Else
								If(@Cant<10000000)
									Set @NroCorrelativo=LTRIM(str(@Cant))
	End
	if(@TipoDocumento='BOLETA')
	begin
		Select @Cant=Count(*)+1 From sfe_sales where cdp_tipo='01'
		If @Cant<10
			Set @NroCorrelativo='000000'+Ltrim(Str(@Cant))
		Else
			If @Cant<100
				Set @NroCorrelativo='00000'+Ltrim(Str(@Cant))
			Else
				If @Cant<1000
					Set @NroCorrelativo='0000'+Ltrim(Str(@Cant))
				Else
					If(@Cant<10000)
						Set @NroCorrelativo='000'+LTRIM(STR(@Cant))
					Else
						If(@Cant<100000)
							Set @NroCorrelativo='00'+LTRIM(STR(@Cant))
						Else
							If(@Cant<1000000)
								Set @NroCorrelativo='0'+LTRIM(str(@Cant))
							Else
								If(@Cant<10000000)
									Set @NroCorrelativo=LTRIM(STR(@Cant))
			End
	End
Go

Create Procedure [Correlativo]
@TipoDocumento Varchar(7),
@NroCorrelativo Char(7)Out
As Begin
	Declare @Cant Int
	Begin
	Select @Cant=Count(*)+1 From sfe_sales_detail 
		Set @NroCorrelativo='000'+Ltrim(Str(@Cant))
	End
End
Go

Create Proc GenerarIdDetalleVenta
@CodeDetalleVenta Int Out
As Begin
	If(Not Exists(Select code From sfe_sales_detail))
		Set @CodeDetalleVenta=1
	Else Begin
		Set @CodeDetalleVenta=(Select count(code)+1 FROM sfe_sales_detail)
		End
	End
Go

Create Proc GenerarIdVenta
@CodeVenta varchar(100) Out
As Begin
	If(Not Exists(Select code From sfe_sales))
		Set @CodeVenta=1
	Else Begin
		Set @CodeVenta=(Select count(code)+1 FROM sfe_sales)
		End
	End
Go

Create Proc GenerarIdDetalleVentas
@CodeDetalleVenta Int Out
As Begin
	If(Not Exists(Select code From sfe_sales_detail))
		Set @CodeDetalleVenta=1
	Else Begin
		Set @CodeDetalleVenta=(Select count(code)+1 FROM sfe_sales_detail)
		End
	End
Go





INSERT INTO sfe_users VALUES ('00520953','LOZANO FERNANDEZ JACKELINE YANETH','','comercio','','','','','', '2020-11-12 00:00:00.000','2020-11-12 00:00:00.000')
INSERT INTO sfe_users VALUES ('10409854805','ZAPATA MAMANI LUZ MARINA','COFEZA-CORPORACION FERRETERA Z','comercio','-','','','ACTIVO','HABIDO', '2020-11-12 00:00:00.000','2020-11-12 00:00:00.000') 

INSERT INTO sfe_voucher_type VALUES ('02','FACTURA', '2020-11-12 00:00:00.000','2020-11-12 00:00:00.000') 

Create Procedure [consecutive_number]
@serie varchar(10),
@NroCorrelativo Char(7)Out
As Begin
	Declare @Cant Int
	If(@serie='B001')
	Begin
	Select @Cant=numero+1 From sfe_consecutive_number where @serie='B001'
		Set @NroCorrelativo='00'+Ltrim(Str(@Cant))
		
	End
	if(@serie='F001')
	begin
		Select @Cant=numero+1 From sfe_consecutive_number where @serie='B001'
		
			Set @NroCorrelativo='00'+Ltrim(Str(@Cant))
		End
	End
Go
--ELIMINADOS
begin
------------------
Create Proc EliminarProducto
	@code_product varchar(10),
	@Mensaje varchar(50) Out
As Begin
	DELETE FROM sfe_product WHERE code_product=@code_product
	set @Mensaje='Producto eliminado.'
End
-----------------------------------
Create Proc ActualizarProducto
	@code_product varchar(10),
	@product_name varchar (1000),
	@code_trademark varchar (10),
	@code_category varchar (10),
	@description varchar(1000),
	@created_at datetime,
	@updated_at datetime,
	@Mensaje varchar(50) Out
As Begin
	If(Not Exists(Select * From sfe_product Where code_product=@code_product))
		Set @Mensaje='Producto no se encuentra Registrado.'
	Else Begin
		Update sfe_product Set product_name=@product_name,code_trademark=@code_trademark,code_category=@code_category,description=@description,
		updated_at=@updated_at
		Where code_product=@code_product
	Set @Mensaje='Registro Actualizado Correctamente.'
	End
End
-----------------------------------------
end
go