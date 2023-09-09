using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCrudUsingEF.Models;

namespace StudentCrudUsingEF.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext context;
        StudentCrud studcrud;
        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
            studcrud = new StudentCrud(this.context);
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var model = studcrud.GetAllStudents();
            return View(model);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(studcrud.GetStudentById(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                var res = studcrud.AddStudent(student);
                if (res == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(studcrud.GetStudentById(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            try
            {
                var res = studcrud.UpdateStudent(student);
                if (res == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(studcrud.GetStudentById(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                var res = studcrud.DeleteStudent(id);
                if (res == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
