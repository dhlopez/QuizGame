using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using QuestionsGame;
using Xamarin.Forms.Platform.Android;
using QuestionsGame.Droid;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdMobRenderer))]
 
namespace QuestionsGame.Droid
{
    public class AdMobRenderer : ViewRenderer<AdMobView, Android.Gms.Ads.AdView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var ad = new Android.Gms.Ads.AdView(Forms.Context);
                ad.AdSize = Android.Gms.Ads.AdSize.Banner;
                ad.AdUnitId = "ca-app-pub-3934780639033713/2713363649";

                var requestbuilder = new Android.Gms.Ads.AdRequest.Builder();
                ad.LoadAd(requestbuilder.Build());

                SetNativeControl(ad);
            }
        }
    }
}