using System;
using System.Data;

using MySql.Data.MySqlClient;
namespace Practica7
{
	public class MySQL
	{
		protected MySqlConnection myConnection;
		string connectionString;
		public MySQL()
		{
		}
		protected void abrirConexion(){
			connectionString = 
				"Server=localhost;" +
				"Database=practica7;" +
				"Uid=root;" +
				"Pwd=2681124g;"+
				"Pooling=false;";
			this.myConnection = new MySqlConnection (connectionString);
			this.myConnection.Open();
		}
		public void cerrarConexion(){
		
			this.myConnection.Close();
			this.myConnection = null;
		
		}
	}
}
