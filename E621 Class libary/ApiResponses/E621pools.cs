namespace E621_Wrapper
{
    public class E621pools
    {
        public int id { get; set; }

        public string name { get; set; }

        public string created_at { get; set; }

        public string updated_at { get; set; }

        public int creator_id { get; set; }

        public string description { get; set; }
        public bool is_active { get; set; }

        public string catergory { get; set; }

        public bool is_deleted { get; set; }

        public int[] post_ids { get; set; }
    }
}