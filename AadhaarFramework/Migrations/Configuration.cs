namespace AadhaarFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using AadhaarFramework.Code.Data.Entity.Security;
    using AadhaarFramework.Code.Data.Entity.People;
    using AadhaarFramework.Code.Data.Providers.Security;
    using AadhaarFramework.Code.Data.Providers.People;
    using AadhaarFramework.Code.Data.Providers.Process;
    using AadhaarFramework.Code.Data.Providers.Common;
    using System.Linq;
    using AadhaarFramework.Code.Data.Entity.Process;
    using System.Reflection;
    using System.IO;
    /// <summary>
    /// Configuration class for migrations since we are using Code first approach
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<AadhaarContext>
    {
        /// <summary>
        /// Query statement for creating sequences.
        /// </summary>
        private const string SEQUENCE_STATEMENT = "CREATE SEQUENCE [dbo].[s{0}]  START WITH {1} INCREMENT BY 1";
        /// <summary>
        /// Query statement that check if a sequence exist.
        /// </summary>
        private const string SEQUENCE_CHECK_IF_EXIST = "SELECT Count(*) FROM sys.objects WHERE [name] = 's{0}' And type = 'SO'";
        //private const long PERSON_COUNT = 100000;

        /// <summary>
            /// This is the number of persons that the system will generate test datas
            /// </summary>
        private const long PERSON_COUNT = 1000;
        //private const int ENROLLER_COUNT = 100000;
        /// <summary>
        /// this is the number of enrollers that the system will generate data for.
        /// </summary>
        private const int ENROLLER_COUNT = 100;
        #region "Valores de prueba para el prototipo"
        /// <summary>
        /// List of entities that need sequence to be created
        /// </summary>
        private readonly string[] Entidades = new string[] { "CountryZone"
                                                   ,"Eye"
                                                   ,"FingerPrint"
                                                   ,"Gender"
                                                   ,"Language"
                                                   //,"Person"
                                                   ,"Photography"
                                                   ,"Religion"
                                                   ,"State"
                                                   ,"Enroller"
                                                   ,"Rol"
                                                   ,"User"
                                                   ,"MenuAadhaar"
                                                  };
        /// <summary>
        /// Rol Names
        /// </summary>
        private readonly string[] NombreRoles = new string[]{"System administrator"
                                                                 ,"Administrator"
                                                                 ,"Report generator"
                                                                 ,"Enroller"
                                                                 ,"Supervisor"
                                                               };


        #endregion

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Seed method, fills the database with test data and initial data
        /// </summary>
        /// <param name="context">Context for database operations</param>
        protected override void Seed(AadhaarContext context)
        {

            //if (!System.Diagnostics.Debugger.IsAttached)
            //    System.Diagnostics.Debugger.Launch();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            AadhaarContext.Enviroment = AadhaarContext.EnviromentType.FRAMEWORK;

            CreateSequence(context);
            AddSecurity();
            AddContryZone();
            AddGender();
            AddLanguage();
            AddReligion();
            AddState();
            AddEnroller();
            AddPerson();
            context.SaveChanges();
            CreateViews(context);

        }
        /// <summary>
        /// Create the database views
        /// </summary>
        /// <param name="context">Context database</param>
        public void CreateViews(AadhaarContext context)
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            var baseDir = Path.GetDirectoryName(path) + "\\Migrations\\Scripts\\View\\vwPopulation.sql";

            context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir));
        }
        /// <summary>
        /// Create the database table sequences
        /// Primero verifica si ya existe, de lo contrario la crea
        /// </summary>
        /// <param name="context">Database context</param>
        private void CreateSequence(AadhaarContext context)
        {
            foreach (string entidad in Entidades)
            {
                int first = 1;
                if (entidad.Length == 0) { continue; }
                switch (entidad)
                {
                    case "CountryZone":
                        first = CountryZone.CountryZones.Length + 1;
                        break;
                    case "Gender":
                        first = Gender.Genders.Length + 1;
                        break;
                    case "Language":
                        first = Language.Languages.Length + 1;
                        break;
                    case "Religion":
                        first = Religion.Religions.Length + 1;
                        break;
                    case "State":
                        first = State.States.Count + 1;
                        break;
                    case "Enroller":
                        first = ENROLLER_COUNT + 1;
                        break;
                    case "Rol":
                        first = NombreRoles.Length + 1;
                        break;
                    case "User":
                        first = 1;
                        break;
                    default:
                        first = 1;
                        break;
                }
                string query = String.Format(SEQUENCE_CHECK_IF_EXIST, entidad);
                int Existe = context.Database.SqlQuery<int>(query).FirstOrDefault();
                if (Existe > 0) { continue; }

                string Statement = String.Format(SEQUENCE_STATEMENT, entidad, first.ToString());
                context.Database.ExecuteSqlCommand(Statement);
            }

        }
        /// <summary>
        /// Add system default user and rol
        /// </summary>
        private void AddSecurity()
        {
            Console.WriteLine("Adding security...");
            //Agrega usuario administrador
            User sys_admin = new User();
            sys_admin.Password = "sys_admin";
            sys_admin.UserName = "sys_admin";
            sys_admin.FirstName = "sys";
            sys_admin.MiddleName = "_";
            sys_admin.LastName = "admin";
            sys_admin.Id = 1;//El usuario de sistema siempre sera 1

            UserProvider up = new UserProvider();
            User Exist = null;
            Exist = up.GetById(sys_admin.Id);
            if (Exist == null)
                up.Save(sys_admin);

            //agrega Rol administrador del sistema
            Rol Rol = null;
            RolProvider rp = new RolProvider();
            for (int i = 0; i < NombreRoles.Length; i++)
            {
                Rol = new Rol();
                Rol.Id = i + 1;
                Rol.Name = NombreRoles[i];
                Rol RolExiste = rp.GetById(Rol.Id);
                if (RolExiste == null)
                    rp.Save(Rol);
            }

        }
        /// <summary>
        /// Add initial data 
        /// </summary>
        private void AddContryZone()
        {
            Console.WriteLine("Adding Country zones");
            CountryZone CountryZone = null;
            CountryZoneProvider CountryZoneProvider = new CountryZoneProvider();
            for (int i = 0; i < CountryZone.CountryZones.Length; i++)
            {
                CountryZone = new CountryZone();
                CountryZone.Id = i + 1;
                CountryZone.Name = CountryZone.CountryZones[i];
                CountryZone CountryZoneExiste = CountryZoneProvider.GetById(CountryZone.Id);
                if (CountryZoneExiste == null)
                    CountryZoneProvider.Save(CountryZone);

            }


        }
        /// <summary>
        /// Add initial data 
        /// </summary>
        private void AddGender()
        {
            Console.WriteLine("Adding genders.");
            Gender Gender = null;
            GenderProvider GenderProvider = new GenderProvider();
            for (int i = 0; i < Gender.Genders.Length; i++)
            {
                Gender = new Gender();
                Gender.Id = i + 1;
                Gender.Name = Gender.Genders[i];
                Gender GenderExist = GenderProvider.GetById(Gender.Id);
                if (GenderExist == null)
                    GenderProvider.Save(Gender);

            }
        }
        /// <summary>
        /// Add initial data 
        /// </summary>
        private void AddLanguage()
        {
            Console.WriteLine("Adding languages...");
            Language Language = null;
            LanguageProvider LanguageProvider = new LanguageProvider();
            for (int i = 0; i < Language.Languages.Length; i++)
            {
                Language = new Language();
                Language.Id = i + 1;
                Language.Name = Language.Languages[i];
                Language LanguageExiste = LanguageProvider.GetById(Language.Id);
                if (LanguageExiste == null)
                    LanguageProvider.Save(Language);

            }
        }
        /// <summary>
        /// Add initial data 
        /// </summary>
        private void AddReligion()
        {
            Console.WriteLine("Adding religions...");
            Religion Religion = null;
            ReligionProvider ReligionProvider = new ReligionProvider();
            for (int i = 0; i < Religion.Religions.Length; i++)
            {
                Religion = new Religion();
                Religion.Id = i + 1;
                Religion.Name = Religion.Religions[i];
                Religion ReligionExiste = ReligionProvider.GetById(Religion.Id);
                if (ReligionExiste == null)
                    ReligionProvider.Save(Religion);

            }
        }
        /// <summary>
        /// Add initial data 
        /// </summary>
        private void AddState()
        {
            Console.WriteLine("Adding states...");
            StateProvider StateProvider = new StateProvider();
            foreach (State State in State.States)
            {
                State StateExist = StateProvider.GetById(State.Id);
                State.Name = State.Name.Trim();
                if (StateExist == null)
                    StateProvider.Save(State);
            }
        }
        /// <summary>
        /// Add initial data 
        /// </summary>
        private void AddEnroller()
        {
            Console.WriteLine("Adding enrollers...");
            EnrollerProvider EnrollerProvider = new EnrollerProvider();
            Random rnd = new Random();
            for (int i = 0; i < ENROLLER_COUNT; i++)
            {
                //genera un nombre aleatorio para un enrollador                
                Enroller Enroller = new Enroller();
                string Name = String.Format(Enroller.Enrollers[rnd.Next(Enroller.Enrollers.Length)].Trim(), Person.Apellidos[rnd.Next(Person.Apellidos.Length)].Trim());
                Enroller.Id = i + 1;
                Enroller.Name = Name.Replace(System.Environment.NewLine, String.Empty).Trim();
                Enroller.IsEnabled = true;
                Enroller.Token = Guid.NewGuid().ToString();
                EnrollerProvider.Save(Enroller);
            }


        }
        /// <summary>
        /// Add initial data 
        /// </summary>
        private void AddPerson()
        {
            Console.WriteLine("Adding person...");
            PersonProvider PersonProvider = new PersonProvider();
            PhotographyProvider PhotographyProvider = new PhotographyProvider();
            EyeProvider EyeProvider = new EyeProvider();
            FingerPrintProvider FingerPrintProvider = new FingerPrintProvider();
            SequenceProvider SequenceProvider = new SequenceProvider();
            for (int i = 0; i < PERSON_COUNT; i++)
            {
                //Genero persona aleatoria
                Person Person = new Person();
                Person.GenerateRandomPerson();
                PersonProvider.Save(Person);

            }
        }
    }
}
