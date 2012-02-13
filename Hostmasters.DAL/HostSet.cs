using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hostmasters.DAL
{
	public class HostSet
	{
		public HostSet() : base()
		{
			this.CreationTime = DateTime.Now;
			this.Hosts = new List<Host>();
		}

		private string _Name;
		public string Name
		{
			get { return this._Name; }
			set
			{
				this.LastModificationTime = DateTime.Now;
				this._Name = value;
			}
		}

		private bool _Active;	
		public bool Active
		{
			get { return this.Active; }
			set
			{
				this.LastModificationTime = DateTime.Now;
				this._Active = value;
			}
		}

		public List<Host> Hosts { get; set; }
		public DateTime CreationTime { get; private set; }
		public DateTime LastModificationTime { get; private set; }
	}
}
