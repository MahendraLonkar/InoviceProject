
using InoviceProject.Models;
using InoviceProject.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Routing.Template;
using System.Numerics;

namespace InoviceProject.Controllers
{
   //[EnableCors("AllowOrigin")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        ICategoryRepository categoryRepository;
        ISubCategoryRepository subCategoryRepository;
        ILocationRepository locationRepository;
        IUnitRepository unitRepository;
        IProductRepository productRepository;
        IVendorRepository vendorRepository;
        IOrderItemsRepository OrderItemRepository;
        IProductReceivedStockRepository receivedStockRepository;
        IOrder_detailsRepository order_DetailsRepository;
        IInvoiceDetailsRepository invoiceDetailsRepository;
        ICustomerRepository customerRepository;
        IInvoiceProductRepository invoiceProductRepository;
        IInovicePaymentRepository inovicePaymentRepository;
        ICompanyDetailsRepository companyDetailsRepository;
        IProductReceivedItemsRepository productReceivedItemsRepository;
        public InvoiceController(ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository, 
            ILocationRepository locationRepository, IUnitRepository unitRepository, IProductRepository productRepository,
            IVendorRepository vendorRepository, IOrderItemsRepository OrderItemRepository,
            IProductReceivedStockRepository receivedStockRepository, IOrder_detailsRepository order_DetailsRepository,
            IInvoiceDetailsRepository invoiceDetailsRepository, ICustomerRepository customerRepository, IInvoiceProductRepository invoiceProductRepository,
            IInovicePaymentRepository inovicePaymentRepository, ICompanyDetailsRepository companyDetailsRepository, IProductReceivedItemsRepository productReceivedItemsRepository)
        {
            this.categoryRepository = categoryRepository;
            this.subCategoryRepository = subCategoryRepository;
            this.locationRepository = locationRepository;
            this.unitRepository = unitRepository;
            this.productRepository = productRepository;
            this.vendorRepository = vendorRepository;
            this.OrderItemRepository = OrderItemRepository;
            this.receivedStockRepository = receivedStockRepository;
            this.order_DetailsRepository = order_DetailsRepository;
            this.invoiceDetailsRepository = invoiceDetailsRepository;
            this.customerRepository = customerRepository;
            this.invoiceProductRepository = invoiceProductRepository;
            this.inovicePaymentRepository = inovicePaymentRepository;
            this.companyDetailsRepository = companyDetailsRepository;
            this.productReceivedItemsRepository = productReceivedItemsRepository;
        }





        //[HttpPost]
        //[Route("api/orderstock")]
        //public StockOrderModel OrderStock(StockOrderModel st)
        //{

        //    return st;
        //}

        //[HttpGet]
        //[Route("api/orderstockproduct")]
        //public List<Product_stock_order_Model> Getproduct()
        //{
        //    return stockOrderRepository.GetAllstock_orders();
        //}

        //[HttpPost]
        //[Route("api/orderstockproduct")]
        //public Product_stock_order_Model productstock(Product_stock_order_Model st)
        //{

        //    return st;
        //}




        [HttpGet]
        [Route("api/category")]
        public List<CategoryModel> GetAllCategories()
        {
            return categoryRepository.GetAllCategory();
        }

        [HttpGet]
        [Route("api/category/{id}")]
        public CategoryModel GetCategoryById(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }

        [HttpPost]
        [Route("api/category")]
        public string AddCategories(CategoryModel category)
        {
            tblCategory sc = new tblCategory()
            {
                Category_id = category.Category_id,
                Category_name = category.Category_name

            };
            categoryRepository.AddCategory(sc);
            return "Added Successfully";
        }

        [HttpPut]
        [Route("api/category")]
        public string UpdateCategory(CategoryModel category)
        {
            tblCategory sc = new tblCategory()
            {
                Category_id = category.Category_id,
                Category_name = category.Category_name

            };
            categoryRepository.UpdateCategory(sc);
            return "Updated Successfully";
        }

        [HttpDelete]
        [Route("api/category/{id}")]
        public string DeleteCategory(int id)
        {
            categoryRepository.DeleteCategory(id);
            return "Deleted Successfully";
        }


        //-------------------------- SubCategory --------------------------//

