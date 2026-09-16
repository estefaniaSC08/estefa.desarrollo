public class Estudiante : Persona
{
    private string programa;
    private string semestre;
    private double promedio;
    public Estudiante(string programaRecibido,
        string semestreRecibido,
        double promedioRecibido,
        string nombreRecibido,
        string apellidoRecibido,
        string documentoRecibido,
        string correoRecibido,
        string telefonoRecibido

     ) : base(nombreRecibido, apellidoRecibido, documentoRecibido, correoRecibido, telefonoRecibido)
    {
        this.programa = programaRecibido;
        this.semestre = semestreRecibido;
        this.promedio = promedioRecibido;
    }


    public string getPrograma()
    {
        return this.programa;
    }

    public void setPrograma(string programa)
    {
        this.programa = programa;
    }

    public string getSemestre()
    {
        return this.semestre;
    }

    public void setSemestre(string semestre)
    {
        this.semestre = semestre;
    }

    public double getPromedio()
    {
        return this.promedio;
    }

    public void setPromedio(double promedio)
    {
        this.promedio = promedio;

    }

     public void imprimirNombreCompleto()
 {

     Console.WriteLine($"Promedio del estudiante {this.promedio} ");

 }
}