using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calc_rpn
{
    public partial class MainPage : ContentPage
    {
        Entry phoneNumberText;
        Button numOneBtn;
        Button numTwoBtn;
        Button callButton;
        int[] rpnArray= new int[] {};
        String eventString;
        public MainPage()
        {
            InitializeComponent();
            this.Padding = new Thickness(20, 20, 20, 20);

            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };
            StackLayout btnGrid = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing =5,
            };
            // Build Btn Grid
            for(int i = 1; i < 4; i++)
            {
               
                Button BtnToCreate = new Button
                {
                    Text = i.ToString(),
                    
                };
                BtnToCreate.Clicked += AddItemToStack;
                btnGrid.Children.Add(BtnToCreate);
         }
            
            
            




            panel.Children.Add(btnGrid);
            panel.Children.Add(phoneNumberText = new Entry
            {
                Text = "1-855-XAMARIN",
            });

            this.Content = panel;
        }


        private void AddItemToStack(object sender, EventArgs e) {
            phoneNumberText.Text = (sender as Button).Text;
            return;
        }
    }

}
