Feature: HostAddition
	In order not miss any additions 
	As a hosts file user
	I want my new host to appear in its proper host set

//@myTag
Scenario: Add a brand new host
	Given I have a new Host with address 1.1.1.1 for host test.com
	And I have a HostSet named default
	When I enumerate the host sets 
	Then one named default should have a Host with address 1.1.1.1 for host test.com
