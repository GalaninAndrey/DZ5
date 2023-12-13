namespace DZ
{
    public class Person
    {
        private string name;
        private int age;
        private static List<Person> people = new List<Person>();

        public string Name
        {
            get { return name; }
            set 
            { 
                if (value == "") 
                    value = "NoName"; 
                name = value; 
            }
        }

        public int Age
        {
            get { return age; }
            set 
            {  
                if (value < 0) 
                    value = 0; 
                age = value; 
            }
        }

        public static List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public Person(string _name, int _age)
        {
            Name = _name;
            Age = _age;
        }

        public Person(Person original)
        {
            Name = original.Name;
            Age = original.Age;
        }

        public virtual void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }

        public override bool Equals(object? obj)
        {
            return obj != null && obj.GetType() == GetType() && obj.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }

        public virtual Person Clone()
        {
            return new Person(this);
        }

        public static Person RandomPerson()
        {
            List<Person> onlyPersons = People.OfType<Person>().ToList();

            if (onlyPersons.Count == 0) return null;

            Random random = new Random();
            int randomIndex = random.Next(0, onlyPersons.Count);

            return onlyPersons[randomIndex];
        }
    }
}