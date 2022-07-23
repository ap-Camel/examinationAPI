namespace exmainationApi.Models {
    public record Tag {
        public int ID {get; init;}
        public string tagName {get; init;} = string.Empty;
    }
}