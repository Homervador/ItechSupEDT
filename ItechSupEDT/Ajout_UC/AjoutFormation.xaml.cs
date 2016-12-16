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
using System.Data.SqlClient;
using ItechSupEDT.Outils;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutFormation.xaml
    /// </summary>

    public partial class AjoutFormation : UserControl
    {
        public AjoutFormation()
        {
            InitializeComponent();
            this.sp_valider.Visibility = Visibility.Collapsed;
        }

        public AjoutFormation(Formation _formation)
        {
            tb_nomFormation.Text = _formation.Nom;
            tb_dureeFormation.Text = _formation.NbHeuresTotal.ToString();
        }


        private void btn_ajoutFormation_Click(object sender, RoutedEventArgs e)
        {
           
            String nom = tb_nomFormation.Text;
            String nbHeureStr = tb_dureeFormation.Text;
            float nbHeuresStr;

            if (this.tb_nomFormation.Text != "" && this.tb_dureeFormation.Text != "")
            {
                if (!float.TryParse(nbHeureStr, out nbHeuresStr))
                {
                    tbk_errorMessage.Text += "Format heure incorrect, veuillez-saisir un nombre";
                }
                else
                {
                    try
                    {
                        nbHeuresStr = float.Parse(nbHeureStr);
                        FormationDAO.CreeFormation(nom, nbHeuresStr);
                        this.tbk_errorMessage.Text = "";
                        this.tbk_errorMessage.Visibility = Visibility.Collapsed;
                        this.tb_nomFormation.Text = "";
                        this.tb_dureeFormation.Text = "";
                        this.tbk_retourMessage.Text = "Formation ajoutée";
                        this.sp_valider.Visibility = Visibility.Visible;
                        this.sp_Ajout.Visibility = Visibility.Collapsed;
                    }
                    catch (Exception ex)
                    {
                        tbk_errorMessage.Text = "Une erreur est survenu lors de l'ajout, veuillez vérifier les information";
                        Console.WriteLine(tbk_errorMessage);
                    }
                }
            }
            else
            {
                this.tbk_errorMessage.Text = "L'un des champs n'est pas renseigné";
                this.tbk_errorMessage.Visibility = Visibility.Visible;
                return;
            }
        }
        private void btn_nouveau_Click(object sender, RoutedEventArgs e)
        {
            this.sp_valider.Visibility = Visibility.Collapsed;
            this.sp_Ajout.Visibility = Visibility.Visible;
        }
    }
}
