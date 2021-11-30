using Atlassian.Jira;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace MongoDBWebAPI.SeleniumGridTest
{
    public static class MyJiraClient
    {
        public static void AddIssue(ITestFailed testFailed, byte[] bytes)
        {
            var url = "https://palm-tree.atlassian.net/";
            var username = "sotheareth.ham@gmail.com";
            var apiKey = "8hc4ECVPMB0BIkFwjGqvBD4D";
            try
            {
                var messages = testFailed.Messages;
                var errorMessage = string.Join(", ", messages);

                var jiraClient = Jira.CreateRestClient(url, username, apiKey);

                var issue = jiraClient.CreateIssue("PT");
                issue.Type = "Bug";
                issue.Summary = "Bug: class name => " + testFailed.TestCase.DisplayName;
                issue.Description = errorMessage;

                var attachments = new UploadAttachmentInfo[] {
                    new UploadAttachmentInfo(Guid.NewGuid().ToString(), bytes)
                };                

                issue.AddAttachment(attachments);
                issue.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"exception: {ex}");
            }
        }

        public static string GetEncodedCredentials(string UserName, string Password)
        {
            string mergedCredentials = String.Format("{0}:{1}", UserName, Password);
            byte[] byteCredentials = Encoding.UTF8.GetBytes(mergedCredentials);
            return Convert.ToBase64String(byteCredentials);
        }

        public static void AddJiraIssue()
        {
            try
            {
                var url = "https://palm-tree.atlassian.net/rest/api/latest/issue";
                string JsonString = "{\"fields\": {\"project\":{\"key\":\"PT\"},\"summary\":\"Sub - task of ABC-123\",\"description\":\"Don't forget to do this too.\",\"issuetype\":{\"name\":\"Task\"}}}";

                var username = "sotheareth.ham@gmail.com";
                var apiKey = "8hc4ECVPMB0BIkFwjGqvBD4D";
                var credential = GetEncodedCredentials(username, apiKey);
                HttpWebResponse response = null;
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", $"Basic {credential}");

                byte[] data = Encoding.UTF8.GetBytes(JsonString);
                using(var requestStream = request.GetRequestStream()) {  
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Close();
                }

                using (response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode == HttpStatusCode.Created)
                    {
                        var reader = new StreamReader(response.GetResponseStream());
                        string str = reader.ReadToEnd();
                        Console.WriteLine("The server returned '{0}'\n{1}", response.StatusCode, str);
                        Console.WriteLine("Issue created sucessfully.");                        
                    }
                    else
                    {
                        Console.WriteLine("Error returned from Server:" + response.StatusCode + " Status Description : " + response.StatusDescription);
                    }
                }
                request.Abort();  
            }  
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.Message);
            }

        } 
    }
}
