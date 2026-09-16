class Program
{
    
    static void Main()
    {
        Estudiante estefania = new Estudiante( "Tecnologia en desarrollo de software",
             "2026-2", 4.4, "Estefania", "Sanchez", "1212423", 
             "estefaniasanchez@correo.com", "3125567468" );


Console.WriteLine ("Estudiante:  " + estefania.getNombre());
estefania.setNombre("Luis");
Console.WriteLine ("Estudiante:  " + estefania.getNombre());
    }

}
