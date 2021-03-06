//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PaymentService.AcctsMngAGW
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://www.ecp.mof.gov.sa/agw", ConfigurationName="PaymentService.AcctsMngAGW.AcctsMngAGW")]
    public interface AcctsMngAGW
    {
        
        // CODEGEN: Generating message contract since the operation AcctsMngAGW is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="AcctsMngAGW", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(AcctRec_Type))]
        PaymentService.AcctsMngAGW.AcctsMngAGWResponse AcctsMngAGW(PaymentService.AcctsMngAGW.AcctsMngAGWRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="AcctsMngAGW", ReplyAction="*")]
        System.Threading.Tasks.Task<PaymentService.AcctsMngAGW.AcctsMngAGWResponse> AcctsMngAGWAsync(PaymentService.AcctsMngAGW.AcctsMngAGWRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class AcctsMngAGWRq_Type
    {
        
        private MsgRqHdr_Type msgRqHdrField;
        
        private AcctsMngAGWRqBody_Type bodyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public MsgRqHdr_Type MsgRqHdr
        {
            get
            {
                return this.msgRqHdrField;
            }
            set
            {
                this.msgRqHdrField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public AcctsMngAGWRqBody_Type Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class MsgRqHdr_Type
    {
        
        private string rqUIDField;
        
        private SCId_Type sCIdField;
        
        private string funcIdField;
        
        private PartnerInfo_Type partnerInfoField;
        
        private long rqModeField;
        
        private bool rqModeFieldSpecified;
        
        private PartyId_Type partyIdField;
        
        private string userIdField;
        
        private string proxyUserIdField;
        
        private System.DateTime clientDtField;
        
        private string echoDataField;
        
        private string versionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string RqUID
        {
            get
            {
                return this.rqUIDField;
            }
            set
            {
                this.rqUIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public SCId_Type SCId
        {
            get
            {
                return this.sCIdField;
            }
            set
            {
                this.sCIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string FuncId
        {
            get
            {
                return this.funcIdField;
            }
            set
            {
                this.funcIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public PartnerInfo_Type PartnerInfo
        {
            get
            {
                return this.partnerInfoField;
            }
            set
            {
                this.partnerInfoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public long RqMode
        {
            get
            {
                return this.rqModeField;
            }
            set
            {
                this.rqModeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RqModeSpecified
        {
            get
            {
                return this.rqModeFieldSpecified;
            }
            set
            {
                this.rqModeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public PartyId_Type PartyId
        {
            get
            {
                return this.partyIdField;
            }
            set
            {
                this.partyIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string UserId
        {
            get
            {
                return this.userIdField;
            }
            set
            {
                this.userIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string ProxyUserId
        {
            get
            {
                return this.proxyUserIdField;
            }
            set
            {
                this.proxyUserIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public System.DateTime ClientDt
        {
            get
            {
                return this.clientDtField;
            }
            set
            {
                this.clientDtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string EchoData
        {
            get
            {
                return this.echoDataField;
            }
            set
            {
                this.echoDataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public enum SCId_Type
    {
        
        /// <remarks/>
        G2G,
        
        /// <remarks/>
        ECLLCTN,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class PartnerInfo_Type
    {
        
        private string partnerIdField;
        
        private PartnerType_Type partnerTypeField;
        
        private string partnerCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string PartnerId
        {
            get
            {
                return this.partnerIdField;
            }
            set
            {
                this.partnerIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public PartnerType_Type PartnerType
        {
            get
            {
                return this.partnerTypeField;
            }
            set
            {
                this.partnerTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string PartnerCode
        {
            get
            {
                return this.partnerCodeField;
            }
            set
            {
                this.partnerCodeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public enum PartnerType_Type
    {
        
        /// <remarks/>
        GOVT,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class Status_Type
    {
        
        private string statusCodeField;
        
        private string statusDescField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string StatusCode
        {
            get
            {
                return this.statusCodeField;
            }
            set
            {
                this.statusCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string StatusDesc
        {
            get
            {
                return this.statusDescField;
            }
            set
            {
                this.statusDescField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class MsgRsHdr_Type
    {
        
        private string rqUIDField;
        
        private string sPRefNumField;
        
        private string msgRecDtField;
        
        private Status_Type statusField;
        
        private string echoDataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string RqUID
        {
            get
            {
                return this.rqUIDField;
            }
            set
            {
                this.rqUIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SPRefNum
        {
            get
            {
                return this.sPRefNumField;
            }
            set
            {
                this.sPRefNumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string MsgRecDt
        {
            get
            {
                return this.msgRecDtField;
            }
            set
            {
                this.msgRecDtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public Status_Type Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string EchoData
        {
            get
            {
                return this.echoDataField;
            }
            set
            {
                this.echoDataField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class AcctsMngAGWRs_Type
    {
        
        private MsgRsHdr_Type msgRsHdrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public MsgRsHdr_Type MsgRsHdr
        {
            get
            {
                return this.msgRsHdrField;
            }
            set
            {
                this.msgRsHdrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class POI_Type
    {
        
        private string pOINumField;
        
        private POIType_Type pOITypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string POINum
        {
            get
            {
                return this.pOINumField;
            }
            set
            {
                this.pOINumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public POIType_Type POIType
        {
            get
            {
                return this.pOITypeField;
            }
            set
            {
                this.pOITypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public enum POIType_Type
    {
        
        /// <remarks/>
        NAT,
        
        /// <remarks/>
        IQA,
        
        /// <remarks/>
        BIS,
        
        /// <remarks/>
        UOI,
        
        /// <remarks/>
        C700,
        
        /// <remarks/>
        GCC,
        
        /// <remarks/>
        PAS,
        
        /// <remarks/>
        BDN,
        
        /// <remarks/>
        FCN,
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AcctInfo_Type))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class AcctRec_Type
    {
        
        private string agencyIdField;
        
        private string billAcctField;
        
        private AcctAction_Type acctActionField;
        
        private bool acctActionFieldSpecified;
        
        private AcctStatusCode_Type acctStatusCodeField;
        
        private bool acctStatusCodeFieldSpecified;
        
        private POI_Type benPOIField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string AgencyId
        {
            get
            {
                return this.agencyIdField;
            }
            set
            {
                this.agencyIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string BillAcct
        {
            get
            {
                return this.billAcctField;
            }
            set
            {
                this.billAcctField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public AcctAction_Type AcctAction
        {
            get
            {
                return this.acctActionField;
            }
            set
            {
                this.acctActionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcctActionSpecified
        {
            get
            {
                return this.acctActionFieldSpecified;
            }
            set
            {
                this.acctActionFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public AcctStatusCode_Type AcctStatusCode
        {
            get
            {
                return this.acctStatusCodeField;
            }
            set
            {
                this.acctStatusCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AcctStatusCodeSpecified
        {
            get
            {
                return this.acctStatusCodeFieldSpecified;
            }
            set
            {
                this.acctStatusCodeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public POI_Type BenPOI
        {
            get
            {
                return this.benPOIField;
            }
            set
            {
                this.benPOIField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public enum AcctAction_Type
    {
        
        /// <remarks/>
        I,
        
        /// <remarks/>
        A,
        
        /// <remarks/>
        D,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public enum AcctStatusCode_Type
    {
        
        /// <remarks/>
        AcctNew,
        
        /// <remarks/>
        AcctActivate,
        
        /// <remarks/>
        AcctDeact,
        
        /// <remarks/>
        Update,
        
        /// <remarks/>
        RemoveAssociation,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class AcctInfo_Type : AcctRec_Type
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class AcctsMngAGWRqBody_Type
    {
        
        private string batchIdField;
        
        private AcctInfo_Type[] acctListField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string BatchId
        {
            get
            {
                return this.batchIdField;
            }
            set
            {
                this.batchIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AcctInfo", IsNullable=false)]
        public AcctInfo_Type[] AcctList
        {
            get
            {
                return this.acctListField;
            }
            set
            {
                this.acctListField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public partial class PartyId_Type
    {
        
        private string partyIdNumField;
        
        private PartyIdType_Type partyIdTypeField;
        
        private bool partyIdTypeFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string PartyIdNum
        {
            get
            {
                return this.partyIdNumField;
            }
            set
            {
                this.partyIdNumField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public PartyIdType_Type PartyIdType
        {
            get
            {
                return this.partyIdTypeField;
            }
            set
            {
                this.partyIdTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PartyIdTypeSpecified
        {
            get
            {
                return this.partyIdTypeFieldSpecified;
            }
            set
            {
                this.partyIdTypeFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://www.ecp.mof.gov.sa/agw")]
    public enum PartyIdType_Type
    {
        
        /// <remarks/>
        IqamaNumber,
        
        /// <remarks/>
        NationalId,
        
        /// <remarks/>
        CommercialRegistration,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("700Code")]
        Item700Code,
        
        /// <remarks/>
        AccountNumber,
        
        /// <remarks/>
        FamilyCardNumber,
        
        /// <remarks/>
        BorderNumber,
        
        /// <remarks/>
        PassportNumber,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AcctsMngAGWRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://www.ecp.mof.gov.sa/agw", Order=0)]
        public PaymentService.AcctsMngAGW.AcctsMngAGWRq_Type AcctsMngAGWRq;
        
        public AcctsMngAGWRequest()
        {
        }
        
        public AcctsMngAGWRequest(PaymentService.AcctsMngAGW.AcctsMngAGWRq_Type AcctsMngAGWRq)
        {
            this.AcctsMngAGWRq = AcctsMngAGWRq;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AcctsMngAGWResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://www.ecp.mof.gov.sa/agw", Order=0)]
        public PaymentService.AcctsMngAGW.AcctsMngAGWRs_Type AcctsMngAGWRs;
        
        public AcctsMngAGWResponse()
        {
        }
        
        public AcctsMngAGWResponse(PaymentService.AcctsMngAGW.AcctsMngAGWRs_Type AcctsMngAGWRs)
        {
            this.AcctsMngAGWRs = AcctsMngAGWRs;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface AcctsMngAGWChannel : PaymentService.AcctsMngAGW.AcctsMngAGW, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class AcctsMngAGWClient : System.ServiceModel.ClientBase<PaymentService.AcctsMngAGW.AcctsMngAGW>, PaymentService.AcctsMngAGW.AcctsMngAGW
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public AcctsMngAGWClient() : 
                base(AcctsMngAGWClient.GetDefaultBinding(), AcctsMngAGWClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.AcctsMngAGWSOAP.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AcctsMngAGWClient(EndpointConfiguration endpointConfiguration) : 
                base(AcctsMngAGWClient.GetBindingForEndpoint(endpointConfiguration), AcctsMngAGWClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AcctsMngAGWClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(AcctsMngAGWClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AcctsMngAGWClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(AcctsMngAGWClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public AcctsMngAGWClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PaymentService.AcctsMngAGW.AcctsMngAGWResponse PaymentService.AcctsMngAGW.AcctsMngAGW.AcctsMngAGW(PaymentService.AcctsMngAGW.AcctsMngAGWRequest request)
        {
            return base.Channel.AcctsMngAGW(request);
        }
        
        public PaymentService.AcctsMngAGW.AcctsMngAGWRs_Type AcctsMngAGW(PaymentService.AcctsMngAGW.AcctsMngAGWRq_Type AcctsMngAGWRq)
        {
            PaymentService.AcctsMngAGW.AcctsMngAGWRequest inValue = new PaymentService.AcctsMngAGW.AcctsMngAGWRequest();
            inValue.AcctsMngAGWRq = AcctsMngAGWRq;
            PaymentService.AcctsMngAGW.AcctsMngAGWResponse retVal = ((PaymentService.AcctsMngAGW.AcctsMngAGW)(this)).AcctsMngAGW(inValue);
            return retVal.AcctsMngAGWRs;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PaymentService.AcctsMngAGW.AcctsMngAGWResponse> PaymentService.AcctsMngAGW.AcctsMngAGW.AcctsMngAGWAsync(PaymentService.AcctsMngAGW.AcctsMngAGWRequest request)
        {
            return base.Channel.AcctsMngAGWAsync(request);
        }
        
        public System.Threading.Tasks.Task<PaymentService.AcctsMngAGW.AcctsMngAGWResponse> AcctsMngAGWAsync(PaymentService.AcctsMngAGW.AcctsMngAGWRq_Type AcctsMngAGWRq)
        {
            PaymentService.AcctsMngAGW.AcctsMngAGWRequest inValue = new PaymentService.AcctsMngAGW.AcctsMngAGWRequest();
            inValue.AcctsMngAGWRq = AcctsMngAGWRq;
            return ((PaymentService.AcctsMngAGW.AcctsMngAGW)(this)).AcctsMngAGWAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.AcctsMngAGWSOAP))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.AcctsMngAGWSOAP))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:7800/AcctsMngAGW");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return AcctsMngAGWClient.GetBindingForEndpoint(EndpointConfiguration.AcctsMngAGWSOAP);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return AcctsMngAGWClient.GetEndpointAddress(EndpointConfiguration.AcctsMngAGWSOAP);
        }
        
        public enum EndpointConfiguration
        {
            
            AcctsMngAGWSOAP,
        }
    }
}
