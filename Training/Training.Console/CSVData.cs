namespace Training
{
    public class CSVData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string IPAddress { get; set; }

        public CSVData(int id, string fName, string lName, string email, string gender, string ipAdd)
        {
            this.Id = id;
            this.FirstName = fName;
            this.LastName = lName;
            this.Email = email;
            this.Gender = gender;
            this.IPAddress = ipAdd;
        }

        public override string ToString() 
        {
            return $"{Id} :: Name: {FirstName} {LastName} -- Email: {Email} -- Gender: {Gender} -- IP: {IPAddress}";
        }
    }
}