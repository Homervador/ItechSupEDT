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

        public static List<Formation> RecupererFormations()
        {
            List<Formation> listFormation = new List<Formation>();
            int id;
            string nom;
            float nbHeureTotale;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT id, nom, nbHeureTotale FROM Formation";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConnexionBase.GetInstance().Conn;
            

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    nom = reader.GetString(1);
                    nbHeureTotale = reader.GetFloat(2);
                    Formation formation = new Formation(id, nom, nbHeureTotale);
                    listFormation.Add(formation);
                }

            }
            return listFormation;
        }
    }
}
