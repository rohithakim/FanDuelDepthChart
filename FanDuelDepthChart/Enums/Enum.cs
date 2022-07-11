using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FanDuelDepthChart.Enums
{
    public enum PlayerPositionName
    {
        [StringValue("QB")]
        QuaterBack,
        [StringValue("WR")]
        WideReceiver,
        [StringValue("RB")]
        RunningBack,
        [StringValue("LT")]
        LeftTackle,
        [StringValue("K")]
        Kicker,
        [StringValue("P")]
        Punter,
        [StringValue("RT")]
        RightTackle,
        [StringValue("PR")]
        PuntRunner,
        [StringValue("LWR")]
        LeftWideReceiver,
        [StringValue("RWR")]
        RightWideReceiver

    }

    /// <summary>
    /// This attribute is used to represent a string value
    /// for a value in an enum.
    /// </summary>
    public class StringValueAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

        #endregion

    }
}
