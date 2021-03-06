﻿namespace meeting_bs_generator.Models.Responses
{
    public class Response
    {
        /// <summary>
        /// The object containing the speech to render to the user
        /// </summary>
        public IOutputSpeech OutputSpeech { get; set; }

        /// <summary>
        /// The object containing a card to render to the Amazon Alexa App. 
        /// </summary>
        //public ICard Card { get; set; }

        /// <summary>
        /// The object containing the outputSpeech to use if a re-prompt is necessary.
        /// 
        /// This is used if the your service keeps the session open after 
        /// sending the response, but the user does not respond with anything 
        /// that maps to an intent defined in your voice interface while the audio 
        /// stream is open.
        /// 
        /// If this is not set, the user is not re-prompted.
        /// </summary>
        //public Reprompt Reprompt { get; set; }

        /// <summary>
        /// A boolean value with true meaning that the session should end, 
        /// or false if the session should remain active.
        /// </summary>
        public bool ShouldEndSession { get; set; }

        public Directive[] directives
        {
            get; set;
        }
    }
}