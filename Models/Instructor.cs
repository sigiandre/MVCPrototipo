namespace MVCPrototipo.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Grados { get; set; }
        public byte[] FotoPerfil { get; set; }
    }
}