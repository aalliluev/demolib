namespace Demo.GeometryLib
{
    /// <summary>
    ///  Common library error messages.
    /// </summary>
    public class ErrorMessages
    {
        public const string ErrorSideNegativeOrZero = "Side cannot be negative or zero";
        public const string ErrorRadiusNegativeOrZero = "Radius cannot be negative or zero";
        public const string ErrorTriangleSidesRuleViolates = "Sum of each two sides must be always greater than the 3d side.";
    }
}