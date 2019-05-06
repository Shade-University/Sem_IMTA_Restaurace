namespace Sem_IMTA_Restaurace.Models
{
    public class Rating
    {
        public double Rating_Value { get; private set; }
        public string Rating_Text { get; private set; }
        public int Votes { get; private set; }

        public Rating(double user_rating, string user_rating_text, int votes)
        {
            Rating_Value = user_rating;
            Rating_Text = user_rating_text;
            Votes = votes;
        }
    }
}
