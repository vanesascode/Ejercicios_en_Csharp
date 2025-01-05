//Problem:

//Suppose we have a system that needs to perform different types of payments
//(e.g., credit card, PayPal, bank transfer). We want to define a common
//structure for processing payments, but allow subclasses to customize the
//specific payment logic.

//Solution:

//We'll define an abstract base class PaymentProcessor that provides a
//template method ProcessPayment. This method will define the common structure
//for processing payments, but leave the specific payment logic to be
//implemented by subclasses.

PaymentProcessor creditCardProcessor = new CreditCardPaymentProcessor();
creditCardProcessor.ProcessPayment(100.00m);

PaymentProcessor payPalProcessor = new PayPalPaymentProcessor();
payPalProcessor.ProcessPayment(50.00m);

PaymentProcessor bankTransferProcessor = new BankTransferPaymentProcessor();
bankTransferProcessor.ProcessPayment(200.00m);


public abstract class PaymentProcessor
{
    //So you don't have to pass the amount parameter to all the methods and classes below, 
    // use a property, not a field, and pass it to the ProcessPayment method: 
    protected decimal Amount { get; set; }

    public void ProcessPayment(decimal amount)
    {
        Amount = amount;
        ValidatePayment();
        AuthorizePayment();
        CapturePayment();
    }

    protected abstract void ValidatePayment();
    protected abstract void AuthorizePayment();
    protected abstract void CapturePayment();

    protected void ProcessStep(string stepName, string paymentMethod)
    {
        Console.WriteLine($"{stepName} {paymentMethod} payment of {Amount}");
    }
}

public class CreditCardPaymentProcessor : PaymentProcessor
{
    protected override void ValidatePayment()
    {
        ProcessStep("Validating", "credit card");
    }

    protected override void AuthorizePayment()
    {
        ProcessStep("Authorizing", "credit card");
    }

    protected override void CapturePayment()
    {
        ProcessStep("Capturing", "credit card");
    }
}

public class PayPalPaymentProcessor : PaymentProcessor
{
    protected override void ValidatePayment()
    {
        ProcessStep("Validating", "PayPal");
    }

    protected override void AuthorizePayment()
    {
        ProcessStep("Authorizing", "PayPal");
    }

    protected override void CapturePayment()
    {
        ProcessStep("Capturing", "PayPal");
    }
}

public class BankTransferPaymentProcessor : PaymentProcessor
{
    protected override void ValidatePayment()
    {
        ProcessStep("Validating", "bank transfer");
    }

    protected override void AuthorizePayment()
    {
        ProcessStep("Authorizing", "bank transfer");
    }

    protected override void CapturePayment()
    {
        ProcessStep("Capturing", "bank transfer");
    }
}