namespace web_api_permissions.Models
{
    public class PermissionResultModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public PermissionModel Permission { get; set; } // Esto podría ser un objeto PermissionModel para representar los detalles de la solicitud de permiso
    }
}
