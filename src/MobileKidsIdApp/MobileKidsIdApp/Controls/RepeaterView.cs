using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MobileKidsIdApp
{
    // TODO: Replace with Xamarin.Forms Bindable Layouts
    public sealed class RepeaterView<T> : StackLayout
    {
        public RepeaterView()
        {
            this.Spacing = 0;
        }

        public ObservableCollection<T> ItemsSource
        {
            get { return (ObservableCollection<T>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
#pragma warning disable CS0618 // Type or member is obsolete
            BindableProperty.Create<RepeaterView<T>, ObservableCollection<T>>(
                p => p.ItemsSource, new ObservableCollection<T>(), BindingMode.OneWay, null, ItemSourceChanged);

#pragma warning restore CS0618 // Type or member is obsolete

        public static readonly BindableProperty ItemTemplateProperty =
#pragma warning disable CS0618 // Type or member is obsolete
            BindableProperty.Create<RepeaterView<T>, DataTemplate>(p => p.ItemTemplate, default(DataTemplate));
#pragma warning restore CS0618 // Type or member is obsolete

        private static void ItemSourceChanged(BindableObject bindable, ObservableCollection<T> oldValue, ObservableCollection<T> newValue)
        {
            if (bindable is RepeaterView<T> control)
            {
                if (oldValue != null)
                    oldValue.CollectionChanged -= control.ItemsSource_CollectionChanged;

                control.Children.Clear();

                if (newValue != null)
                {
                    newValue.CollectionChanged += control.ItemsSource_CollectionChanged;
                    foreach (var item in newValue)
                    {
                        var cell = control.ItemTemplate.CreateContent();
                        var view = ((ViewCell)cell).View;
                        view.BindingContext = item;
                        control.Children.Add(view);
                    }
                }
            }
        }

        void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                this.Children.RemoveAt(e.OldStartingIndex);
                this.UpdateChildrenLayout();
                this.InvalidateLayout();
            }

            if (e.NewItems != null)
            {
                foreach (T item in e.NewItems)
                {
                    var cell = this.ItemTemplate.CreateContent();
                    var view = ((ViewCell)cell).View;
                    view.BindingContext = item;
                    this.Children.Insert(ItemsSource.IndexOf(item), view);
                }
                this.UpdateChildrenLayout();
                this.InvalidateLayout();
            }
        }
    }
}
