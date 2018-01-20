using System;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using System.Diagnostics;
using Newtonsoft.Json;

namespace LibraryApp.Classes
{
    class DataTransfer
    {

        #region Get


        public static async Task<List<Book>> GetBooks()
        {
            return await ("http://localhost:6464/api/books").GetJsonAsync<List<Book>>();
            
        }

        public static async Task<List<Genre>> GetGenres()
        {
            return await "http://localhost:6464/api/books/genres".GetJsonAsync<List<Genre>>();
        }

        public static async Task<dynamic> GetAuthors()
        {
            var result = "";
            try
            {
                result = await ("http://localhost:6464/api/authors").WithHeader("Content-Type", "application/json").GetStringAsync();
            }
            catch (FlurlHttpException httpex)
            {
                if (httpex.Call.HttpStatus != HttpStatusCode.OK)
                {
                    return "There was an issue fetching the data.";
                }
                Debug.WriteLine("Exception Caught (InnerException): " + httpex.InnerException.ToString());
                Debug.WriteLine("Exception Caught (Message): " + httpex.Message.ToString());
                Debug.WriteLine(httpex.Call.HttpStatus);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return "There was an issue fetching the data.";
            }


            Debug.WriteLine("Response recieved: " + result.ToString());

            return result;
        }
        public static async Task<dynamic> GetBook(int Id)
        {
            var result = "";
            try
            {
                result = await ("http://localhost:6464/api/books/" + Id).WithHeader("Content-Type", "application/json").GetStringAsync();
            }
            catch (FlurlHttpException httpex)
            {
                if (httpex.Call.HttpStatus == HttpStatusCode.NotFound)
                {
                    return "The data was not found based on your request.";
                }
                Debug.WriteLine("Exception Caught (InnerException): " + httpex.InnerException.ToString());
                Debug.WriteLine("Exception Caught (Message): " + httpex.Message.ToString());
                Debug.WriteLine(httpex.Call.HttpStatus);
                
            }
             
            
            return result;
        }
        public static async Task<dynamic> GetAuthor(int Id)
        {
            var getResp = await ("http://localhost:6464/api/authors/" + Id).WithHeader("Content-Type", "application/json").GetStringAsync();
            return getResp;
        }
        
        
        #endregion

        #region Post


        public static async Task<HttpResponseMessage> PostBook( Book book )
        {
            var result = new HttpResponseMessage();
            try
            {
                result = await ("http://localhost:6464/api/books/")
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(book);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return result;
        }

        public static async Task<HttpResponseMessage> PostGenre( Genre genre)
        {
            var result = new HttpResponseMessage();
            try
            {
                result = await "http://localhost:6464/api/books/genres"
                    .WithHeader("Content-Type", "application/json")
                    .PostJsonAsync(genre);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return result;
        }

        #endregion

    }
}
