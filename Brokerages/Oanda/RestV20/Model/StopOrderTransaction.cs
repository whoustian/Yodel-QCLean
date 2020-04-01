/* 
 * OANDA v20 REST API
 *
 * The full OANDA v20 REST API Specification. This specification defines how to interact with v20 Accounts, Trades, Orders, Pricing and more.
 *
 * OpenAPI spec version: 3.0.15
 * Contact: api@oanda.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Oanda.RestV20.Model
{
    /// <summary>
    /// A StopOrderTransaction represents the creation of a Stop Order in the user&#39;s Account.
    /// </summary>
    [DataContract]
    public partial class StopOrderTransaction :  IEquatable<StopOrderTransaction>, IValidatableObject
    {
        /// <summary>
        /// The Type of the Transaction. Always set to \"STOP_ORDER\" in a StopOrderTransaction.
        /// </summary>
        /// <value>The Type of the Transaction. Always set to \"STOP_ORDER\" in a StopOrderTransaction.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            
            /// <summary>
            /// Enum CREATE for "CREATE"
            /// </summary>
            [EnumMember(Value = "CREATE")]
            CREATE,
            
            /// <summary>
            /// Enum CLOSE for "CLOSE"
            /// </summary>
            [EnumMember(Value = "CLOSE")]
            CLOSE,
            
            /// <summary>
            /// Enum REOPEN for "REOPEN"
            /// </summary>
            [EnumMember(Value = "REOPEN")]
            REOPEN,
            
            /// <summary>
            /// Enum CLIENTCONFIGURE for "CLIENT_CONFIGURE"
            /// </summary>
            [EnumMember(Value = "CLIENT_CONFIGURE")]
            CLIENTCONFIGURE,
            
            /// <summary>
            /// Enum CLIENTCONFIGUREREJECT for "CLIENT_CONFIGURE_REJECT"
            /// </summary>
            [EnumMember(Value = "CLIENT_CONFIGURE_REJECT")]
            CLIENTCONFIGUREREJECT,
            
            /// <summary>
            /// Enum TRANSFERFUNDS for "TRANSFER_FUNDS"
            /// </summary>
            [EnumMember(Value = "TRANSFER_FUNDS")]
            TRANSFERFUNDS,
            
            /// <summary>
            /// Enum TRANSFERFUNDSREJECT for "TRANSFER_FUNDS_REJECT"
            /// </summary>
            [EnumMember(Value = "TRANSFER_FUNDS_REJECT")]
            TRANSFERFUNDSREJECT,
            
            /// <summary>
            /// Enum MARKETORDER for "MARKET_ORDER"
            /// </summary>
            [EnumMember(Value = "MARKET_ORDER")]
            MARKETORDER,
            
            /// <summary>
            /// Enum MARKETORDERREJECT for "MARKET_ORDER_REJECT"
            /// </summary>
            [EnumMember(Value = "MARKET_ORDER_REJECT")]
            MARKETORDERREJECT,
            
            /// <summary>
            /// Enum LIMITORDER for "LIMIT_ORDER"
            /// </summary>
            [EnumMember(Value = "LIMIT_ORDER")]
            LIMITORDER,
            
            /// <summary>
            /// Enum LIMITORDERREJECT for "LIMIT_ORDER_REJECT"
            /// </summary>
            [EnumMember(Value = "LIMIT_ORDER_REJECT")]
            LIMITORDERREJECT,
            
            /// <summary>
            /// Enum STOPORDER for "STOP_ORDER"
            /// </summary>
            [EnumMember(Value = "STOP_ORDER")]
            STOPORDER,
            
            /// <summary>
            /// Enum STOPORDERREJECT for "STOP_ORDER_REJECT"
            /// </summary>
            [EnumMember(Value = "STOP_ORDER_REJECT")]
            STOPORDERREJECT,
            
            /// <summary>
            /// Enum MARKETIFTOUCHEDORDER for "MARKET_IF_TOUCHED_ORDER"
            /// </summary>
            [EnumMember(Value = "MARKET_IF_TOUCHED_ORDER")]
            MARKETIFTOUCHEDORDER,
            
            /// <summary>
            /// Enum MARKETIFTOUCHEDORDERREJECT for "MARKET_IF_TOUCHED_ORDER_REJECT"
            /// </summary>
            [EnumMember(Value = "MARKET_IF_TOUCHED_ORDER_REJECT")]
            MARKETIFTOUCHEDORDERREJECT,
            
            /// <summary>
            /// Enum TAKEPROFITORDER for "TAKE_PROFIT_ORDER"
            /// </summary>
            [EnumMember(Value = "TAKE_PROFIT_ORDER")]
            TAKEPROFITORDER,
            
            /// <summary>
            /// Enum TAKEPROFITORDERREJECT for "TAKE_PROFIT_ORDER_REJECT"
            /// </summary>
            [EnumMember(Value = "TAKE_PROFIT_ORDER_REJECT")]
            TAKEPROFITORDERREJECT,
            
            /// <summary>
            /// Enum STOPLOSSORDER for "STOP_LOSS_ORDER"
            /// </summary>
            [EnumMember(Value = "STOP_LOSS_ORDER")]
            STOPLOSSORDER,
            
            /// <summary>
            /// Enum STOPLOSSORDERREJECT for "STOP_LOSS_ORDER_REJECT"
            /// </summary>
            [EnumMember(Value = "STOP_LOSS_ORDER_REJECT")]
            STOPLOSSORDERREJECT,
            
            /// <summary>
            /// Enum TRAILINGSTOPLOSSORDER for "TRAILING_STOP_LOSS_ORDER"
            /// </summary>
            [EnumMember(Value = "TRAILING_STOP_LOSS_ORDER")]
            TRAILINGSTOPLOSSORDER,
            
            /// <summary>
            /// Enum TRAILINGSTOPLOSSORDERREJECT for "TRAILING_STOP_LOSS_ORDER_REJECT"
            /// </summary>
            [EnumMember(Value = "TRAILING_STOP_LOSS_ORDER_REJECT")]
            TRAILINGSTOPLOSSORDERREJECT,
            
            /// <summary>
            /// Enum ORDERFILL for "ORDER_FILL"
            /// </summary>
            [EnumMember(Value = "ORDER_FILL")]
            ORDERFILL,
            
            /// <summary>
            /// Enum ORDERCANCEL for "ORDER_CANCEL"
            /// </summary>
            [EnumMember(Value = "ORDER_CANCEL")]
            ORDERCANCEL,
            
            /// <summary>
            /// Enum ORDERCANCELREJECT for "ORDER_CANCEL_REJECT"
            /// </summary>
            [EnumMember(Value = "ORDER_CANCEL_REJECT")]
            ORDERCANCELREJECT,
            
            /// <summary>
            /// Enum ORDERCLIENTEXTENSIONSMODIFY for "ORDER_CLIENT_EXTENSIONS_MODIFY"
            /// </summary>
            [EnumMember(Value = "ORDER_CLIENT_EXTENSIONS_MODIFY")]
            ORDERCLIENTEXTENSIONSMODIFY,
            
            /// <summary>
            /// Enum ORDERCLIENTEXTENSIONSMODIFYREJECT for "ORDER_CLIENT_EXTENSIONS_MODIFY_REJECT"
            /// </summary>
            [EnumMember(Value = "ORDER_CLIENT_EXTENSIONS_MODIFY_REJECT")]
            ORDERCLIENTEXTENSIONSMODIFYREJECT,
            
            /// <summary>
            /// Enum TRADECLIENTEXTENSIONSMODIFY for "TRADE_CLIENT_EXTENSIONS_MODIFY"
            /// </summary>
            [EnumMember(Value = "TRADE_CLIENT_EXTENSIONS_MODIFY")]
            TRADECLIENTEXTENSIONSMODIFY,
            
            /// <summary>
            /// Enum TRADECLIENTEXTENSIONSMODIFYREJECT for "TRADE_CLIENT_EXTENSIONS_MODIFY_REJECT"
            /// </summary>
            [EnumMember(Value = "TRADE_CLIENT_EXTENSIONS_MODIFY_REJECT")]
            TRADECLIENTEXTENSIONSMODIFYREJECT,
            
            /// <summary>
            /// Enum MARGINCALLENTER for "MARGIN_CALL_ENTER"
            /// </summary>
            [EnumMember(Value = "MARGIN_CALL_ENTER")]
            MARGINCALLENTER,
            
            /// <summary>
            /// Enum MARGINCALLEXTEND for "MARGIN_CALL_EXTEND"
            /// </summary>
            [EnumMember(Value = "MARGIN_CALL_EXTEND")]
            MARGINCALLEXTEND,
            
            /// <summary>
            /// Enum MARGINCALLEXIT for "MARGIN_CALL_EXIT"
            /// </summary>
            [EnumMember(Value = "MARGIN_CALL_EXIT")]
            MARGINCALLEXIT,
            
            /// <summary>
            /// Enum DELAYEDTRADECLOSURE for "DELAYED_TRADE_CLOSURE"
            /// </summary>
            [EnumMember(Value = "DELAYED_TRADE_CLOSURE")]
            DELAYEDTRADECLOSURE,
            
            /// <summary>
            /// Enum DAILYFINANCING for "DAILY_FINANCING"
            /// </summary>
            [EnumMember(Value = "DAILY_FINANCING")]
            DAILYFINANCING,
            
            /// <summary>
            /// Enum RESETRESETTABLEPL for "RESET_RESETTABLE_PL"
            /// </summary>
            [EnumMember(Value = "RESET_RESETTABLE_PL")]
            RESETRESETTABLEPL
        }

        /// <summary>
        /// The time-in-force requested for the Stop Order.
        /// </summary>
        /// <value>The time-in-force requested for the Stop Order.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TimeInForceEnum
        {
            
            /// <summary>
            /// Enum GTC for "GTC"
            /// </summary>
            [EnumMember(Value = "GTC")]
            GTC,
            
            /// <summary>
            /// Enum GTD for "GTD"
            /// </summary>
            [EnumMember(Value = "GTD")]
            GTD,
            
            /// <summary>
            /// Enum GFD for "GFD"
            /// </summary>
            [EnumMember(Value = "GFD")]
            GFD,
            
            /// <summary>
            /// Enum FOK for "FOK"
            /// </summary>
            [EnumMember(Value = "FOK")]
            FOK,
            
            /// <summary>
            /// Enum IOC for "IOC"
            /// </summary>
            [EnumMember(Value = "IOC")]
            IOC
        }

        /// <summary>
        /// Specification of how Positions in the Account are modified when the Order is filled.
        /// </summary>
        /// <value>Specification of how Positions in the Account are modified when the Order is filled.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PositionFillEnum
        {
            
            /// <summary>
            /// Enum OPENONLY for "OPEN_ONLY"
            /// </summary>
            [EnumMember(Value = "OPEN_ONLY")]
            OPENONLY,
            
            /// <summary>
            /// Enum REDUCEFIRST for "REDUCE_FIRST"
            /// </summary>
            [EnumMember(Value = "REDUCE_FIRST")]
            REDUCEFIRST,
            
            /// <summary>
            /// Enum REDUCEONLY for "REDUCE_ONLY"
            /// </summary>
            [EnumMember(Value = "REDUCE_ONLY")]
            REDUCEONLY,
            
            /// <summary>
            /// Enum DEFAULT for "DEFAULT"
            /// </summary>
            [EnumMember(Value = "DEFAULT")]
            DEFAULT,
            
            /// <summary>
            /// Enum POSITIONDEFAULT for "POSITION_DEFAULT"
            /// </summary>
            [EnumMember(Value = "POSITION_DEFAULT")]
            POSITIONDEFAULT
        }

        /// <summary>
        /// Specification of what component of a price should be used for comparison when determining if the Order should be filled.
        /// </summary>
        /// <value>Specification of what component of a price should be used for comparison when determining if the Order should be filled.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TriggerConditionEnum
        {
            
            /// <summary>
            /// Enum DEFAULT for "DEFAULT"
            /// </summary>
            [EnumMember(Value = "DEFAULT")]
            DEFAULT,
            
            /// <summary>
            /// Enum TRIGGERDEFAULT for "TRIGGER_DEFAULT"
            /// </summary>
            [EnumMember(Value = "TRIGGER_DEFAULT")]
            TRIGGERDEFAULT,
            
            /// <summary>
            /// Enum INVERSE for "INVERSE"
            /// </summary>
            [EnumMember(Value = "INVERSE")]
            INVERSE,
            
            /// <summary>
            /// Enum BID for "BID"
            /// </summary>
            [EnumMember(Value = "BID")]
            BID,
            
            /// <summary>
            /// Enum ASK for "ASK"
            /// </summary>
            [EnumMember(Value = "ASK")]
            ASK,
            
            /// <summary>
            /// Enum MID for "MID"
            /// </summary>
            [EnumMember(Value = "MID")]
            MID
        }

        /// <summary>
        /// The reason that the Stop Order was initiated
        /// </summary>
        /// <value>The reason that the Stop Order was initiated</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ReasonEnum
        {
            
            /// <summary>
            /// Enum CLIENTORDER for "CLIENT_ORDER"
            /// </summary>
            [EnumMember(Value = "CLIENT_ORDER")]
            CLIENTORDER,
            
            /// <summary>
            /// Enum REPLACEMENT for "REPLACEMENT"
            /// </summary>
            [EnumMember(Value = "REPLACEMENT")]
            REPLACEMENT
        }

        /// <summary>
        /// The Type of the Transaction. Always set to \"STOP_ORDER\" in a StopOrderTransaction.
        /// </summary>
        /// <value>The Type of the Transaction. Always set to \"STOP_ORDER\" in a StopOrderTransaction.</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// The time-in-force requested for the Stop Order.
        /// </summary>
        /// <value>The time-in-force requested for the Stop Order.</value>
        [DataMember(Name="timeInForce", EmitDefaultValue=false)]
        public TimeInForceEnum? TimeInForce { get; set; }
        /// <summary>
        /// Specification of how Positions in the Account are modified when the Order is filled.
        /// </summary>
        /// <value>Specification of how Positions in the Account are modified when the Order is filled.</value>
        [DataMember(Name="positionFill", EmitDefaultValue=false)]
        public PositionFillEnum? PositionFill { get; set; }
        /// <summary>
        /// Specification of what component of a price should be used for comparison when determining if the Order should be filled.
        /// </summary>
        /// <value>Specification of what component of a price should be used for comparison when determining if the Order should be filled.</value>
        [DataMember(Name="triggerCondition", EmitDefaultValue=false)]
        public TriggerConditionEnum? TriggerCondition { get; set; }
        /// <summary>
        /// The reason that the Stop Order was initiated
        /// </summary>
        /// <value>The reason that the Stop Order was initiated</value>
        [DataMember(Name="reason", EmitDefaultValue=false)]
        public ReasonEnum? Reason { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="StopOrderTransaction" /> class.
        /// </summary>
        /// <param name="Id">The Transaction&#39;s Identifier..</param>
        /// <param name="Time">The date/time when the Transaction was created..</param>
        /// <param name="UserID">The ID of the user that initiated the creation of the Transaction..</param>
        /// <param name="AccountID">The ID of the Account the Transaction was created for..</param>
        /// <param name="BatchID">The ID of the \&quot;batch\&quot; that the Transaction belongs to. Transactions in the same batch are applied to the Account simultaneously..</param>
        /// <param name="RequestID">The Request ID of the request which generated the transaction..</param>
        /// <param name="Type">The Type of the Transaction. Always set to \&quot;STOP_ORDER\&quot; in a StopOrderTransaction..</param>
        /// <param name="Instrument">The Stop Order&#39;s Instrument..</param>
        /// <param name="Units">The quantity requested to be filled by the Stop Order. A posititive number of units results in a long Order, and a negative number of units results in a short Order..</param>
        /// <param name="Price">The price threshold specified for the Stop Order. The Stop Order will only be filled by a market price that is equal to or worse than this price..</param>
        /// <param name="PriceBound">The worst market price that may be used to fill this Stop Order. If the market gaps and crosses through both the price and the priceBound, the Stop Order will be cancelled instead of being filled..</param>
        /// <param name="TimeInForce">The time-in-force requested for the Stop Order..</param>
        /// <param name="GtdTime">The date/time when the Stop Order will be cancelled if its timeInForce is \&quot;GTD\&quot;..</param>
        /// <param name="PositionFill">Specification of how Positions in the Account are modified when the Order is filled..</param>
        /// <param name="TriggerCondition">Specification of what component of a price should be used for comparison when determining if the Order should be filled..</param>
        /// <param name="Reason">The reason that the Stop Order was initiated.</param>
        /// <param name="ClientExtensions">ClientExtensions.</param>
        /// <param name="TakeProfitOnFill">TakeProfitOnFill.</param>
        /// <param name="StopLossOnFill">StopLossOnFill.</param>
        /// <param name="TrailingStopLossOnFill">TrailingStopLossOnFill.</param>
        /// <param name="TradeClientExtensions">TradeClientExtensions.</param>
        /// <param name="ReplacesOrderID">The ID of the Order that this Order replaces (only provided if this Order replaces an existing Order)..</param>
        /// <param name="CancellingTransactionID">The ID of the Transaction that cancels the replaced Order (only provided if this Order replaces an existing Order)..</param>
        public StopOrderTransaction(string Id = default(string), string Time = default(string), int? UserID = default(int?), string AccountID = default(string), string BatchID = default(string), string RequestID = default(string), TypeEnum? Type = default(TypeEnum?), string Instrument = default(string), string Units = default(string), string Price = default(string), string PriceBound = default(string), TimeInForceEnum? TimeInForce = default(TimeInForceEnum?), string GtdTime = default(string), PositionFillEnum? PositionFill = default(PositionFillEnum?), TriggerConditionEnum? TriggerCondition = default(TriggerConditionEnum?), ReasonEnum? Reason = default(ReasonEnum?), ClientExtensions ClientExtensions = default(ClientExtensions), TakeProfitDetails TakeProfitOnFill = default(TakeProfitDetails), StopLossDetails StopLossOnFill = default(StopLossDetails), TrailingStopLossDetails TrailingStopLossOnFill = default(TrailingStopLossDetails), ClientExtensions TradeClientExtensions = default(ClientExtensions), string ReplacesOrderID = default(string), string CancellingTransactionID = default(string))
        {
            this.Id = Id;
            this.Time = Time;
            this.UserID = UserID;
            this.AccountID = AccountID;
            this.BatchID = BatchID;
            this.RequestID = RequestID;
            this.Type = Type;
            this.Instrument = Instrument;
            this.Units = Units;
            this.Price = Price;
            this.PriceBound = PriceBound;
            this.TimeInForce = TimeInForce;
            this.GtdTime = GtdTime;
            this.PositionFill = PositionFill;
            this.TriggerCondition = TriggerCondition;
            this.Reason = Reason;
            this.ClientExtensions = ClientExtensions;
            this.TakeProfitOnFill = TakeProfitOnFill;
            this.StopLossOnFill = StopLossOnFill;
            this.TrailingStopLossOnFill = TrailingStopLossOnFill;
            this.TradeClientExtensions = TradeClientExtensions;
            this.ReplacesOrderID = ReplacesOrderID;
            this.CancellingTransactionID = CancellingTransactionID;
        }
        
        /// <summary>
        /// The Transaction&#39;s Identifier.
        /// </summary>
        /// <value>The Transaction&#39;s Identifier.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
        /// <summary>
        /// The date/time when the Transaction was created.
        /// </summary>
        /// <value>The date/time when the Transaction was created.</value>
        [DataMember(Name="time", EmitDefaultValue=false)]
        public string Time { get; set; }
        /// <summary>
        /// The ID of the user that initiated the creation of the Transaction.
        /// </summary>
        /// <value>The ID of the user that initiated the creation of the Transaction.</value>
        [DataMember(Name="userID", EmitDefaultValue=false)]
        public int? UserID { get; set; }
        /// <summary>
        /// The ID of the Account the Transaction was created for.
        /// </summary>
        /// <value>The ID of the Account the Transaction was created for.</value>
        [DataMember(Name="accountID", EmitDefaultValue=false)]
        public string AccountID { get; set; }
        /// <summary>
        /// The ID of the \&quot;batch\&quot; that the Transaction belongs to. Transactions in the same batch are applied to the Account simultaneously.
        /// </summary>
        /// <value>The ID of the \&quot;batch\&quot; that the Transaction belongs to. Transactions in the same batch are applied to the Account simultaneously.</value>
        [DataMember(Name="batchID", EmitDefaultValue=false)]
        public string BatchID { get; set; }
        /// <summary>
        /// The Request ID of the request which generated the transaction.
        /// </summary>
        /// <value>The Request ID of the request which generated the transaction.</value>
        [DataMember(Name="requestID", EmitDefaultValue=false)]
        public string RequestID { get; set; }
        /// <summary>
        /// The Stop Order&#39;s Instrument.
        /// </summary>
        /// <value>The Stop Order&#39;s Instrument.</value>
        [DataMember(Name="instrument", EmitDefaultValue=false)]
        public string Instrument { get; set; }
        /// <summary>
        /// The quantity requested to be filled by the Stop Order. A posititive number of units results in a long Order, and a negative number of units results in a short Order.
        /// </summary>
        /// <value>The quantity requested to be filled by the Stop Order. A posititive number of units results in a long Order, and a negative number of units results in a short Order.</value>
        [DataMember(Name="units", EmitDefaultValue=false)]
        public string Units { get; set; }
        /// <summary>
        /// The price threshold specified for the Stop Order. The Stop Order will only be filled by a market price that is equal to or worse than this price.
        /// </summary>
        /// <value>The price threshold specified for the Stop Order. The Stop Order will only be filled by a market price that is equal to or worse than this price.</value>
        [DataMember(Name="price", EmitDefaultValue=false)]
        public string Price { get; set; }
        /// <summary>
        /// The worst market price that may be used to fill this Stop Order. If the market gaps and crosses through both the price and the priceBound, the Stop Order will be cancelled instead of being filled.
        /// </summary>
        /// <value>The worst market price that may be used to fill this Stop Order. If the market gaps and crosses through both the price and the priceBound, the Stop Order will be cancelled instead of being filled.</value>
        [DataMember(Name="priceBound", EmitDefaultValue=false)]
        public string PriceBound { get; set; }
        /// <summary>
        /// The date/time when the Stop Order will be cancelled if its timeInForce is \&quot;GTD\&quot;.
        /// </summary>
        /// <value>The date/time when the Stop Order will be cancelled if its timeInForce is \&quot;GTD\&quot;.</value>
        [DataMember(Name="gtdTime", EmitDefaultValue=false)]
        public string GtdTime { get; set; }
        /// <summary>
        /// Gets or Sets ClientExtensions
        /// </summary>
        [DataMember(Name="clientExtensions", EmitDefaultValue=false)]
        public ClientExtensions ClientExtensions { get; set; }
        /// <summary>
        /// Gets or Sets TakeProfitOnFill
        /// </summary>
        [DataMember(Name="takeProfitOnFill", EmitDefaultValue=false)]
        public TakeProfitDetails TakeProfitOnFill { get; set; }
        /// <summary>
        /// Gets or Sets StopLossOnFill
        /// </summary>
        [DataMember(Name="stopLossOnFill", EmitDefaultValue=false)]
        public StopLossDetails StopLossOnFill { get; set; }
        /// <summary>
        /// Gets or Sets TrailingStopLossOnFill
        /// </summary>
        [DataMember(Name="trailingStopLossOnFill", EmitDefaultValue=false)]
        public TrailingStopLossDetails TrailingStopLossOnFill { get; set; }
        /// <summary>
        /// Gets or Sets TradeClientExtensions
        /// </summary>
        [DataMember(Name="tradeClientExtensions", EmitDefaultValue=false)]
        public ClientExtensions TradeClientExtensions { get; set; }
        /// <summary>
        /// The ID of the Order that this Order replaces (only provided if this Order replaces an existing Order).
        /// </summary>
        /// <value>The ID of the Order that this Order replaces (only provided if this Order replaces an existing Order).</value>
        [DataMember(Name="replacesOrderID", EmitDefaultValue=false)]
        public string ReplacesOrderID { get; set; }
        /// <summary>
        /// The ID of the Transaction that cancels the replaced Order (only provided if this Order replaces an existing Order).
        /// </summary>
        /// <value>The ID of the Transaction that cancels the replaced Order (only provided if this Order replaces an existing Order).</value>
        [DataMember(Name="cancellingTransactionID", EmitDefaultValue=false)]
        public string CancellingTransactionID { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class StopOrderTransaction {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Time: ").Append(Time).Append("\n");
            sb.Append("  UserID: ").Append(UserID).Append("\n");
            sb.Append("  AccountID: ").Append(AccountID).Append("\n");
            sb.Append("  BatchID: ").Append(BatchID).Append("\n");
            sb.Append("  RequestID: ").Append(RequestID).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Instrument: ").Append(Instrument).Append("\n");
            sb.Append("  Units: ").Append(Units).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  PriceBound: ").Append(PriceBound).Append("\n");
            sb.Append("  TimeInForce: ").Append(TimeInForce).Append("\n");
            sb.Append("  GtdTime: ").Append(GtdTime).Append("\n");
            sb.Append("  PositionFill: ").Append(PositionFill).Append("\n");
            sb.Append("  TriggerCondition: ").Append(TriggerCondition).Append("\n");
            sb.Append("  Reason: ").Append(Reason).Append("\n");
            sb.Append("  ClientExtensions: ").Append(ClientExtensions).Append("\n");
            sb.Append("  TakeProfitOnFill: ").Append(TakeProfitOnFill).Append("\n");
            sb.Append("  StopLossOnFill: ").Append(StopLossOnFill).Append("\n");
            sb.Append("  TrailingStopLossOnFill: ").Append(TrailingStopLossOnFill).Append("\n");
            sb.Append("  TradeClientExtensions: ").Append(TradeClientExtensions).Append("\n");
            sb.Append("  ReplacesOrderID: ").Append(ReplacesOrderID).Append("\n");
            sb.Append("  CancellingTransactionID: ").Append(CancellingTransactionID).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as StopOrderTransaction);
        }

        /// <summary>
        /// Returns true if StopOrderTransaction instances are equal
        /// </summary>
        /// <param name="other">Instance of StopOrderTransaction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(StopOrderTransaction other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.Time == other.Time ||
                    this.Time != null &&
                    this.Time.Equals(other.Time)
                ) && 
                (
                    this.UserID == other.UserID ||
                    this.UserID != null &&
                    this.UserID.Equals(other.UserID)
                ) && 
                (
                    this.AccountID == other.AccountID ||
                    this.AccountID != null &&
                    this.AccountID.Equals(other.AccountID)
                ) && 
                (
                    this.BatchID == other.BatchID ||
                    this.BatchID != null &&
                    this.BatchID.Equals(other.BatchID)
                ) && 
                (
                    this.RequestID == other.RequestID ||
                    this.RequestID != null &&
                    this.RequestID.Equals(other.RequestID)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.Instrument == other.Instrument ||
                    this.Instrument != null &&
                    this.Instrument.Equals(other.Instrument)
                ) && 
                (
                    this.Units == other.Units ||
                    this.Units != null &&
                    this.Units.Equals(other.Units)
                ) && 
                (
                    this.Price == other.Price ||
                    this.Price != null &&
                    this.Price.Equals(other.Price)
                ) && 
                (
                    this.PriceBound == other.PriceBound ||
                    this.PriceBound != null &&
                    this.PriceBound.Equals(other.PriceBound)
                ) && 
                (
                    this.TimeInForce == other.TimeInForce ||
                    this.TimeInForce != null &&
                    this.TimeInForce.Equals(other.TimeInForce)
                ) && 
                (
                    this.GtdTime == other.GtdTime ||
                    this.GtdTime != null &&
                    this.GtdTime.Equals(other.GtdTime)
                ) && 
                (
                    this.PositionFill == other.PositionFill ||
                    this.PositionFill != null &&
                    this.PositionFill.Equals(other.PositionFill)
                ) && 
                (
                    this.TriggerCondition == other.TriggerCondition ||
                    this.TriggerCondition != null &&
                    this.TriggerCondition.Equals(other.TriggerCondition)
                ) && 
                (
                    this.Reason == other.Reason ||
                    this.Reason != null &&
                    this.Reason.Equals(other.Reason)
                ) && 
                (
                    this.ClientExtensions == other.ClientExtensions ||
                    this.ClientExtensions != null &&
                    this.ClientExtensions.Equals(other.ClientExtensions)
                ) && 
                (
                    this.TakeProfitOnFill == other.TakeProfitOnFill ||
                    this.TakeProfitOnFill != null &&
                    this.TakeProfitOnFill.Equals(other.TakeProfitOnFill)
                ) && 
                (
                    this.StopLossOnFill == other.StopLossOnFill ||
                    this.StopLossOnFill != null &&
                    this.StopLossOnFill.Equals(other.StopLossOnFill)
                ) && 
                (
                    this.TrailingStopLossOnFill == other.TrailingStopLossOnFill ||
                    this.TrailingStopLossOnFill != null &&
                    this.TrailingStopLossOnFill.Equals(other.TrailingStopLossOnFill)
                ) && 
                (
                    this.TradeClientExtensions == other.TradeClientExtensions ||
                    this.TradeClientExtensions != null &&
                    this.TradeClientExtensions.Equals(other.TradeClientExtensions)
                ) && 
                (
                    this.ReplacesOrderID == other.ReplacesOrderID ||
                    this.ReplacesOrderID != null &&
                    this.ReplacesOrderID.Equals(other.ReplacesOrderID)
                ) && 
                (
                    this.CancellingTransactionID == other.CancellingTransactionID ||
                    this.CancellingTransactionID != null &&
                    this.CancellingTransactionID.Equals(other.CancellingTransactionID)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                if (this.Time != null)
                    hash = hash * 59 + this.Time.GetHashCode();
                if (this.UserID != null)
                    hash = hash * 59 + this.UserID.GetHashCode();
                if (this.AccountID != null)
                    hash = hash * 59 + this.AccountID.GetHashCode();
                if (this.BatchID != null)
                    hash = hash * 59 + this.BatchID.GetHashCode();
                if (this.RequestID != null)
                    hash = hash * 59 + this.RequestID.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                if (this.Instrument != null)
                    hash = hash * 59 + this.Instrument.GetHashCode();
                if (this.Units != null)
                    hash = hash * 59 + this.Units.GetHashCode();
                if (this.Price != null)
                    hash = hash * 59 + this.Price.GetHashCode();
                if (this.PriceBound != null)
                    hash = hash * 59 + this.PriceBound.GetHashCode();
                if (this.TimeInForce != null)
                    hash = hash * 59 + this.TimeInForce.GetHashCode();
                if (this.GtdTime != null)
                    hash = hash * 59 + this.GtdTime.GetHashCode();
                if (this.PositionFill != null)
                    hash = hash * 59 + this.PositionFill.GetHashCode();
                if (this.TriggerCondition != null)
                    hash = hash * 59 + this.TriggerCondition.GetHashCode();
                if (this.Reason != null)
                    hash = hash * 59 + this.Reason.GetHashCode();
                if (this.ClientExtensions != null)
                    hash = hash * 59 + this.ClientExtensions.GetHashCode();
                if (this.TakeProfitOnFill != null)
                    hash = hash * 59 + this.TakeProfitOnFill.GetHashCode();
                if (this.StopLossOnFill != null)
                    hash = hash * 59 + this.StopLossOnFill.GetHashCode();
                if (this.TrailingStopLossOnFill != null)
                    hash = hash * 59 + this.TrailingStopLossOnFill.GetHashCode();
                if (this.TradeClientExtensions != null)
                    hash = hash * 59 + this.TradeClientExtensions.GetHashCode();
                if (this.ReplacesOrderID != null)
                    hash = hash * 59 + this.ReplacesOrderID.GetHashCode();
                if (this.CancellingTransactionID != null)
                    hash = hash * 59 + this.CancellingTransactionID.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }

}
