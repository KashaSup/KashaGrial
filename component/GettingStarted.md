# Grial UI Kit 1.5
## Release notes
- Added support for AppCompat V7
- Updated Xamarin Forms to 2.2
- Fixed issue that cause multiple Android resources errors reported when Xamarin Forms version was updated.
- Fixed minor issues in Android's Colors.tt
- Fixed accent color of iOS TabBar
# Grial UI Kit 1.2
## Release notes
- Added support for Xamarin Forms 2.0
	- XAlign properties renamed to HorizontalTextAlignment
	- YAlign properties renamed to VerticalTextAlignment
- Added improvements in bindings and view models
- Several minor performance tweaks
- Added [Gorilla Player](http://gorillaplayer.com "Gorilla Player, Instant XAML preview for Xamarin Forms") support
	-  SampleData.json file added to improve preview
	-  Minor tweaks on bindings to get data from SampleData.json
- XAMLC
	- XAMLC is still experimental, so expect things to change as improvements are made over the next few months ([source](https://visualstudiomagazine.com/articles/2016/01/11/xamarin-4-improvements-upgrading.aspx)).
	- We added XAMLC to the assembly, but we skipped it on:
		- App.xaml.cs
			- The reason was that images used as resources are not being displayed
		- MessageItemTemplate.xaml.cs
			- The reason here was the converter
## Overview

Grial offers a set of XAML UI views carefully crafted with developers in mind. 

We provide them with an easy way to focus on logic and to "almost forget" about the UI work by providing ready made views, templates, bindings and styling through a customizable theme.

### For more information please [visit Grial support website](https://github.com/UXDivers/Grial-UI-Kit-Support-And-Issues). ###


### Conventions
For your convenience we have structured the project with the following folders:

       Grial
		|_ References
		|_ Packages
		|_ Helpers
		|_ Models
		|_ Properties
		|_ ViewModel
		|_ Views


### Supported Platforms

Currently Grial UI Kit is optimized for Android 5.0+ (API Level 21) and iOS 8.0+, but Android 4.2.2+ (API Level 17+) is supported.

## Theme and branding of your app
Grial offers a simple way to customize the overall look and feel by providing an easy and extensible theme.
It provides several colors and styles that will ease your UI tweaks.

To start customizing your app's look and feel, please refer to **App.xaml** file located in the following location:

       Grial
		|_ App.xaml

Inside the file you will find the colors, styles and images references keys we created:

	<ResourceDictionary x:Name="ThemeDictionary">
		...

		<!-- COLORS -->
		<Color x:Key="BrandColor">#ad1457</Color>
		
		...

		<!-- BASE STYLES -->
		<Style x:Key="FontIcon" TargetType="Label">
			<Setter Property="FontFamily" Value="{x:Static artina:FontAwesome.FontName}" />
		</Style>
 
		...

		<!-- STATIC IMAGES -->
		<FileImageSource x:Key="BrandImage">logo.png</FileImageSource>
		...

The most important color is the **AccentColor**, which is used across the whole theme/app.
Basically changing its value will affect the overall look and feel.

		<!-- 

			EXPORTED COLORS

			Everytime you change any of the exported colors
			you MUST compile (Right click on "Colors.tt" > Tools > Process T4 Templates)
			to see your changes on your App
		-->
		<!-- Export AccentColor -->
		<Color x:Key="AccentColor">#FFDA125F</Color>
		<!-- Export InverseTextColor -->
		<Color x:Key="InverseTextColor">White</Color>


----------
**Important: Changing the AccentColor value requires to manually export colors**

**Due to some limitations on Xamarin Forms it is not possible to style everything right from App.xaml. 
To work around this limitation we created a color compiler for Android and iOS.**

----------


**Manually exporting colors**

Once you change any exported color (AccentColor and/or InverseTextColor) you will need to manually trigger the colors compilation **BEFORE you run the app.** 

**Otherwise you won't see changes reflected on your app.**

Manually trigger the exported colors compilation by locating the following files on the solution:

	   Grial
		|_ Colors.tt
		
	   Grial.Droid
		|_ Resources
			|_ values
				|_ Colors.tt

...then right click on each of them and select

	 Tools > Process T4 Templates

To visualize the theme simply run the sample app and go to:

	Grial Theme > Native Controls
 	Grial Theme > Native Renderers
	Grial Theme > Grial Common Views

We also provide an easy way to replace your app's logo by modifying an specific resource on ThemeDictionary, called **"BrandImage"**. Simply locate the resource and point it to your image file.

Additionally we provided an specific XAML view to help your branding needs, the **"BrandBlock.xaml"**, which can be found on the following location:


       Grial
		|_ Views
			|_ Common
				|_ BrandBlock.xaml


## Using Icons
Grial uses [Fontawesome icons](https://fortawesome.github.io/Font-Awesome/icons/) 4.3.0

Since they are made from vectors they will render properly across different devices with different pixel densities. In other words, they will look sharp wherever you display them.

To use your desired icon, just follow this procedure:

1. Go to [Fontawesome icons](https://fortawesome.github.io/Font-Awesome/icons/)
2. Type the name of the icon you are looking for in the text input and click on the suggested icon that matches your search. You will be redirected to the icon's page.
3. Copy the unicode value of that icon (something like **f004**)
4. If you are using the icon on a .XAML file, you should use it as **"&#x"** + **UNICODE** + **";"**
5. If you are using the icon on a .CS file, you should use it as **"\u"** + **UNICODE**
 

**Important: Icons can ONLY be used on `<Label>` controls.**
 
---

## Custom Renderers

Xamarin Forms currently allows to customize only some properties of the UI controls. Usually a professional UI requires further customization, but fortunatly, through Custom Renderers, Xamarin Forms open a door to achieve it. Artina provides a set of attached properties and custom renderers to customize some properties that were not possible before. For example, Xamarin Forms out of the box does not provide any mean to configure the border of the Entity control. Grial provides a set of properties to do that: 


	<Entry
		...
		artina:EntryProperties.BorderStyle="BottomLine"
		artina:EntryProperties.BorderWidth="1"
		... />

BorderStyle as it name suggest allows to customize how the border should look like. The possible values are None, BottomLine, Rect, RoundRect or Defaul. The first forces no border to be shown at all. BottomLine renders a single line at the bottom of the entry. Rect draws a rectangle around the Entry and RoundRect a rectangle with rounded corners. There are other properties to further configure the border appearance like BorderWidth, BorderCornerRadius and BorderColor. Besides of specifing the attached properties, we must instruct Xamarin Forms to use the approriate custom renderer (in this case ArtinaEntryRenderer) which is the one that knows how those properties should be renderer.

In Grial, custom renderers are declared in the AssemblyInfo file of the Grial.iOS and Grial.Android project.

If you want to use the attached properties in a different project you need to know that:

- Attached properties are defined on the assembly **UXDivers.Artina.Shared.**, therefore you must reference it from your Xamarin Forms project.

- Custom Renderers are defined in **UXDivers.Artina.Shared.Android** for Android and  **UXDivers.Artina.Shared.iOS** for iOS. So from your iOS project you will need to reference both **UXDivers.Artina.Shared.** and **UXDivers.Artina.Shared.iOS**. From Android you need to reference **UXDivers.Artina.Shared.** and **UXDivers.Artina.Shared.Android**.

---


## Splash image
Grial provides the needed infrastructure for your app to display your app's splash image.


**On Android:**

The only thing you will need is to find and replace all the **"splash.png"** images files with yours.

    Grial
		|_ Grial.Droid
			|_ resources
				|_ drawable
					|_ splash.png
				|_ drawable-hdpi
					|_ splash.png
				|_ drawable-xhdpi
					|_ splash.png
				|_ drawable-xxhdpi
					|_ splash.png

**On iOS:**

     Grial
		|_ Grial.iOS
			|_ Resources
				|_ Default.png
				|_ Default-Portrait.png
				|_ Default@2x.png
				|_ Default-Portrait@2x.png
				|_ Default-6@3x.png
				|_ Default-6Plus@3x.png
				|_ Default-568h@2x.png




---

## UI Templates

Grial provides 30+ templates which target common patterns in apps UIs.
Each one of them is fully functional page sample, with its code behind and data bindings to help bootstrapping your app or prototype.

Basically the templates fit two categories, the **Common** ones:
    
	   Grial
		|_ Views
			|_ Common

...and the specific ones:

       Grial
		|_ Views
			|_ Articles
			|_ Dashboards
			|_ Ecommerce
			|_ Logins
			|_ Messages
			|_ Navigation
			|_ Settings
			|_ Social
			|_ Theme
			|_ Walkthrough

Inside each category folder you will find sample pages and in most cases item templates (used as items in repeaters controls such as ListViews). Take a look at the **Dashboards** folder as an example:

	   Grial
		|_ Views
			|_ Dashboards
				|_ Templates
				|	|_ DashboardItemTemplate.xaml
				|
				|_ DashboardWithImages.xaml
				|_ Dashboard.xaml
				|_ DashboardFlat.xaml


The **"DashWidgetView.xaml"** contains the common template that will be used in all of the dashboards pages.

## The common views

Common views are ContentViews that are used often more than once in an app. 

	   Grial
		|_ Views
			|_ Common				
				|_ Badge.xaml
				|_ BrandBlock.xaml
				|_ CircleIcon.xaml
				|_ CustomNavBar.xaml

To visualize them simply run the sample app and go to:

	Grial Theme > Grial Common Views

---

**Badge.xaml**

This is a ContenView which mimics a Badge Control.

To include it in your page first add the namespace:

	<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage
			...
			xmlns:commonViews="clr-namespace:UXDivers.Artina.Grial;assembly=UXDivers.Artina.Grial">

Then place it inside a RelativeLayout: 

    <RelativeLayout 

		<commonViews:Badge 
			Scale=".9"
			BindingContext="{ Binding AllSamples.Count }"
			BadgeTextColor="#FFF" 
			BadgeBackgroundColor="#F00"
			RelativeLayout.XConstraint="{ ConstraintExpression Type=RelativeToView, ElementName=BrandBlock, Property=Width, Factor=1,  Constant=-26 }" 
			RelativeLayout.YConstraint="{ ConstraintExpression Type=RelativeToView, ElementName=BrandBlock, Property=Y, Factor=1, Constant=4 }"
		/>

	</RelativeLayout>

The bindable properties are:

- **BadgeBackgroundColor** Color.FromHex
- **BadgeTextColor** Color.FromHex

---

**BrandBlock.xaml**

This is a ContenView which holds the app logo and branding info.

To include it in your page first add the namespace:

	<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage
			...
			xmlns:commonViews="clr-namespace:UXDivers.Artina.Grial;assembly=UXDivers.Artina.Grial">

Then simply add it on our page:

	<commonViews:BrandBlock />

This is not a bindable view.

---


**CircleIcon.xaml**

This is a ContenView that renders an icon inside a circle.

To include it in your page first add the namespace:

	<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage
			...
			xmlns:commonViews="clr-namespace:UXDivers.Artina.Grial;assembly=UXDivers.Artina.Grial">

Then simply add it on our page:

	<commonViews:CircleIcon />

This is not a bindable view.

---


**CustomNavBar.xaml**

This is a ContenView which aims to replace standard ActionBar/NavBar. If you use it on a Master/Detail page it will trigger the menu states (presented or not). 

The main benefits are that:

- You can fully customize the look and feel and use font icons
- It will be displayed over the NavBar/ActionBar 

To make it look as native on your app, first you need to hide the real NavBar/ActionBar. To achieve it, simply go to the code behind file of your page and add the following:

    InitializeComponent ();
	NavigationPage.SetHasNavigationBar(this, false);

To include it in your page add the namespace:

	<?xml version="1.0" encoding="UTF-8"?>
		<ContentPage
			...
			xmlns:commonViews="clr-namespace:UXDivers.Artina.Grial;assembly=UXDivers.Artina.Grial">

Then simply add it on our page:

	<commonViews:CustomNavBar />


This is not a bindable view.

---


## The Specific views

The Specific views are examples of pages that belongs to certain categories which implement common UI patterns to help users achieve specific goals.

Typically they use templates for rendering items inside ListViews or in looped items.

Artina Grial follows the following convention:

	   Grial
		|_ Views
			|_ <CATEGORY NAME>
				|_ <PAGE>.xaml
				|_ Templates
					|_ <PAGE>ItemTemplate.xaml

---

**Articles**

The articles views and their item templates are used to display blog posts, articles, feeds, etc.

	   Grial
		|_ Views
			|_ Articles


---


**Dashboards**

The Dashboards views and their item templates are used to display nice looking categories.

	   Grial
		|_ Views
			|_ Dashboards

There are 3 available dashboards visualizations available in Artina Grial:

1. Default (Dashboard.xaml)
	- A dashboard displaying circled icons
2. Flat (DashboardFlat.xaml)
	- A variation from previous one displaying rectangular tiles for each item
3. Images (DashboardWithImages.xaml)
	- Another variation using icons and images as background


---

**Ecommerce**

The Ecommerce views and their item templates are used to display products lists and products previews.

	   Grial
		|_ Views
			|_ Ecommerce

---

**Logins**

The Logins views are used to sign-in, sign-up, login and password recovery pages.

	   Grial
		|_ Views
			|_ Logins

The Logins views shows how to use validations and display error and warning messages.

---

**Messages**

The Messages views and their item templates are used to display email like UIs and chats/instant messaging UIs.

	   Grial
		|_ Views
			|_ Messages


---

**Navigation**

The Navigation views are -as their name suggests- used for navigation purposes.

Basically there are 3 types:

1. Master/Detail (RootPage.xaml)
	- A Page that manages two panes of information: A master page that presents data at a high level, and a detail page that displays low-level details about information in the master.
2. Lists
	- Acts as proxies through categories navigations. They are similar to Dashboards but they are used to display much more information through ListViews.
3. Custom Navigation Bar Page Sample 
	- This is a sample showing the use of the common view `<commonViews:CustomNavBar />`

	   Grial
		|_ Views
			|_ Navigation


---

**Settings**

The Settings views are used -as its name suggest- for displaying settings.
Particularly, this sample illustrates the usage of Xamarin Forms TableViews with intent "Settings".

	   Grial
		|_ Views
			|_ Settings


---

**Social**

The Social views and their item templates are used to display users social profiles, friends lists and image galleries.

	   Grial
		|_ Views
			|_ Social

One of the remarkable features of this category is the use of subtle animations to improve the UX and also an image gallery specially implemented for Xamarin Forms.

---


**Theme**

The Theme views are mainly created to showcase the style features on Artina Grial.

	   Grial
		|_ Views
			|_ Theme

One of the remarkable features of this category is the use of `<WebView>`

---

**Walkthroughs**

The Walkthroughs views and their item templates are used to explain users the main features of your app. Think of it as a "tutorial mode" where the UI demonstrate features to the user.

	   Grial
		|_ Views
			|_ Walkthroughs


We have created 2 types of walkthough to serve different purposes:

1. Default (Walkthrough.xaml)
	- This type is intended to be used when you count with a design team who can provide you with images. These are ideal for final apps.  
2. Variant(WalkthroughVariant.xaml)
	- This type was specially created for devs who lacks of a design team. These are also very useful while building prototypes.

---
