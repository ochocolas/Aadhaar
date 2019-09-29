using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using AadhaarFramework.Code.Data.Entity.Common;



namespace AadhaarFramework.Code.Data.Entity.People
{
    /// <summary>
    /// States of India
    /// </summary>
    public class State:SimpleCatalogEntity
    {
        /// <summary>
        /// Initial catalog data
        /// </summary>
        public static readonly List<State> States = new List<State>()
        { new State{ Id= 1   , Name = "	Andhra Pradesh	",Latitud = 15.91m, Longitud = 79.74m, Area =   160205  , Capital = "	Hyderabad	", IdCountryZone=   2   , IdOfficialLanguage=   15  , IsDeleted=false, Population = 49506799    }
        , new State{ Id=    2   , Name = "	Arunachal Pradesh	",Latitud = 28.21m, Longitud = 94.72m, Area =   83743   , Capital = "	Itanagar	", IdCountryZone=   5   , IdOfficialLanguage=   3   , IsDeleted=false, Population = 1383727     }
        , new State{ Id=    3   , Name = "	Assam	",Latitud = 26.20m, Longitud = 92.93m, Area =   78550   , Capital = "	Dispur	", IdCountryZone=   5   , IdOfficialLanguage=   1   , IsDeleted=false, Population = 31205576    }
        , new State{ Id=    4   , Name = "	Bihar	",Latitud = 25.09m, Longitud = 85.31m, Area =   94163   , Capital = "	Patna	", IdCountryZone=   4   , IdOfficialLanguage=   5   , IsDeleted=false, Population = 104099452   }
        , new State{ Id=    5   , Name = "	Chhattisgarh	",Latitud = 21.27m, Longitud = 81.86m, Area =   135194  , Capital = "	Raipur	", IdCountryZone=   7   , IdOfficialLanguage=   5   , IsDeleted=false, Population = 25545198    }
        , new State{ Id=    6   , Name = "	Goa	",Latitud = 15.29m, Longitud = 74.12m, Area =   3702    , Capital = "	Panaji	", IdCountryZone=   3   , IdOfficialLanguage=   7   , IsDeleted=false, Population = 1458545     }
        , new State{ Id=    7   , Name = "	Gujarat	",Latitud = 22.25m, Longitud = 71.19m, Area =   196024  , Capital = "	Gandhinagar	", IdCountryZone=   3   , IdOfficialLanguage=   4   , IsDeleted=false, Population = 60439692    }
        , new State{ Id=    8   , Name = "	Haryana	",Latitud = 29.05m, Longitud = 76.08m, Area =   44212   , Capital = "	Chandigarh	", IdCountryZone=   1   , IdOfficialLanguage=   5   , IsDeleted=false, Population = 25351462    }
        , new State{ Id=    9   , Name = "	Himachal Pradesh	",Latitud = 31.10m, Longitud = 77.17m, Area =   55673   , Capital = "	Shimla	", IdCountryZone=   1   , IdOfficialLanguage=   5   , IsDeleted=false, Population = 6864602     }
        , new State{ Id=    10  , Name = "	Jammu and Kashmir	",Latitud = 33.77m, Longitud = 76.57m, Area =   222236  , Capital = "	Jammu	", IdCountryZone=   1   , IdOfficialLanguage=   16  , IsDeleted=false, Population = 12541302    }
        , new State{ Id=    11  , Name = "	Jharkhand	",Latitud = 23.61m, Longitud = 85.27m, Area =   74677   , Capital = "	Ranchi	", IdCountryZone=   4   , IdOfficialLanguage=   5   , IsDeleted=false, Population = 32988134    }
        , new State{ Id=    12  , Name = "	Karnataka	",Latitud = 15.31m, Longitud = 75.71m, Area =   191791  , Capital = "	Bengaluru	", IdCountryZone=   2   , IdOfficialLanguage=   6   , IsDeleted=false, Population = 61095297    }
        , new State{ Id=    13  , Name = "	Kerala	",Latitud = 10.85m, Longitud = 76.27m, Area =   38863   , Capital = "	Thiruvananthapuram	", IdCountryZone=   2   , IdOfficialLanguage=   8   , IsDeleted=false, Population = 33406061    }
        , new State{ Id=    14  , Name = "	Madhya Pradesh	",Latitud = 22.97m, Longitud = 78.65m, Area =   308252  , Capital = "	Bhopal	", IdCountryZone=   7   , IdOfficialLanguage=   5   , IsDeleted=false, Population = 72626809    }
        , new State{ Id=    15  , Name = "	Maharashtra	",Latitud = 19.75m, Longitud = 75.71m, Area =   307713  , Capital = "	Mumbai	", IdCountryZone=   3   , IdOfficialLanguage=   9   , IsDeleted=false, Population = 112374333   }
        , new State{ Id=    16  , Name = "	Manipur	",Latitud = 24.66m, Longitud = 93.90m, Area =   22347   , Capital = "	Imphal	", IdCountryZone=   5   , IdOfficialLanguage=   10  , IsDeleted=false, Population = 2855794     }
        , new State{ Id=    17  , Name = "	Meghalaya	",Latitud = 25.46m, Longitud = 91.36m, Area =   22720   , Capital = "	Shillong	", IdCountryZone=   5   , IdOfficialLanguage=   3   , IsDeleted=false, Population = 2966889     }
        , new State{ Id=    18  , Name = "	Mizoram	",Latitud = 23.16m, Longitud = 92.93m, Area =   21081   , Capital = "	Aizawl	", IdCountryZone=   5   , IdOfficialLanguage=   3   , IsDeleted=false, Population = 1097206     }
        , new State{ Id=    19  , Name = "	Nagaland	",Latitud = 26.15m, Longitud = 94.56m, Area =   16579   , Capital = "	Kohima	", IdCountryZone=   5   , IdOfficialLanguage=   3   , IsDeleted=false, Population = 1978502     }
        , new State{ Id=    20  , Name = "	Odisha	",Latitud = 20.95m, Longitud = 85.09m, Area =   155820  , Capital = "	Bhubaneswar	", IdCountryZone=   4   , IdOfficialLanguage=   12  , IsDeleted=false, Population = 41974218    }
        , new State{ Id=    21  , Name = "	Punjab	",Latitud = 31.14m, Longitud = 75.34m, Area =   50362   , Capital = "	Chandigarh	", IdCountryZone=   1   , IdOfficialLanguage=   13  , IsDeleted=false, Population = 27743338    }
        , new State{ Id=    22  , Name = "	Rajasthan	",Latitud = 27.02m, Longitud = 74.21m, Area =   342269  , Capital = "	Jaipur	", IdCountryZone=   1   , IdOfficialLanguage=   5   , IsDeleted=false, Population = 68548437    }
        , new State{ Id=    23  , Name = "	Sikkim	",Latitud = 27.53m, Longitud = 88.51m, Area =   7096    , Capital = "	Gangtok	", IdCountryZone=   5   , IdOfficialLanguage=   11  , IsDeleted=false, Population = 610577  }
        , new State{ Id=    24  , Name = "	Tamil Nadu	",Latitud = 11.12m, Longitud = 78.65m, Area =   130058  , Capital = "	Chennai	", IdCountryZone=   2   , IdOfficialLanguage=   14  , IsDeleted=false, Population = 72147030    }
        , new State{ Id=    25  , Name = "	Telangana	",Latitud = 18.11m, Longitud = 79.0193m, Area =   114840  , Capital = "	Hyderabad	", IdCountryZone=   2   , IdOfficialLanguage=   15  , IsDeleted=false, Population = 35193978  }
        , new State{ Id=    26  , Name = "	Tripura	",Latitud = 23.94m, Longitud = 91.98m, Area =   10492   , Capital = "	Agartala	", IdCountryZone=   5   , IdOfficialLanguage=   2   , IsDeleted=false, Population = 3673917     }
        , new State{ Id=    28  , Name = "	Uttarakhand	",Latitud = 30.06m, Longitud = 79.01m, Area =   53483   , Capital = "	Dehradun	", IdCountryZone=   7   , IdOfficialLanguage=   5   , IsDeleted=false, Population = 10086292    }
        , new State{ Id=    27  , Name = "	Uttar Pradesh	",Latitud = 26.84m, Longitud = 80.94m, Area =   243286  , Capital = "	Lucknow	", IdCountryZone=   7   , IdOfficialLanguage=   5   , IsDeleted=false, Population = 199812341   }
        , new State{ Id=    29  , Name = "	West Bengal	",Latitud = 22.98m, Longitud = 87.85m, Area =   88752   , Capital = "	Kolkata	", IdCountryZone=   4   , IdOfficialLanguage=   2   , IsDeleted=false, Population = 91276115    }



        };

        /// <summary>
        /// Capital of the state.
        /// </summary>
        public string Capital { get; set; }
        /// <summary>
        /// Land area of the state.
        /// </summary>
        public int Area { get; set; }
        /// <summary>
        /// Population of the state.
        /// </summary>
        public int Population { get; set; }
        /// <summary>
        /// Latitud, for maps
        /// </summary>
        public decimal Latitud { get; set; }
        /// <summary>
        /// Longitud for maps.
        /// </summary>
        public decimal Longitud { get; set; }
        /// <summary>
        /// Official language.
        /// </summary>
        public long IdOfficialLanguage { get; set; }
        /// <summary>
        /// Country zone of the state
        /// </summary>
        public long IdCountryZone { get; set; }

        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdOfficialLanguage")]
        public Language OfficialLanguage { get; set; }
        /// <summary>
        /// Navigation entity (entity framework)
        /// </summary>
        [ForeignKey("IdCountryZone")]
        public CountryZone CountryZone { get; set; }

    }
}
