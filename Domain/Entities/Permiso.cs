namespace web_api_permissions.Domain.Entities
{
    public class Permiso
    {
        public int Id { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public int TipoPermisoId { get; set; }
        public DateTime FechaPermiso { get; set; }

        public TipoPermiso TipoPermiso { get; set; }
    }
}
