using System;
using ItechSupEDT.Modele;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    class FormateurDAO
    {
        public static Formateur CreeFormateur(string nom, string prenom, string mail, string telephone, List<Modele.Matiere> listeMatiere)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Formateur (nom, prenom, mail, telephone) VALUES (@nom, @prenom, @mail, @telephone) SELECT SCOPE_IDENTITY();";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConnexionBase.GetInstance().Conn;
            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;
            SqlParameter prenomParam = new SqlParameter("prenom", SqlDbType.VarChar);
            prenomParam.Value = prenom;
            SqlParameter mailParam = new SqlParameter("mail", SqlDbType.VarChar);
            mailParam.Value = mail;
            SqlParameter telephoneParam = new SqlParameter("telephone", SqlDbType.VarChar);
            telephoneParam.Value = telephone;
            SqlParameter matiere_idParam = new SqlParameter("matiere_id", SqlDbType.Int);
            matiere_idParam.Value = listeMatiere.Id;

            cmd.Parameters.Add(nomParam);
            cmd.Parameters.Add(prenomParam);
            cmd.Parameters.Add(mailParam);
            cmd.Parameters.Add(telephoneParam);
            cmd.Parameters.Add(matiere_idParam);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int id = (int)reader.GetDecimal(0);

            Formateur nv_Formateur = new Formateur(id, nom, prenom, mail, telephone, listeMatiere);

            return nv_Formateur;
        }
    }
    
}
