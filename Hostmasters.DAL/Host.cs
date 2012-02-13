using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hostmasters.DAL
{
	public class Host
	{
		public Host() : base()
		{
			this.CreationTime = DateTime.Now;	
		}

		private string _Hostname;
		public string Hostname
		{
			get { return this._Hostname; }
			set
			{
				this.LastModificationTime = DateTime.Now;
				this._Hostname = value;
			}
		}

		private string _IpAddress;
		public string IpAddress
		{
			get { return this._IpAddress; }
			set
			{
				this.LastModificationTime = DateTime.Now;
				this._IpAddress = value;
			}
		}

		private string _Comment;
		public string Comment
		{
			get { return this._Comment; }
			set
			{
				this.LastModificationTime = DateTime.Now;
				this._Comment = value;
			}
		}

		public DateTime CreationTime { get; private set; }
		public DateTime LastModificationTime { get; private set; }
	}
}
