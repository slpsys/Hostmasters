using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Hostmasters.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hostmasters.Specs
{
	[Binding]
	public class HostAddition
	{
		//[Given("I have a new Host with address ((?:\\d+\\.){3}\\d+) for host (.*)")]
		[Given("I have a new Host with address (.*) for host (.*)")]
		public void GivenIHaveANewHostWithAddressForHost(string addr, string host)
		{
			ScenarioContext.Current.Pending();
			ScenarioContext.Current.Add("host", new Host() { IpAddress = addr, HostName = host });
		}

		[Given("I have a HostSet named (.*)")]
		public void GivenIHaveAHostSetNamed(string setName)
		{
			ScenarioContext.Current.Pending();
			ScenarioContext.Current.Add("set", new HostSet() { Active = true, Name = setName });
		}

		[When("I enumerate the host sets")]
		public void WhenIEnumerateTheHostSets()
		{
			ScenarioContext.Current.Pending();
			//TODO: result should be set to the list of hosts, but that needs to have the IHostmastersDAL wired up.
			ScenarioContext.Current.Add("result", null);
		}

		[Then("one named (.*) should have a Host with address (.*) host (.*)")]
		public void ThenTheResultShouldBe(string name, string address, string host)
		{
			ScenarioContext.Current.Pending();
			var result = (ICollection<HostSet>)ScenarioContext.Current["result"];
			Assert.IsTrue(result.Any(x => x.Name == name && x.Hosts.Any(h => h.IpAddress == address && h.HostName.ToLower() == host.ToLower())));
		}
	}
}
