namespace exmainationApi.Models {
    public record Settings {
        public int ID {get; init;}
        public string title {get; init;} = string.Empty;
    }
}