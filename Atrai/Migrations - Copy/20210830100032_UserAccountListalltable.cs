using Microsoft.EntityFrameworkCore.Migrations;

namespace Invoice.Migrations
{
    public partial class UserAccountListalltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WarrentyItems_LuserId",
                table: "WarrentyItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_LuserId",
                table: "Warehouse",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_VGM_LuserId",
                table: "VGM",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransactionLog_LuserId",
                table: "UserTransactionLog",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTerminate_LuserId",
                table: "UserTerminate",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogingInfo_LuserId",
                table: "UserLogingInfo",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_LuserId",
                table: "UserAccount",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_LuserId",
                table: "Unit",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicketComment_LuserId",
                table: "TroubleTicketComment",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_TroubleTicket_LuserId",
                table: "TroubleTicket",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_LuserId",
                table: "ToDo",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestRouterOnuTracking_LuserId",
                table: "TestRouterOnuTracking",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_LuserId",
                table: "Supplier",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreSetting_LuserId",
                table: "StoreSetting",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shop_LuserId",
                table: "Shop",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesPayment_LuserId",
                table: "SalesPayment",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_LuserId",
                table: "SalesItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesBatchItems_LuserId",
                table: "SalesBatchItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_LuserId",
                table: "Sales",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasePayment_LuserId",
                table: "PurchasePayment",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_LuserId",
                table: "PurchaseItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseBatchItems_LuserId",
                table: "PurchaseBatchItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_LuserId",
                table: "Purchase",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSecoundaryUnit_LuserId",
                table: "ProductSecoundaryUnit",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLedger_LuserId",
                table: "ProductLedger",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_LuserId",
                table: "Product",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_LuserId",
                table: "PaymentType",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberStatus_LuserId",
                table: "MemberStatus",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_LuserId",
                table: "Member",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Market_LuserId",
                table: "Market",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueItems_LuserId",
                table: "IssueItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueBatchItems_LuserId",
                table: "IssueBatchItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Issue_LuserId",
                table: "Issue",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceBill_LuserId",
                table: "InvoiceBill",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetUserStatus_LuserId",
                table: "InternetUserStatus",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetUser_LuserId",
                table: "InternetUser",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetPackage_LuserId",
                table: "InternetPackage",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetComplain_LuserId",
                table: "InternetComplain",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferItems_LuserId",
                table: "InternalTransferItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransferBatchItems_LuserId",
                table: "InternalTransferBatchItems",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalTransfer_LuserId",
                table: "InternalTransfer",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpireDateExtend_LuserId",
                table: "ExpireDateExtend",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LuserId",
                table: "Employee",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisReport_LuserId",
                table: "DiagnosisReport",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceWeight_LuserId",
                table: "DeliveryServiceWeight",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceTiming_LuserId",
                table: "DeliveryServiceTiming",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryServiceDistance_LuserId",
                table: "DeliveryServiceDistance",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryService_LuserId",
                table: "DeliveryService",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_LuserId",
                table: "Customer",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCalculated_LuserId",
                table: "CostCalculated",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_LuserId",
                table: "Category",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivationTicket_LuserId",
                table: "ActivationTicket",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsDailyTransaction_LuserId",
                table: "AccountsDailyTransaction",
                column: "LuserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountHead_LuserId",
                table: "AccountHead",
                column: "LuserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountHead_UserAccount_LuserId",
                table: "AccountHead",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountsDailyTransaction_UserAccount_LuserId",
                table: "AccountsDailyTransaction",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivationTicket_UserAccount_LuserId",
                table: "ActivationTicket",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_UserAccount_LuserId",
                table: "Category",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCalculated_UserAccount_LuserId",
                table: "CostCalculated",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_UserAccount_LuserId",
                table: "Customer",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryService_UserAccount_LuserId",
                table: "DeliveryService",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryServiceDistance_UserAccount_LuserId",
                table: "DeliveryServiceDistance",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryServiceTiming_UserAccount_LuserId",
                table: "DeliveryServiceTiming",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryServiceWeight_UserAccount_LuserId",
                table: "DeliveryServiceWeight",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisReport_UserAccount_LuserId",
                table: "DiagnosisReport",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_UserAccount_LuserId",
                table: "Employee",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpireDateExtend_UserAccount_LuserId",
                table: "ExpireDateExtend",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalTransfer_UserAccount_LuserId",
                table: "InternalTransfer",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalTransferBatchItems_UserAccount_LuserId",
                table: "InternalTransferBatchItems",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalTransferItems_UserAccount_LuserId",
                table: "InternalTransferItems",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternetComplain_UserAccount_LuserId",
                table: "InternetComplain",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternetPackage_UserAccount_LuserId",
                table: "InternetPackage",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternetUser_UserAccount_LuserId",
                table: "InternetUser",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternetUserStatus_UserAccount_LuserId",
                table: "InternetUserStatus",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceBill_UserAccount_LuserId",
                table: "InvoiceBill",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Issue_UserAccount_LuserId",
                table: "Issue",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueBatchItems_UserAccount_LuserId",
                table: "IssueBatchItems",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IssueItems_UserAccount_LuserId",
                table: "IssueItems",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Market_UserAccount_LuserId",
                table: "Market",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Member_UserAccount_LuserId",
                table: "Member",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberStatus_UserAccount_LuserId",
                table: "MemberStatus",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentType_UserAccount_LuserId",
                table: "PaymentType",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_UserAccount_LuserId",
                table: "Product",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductLedger_UserAccount_LuserId",
                table: "ProductLedger",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSecoundaryUnit_UserAccount_LuserId",
                table: "ProductSecoundaryUnit",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_UserAccount_LuserId",
                table: "Purchase",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseBatchItems_UserAccount_LuserId",
                table: "PurchaseBatchItems",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_UserAccount_LuserId",
                table: "PurchaseItems",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasePayment_UserAccount_LuserId",
                table: "PurchasePayment",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_UserAccount_LuserId",
                table: "Sales",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesBatchItems_UserAccount_LuserId",
                table: "SalesBatchItems",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_UserAccount_LuserId",
                table: "SalesItems",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesPayment_UserAccount_LuserId",
                table: "SalesPayment",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_UserAccount_LuserId",
                table: "Shop",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoreSetting_UserAccount_LuserId",
                table: "StoreSetting",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_UserAccount_LuserId",
                table: "Supplier",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestRouterOnuTracking_UserAccount_LuserId",
                table: "TestRouterOnuTracking",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDo_UserAccount_LuserId",
                table: "ToDo",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TroubleTicket_UserAccount_LuserId",
                table: "TroubleTicket",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TroubleTicketComment_UserAccount_LuserId",
                table: "TroubleTicketComment",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_UserAccount_LuserId",
                table: "Unit",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_UserAccount_LuserId",
                table: "UserAccount",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogingInfo_UserAccount_LuserId",
                table: "UserLogingInfo",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTerminate_UserAccount_LuserId",
                table: "UserTerminate",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTransactionLog_UserAccount_LuserId",
                table: "UserTransactionLog",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VGM_UserAccount_LuserId",
                table: "VGM",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouse_UserAccount_LuserId",
                table: "Warehouse",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarrentyItems_UserAccount_LuserId",
                table: "WarrentyItems",
                column: "LuserId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountHead_UserAccount_LuserId",
                table: "AccountHead");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountsDailyTransaction_UserAccount_LuserId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivationTicket_UserAccount_LuserId",
                table: "ActivationTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_UserAccount_LuserId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_CostCalculated_UserAccount_LuserId",
                table: "CostCalculated");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_UserAccount_LuserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryService_UserAccount_LuserId",
                table: "DeliveryService");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryServiceDistance_UserAccount_LuserId",
                table: "DeliveryServiceDistance");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryServiceTiming_UserAccount_LuserId",
                table: "DeliveryServiceTiming");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryServiceWeight_UserAccount_LuserId",
                table: "DeliveryServiceWeight");

            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisReport_UserAccount_LuserId",
                table: "DiagnosisReport");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_UserAccount_LuserId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpireDateExtend_UserAccount_LuserId",
                table: "ExpireDateExtend");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalTransfer_UserAccount_LuserId",
                table: "InternalTransfer");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalTransferBatchItems_UserAccount_LuserId",
                table: "InternalTransferBatchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalTransferItems_UserAccount_LuserId",
                table: "InternalTransferItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InternetComplain_UserAccount_LuserId",
                table: "InternetComplain");

            migrationBuilder.DropForeignKey(
                name: "FK_InternetPackage_UserAccount_LuserId",
                table: "InternetPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_InternetUser_UserAccount_LuserId",
                table: "InternetUser");

            migrationBuilder.DropForeignKey(
                name: "FK_InternetUserStatus_UserAccount_LuserId",
                table: "InternetUserStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceBill_UserAccount_LuserId",
                table: "InvoiceBill");

            migrationBuilder.DropForeignKey(
                name: "FK_Issue_UserAccount_LuserId",
                table: "Issue");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueBatchItems_UserAccount_LuserId",
                table: "IssueBatchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_IssueItems_UserAccount_LuserId",
                table: "IssueItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Market_UserAccount_LuserId",
                table: "Market");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_UserAccount_LuserId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberStatus_UserAccount_LuserId",
                table: "MemberStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentType_UserAccount_LuserId",
                table: "PaymentType");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_UserAccount_LuserId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLedger_UserAccount_LuserId",
                table: "ProductLedger");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSecoundaryUnit_UserAccount_LuserId",
                table: "ProductSecoundaryUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_UserAccount_LuserId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseBatchItems_UserAccount_LuserId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_UserAccount_LuserId",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchasePayment_UserAccount_LuserId",
                table: "PurchasePayment");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_UserAccount_LuserId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesBatchItems_UserAccount_LuserId",
                table: "SalesBatchItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_UserAccount_LuserId",
                table: "SalesItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesPayment_UserAccount_LuserId",
                table: "SalesPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_Shop_UserAccount_LuserId",
                table: "Shop");

            migrationBuilder.DropForeignKey(
                name: "FK_StoreSetting_UserAccount_LuserId",
                table: "StoreSetting");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_UserAccount_LuserId",
                table: "Supplier");

            migrationBuilder.DropForeignKey(
                name: "FK_TestRouterOnuTracking_UserAccount_LuserId",
                table: "TestRouterOnuTracking");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDo_UserAccount_LuserId",
                table: "ToDo");

            migrationBuilder.DropForeignKey(
                name: "FK_TroubleTicket_UserAccount_LuserId",
                table: "TroubleTicket");

            migrationBuilder.DropForeignKey(
                name: "FK_TroubleTicketComment_UserAccount_LuserId",
                table: "TroubleTicketComment");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_UserAccount_LuserId",
                table: "Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_UserAccount_LuserId",
                table: "UserAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogingInfo_UserAccount_LuserId",
                table: "UserLogingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTerminate_UserAccount_LuserId",
                table: "UserTerminate");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTransactionLog_UserAccount_LuserId",
                table: "UserTransactionLog");

            migrationBuilder.DropForeignKey(
                name: "FK_VGM_UserAccount_LuserId",
                table: "VGM");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouse_UserAccount_LuserId",
                table: "Warehouse");

            migrationBuilder.DropForeignKey(
                name: "FK_WarrentyItems_UserAccount_LuserId",
                table: "WarrentyItems");

            migrationBuilder.DropIndex(
                name: "IX_WarrentyItems_LuserId",
                table: "WarrentyItems");

            migrationBuilder.DropIndex(
                name: "IX_Warehouse_LuserId",
                table: "Warehouse");

            migrationBuilder.DropIndex(
                name: "IX_VGM_LuserId",
                table: "VGM");

            migrationBuilder.DropIndex(
                name: "IX_UserTransactionLog_LuserId",
                table: "UserTransactionLog");

            migrationBuilder.DropIndex(
                name: "IX_UserTerminate_LuserId",
                table: "UserTerminate");

            migrationBuilder.DropIndex(
                name: "IX_UserLogingInfo_LuserId",
                table: "UserLogingInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_LuserId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_Unit_LuserId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_TroubleTicketComment_LuserId",
                table: "TroubleTicketComment");

            migrationBuilder.DropIndex(
                name: "IX_TroubleTicket_LuserId",
                table: "TroubleTicket");

            migrationBuilder.DropIndex(
                name: "IX_ToDo_LuserId",
                table: "ToDo");

            migrationBuilder.DropIndex(
                name: "IX_TestRouterOnuTracking_LuserId",
                table: "TestRouterOnuTracking");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_LuserId",
                table: "Supplier");

            migrationBuilder.DropIndex(
                name: "IX_StoreSetting_LuserId",
                table: "StoreSetting");

            migrationBuilder.DropIndex(
                name: "IX_Shop_LuserId",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_SalesPayment_LuserId",
                table: "SalesPayment");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_LuserId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesBatchItems_LuserId",
                table: "SalesBatchItems");

            migrationBuilder.DropIndex(
                name: "IX_Sales_LuserId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_PurchasePayment_LuserId",
                table: "PurchasePayment");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_LuserId",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseBatchItems_LuserId",
                table: "PurchaseBatchItems");

            migrationBuilder.DropIndex(
                name: "IX_Purchase_LuserId",
                table: "Purchase");

            migrationBuilder.DropIndex(
                name: "IX_ProductSecoundaryUnit_LuserId",
                table: "ProductSecoundaryUnit");

            migrationBuilder.DropIndex(
                name: "IX_ProductLedger_LuserId",
                table: "ProductLedger");

            migrationBuilder.DropIndex(
                name: "IX_Product_LuserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_PaymentType_LuserId",
                table: "PaymentType");

            migrationBuilder.DropIndex(
                name: "IX_MemberStatus_LuserId",
                table: "MemberStatus");

            migrationBuilder.DropIndex(
                name: "IX_Member_LuserId",
                table: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Market_LuserId",
                table: "Market");

            migrationBuilder.DropIndex(
                name: "IX_IssueItems_LuserId",
                table: "IssueItems");

            migrationBuilder.DropIndex(
                name: "IX_IssueBatchItems_LuserId",
                table: "IssueBatchItems");

            migrationBuilder.DropIndex(
                name: "IX_Issue_LuserId",
                table: "Issue");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceBill_LuserId",
                table: "InvoiceBill");

            migrationBuilder.DropIndex(
                name: "IX_InternetUserStatus_LuserId",
                table: "InternetUserStatus");

            migrationBuilder.DropIndex(
                name: "IX_InternetUser_LuserId",
                table: "InternetUser");

            migrationBuilder.DropIndex(
                name: "IX_InternetPackage_LuserId",
                table: "InternetPackage");

            migrationBuilder.DropIndex(
                name: "IX_InternetComplain_LuserId",
                table: "InternetComplain");

            migrationBuilder.DropIndex(
                name: "IX_InternalTransferItems_LuserId",
                table: "InternalTransferItems");

            migrationBuilder.DropIndex(
                name: "IX_InternalTransferBatchItems_LuserId",
                table: "InternalTransferBatchItems");

            migrationBuilder.DropIndex(
                name: "IX_InternalTransfer_LuserId",
                table: "InternalTransfer");

            migrationBuilder.DropIndex(
                name: "IX_ExpireDateExtend_LuserId",
                table: "ExpireDateExtend");

            migrationBuilder.DropIndex(
                name: "IX_Employee_LuserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_DiagnosisReport_LuserId",
                table: "DiagnosisReport");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryServiceWeight_LuserId",
                table: "DeliveryServiceWeight");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryServiceTiming_LuserId",
                table: "DeliveryServiceTiming");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryServiceDistance_LuserId",
                table: "DeliveryServiceDistance");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryService_LuserId",
                table: "DeliveryService");

            migrationBuilder.DropIndex(
                name: "IX_Customer_LuserId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_CostCalculated_LuserId",
                table: "CostCalculated");

            migrationBuilder.DropIndex(
                name: "IX_Category_LuserId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_ActivationTicket_LuserId",
                table: "ActivationTicket");

            migrationBuilder.DropIndex(
                name: "IX_AccountsDailyTransaction_LuserId",
                table: "AccountsDailyTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AccountHead_LuserId",
                table: "AccountHead");
        }
    }
}
