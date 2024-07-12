using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {

            string token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyX25hbWUiOiI5NDQwNzAyOCIsInNjb3BlIjpbImFsbGVncm86YXBpOm9yZGVyczpyZWFkIiwiYWxsZWdybzphcGk6cHJvZmlsZTp3cml0ZSIsImFsbGVncm86YXBpOnNhbGU6b2ZmZXJzOndyaXRlIiwiYWxsZWdybzphcGk6YmlsbGluZzpyZWFkIiwiYWxsZWdybzphcGk6Y2FtcGFpZ25zIiwiYWxsZWdybzphcGk6ZGlzcHV0ZXMiLCJhbGxlZ3JvOmFwaTpzYWxlOm9mZmVyczpyZWFkIiwiYWxsZWdybzphcGk6YmlkcyIsImFsbGVncm86YXBpOm9yZGVyczp3cml0ZSIsImFsbGVncm86YXBpOmFkcyIsImFsbGVncm86YXBpOnBheW1lbnRzOndyaXRlIiwiYWxsZWdybzphcGk6c2FsZTpzZXR0aW5nczp3cml0ZSIsImFsbGVncm86YXBpOnByb2ZpbGU6cmVhZCIsImFsbGVncm86YXBpOnJhdGluZ3MiLCJhbGxlZ3JvOmFwaTpzYWxlOnNldHRpbmdzOnJlYWQiLCJhbGxlZ3JvOmFwaTpwYXltZW50czpyZWFkIiwiYWxsZWdybzphcGk6bWVzc2FnaW5nIl0sImFsbGVncm9fYXBpIjp0cnVlLCJpc3MiOiJodHRwczovL2FsbGVncm8ucGwuYWxsZWdyb3NhbmRib3gucGwiLCJleHAiOjE3MjA4MTQ1MjcsImp0aSI6IjU2NjVlYWY4LTQ4MjEtNGQ3NS04NGQ2LTE4NjZiZWMyODdmMSIsImNsaWVudF9pZCI6Ijg3ZTE4OWU3YzUwNjQyZDViN2I2Zjc0ZjU0NzVmMDhhIn0.g_mQATHUSsPTFNCF-azRmmtQ8Fl6vm3uLWv9XTRHnNKjQzmNfBCfQX6AH1WIp52i0dqdz5u70hCXm2xMXShxechMDF6Vrl4PS468jIxgMm7l1q3fX2DOJKuLDzBnqRr5mMal0_5OyJjzZbX1vM-JLxdGZ4l5wP3HyM76iRm5npemB5_9Lv9IMuRwxEbD2ZpoWMfJruVrn_664rallHshCfKXydDgH1OAHG5dfurnsRxq0tHmS1y39L5FCcWZ7rdQFnYnn8lFjd0k2xasmfqyF58gTfIAyYVGAD8pa07lPkCxuDXrzRMmBXiIbl09i3gAtIJ_aDyIIBBS2z8Q8JwwQPvPmqhnSCVvIWepId47otnzCyMOpYUiqH2msN2a_udM4zUgzYhy67oA3cWf_UXJi2N3z6H4RX8eTKaeWP7X9DNT6Z7sbQkkswNHGAnJa2BaDZCm4tI_fIgkiLOeVtOrGhvYQAJBFvrKmmJsbcBbIoVxtyGiCowHJizI7HS9S9n7T2xFicKp5X6oyYC5my8DkFaaPuNdAsP979pLkTvzJumv5rSUv1ml79yVx7Wz_9ORQAO2WaXjOPTiwTVr3WKIXPLatrrh4NpFLTe3MvW5xFNQV1Tstb-wcj3KLfnYqGukCIQ292ddVFZIPaSfQTU-DG3S3XX_YAEzYZ6OutZ8iWM";

            var result = GetBillingEntries(token).Result;

            System.IO.File.WriteAllText("JsonFilesFromAllegroAPI.txt", result);

            Console.WriteLine("Content written to file successfully.");


        }

        public static async Task<string> GetBillingEntries(string token)
        {
            HttpClient client = new HttpClient();

            string url = "https://api.allegro.pl.allegrosandbox.pl/billing/billing-entries";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}
