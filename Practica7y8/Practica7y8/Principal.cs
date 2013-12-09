using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Practica7
{
	public class Principal
	{
		public static void Main (string [] args){
			string id = "",codigo = "",nombre = "",telefono = "",email= "",resp = "";
			int opcion;
			
			do{
			Console.Clear();
			Console.WriteLine("\tPrograma para Agregar,Mostrar,Editar y Eliminar Alumnos en una B.D");
			Console.WriteLine("\n1-Agregar\n2-Mostrar\n3-Editar\n4-Eliminar\n5-Salir\n");
			Console.Write("\nSeleccione una Opcion:");
			
			opcion = int.Parse(Console.ReadLine());
			Console.WriteLine("--------------------------------------------------------------------------------");
			switch(opcion){
			
				case 1:
			Alumnos alumnos = new Alumnos();
			alumnos.insertarRegistroNuevo(codigo,nombre,telefono,email);
			break;
				case 2:
			Alumnos alumnos2 = new Alumnos();
			alumnos2.mostrarTodos();
			break;
				case 3:
			Alumnos alumnos3 = new Alumnos();
			alumnos3.editarCodigoRegistro(id);
			break;
			
				case 4:
			Alumnos alumnos4 = new Alumnos();
			alumnos4.eliminarRegistroPorId(id);
			break;
			
			case 5:
			Environment.Exit(0);
			break;
				
				}
			Console.WriteLine("\n1)Menu Principal   2)Salir ");
			Console.Write("\nSeleccione una Opcion:");
			resp = Console.ReadLine();
			}
			while (resp == "1");
		}
	}
}
