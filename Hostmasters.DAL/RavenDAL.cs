using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client;

namespace Hostmasters.DAL
{
	public class RavenDAL : IHostmastersDAL, IDisposable
	{
		#region Fields

		private const string DEFAULT_DB_NAME = @"Hostmasters.db";
		private bool _Disposed = false;
		private EmbeddableDocumentStore store;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="RavenDAL"/> class.
		/// </summary>
		public RavenDAL() : this(DEFAULT_DB_NAME) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="RavenDAL"/> class.
		/// </summary>
		/// <param name="dbName">Name of the db.</param>B
		public RavenDAL(string dbName)
		{
			this.store = new EmbeddableDocumentStore() { DataDirectory = DEFAULT_DB_NAME };
			this.store.Initialize();
		}

		#endregion

		#region DAL methods

		/// <summary>
		/// Adds the host to set.
		/// </summary>
		/// <param name="host">The host.</param>
		/// <param name="set">The set.</param>
		public void AddHostToSet(Host host, HostSet set)
		{
			using (var session = this.store.OpenSession())
			{
				var dalSet = session.Get(set);
				dalSet.Hosts.Add(host);
				session.SaveChanges();
			}
		}

		/// <summary>
		/// Removes the host from set.
		/// </summary>
		/// <param name="host">The host.</param>
		/// <param name="set">The set.</param>
		public void RemoveHostFromSet(Host host, HostSet set)
		{
			using (var session = this.store.OpenSession())
			{
				var dalSet = session.Get(set);
				dalSet.Hosts.Remove(host);
				session.SaveChanges();
			}
		}

		/// <summary>
		/// Activates the set.
		/// </summary>
		/// <param name="set">The set.</param>
		/// <returns></returns>
		public HostSet ActivateSet(HostSet set)
		{
			return ToggleSetActivation(set, true);
		}

		/// <summary>
		/// Deactivates the set.
		/// </summary>
		/// <param name="set">The set.</param>
		/// <returns></returns>
		public HostSet DeactivateSet(HostSet set)
		{
			return ToggleSetActivation(set, true);
		}

		/// <summary>
		/// Deletes the set.
		/// </summary>
		/// <param name="set">The set.</param>
		/// <returns></returns>
		public HostSet DeleteSet(HostSet set)
		{
			using (var session = this.store.OpenSession())
			{
				var result = session.Get(set);
				if (result != null)
				{
					session.Delete(result);
					session.SaveChanges();
				}
			}	
			return set;
		}

		/// <summary>
		/// Lists the sets.
		/// </summary>
		/// <returns></returns>
		public ICollection<HostSet> ListSets()
		{
			var sets = new List<HostSet>();
			using (var session = this.store.OpenSession())
			{
				var result = from set in session.Query<HostSet>()
							 select set;
				sets = result.ToList();
			}
			return sets;
		}

		/// <summary>
		/// Creates the set.
		/// </summary>
		/// <param name="set">The set.</param>
		/// <returns></returns>
		public HostSet CreateSet(HostSet set)
		{
			using (var session = this.store.OpenSession())
			{
				session.Store(set);
				session.SaveChanges();
			}
			return set;
		}

		public Stream BuildHostsFile()
		{
			throw new NotImplementedException();
		}

		public void ParseHostsFile(Stream input)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Helpers

		protected HostSet ToggleSetActivation(HostSet set, bool value)
		{
			using (var session = this.store.OpenSession())
			{
				var dalSet = session.Get(set);
				dalSet.Active = value;
				session.SaveChanges();
			}
			return set;
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
				this.store.Dispose();
				this._Disposed = true;
			}	
		}

		#endregion
	}
}
