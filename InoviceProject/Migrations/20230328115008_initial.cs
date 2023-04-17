using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InoviceProject.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Categoryid = table.Column<int>(name: "Category_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoryname = table.Column<string>(name: "Category_name", type: "nvarchar(450)", nullable: false),
                    Flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Categoryid);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetails",
                columns: table => new
                {
                    companyid = table.Column<int>(name: "company_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    companyname = table.Column<string>(name: "company_name", type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobilenumber = table.Column<string>(name: "mobile_number", type: "nvarchar(max)", nullable: false),
                    emailaddress = table.Column<string>(name: "email_address", type: "nvarchar(max)", nullable: false),
                    gstnumber = table.Column<string>(name: "gst_number", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetails", x => x.companyid);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customerid = table.Column<int>(name: "customer_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customername = table.Column<string>(name: "customer_name", type: "nvarchar(max)", nullable: false),
                    mobilenumber = table.Column<string>(name: "mobile_number", type: "nvarchar(max)", nullable: false),
                    Flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customerid);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Locationid = table.Column<int>(name: "Location_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Locationname = table.Column<string>(name: "Location_name", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Locationid);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Unitid = table.Column<int>(name: "Unit_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unitname = table.Column<string>(name: "Unit_name", type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Unitid);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryid = table.Column<int>(name: "SubCategory_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryname = table.Column<string>(name: "SubCategory_name", type: "nvarchar(max)", nullable: false),
                    Categoryid = table.Column<int>(name: "Category_id", type: "int", nullable: false),
                    Flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryid);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_Category_id",
                        column: x => x.Categoryid,
                        principalTable: "Categories",
                        principalColumn: "Category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice_Details",
                columns: table => new
                {
                    invoiceid = table.Column<int>(name: "invoice_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerid = table.Column<int>(name: "customer_id", type: "int", nullable: false),
                    invoicedate = table.Column<string>(name: "invoice_date", type: "nvarchar(max)", nullable: false),
                    invoiceamount = table.Column<float>(name: "invoice_amount", type: "real", nullable: false),
                    Flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice_Details", x => x.invoiceid);
                    table.ForeignKey(
                        name: "FK_Invoice_Details_Customers_customer_id",
                        column: x => x.customerid,
                        principalTable: "Customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Vendorid = table.Column<int>(name: "Vendor_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vendorname = table.Column<string>(name: "Vendor_name", type: "nvarchar(max)", nullable: false),
                    Firmname = table.Column<string>(name: "Firm_name", type: "nvarchar(max)", nullable: false),
                    Firmaddress = table.Column<string>(name: "Firm_address", type: "nvarchar(max)", nullable: false),
                    Locationid = table.Column<int>(name: "Location_id", type: "int", nullable: false),
                    Mobilenumber = table.Column<string>(name: "Mobile_number", type: "nvarchar(max)", nullable: false),
                    Alternatenumber = table.Column<string>(name: "Alternate_number", type: "nvarchar(max)", nullable: false),
                    Emailaddress = table.Column<string>(name: "Email_address", type: "nvarchar(max)", nullable: false),
                    Flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Vendorid);
                    table.ForeignKey(
                        name: "FK_Vendors_Locations_Location_id",
                        column: x => x.Locationid,
                        principalTable: "Locations",
                        principalColumn: "Location_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Productid = table.Column<int>(name: "Product_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Productname = table.Column<string>(name: "Product_name", type: "nvarchar(max)", nullable: false),
                    SubCategoryid = table.Column<int>(name: "SubCategory_id", type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Unitid = table.Column<int>(name: "Unit_id", type: "int", nullable: false),
                    Stockquantity = table.Column<int>(name: "Stock_quantity", type: "int", nullable: false),
                    Sellingrate = table.Column<float>(name: "Selling_rate", type: "real", nullable: false),
                    Tax = table.Column<float>(type: "real", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Productid);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategory_id",
                        column: x => x.SubCategoryid,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategory_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Products_Units_Unit_id",
                        column: x => x.Unitid,
                        principalTable: "Units",
                        principalColumn: "Unit_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Invoice_Payments",
                columns: table => new
                {
                    paymentid = table.Column<int>(name: "payment_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceid = table.Column<int>(name: "invoice_id", type: "int", nullable: false),
                    paymentdate = table.Column<string>(name: "payment_date", type: "nvarchar(max)", nullable: false),
                    paymentamount = table.Column<double>(name: "payment_amount", type: "float", nullable: false),
                    paymentmode = table.Column<string>(name: "payment_mode", type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice_Payments", x => x.paymentid);
                    table.ForeignKey(
                        name: "FK_Invoice_Payments_Invoice_Details_invoice_id",
                        column: x => x.invoiceid,
                        principalTable: "Invoice_Details",
                        principalColumn: "invoice_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    orderid = table.Column<int>(name: "order_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vendorid = table.Column<int>(name: "vendor_id", type: "int", nullable: false),
                    orderdate = table.Column<string>(name: "order_date", type: "nvarchar(max)", nullable: false),
                    IsReceived = table.Column<bool>(name: "Is_Received", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.orderid);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Vendors_vendor_id",
                        column: x => x.vendorid,
                        principalTable: "Vendors",
                        principalColumn: "Vendor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice_Products",
                columns: table => new
                {
                    invoiceproductid = table.Column<int>(name: "invoice_product_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceid = table.Column<int>(name: "invoice_id", type: "int", nullable: false),
                    productid = table.Column<int>(name: "product_id", type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    Flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice_Products", x => x.invoiceproductid);
                    table.ForeignKey(
                        name: "FK_Invoice_Products_Invoice_Details_invoice_id",
                        column: x => x.invoiceid,
                        principalTable: "Invoice_Details",
                        principalColumn: "invoice_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoice_Products_Products_product_id",
                        column: x => x.productid,
                        principalTable: "Products",
                        principalColumn: "Product_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    orderitemid = table.Column<int>(name: "orderitem_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderid = table.Column<int>(name: "order_id", type: "int", nullable: false),
                    Productid = table.Column<int>(name: "Product_id", type: "int", nullable: false),
                    Orderquantity = table.Column<int>(name: "Order_quantity", type: "int", nullable: false),
                    Flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.orderitemid);
                    table.ForeignKey(
                        name: "FK_OrderItems_OrderDetails_order_id",
                        column: x => x.orderid,
                        principalTable: "OrderDetails",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_Product_id",
                        column: x => x.Productid,
                        principalTable: "Products",
                        principalColumn: "Product_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedDetails",
                columns: table => new
                {
                    Receivestockid = table.Column<int>(name: "Receive_stock_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orderid = table.Column<int>(name: "Order_id", type: "int", nullable: false),
                    Receiveddate = table.Column<string>(name: "Received_date", type: "nvarchar(max)", nullable: false),
                    Flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedDetails", x => x.Receivestockid);
                    table.ForeignKey(
                        name: "FK_ReceivedDetails_OrderDetails_Order_id",
                        column: x => x.Orderid,
                        principalTable: "OrderDetails",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivedItems",
                columns: table => new
                {
                    receiveditemid = table.Column<int>(name: "received_item_id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Receiveid = table.Column<int>(name: "Receive_id", type: "int", nullable: false),
                    orderitemid = table.Column<int>(name: "orderitem_id", type: "int", nullable: false),
                    receivedquantity = table.Column<int>(name: "received_quantity", type: "int", nullable: false),
                    Purchaserate = table.Column<float>(name: "Purchase_rate", type: "real", nullable: false),
                    flag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedItems", x => x.receiveditemid);
                    table.ForeignKey(
                        name: "FK_ReceivedItems_OrderItems_orderitem_id",
                        column: x => x.orderitemid,
                        principalTable: "OrderItems",
                        principalColumn: "orderitem_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ReceivedItems_ReceivedDetails_Receive_id",
                        column: x => x.Receiveid,
                        principalTable: "ReceivedDetails",
                        principalColumn: "Receive_stock_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Category_name",
                table: "Categories",
                column: "Category_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Details_customer_id",
                table: "Invoice_Details",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Payments_invoice_id",
                table: "Invoice_Payments",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Products_invoice_id",
                table: "Invoice_Products",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Products_product_id",
                table: "Invoice_Products",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_vendor_id",
                table: "OrderDetails",
                column: "vendor_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_order_id",
                table: "OrderItems",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_Product_id",
                table: "OrderItems",
                column: "Product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategory_id",
                table: "Products",
                column: "SubCategory_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Unit_id",
                table: "Products",
                column: "Unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedDetails_Order_id",
                table: "ReceivedDetails",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedItems_orderitem_id",
                table: "ReceivedItems",
                column: "orderitem_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedItems_Receive_id",
                table: "ReceivedItems",
                column: "Receive_id");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_Category_id",
                table: "SubCategories",
                column: "Category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Unit_name",
                table: "Units",
                column: "Unit_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_Location_id",
                table: "Vendors",
                column: "Location_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyDetails");

            migrationBuilder.DropTable(
                name: "Invoice_Payments");

            migrationBuilder.DropTable(
                name: "Invoice_Products");

            migrationBuilder.DropTable(
                name: "ReceivedItems");

            migrationBuilder.DropTable(
                name: "Invoice_Details");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ReceivedDetails");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
