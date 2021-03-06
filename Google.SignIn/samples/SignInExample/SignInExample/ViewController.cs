// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;
using Google.SignIn;

namespace SignInExample
{
	public partial class ViewController : UIViewController, ISignInUIDelegate
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// TODO(developer) Configure the sign-in button look/feel
			SignIn.SharedInstance.UIDelegate = this;

			SignIn.SharedInstance.SignedIn += (sender, e) => {
				// Perform any operations on signed in user here.
				if (e.User != null && e.Error == null) {
					statusText.Text = string.Format ("Signed in user: {0}",	e.User.Profile.Name);
					ToggleAuthUI ();
				}
			};

			SignIn.SharedInstance.Disconnected += (sender, e) => {
				// Perform any operations when the user disconnects from app here.
				statusText.Text = "Disconnected user";
				ToggleAuthUI ();
			};

			// Automatically sign in the user.
			SignIn.SharedInstance.SignInUserSilently ();
			ToggleAuthUI ();

			statusText.Text = "Google Sign in\niOS Demo";
		}

		partial void didTapSignOut (NSObject sender)
		{
			SignIn.SharedInstance.SignOutUser ();
			ToggleAuthUI ();
		}

		partial void didTapDisconnect (NSObject sender)
		{
			SignIn.SharedInstance.DisconnectUser ();
		}

		void ToggleAuthUI ()
		{
			if (SignIn.SharedInstance.CurrentUser == null || SignIn.SharedInstance.CurrentUser.Authentication == null) {
				// Not signed in
				statusText.Text = "Google Sign in\niOS Demo";
				signInButton.Hidden = false;
				signOutButton.Hidden = true;
				disconnectButton.Hidden = true;
			} else {
				// Signed in
				signInButton.Hidden = true;
				signOutButton.Hidden = false;
				disconnectButton.Hidden = false;
			}
		}

		public override UIStatusBarStyle PreferredStatusBarStyle ()
		{
			return UIStatusBarStyle.LightContent;
		}
	}
}
