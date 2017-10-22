using System;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                    people[i] = new ObjectInfo((short) temp.location.left, (short) temp.location.top
                        (short) temp.location.width, (short) temp.location.height, temp.scores.Emotion);
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
        public static const double CUTOFF = 0.7;

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
            if (anger > CUTOFF)
            {
                return "anger";
            }
            else if (contempt > CUTOFF)
            {
                return "contempt";
            }
            else if (disgust > CUTOFF)
            {
                return "disgust";
            }
            else if (fear > CUTOFF)
            {
                return "fear"
            }
            else if (happiness > CUTOFF)
            {
                return "happiness"
            }
            else if (neutral > CUTOFF)
            {
                return "neutral";
            }
            else if (sadness > CUTOFF)
            {
                return "sadness";
            }
            else if (surprise > CUTOFF)
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
        private readonly short left;
        private readonly short top;
        private readonly short width;
        private readonly short height;
        private readonly string emotion;

        public ObjectInfo(short left, short top, short width, short height, string emotion)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
            this.emotion = emotion;
        }

        public short Left
        {
            get
            {
                return left;
            }
        }

        public short Top
        {
            get
            {
                return top;
            }
        }

        public short Width
        {
            get
            {
                return width;
            }
        }

        public short Height
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

    class JSonParser
    {
        private String cheese;
        private int index;

        public JSonParser(String JSon)
        {
            cheese = JSon;
            index = 0;
        }

        public Stack<ObjectInfo> Parse()
        {
            /*
            advanceTo("height:");
            while (index < cheese.Length && index > 0)
            {
                short height = 
            }
            */









            return null;
        }

        private void advanceTo(String target)
        {
            index = cheese.IndexOf(target, index + 1);
            index += target.Length;
        }

        private short getInt()
        {
            int length = cheese.IndexOf(",") - 1;
            return short.Parse(cheese.Substring(index, length));
        }
    }
}
