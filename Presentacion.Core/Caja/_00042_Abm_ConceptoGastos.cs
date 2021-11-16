using PresentacionBase.Formularios;

namespace Presentacion.Core.Caja
{
    public partial class _00042_Abm_ConceptoGastos : FormAbm
    {
        public _00042_Abm_ConceptoGastos(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
        }
    }
}
