namespace StudentCrudUsingEF.Models
{
    public class StudentCrud
    {
        ApplicationDbContext context;
        public StudentCrud(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<Student> GetAllStudents()
        {
            return context.Stud.Where(x => x.IsActive == 1).ToList();
        }
        public Student GetStudentById(int id)
        {
            var student = context.Stud.Where(x => x.Roll == id).FirstOrDefault();
            return student;
        }
        public int AddStudent(Student student)
        {
            student.IsActive = 1;
            int result = 0;
            context.Stud.Add(student);
            result = context.SaveChanges();
            return result;
        }
        public int UpdateStudent(Student student)
        {            
            int result = 0;
           var s = context.Stud.Where(x => x.Roll == student.Roll).FirstOrDefault();
            if (s != null)
            {
                s.Roll = student.Roll;
                s.Name = student.Name;
                s.Percentage = student.Percentage;
                s.IsActive = 1;
                result = context.SaveChanges();
            }
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            var s = context.Stud.Where(x => x.Roll == id).FirstOrDefault();
            if (s != null)
            {
                
                s.IsActive = 0;
                result = context.SaveChanges();
            }
            return result;
        }
    }
}
