namespace MyProtocolsAPI_JeanCVR.ModelsDTOs
{
    public class UserRoleDTO
    {
        //Un DTO (data transfer object) sirve básicamente para 2 funciones:
        //1. Simplificar la estructura de los JSON que se envian y llegan a los end points de los controllers,
        //quitando composiciones innecesarias que solo harian que los JSON sean muy pesados o que muestren información 
        //que no se desea ver (pueder ser por seguridad)
        //2. Ocultar la estructura real de los modelos y por tanto de las tablas de bases de datos, a los programadores
        //de las apps, páginas web o aplicaciones de escritorio.

        //tomando en cuenta el segundo criterio, y solo a manera de ejemplo, este DTO tendrá los nombres de propiedades
        //en español

        public int UserRoleId { get; set; }
        public string Description { get; set; } = null!;



    }
}
