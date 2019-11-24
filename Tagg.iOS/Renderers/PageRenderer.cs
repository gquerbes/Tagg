using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(Tagg.iOS.Renderers.PageRenderer))]
namespace Tagg.iOS.Renderers
{

    public class PageRenderer : Xamarin.Forms.Platform.iOS.PageRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            try
            {
                SetAppTheme();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"\t\t\tERROR: {ex.Message}");
            }
        }

        public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection)
        {
            base.TraitCollectionDidChange(previousTraitCollection);
            Console.WriteLine($"TraitCollectionDidChange: {TraitCollection.UserInterfaceStyle} != {previousTraitCollection.UserInterfaceStyle}");

            if (this.TraitCollection.UserInterfaceStyle != previousTraitCollection.UserInterfaceStyle)
            {
                SetAppTheme();
            }


        }

        void SetAppTheme()
        {
            //get current resource
            ResourceDictionary currentStyle = Xamarin.Forms.Application.Current.Resources;

            ResourceDictionary desiredStyle;


            if (this.TraitCollection.UserInterfaceStyle == UIUserInterfaceStyle.Dark)
            {
                desiredStyle =  TaggUI.Styles.DarkTheme.Instance;
            }
            else
            {
               desiredStyle = TaggUI.Styles.LightTheme.Instance;
            }


            if(currentStyle != desiredStyle)
            {
                Xamarin.Forms.Application.Current.Resources = desiredStyle;

            }
          
        }
    }

}