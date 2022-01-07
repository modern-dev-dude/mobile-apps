using System;
using Xamarin.Forms;
using System.Collections;

namespace calc_rpn
{
    public partial class MainPage : ContentPage
    {
        Stack rpnNumStack = new Stack();
        Entry textVAl;
       
        public MainPage()
        {
            InitializeComponent();

            this.Padding = new Thickness(20, 20, 20, 20);

           
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

            this.panel.Children.Add(btnGrid);
            // to test stack count to ensure it is loading properly
            this.panel.Children.Add(textVAl = new Entry
            {
                Text = rpnNumStack.Count.ToString(),
            });

        }

        private void AddItemToStack(object sender, EventArgs e) {
            string btnVal = (sender as Button).Text;
            rpnNumStack.Push('1');
            textVAl.Text = rpnNumStack.Count.ToString();
            return;
        }
    }

}
