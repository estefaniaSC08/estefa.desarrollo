public class Estudiante : Persona

{
  private string programa;
  private string semestre;
  private double promedio;


public Estudiante(string programaRecibido, string semestreRecibido, 
double promedioRecibido, string nombreRecibido, string apellidoRecibido, 
string documentoRecibido, string correoRecibido, string telefonoRecibido
) : base(nombreRecibido, apellidoRecibido,documentoRecibido,correoRecibido,telefonoRecibido)
 {

    this.programa = programaRecibido;
    this.semestre = semestreRecibido;
    this.promedio = promedioRecibido;
 }


}