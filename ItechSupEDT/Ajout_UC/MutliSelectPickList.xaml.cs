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
using System.Collections.ObjectModel;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Logique d'interaction pour MutliSelectPickList.xaml
    /// </summary>
    public partial class MutliSelectPickList : UserControl 
    {
        private ObservableCollection<String> objectList;
        private ObservableCollection<String> lstNom;
        private List<MultiSelectedObject> maList;

        public List<MultiSelectedObject> MaList
        {
            get { return maList; }
            set { maList = value; }
        }

        /**private DependencyProperty multiSelectObject;

        public List<MultiSelectedObject> MultiSelectObject
        {
            get { return (List<MultiSelectedObject>)GetValue(multiSelectObject); }
            set { SetValue(multiSelectObject, value); }
        }**/
        public MutliSelectPickList(List<MultiSelectedObject> _maList)
        {
            InitializeComponent();
            objectList = new ObservableCollection<String>();
            lstNom = new ObservableCollection<String>();
            this.MaList = _maList;
            foreach(MultiSelectedObject objet in this.MaList)
            {
                this.objectList.Add(objet.getNom());
            }
            this.SetListview();
        }

        private void SetListview()
        {
            lv_listeObject.ItemsSource = this.objectList;
            lv_selectedObject.ItemsSource = this.lstNom;
        }

        private void btn_push_Click(object sender, RoutedEventArgs e)
        {
            if(lv_listeObject.SelectedItem != null)
            {
                lstNom.Add(lv_listeObject.SelectedItem.ToString());
                objectList.Remove(lv_listeObject.SelectedItem.ToString());
                this.SetListview();
            }
        }

        private void btn_pull_Click(object sender, RoutedEventArgs e)
        {
            if (lv_selectedObject.SelectedItem != null)
            {
                objectList.Add(lv_selectedObject.SelectedItem.ToString());
                lstNom.Remove(lv_selectedObject.SelectedItem.ToString());
                this.SetListview();
            }
        }
    }
}
