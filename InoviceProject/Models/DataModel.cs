using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using InoviceProject.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace InoviceProject.Models
{
    public class DataModel
    {
    }

    public class CategoryModel
    {
        public int Category_id { get; set; }
        public string Category_name { get; set; }
    }

    public class SubCategoryModel
    {
        public int SubCategory_id { get; set; }
        public string SubCategory_name { get; set; }
        public int Category_id { get; set; }
        public string Category_name { get; set; }
    }


    public class LocationModel
    {
        public int Location_id { get; set; }
        public string Location_name { get; set; }
    }

    public class UnitModel
    {
        public int Unit_id { get; set; }
        public string Unit_name { get; set; }
    }

    public class ProductModel
    {
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int SubCategory_id { get; set; }
        public string SubCategory_Name { get; set; }
        public int category_id { get; set; }
        public string category_name { get; set; }
        public float Weight { get; set; }
        public int Unit_id { get; set; }
        public string Unit_Name { get; set; }
        public int Stock_quantity { get; set; }
        public float Selling_rate { get; set; }
        public float Tax { get; set; }
    }

    public class ProductDataModel
    {
        public int Product_id { get; set; }
        public string Product_name { get; set; }
        public int SubCategory_id { get; set; }
        public string SubCategory_Name { get; set; }
        public float Weight { get; set; }
        public int Unit_id { get; set; }
        public string Unit_Name { get; set; }
        public int Stock_quantity { get; set; }
        public float Selling_rate { get; set; }
        public float Tax { get; set; }
    }

    public class VendorModel
    {
        public int Vendor_id { get; set; }
        public string Vendor_name { get; set; }
        public string Firm_name { get; set; }
        public string Firm_address { get; set; }
        public int Location_id { get; set; }
        public string Location_Name { get; set; }
        public string Mobile_number { get; set; }
        public string Alternate_number { get; set; }
        public string Email_address { get; set; }
    }

   


    public class order_items_Model
    {
        public int orderitem_id { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public float selling_rate { get; set; }
        public int Order_quantity { get; set; }


    }
    public class Order_details_Model
    {
        public int order_id { get; set; }
        public int vendor_id { get; set; }
        public string vendor_name { get; set; }
        public string order_date { get; set; }
        public bool is_received { get; set; }

        public List<order_items_Model> OrderItems { get; set; }
    }

    public class Product_received_stock_Model
    {
        public int Receive_stock_id { get; set; }
        public int Order_id { get; set; }
        public string order_date { get; set; }
        public int vendor_id { get; set; }
        public string Vendor_name { get; set; }
        public string Received_date { get; set; }

        public List<Received_Item_Model> ReceivedItems { get; set; }

    }

    public class Received_Item_Model
    {
        public int received_item_id { get; set; }
        public int Receive_id { get; set; }
        public int orderitem_id { get; set; }
        public int received_quantity { get; set; }
        public float purchase_rate { get; set; }
    }


    public class ItemModel
    {
        public int Received_item_id { get; set; }

        public int order_item_id { get; set; }
        public int order_quantity { get; set; }
        public int Received_id { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int Received_quantity { get; set; }
        public float purchase_rate { get; set; }

    }

    public class Customer_Model
    {
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string mobile_number { get; set; }
    }

    public class Invoice_Details_Model
    {
        public int invoice_id { get; set; }
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string invoice_date { get; set; }
        public float invoice_amount { get; set; }
        public float remaining_amount { get; set; }
        public float paid_amount { get; set; }
        public string status { get; set; }
        public List<Invoice_Product_Model> Invoice_Products { get; set; }
        

    }

    public class InvoiceSummary
    {
        public string InvoiceDate { get; set; }
        public int TotalQuantity { get; set; }
        public float InvoiceAmount { get;set;}
    }

    public class Invoice_quantityproduct_model
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int TotalQuantity { get; set; }
    }

    public class Invoice_Product_Model
    {
        public int invoice_product_id { get; set; }
        public int invoice_id { get; set; }
        
        public int product_id { get; set; }
        public string product_name { get; set; }
        public float selling_rate { get; set; }
        public int quantity { get; set; }
        public float tax { get; set; }
    }

    public class Invoice_Payment_Model
    {
        public int payment_id { get; set; }
        public int invoice_id { get; set; }
        public int customer_id { get; set; }
        public string customer_name { get; set; }
        public string invoice_date { get; set; }
        public float invoice_amount { get; set; }
        public float remaining_amount { get; set; }
        public float paid_amount { get; set; }
        public string status { get; set; }
        public string payment_date { get; set; }
        public double payment_amount { get; set; }
        public string payment_mode { get; set; }
        public string description { get; set; }
    }

    public class Invoice_Pay_Model
    {
        public int payment_id { get; set; }
        public int invoice_id { get; set; }
        public string payment_date { get; set; }
        public double payment_amount { get; set; }
        public string payment_mode { get; set; }
        public string description { get; set; }
    }

    public class CompanyModel
    {
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string address { get; set; }
        public string mobile_number { get; set; }
        public string email_address { get; set; }
        public string gst_number { get; set; }
    }
}











