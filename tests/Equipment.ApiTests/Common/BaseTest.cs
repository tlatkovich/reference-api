namespace Equipment.ApiTests.Common;

public abstract class BaseTest
{
#pragma warning disable CS8625

    public static TheoryData<string> NullOrWhitespaceStrings =>
    [
        null,
        "",
        "   "
    ];

#pragma warning restore CS8625

    public static TheoryData<int> NegativeOrZeroIntegers =>
        [
            -1,
            0
        ];
}
