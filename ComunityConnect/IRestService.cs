using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace ComunityConnect
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRestService" in both code and config file together.
    [ServiceContract]
    public interface IRestService
    {
        [WebGet(UriTemplate = "/DeleteUser?UserNo={UserID}",
            ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool DeleteUser(int UserID);

        [WebGet(UriTemplate = "/DeleteEvent?EventNo={EventID}",
           ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        bool DeleteEvent(int EventID);

        [WebGet(UriTemplate = "/ReadAllEvents",
    ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        CCtblEvent[] ReadEventList();

        [WebGet(UriTemplate = "/Read?UserNo={UserID}",
        ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        CCtblUser ReadUser(int UserID);



        [WebInvoke(UriTemplate = "/CreateGuest",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare
           )]
        [OperationContract]
        string CreateGuestPost(CCtblGuestLookUp guest);

        [WebInvoke(UriTemplate = "/CreateUser",
    ResponseFormat = WebMessageFormat.Json,
    RequestFormat = WebMessageFormat.Json,
    BodyStyle = WebMessageBodyStyle.Bare)]
        [OperationContract]
        string CreateUserPost(CCtblUser CreateUser);


    








    }
}
