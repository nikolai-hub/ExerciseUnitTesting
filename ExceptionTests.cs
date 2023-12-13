using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string stringToReverse = "ani";
        // Act
        string result = _exceptions.ArgumentNullReverse(stringToReverse);
        string expected = "ina";
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string? input = null;
        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        decimal totalPrice = 100.0m;
        decimal discount = 10.0m;

        decimal result = _exceptions.ArgumentCalculateDiscount(totalPrice, discount);
        Assert.That(result, Is.EqualTo(90.0m));
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        decimal totalPrice = 100.0m;
        decimal discount = -10.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        int[] array = new int[] { 1, 2, 3 };
        int index = 1;

        int result = _exceptions.IndexOutOfRangeGetElement(array, index);

        Assert.That(result, Is.EqualTo(2));
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        int[] array = new int[] { 1, 2, 3 };
        int index = -1;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        int[] array = { 10, 20, 30, 40, 50 };
        int index = 100;

        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        bool isLoggedIn = true;

        string actualResult = _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);
        string expectedResult = "User logged in.";

        Assert.That(actualResult, Is.EqualTo(expectedResult));

    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        bool isLoggedIn = false;

        Assert.That(() => _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn), Throws.InvalidOperationException);
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        string input = "123";
        int actualResult = _exceptions.FormatExceptionParseInt(input);
        Assert.That(actualResult, Is.EqualTo(123));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        string input = "123abc";
        Assert.That(() => _exceptions.FormatExceptionParseInt(input), Throws.InstanceOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        Dictionary<string, int> numbers = new Dictionary<string, int>()
        {
            ["first"] = 1,
            ["second"] = 2,
            ["third"] = 3,
        };

        int actualResult = _exceptions.KeyNotFoundFindValueByKey(numbers, "first");
        Assert.That(actualResult, Is.EqualTo(1));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        Dictionary<string, int> numbers = new Dictionary<string, int>()
        {
            ["first"] = 1,
            ["second"] = 2,
            ["third"] = 3,
        };

        Assert.That(() => _exceptions.KeyNotFoundFindValueByKey(numbers, "five"), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
       int firstNumber = 1;
       int secondNumber = 2;
       int actualResult = _exceptions.OverflowAddNumbers(firstNumber, secondNumber);
       Assert.That(actualResult, Is.EqualTo(3));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        int firstNumber = int.MaxValue;
        int secondNumber = int.MaxValue;
        Assert.That(() => _exceptions.OverflowAddNumbers(firstNumber, secondNumber), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        int firstNumber = int.MinValue;
        int secondNumber = int.MinValue;
        Assert.That(() => _exceptions.OverflowAddNumbers(firstNumber, secondNumber), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        int number = 6;
        int divisor = 3;
        int actualResult = _exceptions.DivideByZeroDivideNumbers(number, divisor);
        Assert.That(actualResult, Is.EqualTo(2));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        int number = 6;
        int divisor = 0;
        Assert.That(() => _exceptions.DivideByZeroDivideNumbers(number, divisor), Throws.InstanceOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        int[] numbers = new int[] { 1, 2, 3 };
        int index = 0;
        int actualResult = _exceptions.SumCollectionElements(numbers, index);
        Assert.That(actualResult, Is.EqualTo(6));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        int[]? numbers = null;
        int index = 5;
        Assert.That(() => _exceptions.SumCollectionElements(numbers,index), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        int[] numbers = new int[] { 1, 2, 3 };
        int index = 5;
        Assert.That(() => _exceptions.SumCollectionElements(numbers,index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        Dictionary<string, string> numbersAsStrings = new Dictionary<string, string>
        {
            ["first"] = "1",
            ["second"] = "2",
            ["third"] = "3",
        };
        int actualResult = _exceptions.GetElementAsNumber(numbersAsStrings, "first");
        Assert.That(actualResult, Is.EqualTo(1));

    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        Dictionary<string, string> numbersAsStrings = new Dictionary<string, string>
        {
            ["first"] = "1",
            ["second"] = "2",
            ["third"] = "3",
        };
        Assert.That(() => _exceptions.GetElementAsNumber(numbersAsStrings, "1"), Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        Dictionary<string, string> numbersAsStrings = new Dictionary<string, string>
        {
            ["first"] = "1abc",
            ["second"] = "2def",
            ["third"] = "3ghi",
        };
        Assert.That(() => _exceptions.GetElementAsNumber(numbersAsStrings, "first"), Throws.InstanceOf<FormatException>());
    }
}
