using System;

namespace Geekbrains
{
    public sealed class ExampleDeepCopy
    {
        public class Person : ICloneable
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public Company Work { get; set; }
 
            public object Clone()
            {
                Company company = new Company { Name = Work.Name };
                return new Person
                {
                    Name = Name,
                    Age = Age,
                    Work = company
                };
            }
        }
 
        public class Company
        {
            public string Name { get; set; }
        }
    }
}

