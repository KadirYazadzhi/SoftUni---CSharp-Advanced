using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    private static Dictionary<string, List<Product>> products = new Dictionary<string, List<Product>>();

    public static void Main(string[] args) {
        ReadData();
        PrintProducts();
    }

    private static void ReadData() {
        string line = null;
        while ((line = Console.ReadLine()) != "Revision") {
            string[] data = line.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Product product = new Product(data[1], double.Parse(data[2]));
            
            if (products.ContainsKey(data[0])) products[data[0]].Add(product);
            else products.Add(data[0], new List<Product>() { product });
        }
    }

    private static void PrintProducts() {
        foreach ((string shopName, List<Product> productsData) in products.OrderBy(p => p.Key)) {
            Console.WriteLine($"{shopName}->");

            for (int i = 0; i < productsData.Count; i++) {
                Console.WriteLine($"Product: {productsData[i].productName}, Price: {productsData[i].productPrice}");
            }
        }
    }
}

class Product {
    public string productName { get; set; }
    public double productPrice { get; set; }

    public Product(string productName, double productPrice) {
        this.productName = productName;
        this.productPrice = productPrice;
    }
}

