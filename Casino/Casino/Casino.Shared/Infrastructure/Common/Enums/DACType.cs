namespace Casino.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Casino.Data.dll", "Casino.Data.CustomerDAC")]
        CustomerDAC = 1,

        [QualifiedTypeName("Casino.Data.dll", "Casino.Data.RouletteDAC")]
        RouletteDAC = 2

    }
}
