using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MpesaLib;
using System.Net;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.X509;
using System.IO;
using System.Security.Cryptography;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;
using System.Threading.Tasks;

namespace Gsort.Mwanzowadata
{
    public class Payments
    {
        private readonly Env Environment;
        private readonly string ConsumerKey;
        private readonly string ConsumerSecret;
        private RestClient client;
        private ExtraConfig Config;
        /// <summary>
        /// Used to set extra config needed for advanced calls such as LNM
        /// </summary>
        public class ExtraConfig
        {
            /// <summary>
            /// Gets or sets the short code.
            /// </summary>
            /// <value>The short code.</value>
            //public int ShortCode { get; set; }
            /// <summary>
            /// Gets or sets the initiator.
            /// </summary>
            /// <value>The initiator.</value>
            //public string Initiator { get; set; }
            /// <summary>
            /// Gets or sets the LNM Short code.
            /// </summary>
            /// <value>The LNM Shortcode.</value>
            public int LNMShortCode { get; set; }
            /// <summary>
            /// Gets or sets the LNM Password.
            /// </summary>
            /// <value>The LNMPassword.</value>
            public string LNMPassWord { get; set; }
            /// <summary>
            /// Gets or sets the security credential.
            /// </summary>
            /// <value>The security credential.</value>
            //public string SecurityCredential { get; set; }
            /// <summary>
            /// Gets or sets the cert path.
            /// </summary>
            /// <value>Path to Mpesa Public Key</value>
            /// 
            //public string CertPath { get; set; }
        }
        public class Env
        {
            public string Endpoint { get; set; }
            private Env(string env) { Endpoint = env; }
            public static Env Sandbox { get { return new Env("https://sandbox.safaricom.co.ke"); } }
            public static Env Production { get { return new Env("https://api.safaricom.co.ke"); } }
        }

        public Payments(Env env, string consumerKey, string consumerSecret, ExtraConfig config = null)
        {
            Environment = env;
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            client = new RestClient(env.Endpoint);
            if (config != null)
                Config = config;

        }/*
        protected string GetSecurityCredential()
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(Config.SecurityCredential);

            PemReader pr = new PemReader(
                (StreamReader)File.OpenText(Config.CertPath)
            );
            X509Certificate certificate = (X509Certificate)pr.ReadObject();

            //PKCS1 v1.5 paddings
            Pkcs1Encoding eng = new Pkcs1Encoding(new RsaEngine());
            eng.Init(true, certificate.GetPublicKey());

            int length = plainTextBytes.Length;
            int blockSize = eng.GetInputBlockSize();
            List<byte> cipherTextBytes = new List<byte>();
            for (int chunkPosition = 0;
                chunkPosition < length;
                chunkPosition += blockSize)
            {
                int chunkSize = Math.Min(blockSize, length - chunkPosition);
                cipherTextBytes.AddRange(eng.ProcessBlock(
                    plainTextBytes, chunkPosition, chunkSize
                ));
            }
            return Convert.ToBase64String(cipherTextBytes.ToArray());
        }*/

        private RestRequest GenerateAuthRequest()
        {
            var request = new RestRequest("/oauth/v1/generate?grant_type=client_credentials", Method.GET);
            byte[] creds = Encoding.UTF8.GetBytes(ConsumerKey + ":" + ConsumerSecret);
            string encoded = System.Convert.ToBase64String(creds);
            request.AddHeader("Authorization", "Basic " + encoded);
            return request;
        }

