﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GetHairdresser.Client.HairdressInfoService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HairdressInfoService.IHairdressInfoService")]
    public interface IHairdressInfoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHairdressInfoService/GetHairdressInform", ReplyAction="http://tempuri.org/IHairdressInfoService/GetHairdressInformResponse")]
        GetHairDresser.Common.Entities.HairdresInfo GetHairdressInform(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHairdressInfoService/GetHairdressInform", ReplyAction="http://tempuri.org/IHairdressInfoService/GetHairdressInformResponse")]
        System.Threading.Tasks.Task<GetHairDresser.Common.Entities.HairdresInfo> GetHairdressInformAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHairdressInfoService/SetHairdressInform", ReplyAction="http://tempuri.org/IHairdressInfoService/SetHairdressInformResponse")]
        bool SetHairdressInform(GetHairDresser.Common.Entities.HairdresInfo info);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IHairdressInfoService/SetHairdressInform", ReplyAction="http://tempuri.org/IHairdressInfoService/SetHairdressInformResponse")]
        System.Threading.Tasks.Task<bool> SetHairdressInformAsync(GetHairDresser.Common.Entities.HairdresInfo info);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IHairdressInfoServiceChannel : GetHairdresser.Client.HairdressInfoService.IHairdressInfoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class HairdressInfoServiceClient : System.ServiceModel.ClientBase<GetHairdresser.Client.HairdressInfoService.IHairdressInfoService>, GetHairdresser.Client.HairdressInfoService.IHairdressInfoService {
        
        public HairdressInfoServiceClient() {
        }
        
        public HairdressInfoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public HairdressInfoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HairdressInfoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public HairdressInfoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public GetHairDresser.Common.Entities.HairdresInfo GetHairdressInform(int id) {
            return base.Channel.GetHairdressInform(id);
        }
        
        public System.Threading.Tasks.Task<GetHairDresser.Common.Entities.HairdresInfo> GetHairdressInformAsync(int id) {
            return base.Channel.GetHairdressInformAsync(id);
        }
        
        public bool SetHairdressInform(GetHairDresser.Common.Entities.HairdresInfo info) {
            return base.Channel.SetHairdressInform(info);
        }
        
        public System.Threading.Tasks.Task<bool> SetHairdressInformAsync(GetHairDresser.Common.Entities.HairdresInfo info) {
            return base.Channel.SetHairdressInformAsync(info);
        }
    }
}