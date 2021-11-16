using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IServicio.BaseDto;

namespace IServicios.Departamento.DTOs
{
    public class DepartamentoCrudDto : DtoBase
    {
        public long ProvinciaId { get; set; }
        public string Descripcion { get; set; }
    }
}
