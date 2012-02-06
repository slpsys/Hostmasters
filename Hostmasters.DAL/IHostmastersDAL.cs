using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hostmasters.DAL
{
	public interface IHostmastersDAL
	{
		void CreateHost(Host host);
		void DeleteHost(Host host);

		void AddHostToSet(Host host, HostSet set);
		void RemoveHostFromSet(Host host, HostSet set);
		ICollection<Host> ListHosts(HostSet set);

		HostSet CreateSet();
		void ActivateSet(HostSet set);
		void DeactivateSet(HostSet set);
		void DeleteSet(HostSet set);
		ICollection<HostSet> ListSets();

		string BuildHostsFile();
	}
}
