using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestWCFServiceLibrary
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface IRestWCFServiceLibrary
    {



        [OperationContract]
        [WebInvoke(Method = "GET",
           UriTemplate = "GetSources",
                        BodyStyle = WebMessageBodyStyle.Wrapped,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Source> GetSources();


        [OperationContract]
        [WebInvoke(Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/GetImages?id={id}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string GetImages(string id);

        [OperationContract]
        [WebInvoke(Method = "GET",
        UriTemplate = "IsInstalledFlag",
                        BodyStyle = WebMessageBodyStyle.Wrapped,

                ResponseFormat = WebMessageFormat.Json,
                    RequestFormat = WebMessageFormat.Json
                   )]


        bool IsInstalledFlag();


    }

    public sealed class Source
    {

        public string Id
        {
            get;
            set;
        }


        public string Name
        {
            get;
            set;
        }


        public SourcePlatform Platform
        {
            get;
            set;
        }


        public DsmVersion Version
        {
            get;
            set;
        }


        public bool IsDefault
        {
            get;
            set;
        }
    }




    public enum SourcePlatform
    {
        X86_32,
        X86_64
    }

    public enum DsmVersion
    {
        V1,
        V2
    }
}
