using System.Windows.Input;
using Xamarin.Forms;

namespace TestTotalTech.UserControl
{
    public class XListView : Xamarin.Forms.ListView
    {
        #region BindableProperty
        public static BindableProperty ItemSelectedCommandProperty = BindableProperty.Create("SelectedItemProperty", typeof(ICommand), typeof(XListView));
        public static BindableProperty ItemTappedCommandProperty = BindableProperty.Create("TappedCommandProperty", typeof(ICommand), typeof(XListView));
        #endregion

        #region constructor
        public XListView()
        {
            this.ItemSelected += Item_Selected;
            this.ItemTapped += Item_Tapped;
        }
        #endregion

        #region propiedades
        public ICommand ItemSelectedCommand
        {
            get
            {
                return (ICommand)this.GetValue(ItemSelectedCommandProperty);
            }
            set
            {
                this.SetValue(ItemSelectedCommandProperty, value);
            }
        }

        public ICommand ItemTappedCommand
        {
            get
            {
                return (ICommand)this.GetValue(ItemTappedCommandProperty);
            }
            set
            {
                this.SetValue(ItemTappedCommandProperty, value);
            }
        }

        #endregion

        #region eventos
        private void Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (this.ItemSelectedCommand != null)
            {
                this.ItemSelectedCommand.Execute(e);
            }
        }

        private void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            if (this.ItemTappedCommand != null)
            {
                this.ItemTappedCommand.Execute(e);
            }
        }
        #endregion

    }
}
