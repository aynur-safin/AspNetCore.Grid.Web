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
                row["MaritalStatus"] = person.MaritalStatus;

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
                new Person(1, "Joe", "Crosswave")
                {
                    MaritalStatus = MaritalStatus.Married,

                    Age = (Int32)(DateTime.Now - new DateTime(1988, 01, 05)).TotalDays / 365,
                    Birthday = new DateTime(1988, 01, 05),
                    IsWorking = false,

                    Children = new List<Person>
                    {
                        new Person(11, "Katy", "Crosswave")
                        {
                            Age = (Int32)(DateTime.Now - new DateTime(2015, 01, 05)).TotalDays / 365,
                            Birthday = new DateTime(2015, 01, 05)
                        },
                        new Person(12, "Kate", "Crosswave")
                        {
                            Age = (Int32)(DateTime.Now - new DateTime(2015, 01, 05)).TotalDays / 365,
                            Birthday = new DateTime(2015, 01, 05)
                        }
                    }
                },
                new Person(2, "Merry", "Lisel")
                {
                    MaritalStatus = MaritalStatus.Widowed,

                    Age = (Int32)(DateTime.Now - new DateTime(1978, 05, 06)).TotalDays / 365,
                    Birthday = new DateTime(1978, 05, 06)
                },
                new Person(3, "Henry", "Crux")
                {
                    MaritalStatus = MaritalStatus.Single,

                    Age = (Int32)(DateTime.Now - new DateTime(1990, 11, 19)).TotalDays / 365,
                    Birthday = new DateTime(1990, 11, 19),
                    IsWorking = true
                },
                new Person(4, "Cody", "Jurut")
                {
                    Age = (Int32)(DateTime.Now - new DateTime(1970, 08, 11)).TotalDays / 365,
                    Birthday = new DateTime(1970, 08, 11),
                    IsWorking = false
                },
                new Person(5, "Simon", "Scranton")
                {
                    MaritalStatus = MaritalStatus.Single,

                    Age = (Int32)(DateTime.Now - new DateTime(1985, 10, 10)).TotalDays / 365,
                    Birthday = new DateTime(1985, 10, 10)
                },
                new Person(6, "Leena", "Laurent")
                {
                    MaritalStatus = MaritalStatus.Divorced,

                    Age = (Int32)(DateTime.Now - new DateTime(2000, 07, 01)).TotalDays / 365,
                    Birthday = new DateTime(2000, 07, 01),
                    IsWorking = false
                },
                new Person(7, "Ode", "Cosmides")
                {
                    MaritalStatus = MaritalStatus.Married,

                    Age = (Int32)(DateTime.Now - new DateTime(1966, 04, 17)).TotalDays / 365,
                    Birthday = new DateTime(1966, 04, 17),
                    IsWorking = true,

                    Children = new List<Person>
                    {
                        new Person(71, "Jake", "Cosmides")
                        {

                            Age = (Int32)(DateTime.Now - new DateTime(2014, 07, 14)).TotalDays / 365,
                            Birthday = new DateTime(2014, 07, 14)
                        }
                    }
                },
                new Person(8, "Diandra", "Mizner")
                {
                    MaritalStatus = MaritalStatus.Single,

                    Age = (Int32)(DateTime.Now - new DateTime(1999, 08, 20)).TotalDays / 365,
                    Birthday = new DateTime(1999, 08, 20),
                    IsWorking = false
                },
                new Person(9, "Pete", "Cassel")
                {
                    MaritalStatus = MaritalStatus.Married,

                    Age = (Int32)(DateTime.Now - new DateTime(1997, 03, 13)).TotalDays / 365,
                    Birthday = new DateTime(1997, 03, 13),
                    IsWorking = false
                },
                new Person(10, "Nicky", "Tremblay")
                {
                    MaritalStatus = MaritalStatus.Married,

                    Age = (Int32)(DateTime.Now - new DateTime(1988, 01, 05)).TotalDays / 365,
                    Birthday = new DateTime(1988, 01, 05),
                    IsWorking = true,

                    Children = new List<Person>
                    {
                        new Person(101, "Nick", "Tremblay")
                        {
                            Age = (Int32)(DateTime.Now - new DateTime(2013, 06, 08)).TotalDays / 365,
                            Birthday = new DateTime(2013, 06, 08)
                        },
                        new Person(102, "Nike", "Tremblay")
                        {
                            Age = (Int32)(DateTime.Now - new DateTime(2014, 12, 12)).TotalDays / 365,
                            Birthday = new DateTime(2014, 12, 12)
                        },
                        new Person(103, "Norbert", "Tremblay")
                        {
                            Age = (Int32)(DateTime.Now - new DateTime(2015, 05, 23)).TotalDays / 365,
                            Birthday = new DateTime(2015, 05, 23)
                        }
                    }
                }
            }.Where(person =>
                person.Age.ToString().Contains(search) ||
                person.Name.ToLower().Contains(search) ||
                person.Surname.ToLower().Contains(search) ||
                person.Birthday.ToString()!.Contains(search) ||
                person.IsWorking.ToString()!.ToLower().Contains(search) ||
                person.MaritalStatus.ToString()!.ToLower().Contains(search))
            .ToList();
        }
    }
}
