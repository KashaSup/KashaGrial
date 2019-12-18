using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class WalkthroughVariantStepItemTemplate : ContentPage
	{
		public static BindableProperty TextProperty =
			BindableProperty.Create ( "Text", typeof ( string ),
				typeof ( WalkthroughVariantStepItemTemplate ),
				string.Empty,
				defaultBindingMode	: BindingMode.OneWay,
				propertyChanging	: (bindable, oldValue, newValue) => {
					var ctrl = (WalkthroughVariantStepItemTemplate)bindable;
					ctrl.DescriptionLabel.Text = (string)newValue;
				}
			);

		public string Text {
			get { return ( string )GetValue( TextProperty ); }
			set { SetValue ( TextProperty, value ); }
		}

		/* HEADER */

		public static BindableProperty HeaderProperty =
			BindableProperty.Create ( "Header", typeof ( string ),
				typeof ( WalkthroughVariantStepItemTemplate ),
				string.Empty,
				defaultBindingMode	: BindingMode.OneWay,
				propertyChanging	: ( bindable, oldValue, newValue ) => {
					var ctrl = (WalkthroughVariantStepItemTemplate)bindable;
					ctrl.HeaderLabel.Text = (string)newValue;
				}
			);

		public string Header {
			get { return ( string )GetValue( HeaderProperty ); }
			set { SetValue ( HeaderProperty, value ); }
		}

		/* BUTTON */

		public static BindableProperty ButtonTextProperty =
			BindableProperty.Create ( "ButtonText", typeof ( string ),
				typeof ( WalkthroughVariantStepItemTemplate ),
				string.Empty,
				defaultBindingMode	: BindingMode.OneWay,
				propertyChanging	: (bindable, oldValue, newValue) => {
					var ctrl = (WalkthroughVariantStepItemTemplate)bindable;
					ctrl.PrimaryActionButton.Text = (string)newValue;
				}
			);

		public string ButtonText {
			get { return ( string )GetValue( ButtonTextProperty ); }
			set { SetValue ( ButtonTextProperty, value ); }
		}

		public static BindableProperty ButtonBackgroundColorProperty =
			BindableProperty.Create ( "ButtonBackgroundColor", typeof ( string ),
				typeof ( WalkthroughVariantStepItemTemplate ),
				string.Empty,
				defaultBindingMode	: BindingMode.OneWay,
				propertyChanging	: (bindable, oldValue, newValue) => {
					var ctrl = (WalkthroughVariantStepItemTemplate)bindable;
					ctrl.PrimaryActionButton.BackgroundColor = Color.FromHex ((string)newValue);
				}
			);

		public string ButtonBackgroundColor {
			get { return ( string )GetValue( ButtonBackgroundColorProperty ); }
			set { SetValue ( ButtonBackgroundColorProperty, value ); }
		}

		/* ICON */

		public static BindableProperty IconColorProperty =
			BindableProperty.Create ( "IconColor", typeof ( string ),
				typeof ( WalkthroughVariantStepItemTemplate ),
				string.Empty,
				defaultBindingMode	: BindingMode.OneWay,
				propertyChanging	: (bindable, oldValue, newValue) => {
					var ctrl = (WalkthroughVariantStepItemTemplate)bindable;
					ctrl.IconLabel.TextColor = Color.FromHex ((string)newValue);
				}
			);

		public string IconColor {
			get { return ( string )GetValue( IconColorProperty ); }
			set { SetValue ( IconColorProperty, value ); }
		}

		/* IMAGE */

		public static BindableProperty StepBackgroundImageProperty =
			BindableProperty.Create ( "StepBackgroundImage", typeof ( string ),
				typeof ( WalkthroughVariantStepItemTemplate ),
				string.Empty,
				defaultBindingMode	: BindingMode.OneWay,
				propertyChanging	: (bindable, oldValue, newValue) => {
					var ctrl = (WalkthroughVariantStepItemTemplate)bindable;
					ctrl.img.Source = (string)newValue;
				}
			);

		public string StepBackgroundImage {
			get { return ( string )GetValue( StepBackgroundImageProperty ); }
			set { SetValue ( StepBackgroundImageProperty, value ); }
		}

		public static BindableProperty IconTextProperty =
			BindableProperty.Create ( "IconText", typeof ( string ),
				typeof ( WalkthroughVariantStepItemTemplate ),
				string.Empty,
				defaultBindingMode	: BindingMode.OneWay,
				propertyChanging	: ( bindable, oldValue, newValue ) => {
					var ctrl = (WalkthroughVariantStepItemTemplate)bindable;
					ctrl.IconLabel.Text = (string)newValue;
				}
			);

		public string IconText {
			get { return ( string )GetValue( IconTextProperty ); }
			set { SetValue ( IconTextProperty, value ); }
		}

		public WalkthroughVariantStepItemTemplate ()
		{
			InitializeComponent ();

			ResetAnimation ();
		}

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();

			ResetAnimation ();
		}
			
		public async Task AnimateIn(){
			await Task.WhenAll (new [] {
				AnimateItem (IconLabel, 500),
				AnimateItem (HeaderLabel, 600),
				AnimateItem (DescriptionLabel, 700)
			});
		}

		private async Task AnimateItem( View uiElement, uint duration ){
			await Task.WhenAll (new Task[] {
				uiElement.ScaleTo(1.5, duration, Easing.CubicIn),
				uiElement.FadeTo(1, duration/2, Easing.CubicInOut).ContinueWith(
					_ => 
                    {
                        // Queing on UI to workaround an issue with Forms 2.1
                        Device.BeginInvokeOnMainThread(() => {
                            uiElement.ScaleTo(1, duration, Easing.CubicOut);
                        });
                    })
			});
		}

		void OnPrimaryActionButtonClicked(object sender, EventArgs args)
		{
			var parent = (WalkthroughVariantPage) Parent;
			parent.GoToStep ();
		}

		void OnCloseButtonClicked(object sender, EventArgs args)
		{
			var parent = (WalkthroughVariantPage)Parent;
			parent.Close ();
		}

		private void ResetAnimation(){
			IconLabel.Opacity = 0;
			HeaderLabel.Opacity = 0;
			DescriptionLabel.Opacity = 0;
			OverlapedButtonContainer.BackgroundColor = BackgroundColor;
		}
	}
}
