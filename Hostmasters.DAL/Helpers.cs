using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Client;

namespace Hostmasters.DAL
{
	public static class Helpers
	{
		public static HostSet Get(this IDocumentSession session, HostSet set)
		{
			var result = from qSet in session.Query<HostSet>()
						 where qSet.Id == set.Id
						 select qSet;
			return result.FirstOrDefault();
		}
	}
}
