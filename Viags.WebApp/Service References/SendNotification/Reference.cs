﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Viags.WebApp.SendNotification {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://xmlns.example.com/1461385719163", ConfigurationName="SendNotification.PortType")]
    public interface PortType {
        
        // CODEGEN: Generating message contract since the operation createSendNotification is neither RPC nor document wrapped.
        [System.ServiceModel.OperationContractAttribute(Action="/Services/Global/Utilities/SendNotification/OperationImpl/SendNotification.servic" +
            "eagent/PortTypeEndpoint1/createSendNotification", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BaseServiceEnvelopeResponseType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BaseServiceEnvelopeRequestType))]
        Viags.WebApp.SendNotification.createSendNotificationResponse createSendNotification(Viags.WebApp.SendNotification.createSendNotificationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="/Services/Global/Utilities/SendNotification/OperationImpl/SendNotification.servic" +
            "eagent/PortTypeEndpoint1/createSendNotification", ReplyAction="*")]
        System.Threading.Tasks.Task<Viags.WebApp.SendNotification.createSendNotificationResponse> createSendNotificationAsync(Viags.WebApp.SendNotification.createSendNotificationRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.Viags.gov.vn/schema/global/utilities/sendnotification/SendNotification" +
        ".xsd")]
    public partial class createSendNotificationReqType : BaseServiceEnvelopeRequestType {
        
        private SendNotificationInput sendNotificationInputField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public SendNotificationInput SendNotificationInput {
            get {
                return this.sendNotificationInputField;
            }
            set {
                this.sendNotificationInputField = value;
                this.RaisePropertyChanged("SendNotificationInput");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.Viags.gov.vn/schema/global/utilities/sendnotification/SendNotification" +
        ".xsd")]
    public partial class SendNotificationInput : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string sendNotificationIDField;
        
        private string sendNotificationTypeField;
        
        private Authentication authenticationField;
        
        private SendNotificationSMS sendNotificationSMSField;
        
        private SendNotificationEmail sendNotificationEmailField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SendNotificationID {
            get {
                return this.sendNotificationIDField;
            }
            set {
                this.sendNotificationIDField = value;
                this.RaisePropertyChanged("SendNotificationID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SendNotificationType {
            get {
                return this.sendNotificationTypeField;
            }
            set {
                this.sendNotificationTypeField = value;
                this.RaisePropertyChanged("SendNotificationType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public Authentication Authentication {
            get {
                return this.authenticationField;
            }
            set {
                this.authenticationField = value;
                this.RaisePropertyChanged("Authentication");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public SendNotificationSMS SendNotificationSMS {
            get {
                return this.sendNotificationSMSField;
            }
            set {
                this.sendNotificationSMSField = value;
                this.RaisePropertyChanged("SendNotificationSMS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public SendNotificationEmail SendNotificationEmail {
            get {
                return this.sendNotificationEmailField;
            }
            set {
                this.sendNotificationEmailField = value;
                this.RaisePropertyChanged("SendNotificationEmail");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.Viags.gov.vn/schema/global/utilities/sendnotification/SendNotification" +
        ".xsd")]
    public partial class Authentication : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string systemTypeField;
        
        private string usernameField;
        
        private string passwordField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SystemType {
            get {
                return this.systemTypeField;
            }
            set {
                this.systemTypeField = value;
                this.RaisePropertyChanged("SystemType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("Username");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Viags/common/envelope/commonheader/1.0")]
    public partial class ErrorInfoType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string idField;
        
        private string errorCodeField;
        
        private string errorMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ErrorCode {
            get {
                return this.errorCodeField;
            }
            set {
                this.errorCodeField = value;
                this.RaisePropertyChanged("ErrorCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ErrorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                this.errorMessageField = value;
                this.RaisePropertyChanged("ErrorMessage");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Viags/common/envelope/commonheader/1.0")]
    public partial class ResponseStatusType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string statusField;
        
        private string errorCodeField;
        
        private string errorMessageField;
        
        private ErrorInfoType[] errorInfoField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("Status");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ErrorCode {
            get {
                return this.errorCodeField;
            }
            set {
                this.errorCodeField = value;
                this.RaisePropertyChanged("ErrorCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ErrorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                this.errorMessageField = value;
                this.RaisePropertyChanged("ErrorMessage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ErrorInfo", Order=3)]
        public ErrorInfoType[] ErrorInfo {
            get {
                return this.errorInfoField;
            }
            set {
                this.errorInfoField = value;
                this.RaisePropertyChanged("ErrorInfo");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(createSendNotificationResType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Viags/common/envelope/serviceenvelope/1.0")]
    public partial class BaseServiceEnvelopeResponseType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private AppHdrType appHdrField;
        
        private ResponseStatusType responseStatusField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="Viags/common/envelope/commonheader/1.0", Order=0)]
        public AppHdrType AppHdr {
            get {
                return this.appHdrField;
            }
            set {
                this.appHdrField = value;
                this.RaisePropertyChanged("AppHdr");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="Viags/common/envelope/commonheader/1.0", Order=1)]
        public ResponseStatusType ResponseStatus {
            get {
                return this.responseStatusField;
            }
            set {
                this.responseStatusField = value;
                this.RaisePropertyChanged("ResponseStatus");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Viags/common/envelope/commonheader/1.0")]
    public partial class AppHdrType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string charSetField;
        
        private string servVersionField;
        
        private PairsType fromField;
        
        private PairsType toField;
        
        private string msgIdField;
        
        private string msgPreIdField;
        
        private string msgSrcIdField;
        
        private PairsType bizServField;
        
        private System.DateTime createdDateField;
        
        private string signatureField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CharSet {
            get {
                return this.charSetField;
            }
            set {
                this.charSetField = value;
                this.RaisePropertyChanged("CharSet");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ServVersion {
            get {
                return this.servVersionField;
            }
            set {
                this.servVersionField = value;
                this.RaisePropertyChanged("ServVersion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public PairsType From {
            get {
                return this.fromField;
            }
            set {
                this.fromField = value;
                this.RaisePropertyChanged("From");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public PairsType To {
            get {
                return this.toField;
            }
            set {
                this.toField = value;
                this.RaisePropertyChanged("To");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string MsgId {
            get {
                return this.msgIdField;
            }
            set {
                this.msgIdField = value;
                this.RaisePropertyChanged("MsgId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string MsgPreId {
            get {
                return this.msgPreIdField;
            }
            set {
                this.msgPreIdField = value;
                this.RaisePropertyChanged("MsgPreId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string MsgSrcId {
            get {
                return this.msgSrcIdField;
            }
            set {
                this.msgSrcIdField = value;
                this.RaisePropertyChanged("MsgSrcId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public PairsType BizServ {
            get {
                return this.bizServField;
            }
            set {
                this.bizServField = value;
                this.RaisePropertyChanged("BizServ");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public System.DateTime CreatedDate {
            get {
                return this.createdDateField;
            }
            set {
                this.createdDateField = value;
                this.RaisePropertyChanged("CreatedDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Signature {
            get {
                return this.signatureField;
            }
            set {
                this.signatureField = value;
                this.RaisePropertyChanged("Signature");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Viags/common/envelope/commonheader/1.0")]
    public partial class PairsType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string idField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("Id");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
                this.RaisePropertyChanged("Name");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.Viags.gov.vn/schema/global/utilities/sendnotification/SendNotification" +
        ".xsd")]
    public partial class createSendNotificationResType : BaseServiceEnvelopeResponseType {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(createSendNotificationReqType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Viags/common/envelope/serviceenvelope/1.0")]
    public partial class BaseServiceEnvelopeRequestType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private AppHdrType appHdrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="Viags/common/envelope/commonheader/1.0", Order=0)]
        public AppHdrType AppHdr {
            get {
                return this.appHdrField;
            }
            set {
                this.appHdrField = value;
                this.RaisePropertyChanged("AppHdr");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.Viags.gov.vn/schema/global/utilities/sendnotification/SendNotification" +
        ".xsd")]
    public partial class SendNotificationSMS : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string destinationField;
        
        private string outContentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Destination {
            get {
                return this.destinationField;
            }
            set {
                this.destinationField = value;
                this.RaisePropertyChanged("Destination");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string OutContent {
            get {
                return this.outContentField;
            }
            set {
                this.outContentField = value;
                this.RaisePropertyChanged("OutContent");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.Viags.gov.vn/schema/global/utilities/sendnotification/SendNotification" +
        ".xsd")]
    public partial class SendNotificationEmail : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string sendFromField;
        
        private string sendToField;
        
        private string sendCCField;
        
        private string sendBCCField;
        
        private string subjectField;
        
        private string contentField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SendFrom {
            get {
                return this.sendFromField;
            }
            set {
                this.sendFromField = value;
                this.RaisePropertyChanged("SendFrom");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SendTo {
            get {
                return this.sendToField;
            }
            set {
                this.sendToField = value;
                this.RaisePropertyChanged("SendTo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SendCC {
            get {
                return this.sendCCField;
            }
            set {
                this.sendCCField = value;
                this.RaisePropertyChanged("SendCC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SendBCC {
            get {
                return this.sendBCCField;
            }
            set {
                this.sendBCCField = value;
                this.RaisePropertyChanged("SendBCC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Subject {
            get {
                return this.subjectField;
            }
            set {
                this.subjectField = value;
                this.RaisePropertyChanged("Subject");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
                this.RaisePropertyChanged("Content");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class createSendNotificationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.Viags.gov.vn/schema/global/utilities/sendnotification/SendNotification" +
            ".xsd", Order=0)]
        public Viags.WebApp.SendNotification.createSendNotificationReqType createSendNotificationReq;
        
        public createSendNotificationRequest() {
        }
        
        public createSendNotificationRequest(Viags.WebApp.SendNotification.createSendNotificationReqType createSendNotificationReq) {
            this.createSendNotificationReq = createSendNotificationReq;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class createSendNotificationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.Viags.gov.vn/schema/global/utilities/sendnotification/SendNotification" +
            ".xsd", Order=0)]
        public Viags.WebApp.SendNotification.createSendNotificationResType createSendNotificationRes;
        
        public createSendNotificationResponse() {
        }
        
        public createSendNotificationResponse(Viags.WebApp.SendNotification.createSendNotificationResType createSendNotificationRes) {
            this.createSendNotificationRes = createSendNotificationRes;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PortTypeChannel : Viags.WebApp.SendNotification.PortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PortTypeClient : System.ServiceModel.ClientBase<Viags.WebApp.SendNotification.PortType>, Viags.WebApp.SendNotification.PortType {
        
        public PortTypeClient() {
        }
        
        public PortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Viags.WebApp.SendNotification.createSendNotificationResponse Viags.WebApp.SendNotification.PortType.createSendNotification(Viags.WebApp.SendNotification.createSendNotificationRequest request) {
            return base.Channel.createSendNotification(request);
        }
        
        public Viags.WebApp.SendNotification.createSendNotificationResType createSendNotification(Viags.WebApp.SendNotification.createSendNotificationReqType createSendNotificationReq) {
            Viags.WebApp.SendNotification.createSendNotificationRequest inValue = new Viags.WebApp.SendNotification.createSendNotificationRequest();
            inValue.createSendNotificationReq = createSendNotificationReq;
            Viags.WebApp.SendNotification.createSendNotificationResponse retVal = ((Viags.WebApp.SendNotification.PortType)(this)).createSendNotification(inValue);
            return retVal.createSendNotificationRes;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Viags.WebApp.SendNotification.createSendNotificationResponse> Viags.WebApp.SendNotification.PortType.createSendNotificationAsync(Viags.WebApp.SendNotification.createSendNotificationRequest request) {
            return base.Channel.createSendNotificationAsync(request);
        }
        
        public System.Threading.Tasks.Task<Viags.WebApp.SendNotification.createSendNotificationResponse> createSendNotificationAsync(Viags.WebApp.SendNotification.createSendNotificationReqType createSendNotificationReq) {
            Viags.WebApp.SendNotification.createSendNotificationRequest inValue = new Viags.WebApp.SendNotification.createSendNotificationRequest();
            inValue.createSendNotificationReq = createSendNotificationReq;
            return ((Viags.WebApp.SendNotification.PortType)(this)).createSendNotificationAsync(inValue);
        }
    }
}
