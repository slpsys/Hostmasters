using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Raven.Client.Document;

namespace Hostmasters.DAL
{
	public class RavenDAL : IHostmastersDAL, IDisposable
	{
		#region Fields

		private const string DEFAULT_DB_NAME = @"./Hostmasters.db";
		private bool _Disposed = false;

		#endregion

		#region Constructors

		public RavenDAL() : this(DEFAULT_DB_NAME)
		{
		}

		public RavenDAL(string dbName)
		{
		}

		#endregion

		#region DAL methods

		public void AddHostToSet(Host host, HostSet set)
		{
			throw new NotImplementedException();
		}

		public void RemoveHostFromSet(Host host, HostSet set)
		{
			throw new NotImplementedException();
		}

		public ICollection<Host> ListHosts(HostSet set)
		{
			throw new NotImplementedException();
		}

		public HostSet ActivateSet(HostSet set)
		{
			throw new NotImplementedException();
		}

		public HostSet DeactivateSet(HostSet set)
		{
			throw new NotImplementedException();
		}

		public HostSet DeleteSet(HostSet set)
		{
			throw new NotImplementedException();
		}

		public ICollection<HostSet> ListSets()
		{
			throw new NotImplementedException();
		}

		public Stream BuildHostsFile()
		{
			throw new NotImplementedException();
		}

		public HostSet CreateSet(HostSet set)
		{
			throw new NotImplementedException();
		}

		public void ParseHostsFile(Stream input)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Disposable methods

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		public virtual void Dispose(bool disposing)
		{
			if (disposing && !this._Disposed)
			{
				// Raven stuff here?
				this._Disposed = true;
			}	
		}

		#endregion
	}
}
