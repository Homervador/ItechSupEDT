using ItechSupEDT.Modele;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    class FormationDAO
    {

        public static Formation CreeFormation(string nom, float nbHeureStr)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO formation (nom, nbHeureTotale) VALUES (@nom,@duree); SELECT SCOPE_IDENTITY();";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConnexionBase.GetInstance().Conn;
            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;
            SqlParameter dureeParam = new SqlParameter("duree", SqlDbType.Float);
            dureeParam.Value = nbHeureStr;

            cmd.Parameters.Add(nomParam);
            cmd.Parameters.Add(dureeParam);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int id = (int)reader.GetDecimal(0);

            Formation nv_Formation = new Formation(id, nom, nbHeureStr);

            return nv_Formation;
        }
    }
}
