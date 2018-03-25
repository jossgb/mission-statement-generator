using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meeting_bs_generator.Models.Requests;
using meeting_bs_generator.Models.Responses;

namespace meeting_bs_generator.Helpers
{
    public class SkillResponseHelper
    {
        private static SkillResponse CreateBaseResponse(bool endSession)
        {
            var rv = new SkillResponse();
            var response = new Response();
            // var outputSpeech = new SsmlOutputSpeech();

            // outputSpeech.Ssml = "<speak>It will take 14 hours 56 mins minutes to drive to " + destination + "</speak>";
            rv.SessionAttributes = new Dictionary<string, object>();
            // response.OutputSpeech = outputSpeech;
            response.ShouldEndSession = endSession;

            rv.Response = response;
            rv.Version = "1.0";

            return rv;
        }

        public static SkillResponse EndSessionWithMessage(string message)
        {
            var rv = SkillResponseHelper.CreateBaseResponse(true);
            var outputSpeech = new SsmlOutputSpeech();

            outputSpeech.Ssml = "<speak>" + message + "</speak>";
            rv.Response.OutputSpeech = outputSpeech;

            return rv;
        }

        public static SkillResponse ContinueSessionWithMessage(string message) {
              var rv = SkillResponseHelper.CreateBaseResponse(false);
            var outputSpeech = new SsmlOutputSpeech();

            outputSpeech.Ssml = "<speak>" + message + "</speak>";
            rv.Response.OutputSpeech = outputSpeech;

            return rv;
        }

        public static SkillResponse RespondWithHelpMesseage()
        {
            var instructionMesesage = "Need a strategy? Can't be bothered to understand your landscape? Don't care about situational awareness or gameplay? Need it fast? Minimal effort? No problem! Simpy ask mission statement for a mission statement or strategy, and I will work it out for you! Would you like me to generate a strategy for you?";
            var rv = SkillResponseHelper.CreateBaseResponse(false);
            var outputSpeech = new SsmlOutputSpeech();

            outputSpeech.Ssml = "<speak> " + instructionMesesage + " </speak>";
            rv.Response.OutputSpeech = outputSpeech;

            rv.Response.ShouldEndSession = false;

            return rv;
        }

        // public static SkillResponse RespondWithTime(string source, string destination, string timeValue)
        // {
        //     var rv = SkillResponseHelper.CreateBaseResponse();
        //     var outputSpeech = new SsmlOutputSpeech();

        //     outputSpeech.Ssml = "<speak>It will take about " + timeValue + " to drive to " + destination + " from " + source + "</speak>";
        //     rv.Response.OutputSpeech = outputSpeech;

        //     return rv;
        // }

        // public static SkillResponse RepondWithDialogDirective(Intent currentIntent)
        // {
        //     //TODO: THIS
        //     var rv = new SkillResponse();
        //     var response = new Response();
        //     var outputSpeech = new SsmlOutputSpeech();

        //     rv.SessionAttributes = new Dictionary<string, object>();
        //     response.ShouldEndSession = false;

        //     rv.Response = response;
        //     rv.Version = "1.0";

        //     rv.Response.directives = new Directive[1];
        //     rv.Response.directives[0] = new Directive();
        //     var updatedIntent = new Updatedintent();

        //     updatedIntent.name = currentIntent.Name;
        //     updatedIntent.confirmationStatus = "NONE";
        //     updatedIntent.slots = new Slots();
        //     updatedIntent.slots.destination = new Destination();
        //     updatedIntent.slots.source = new Source();
        //     updatedIntent.slots.source.name = "source";
        //     updatedIntent.slots.source.confirmationStatus = "NONE";

        //     updatedIntent.slots.destination.name = "destination";
        //     updatedIntent.slots.destination.confirmationStatus = "NONE";

        //     updatedIntent.slots.destination.value = currentIntent.Slots["destination"].Value;
        //     updatedIntent.slots.source.value = currentIntent.Slots["source"].Value;
        //     rv.Response.directives[0].type = "Dialog.ElicitSlot";
        //     if (currentIntent.Slots["source"].Value == null || currentIntent.Slots["source"].Value.Length == 0)
        //     {
        //         rv.Response.directives[0].slotToElicit = "source";
        //         outputSpeech.Ssml = "<speak>Where would you like to drive from?</speak>";
        //         updatedIntent.slots.source.value = "";
        //     }
        //     else
        //     {
        //         updatedIntent.slots.destination.value = "";
        //         rv.Response.directives[0].slotToElicit = "destination";
        //         outputSpeech.Ssml = "<speak>Where would you like to drive to?</speak>";
        //     }


        //     rv.Response.OutputSpeech = outputSpeech;

        //     rv.Response.directives[0].updatedIntent = updatedIntent;


        //     return rv;
       // }

        /// Called when the user just opens the app. Tell them what to do

    }
}