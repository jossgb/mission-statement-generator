namespace meeting_bs_generator.Models.Responses
{
    public class Reprompt
    {
        /// <summary>
        /// An OutputSpeech object containing the text or SSML to render as a re-prompt.
        /// </summary>
        public IOutputSpeech OutputSpeech { get; set; }
    }
}