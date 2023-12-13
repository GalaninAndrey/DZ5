using ClassStudent;
using ClassTeacher;
using System.Xml.Linq;

namespace ClassStudentWithAdvisor
{
    public class StudentWithAdvisor : Student
    {
        private Teacher teacher;

        public Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }

        public StudentWithAdvisor(string _name, int _age, int _course) 
            :base(_name, _age, _course) { }

        public StudentWithAdvisor(StudentWithAdvisor original) 
            :base(original)
        {
            Teacher = original.Teacher;
        }

        public override void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Course: {Course}, Teacher: {Teacher}";
        }

        public override bool Equals(object? obj)
        {
            return obj != null && obj.GetType() == GetType() && obj.GetHashCode() == this.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode() ^ Course.GetHashCode();
        }

        public override StudentWithAdvisor Clone()
        {
            return new StudentWithAdvisor(this);
        }

        public void AppointTeacher(Teacher _teacher)
        {
            teacher = _teacher;
            _teacher.Students.Add(this);
        }

        public static StudentWithAdvisor RandomStudentWithAdvisor()
        {
            List<StudentWithAdvisor> onlyStudents = People.OfType<StudentWithAdvisor>().ToList();

            if (onlyStudents.Count == 0) return null;

            Random random = new Random();
            int randomIndex = random.Next(0, onlyStudents.Count);

            return onlyStudents[randomIndex];
        }
    }
}