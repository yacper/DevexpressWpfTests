﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.Mvvm;

namespace GridTest.ViewModels
{
	public class Customer
	{
		public string Name { get; set; }
		public string City { get; set; }
		public int Visits { get; set; }
		public DateTime? Birthday { get; set; }
	}

	public class MainViewModel : ViewModelBase
	{
		public MainViewModel()
		{
			List<Customer> people = new List<Customer>();
			people.Add(new Customer() { Name = "Gregory S. Price", City = "Hong Kong", Visits = 4, Birthday = new DateTime(1980, 1, 1) });
			people.Add(new Customer() { Name = "Irma R. Marshall", City = "Madrid", Visits = 2, Birthday = new DateTime(1966, 4, 15) });
			people.Add(new Customer() { Name = "John C. Powell", City = "Los Angeles", Visits = 6, Birthday = new DateTime(1982, 3, 11) });
			people.Add(new Customer() { Name = "Christian P. Laclair", City = "London", Visits = 11, Birthday = new DateTime(1977, 12, 5) });
			people.Add(new Customer() { Name = "Karen J. Kelly", City = "Hong Kong", Visits = 8, Birthday = new DateTime(1956, 9, 5) });
			people.Add(new Customer() { Name = "Brian C. Cowling", City = "Los Angeles", Visits = 5, Birthday = new DateTime(1990, 2, 27) });
			people.Add(new Customer() { Name = "Thomas C. Dawson", City = "Madrid", Visits = 21, Birthday = new DateTime(1965, 5, 5) });
			people.Add(new Customer() { Name = "Angel M. Wilson", City = "Los Angeles", Visits = 8, Birthday = new DateTime(1987, 11, 9) });
			people.Add(new Customer() { Name = "Winston C. Smith", City = "London", Visits = 1, Birthday = new DateTime(1949, 6, 18) });
			people.Add(new Customer() { Name = "Harold S. Brandes", City = "Bangkok", Visits = 3, Birthday = new DateTime(1989, 1, 8) });
			people.Add(new Customer() { Name = "Michael S. Blevins", City = "Hong Kong", Visits = 4, Birthday = new DateTime(1972, 9, 14) });
			people.Add(new Customer() { Name = "Jan K. Sisk", City = "Bangkok", Visits = 6, Birthday = new DateTime(1989, 5, 7) });
			people.Add(new Customer() { Name = "Sidney L. Holder", City = "London", Visits = 19, Birthday = new DateTime(1971, 10, 3) });
			Customers = people;


			//var cities = from c in people select c.City;
			var cities = people.Select(p => p.City);
			Cities = cities.Distinct().ToList();
		}
		public List<string> Cities { get; private set; }
		public List<Customer> Customers { get; private set; }
	}
}