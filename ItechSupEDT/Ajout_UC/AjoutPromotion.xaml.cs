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
        }
    }
}
