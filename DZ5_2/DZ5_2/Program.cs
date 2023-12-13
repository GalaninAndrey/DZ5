using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DZ;
using ClassStudent;
using ClassTeacher;
using ClassStudentWithAdvisor;



namespace DZ5
{
    class Work
    {
        static void Main()
        {
            var people = new List<Person>
        {
            new Student("TestStudent", 22, 3),
            new Teacher("TestTeacher", 45)
        };

            Console.WriteLine("Original people list:");
            Console.WriteLine(string.Join("\n", people));

            var peopleCopy = people.Select(p => (Person)p.Clone()).ToList();

            foreach (var person in peopleCopy)
            {
                if (person is Student)
                {
                    (person as Student).Course++;
                    person.Print();
                }
                else if (person is Teacher)
                {
                    person.Print();
                }
                else
                {
                    person.Print();
                }
            }
        }
    }
}