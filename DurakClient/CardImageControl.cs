using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DurakLibrary;

namespace DurakClient
{
    class CardImageControl : UserControl
    {

        #region Component Designer generated code
        //Component Designer Generated Code 
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox PictureBoxControl;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.PictureBoxControl = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxControl)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBoxControl
            // 
            this.PictureBoxControl.Image = global::DurakClient.Properties.Resources.FaceDown;
            this.PictureBoxControl.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxControl.Name = "PictureBoxControl";
            this.PictureBoxControl.Size = new System.Drawing.Size(71, 96);
            this.PictureBoxControl.TabIndex = 0;
            this.PictureBoxControl.TabStop = false;
            this.PictureBoxControl.Click += new System.EventHandler(this.PictureBoxControl_Click);
            // 
            // CardImageControl
            // 
            this.Controls.Add(this.PictureBoxControl);
            this.Name = "CardImageControl";
            this.Size = new System.Drawing.Size(71, 96);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
               
        //declare new card object and even handler
        private Card card = new Card();
        public event EventHandler CardClicked;
        
        //generates starting of the card image control
        public CardImageControl()
        {
            InitializeComponent();
           StartingCardImage();
        }
              
        //get and set a card object, based on the card value update the card image
        public Card Card
        {
            get {
                return card;
            }
            set
            {
                card = value;
                UpdateCardImage();
            }
        }
         
       //returns the card suit enumeration
        public CardSuitsEnum getSuitEnum()
        {
                return card.getCardSuit();  
        }

        //returns the card rank enumeration
        public CardRanksEnum getRankEnum()
        {
            return card.getCardRank();
        }

        //starting card image is face down
        //Within resources get object(filename) and return to update the picture box image
        private void StartingCardImage()
        {
            string fileName = "FaceDown";
            PictureBoxControl.Image = (Image)Properties.Resources.ResourceManager.GetObject(fileName);
            PictureBoxControl.Refresh();
        }

        //will update the card image based on card string as filename. 
        //Within resources get object(filename) and return to update the picture box image
        private void UpdateCardImage()
        {
            string fileName = "";

            fileName = Convert.ToString(getSuitEnum()).Substring(0, 1).ToLower() + (int)getRankEnum();

            PictureBoxControl.Image = (Image)Properties.Resources.ResourceManager.GetObject(fileName);
            PictureBoxControl.Refresh();
        }

        //Delegate
        protected virtual void OnCardClicked(EventArgs e)
        {
            if (CardClicked != null)
                CardClicked(this, e);
        }

        //raises the card click event when the picture box is clicked
        private void PictureBoxControl_Click(object sender, EventArgs e)
        {
            OnCardClicked(EventArgs.Empty); // Raise card clicked event
        }



    }
 
 }

