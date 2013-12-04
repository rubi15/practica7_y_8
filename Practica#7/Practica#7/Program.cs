
using System;

namespace Practica_7
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			int opc;
			Command comando = new Command();
			do{
				menu:
				Console.Clear();
			Console.WriteLine("** Menu**\n");
			Console.WriteLine("1.- Mostrar todos los datos. \n");
			Console.WriteLine("2.- Agregar Nuevo Registro.  \n ");
			Console.WriteLine("3.- Editar Registro. \n");
			Console.WriteLine("4.- Eliminar registro. \n");
			Console.WriteLine("5.- Salir. \n");
			
			Console.WriteLine("elija una opcion:");
			
			opc = Convert.ToInt32(Console.ReadLine());
			
			switch(opc){
				 
				case 1:
					comando.mostrarTodos();
					Console.ReadKey(true);
					goto menu;
				case 2:
					Console.WriteLine("ingrese el nombre:");
					String nombreN = Console.ReadLine();
					Console.WriteLine("ingrese el codigo:");
					String codigoN = Console.ReadLine();
					Console.WriteLine("ingrese el telefono:");
					String telefonoN = Console.ReadLine();
					Console.WriteLine("ingrese el email:");
					String emailN = Console.ReadLine();
					
					comando.agregarRegistroNuevo(nombreN,codigoN,telefonoN,emailN);
					Console.WriteLine();
				goto menu;
					
				case 3:
					Console.WriteLine("Ingrese el codigo que decea editar:");
					
					comando.editarCodigo(Console.ReadLine());
					Console.WriteLine();
								goto menu;
				case 4:
							
					Console.WriteLine("Ingrese el ID que decea eliminarl:  ");
					string id = Console.ReadLine();
					comando.eliminarRegistro(id);
				     Console.WriteLine("Esta seguro de que decea eliminar el Registro: \n si/no");
					
					string sel= Console.ReadLine();
					if(sel.Equals("si")){
						
						comando.eliminarRegistro(id);
						
					}else goto menu;
					Console.WriteLine();
					goto menu;
					
		}
			}
			while(opc!=5);
			Console.ReadKey();
     }
   }
}