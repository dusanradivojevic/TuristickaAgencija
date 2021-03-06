﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IDomenskiObjekat
    {
        string NazivTabele { get; }
        string VrednostiZaInsert { get; }
        string VrednostZaUpdate { get; }
        string KriterijumiZaPretragu { get; }
        string PrimarniKljuc { get; } 
        IDictionary Kriterijumi { get; set; }

        List<IDomenskiObjekat> VratiListu(SqlDataReader reader);
        IDomenskiObjekat VratiPodDomen();
        void PostaviVrednost(IDomenskiObjekat ido);
        void PostaviVrednostPodDomena(IDomenskiObjekat ido);
        bool AdekvatnoPopunjen();
        string UslovFiltera();
    }
}
