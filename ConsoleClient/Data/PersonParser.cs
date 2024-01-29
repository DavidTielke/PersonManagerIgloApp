﻿using ConsoleClient.CrossCutting;

namespace ConsoleClient.Data
{
    public class PersonParser : IPersonParser
    {
        public IEnumerable<Person> ParseFromCsv(string[] lines)
        {
            return lines.Select(l => l.Split(","))
                .Select(p => new Person
                {
                    Id = int.Parse(p[0]),
                    Name = p[1],
                    Age = int.Parse(p[2]),
                });
        }

        public string ParseToCsv(Person person)
        {
            return $"{person.Id},{person.Name},{person.Age}";
        }
    }
}
