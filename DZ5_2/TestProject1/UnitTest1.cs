using ClassStudentWithAdvisor;
using ClassStudent;
using ClassTeacher;
using DZ;

namespace TestClasses
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRandom()
        {
            Person p1 = new Person("Andrew", 21);
            Teacher t1 = new Teacher("Misha", 32);
            Teacher t2 = new Teacher("Masha", 27);
            StudentWithAdvisor s1 = new StudentWithAdvisor("Vovan", 20, 3);
            StudentWithAdvisor s2 = new StudentWithAdvisor("Andrew", 22, 4);
            Person.People = new List<Person> { s1, p1, t1, s2, t2 };
            s1.AppointTeacher(Teacher.RandomTeacher());
            s2.AppointTeacher(Teacher.RandomTeacher());
            Assert.IsNotNull(s1.Teacher);
            Assert.IsNotNull(s2.Teacher);
        }

        [TestMethod]
        public void TestEquals()
        {
            Person p1 = new Person("Andrew", 21);
            Assert.IsTrue(p1.Equals(new Person("Andrew", 21)));
            Assert.IsFalse(p1.Equals(new Person("Andrew", 20)));
            Assert.IsFalse(p1.Equals(new Teacher("Andrew", 21)));
        }

        [TestMethod]
        public void TestClone()
        {
            Teacher t1 = new Teacher("Dimon", 38);
            Teacher t2 = t1.Clone();
            Assert.AreEqual(t1, t2);
        }

        [TestMethod]
        public void TestToString()
        {
            Person p1 = new Person("Andrew", 21);
            Assert.AreEqual("Name: Andrew, Age: 21", p1.ToString());
        }
    }
}