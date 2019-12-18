﻿using System;
using UXDivers.Artina.Shared;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public class CustomFontLabelRenderer : ArtinaCustomFontLabelRenderer
	{
		private static readonly string[] CustomFontFamily = new [] { "FontAwesome" };
		private static readonly Tuple<FontAttributes, string>[][] CustomFontFamilyData = new [] { 
			new [] {
				new Tuple<FontAttributes, string>(FontAttributes.None, "fontawesome-webfont.ttf"), 
				new Tuple<FontAttributes, string>(FontAttributes.Bold, "fontawesome-webfont.ttf"), 
				new Tuple<FontAttributes, string>(FontAttributes.Italic, "fontawesome-webfont.ttf"), 
			},
		};
			
		protected override bool CheckIfCustomFont (string fontFamily, FontAttributes attributes, out string fontFileName)
		{
			for (int i = 0; i < CustomFontFamily.Length; i++) {
				if (string.Equals(fontFamily, CustomFontFamily[i], StringComparison.InvariantCulture)){
					var fontFamilyData = CustomFontFamilyData[i];

					for (int j = 0; j < fontFamilyData.Length; j++) {
						var data = fontFamilyData[j];
						if (data.Item1 == attributes){
							fontFileName = data.Item2;

							return true;
						}
					}

					break;
				}
			}

			fontFileName = null;
			return false;
		}
	}
}

