using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Gsort.Mwanzowadata
{
    public class Mpesa
    {
        public Mpesa()
        {
            Console.Title = "OAUTH";
            String a = "https://sandbox.safaricom.co.ke/oauth/v1/generate?grant_type=client_credentials";
            String baseUrl = a;

            String app_key = "bYBiRy4gsWkPjMMcuYDrtT2AjEYnoIrx";
            String app_secret = "3tUcCxyFXOtOu19m";

            byte[] auth = Encoding.UTF8.GetBytes(app_key + ":" + app_secret);
            String encoded = System.Convert.ToBase64String(auth);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseUrl);
            request.Headers.Add("Authorization", "Basic bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919" + encoded);
            request.ContentType = "application/json";
            request.Headers.Add("cache-control", "no-cache");
            request.Method = "GET";

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Get the stream associated with the response.
                Stream receiveStream = response.GetResponseStream();

                // Pipes the stream to a higher level stream reader with the required encoding format. 
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

                Console.WriteLine(readStream.ReadToEnd());
                response.Close();
                readStream.Close();
            }
            catch (WebException ex)
            {
                var resp = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                Console.WriteLine(resp);

            }


        }
    }
}