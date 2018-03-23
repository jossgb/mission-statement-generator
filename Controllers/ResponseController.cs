using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using meeting_bs_generator.Models;
using meeting_bs_generator.Models.Responses;
using meeting_bs_generator.Models.Requests;
using meeting_bs_generator.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net;
using System.Text;
using System.IO;

namespace meeting_bs_generator.Controllers
{
    [Route("api/[controller]")]
    public class ReponseController : Controller
    {


        public ReponseController()
        {

        }

        //", GET api/values
        [HttpGet]
        public string Get()
        {
            Random random = new Random(DateTime.UtcNow.Second * DateTime.UtcNow.Millisecond);
            random.Next();
            String s = String.Format(mainText,
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)],
            buzzWords[random.Next(0, buzzWords.Length)]);

            return s;
        }

        [HttpGet("{projectName}")]
        public string Get(string projectName)
        {
            return (Get());
        }

        [HttpPost]
        public SkillResponse Post()
        {
            //Were returning a SkillResponse
            //[FromBody]SkillRequest value
            DateTime now = DateTime.Now; // reference time for this request

            var memStream = new MemoryStream();
            HttpContext.Request.Body.CopyTo(memStream);
            //Verify Signature
            string signatureCertChainUrl = HttpContext.Request.Headers["SignatureCertChainUrl"];
            string signature = HttpContext.Request.Headers["Signature"];

            var requestBytes = memStream.ToArray();
            var requestString = System.Text.Encoding.UTF8.GetString(requestBytes);

            var value = JsonConvert.DeserializeObject<SkillRequest>(requestString);

            var validCertification = AmazonSignatureVerifier.VerifyRequestSignature(requestBytes, signature, signatureCertChainUrl);


            if (!validCertification)
            {
                HttpContext.Response.StatusCode = 400;
                return new SkillResponse();
            }

            //Verify timestamp

            var timestampValid = AmazonSignatureVerifier.VerifyRequestTimestamp(value.Request.Timestamp, now);

            if (!timestampValid)
            {
                HttpContext.Response.StatusCode = 400;
                return new SkillResponse();
            }

            return SkillResponseHelper.EndSessionWithMessage(value.Request.Type + " blah lah");

            switch (value.Request.Type)
            {
                case "LaunchRequest":
                    return SkillResponseHelper.EndSessionWithMessage(Get());

                case "SessionEndedRequest":
                    return SkillResponseHelper.EndSessionWithMessage("Goodbye");
            }



            if (value.Request.Intent.Name == "AMAZON.HelpIntent")
            {
                return SkillResponseHelper.RespondWithHelpMesseage();
            }
            else if (value.Request.Intent.Name == "AMAZON.StopIntent")
            {
                return SkillResponseHelper.EndSessionWithMessage("Goodbye");
            }
            else if (value.Request.Intent.Name == "AMAZON.CancelIntent")
            {
                return SkillResponseHelper.EndSessionWithMessage("Goodbye");
            }
            else if (value.Request.Intent.Name == "projectResponse")
            {
                var projectName = value.Request.Intent.Slots["projectName"].Value;
                if (String.IsNullOrEmpty(projectName))
                {
                    return SkillResponseHelper.EndSessionWithMessage(Get());
                }
                else
                {
                    return SkillResponseHelper.EndSessionWithMessage(Get(projectName));
                }
            }
            else
            {
                return SkillResponseHelper.EndSessionWithMessage(Get());

            }
        }

        private string mainText = "Our strategy is {0}. We will lead a {1} effort of the market through our use of {2} and {3}  to build a {4}. By being both {5} and {6}, our {7} approach will drive {8} throughout the organisation. Synergies between our {9} and {10} will enable us to capture the upside by becoming {11} in a {12} world. These transformations combined with {13} due to our {14} will create a {15} through {16} and {17}";

        private string[] buzzWords = {
   "digital first",
   "agile",
   "open",
   "innovative",
   "efficiency",
   "competitive advantage",
   "ecosystem",
   "networked",
   "collaborative",
   "learning organisation",
   "social media",
   "revolution",
   "cloud based",
   "big data",
   "secure",
   "internet of things",
   "growth",
   "value",
   "customer focused",
   "digital business",
   "disruptive",
   "data leaders",
   "big data",
   "insight from data",
   "platform",
   "sustainable",
   "revolution",
   "culture",
};
    }
}
