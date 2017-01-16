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
    class PromotionDAO
    {
        public static Promotion CreePromotion(string nom, DateTime dateDebut, DateTime dateFin, Formation formation)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Promotion (nom, dateDebut, dateFin, formation_id) VALUES (@nom, @dateDebut, @dateFin, @formation_id); SELECT SCOPE_IDENTITY();";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConnexionBase.GetInstance().Conn;
            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;
            SqlParameter dateDebutParam = new SqlParameter("dateDebut", SqlDbType.DateTime);
            dateDebutParam.Value = dateDebut;
            SqlParameter dateFinParam = new SqlParameter("dateFin", SqlDbType.DateTime);
            dateFinParam.Value = dateFin;
            SqlParameter id_formationParam = new SqlParameter("formation_id", SqlDbType.Int);
            id_formationParam.Value = formation.Id;

            cmd.Parameters.Add(nomParam);
            cmd.Parameters.Add(dateDebutParam);
            cmd.Parameters.Add(dateFinParam);
            cmd.Parameters.Add(id_formationParam);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int id = (int)reader.GetDecimal(0);

            Promotion nv_Promotion = new Promotion(id, nom, dateDebut, dateFin, formation);

            return nv_Promotion;
        }
    }
}
