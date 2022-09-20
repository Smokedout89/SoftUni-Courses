using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (students.Count + 1 > Capacity)
            {
                return "No seats in the classroom";
            }

            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            var student = students.FirstOrDefault(n => n.FirstName == firstName && n.LastName == lastName);

            if (student == null)
            {
                return "Student not found";
            }

            students.Remove(student);
            return $"Dismissed student {firstName} {lastName}";
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.FirstOrDefault(n => n.FirstName == firstName && n.LastName == lastName);
        }

        public string GetSubjectInfo(string subject)
        {
            var subjectStudents = students.Where(s => s.Subject == subject);

            if (subjectStudents.Count() == 0)
            {
                return "No students enrolled for the subject";
            }

            var sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in subjectStudents)
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
