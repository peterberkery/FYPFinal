using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartLibrary
{
    public class FundInstance
    {
        #region Properties
        /// <summary>  
        /// get and set the PlayerId  
        /// </summary>  
        public int FundId
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the PlayerName  
        /// </summary>  
        public string FundName
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the PlayerList  
        /// </summary>  
        public List<FundInstance> FundInstanceList
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the PlayerRecordList  
        /// </summary>  
        public List<FundRecord> FundRecordsList
        {
            get;
            set;
        }
        #endregion
    }
    public class FundRecord
    {
        #  region Properties
        /// <summary>  
        /// get and set the PlayerId  
        /// </summary>  
        public int FundId
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the Year  
        /// </summary>  
        public float FDate
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the TotalWickets  
        /// </summary>  
        public float Bitcoin
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the ODIMatches  
        /// </summary>  
        public float PBitcoin
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the TestMatches  
        /// </summary>  
        public float Ethereum
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the TestMatches  
        /// </summary>  
        public float PEthereum
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the TestMatches  
        /// </summary>  
        public float BitcoinCash
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the TestMatches  
        /// </summary>  
        public float PBitcoinCash
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the TestMatches  
        /// </summary>  
        public float Litecoin
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the TestMatches  
        /// </summary>  
        public float PLitecoin
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the TestMatches  
        /// </summary>  
        public float Ripple
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the TestMatches  
        /// </summary>  
        public float PRipple
        {
            get;
            set;
        }
        /// <summary>  
        /// get and set the TestMatches  
        /// </summary>  
        public float FundValue
        {
            get;
            set;
        }
        #endregion
    }
}
