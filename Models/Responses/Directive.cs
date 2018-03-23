namespace meeting_bs_generator.Models.Responses
{
    public class Directive
    {
        public string type { get; set; }
        public string slotToElicit { get; set; }
        public Updatedintent updatedIntent { get; set; }
    }

    public class Updatedintent
    {
        public string name { get; set; }
        public string confirmationStatus { get; set; }
        public Slots slots { get; set; }
    }

    public class Slots
    {
        public Destination destination { get; set; }
        public Source source { get; set; }

    }

    public class Destination
    {
        public string name { get; set; }
        public string confirmationStatus { get; set; }
        public string value { get; set;}
    }

    public class Source
    {
        public string name { get; set; }
        public string confirmationStatus { get; set; }
        public string value { get; set;}
    }

}