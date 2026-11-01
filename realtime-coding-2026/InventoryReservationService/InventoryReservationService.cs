namespace Inventory
{
    public record OrderItem(
        string ProductCode,
        int Quantity
    );

    public record ReservationResult(
        bool Success,
        string Message,
        Dictionary<string, int> RemainingStock
    );

    // public interface IInventoryService
    // {
    //     ReservationResult Reserve(
    //         List<OrderItem> items
    //     );

    //     bool Restock(
    //         string productCode,
    //         int quantity
    //     );

    //     int GetAvailableStock(
    //         string productCode
    //     );

    //     List<string> GetLowStockProducts(
    //         int threshold
    //     );
    // }

    // public class InventoryService : IInventoryService
    // {
    //     public Dictionary<string, int> StockDic = new Dictionary<string, int>
    //     {
    //         {"LAPTOP", 10},
    //         {"MOUSE", 25},
    //         {"KEYBOARD", 8},
    //         {"MONITOR", 5},
    //     };

    //     public ReservationResult Reserve(List<OrderItem> items)
    //     {

    //     }

    //     bool Restock(
    //         string productCode,
    //         int quantity
    //     );

    //     int GetAvailableStock(
    //         string productCode
    //     );

    //     List<string> GetLowStockProducts(
    //         int threshold
    //     );
    // }
}
