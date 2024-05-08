using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC6Crud.Data;
using MVC6Crud.Interfaces;
using MVC6Crud.Models;
using MVC6Crud.Service;
using MVC6Crud.ViewModel;

namespace MVC6Crud.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        
        public IActionResult Index()
        {
            IEnumerable<Students> students = _studentRepository.RetrieveAllStudents();
            return View(students);

            //List<ProductListViewModel> productListViewModelList = new List<ProductListViewModel>();
            //var productList = _context.Products;
            //if (productList != null)
            //{
            //    foreach (var item in productList)
            //    {
            //        ProductListViewModel productListViewModel = new ProductListViewModel();
            //        productListViewModel.Id = item.Id;
            //        productListViewModel.Name = item.Name;
            //        productListViewModel.Description = item.Description;
            //        productListViewModel.Color = item.Color;
            //        productListViewModel.Price = item.Price;
            //        productListViewModel.CategoryId = item.CategoryId;
            //        productListViewModel.Image = item.Image;
            //        productListViewModel.CategoryName = _context.Categories.Where(c => c.CategoryId == item.CategoryId).Select(c => c.CategoryName).FirstOrDefault();
            //        productListViewModelList.Add(productListViewModel);
            //    }
            //}
            //return View(productListViewModelList);           
        }

        public IActionResult Create()
        {
            ProductViewModel productCreateViewModel = new ProductViewModel();
            //productCreateViewModel.Category = (IEnumerable<SelectListItem>)_context.Categories.Select(c => new SelectListItem()
            //{
            //    Text = c.CategoryName,
            //    Value = c.CategoryId.ToString()
            //});

            return View(productCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductViewModel productCreateViewModel)
        {
            //productCreateViewModel.Category = (IEnumerable<SelectListItem>)_context.Categories.Select(c => new SelectListItem()
            //{
            //    Text = c.CategoryName,
            //    Value = c.CategoryId.ToString()
            //});
            //var product = new Product()
            //{
            //    Name = productCreateViewModel.Name,
            //    Description = productCreateViewModel.Description,
            //    Price = productCreateViewModel.Price,
            //    Color = productCreateViewModel.Color,
            //    CategoryId = productCreateViewModel.CategoryId,
            //    Image = productCreateViewModel.Image
            //};
            //ModelState.Remove("Category");
            //if (ModelState.IsValid)
            //{
            //    _context.Products.Add(product);
            //    _context.SaveChanges();
            //    TempData["SuccessMsg"] = "Product ("+ product.Name + ") added successfully.";
            //    return RedirectToAction("Index");
            //}

            //return View(productCreateViewModel);

            return View(productCreateViewModel);
        }

        public IActionResult Edit(int Id)
        {
            Students? student = _studentRepository.RetrieveStudentById(Id);

            //var productToEdit = _context.Products.Find(id);
            //if (productToEdit != null)
            //{
            //    var productViewModel = new ProductViewModel()
            //    {
            //        Id = productToEdit.Id,
            //        Name = productToEdit.Name,
            //        Description = productToEdit.Description,
            //        Price = productToEdit.Price,
            //        CategoryId = productToEdit.CategoryId,
            //        Color = productToEdit.Color,
            //        Image = productToEdit.Image,
            //        Category = (IEnumerable<SelectListItem>)_context.Categories.Select(c => new SelectListItem()
            //        {
            //            Text = c.CategoryName,
            //            Value = c.CategoryId.ToString()                        
            //        })
            //    };
            //    return View(productViewModel);
            //}
            //else
            //{
            //    return NotFound();
            //}

            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Students student)
        {
            _studentRepository.EditStudent(student);
            return View(student);
        }
        public IActionResult Delete(int? id)
        {
            //var productToEdit = _context.Products.Find(id);
            //if (productToEdit != null)
            //{
            //    var productViewModel = new ProductViewModel()
            //    {
            //        Id = productToEdit.Id,
            //        Name = productToEdit.Name,
            //        Description = productToEdit.Description,
            //        Price = productToEdit.Price,
            //        CategoryId = productToEdit.CategoryId,
            //        Color = productToEdit.Color,
            //        Image = productToEdit.Image,
            //        Category = (IEnumerable<SelectListItem>)_context.Categories.Select(c => new SelectListItem()
            //        {
            //            Text = c.CategoryName,
            //            Value = c.CategoryId.ToString()
            //        })
            //    };
            //    return View(productViewModel);
            //}
            //else {
            //    return RedirectToAction("Index");
            //}            

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int? id)
        {
            //var product = _context.Products.Find(id);
            //if (product == null)
            //{
            //    return NotFound();
            //}
            //_context.Products.Remove(product);
            //_context.SaveChanges();
            //TempData["SuccessMsg"] = "Product (" + product.Name + ") deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
