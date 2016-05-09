/*
' Copyright (c) 2016  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using System.Web.UI.WebControls;
using Christoc.Modules.DNNModule1.Components;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using DotNetNuke.UI.Utilities;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Collections;

namespace Christoc.Modules.DNNModule1
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from DNNModule1ModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : DNNModule1ModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }
        protected void RadGrid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            var controller = new ProductController();
            RadGrid.DataSource = controller.getAll(); ;

        }
        protected void RadGrid_UpdateCommand(object source, GridCommandEventArgs e)
        {
            var controller = new ProductController();
            var editableItem = ((GridEditableItem)e.Item);
            var productId = (int)editableItem.GetDataKeyValue("ID");
            var product = controller.GetProduct(productId);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);
            product.ProductName = (string)values["ProductName"];
            product.Category = (string)values["Category"];
            product.Supplier = (string)values["Supplier"];
            if (product != null)
            {
                controller.UpdateProduct(product);
            }
        }
        protected void RadGrid_InsertCommand(object source, GridCommandEventArgs e)
        {
            var controller = new ProductController();
            var editableItem = ((GridEditableItem)e.Item);
            var product = new Product();
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);
            product.ProductName = (string)values["ProductName"];
            product.Category = (string)values["Category"];
            product.Supplier = (string)values["Supplier"];
            controller.CreateProduct(product);

        }
        protected void RadGrid_DeleteCommand(object source, GridCommandEventArgs e)
        {
            var controller = new ProductController();
            var editableItem = ((GridEditableItem)e.Item);
            var productId = (int)editableItem.GetDataKeyValue("ID");
            controller.DeleteProduct(productId);
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

    }
}