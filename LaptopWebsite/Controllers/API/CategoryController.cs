using LaptopWebsite.Dao.IDao;
using LaptopWebsite.Models.Mapping;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication2.Models;
using LaptopWebsite.Service.Common;
using LaptopWebsite.Dao;

namespace LaptopWebsite.Controllers.API
{
    public class CategoryController : ApiController
    {
        private CategoryDao categoryDao;

        public CategoryController()
        {
            this.categoryDao = new CategoryDaoImp();
        }
        
        //Get All Categories in database
        [HttpGet]
        [Route("api/category/get-all")]
        public IHttpActionResult AllCategories()
        {
            var results = this.categoryDao.PageView(1, 10, "name");
            Response res = new Response();
            res.code = "200";
            res.status = "success";
            res.pageIndex = results.CurrentPage;
            res.pageSize = results.PageSize;
            res.total = results.RowCount;
            res.results = results.Results;
            return Ok(res);
        }

        //Create New Category
        [Route("api/category/create")]
        [HttpPost]
        public IHttpActionResult CreateCategory(Category category)
        {
            Response response = new Response();
            if (!ModelState.IsValid)
            {
                response.code = "400";
                response.status = "Not a valid model";
                return BadRequest(response.ToString());
            }

            if (category.name.Length == 0 || category.name == null)
            {
                response.code = "300";
                response.status = "Missing Required Field";
                return Ok(response);
            }

            category.code = Utils.RandomString(10);

            IEnumerable<Category> categories = this.categoryDao.GetCategory();
            List<Category> listCategories = new List<Category>();
            for (int i = 0; i < listCategories.ToArray().Length; i++)
            {
                if (listCategories[i].name == category.name)
                {
                    response.code = "301";
                    response.status = "Category name is Exist";
                    return Ok(response);
                }
            }

            this.categoryDao.InsertCategory(new Category(category.code,category.name));
            this.categoryDao.Save();

            response = new Response();
            response.code = "201";
            response.status = "Created";

            return Created("Created", response);
        }

        //Update Category
        [Route("api/category/update")]
        [HttpPut]
        public IHttpActionResult UpdateCategory(Category category)
        {
            Response response = new Response();
            IEnumerable<Category> categories = this.categoryDao.GetCategory();
            List<Category> listCategories = new List<Category>();
            for (int i = 0; i < listCategories.ToArray().Length; i++)
            {
                if(listCategories[i].name == category.name)
                {
                    response.code = "301";
                    response.status = "Category name is Exist";
                    return Ok(response);
                }
            }

            this.categoryDao.UpdateCategory(category);
            this.categoryDao.Save();
            response.code = "200";
            response.status = "Updated Success";

            return Ok(response);
        }

        //Delete Category By Id
        [Route("api/category/delete/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteCategory(short id)
        {
            Response response = new Response();
            Category category = this.categoryDao.GetCategoryById(id);
            if(category == null)
            {
                response.code = "404";
                response.status = "Can not find Category";
                return Ok(response);
            }

            this.categoryDao.DeleteCategory(id);
            response.code = "200";
            response.status = "Delete Success";
            return Ok(response);
        }
    }
}