    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace UniversidadPOO
    {
        public class Materia
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
            public int CarreraId { get; set; }
            public string NombreCarrera { get; set; }
        }
    }