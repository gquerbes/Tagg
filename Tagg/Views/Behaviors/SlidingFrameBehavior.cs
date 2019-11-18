using System;
using System.Diagnostics;
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
            var math = args.TotalY / Device.info.PixelScreenSize.Height;

            Debug.WriteLine($"Total Y: {args.TotalY}");
            Debug.WriteLine($"ScreenHeight: {Device.info.PixelScreenSize}");
            Debug.Write($"Math {args.TotalY / Device.info.PixelScreenSize.Height}");




            var newHeight = currentHeight - math;

            if (newHeight > .15 && newHeight < 1)
            {
                AbsoluteLayout.SetLayoutBounds(view, new Rectangle(0, 1, 1, newHeight ));
            }
            
            
        }
    }
}
