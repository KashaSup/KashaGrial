using System;

namespace UXDivers.Artina.Grial
{
	public class Message
	{
		public User From {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		public string Body {
			get;
			set;
		}

		public bool HasAttachment {
			get;
			set;
		}

		public uint ThreadCount {
			get;
			set;
		}

		public string When {
			get;
			set;
		}

		public Boolean IsStared {
			get;
			set;
		}

		public Boolean IsRead {
			get;
			set;
		}

		public Message (
			User from, 
			uint threadCount, 
			bool hasAttachment,
			string when,
			string title, 
			string body, 
			Boolean isStared,
			Boolean isRead)
		{
			From 			= from;
			ThreadCount 	= threadCount;
			HasAttachment 	= hasAttachment;
			When 			= when;
			Title			= title;
			Body 			= body;
			IsStared	 	= isStared;
			IsRead	 		= isRead;
		}
	}
}