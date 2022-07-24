using AvocadoStore_API.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace AvocadoStore_API.Repository
{
    public class ProductRepository : BaseRepository
    {
        public ProductEntity GetById(int id)
        {
            try
            {
                string query = $@"SELECT * FROM Product
                                  WHERE ProductID = {id}
                                  AND DT_DELETE IS NULL";

                ProductEntity user = new ProductEntity();
                DataTable result = ExecQuery(query);

                return SetEntity(result.Rows[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductEntity> GetAll()
        {
            try
            {
                string query = $"SELECT * FROM Product WHERE DT_DELETE IS NULL";

                List<ProductEntity> userList = new List<ProductEntity>();
                DataTable result = ExecQuery(query);

                foreach (DataRow row in result.Rows)
                {
                    userList.Add(SetEntity(row));
                }

                if (result.Rows.Count == 0)
                    return null;

                return userList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductView GetProductsView()
        {
            try
            {
                string query = $@"SELECT A.ProductID,
	                                     A.Name AS Product,
	                                     A.ProductNumber,
	                                     A.StandardCost,
	                                     A.ListPrice,
	                                     B.Name AS Subcategory,
	                                     C.Name AS Category,
	                                     D.Name AS Model
                                  FROM Product AS A
                                  INNER JOIN ProductSubcategory AS B ON B.ProductSubcategoryID = A.ProductSubcategoryID
                                  INNER JOIN ProductCategory AS C ON C.ProductCategoryID = B.ProductCategoryID
                                  INNER JOIN ProductModel AS D ON D.ProductModelID = A.ProductModelID";

                List<ProductItem> itens = new List<ProductItem>();
                DataTable result = ExecQuery(query);

                if (result.Rows.Count == 0)
                {
                    return null;
                }

                foreach (DataRow row in result.Rows)
                {
                    var item = new ProductItem
                    {
                        ProductID = Convert.ToInt32(row["ProductID"]),
                        Product = Convert.ToString(row["Product"]),
                        ProductNumber = Convert.ToString(row["ProductNumber"]),
                        StandardCost = Math.Round(Convert.ToDecimal(row["StandardCost"]), 2),
                        ListPrice = Math.Round(Convert.ToDecimal(row["ListPrice"]), 2),
                        Subcategory = Convert.ToString(row["Subcategory"]),
                        Category = Convert.ToString(row["Category"]),
                        Model = Convert.ToString(row["Model"])
                    };

                    var differenceCostPrice = Math.Round(item.ListPrice - item.StandardCost, 2);
                    var percDiffCostPrice = Math.Round((item.ListPrice - item.StandardCost) / item.ListPrice * 100, 2);

                    item.DifferenceCostPrice = differenceCostPrice;
                    item.PercDiffCostPrice = percDiffCostPrice;

                    itens.Add(item);
                }

                decimal totalCost = Math.Round(itens.Sum(x => x.StandardCost), 2);
                decimal totalPrice = Math.Round(itens.Sum(x => x.ListPrice), 2);

                return new ProductView
                {
                    TotalProducts = itens.Count,
                    TotalCost = totalCost,
                    TotalPrice = totalPrice,
                    TotalDiffCostPrice = totalPrice - totalCost,
                    TotalPercDiffCostPrice = Math.Round((totalPrice - totalCost) / totalPrice * 100, 2),
                    Itens = itens.OrderBy(item => item.PercDiffCostPrice).ToList()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductEntity SetEntity(DataRow row) => new ProductEntity()
        {
            ProductID = Convert.ToInt32(row["ProductID"]),
            Name = Convert.ToString(row["Name"]),
            ProductNumber = Convert.ToString(row["ProductNumber"]),
            MakeFlag = Convert.ToBoolean(row["MakeFlag"]),
            FinishedGoodsFlag = Convert.ToBoolean(row["FinishedGoodsFlag"]),
            Color = Convert.ToString(row["Color"]),
            SafetyStockLevel = Convert.ToInt32(row["SafetyStockLevel"]),
            ReorderPoint = Convert.ToInt32(row["ReorderPoint"]),
            StandardCost = Convert.ToDecimal(row["StandardCost"]),
            ListPrice = Convert.ToDecimal(row["ListPrice"]),
            DaysToManufacture = Convert.ToInt32(row["DaysToManufacture"]),
            ProductSubcategoryID = !Convert.IsDBNull(row["ProductSubcategoryID"]) ? Convert.ToInt32(row["ProductSubcategoryID"]) : 0,
            ProductModelID = !Convert.IsDBNull(row["ProductModelID"]) ? Convert.ToInt32(row["ProductModelID"]) : 0,
            SellStartDate = !Convert.IsDBNull(row["SellStartDate"]) ? Convert.ToDateTime(row["SellStartDate"]) : DateTime.MinValue,
            rowguid = Convert.ToString(row["rowguid"]),
            ModifiedDate = Convert.ToDateTime(row["ModifiedDate"]),
            Cd_user_delete = !Convert.IsDBNull(row["CD_USER_DELETE"]) ? Convert.ToInt32(row["CD_USER_DELETE"]) : 0,
            Dt_delete = !Convert.IsDBNull(row["DT_DELETE"]) ? Convert.ToDateTime(row["DT_DELETE"]) : DateTime.MinValue
        };
    }
}
