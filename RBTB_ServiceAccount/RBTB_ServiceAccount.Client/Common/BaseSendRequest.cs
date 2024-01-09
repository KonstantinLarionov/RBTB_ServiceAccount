using RBTB_ServiceAccount.Client.Extensions;
using RestSharp;

namespace RBTB_ServiceAccount.Client.Common
{
    internal class BaseSendRequest<T>
    {
        public BaseResponse<T> SendRequest( IRestClient client, BaseRequest baseRequest )
        {
            //var method = baseRequest.Method.GetMethod();
            //var request = new RestRequest( baseRequest.EndPoint + baseRequest.Query, method );
            //if ( method != Method.Get && baseRequest.Properties is not null)
            //{
            //    request.AddBody( baseRequest.Properties );
            //}

            //return await client.ExecuteAsync( request );

            var method = baseRequest.Method.GetMethod();

            var endpoint = method == Method.GET ? baseRequest.Properties.GenerateParametersString() : string.Empty;
            var request = new RestRequest( baseRequest.EndPoint + endpoint, method );

           if ( method != Method.GET && baseRequest.Properties is not null )
            {
                request.AddJsonBody( baseRequest.Properties );
            }

            var response = SendRequest( request.Method, client, request );

            if ( response.Data != null )
            {
                return response.Data;
            }

            return new BaseResponse<T> { Success = false };
        }

        private IRestResponse<BaseResponse<T>> SendRequest( Method method, IRestClient client, RestRequest request )
        {
            return method switch
            {
                Method.DELETE => client.Delete<BaseResponse<T>>( request ),
                Method.POST => client.Post<BaseResponse<T>>( request ),
                Method.PUT => client.Put<BaseResponse<T>>( request ),
                _ => client.Get<BaseResponse<T>>( request ),
            };
        }
    }
}
