public class Persona
{
    private string nombre;
    private string apellido;
    private string documento;
    private string correo;
    private string telefono;

    public Persona(string nombreRecibido, string apellidoRecibido, string documentoRecibido, string correoRecibido, string telefonoRecibido)
    {
        this.nombre = nombreRecibido;
        this.apellido = apellidoRecibido;
        this.documento = documentoRecibido;
        this.correo = correoRecibido;
        this.telefono = telefonoRecibido;
    }
    public string getApellido()
    {
        return this.apellido;
    }

    public void setApellido(string apellido)
    {
        this.apellido = apellido;
    }

    public string getDocumento()
    {
        return this.documento;
    }

    public void setDocumento(string documento)
    {
        this.documento = documento;
    }

    public string getCorreo()
    {
        return this.correo;
    }

    public void setCorreo(string correo)
    {
        this.correo = correo;
    }

    public string getTelefono()
    {
        return this.telefono;
    }

    public void setTelefono(string telefono)
    {
        this.telefono = telefono;
    }


    public string getNombre()
    {
        return this.nombre;
    }

    public void setNombre(string nombreRecibido)
    {
        this.nombre = nombreRecibido;
    }

 public void imprimirNombreCompleto()

 {
     Console.WriteLine( $"{ this.nombre} {this.apellido}" );
    // Console.WriteLine(this.nombre + " " + this.apellido);
   
 }  

}