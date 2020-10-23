namespace TMS
{
    /// \class RateFee
    /// 
    /// \brief Contains Properties that can be used for holding all RateFee data.
    /// 
    /// This class contains public accessors/mutators that can be used to hold
    /// all RateFee data.
    ///
    public class RateFee
    {
        ///
        /// \brief This method is the accessor/mutator for <i>string CarrierName</i> Property.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>string CarrierName</i>
        /// Property. It allows getting the value of <i>string CarrierName</i>,
        /// and setting the value of <i>string CarrierName</i>.
        ///
        /// \param value - <b>string</b> - The value that's being set to <i>string CarrierName</i>.
        /// 
        /// \return CarrierName - <b>string</b> - The value of <i>string CarrierName</i>.
        ///
        public string CarrierName { get; set; }


        ///
        /// \brief This method is the accessor/mutator for <i>double FTLRate</i> Property.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>double FTLRate</i>
        /// Property. It allows getting the value of <i>double FTLRate</i>,
        /// and setting the value of <i>double FTLRate</i>.
        ///
        /// \param value - <b>double</b> - The value that's being set to <i>double FTLRate</i>.
        /// 
        /// \return FTLRate - <b>double</b> - The value of <i>double FTLRate</i>.
        ///
        public double FTLRate { get; set; }


        ///
        /// \brief This method is the accessor/mutator for <i>double LTLRate</i> Property.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>double LTLRate</i>
        /// Property. It allows getting the value of <i>double LTLRate</i>,
        /// and setting the value of <i>double LTLRate</i>.
        ///
        /// \param value - <b>double</b> - The value that's being set to <i>double LTLRate</i>.
        /// 
        /// \return LTLRate - <b>double</b> - The value of <i>double LTLRate</i>.
        ///
        public double LTLRate { get; set; }


        ///
        /// \brief This method is the accessor/mutator for <i>double ReeferCharge</i> Property.
        /// 
        /// \details <b>Details</b>
        /// This method is the accessor/mutator for the <i>double ReeferCharge</i>
        /// Property. It allows getting the value of <i>double ReeferCharge</i>,
        /// and setting the value of <i>double ReeferCharge</i>.
        ///
        /// \param value - <b>double</b> - The value that's being set to <i>double ReeferCharge</i>.
        /// 
        /// \return ReeferCharge - <b>double</b> - The value of <i>double ReeferCharge</i>.
        ///
        public double ReeferCharge { get; set; }
    }
}