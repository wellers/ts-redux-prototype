﻿using System.Linq;
using SharedTypes.NET;
using System.Collections.Generic;
using System.Web.Http;

namespace Server.Areas.Contacts.Controllers
{
	public class ContactsApiController : ApiController
	{
		private readonly List<Contact> _contacts = new List<Contact>
		{
			new Contact{ Title = "Mr", Forename = "Paul", Surname = "Welbourne" },
			new Contact{ Title = "Mr", Forename = "Paul", Surname = "Riding" },
			new Contact{ Title = "Mrs", Forename = "Elena", Surname = "Potapova" },
			new Contact{ Title = "Mr", Forename = "Mike", Surname = "Lloyd" },
		};

		[HttpPost]
		public GetContactsResponse GetContacts([FromBody]ContactSearch search)
		{
			var searchResults = _contacts.Where(c => c.Forename.ToLower().Contains(search.SearchTerm.ToLower()) 
				|| c.Surname.ToLower().Contains(search.SearchTerm.ToLower())).ToList();

			return new GetContactsResponse
			{
				Results = searchResults,
				TotalResultCount = searchResults.Count(),
				ResultsPerPage = 10
			};
		}
	}
}