        [HttpGet]
        [Route("api/subcategory")]
        public List<SubCategoryModel> GetAllSubCategories()
        {
            return subCategoryRepository.GetAllSubCategory();
        }

        [HttpGet]
        [Route("api/subcategories/{id}")]
        public List<SubCategoryModel> GetcategorywiseSubCategories(int id)
        {
            return subCategoryRepository.GetCategoryWiseSubCategory(id);
        }

        [HttpPost]
        [Route("api/subcategory")]
        public string AddSubCategories(SubCategoryModel c)
        {
             
                tblSubCategory sc = new tblSubCategory()
                {
                    Category_id = c.Category_id,
                    SubCategory_name = c.SubCategory_name

                };
                subCategoryRepository.AddSubCategory(sc);
            return "Added Successfully";

        }


        [HttpGet]
        [Route("api/subcategory/{id}")]
        public SubCategoryModel GetSubCategoryById(int id)
        {
            return subCategoryRepository.GetSubCategoryById(id);
        }

        [HttpPut]
        [Route("api/subcategory")]
        public string UpdateSubCategory(SubCategoryModel subcategory)
        {
            tblSubCategory sc = new tblSubCategory()
            {
                Category_id = subcategory.Category_id,
                SubCategory_id=subcategory.SubCategory_id,
                SubCategory_name = subcategory.SubCategory_name

            };
            subCategoryRepository.UpdateSubCategory(sc);
            return "Updated Successfully";
        }

        [HttpDelete]
        [Route("api/subcategory/{id}")]
        public string DeleteSubCategory(int id)
        {
            subCategoryRepository.DeleteSubCategory(id);
            return "Deleted Successfully";
        }


        //-------------------------- Location --------------------------//


        [HttpGet]
        [Route("api/location")]
        public List<LocationModel> GetAllLocations()
        {
            return locationRepository.GetAllLocation();
        }

        [HttpPost]
        [Route("api/location")]
        public string AddLocations(LocationModel l)
        {
            tblLocation lm = new tblLocation()
            {
                Location_id = l.Location_id,
                Location_name = l.Location_name

            };
            locationRepository.AddLocation(lm);
            return "Added Successfully";
        }

        [HttpGet]
        [Route("api/location/{id}")]
        public LocationModel GetLocationById(int id)
        {
            return locationRepository.GetLocationById(id);
        }

        [HttpPut]
        [Route("api/location")]
        public string UpdateLocation(LocationModel location)
        {
            tblLocation lm = new tblLocation()
            {
                Location_id = location.Location_id,
                Location_name = location.Location_name

            };
            locationRepository.UpdateLocation(lm);
            return "Updated Successfully";
        }

        [HttpDelete]
        [Route("api/location/{id}")]
        public string DeleteLocation(int id)
        {
            locationRepository.DeleteLocation(id);
            return "deleted Successfully";
        }


        //-------------------------- Units --------------------------//


        [HttpGet]
        [Route("api/unit")]
        public List<UnitModel> GetAllUnits()
        {
            return unitRepository.GetAllUnit();
        }

        [HttpPost]
        [Route("api/unit")]
        public string AddUnits(tblUnit unit)
        {

            unitRepository.AddUnit(unit);
            return "Added Successfully";
        }

        [HttpGet]
        [Route("api/unit/{id}")]
        public UnitModel GetUnitById(int id)
        {
            return unitRepository.GetUnitById(id);
        }

        [HttpPut]
        [Route("api/unit")]
        public string UpdateUnit(UnitModel unit)
        {
            tblUnit um = new tblUnit()
            {
                Unit_id = unit.Unit_id,
                Unit_name = unit.Unit_name

            };
            unitRepository.Updateunit(um);
            return "Updated Successfully";
        }

        [HttpDelete]
        [Route("api/unit/{id}")]
        public string DeleteUnit(int id)
        {
            unitRepository.DeleteUnit(id);
            return "Deleted Successfully";
        }


        //-------------------------- Products --------------------------//



        [HttpGet]
        [Route("api/product")]
        public List<ProductModel> GetAllProducts()
        {
            return productRepository.GetAllProduct();
        }

