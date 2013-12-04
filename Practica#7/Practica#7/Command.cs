using System;
using MySql.Data.MySqlClient;

namespace Practica_7
{
	public class Command : MySQL
	{
		public Command ()
		{
		}
		
		public void mostrarTodos(){
			this.abrirConexion();
            MySqlCommand myCommand = new MySqlCommand(this.querySelect(), myConnection);
            MySqlDataReader myReader = myCommand.ExecuteReader();	
	        while (myReader.Read()){
            	
	            string id = myReader["id"].ToString();
	            string nombre = myReader["nombre"].ToString();
	            string codigo = myReader["codigo"].ToString();
	            string telefono = myReader["telefono"].ToString();
	            string email = myReader["email"].ToString();
	            
	            Console.WriteLine("ID: " + id  + 
				                  " Nombre: " + nombre + 
				                  " Codigo: " + codigo + " Telefono: " +
				                  telefono + " Email: " + email );
	       }
			
            myReader.Close();
			myReader = null;
            myCommand.Dispose();
			myCommand = null;
			this.cerrarConexion();
		}
		
		public void agregarRegistroNuevo(string nombre, string codigo, string telefono, string email){
			this.abrirConexion();
			string sql = "INSERT INTO `tabla1`(`nombre`, `codigo`, `telefono`, `email`)" + 
				"VALUES ('" + nombre + "', '" + codigo + "','"+ telefono +"','" + email +"')";
			
	
			this.ejecutarComando(sql);
			this.cerrarConexion();
	
		}
		public void editarCodigo(string id1){
			this.abrirConexion();
			MySqlCommand myCommand=new MySqlCommand(this.queryId(id1), this.myConnection);
			MySqlDataReader myReader=myCommand.ExecuteReader();
			
			while(myReader.Read()){
				string id = myReader["id"].ToString();
	            string nombre = myReader["nombre"].ToString();
	            string codigo = myReader["codigo"].ToString();
	            string telefono = myReader["telefono"].ToString();
	            string email = myReader["email"].ToString();
	            
	            Console.WriteLine("ID: " + id  + 
				                  " Nombre: " + nombre + 
				                  " Codigo: " + codigo + "Telefono: " +
				                  telefono + "Email: " + email );	
			}
			Console.WriteLine("ingrese el nombre:");
					String nombreN = Console.ReadLine();
					Console.WriteLine("ingrese el codigo:");
					String codigoN = Console.ReadLine();
					Console.WriteLine("ingrese el telefono:");
					String telefonoN = Console.ReadLine();
					Console.WriteLine("ingrese el email:");
					String emailN = Console.ReadLine();
					
			string sql = "UPDATE `tabla1` SET `Nombre`='" + nombreN + "', Codigo= '" +
										codigoN + "', Telefono= '" + telefonoN + "', Email= '" +
										emailN + "' WHERE `id`=('" + id1 + "')";
			 myReader.Close();
			this.ejecutarComando(sql);
			this.cerrarConexion();
		}
		
		 public void eliminarRegistro(string id1){
			this.abrirConexion();
			MySqlCommand myCommand=new MySqlCommand(this.queryId(id1), this.myConnection);
			MySqlDataReader myReader=myCommand.ExecuteReader();
			
			while(myReader.Read()){
				string id = myReader["id"].ToString();
	            string nombre = myReader["nombre"].ToString();
	            string codigo = myReader["codigo"].ToString();
	            string telefono = myReader["telefono"].ToString();
	            string email = myReader["email"].ToString();
	            
	            Console.WriteLine("ID: " + id  + 
				                  " Nombre: " + nombre + 
				                  " Codigo: " + codigo + "Telefono: " +
				                  telefono + "Email: " + email );	
			}
			
		string sql = "DELETE FROM `tabla1` WHERE `id`=  ('" + id1 + "')";
		
		 myReader.Close();
		this.ejecutarComando(sql);
		this.cerrarConexion();

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
	           	"FROM tabla1";
		}
		private string queryId(string id){
			return "SELECT * from tabla1 where id='" + id + "'";
		}
	}
}

