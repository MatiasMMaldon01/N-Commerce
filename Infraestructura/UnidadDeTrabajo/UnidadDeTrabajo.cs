using System;
using Dominio.UnidadDeTrabajo;

namespace Infraestructura.UnidadDeTrabajo
{
    public partial class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly DataContext _context;

        public UnidadDeTrabajo(DataContext context)
        {
            _context = context;
        }


        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        var message = $"{validationErrors.Entry.Entity.ToString()}:{validationError.ErrorMessage}";

                        raise = new InvalidOperationException(message, raise);
                    }
                }

                throw raise;
            }
        }

        public void Disposed()
        {
            _context.Dispose();
        }
    }
}
