# Payment Processing Service

目标 40 分钟 · 最长 60 分钟

## 1. Background

You're developing a payment processing service for an e-commerce platform.

When a customer submits a payment request, the service must validate the request, calculate transaction fees, and return a payment result.

The service does not communicate with a real payment provider. Everything runs in memory.

## 2. Data models

```
public record PaymentRequest(
    string PaymentId,
    string CustomerId,
    decimal Amount,
    string Currency,
    string PaymentMethod
);

public record PaymentResult(
    string PaymentId,
    decimal OriginalAmount,
    decimal Fee,
    decimal TotalAmount,
    string Status,
    string Message
);
```

Implement:

```
public interface IPaymentService
{
    PaymentResult ProcessPayment(
        PaymentRequest request
    );

    PaymentResult? GetPayment(
        string paymentId
    );

    List<PaymentResult> GetPaymentsByCustomer(
        string customerId
    );
}
```

## 3. Functional requirements

### A. ProcessPayment

Implement `ProcessPayment(PaymentRequest request)`.

Validation rules:

1. `PaymentId` and `CustomerId` cannot be empty or whitespace-only.
2. `Amount` must be greater than zero.
3. Supported currencies: `EUR`, `USD`, `GBP`.
4. Supported payment methods: `Card`, `BankTransfer`, `PayPal`.
5. Currency and payment-method comparisons must be case-insensitive.
6. A `PaymentId` cannot be processed more than once, ignoring case.

Fee calculation:

| Payment method | Fee                 |
| -------------- | ------------------- |
| Card           | 2% of amount + 0.30 |
| BankTransfer   | 0.5% of amount      |
| PayPal         | 3% of amount + 0.50 |

Round the fee to two decimal places using `MidpointRounding.AwayFromZero`.

The total amount is:

\\[ \text{TotalAmount}=\text{OriginalAmount}+\text{Fee} \\]

For a valid payment, return `Status = "Success"` and store the result in memory.

For an invalid payment, return `Status = "Failed"` with a meaningful message. Invalid payments must not be stored.

For a duplicate `PaymentId`, throw an `InvalidOperationException`. The original payment must remain unchanged.

### B. GetPayment

- Find a payment by its ID, ignoring case.
- Return `null` if no payment exists.

### C. GetPaymentsByCustomer

- Return all successful payments belonging to the requested customer, ignoring case.
- Sort by `PaymentId` alphabetically.
- Return an empty list if no payments match.

## 4. Acceptance tests

Use the following examples. Each independent test should start with a fresh service instance unless otherwise stated.

| Scenario                                    | Expected result             |
| ------------------------------------------- | --------------------------- |
| Card payment, 100 EUR                       | Fee = 2.30, Total = 102.30  |
| BankTransfer, 100 EUR                       | Fee = 0.50, Total = 100.50  |
| PayPal, 100 EUR                             | Fee = 3.50, Total = 103.50  |
| Card payment, 10.25 EUR                     | Fee = 0.51, Total = 10.76   |
| Amount = 0                                  | Failed, not stored          |
| Currency = JPY                              | Failed, not stored          |
| Method = Crypto                             | Failed, not stored          |
| Duplicate payment ID                        | `InvalidOperationException` |
| `GetPayment("p001")` after storing `"P001"` | Returns the stored result   |

For the duplicate test, call `ProcessPayment` twice on the same service instance.

## 5. Additional requirement — Unit Tests

Write at least three automated unit tests using xUnit or NUnit:

1. Successful payment with the correct fee.
2. Invalid payment is rejected and not stored.
3. Duplicate payment throws the expected exception.

You may create a test project with your preferred .NET testing framework.

## 6. Interview constraints

- Use an in-memory collection for storing processed payments.
- Use `Dictionary<string, PaymentResult>` or another appropriate collection.
- Use LINQ where it improves readability.
- Keep validation and fee calculation reasonably separated.
- Do not introduce unnecessary architectural layers or external dependencies.
- You can assume requests are non-null and no concurrent calls occur.

## 7. Evaluation criteria

| Criterion                      | Weight |
| ------------------------------ | ------ |
| Business logic and correctness | 35%    |
| C# syntax and code quality     | 25%    |
| Validation and edge cases      | 20%    |
| Unit testing                   | 20%    |

完成后提交： `PaymentService` 的完整实现、至少三个测试，以及实际耗时。

这次我会特别关注：你能否在不依赖 Copilot 的情况下，独立写出一个结构清晰、能够运行、有基本测试覆盖的 C# Service。

下一轮 Day 6 就不再提前告诉你重点考察哪些 API，而是像真正的 Live Coding 一样，只给业务需求，让你自己选择实现方式。