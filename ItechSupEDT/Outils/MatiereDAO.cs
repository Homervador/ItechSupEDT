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
    class MatiereDAO
    {
        public static Matiere CreeMatiere(string nom)
        {
            SqlCommand cdm = new SqlCommand();
            cdm.CommandText = "INSERT INTO Matiere (nom) VALUES (@nom); SELECT SCOPE_IDENTITY();";
            cdm.CommandType = CommandType.Text;
            cdm.Connection = ConnexionBase.GetInstance().Conn;
            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;

            cdm.Parameters.Add(nomParam);

            SqlDataReader reader = cdm.ExecuteReader();
            reader.Read();
            int id = (int)reader.GetDecimal(0);

            Matiere nv_Matiere = new Matiere(id, nom);

            return nv_Matiere;
        }
    }
}
