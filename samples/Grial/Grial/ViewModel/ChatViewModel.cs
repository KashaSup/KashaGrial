using System;
using System.Collections.Generic;
namespace UXDivers.Artina.Grial
{
	public class ChatViewModel
	{
		
		public User FirstUser{
			get;
			set;
		}

		public User SecondUser{
			get;
			set;
		}

		public string When {
			get;
			set;
		}

		public List<ChatMessage> Messages {
			get;
			set;
		}
	
		public ChatViewModel (
			User firstUser,
			User secondUser,
			string when,
			List<ChatMessage> messages
		)
		{
			FirstUser = firstUser;
			SecondUser = secondUser;
			When = when;
			Messages = messages;

		}
	}
}

