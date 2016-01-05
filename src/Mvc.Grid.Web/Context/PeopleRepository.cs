using NonFactors.Mvc.Grid.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NonFactors.Mvc.Grid.Web.Context
{
    public static class PeopleRepository
    {
        public static IEnumerable<PersonModel> GetPeople(String search = "")
        {
            search = (search ?? "").ToLower();

            return new List<PersonModel>
            {
                new PersonModel
                {
                    Id = 1,
                    Name = "Joe",
                    Surname = "Crosswave",

                    Age = (Int32)(DateTime.Now - new DateTime(1988, 01, 05)).TotalDays / 365,
                    Birthday = new DateTime(1988, 01, 05),
                    IsWorking = false
                },
                new PersonModel
                {
                    Id = 2,
                    Name = "Merry",
                    Surname = "Lisel",

                    Age = (Int32)(DateTime.Now - new DateTime(1978, 05, 06)).TotalDays / 365,
                    Birthday = new DateTime(1978, 05, 06)
                },
                new PersonModel
                {
                    Id = 3,
                    Name = "Henry",
                    Surname = "Crux",

                    Age = (Int32)(DateTime.Now - new DateTime(1990, 11, 19)).TotalDays / 365,
                    Birthday = new DateTime(1990, 11, 19),
                    IsWorking = true
                },
                new PersonModel
                {
                    Id = 4,
                    Name = "Cody",
                    Surname = "Jurut",

                    Age = (Int32)(DateTime.Now - new DateTime(1970, 08, 11)).TotalDays / 365,
                    Birthday = new DateTime(1970, 08, 11),
                    IsWorking = false
                },
                new PersonModel
                {
                    Id = 5,
                    Name = "Simon",
                    Surname = "Scranton",

                    Age = (Int32)(DateTime.Now - new DateTime(1985, 10, 10)).TotalDays / 365,
                    Birthday = new DateTime(1985, 10, 10)
                },
                new PersonModel
                {
                    Id = 6,
                    Name = "Leena",
                    Surname = "Laurent",

                    Age = (Int32)(DateTime.Now - new DateTime(2000, 07, 01)).TotalDays / 365,
                    Birthday = new DateTime(2000, 07, 01),
                    IsWorking = false
                },
                new PersonModel
                {
                    Id = 7,
                    Name = "Ode",
                    Surname = "Cosmides",

                    Age = (Int32)(DateTime.Now - new DateTime(1966, 04, 17)).TotalDays / 365,
                    Birthday = new DateTime(1966, 04, 17),
                    IsWorking = true
                },
                new PersonModel
                {
                    Id = 8,
                    Name = "Diandra",
                    Surname = "Mizner",

                    Age = (Int32)(DateTime.Now - new DateTime(1999, 08, 20)).TotalDays / 365,
                    Birthday = new DateTime(1999, 08, 20),
                    IsWorking = false
                },
                new PersonModel
                {
                    Id = 9,
                    Name = "Pete",
                    Surname = "Cassel",

                    Age = (Int32)(DateTime.Now - new DateTime(1997, 03, 13)).TotalDays / 365,
                    Birthday = new DateTime(1997, 03, 13),
                    IsWorking = false
                },
                new PersonModel
                {
                    Id = 10,
                    Name = "Nicky",
                    Surname = "Tremblay",

                    Age = (Int32)(DateTime.Now - new DateTime(1988, 01, 05)).TotalDays / 365,
                    Birthday = new DateTime(1988, 01, 05),
                    IsWorking = true
                }
            }.Where(person =>
                    person.Age.ToString().Contains(search) ||
                    person.Name.ToLower().Contains(search) ||
                    person.Surname.ToLower().Contains(search) ||
                    person.Birthday.ToString().Contains(search))
            .ToList();
        }
    }
}
