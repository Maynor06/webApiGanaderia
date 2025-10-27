namespace WebapiProyect.DTO
{
    public class EspecieDto
    {

        public long IdEspecie { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public List<RazaDto> Razas { get; set; } = new List<RazaDto>();
    }
}
