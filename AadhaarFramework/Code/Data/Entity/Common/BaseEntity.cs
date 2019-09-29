using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace AadhaarFramework.Code.Data.Entity.Common
{
    /// <summary>
    /// This is the base class of every entity class for the database model.
    /// It implements constants, fields properties and usefull methods.
    /// This makes the development robust and fast.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Sugested name length string
        /// </summary>
        protected const int NAME_LENGTH = 100;
        /// <summary>
        /// Subrogate keys for every entity, they will be managed values via Sequences
        /// </summary>
        [Required, Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; } = -1;

        /// <summary>
        /// Soft delete will be the approach, we still need to know the catalog data even if its not required anymore
        /// </summary>
        [Column(Order = 95)]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Log created date of the row
        /// </summary>
        [Column(Order = 96)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Log created by user of the row
        /// </summary>
        [Column(Order = 97)]
        public string CreatedBy { get; set; } = String.Empty;

        /// <summary>
        /// Log Modified date of the row
        /// </summary>
        [Column(Order = 98)]
        public Nullable<DateTime> ModifyDate { get; set; } = null;

        /// <summary>
        /// Log modified by user of the row
        /// </summary>
        [Column(Order = 99)]
        public string ModifyBy { get; set; } = null;

        /// <summary>
        ///Returns the Entity name
        ///</summary>
        ///<returns>The Entity name</returns>
        public string WhatsMyNameAgain()
        {            
            return this.GetType().Name.ToString().Split('_')[0];
        }

        /// <summary>
        ///Copy the values from a Entity to this entity.
        ///This thecnic saves time when the entity has been modified and need to reflect those changes on the entity framework context.
        ///</summary>
        ///<param name="Entity">Entity from where values are copy</param>
        public void CopyValuesFrom(BaseEntity Entity)
        {         
            Type typeB = Entity.GetType();
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                if (property.Name.Equals("Id") || property.Name.Equals("IsDeleted") || property.Name.Equals("CreatedDate") || property.Name.Equals("CreatedBy") || property.Name.Equals("ModifyDate") || property.Name.Equals("ModifyBy"))
                    continue;
                if (!property.CanRead || (property.GetIndexParameters().Length > 0))
                    continue;
                PropertyInfo other = typeB.GetProperty(property.Name);
                if ((other != null) && (other.CanWrite))
                {
                    if (!IsSimple(property.PropertyType))
                        continue;
                    property.SetValue(this, other.GetValue(Entity, null), null);
                }
            }
        }

        /// <summary>
        /// Verifica si el campo es simple, es decir no es un objeto, ya que la funcion
        /// de CopyValuesFrom unicamente copia valores mapeados a la base de datos, no sus relaciones.
        /// </summary>
        /// <param name="type">Tipo de variable</param>
        /// <returns>True si es simple, false si no</returns>
        private bool IsSimple(Type type)
        {
            if (Nullable.GetUnderlyingType(type) != null)
                return true;
            return type.IsPrimitive 
                || type.IsEnum 
                || type.Equals(typeof(string)) 
                || type.Equals(typeof(decimal)) 
                || type.Equals(typeof(DateTime)) 
                || type.Equals(typeof(long)) 
                || type.Equals(typeof(int));
        }


    }
}
