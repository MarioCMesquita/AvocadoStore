using System;
using System.Collections.Generic;

namespace AvocadoStore_API.Entities
{
    public class ProductEntity : BaseEntity
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public int SafetyStockLevel { get; set; }
        public int ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public int DaysToManufacture { get; set; }
        public int ProductSubcategoryID { get; set; }
        public int ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public string rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }

    public class ProductView
    {
        public int TotalProducts { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalDiffCostPrice { get; set; }
        public decimal TotalPercDiffCostPrice { get; set; }
        public List<ProductItem> Itens { get; set; }
    }

    public class ProductItem
    {
        public int ProductID { get; set; }
        public string Product { get; set; }
        public string ProductNumber { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public decimal DifferenceCostPrice { get; set; }
        public decimal PercDiffCostPrice { get; set; }
        public string Subcategory { get; set; }
        public string Category { get; set; }
        public string Model { get; set; }
    }
}
