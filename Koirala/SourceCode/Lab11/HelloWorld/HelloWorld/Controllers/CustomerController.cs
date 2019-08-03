using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloWorld.Models;
using HelloWorld.Dal;
using HelloWorld.ViewModel;
namespace HelloWorld.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Load()
        {
            Customer obj = 
                new Customer 
                    { 
                        CustomerCode = "1001", 
                        CustomerName = "Shiv" 
                    };

            return View("Customer",obj);
        }
        public ActionResult Enter()
        {
            // view model object
            CustomerViewModel obj = new CustomerViewModel();
            // // single object is fresh
            obj.customer = new Customer();
            // dal i have filled the customers collection
            CustomerDal dal = new CustomerDal();
            List<Customer> customerscoll = dal.Customers.ToList<Customer>();
            obj.customers = customerscoll;
            return View("EnterCustomer", obj);
        }
        public ActionResult EnterSearch()
        {
            CustomerViewModel obj = new CustomerViewModel();
            obj.customers = new List<Customer>();
            return View("SearchCustomer", obj);
        }
        public ActionResult SearchCustomer()
        {
            CustomerViewModel obj = new CustomerViewModel();
            CustomerDal dal = new CustomerDal();
            string str = Request.Form["txtCustomerName"].ToString();
            List<Customer> customerscoll
                = (from x in dal.Customers
                   where x.CustomerName == str
                   select x).ToList<Customer>();
            obj.customers = customerscoll;
            return View("SearchCustomer", obj);
        }
        public ActionResult Submit() // validation runs
        {
            CustomerViewModel vm = new CustomerViewModel();
            Customer obj = new Customer();
            obj.CustomerName = Request.Form["Customer.CustomerName"];
            obj.CustomerCode = Request.Form["Customer.CustomerCode"];
            if(ModelState.IsValid)
            {
                // insert the customer object to database
                // EF DAL
                CustomerDal Dal = new CustomerDal();
                Dal.Customers.Add(obj); // in mmemory
                Dal.SaveChanges(); // physical commit
                vm.customer = new Customer();
            }
            else
            {
                vm.customer = obj;
            }
            CustomerDal dal = new CustomerDal();
            List<Customer> customerscoll = dal.Customers.ToList<Customer>();
            vm.customers = customerscoll;
            return View("EnterCustomer",vm);
            
        }
    }
}