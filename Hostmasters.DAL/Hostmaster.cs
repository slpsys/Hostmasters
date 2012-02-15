using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hostmasters.DAL;
using Ninject;

namespace Hostmasters
{
	public class Hostmaster
	{
		/// <summary>
		/// Gets or sets the dal.
		/// </summary>
		/// <value>The dal.</value>
		public IHostmastersDAL dal { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Hostmaster"/> class.
		/// </summary>
		/// <param name="dal">The dal.</param>
		public Hostmaster(IHostmastersDAL dal)
		{
			this.dal = dal;
		}
	}
}
