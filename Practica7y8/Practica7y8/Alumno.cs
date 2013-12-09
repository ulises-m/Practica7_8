using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Practica7
{
public class Alumnos:MySQL
{
	
	
	public Alumnos()
	{
		
	}
	public void mostrarTodos(){
		Console.WriteLine("\n"+"\t\tTotal de Registros Guardados en la BD");
		this.abrirConexion();
		MySqlCommand myCommand = new MySqlCommand(this.querySelect(),myConnection);
		MySqlDataReader myReader = myCommand.ExecuteReader();
		
		while (myReader.Read()){
			
		string  id = myReader["id"].ToString();
		string nombre = myReader["nombre"].ToString();
		string codigo = myReader["codigo"].ToString();
		string telefono = myReader["telefono"].ToString();
		string email = myReader ["email"].ToString();
			
		Console.WriteLine("\nID: "+id+"\nNombre:"+nombre+"\nCodigo:"+codigo+
		                  "\ntelefono:"+ telefono+"\nemail:"+email);
		}
		myReader.Close();
		myReader = null;
		myCommand.Dispose();
		myCommand = null;
		this.cerrarConexion();
	}
	public void insertarRegistroNuevo(string codigo, string nombre,string telefono,string email){
		
		Console.WriteLine("---Funcion Para Agregar Alumnos Ingrese sus Datos---\n");
		Console.WriteLine("Ingrese Los Datos Requeridos\n");
		this.abrirConexion();
		//Console.Write("ID:");
		//id = Console.ReadLine();
		Console.Write("NOMBRE:");
		nombre = Console.ReadLine();
		Console.Write("CODIGO:");
		codigo = Console.ReadLine();
		Console.Write("TELEFONO:");
		telefono = Console.ReadLine();
		Console.Write("E-MAIL:");
		email = Console.ReadLine();
		
		string sql = "INSERT INTO `alumnos` (`nombre`,`codigo`,`telefono`,`email`) VALUES ('"+nombre+"','"+codigo+"','"+telefono+"','"+email+"')";
		this.ejecutarComando(sql);
		this.cerrarConexion();
	}
	public void editarCodigoRegistro(string id){
		string codigo,nombre,telefono,email;
		
		Console.WriteLine("---Funcion Para Editar Datos del Alumno---\n");
		Console.Write("Dame el ID del Alumno:");
		id = Console.ReadLine();
		this.abrirConexion();
		
		string sqlid = "SELECT id FROM `alumnos` WHERE `id`='"+id+"';";
		MySqlCommand myCommand = new MySqlCommand(sqlid,myConnection);
		MySqlDataReader myReader = myCommand.ExecuteReader();
		
		if (myReader.Read()){
		Console.WriteLine("\n---Ingrese Los Nuevos Datos Del Alumno---\n");
		Console.Write("NOMBRE:");
		nombre = Console.ReadLine();
		Console.Write("CODIGO:");
		codigo = Console.ReadLine();
		Console.Write("TELEFONO:");
		telefono = Console.ReadLine();
		Console.Write("E-MAIL:");
		email = Console.ReadLine();
		
		string sql = "UPDATE `alumnos` SET `nombre`='"+nombre+ "',`codigo`='" +codigo+ "',telefono='"+telefono+"',email='"+email+"' WHERE (`id`='" + id + "')";
		
		myReader.Close();
		myReader = null;
		myCommand.Dispose();
		myCommand = null;
		this.ejecutarComando(sql);
		this.cerrarConexion();
		Console.WriteLine("Se han Actualizado los Datos del Alumno");}
		else {
		
			Console.WriteLine("Error no Existe");
		}
	}
	public void eliminarRegistroPorId(string id){
		string opc ="";
		Console.Write("Dame el ID a Eliminar:");
		id = Console.ReadLine();
		
		this.abrirConexion();
		string sqlid = "SELECT id FROM `alumnos` WHERE `id`='"+id+"';";
		MySqlCommand myCommand = new MySqlCommand(sqlid,myConnection);
		MySqlDataReader myReader = myCommand.ExecuteReader();
		
		if (myReader.Read()){
		Console.Write("Seguro que desea eliminar el registro: {0}  1)Si  2)No :",id);
		opc = Console.ReadLine();
		
		if (opc == "1"){
		
		string sql = "DELETE FROM `alumnos` WHERE (`id`='" + id + "')";
		myReader.Close();
		myReader = null;
		myCommand.Dispose();
		myCommand = null;
		
		this.ejecutarComando(sql);
		this.cerrarConexion();
		Console.WriteLine("Registro Eliminado ID:{0}",id);
			
		}
	
		else {
		
		 new Principal();
		}}
			else {
		
			
			Console.WriteLine("Error no existe");
		}
	}
	private int ejecutarComando(string sql){
		MySqlCommand myCommand = new MySqlCommand(sql,this.myConnection);
		int afectadas = myCommand.ExecuteNonQuery();
		myCommand.Dispose();
		myCommand = null;
		return afectadas;
	}
	
	private string querySelect(){
		return "SELECT * " +
			"FROM alumnos";
	}
  }
}