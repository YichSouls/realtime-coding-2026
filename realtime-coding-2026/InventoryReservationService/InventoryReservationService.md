# Inventory Reservation Service

目标 35 分钟 · 最长 45 分钟

## 1. Background

You're building an in-memory inventory reservation service for an e-commerce platform.

When a customer places an order, the service must check product availability and reserve the requested quantities.

A reservation must be atomic: either all products are reserved, or none are.

No database, no HTTP API, no external libraries.

## 2. Data models

```
public record OrderItem(
    string ProductCode,
    int Quantity
);

public record ReservationResult(
    bool Success,
    string Message,
    Dictionary<string, int> RemainingStock
);
```

Implement:

```
public interface IInventoryService
{
    ReservationResult Reserve(
        List<OrderItem> items
    );

    bool Restock(
        string productCode,
        int quantity
    );

    int GetAvailableStock(
        string productCode
    );

    List<string> GetLowStockProducts(
        int threshold
    );
}
```

Initialize the service with:

| ProductCode | Stock |
| ----------- | ----- |
| LAPTOP      | 10    |
| MOUSE       | 25    |
| KEYBOARD    | 8     |
| MONITOR     | 5     |

All product-code comparisons must be case-insensitive.

## 3. Functional requirements

### A. Reserve

Implement `Reserve(List<OrderItem> items)`.

1. Reject an empty order.
2. Reject any item with `Quantity <= 0`.
3. Reject an order if any product does not exist.
4. Reject an order if there is insufficient stock for any product.
5. If a product appears multiple times in an order, combine the requested quantities before checking stock.
6. If the order is valid, deduct the quantities from inventory.
7. If any validation fails, inventory must remain completely unchanged.
8. Return a `ReservationResult` with success status, a meaningful message and a snapshot of the remaining inventory.

### B. Restock

Implement `Restock(string productCode, int quantity)`.

- Return `false` if the product does not exist.
- Return `false` if `quantity <= 0`.
- Otherwise increase its stock and return `true`.

### C. GetAvailableStock

- Return the current quantity for an existing product.
- Return `-1` if the product does not exist.

### D. GetLowStockProducts

- Return product codes whose stock is strictly less than `threshold`.
- Sort the product codes alphabetically.
- Return an empty list if no products qualify.

## 4. Acceptance tests

| Operation                                 | Expected result                      |
| ----------------------------------------- | ------------------------------------ |
| `Reserve([("LAPTOP", 2), ("MOUSE", 3)])`  | Success; LAPTOP = 8, MOUSE = 22      |
| `Reserve([("LAPTOP", 2), ("laptop", 3)])` | Success; LAPTOP = 5                  |
| `Reserve([("MONITOR", 6)])`               | Failure; stock unchanged             |
| `Reserve([("MOUSE", 2), ("UNKNOWN", 1)])` | Failure; stock unchanged             |
| `Reserve([])`                             | Failure; stock unchanged             |
| `Restock("keyboard", 4)`                  | Success; stock increased by 4        |
| `GetAvailableStock("unknown")`            | `-1`                                 |
| `GetLowStockProducts(10)`                 | Products with stock below 10, sorted |

Each test should run against a fresh service instance so previous operations don't affect the expected results.

## 5. Interview constraints

You must use:

- `Dictionary<string, int>` for inventory storage.
- `StringComparer.OrdinalIgnoreCase` for product-code comparisons.
- `TryGetValue` in at least one method.
- LINQ `GroupBy` to combine duplicate order items.
- A separate validation phase before changing inventory.

You may use `foreach` for updating inventory. In fact, for state changes, an imperative approach is often clearer than forcing everything into LINQ.

You can assume product codes are non-null, quantities fit within `int`, and no concurrent requests occur. You do not need to implement database transactions or thread synchronization.

## 6. What I'll evaluate

| Criterion                    | Weight |
| ---------------------------- | ------ |
| Business logic and atomicity | 40%    |
| C# collections and syntax    | 30%    |
| Edge cases and validation    | 20%    |
| Code readability             | 10%    |