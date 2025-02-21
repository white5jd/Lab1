namespace Lab1Final.Pages.DataClasses
{
    public class Grant
    {
        public int grantID { get; set; }

        public String? grantName { get; set; }

        public String? submissionDate { get; set; }

        public String? awardDate { get; set; }

        public Decimal awardAmount { get; set; }

        public String? grantStatus { get; set; }

        public String? grantCategory { get; set; }

        public int agencyID { get; set; }

        public int projectID { get; set; }

    }
}
