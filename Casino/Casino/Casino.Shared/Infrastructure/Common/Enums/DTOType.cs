namespace Casino.Shared
{
    /// <summary>
    /// Data Transfer Objects
    /// </summary>
    public enum DTOType
    {
        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Casino.DTOModel.dll", "Casino.DTOModel.CustomerDTO")]
        CustomerDTO = 1,

        [QualifiedTypeName("Casino.DTOModel.dll", "Casino.DTOModel.RoulettePlayerDTO")]
        RoulettePlayerDTO = 2,

        [QualifiedTypeName("Casino.DTOModel.dll", "Casino.DTOModel.CustomerSearchDTO")]
        CustomerSearchDTO = 3
    }
}