        [HttpPost]
        [Route("api/product")]
        public string AddProducts(ProductDataModel product)
        {
                tblProduct sc = new tblProduct()
                {
                   
                   SubCategory_id=product.SubCategory_id,
                    Unit_id = product.Unit_id,
                    Product_name = product.Product_name,
                    Stock_quantity=product.Stock_quantity,
                    Selling_rate=product.Selling_rate,
                    Tax=product.Tax

                };
                productRepository.AddProduct(sc);
            return "Added Successfully";

        }

        [HttpGet]
        [Route("api/product/{id}")]
        public ProductModel GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }

        [HttpGet]
        [Route("api/categorybyproduct/{id}")]
        public List<ProductModel> GetCategoryByProductId(int id)
        {
            return productRepository.CategoryWiseProduct(id);
        }

        [HttpGet]
        [Route("api/unitbyproduct/{id}")]
        public List<ProductModel> GetUnitByProductId(int id)
        {
            return productRepository.UnitWiseProduct(id);
        }

        [HttpPut]
        [Route("api/product")]
        public string UpdateProduct(ProductDataModel product)
        {
            tblProduct sc = new tblProduct()
            {
                Product_id = product.Product_id,
                SubCategory_id = product.SubCategory_id,
                Unit_id = product.Unit_id,
                Product_name = product.Product_name,
                Stock_quantity = product.Stock_quantity,
                Selling_rate = product.Selling_rate,
                Tax=product.Tax

            };
            productRepository.UpdateProduct(sc);
            return "Updated Successfully";
        }

        [HttpDelete]
        [Route("api/product/{id}")]
        public string DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
            return "Deleted Successfully";
        }


        //-------------------------- Vendor --------------------------//



        [HttpGet]
        [Route("api/vendor")]
        public List<VendorModel> GetAllVendor()
        {
            return vendorRepository.GetAllVendor();
        }

        [HttpPost]
        [Route("api/vendor")]
        public string AddVendor(VendorModel vendor)
        {

                tblVendor l = new tblVendor()
                {
                    Vendor_name = vendor.Vendor_name,
                    Firm_name = vendor.Firm_name,
                    Firm_address = vendor.Firm_address,
                    Location_id =vendor.Location_id,
                    Mobile_number=vendor.Mobile_number,
                    Alternate_number=vendor.Alternate_number,
                    Email_address=vendor.Email_address

                };
                vendorRepository.AddVendor(l);
            return "Added Successfully";

        }

        [HttpGet]
        [Route("api/vendor/{id}")]
        public VendorModel GetVendorById(int id)
        {
            return vendorRepository.GetVendorById(id);
        }

        [HttpPut]
        [Route("api/vendor")]
        public string UpdateVendor(VendorModel vendor)
        {
            tblVendor l = new tblVendor()
            {
                Vendor_id=vendor.Vendor_id,
                Vendor_name = vendor.Vendor_name,
                Firm_name = vendor.Firm_name,
                Firm_address = vendor.Firm_address,
                Location_id = vendor.Location_id,
                Mobile_number = vendor.Mobile_number,
                Alternate_number = vendor.Alternate_number,
                Email_address = vendor.Email_address

            };
            vendorRepository.UpdateVendor(l);
            return "Updated Successfully";
        }

        [HttpDelete]
        [Route("api/vendor/{id}")]
        public string DeleteVendor(int id)
        {
            vendorRepository.DeleteVendor(id);
            return "Deleted Successfully";
        }


        //-------------------------- Order item --------------------------//





        [HttpGet]
        [Route("api/orderitem")]
        public List<order_items_Model> GetAllOrdersitems()
        {
            return OrderItemRepository.GetAllOrdersItems();
        }

        [HttpGet]
        [Route("api/orderitems/{id}")]
        public order_items_Model GetOrdersitemsById(int id)
        {
            return OrderItemRepository.GetOrderItemById(id);
        }

        [HttpGet]
        [Route("api/orderitem/{id}")]
        public List<order_items_Model> GetorderByproduct(int id)
        {
            return OrderItemRepository.OrderWiseProductId(id);
        }

        //[HttpPost]
        //[Route("api/stockorder")]
        //public string AddStockOrder(Product_stock_order_Model productStockOrder)
        //{
        //    //foreach(ProductQuantityModel qm in productStockOrder.productsdata)
        //    //{ 
        //    //    tblOrder_details l = new tblOrder_details()
        //    //    {

        //    //        //Vendor_id = productStockOrder.Vendor_id,
        //    //        //Order_date = productStockOrder.Order_date,
        //    //        Product_id=qm.Product_id,
        //    //        Order_quantity=qm.Order_quantity


        //    //    };
        //    //    stockOrderRepository.AddStockOrder(l);
        //    //}

        //    //tblOrder_details l = new tblOrder_details()
        //    //{
        //    //    invoice_id=productStockOrder.invoice_id,

        //    //    Product_id=productStockOrder.product_id,
        //    //    Order_quantity=productStockOrder.Order_quantity

        //    //};
        //    stockOrderRepository.AddStockOrder(l);
        //    return "Added Successfully";
        //}

        //[HttpGet]
        //[Route("api/stockorder/{id}")]
        //public Product_stock_order_Model GetStockOrderById(int id)
        //{
        //    return stockOrderRepository.GetStockOrderById(id);
        //}

        //[HttpPut]
        //[Route("api/stockorder")]
        //public string UpdateStockOrder(Product_stock_order_Model productStockOrder)
        //{
        //    tblOrder_details l = new tblOrder_details()
        //    {
        //        Order_id=productStockOrder.Order_id,
        //        //Vendor_id = productStockOrder.Vendor_id,
        //        //Product_id = productStockOrder.Product_id,
        //        //Order_date = productStockOrder.Order_date,
        //        //Order_quantity = productStockOrder.Order_quantity

        //    };
        //    stockOrderRepository.UpdateStockOrder(l);
        //    return "Updated Successfully";
        //}

        //[HttpDelete]
        //[Route("api/stockorder/{id}")]
        //public string DeleteStockOrder(int id)
        //{
        //    stockOrderRepository.DeleteStockOrder(id);
        //    return "Deleted Successfully";
        //}


        //-------------------------- Received Stocks --------------------------//


        [HttpGet]
        [Route("api/receivedstock")]
        public List<Product_received_stock_Model> GetAllReceivedStocks()
        {
            return receivedStockRepository.GetProduct_received_stock();
        }
        [HttpGet]
        [Route("api/receivedstocks/{id}")]
        public  List<Product_received_stock_Model> GetorderwiseReceivedstockid(int id)
        {
            return receivedStockRepository.OrderWiseReceivedStock(id);
        }


        [HttpPost]
        [Route("api/receivedstock")]
        public string AddReceivedStocks(Product_received_stock_Model productReceivedStock)
        {

            tblReceived_details l = new tblReceived_details()
            {
                Order_id = productReceivedStock.Order_id,
                Received_date = productReceivedStock.Received_date,
                
                ReceivedItems = new List<tblReceived_Items>()
                
            };
            foreach (Received_Item_Model received_Item in productReceivedStock.ReceivedItems)
            {
                tblReceived_Items items = new tblReceived_Items()
                {
                    Receive_id = received_Item.Receive_id,
                    orderitem_id = received_Item.orderitem_id,
                    received_quantity = received_Item.received_quantity,
                    Purchase_rate = received_Item.purchase_rate,
                };
                
                l.ReceivedItems.Add(items);
            }
            receivedStockRepository.AddReceivedStock(l);
            return "Added Successfully";
        }

        [HttpGet]
        [Route("api/receivedstock/{id}")]
        public Product_received_stock_Model GetReceivedStocksById(int id)
        {
            return receivedStockRepository.GetReceivedStockById(id);
        }

        [HttpPut]
        [Route("api/receivedstock")]
        public string UpdateReceivedStocks(Product_received_stock_Model productReceivedStock)
        {
            tblReceived_details l = new tblReceived_details()
            {
                Receive_stock_id= productReceivedStock.Receive_stock_id,
                Order_id= productReceivedStock.Order_id,
                Received_date = productReceivedStock.Received_date,

            };
            receivedStockRepository.UpdateReceivedStock(l);
            return "Updated Successfully";
        }

        [HttpDelete]
        [Route("api/receivedstock/{id}")]
        public string DeleteReceivedStocks(int id)
        {
            receivedStockRepository.DeleteReceivedStock(id);
            return "Deleted Successfully";
        }


        [HttpGet]
        [Route("api/receiveditem")]
        public List<ItemModel> GetReceivedItem()
        {
            return productReceivedItemsRepository.GetAllReceivedItems();
;
        }


        [HttpGet]
        [Route("api/receiveditemByid/{id}")]
        public ItemModel GetReceivedItemById(int id)
        {
            return productReceivedItemsRepository.GetReceivedItemById(id)
;
        }

        [HttpGet]
        [Route("api/orderitemwiseReceiveditem/{id}")]
        public List<ItemModel> GetorderitemwiseReceiveditem(int id)
        {
            return productReceivedItemsRepository.GetorderitemwiseReceiveditem(id)
;
        }

        [HttpGet]
        [Route("api/receivedstockmwiseReceiveditem/{id}")]
        public List<ItemModel> GetreceivedstockmwiseReceiveditem(int id)
        {
            return productReceivedItemsRepository.GetreceivedstockmwiseReceiveditem(id)
;
        }

        //-------------------------- Order Details --------------------------//

        [HttpGet]
        [Route("api/orderdetails")]
        public List<Order_details_Model> GetAllOrderDetails()
        {
            return order_DetailsRepository.GetAllOrder();
        }

        [HttpPost]
        [Route("api/orderdetails")]
        public string AddOrderDetails(Order_details_Model order)
        {
            
                tblOrder_details newOrder = new tblOrder_details()
                {
                    vendor_id = order.vendor_id,
                    order_date = order.order_date,
                    Is_Received = false,
                    OrderItems = new List<tblOrder_items>()
                };
                foreach (order_items_Model orderDetail in order.OrderItems)
                {
                    tblOrder_items newItem = new tblOrder_items()
                    {
                        Product_id = orderDetail.product_id,
                        Order_quantity = orderDetail.Order_quantity
                    };
                    newOrder.OrderItems.Add(newItem);
                }

                order_DetailsRepository.AddOrder(newOrder);
            
            return "Order added successfully";
        }
        

        [HttpPut]
        [Route("api/orderdetails")]
        public string UpdateOrderDetails(Order_details_Model order)
        {
            tblOrder_details l = new tblOrder_details()
            {
                order_id = order.order_id,
                vendor_id = order.vendor_id,

                //  Product_id = productStockOrder.Product_id,
                order_date = order.order_date,
                


            };
            
            order_DetailsRepository.UpdateOrder(l);
            return "Updated successfully";
        }

        [HttpGet]
        [Route("api/orderdetailswiseVendor/{id}")]
        public Order_details_Model GetOrderWiseVendorId(int id)
        {
            return order_DetailsRepository.GetOrderwiseVendorId(id);
        }


        [HttpGet]
        [Route("api/orderdetails/{id}")]
        public Order_details_Model GetOrderByid(int id)
        {
            return order_DetailsRepository.GetOrderById(id);
        }


        //-------------------------- Invoice Details --------------------------//


        [HttpGet]
        [Route("api/invoicedetails")]
        public List<Invoice_Details_Model> GetAllInvoiceDetails()
        {
            return invoiceDetailsRepository.GetAllInvoiceDetails();
        }

        [HttpGet]
        [Route("api/invoicedetails/{id}")]
        public Invoice_Details_Model GetInvoiceDetailsByid(int id)
        {
            return invoiceDetailsRepository.GetInvoice_DetailsById(id);
        }

        [HttpGet]
        [Route("api/invoicedetailwisecustomer/{id}")]
        public List<Invoice_Details_Model> GetCustomerWiseInvoiceDetails(int id)
        {
            return invoiceDetailsRepository.GetCustomerWiseInvoiceDetails(id);
        }


        

        [HttpPost]
        [Route("api/invoicedetails")]
        public string AddInvoiceDetails(Invoice_Details_Model invoice_Details)
        {
            tblInvoice_details i=new tblInvoice_details()
            {
                invoice_date=invoice_Details.invoice_date,
                invoice_amount=invoice_Details.invoice_amount,
                customer_id=invoice_Details.customer_id,
                Invoice_Products= new List<tblInvoice_Product>()
            };
            foreach (Invoice_Product_Model invoice_Product in invoice_Details.Invoice_Products)
            {
                tblInvoice_Product newItem = new tblInvoice_Product()
                {
                    product_id=invoice_Product.product_id,
                    
                    quantity=invoice_Product.quantity,
                };
                i.Invoice_Products.Add(newItem);
            }
           
            invoiceDetailsRepository.AddInvoiceDetails(i);
            return "Added Successfully";
        }



        //-------------------------- Customer Details --------------------------//


        [HttpGet]
        [Route("api/customer")]
        public List<Customer_Model> GetAllCustomer()
        {
            return customerRepository.GetAllCustomer();
        }

        [HttpGet]
        [Route("api/customer/{id}")]
        public Customer_Model GetCustomerByid(int id)
        {
            return customerRepository.GetCustomerById(id);
        }

        [HttpPost]
        [Route("api/customer")]
        public string AddCustomer(Customer_Model customer)
        {
            tblCustomer sc = new tblCustomer()
            {
                customer_id = customer.customer_id,
                customer_name=customer.customer_name,
                mobile_number=customer.mobile_number

            };
            customerRepository.AddCustomer(sc);
            return "Added Successfully";
        }


        //-------------------------- Invoice Product --------------------------//


        [HttpGet]
        [Route("api/invoiceproduct")]
        public List<Invoice_Product_Model> GetAllInvoiceProduct()
        {
            return invoiceProductRepository.GetAllInvoiceproduct();
        }

        [HttpGet]
        [Route("api/invoicescounts")]
        public List<InvoiceSummary> GetInvoices()
        {
            var invoices = new List<InvoiceSummary>();
            return invoiceProductRepository.GetAllInvoicesummary();
        }

        [HttpGet]
        [Route("api/invoicestotalquantity")]
        public List<Invoice_quantityproduct_model> GetInvoicesTotalQuantity()
        {
            return invoiceProductRepository.GetAllInvoiceTotalQuantity();
        }


        [HttpGet]
        [Route("api/invoiceproduct/{id}")]
        public Invoice_Product_Model GetInvoiceProductByid(int id)
        {
            return invoiceProductRepository.GetInvoiceProductById(id);
        }

        [HttpGet]
        [Route("api/invoiceproductwiseproduct/{id}")]
        public List<Invoice_Product_Model> GetInvoiceProductByProductid(int id)
        {
            return invoiceProductRepository.GetProductWiseInvoiceProduct(id);
        }


        [HttpGet]
        [Route("api/invoicewiseinvoiceproduct/{id}")]
        public List<Invoice_Product_Model> GetInvoiceByInvoiceProductid(int id)
        {
            return invoiceProductRepository.GetinvoiceWiseInvoiceProduct(id);
        }



        //-------------------------- Invoice payment --------------------------//




        [HttpPost]
        [Route("api/payment")]
        public string AddInvoicePayment(Invoice_Pay_Model payments)
        {

            tblinvoice_payments sc = new tblinvoice_payments()
            {
                invoice_id = payments.invoice_id,
                payment_date = payments.payment_date,
                payment_amount = payments.payment_amount,
                payment_mode = payments.payment_mode,
                description = payments.description

            };
            inovicePaymentRepository.AddInvoicePayment(sc);
            return "Added Successfully";
            
        }

        [HttpGet]
        [Route("api/invoicewisepayment/{id}")]
        public List<Invoice_Payment_Model> GetInvoiceDetailWisePayment(int id)
        {
            return inovicePaymentRepository.GetInvoiceDetailWisePayment(id);
        }

        [HttpGet]
        [Route("api/payment")]
        public List<Invoice_Payment_Model> GetAllPayment()
        {
            return inovicePaymentRepository.GetInvoicePayment();
        }


        //-------------------------- Company Details --------------------------//


        [HttpGet]
        [Route("api/companydetail/{id}")]
        public CompanyModel GetCompanyDetailById(int id)
        {
            return companyDetailsRepository.GetCompanybyId(id);
        }

        [HttpGet]
        [Route("api/companydetail")]
        public List<CompanyModel> GetAllCompanyDetails()
        {
            return companyDetailsRepository.GetAllCompanyDetails();
        }

    }
}