using DZ;
using System.Xml.Linq;

namespace ClassStudent
{
    public class Student : Person
    {
        private int course;

        public int Course
        {
            get { return course; }
            set
            {
                if (course < 0) value = 0;
                else if (course > 4) value = 4;
                course = value;
            }
        }

        public Student(string _name, int _age, int _course) 
            :base(_name, _age)
        {
            course = _course;
        }

        public Student(Student original) 
            :base(original)
        {
            Course = original.Course;
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Course: {Course}";
        }

        public override bool Equals(object? obj)
        {
            return obj != null && obj.GetType() == GetType() && obj.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode() ^ Course.GetHashCode();
        }

        public override Student Clone()
        {
            return new Student(this);
        }

        public static Student RandomStudent()
        {
            List<Student> onlyStudents = People.OfType<Student>().ToList();

            if (onlyStudents.Count == 0) return null;

            Random random = new Random();
            int randomIndex = random.Next(0, onlyStudents.Count);

            return onlyStudents[randomIndex];
        }
    }
}