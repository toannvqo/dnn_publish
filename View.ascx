<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.DNNModule1.View" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="dnnWeb" Assembly="DotNetNuke" Namespace="DotNetNuke.UI.WebControls" %>
<%@ Register TagPrefix="dnnUI" Assembly="DotNetNuke.Web" Namespace="DotNetNuke.Web.UI.WebControls" %>

<telerik:RadGrid RenderMode="Lightweight" runat="server" ID="RadGrid" AllowPaging="true" AllowSorting="true" Width="800px" Skin="Black" EnableEmbeddedSkins="false"
    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"
    OnNeedDataSource="RadGrid_NeedDataSource" OnUpdateCommand="RadGrid_UpdateCommand" AutoGenerateColumns="false" OnInsertCommand="RadGrid_InsertCommand"
   OnDeleteCommand="RadGrid_DeleteCommand">
    <MasterTableView DataKeyNames="ID" CommandItemDisplay="Top" InsertItemPageIndexAction="ShowItemOnCurrentPage" Width="100%">
        <Columns>

            <telerik:GridBoundColumn DataField="ID" HeaderText="Product ID" ReadOnly="true"
                ForceExtractValue="Always" ConvertEmptyStringToNull="true" />
            <telerik:GridBoundColumn DataField="ProductName" HeaderText="Product Name" />
            <telerik:GridBoundColumn DataField="Category" HeaderText="Category" />
            <telerik:GridBoundColumn DataField="Supplier" HeaderText="Supplier" />
            <telerik:GridEditCommandColumn />
            <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" ConfirmText="Delete this product?" ConfirmDialogType="RadWindow" />
        </Columns>
    </MasterTableView>
</telerik:RadGrid>