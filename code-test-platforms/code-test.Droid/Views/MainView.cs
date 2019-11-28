using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Views.InputMethods;
using code_test.common.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace code_test.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Code Test", Theme = "@style/AppTheme", LaunchMode = LaunchMode.SingleTop, Name = "code_test.droid.view.MainView")]
    public class MainView : MvxAppCompatActivity<MainViewModel>
    {
        public DrawerLayout DrawerLayout { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.MainView);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (bundle == null)
            {
                System.Diagnostics.Debug.WriteLine("MainView, no previous bundle set, showing default...");
                ViewModel.ShowUsersViewModelCommand.Execute(null);
                ViewModel.ShowMenuViewModelCommand.Execute(null);
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
            {
                DrawerLayout.CloseDrawers();
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null)
            {
                return;
            }

            var inputMethodManager = (InputMethodManager) GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);
            
            CurrentFocus.ClearFocus();
        }
    }
}