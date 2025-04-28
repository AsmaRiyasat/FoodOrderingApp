    public class Items
    {
        private string? item_name;
        private float item_price;


        public Items() { }



        public string ItemName
        {
            get
            {
                return item_name!;
            }
            set
            {
                item_name = value;
            }
        }

        public float ItemPrice
        {
            get
            {
                return item_price!;
            }
            set
            {
                item_price = value;
            }
        }



        public override string ToString()
        {
            return $"{item_name}, {item_price}";
        }
    }
