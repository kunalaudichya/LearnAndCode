using Chapter5.Exceptions;
using Chapter5.Models;
using Chapter5.Services;

namespace Chapter5
{
    public class PaymentProcessor
    {
        private static readonly decimal MIN_AMOUNT = new decimal(0.01);
        private static readonly int MAX_RETRIES = 2;
        private static readonly string PAYMENT_SUCCESS = "Payment successful";
        private static readonly string PAYMENT_FAILED = "Payment failed";

        private Logger logger;
        private NotificationService notifier;
        private Dictionary<string, PaymentRecord> history;

        public PaymentProcessor(Logger logger, NotificationService notifier)
        {
            this.logger = logger;
            this.notifier = notifier;
            this.history = new Dictionary<string, PaymentRecord>();
        }

        public PaymentResult Process(PaymentRequest request)
        {
            Validate(request);

            int attempt = 0;

            while(attempt < MAX_RETRIES)
            {
                try
                {
                    Execute(request);
                    Record(request);
                    NotifySuccess(request);

                    return new PaymentResult(
                        true,
                        PAYMENT_SUCCESS,
                        GenerateId()
                    );
                }
                catch(PaymentException e)
                {
                    attempt++;
                    logger.Log($"Retry attempt: {attempt}");
                }
            }

            return new PaymentResult(
                false,
                PAYMENT_FAILED,
                null
            );
        }

        private void Validate(PaymentRequest request)
        {
            if(request.CustomerId == null || string.IsNullOrEmpty(request.CustomerId))
            {
                throw new ArgumentException("Customer ID required");
            }

            if(request.Amount < MIN_AMOUNT)
            {
                throw new ArgumentException("Invalid amount");
            }
        }

        private void Execute(PaymentRequest request)
        {
            logger.Log($"Executing payment of {request.Amount}");

            if(request.Amount > new decimal(5000))
            {
                throw new PaymentException("Limit exceeded");
            }
        }

        private void Record(PaymentRequest request)
        {
            history.Add(
                GenerateId(),
                new PaymentRecord(
                    request.CustomerId,
                    request.Amount,
                    DateTime.Now)
                );
        }

        private void NotifySuccess(PaymentRequest request)
        {
            notifier.Send(
                request.CustomerId,
                $"Payment of {request.Amount} processed"
            );
        }

        private String GenerateId()
        {
            return $"TXN-{DateTime.Now.Millisecond}";
        }
    }
}
