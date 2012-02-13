using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hostmasters.DAL
{
	public interface IHostmastersDAL
	{
		void AddHostToSet(Host host, HostSet set);
		void RemoveHostFromSet(Host host, HostSet set);
		ICollection<Host> ListHosts(HostSet set);

		HostSet CreateSet(HostSet set);
		HostSet ActivateSet(HostSet set);
		HostSet DeactivateSet(HostSet set);
		HostSet DeleteSet(HostSet set);
		ICollection<HostSet> ListSets();

		Stream BuildHostsFile();
		void ParseHostsFile(Stream input);
	}
}
