namespace Entidades.Negocio
{
    public class Persona
    {
        public int Id_Persona { get; set; }
        public string Primer_nombre { get; set; }
        public string Segundo_nombre { get; set; }
        public string Primer_apellido { get; set; }
        public string Segundo_apellido { get; set; }
        public int Id_tipo_documento { get; set; }
        public long Numero_documento { get; set; }
        public long celular { get; set; }
        public string direccion { get; set; }
        public string correo { get; set; }
    }
}