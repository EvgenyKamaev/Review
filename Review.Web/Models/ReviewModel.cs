namespace Review.Web.Models
{
    public class ReviewModel
    {
        public string Organization { get; set; }

        public string Address { get; set; }

        public int Rate { get; set; }

        public ReviewInfoModel ReviewInfo { get; set; }
    }
}