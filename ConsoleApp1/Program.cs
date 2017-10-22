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

namespace ConsoleApp1
{
    class Driver
    {
        static void Main(string[] args)
        {
            var r = new Reader();
            bool HoloLensOn = true;

            var writer = new JsonWriter();
            var serializer = new JsonSerializer();
            JObject json = JObject.Parse(string);


            while (HoloLensOn)
            {
                Task<string> temp = r.ReadEmotions();
                String json = temp.Result;


            }
        }
    }

    class Reader
    {

        public Reader() {}

        public async Task<string> ReadEmotions()
        {
            var client = new HttpClient();

            // Request headers - replace this example key with your valid key.
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "130562a8eac64d94845518dd78c50fc6");

            string uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?";
            HttpResponseMessage response;

            // Request body. Try this sample with a locally stored JPEG image.
            byte[] byteData = GetImageAsByteArray("IMAGE");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                return response.Content.Read
            }
        }

        private byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
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
