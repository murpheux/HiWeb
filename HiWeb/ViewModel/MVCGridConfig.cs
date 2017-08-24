using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCGrid.Web;
using MVCGrid.Models;

namespace HiWeb.ViewModel
{

    public class MVCGridConfig
    {
        public static void RegisterGrids()
        {
            // add your Grid definitions here, using the MVCGridDefinitionTable.Add method

            MVCGridDefinitionTable.Add("HiWebGrid", new MVCGridBuilder<StudentModel>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .WithSorting(sorting: true, defaultSortColumn: "Id", defaultSortDirection: SortDirection.Dsc)
                .WithPaging(paging: true, itemsPerPage: 10, allowChangePageSize: true, maxItemsPerPage: 100)
                .WithAdditionalQueryOptionNames("search")
                .AddColumns(cols =>
                {
                    //cols.Add("Id").WithValueExpression((p, c) => c.UrlHelper.Action("detail", "demo", new { id = p.StudentId }))
                    //    .WithValueTemplate("<a href='{Value}'>{Model.Id}</a>", false)
                    //    .WithPlainTextValueExpression(p => p.StudentId.ToString());
                    cols.Add("FirstName").WithHeaderText("First Name")
                        .WithVisibility(true, true)
                        .WithValueExpression(p => p.Name);
                    cols.Add("LastName").WithHeaderText("Last Name")
                        .WithVisibility(true, true)
                        .WithValueExpression(p => p.Address);
                    cols.Add("FullName").WithHeaderText("Full Name")
                        .WithValueTemplate("{Model.FirstName} {Model.LastName}")
                        .WithVisibility(visible: false, allowChangeVisibility: true)
                        .WithSorting(false);
                    //cols.Add("StartDate").WithHeaderText("Start Date")
                    //    .WithVisibility(visible: true, allowChangeVisibility: true)
                    //    .WithValueExpression(p => p.StartDate.HasValue ? p.StartDate.Value.ToShortDateString() : "");
                    //cols.Add("Status")
                    //    .WithSortColumnData("Active")
                    //    .WithVisibility(visible: true, allowChangeVisibility: true)
                    //    .WithHeaderText("Status")
                    //    .WithValueExpression(p => p.Active ? "Active" : "Inactive")
                    //    .WithCellCssClassExpression(p => p.Active ? "success" : "danger");
                    //cols.Add("Gender").WithValueExpression((p, c) => p.Sex)
                    //    .WithAllowChangeVisibility(true);
                    //cols.Add("Email")
                    //    .WithVisibility(visible: false, allowChangeVisibility: true)
                    //    .WithValueExpression(p => p.Email);
                    //cols.Add("Url").WithVisibility(false)
                    //    .WithValueExpression((p, c) => c.UrlHelper.Action("detail", "demo", new { id = p.Email }));
                })
                .WithAdditionalSetting(MVCGrid.Rendering.BootstrapRenderingEngine.SettingNameTableClass, "notreal") // Example of changing table css class
                .WithRetrieveDataMethod((context) =>
                {
                    //var options = context.QueryOptions;
                    //int totalRecords;
                    //var repo =  DependencyResolver.Current.GetService<IPersonRepository>();
                    //string globalSearch = options.GetAdditionalQueryOptionString("search");
                    //string sortColumn = options.GetSortColumnData<string>();
                    var items = GetList(); //repo.GetData(out totalRecords, globalSearch, options.GetLimitOffset(), options.GetLimitRowcount(),
                    //    sortColumn, options.SortDirection == SortDirection.Dsc);
                    return new QueryResult<StudentModel>()
                    {
                        Items = items,
                        TotalRecords = 2 // totalRecords
                    };
                })
            );

            MVCGridDefinitionTable.Add("Demo", new MVCGridBuilder<StudentModel>()
                .WithAuthorizationType(AuthorizationType.AllowAnonymous)
                .AddColumns(cols =>
                {
                    // Add your columns here
                    cols.Add("UniqueColumnName").WithHeaderText("Any Header")
                        .WithValueExpression(i => i.Name); // use the Value Expression to return the cell text for this column
                    cols.Add().WithColumnName("UrlExample")
                        .WithHeaderText("Edit")
                        .WithValueExpression((i, c) => c.UrlHelper.Action("detail", "demo", new { id = i.Email }));
                })
                .WithRetrieveDataMethod((context) =>
                {
                    // Query your data here. Obey Ordering, paging and filtering paramters given in the context.QueryOptions.
                    // Use Entity Framwork, a module from your IoC Container, or any other method.
                    // Return QueryResult object containing IEnumerable<YouModelItem>
                    return new QueryResult<StudentModel>()
                    {
                        Items = GetList(),
                        TotalRecords = 0 // if paging is enabled, return the total number of records of all pages
                    };
                })
            );
        }

        private static List<StudentModel> GetList()
        {
            var list = new List<StudentModel>
            {
                new StudentModel() { Name = "Clement Onawole", Sex = "M", Age = 40 },
                new StudentModel() { Name = "Seun Bukari", Sex = "F", Age = 22 }
            };

            return list;
        }
    }
}