        public IRestResponse<AuthResponse> Auth()
        {
            IRestResponse<AuthResponse> response = client.Execute<AuthResponse>(GenerateAuthRequest());
            return response;
        }
        public Task<IRestResponse<AuthResponse>> AuthAsync()
        {
            return client.ExecuteAsync<AuthResponse>(GenerateAuthRequest());
        }
        /*
        public Task<IRestResponse<C2BRegisterResponse>> C2BRegister(string confirmationURL, string validationURL)
        {
            var request = new RestRequest("mpesa/c2b/v1/registerurl", Method.POST);
            AuthResponse authResponse = this.Auth().Data;
            request.AddHeader("Authorization", "Bearer " + authResponse.AccessToken);
            request.AddJsonBody(new
            {
                Config.ShortCode,
                ResponseType = "Completed",
                ConfirmationURL = confirmationURL,
                ValidationURL = validationURL
            });
            return client.ExecuteAsync<C2BRegisterResponse>(request);
        }
        */
        public Task<IRestResponse<LNMPaymentResponse>> LipaNaMpesaOnline(long senderMsisdn, int amount, string callbackUrl, string accountRef, string transactionDesc = "Lipa na mpesa online")
        {
            var request = new RestRequest("/mpesa/stkpush/v1/processrequest", Method.POST);
            AuthResponse authResponse = this.Auth().Data;
            request.AddHeader("Authorization", "Bearer " + authResponse.AccessToken);
            var timeStamp = DateTime.Now.ToString("yyyyMMddDDmmss");
            var password = string.Concat(Config.LNMShortCode, Config.LNMPassWord, timeStamp);
            request.AddJsonBody(new
            {
                BusinessShortCode = Config.LNMShortCode,
                Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password)),
                Timestamp = timeStamp,
                TransactionType = CommandID.CustomerPayBillOnline.ToString(), // see https://developer.safaricom.co.ke/docs#lipa-na-m-pesa-online-payment-request-parameters
                Amount = amount,
                PartyA = senderMsisdn,
                PartyB = Config.LNMShortCode,
                PhoneNumber = senderMsisdn,
                CallBackURL = callbackUrl,
                AccountReference = accountRef,
                TransactionDesc = transactionDesc
            });
            return client.ExecuteAsync<LNMPaymentResponse>(request);
        }
        public Task<IRestResponse<LNMQueryResponse>> LipaNaMpesaQuery(string checkoutRequestId)
        {
            var request = new RestRequest("/mpesa/stkpushquery/v1/query", Method.POST);
            AuthResponse authResponse = this.Auth().Data;
            request.AddHeader("Authorization", "Bearer " + authResponse.AccessToken);
            var timeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            var password = string.Concat(Config.LNMShortCode, Config.LNMPassWord, timeStamp);
            request.AddJsonBody(new
            {
                BusinessShortCode = Config.LNMShortCode,
                Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password)),
                Timestamp = timeStamp,
                CheckoutRequestID = checkoutRequestId
            });
            return client.ExecuteAsync<LNMQueryResponse>(request);
        }/*
        public Task<IRestResponse<TransactionStatusResponse>> TransactionStatus(string transactionId, string queueUrl, string resultUrl, string remarks = "TransactionReversal", string occasion = "TransactionReversal")
        {
            IdentityParty receiverParty = new IdentityParty(Config.ShortCode, IdentityParty.IdentifierType.SHORTCODE);
            var request = new RestRequest("/mpesa/transactionstatus/v1/query", Method.POST);
            AuthResponse authResponse = this.Auth().Data;
            request.AddHeader("Authorization", "Bearer " + authResponse.AccessToken);
            request.AddJsonBody(new
            {
                Config.Initiator,
                SecurityCredential = GetSecurityCredential(),
                CommandID = CommandID.TransactionStatusQuery.ToString(),
                TransactionID = transactionId,
                PartyA = receiverParty.Party,
                IdentifierType = receiverParty.Type,
                ResultURL = resultUrl,
                QueueTimeOutURL = queueUrl,
                Remarks = remarks,
                Occasion = occasion
            });
            return client.ExecuteAsync<TransactionStatusResponse>(request);
        }*/
        /*service.AddHttpClient<IMpesaClient, MpesaClient>(options => options.BaseAddress = RequestEndPoint.SandboxBaseAddress);
            private readonly IMpesaClient mpesaClient;
        public Payments(IMpesaClient _mpesaClient)
        {
            _mpesaClient = mpesaClient;
            var accesstoken = await _mpesaClient.GetAuthTokenAsync("bYBiRy4gsWkPjMMcuYDrtT2AjEYnoIrx", "3tUcCxyFXOtOu19m", RequestEndPoint.AuthToken);
        }*/

    }
}