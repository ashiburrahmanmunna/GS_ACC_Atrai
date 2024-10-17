using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class compnaymodellink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WarrentyItems_ComId",
                table: "WarrentyItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_ComId",
                table: "Warehouse",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_VGM_ComId",
                table: "VGM",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactionLog_ComId",
                table: "UserTransactionLog",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTerminate_ComId",
                table: "UserTerminate",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogingInfo_ComId",
                table: "UserLogingInfo",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_ComId",
                table: "UserAccount",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_ComId",
                table: "Unit",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicketComment_ComId",
                table: "TroubleTicketComment",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_ComId",
                table: "ToDo",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRouterOnuTracking_ComId",
                table: "TestRouterOnuTracking",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ComId",
                table: "Supplier",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_ComId",
                table: "StoreSetting",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_ComId",
                table: "Shop",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPayment_ComId",
                table: "SalesPayment",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_ComId",
                table: "SalesItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesBatchItems_ComId",
                table: "SalesBatchItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_ComId",
                table: "PurchasePayment",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ComId",
                table: "PurchaseItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBatchItems_ComId",
                table: "PurchaseBatchItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSecoundaryUnit_ComId",
                table: "ProductSecoundaryUnit",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLedger_ComId",
                table: "ProductLedger",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ComId",
                table: "Product",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_ComId",
                table: "PaymentType",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberStatus_ComId",
                table: "MemberStatus",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_ComId",
                table: "Member",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Market_ComId",
                table: "Market",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueItems_ComId",
                table: "IssueItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueBatchItems_ComId",
                table: "IssueBatchItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetUserStatus_ComId",
                table: "InternetUserStatus",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetPackage_ComId",
                table: "InternetPackage",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetComplain_ComId",
                table: "InternetComplain",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferItems_ComId",
                table: "InternalTransferItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferBatchItems_ComId",
                table: "InternalTransferBatchItems",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpireDateExtend_ComId",
                table: "ExpireDateExtend",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ComId",
                table: "Employee",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisReport_ComId",
                table: "DiagnosisReport",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceWeight_ComId",
                table: "DeliveryServiceWeight",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceTiming_ComId",
                table: "DeliveryServiceTiming",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceDistance_ComId",
                table: "DeliveryServiceDistance",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceComment_ComId",
                table: "DeliveryServiceComment",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ComId",
                table: "Customer",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_ComId",
                table: "CostCalculated",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ComId",
                table: "Category",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_ComId",
                table: "AccountsDailyTransaction",
                column: "ComId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHead_ComId",
                table: "AccountHead",
                column: "ComId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_Company_ComId",
                table: "AccountHead",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_Company_ComId",
                table: "AccountsDailyTransaction",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationTicket_Company_ComId",
                table: "ActivationTicket",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Company_ComId",
                table: "Category",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_Company_ComId",
                table: "CostCalculated",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Company_ComId",
                table: "Customer",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryService_Company_ComId",
                table: "DeliveryService",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryServiceComment_Company_ComId",
                table: "DeliveryServiceComment",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryServiceDistance_Company_ComId",
                table: "DeliveryServiceDistance",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryServiceTiming_Company_ComId",
                table: "DeliveryServiceTiming",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryServiceWeight_Company_ComId",
                table: "DeliveryServiceWeight",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisReport_Company_ComId",
                table: "DiagnosisReport",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_ComId",
                table: "Employee",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpireDateExtend_Company_ComId",
                table: "ExpireDateExtend",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalTransfer_Company_ComId",
                table: "InternalTransfer",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalTransferBatchItems_Company_ComId",
                table: "InternalTransferBatchItems",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalTransferItems_Company_ComId",
                table: "InternalTransferItems",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternetComplain_Company_ComId",
                table: "InternetComplain",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternetPackage_Company_ComId",
                table: "InternetPackage",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternetUser_Company_ComId",
                table: "InternetUser",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternetUserStatus_Company_ComId",
                table: "InternetUserStatus",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceBill_Company_ComId",
                table: "InvoiceBill",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_Company_ComId",
                table: "Issue",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueBatchItems_Company_ComId",
                table: "IssueBatchItems",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueItems_Company_ComId",
                table: "IssueItems",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Market_Company_ComId",
                table: "Market",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Company_ComId",
                table: "Member",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberStatus_Company_ComId",
                table: "MemberStatus",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_Company_ComId",
                table: "PaymentType",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Company_ComId",
                table: "Product",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLedger_Company_ComId",
                table: "ProductLedger",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSecoundaryUnit_Company_ComId",
                table: "ProductSecoundaryUnit",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Company_ComId",
                table: "Purchase",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseBatchItems_Company_ComId",
                table: "PurchaseBatchItems",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Company_ComId",
                table: "PurchaseItems",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayment_Company_ComId",
                table: "PurchasePayment",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Company_ComId",
                table: "Sales",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesBatchItems_Company_ComId",
                table: "SalesBatchItems",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_Company_ComId",
                table: "SalesItems",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_Company_ComId",
                table: "SalesPayment",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_Company_ComId",
                table: "Shop",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_Company_ComId",
                table: "StoreSetting",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Company_ComId",
                table: "Supplier",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRouterOnuTracking_Company_ComId",
                table: "TestRouterOnuTracking",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_Company_ComId",
                table: "ToDo",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TroubleTicket_Company_ComId",
                table: "TroubleTicket",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TroubleTicketComment_Company_ComId",
                table: "TroubleTicketComment",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Company_ComId",
                table: "Unit",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_Company_ComId",
                table: "UserAccount",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogingInfo_Company_ComId",
                table: "UserLogingInfo",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTerminate_Company_ComId",
                table: "UserTerminate",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTransactionLog_Company_ComId",
                table: "UserTransactionLog",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VGM_Company_ComId",
                table: "VGM",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_Company_ComId",
                table: "Warehouse",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarrentyItems_Company_ComId",
                table: "WarrentyItems",
                column: "ComId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_Company_ComId",
                table: "AccountHead");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_Company_ComId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivationTicket_Company_ComId",
                table: "ActivationTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Company_ComId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_Company_ComId",
                table: "CostCalculated");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Company_ComId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryService_Company_ComId",
                table: "DeliveryService");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryServiceComment_Company_ComId",
                table: "DeliveryServiceComment");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryServiceDistance_Company_ComId",
                table: "DeliveryServiceDistance");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryServiceTiming_Company_ComId",
                table: "DeliveryServiceTiming");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryServiceWeight_Company_ComId",
                table: "DeliveryServiceWeight");

            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisReport_Company_ComId",
                table: "DiagnosisReport");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_ComId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpireDateExtend_Company_ComId",
                table: "ExpireDateExtend");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalTransfer_Company_ComId",
                table: "InternalTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalTransferBatchItems_Company_ComId",
                table: "InternalTransferBatchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalTransferItems_Company_ComId",
                table: "InternalTransferItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InternetComplain_Company_ComId",
                table: "InternetComplain");

            migrationBuilder.DropForeignKey(
                name: "FK_InternetPackage_Company_ComId",
                table: "InternetPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_InternetUser_Company_ComId",
                table: "InternetUser");

            migrationBuilder.DropForeignKey(
                name: "FK_InternetUserStatus_Company_ComId",
                table: "InternetUserStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceBill_Company_ComId",
                table: "InvoiceBill");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_Company_ComId",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueBatchItems_Company_ComId",
                table: "IssueBatchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueItems_Company_ComId",
                table: "IssueItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Market_Company_ComId",
                table: "Market");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Company_ComId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberStatus_Company_ComId",
                table: "MemberStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_Company_ComId",
                table: "PaymentType");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Company_ComId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLedger_Company_ComId",
                table: "ProductLedger");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSecoundaryUnit_Company_ComId",
                table: "ProductSecoundaryUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Company_ComId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseBatchItems_Company_ComId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Company_ComId",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayment_Company_ComId",
                table: "PurchasePayment");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Company_ComId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesBatchItems_Company_ComId",
                table: "SalesBatchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_Company_ComId",
                table: "SalesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_Company_ComId",
                table: "SalesPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_Company_ComId",
                table: "Shop");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_Company_ComId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Company_ComId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRouterOnuTracking_Company_ComId",
                table: "TestRouterOnuTracking");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_Company_ComId",
                table: "ToDo");

            migrationBuilder.DropForeignKey(
                name: "FK_TroubleTicket_Company_ComId",
                table: "TroubleTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_TroubleTicketComment_Company_ComId",
                table: "TroubleTicketComment");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Company_ComId",
                table: "Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_Company_ComId",
                table: "UserAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogingInfo_Company_ComId",
                table: "UserLogingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTerminate_Company_ComId",
                table: "UserTerminate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTransactionLog_Company_ComId",
                table: "UserTransactionLog");

            migrationBuilder.DropForeignKey(
                name: "FK_VGM_Company_ComId",
                table: "VGM");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_Company_ComId",
                table: "Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_WarrentyItems_Company_ComId",
                table: "WarrentyItems");

            migrationBuilder.DropIndex(
                name: "IX_WarrentyItems_ComId",
                table: "WarrentyItems");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_ComId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_VGM_ComId",
                table: "VGM");

            migrationBuilder.DropIndex(
                name: "IX_UserTransactionLog_ComId",
                table: "UserTransactionLog");

            migrationBuilder.DropIndex(
                name: "IX_UserTerminate_ComId",
                table: "UserTerminate");

            migrationBuilder.DropIndex(
                name: "IX_UserLogingInfo_ComId",
                table: "UserLogingInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_ComId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_Unit_ComId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_TroubleTicketComment_ComId",
                table: "TroubleTicketComment");

            migrationBuilder.DropIndex(
                name: "IX_ToDo_ComId",
                table: "ToDo");

            migrationBuilder.DropIndex(
                name: "IX_TestRouterOnuTracking_ComId",
                table: "TestRouterOnuTracking");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_ComId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_ComId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_Shop_ComId",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_SalesPayment_ComId",
                table: "SalesPayment");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_ComId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesBatchItems_ComId",
                table: "SalesBatchItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayment_ComId",
                table: "PurchasePayment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_ComId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBatchItems_ComId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropIndex(
                name: "IX_ProductSecoundaryUnit_ComId",
                table: "ProductSecoundaryUnit");

            migrationBuilder.DropIndex(
                name: "IX_ProductLedger_ComId",
                table: "ProductLedger");

            migrationBuilder.DropIndex(
                name: "IX_Product_ComId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_PaymentType_ComId",
                table: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_MemberStatus_ComId",
                table: "MemberStatus");

            migrationBuilder.DropIndex(
                name: "IX_Member_ComId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Market_ComId",
                table: "Market");

            migrationBuilder.DropIndex(
                name: "IX_IssueItems_ComId",
                table: "IssueItems");

            migrationBuilder.DropIndex(
                name: "IX_IssueBatchItems_ComId",
                table: "IssueBatchItems");

            migrationBuilder.DropIndex(
                name: "IX_InternetUserStatus_ComId",
                table: "InternetUserStatus");

            migrationBuilder.DropIndex(
                name: "IX_InternetPackage_ComId",
                table: "InternetPackage");

            migrationBuilder.DropIndex(
                name: "IX_InternetComplain_ComId",
                table: "InternetComplain");

            migrationBuilder.DropIndex(
                name: "IX_InternalTransferItems_ComId",
                table: "InternalTransferItems");

            migrationBuilder.DropIndex(
                name: "IX_InternalTransferBatchItems_ComId",
                table: "InternalTransferBatchItems");

            migrationBuilder.DropIndex(
                name: "IX_ExpireDateExtend_ComId",
                table: "ExpireDateExtend");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ComId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_DiagnosisReport_ComId",
                table: "DiagnosisReport");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryServiceWeight_ComId",
                table: "DeliveryServiceWeight");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryServiceTiming_ComId",
                table: "DeliveryServiceTiming");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryServiceDistance_ComId",
                table: "DeliveryServiceDistance");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryServiceComment_ComId",
                table: "DeliveryServiceComment");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ComId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_ComId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_Category_ComId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_ComId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountHead_ComId",
                table: "AccountHead");
        }
    }
}
