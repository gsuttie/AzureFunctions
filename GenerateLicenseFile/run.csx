using System;

public class Order
{
    public string OrderId { get; set; }
    public string ProductId { get; set;} 
    public string Email { get; set; }
    public decimal Price { get; set; }
}

public static void Run(Order myQueueItem, TraceWriter log, IBinder binder)
{
    log.Info($"Received an Order: Order {myQueueItem.OrderId}, Product {myQueueItem.ProductId}, Email {myQueueItem.Email}, Price {myQueueItem.Price}");
    
    // Generate a meaning ful name for the licence file (name it after the OrderId)
    using (var outputBlob = binder.Bind<TextWriter>(
        new BlobAttribute($"licenses/{myQueueItem.OrderId}.lic")))
    {
        outputBlob.WriteLine($"OrderID: {myQueueItem.OrderId} ");
        outputBlob.WriteLine($"Email: {myQueueItem.Email} ");
        outputBlob.WriteLine($"ProductId: {myQueueItem.ProductId} ");
        outputBlob.WriteLine($"PurchaseDate: {DateTime.UtcNow} ");
        var md5 = System.Security.Cryptography.MD5.Create();
        var hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(myQueueItem.Email + "secret"));
        outputBlob.WriteLine($"secretcode: {BitConverter.ToString(hash).Replace("-","")}");
    }
}