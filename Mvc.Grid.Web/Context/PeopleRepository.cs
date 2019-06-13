using NonFactors.Mvc.Grid.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NonFactors.Mvc.Grid.Web.Context
{
    public static class PeopleRepository
    {
        public static DataTable AsDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Name"));
            table.Columns.Add(new DataColumn("Surname"));
            table.Columns.Add(new DataColumn("MaritalStatus"));
            table.Columns.Add(new DataColumn("Age"));
            table.Columns.Add(new DataColumn("Birthday"));
            table.Columns.Add(new DataColumn("IsWorking"));

            foreach (Person person in GetPeople())
            {
                DataRow row = table.NewRow();

                row["Name"] = person.Name;
                row["Surname"] = person.Surname;
                row["MaritalStatus"] =person.MaritalStatus;

                row["Age"] = person.Age;
                row["Birthday"] = person.Birthday;
                row["IsWorking"] = person.IsWorking;

                table.Rows.Add(row);
            }

            return table;
        }
        public static IEnumerable<Person> GetPeople(String search = "")
        {
            search = (search ?? "").ToLower();

            return new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Joe",
                    Surname = "Crosswave",
                    MaritalStatus = MaritalStatus.Married,

                    Age = (Int32)(DateTime.Now - new DateTime(1988, 01, 05)).TotalDays / 365,
                    Birthday = new DateTime(1988, 01, 05),
                    IsWorking = false,

                    Children = new List<Person>
                    {
                        new Person
                        {
                            Id = 11,
                            Name = "Katy",
                            Surname = "Crosswave",

                            Age = (Int32)(DateTime.Now - new DateTime(2015, 01, 05)).TotalDays / 365,
                            Birthday = new DateTime(2015, 01, 05)
                        },
                        new Person
                        {
                            Id = 12,
                            Name = "Kate",
                            Surname = "Crosswave",

                            Age = (Int32)(DateTime.Now - new DateTime(2015, 01, 05)).TotalDays / 365,
                            Birthday = new DateTime(2015, 01, 05)
                        }
                    }
                },
                new Person
                {
                    Id = 2,
                    Name = "Merry",
                    Surname = "Lisel",
                    MaritalStatus = MaritalStatus.Widowed,

                    Age = (Int32)(DateTime.Now - new DateTime(1978, 05, 06)).TotalDays / 365,
                    Birthday = new DateTime(1978, 05, 06)
                },
                new Person
                {
                    Id = 3,
                    Name = "Henry",
                    Surname = "Crux",
                    MaritalStatus = MaritalStatus.Single,

                    Age = (Int32)(DateTime.Now - new DateTime(1990, 11, 19)).TotalDays / 365,
                    Birthday = new DateTime(1990, 11, 19),
                    IsWorking = true
                },
                new Person
                {
                    Id = 4,
                    Name = "Cody",
                    Surname = "Jurut",

                    Age = (Int32)(DateTime.Now - new DateTime(1970, 08, 11)).TotalDays / 365,
                    Birthday = new DateTime(1970, 08, 11),
                    IsWorking = false
                },
                new Person
                {
                    Id = 5,
                    Name = "Simon",
                    Surname = "Scranton",
                    MaritalStatus = MaritalStatus.Single,

                    Age = (Int32)(DateTime.Now - new DateTime(1985, 10, 10)).TotalDays / 365,
                    Birthday = new DateTime(1985, 10, 10)
                },
                new Person
                {
                    Id = 6,
                    Name = "Leena",
                    Surname = "Laurent",
                    MaritalStatus = MaritalStatus.Divorced,

                    Age = (Int32)(DateTime.Now - new DateTime(2000, 07, 01)).TotalDays / 365,
                    Birthday = new DateTime(2000, 07, 01),
                    IsWorking = false
                },
                new Person
                {
                    Id = 7,
                    Name = "Ode",
                    Surname = "Cosmides",
                    MaritalStatus = MaritalStatus.Married,

                    Age = (Int32)(DateTime.Now - new DateTime(1966, 04, 17)).TotalDays / 365,
                    Birthday = new DateTime(1966, 04, 17),
                    IsWorking = true,

                    Children = new List<Person>
                    {
                        new Person
                        {
                            Id = 71,
                            Name = "Jake",
                            Surname = "Cosmides",

                            Age = (Int32)(DateTime.Now - new DateTime(2014, 07, 14)).TotalDays / 365,
                            Birthday = new DateTime(2014, 07, 14)
                        }
                    }
                },
                new Person
                {
                    Id = 8,
                    Name = "Diandra",
                    Surname = "Mizner",
                    MaritalStatus = MaritalStatus.Single,

                    Age = (Int32)(DateTime.Now - new DateTime(1999, 08, 20)).TotalDays / 365,
                    Birthday = new DateTime(1999, 08, 20),
                    IsWorking = false
                },
                new Person
                {
                    Id = 9,
                    Name = "Pete",
                    Surname = "Cassel",
                    MaritalStatus = MaritalStatus.Married,

                    Age = (Int32)(DateTime.Now - new DateTime(1997, 03, 13)).TotalDays / 365,
                    Birthday = new DateTime(1997, 03, 13),
                    IsWorking = false
                },
                new Person
                {
                    Id = 10,
                    Name = "Nicky",
                    Surname = "Tremblay",
                    MaritalStatus = MaritalStatus.Married,

                    Age = (Int32)(DateTime.Now - new DateTime(1988, 01, 05)).TotalDays / 365,
                    Birthday = new DateTime(1988, 01, 05),
                    IsWorking = true,

                    Children = new List<Person>
                    {
                        new Person
                        {
                            Id = 101,
                            Name = "Nick",
                            Surname = "Tremblay",

                            Age = (Int32)(DateTime.Now - new DateTime(2013, 06, 08)).TotalDays / 365,
                            Birthday = new DateTime(2013, 06, 08)
                        },
                        new Person
                        {
                            Id = 102,
                            Name = "Nike",
                            Surname = "Tremblay",

                            Age = (Int32)(DateTime.Now - new DateTime(2014, 12, 12)).TotalDays / 365,
                            Birthday = new DateTime(2014, 12, 12)
                        },
                        new Person
                        {
                            Id = 103,
                            Name = "Norbert",
                            Surname = "Tremblay",

                            Age = (Int32)(DateTime.Now - new DateTime(2015, 05, 23)).TotalDays / 365,
                            Birthday = new DateTime(2015, 05, 23)
                        }
                    }
                }
            }.Where(person =>
                person.Age.ToString().Contains(search) ||
                person.Name.ToLower().Contains(search) ||
                person.Surname.ToLower().Contains(search) ||
                person.Birthday.ToString().Contains(search) ||
                person.IsWorking.ToString().ToLower().Contains(search) ||
                person.MaritalStatus.ToString().ToLower().Contains(search))
            .ToList();
        }
    }
}
