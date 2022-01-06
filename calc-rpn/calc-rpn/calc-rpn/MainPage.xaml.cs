using System;
using Xamarin.Forms;
using System.Collections;

namespace calc_rpn
{
    public partial class MainPage : ContentPage
    {
        Stack rpnNumStack = new Stack();

        public MainPage()
        {
            InitializeComponent();
            this.Padding = new Thickness(20, 20, 20, 20);


            StackLayout panel = new StackLayout
            {
                Spacing = 15
            };
            Grid btnGrid = new Grid();

            // Build Btn Grid
            int rowCount = 0;
            int colCount = 0;
            for (int i = 1; i < 10; i++)
             {
                 btnGrid.ColumnDefinitions.Add(new ColumnDefinition { Width =  75, });
                Button BtnToCreate = new Button
                {
                    Text = i.ToString(),
                };
                BtnToCreate.Clicked += AddItemToStack;
                BtnToCreate.SetValue(Grid.ColumnProperty, colCount);
                BtnToCreate.SetValue(Grid.RowProperty, rowCount);
                btnGrid.Children.Add(BtnToCreate);
                // increment row every 3 buttons and reset the col
                colCount++;
                if (i % 3 == 0)
                {
                    rowCount++;
                    colCount = 0;
                }
             }

            int textVAl = rpnNumStack.Count;
            panel.Children.Add(btnGrid);
            panel.Children.Add(new Entry
            {
                Text = textVAl.ToString(),
            });

            this.Content = panel;
        }


        private void AddItemToStack(object sender, EventArgs e) {
            string btnVal = (sender as Button).Text;
            rpnNumStack.Push('1');
            return;
        }
    }

}
