using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TableFilter.Enums;
using TableFilter.Models;

namespace TableFilter.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index(int page=1)
        {
            List<Employee> employees = Employees();

            //var result = employees.ToPagedList(page,10);
            TempData["Employees "] = employees.ToPagedList(page, 5);
            return View();
        }

        [HttpGet]
        public ActionResult Filter(int page= 1, string q = "", FilterTypes filterType = FilterTypes.AllFilter)
        {
            var employees = Employees();
            switch (filterType)
            {
                case FilterTypes.NameFilter:
                    employees = employees.Where(i => i.Name.ToLower().Contains(q.ToLower())).ToList();
                    break;
                case FilterTypes.SurnameFilter:
                    employees = employees.Where(i => i.Surname.ToLower().Contains(q.ToLower())).ToList();
                    break;
                case FilterTypes.CompanyFilter:
                    employees = employees.Where(i => i.Company.ToLower().Contains(q.ToLower())).ToList();
                    break;
                case FilterTypes.AllFilter:
                    employees = employees.Where(i => i.Name.ToLower().Contains(q.ToLower()) || i.Surname.ToLower().Contains(q.ToLower()) || i.Company.ToLower().Contains(q.ToLower())).ToList();
                    break;
                default:
                    break;
            }
            TempData["Employees "]= employees.ToPagedList(page, 5);
            return Json(employees.ToPagedList(page,5), JsonRequestBehavior.AllowGet);
        }

        public static List<Employee> Employees()
        {
            var list = new List<Employee>()
        {
             new Employee() { Id = 1, Name = "Ertuğrul", Surname = "Güler", Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 2, Name = "Mücahit", Surname = "Güler", Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 3, Name = "Ahmet", Surname = "Yavuz", Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 4,Name = "Fatih", Surname = "Ekşi", Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 5, Name = "Ahmet", Surname = "Yılmaz", Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 6, Name = "Yusuf", Surname = "Avcı", Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 7, Name = "Erkin", Surname = "Biber", Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 8, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 9, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 10, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 11, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 12, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 13, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 14, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 15, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 16, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 17, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 18, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 19, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
             new Employee() { Id = 20, Name = FakeData.NameData.GetFirstName(), Surname = FakeData.NameData.GetSurname(), Company = FakeData.NameData.GetCompanyName() },
        };
            return list;
        }
    }


}
