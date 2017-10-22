using System;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApp1
{
    class Driver
    {
        static void Main(string[] args)
        {
            var ser = new JavaScriptSerializer();
            var r = new Reader();
            bool HoloLensOn = true;
            
            


            while (HoloLensOn)
            {
                String json = r.ReadEmotions().Result;
                var faces = ser.Deserialize<Temp>(json).faces;
                ObjectInfo[] people = new ObjectInfo[faces.Length];
                for (int i = 0; i < faces.Length; i++)
                {
                    var temp = faces[i];
                    people[i] = new ObjectInfo(temp.location.left, temp.location.top,
                        temp.location.width, temp.location.height, temp.scores.Emotion());
                }
            }
        }
    }



    public class Temp
    {
        public Person[] faces { get; set; }
    }

    public class Person
    {
        public Location location { get; set; }
        public Scores scores { get; set; }
    }

    public class Location
    {
        public int top { get; set; }
        public int left { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Scores
    {

        public float anger { get; set; }
        public float contempt { get; set; }
        public float disgust { get; set; }
        public float fear { get; set; }
        public float happiness { get; set; }
        public float neutral { get; set; }
        public float sadness { get; set; }
        public float surprise { get; set; }

        public string Emotion()
        {
            if (anger > 0.7)
            {
                return "anger";
            }
            else if (contempt > 0.7)
            {
                return "contempt";
            }
            else if (disgust > 0.7)
            {
                return "disgust";
            }
            else if (fear > 0.7)
            {
                return "fear";
            }
            else if (happiness > 0.7)
            {
                return "happiness";
            }
            else if (neutral > 0.7)
            {
                return "neutral";
            }
            else if (sadness > 0.7)
            {
                return "sadness";
            }
            else if (surprise > 0.7)
            {
                return "sadness";

            } else
            {
                return "";
            }
        }
    }

    class Reader
    {

        public Reader() { }

        public async Task<string> ReadEmotions()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "130562a8eac64d94845518dd78c50fc6");

            string uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?";
            HttpResponseMessage response;
.
            //TODO: input actual method
            byte[] byteData = KORYSMETHOD();

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }

    class ObjectInfo
    {
        private readonly int left;
        private readonly int top;
        private readonly int width;
        private readonly int height;
        private readonly string emotion;

        public ObjectInfo(int left, int top, int width, int height, string emotion)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
            this.emotion = emotion;
        }

        public int Left
        {
            get
            {
                return left;
            }
        }

        public int Top
        {
            get
            {
                return top;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
        }

        public String Emotion
        {
            get
            {
                return emotion;
            }
        }
    }

}
