using PresentacionBase.Formularios;

namespace Presentacion.Core.Caja
{
    public partial class _00044_Abm_Gastos : FormAbm
    {
        public _00044_Abm_Gastos(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
        }
    }
}
