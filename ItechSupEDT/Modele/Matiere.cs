﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Matiere
    {
        private String nom;
        private List<Formation> lstFormations;
        private List<Session> lstSessions;
        private List<Formateur> lstFormateurs;
        public String Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public List<Formation> LstMatire
        {
            get { return this.lstFormations; }
            set { this.lstFormations = value; }
        }
        public List<Session> LstSessions
        {
            get { return this.lstSessions; }
            set { this.lstSessions = value; }
        }
        public List<Formateur> LstFormateurs
        {
            get { return this.lstFormateurs; }
            set { this.lstFormateurs = value; }
        }
        public Matiere(String _nom)
        {
            this.Nom = _nom;
            this.LstSessions = new List<Session>();
            this.LstFormateurs = new List<Formateur>();
            this.lstFormations = new List<Formation>();
        }
    }
}
