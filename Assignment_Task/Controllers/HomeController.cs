using Assignment_Task.Models;
using Assignment_Task.Repositery;
using Assignment_Task.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Assignment_Task.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICustomerInfoService customerInfo;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ICustomerInfoService customerInfo, ILogger<HomeController> logger)
        {
            this.customerInfo = customerInfo;
            _logger = logger;

        }
        #region Customer (Get, Add, Update, Delete)
        public IActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// Add or Update Customer Detail in Database
        /// </summary>
        /// <param name="customer"> customer as CustomerInfoVM</param>
        /// <returns> Response Status in ResponceVM</returns>
        [HttpPost]
        public async Task<IActionResult> Index([FromBody] CustomerInfoVM customer)
        {
            var res = new ResponceVM();
            try
            {
                if (ModelState.IsValid)
                {
                    res = await customerInfo.AddUpdateCustomer(customer);
                }
                else
                {
                    res.Status = 0;
                    res.MSG ="Invalid Data .";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Json(res);
        }

        /// <summary>
        /// Get List Of All Customer
        /// </summary>
        /// <returns>List Response in List<CustomerInfoVM></returns>
        [HttpGet]
        public async Task<JsonResult> GetCustomerList()
        {
            var listVM = new List<CustomerInfoVM>();
            try
            {
                listVM = await customerInfo.GetAllCustomers();
            }
            catch (Exception)
            {

                throw;
            }
            return Json(listVM);
        }

        /// <summary>
        /// Delete the record of Customer based on CustomerId
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns> Response Status in ResponceVM</returns>
        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int CustomerId)
        {
            var res = new ResponceVM();
            try
            {
                res = await customerInfo.DeleteCustomer(CustomerId);
            }
            catch (Exception)
            {

                throw;
            }
            return Json(res);
        }

        /// <summary>
        /// Get detail of Employee by Employee Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns> Return Customer Detail as CustomerInfoVM</returns>
        [HttpGet]
        public async Task<IActionResult> GetCustomerById(int CustomerId)
        {
            var res = new CustomerInfoVM();
            try
            {
                res = await customerInfo.GetCustomerById(CustomerId);
            }
            catch (Exception)
            {

                throw;
            }
            return Json(res);
        }

        #endregion

        #region Get All Lists (Gender, State, City)
        /// <summary>
        /// Get Gender list
        /// </summary>
        /// <returns>List of Gender</returns>
        [HttpGet]
        public async Task<JsonResult> GetGenderList()
        {
            var listVM = new List<ListVM>();
            try
            {
                listVM = await customerInfo.GetGenderList();
            }
            catch (Exception)
            {

                throw;
            }
            return Json(listVM);
        }

        /// <summary>
        /// Get State list
        /// </summary>
        /// <returns>List of State</returns>
        [HttpGet]
        public async Task<JsonResult> GetStateList()
        {
            var listVM = new List<ListVM>();
            try
            {
                listVM = await customerInfo.GetStateList();
            }
            catch (Exception)
            {

                throw;
            }
            return Json(listVM);
        }
        /// <summary>
        /// Get District list
        /// </summary>
        /// <returns>List of District</returns>
        [HttpGet]
        public async Task<JsonResult> GetDistrictList(int stateId)
        {
            var listVM = new List<ListVM>();
            try
            {
                listVM = await customerInfo.GetDistrictList(stateId);
            }
            catch (Exception)
            {

                throw;
            }
            return Json(listVM);
        }
        #endregion

        // Error action to handle exceptions and status codes
        [Route("Home/Error")]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                // Handle specific status codes (like 404 Not Found)
                if (statusCode == 404)
                {
                    return View("NotFound");
                }
            }

            // For general errors, display a generic error view
            return View("Error");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
