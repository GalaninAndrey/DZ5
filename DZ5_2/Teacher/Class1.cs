using DZ;
using ClassStudent;
using System.Xml.Linq;

namespace ClassTeacher
{
    public class Teacher : Person
    {
        private List<Student> students;

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public Teacher(string _name, int _age) 
            : base(_name, _age)
        {
            students = new List<Student>();
        }

        public Teacher(Teacher original) 
            : base(original)
        {
            Students = original.Students;
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Students: {string.Join(", ", Students.Select(s => s.Name))}";
        }

        public override bool Equals(object? obj)
        {
            return obj != null && obj.GetType() == GetType() && obj.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }

        public override Teacher Clone()
        {
            return new Teacher(this);
        }

        public static Teacher RandomTeacher()
        {
            List<Teacher> onlyTeachers = People.OfType<Teacher>().ToList();

            if (onlyTeachers.Count == 0) return null;

            Random random = new Random();
            int randomIndex = random.Next(0, onlyTeachers.Count);

            return onlyTeachers[randomIndex];
        }
    }
}