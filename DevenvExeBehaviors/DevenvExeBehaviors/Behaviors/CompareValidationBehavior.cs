﻿using Xamarin.Forms;

namespace DevenvExeBehaviors.Behaviors
{
    
    public class CompareValidationBehavior : Behavior<Entry>
    {
       
        //public static BindableProperty TextProperty = BindableProperty.Create<CompareValidationBehavior, string>(tc => tc.Text, string.Empty, BindingMode.TwoWay);

        //Should Replace with this newer Version that I Come With.
        public static BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(CompareValidationBehavior), string.Empty, BindingMode.TwoWay);


        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

       
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            bool IsValid = false;
            IsValid =  e.NewTextValue ==Text;
           
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}
