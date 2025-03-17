using EL;
using DAL;

Clientes c = new Clientes();
c.Nombre = "Arles";
c.DNI = "1234";
c.Telefono = "12345678";
c.Correo = "asda";
c.UsuarioRegistra = 1;

var resultado = await DAL_Clientes.Insert(c);

if (resultado != null)
{
    Console.WriteLine("Ingresado correctamente");
}

else
{
    Console.WriteLine("No se ingreso");
}
Console.ReadLine();