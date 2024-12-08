using Microsoft.AspNetCore.Mvc;

public class CalcController : Controller
{
    [HttpGet]
    public IActionResult Manual()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Manual(double number1, double number2, string operation)
    {
        var result = PerformCalculation(number1, number2, operation);
        ViewBag.OperationDetails = FormatOperation(number1, number2, operation);
        ViewBag.Result = result;

        return View();
    }

    [HttpGet]
    public IActionResult ManualWithSeparateHandlers()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ManualWithSeparateHandlers(double number1, double number2, string operation)
    {
        var result = PerformCalculation(number1, number2, operation);
        ViewBag.OperationDetails = FormatOperation(number1, number2, operation);
        ViewBag.Result = result;

        return View();
    }

    [HttpGet]
    public IActionResult ModelBindingInParameters()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ModelBindingInParameters(double number1, double number2, string operation)
    {
        var result = PerformCalculation(number1, number2, operation);
        ViewBag.OperationDetails = FormatOperation(number1, number2, operation);
        ViewBag.Result = result;

        return View();
    }

    [HttpGet]
    public IActionResult ModelBindingInSeparateModel()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ModelBindingInSeparateModel(CalcModel model)
    {
        var result = PerformCalculation(model.Number1, model.Number2, model.Operation);
        ViewBag.OperationDetails = FormatOperation(model.Number1, model.Number2, model.Operation);
        ViewBag.Result = result;

        return View();
    }
    private string PerformCalculation(double number1, double number2, string operation)
    {
        double result;
        switch (operation)
        {
            case "+":
                result = number1 + number2;
                break;
            case "-":
                result = number1 - number2;
                break;
            case "*":
                result = number1 * number2;
                break;
            case "/":
                if (number2 == 0)
                    return "Деление на ноль невозможно.";
                result = number1 / number2;
                break;
            default:
                return "Неподдерживаемая операция.";
        }
        return $"{result}";
    }
private string FormatOperation(double number1, double number2, string operation)
    {
        return $"{number1} {operation} {number2} =";
    }
}

public class CalcModel
{
    public double Number1 { get; set; }
    public double Number2 { get; set; }
    public string Operation { get; set; }
}