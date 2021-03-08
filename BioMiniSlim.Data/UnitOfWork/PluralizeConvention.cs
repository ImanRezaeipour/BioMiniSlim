using System.Data.Entity.Design.PluralizationServices;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Globalization;

namespace BioMiniSlim.Data.UnitOfWork
{
    /// <summary>
    /// </summary>
    public class PluralizeConvention : Convention
    {
        #region Public Constructors

        /// <summary>
        /// </summary>
        public PluralizeConvention()
        {
            var pluralization = PluralizationService.CreateService(new CultureInfo("en-US"));

            // FieldName Convention
            Properties().Configure(property =>
            {
                if (property.ClrPropertyInfo.ReflectedType != null)
                    property.HasColumnName(property.ClrPropertyInfo.ReflectedType.Name + "_" + property.ClrPropertyInfo.Name);
            });

            // TableName Convention
            Types().Configure(entity => entity.ToTable("BM_" + pluralization.Pluralize(entity.ClrType.Name), "dbo"));
        }

        #endregion Public Constructors
    }
}