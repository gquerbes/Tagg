using System;
using Xamarin.Forms;

namespace Tagg.Views.Behaviors
{
    public class SlidingFrameBehavior : Behavior<View>
    {
        


        protected override void OnAttachedTo(View bindable)
        {

            var gest = new PanGestureRecognizer();
            gest.PanUpdated += OnGestureRegcongized;
            bindable.GestureRecognizers.Add(gest);
            base.OnAttachedTo(bindable);
        }


        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
        }


        protected virtual void OnGestureRegcongized(object sender, PanUpdatedEventArgs args)
        {
            var view = (View)sender;
            var currentHeight = AbsoluteLayout.GetLayoutBounds(view).Height;


            var yAxisChange = 0.0;

            if (args.TotalY < 0)
            {
                yAxisChange = .01;

            }
            if(args.TotalY > 0)
            {
                yAxisChange = -.01;
            }

            var newHeight = currentHeight + yAxisChange;

            if (newHeight > .15 && newHeight < 1)
            {
                AbsoluteLayout.SetLayoutBounds(view, new Rectangle(0, 1, 1, newHeight ));
            }
            
            
        }
    }
}
