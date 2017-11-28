namespace Casino.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Casino.Business.dll", "Casino.Business.CustomerBDC")]
        CustomerBDC = 1,

        [QualifiedTypeName("Casino.Business.dll", "Casino.Business.RouletteBDC")]
        RouletteBDC = 2

    }
}
