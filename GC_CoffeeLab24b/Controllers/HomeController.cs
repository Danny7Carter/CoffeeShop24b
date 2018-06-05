using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GC_CoffeeLab24b.Models;

namespace GC_CoffeeLab24b.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ItemList()
        {
            CoffeeShopEntities db = new CoffeeShopEntities();
            List<Item> Items = db.Items.ToList();
            ViewBag.Items = Items;

            //ViewBag.Statuses = db.Statuses.ToList();

            return View();
        }

        //filter by status
        public ActionResult ItemListByQuantity(int Quantity)
        {
            CoffeeShopEntities db = new CoffeeShopEntities();
            
            //LINQ Query
            List<Item> Items = (from b in db.Items
                                where b.Quantity == Quantity
                                select b).ToList();
            ViewBag.Items = Items;

            ViewBag.Quantity = db.Quantity.ToString(); 

            return View("ItemList");
        }
        //public=Access modifier**
        //returnType=ActionResult
        //BookListByAuthor=Method name
        public ActionResult ItemListByItemName(string ItemName)
        {
            CoffeeShopEntities db = new CoffeeShopEntities();
            //LINQ Query
            List<Item> books = (from b in db.Items
                                where b.ItemName.Contains(ItemName)
                                select b).ToList();
            dynamic Items = null;
            ViewBag.Items = Items;

            ViewBag.ItemName = db.Items.ToList();

            return View("ItemList");
        }

        public ActionResult ItemListSorted(string column)
        {
            CoffeeShopEntities db = new CoffeeShopEntities();
            //LINQ Query
            if (column == "ItemID")
            {
                ViewBag.Books = (from b in db.Items
                                 orderby b.ItemID
                                 select b).ToList();
            }
            else if (column == "ItemName")
            {
                ViewBag.Books = (from b in db.Items
                                 orderby b.ItemName
                                 select b).ToList();
            }
            else if (column == "Description")
            {
                ViewBag.Books = (from b in db.Items
                                 orderby b.Description
                                 select b).ToList();
            }
            else if (column == "Quantity")
            {
                ViewBag.Books = (from b in db.Items
                                 orderby b.Quantity
                                 select b).ToList();
            }
            else if (column == "Price")
            {
                ViewBag.Books = (from b in db.Items
                                 orderby b.Price
                                 select b).ToList();
            }

            ViewBag.ItemID = db.Items.ToList();

            return View("ItemList");
        }
        public ActionResult Add(string ItemName)
        {
            CoffeeShopEntities db = new CoffeeShopEntities();

            //check if the Cart object already exists
            if (Session["Cart"] == null)
            {
                //if it doesn't, make a new list of books
                List<Item> cart = new List<Item>();
                //add this book to it
                cart.Add((from b in db.Items
                          where b.ItemName == ItemName
                          select b).Single());
                //add the list to the session
                Session.Add("Cart", cart);
            }
            else
            {
                //if it does exist, get the list
                List<Item> cart = (List<Item>)(Session["Cart"]);
                //add this book to it
                cart.Add((from b in db.Items
                          where b.ItemName == ItemName
                          select b).Single());
            }
            return View();
        }
    }
}