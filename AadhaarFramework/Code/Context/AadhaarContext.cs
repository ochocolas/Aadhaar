
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using AadhaarFramework.Code.Data.Entity.Common;
using AadhaarFramework.Code.Data.Entity.People;
using AadhaarFramework.Code.Data.Entity.Process;
using AadhaarFramework.Code.Data.Entity.Report;
using AadhaarFramework.Code.Data.Entity.Security;
/// <summary>
/// Database communication class for Aadhaar, it wraps all Entity framework communication.
/// If used for web app, the default behavior is for Web.
/// If you need to use it within the framework definition for development or for desktop development
/// change it on runtime.
/// </summary>
public class AadhaarContext : DbContext
{
    /// <summary>
    /// Constant for Web usage session variable.
    /// </summary>
    public const string SESSION_USUARIO_LOGEADO = "SESSION_USUARIO_LOGEADO";
    /// <summary>
    /// This property determine the behavior of the fill audit and the Public Property UsuarioLogueado.
    /// </summary>
    public enum EnviromentType

    {
        FRAMEWORK,
        WEB,
        DESKTOP,
    }
    /// <summary>
    /// Current user session information
    /// </summary>
    private static User _UsuarioLogeado = null;
    /// <summary>
    /// By default is Web, if you import the DLL from a:
    /// Desktop     project - Change it to DESKTOP
    /// Web         project - Change it to WEB
    /// Framework   project - Change it to FRAMEWORK
    /// </summary>
    public static EnviromentType Enviroment { get; set; } = EnviromentType.WEB;
    //public static string FrameworkUsuarioLogueado {get; set;}   
    /// <summary>
    /// This property should store the current logged User information.
    /// It behaves diffently based on the property this.Enviroment.
    /// See description of this.Enviroment
    /// </summary>
    public static User UsuarioLogueado
    {
        get
        {
            object o = null;
            switch (Enviroment)
            {
                case EnviromentType.FRAMEWORK:
                    o = _UsuarioLogeado;
                    break;
                case EnviromentType.WEB:
                    o = HttpContext.Current.Session[SESSION_USUARIO_LOGEADO];
                    break;
                case EnviromentType.DESKTOP:
                    o = _UsuarioLogeado;
                    break;
                default:
                    break;
            }


            if (o == null)
                return null;
            User u = new User();
            {
                User temp = o as User;
                
                u.Id = temp.Id;
                u.UserName = temp.UserName;
                u.FirstName = temp.FirstName;
                u.MiddleName = temp.MiddleName;
                u.LastName = temp.LastName;

            }
            return u;
        }
        set
        {

            switch (Enviroment)
            {
                case EnviromentType.FRAMEWORK:
                    _UsuarioLogeado = value;
                    break;
                case EnviromentType.WEB:
                    HttpContext.Current.Session[SESSION_USUARIO_LOGEADO] = value;
                    break;
                case EnviromentType.DESKTOP:
                    _UsuarioLogeado = value;
                    break;
                default:
                    break;
            }
            
            //if (value == null)
                //return;
            //HttpContext.Current.Session[UsuarioProvider.SESSION_ID_USUARIO] = value.Id;
        }
    }
    /// <summary>
    /// Creates database table CountryZone
    /// </summary>
    public virtual DbSet<CountryZone> CountryZone { get; set; }
    /// <summary>
    /// Creates database table Eye
    /// </summary>
    public virtual DbSet<Eye> Eye { get; set; }
    /// <summary>
    /// Creates database table Fingerprint
    /// </summary>
    public virtual DbSet<FingerPrint> FingerPrint { get; set;}
    /// <summary>
    /// Creates database table GEnder
    /// </summary>
    public virtual DbSet<Gender> Gender { get; set; }
    /// <summary>
    /// Creates database table Language
    /// </summary>
    public virtual DbSet<Language> Language { get; set; }
    /// <summary>
    /// Creates database table Person
    /// </summary>
    public virtual DbSet<Person> Person { get; set; }
    /// <summary>
    /// Creates database table Photography
    /// </summary>
    public virtual DbSet<Photography> Photography { get; set; }
    /// <summary>
    /// Creates database table Religion
    /// </summary>
    public virtual DbSet<Religion> Religion { get; set; }
    /// <summary>
    /// Creates database table State
    /// </summary>
    public virtual DbSet<State> State { get; set; }
    /// <summary>
    /// Creates database table Enroller
    /// </summary>
    public virtual DbSet<Enroller> Enroller { get; set; }
    /// <summary>
    /// Creates database table Rol
    /// </summary>
    public virtual DbSet<Rol> Rol { get; set; }
    /// <summary>
    /// Creates database table CountryZone
    /// </summary>
    public virtual DbSet<User> User { get; set; }
    /// <summary>
    /// Creates database view vwPopulation 
    /// </summary>
    public virtual DbSet<vwPopulation> vwPopulation { get; set; }
    /// <summary>
    /// Enpty constructor
    /// </summary>
    public AadhaarContext(){}

    /// <summary>
    /// Overrides and set the model creation conventions.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(9, 6));
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
    }

    /// <summary>
    /// Overrides the base Savechanges so it always fills the Audit fields of every table
    /// </summary>
    /// <returns></returns>
    public override int SaveChanges()
    {
        FillAudit();
        return base.SaveChanges();
    }

    /// <summary>
    /// Fill audit fields
    /// </summary>
    private void FillAudit()
    {
        DateTime FechaHora = DateTime.Now;
        List<DbEntityEntry> changes = ChangeTracker.Entries().ToList();
        foreach (DbEntityEntry change in changes)
        {
            if (change.State == EntityState.Added)
            {
                BaseEntity Entity = change.Entity as BaseEntity;
                if (Entity != null)
                {
                    if (Entity.CreatedDate == null)
                        Entity.CreatedDate = FechaHora;

                    switch (Enviroment)
                    {
                        case EnviromentType.FRAMEWORK:
                            Entity.CreatedBy = "sys_admin";
                            break;
                        case EnviromentType.WEB:
                            Entity.CreatedBy = AadhaarContext.UsuarioLogueado.UserName;
                            break;
                        case EnviromentType.DESKTOP:
                            Entity.CreatedBy = AadhaarContext.UsuarioLogueado.UserName;
                            break;
                        default:
                            break;
                    }                    

                }
            }
            else if (change.State == EntityState.Modified)
            {
                BaseEntity Entity = change.Entity as BaseEntity;
                if (Entity != null)
                {
                    
                    if (Entity.ModifyDate == null)
                        Entity.ModifyDate = FechaHora;
                    switch (Enviroment)
                    {
                        case EnviromentType.FRAMEWORK:
                            Entity.ModifyBy = "sys_admin";
                            break;
                        case EnviromentType.WEB:
                            Entity.ModifyBy = AadhaarContext.UsuarioLogueado.UserName;
                            break;
                        case EnviromentType.DESKTOP:
                            Entity.ModifyBy = AadhaarContext.UsuarioLogueado.UserName;
                            break;
                        default:
                            break;
                    }
                    
                }
            }
            else if (change.State == EntityState.Deleted)
            {
                BaseEntity Entity = change.Entity as BaseEntity;
                Entity.IsDeleted = true;
                change.State = EntityState.Modified;

            }
        }
    }

}