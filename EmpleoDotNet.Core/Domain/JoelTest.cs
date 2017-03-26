namespace EmpleoDotNet.Core.Domain
{
    /// <summary>
    /// Indica cuales pasos de la Prueba de Joel sigue la empresa
    /// Para mas informacion, visitar el enlace : 
    /// http://local.joelonsoftware.com/wiki/El_Test_de_Joel:_12_pasos_hacia_un_c%C3%B3digo_mejor
    /// </summary>
    public class JoelTest : EntityBase
    {
        /// <summary>
        /// Indica si  utilizan algún tipo de Sistema de Control de Versiones
        /// </summary>
        public bool HasSourceControl { get; set; }

        /// <summary>
        /// Indica si se pueden hacer pases  a produccion en un solo paso
        /// </summary>
        public bool HasOneStepBuilds { get; set; }

        /// <summary>
        /// Indica si hacen builds diarios
        /// </summary>
        public bool HasDailyBuilds { get; set; }

        /// <summary>
        /// Indica si tienen una base de datos de bugs (tipo JIRA o YouTrack)
        /// </summary>
        public bool HasBugsDatabase { get; set; }

        /// <summary>
        /// Indica si se corrigen los bugs existentes antes de agregar nuevos features
        /// </summary>
        public bool HasBugsFixedBeforeProceding { get; set; }

        /// <summary>
        /// Indica si tienen una planificacion actualizada
        /// </summary>
        public bool HasUpToDateSchedule { get; set; }

        /// <summary>
        /// Indica si tienen documentos de especificacion
        /// </summary>
        public bool HasSpec { get; set; }

        /// <summary>
        /// Indica si los programadores estan en un lugar tranquilo
        /// </summary>
        public bool HasQuietEnvironment { get; set; }

        /// <summary>
        /// Indica si utilizan las mejores herramientas que se puedan comprar
        /// </summary>
        public bool HasBestTools { get; set; }

        /// <summary>
        /// Indica si tienen personas encargadas de pruebas
        /// </summary>
        public bool HasTesters { get; set; }

        /// <summary>
        /// Indica si hacen escribir codigo a los candidatos en las entrevistas
        /// </summary>
        public bool HasWrittenTest { get; set; }

        /// <summary>
        /// Indican si tienen pruebas de usabilidad 'de vestibulo'
        /// </summary>
        public bool HasHallwayTests { get; set; }
    }
}