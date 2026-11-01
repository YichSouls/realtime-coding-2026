namespace Payment
{
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

    public class PaymentService : IPaymentService
    {
        private static readonly HashSet<string> SupportedCurrencies =
            new(StringComparer.OrdinalIgnoreCase) { "EUR", "USD", "GBP" };

        private static readonly HashSet<string> SupportedMethods =
            new(StringComparer.OrdinalIgnoreCase) { "Card", "BankTransfer", "PayPal" };

        // PaymentResult 本身不携带 CustomerId，需要连同原始请求一起存，供按客户查询使用
        private readonly Dictionary<string, (PaymentRequest Request, PaymentResult Result)> _payments = new(StringComparer.OrdinalIgnoreCase);

        public PaymentResult ProcessPayment(PaymentRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.PaymentId) || string.IsNullOrWhiteSpace(request.CustomerId))
            {
                return Failed(request, "PaymentId and CustomerId cannot be empty.");
            }

            if (_payments.ContainsKey(request.PaymentId))
            {
                throw new InvalidOperationException($"Payment '{request.PaymentId}' has already been processed.");
            }

            if (request.Amount <= 0)
            {
                return Failed(request, "Amount must be greater than zero.");
            }

            if (!SupportedCurrencies.Contains(request.Currency))
            {
                return Failed(request, $"Currency '{request.Currency}' is not supported.");
            }

            if (!SupportedMethods.Contains(request.PaymentMethod))
            {
                return Failed(request, $"Payment method '{request.PaymentMethod}' is not supported.");
            }

            decimal fee = CalculateFee(request.PaymentMethod, request.Amount);
            decimal total = request.Amount + fee;

            var result = new PaymentResult(
                request.PaymentId,
                request.Amount,
                fee,
                total,
                "Success",
                "Payment processed successfully."
            );

            _payments[request.PaymentId] = (request, result);
            return result;
        }

        public PaymentResult? GetPayment(string paymentId)
        {
            return _payments.TryGetValue(paymentId, out var entry) ? entry.Result : null;
        }

        public List<PaymentResult> GetPaymentsByCustomer(string customerId)
        {
            return _payments.Values
                .Where(p => string.Equals(p.Request.CustomerId, customerId, StringComparison.OrdinalIgnoreCase))
                .Select(p => p.Result)
                .OrderBy(r => r.PaymentId, StringComparer.OrdinalIgnoreCase)
                .ToList();
        }

        private static decimal CalculateFee(string method, decimal amount)
        {
            decimal fee = method.ToUpperInvariant() switch
            {
                "CARD" => amount * 0.02m + 0.30m,
                "BANKTRANSFER" => amount * 0.005m,
                "PAYPAL" => amount * 0.03m + 0.50m,
                _ => throw new InvalidOperationException("Unsupported payment method.")
            };

            return Math.Round(fee, 2, MidpointRounding.AwayFromZero);
        }

        private static PaymentResult Failed(PaymentRequest request, string message)
        {
            return new PaymentResult(
                request.PaymentId,
                request.Amount,
                0m,
                request.Amount,
                "Failed",
                message
            );
        }
    }
}