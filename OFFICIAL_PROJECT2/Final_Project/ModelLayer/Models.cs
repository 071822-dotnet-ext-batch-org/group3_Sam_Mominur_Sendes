namespace ModelLayer;
public class Models
{
    //------------User Section -----------------
    /// <summary>
    /// This is a user's role status
    /// </summary>
    public enum Status
    {
        User = 1,
        Admin = 2
    }

    public enum OrderStatus
    {
        Pending = 0,
        Bounced = 1,
        Approved = 2,
        Canceled = 3
    }
    /// <summary>
    /// This is a Guest class (first, last, email)
    /// </summary>
    public class Guest
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public Guest() { }
        public Guest(string firstname, string lastname, string email) { }
    }//End of Base Class

    /// <summary>
    /// This is a User class (id, username, password, first, last, email, role, signupDate)
    /// </summary>
    public class User : Guest
    {
        public Guid PK_UserID { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public DateTime SignupDate { get; set; }
        public Status Role { get; set; }

        public User() { }
        public User(Guid id, string username, string password, string firstname, string lastname, string email, Status role, DateTime signUpDate) : base(firstname, lastname, email)
        {
            this.PK_UserID = id;
            this.Username = username;
            this.Password = password;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Role = Status.User;
            this.SignupDate = signUpDate;
        }
    }//End of User Class

    //------------Product Section -----------------
    /// <summary>
    /// This is a front end product (publicID, title, desc, price, inventory, dateAdded)
    /// </summary>
    public class FrontEnd_Product
    {
        public int ID { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public int Inventory { get; set; }
        public DateTime DateAdded { get; set; }

        public FrontEnd_Product() { }
        public FrontEnd_Product(int publicId, string title, string desc, decimal price, int inventory, DateTime creationDate)
        {
            this.ID = publicId;
            this.Title = title;
            this.Description = desc;
            this.Price = price;
            this.Inventory = inventory;
            this.DateAdded = creationDate;
        }

    }//End of Front End Product
    /// <summary>
    /// This is a back end product (privateID, publicID, title, desc, price, inventory, dateAdded, productCreator)
    /// </summary>
    public class Product : FrontEnd_Product
    {
        public Guid PK_ProductID { get; set; }
        public string CreatedBy { get; set; } = "";

        public Product() { }
        public Product(Guid privateID, int publicID, string title, string desc, decimal price, int inventory, DateTime creationDate, string productCreator) : base(publicID, title, desc, price, inventory, creationDate)
        {
            //this.ID = publicId;
            this.PK_ProductID = privateID;
            this.ID = publicID;
            this.Title = title;
            this.Description = desc;
            this.Price = price;
            this.Inventory = inventory;
            this.DateAdded = creationDate;
            this.CreatedBy = productCreator;
        }

    }//End of Back End Product

    /// <summary>
    /// This is the Order for Front End
    /// </summary>
    public class FrontEnd_Order : Guest
    {
        
        public string StreetAddress { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Country { get; set; } = "";
        public int AreaCode { get; set; }
        public List<int> ProductIDs { get; set; } = new List<int>();
        public FrontEnd_Order() { }
        public FrontEnd_Order(string firstname, string lastname, string email, string streetAddy, string city, string state, string country, int zip, List<int> productIDs) : base(firstname, lastname, email)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.AreaCode = zip;
            this.ProductIDs = productIDs;
        }
    }//End OF FRONT END ORDER

    //------------Order Section -----------------
    /// <summary>
    /// This is the Order class (orderID, firstname, lastname, email, cart(list of prod), orderTotal, datePurchased)
    /// </summary>
    public class Order : FrontEnd_Order
    {
        public Guid OrderID { get; set; }
        public decimal Total { get; set; }
        public DateTime DatePurchased { get; set; }
        public OrderStatus Status { get; set; }
        public List<Models.Product> UserCart { get; set; } = new List<Models.Product>();


        public Order() { }
        public Order(Guid id, string firstname, string lastname, string email, string streetAddy, string city, string state, string country, int zip, decimal totalAmount, DateTime purchaseDate, List<int> productIDs, List<Models.Product> cart) : base( firstname, lastname, email , streetAddy, city, state, country, zip, productIDs)
        {
            
            this.OrderID = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.StreetAddress = streetAddy;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.AreaCode = zip;
            this.Total = totalAmount;
            this.DatePurchased = purchaseDate;
            this.Status = OrderStatus.Pending;
            this.ProductIDs = productIDs;
            this.UserCart = cart;

        }

        public void SetOrderTotal()
        {
            foreach(Models.Product product in this.UserCart)
            {

                this.Total += product.Price;

            }
            Console.WriteLine($"\n\n\t\tAn Order totaling ${this.Total}:C2 was made LETSS GOOO BOIII!!!\n\n");
        }
    }//End of Order

    /// <summary>
    /// This is the relation for and Order and its Products 
    /// </summary>
    public class ProductsOfOrder
    {
        public KeyValuePair<Guid,List<KeyValuePair<Guid,Guid>>> ListOfRelations = new KeyValuePair<Guid, List<KeyValuePair<Guid, Guid>>>();
        public ProductsOfOrder() { }
        
    }

}
