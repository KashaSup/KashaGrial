using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace UXDivers.Artina.Grial
{
	public partial class ChatMessagesListPage : ContentPage
	{
		public ChatMessagesListPage ()
		{
			InitializeComponent ();

			SetupChat();
		}

		public void SetupChat(){
			var chatMessagesList = SampleData.ChatMessagesList;
			User FirstUser = SampleData.ChatMessagesList[0].From;
			View widget;

			for (int index=0; index < chatMessagesList.Count; index++){
				
				if ((chatMessagesList [index] as ChatMessage).From != FirstUser) {
					widget = new ChatRightMessageItemTemplate ();
				} else {
					widget = new ChatLeftMessageItemTemplate ();
				}
				widget.BindingContext = chatMessagesList[index];
				ChatMessagesListView.Children.Add( widget);
			}
		}
	}
}

