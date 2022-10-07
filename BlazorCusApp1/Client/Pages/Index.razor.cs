using Cus.ViewModels;
using EasyArchitect.Web.Blazor.Components;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCusApp1.Client.Pages
{
    public partial class Index
    {
        private string _startUrl = @"https://localhost:7000/api/Customer/GetCustomers/";
        private IEnumerable<CusOrderViewModel>? _customers;
        private string? _selectedValue;
        private object? _dataSource;
        //private readonly NavigationManager _uriHelper;

        //public Index(NavigationManager uriHelper)
        //{
        //    _uriHelper = uriHelper;
        //}

        protected async override Task OnInitializedAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_startUrl);
            _customers = await client.GetFromJsonAsync<IEnumerable<CusOrderViewModel>>(
                _startUrl);

            await base.OnInitializedAsync();
        }

        void SelectedCusContact(ChangeEventArgs e)
        {
            _selectedValue = (string)(e.Value ?? "");
        }

        protected async Task GetCustomers()
        {
            string getCusUrl = @$"https://localhost:7000/api/Customer/GetCustomers/{_selectedValue}";

            _dataSource = await GridView.GetData<CusOrderViewModel>(getCusUrl);
        }

        protected void AddOrder()
        {
            _uriHelper.NavigateTo($"addorder?CustomerID={_selectedValue}");
        }
    }
}
