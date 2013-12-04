using System;
using MySql.Data.MySqlClient;

namespace Practica_7
{
	public class MySQL
	{
		protected MySqlConnection myConnection;
		public MySQL ()
		{
		}
		
		protected void abrirConexion(){
			string connectionString =
				
          		"Server= localhost;" +
	          	"Database= programacion;" +
	          	"User ID= root;" +
	          	"Password= rubi15;" +
	          	"Pooling= false;";
	       this.myConnection = new MySqlConnection(connectionString);
	       this.myConnection.Open();
		}
		
		protected void cerrarConexion(){
			this.myConnection.Close(); 
			this.myConnection = null;
		}
	}
}

