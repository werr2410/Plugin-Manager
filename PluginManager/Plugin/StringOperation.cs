namespace PManager {
    partial class Plugin {
        protected string StringVisual() {
            var builder = new System.Text.StringBuilder();

            builder.Append(Name + "|");
            builder.Append(Description + "|");
            builder.Append(CreationDateTime + "|");
            builder.Append(Language + "|");

            return builder.ToString();
        }

        protected void FromString(string plugin) {
            var elements = plugin.Split("|");

            if(elements.Length != CountElement)
                throw new FormatException("Plugin file doesnt work normal");
            
            int counter = 0;

            Name            = elements[counter++];
            Description     = elements[counter++];
            CreationDate    = DateTime.Parse(elements[counter++]);

            Language lang = Language.None;
            if(!Language.TryParse<Language>(elements[counter++], out lang))
                throw new FormatException("Plugin file doesnt work normal");
            
            Language = lang;
        }
    }
}