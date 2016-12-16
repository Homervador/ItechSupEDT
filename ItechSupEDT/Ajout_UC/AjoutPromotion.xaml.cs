using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ItechSupEDT.Modele;
using ItechSupEDT.Ajout_UC;
using System.Data.SqlClient;
using ItechSupEDT.Outils;
using System.Data;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutPromotion.xaml
    /// </summary>
    public partial class AjoutPromotion : UserControl
    {
        private Dictionary<String, Formation> lstFormations;
        public Dictionary<String, Formation> LstFormations
        {
            get { return this.lstFormations; }
            set { this.lstFormations = value; }
        }
        public AjoutPromotion(List<Formation> _lstFormations, List<MultiSelectedObject> _lstEleve)
        {
            InitializeComponent();

            this.LstFormations = new Dictionary<string, Formation>();
            if (_lstFormations.Count > 0)
            {
                foreach (Formation formation in _lstFormations)
                {
                    this.LstFormations.Add(formation.Nom, formation);
                }
                this.cb_lstFormations.ItemsSource = this.LstFormations.Keys;
                this.cb_lstFormations.SelectedIndex = 0;
            }
            MutliSelectPickList multiSelect = new MutliSelectPickList(_lstEleve);
            this.MultiSelect.Content = multiSelect;
            this.sp_valider.Visibility = Visibility.Collapsed;
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand insertPromotion;
            String nom = tb_nom.Text;
            DateTime? dateDebut = dp_dateDebut.SelectedDate;
            DateTime? dateFin = dp_dateFin.SelectedDate;

            if (this.tb_nom.Text == "")
            {
                this.tbk_error.Text = "Le nom de la promotion est vide.";
                this.tbk_error.Visibility = Visibility.Visible;
                return;
            }

            else
            {
                try
                {
                    insertPromotion = new SqlCommand();
                    insertPromotion.CommandText = "INSERT INTO Promotion (nom, dateDebout, dateFin) VALUES (@nom, @dateDebut, @dateFin)";
                    insertPromotion.CommandType = CommandType.Text;
                    insertPromotion.Connection = ConnexionBase.GetInstance().Conn;

                    SqlParameter nomparam = new SqlParameter("nom", SqlDbType.VarChar);
                    nomparam.Value = nom;
                    SqlParameter dateDebutparam = new SqlParameter("dateDebut", SqlDbType.DateTime);
                    dateDebutparam.Value = dateDebut;
                    SqlParameter dateFinparam = new SqlParameter("dateFin", SqlDbType.DateTime);
                    dateFinparam.Value = dateFin;

                    insertPromotion.Parameters.Add(nomparam);
                    insertPromotion.Parameters.Add(dateDebutparam);
                    insertPromotion.Parameters.Add(dateFinparam);

                    insertPromotion.ExecuteReader();
                }
                catch (Exception)
                {
                    tbk_error.Text = "Une erreur est survenu lors de l'ajout, veuillez vérifier les information";
                    Console.WriteLine(tbk_error);
                }
                this.tb_nom.Text = "";
                this.dp_dateDebut = null;
                this.dp_dateFin = null;
                this.tbk_retourMessage.Text = "Promotion ajoutée";
                this.sp_valider.Visibility = Visibility.Visible;
                this.sp_Ajout.Visibility = Visibility.Collapsed;
            }
            
        }
        private void btn_nouveau_Click(object sender, RoutedEventArgs e)
        {
            this.sp_valider.Visibility = Visibility.Collapsed;
            this.sp_Ajout.Visibility = Visibility.Visible;
        }
    }
}
